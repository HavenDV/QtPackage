using System;
using System.Collections;
using System.IO;
using Microsoft.Win32;
using System.Collections.Generic;

namespace Digia.Qt5ProjectLib {
    /// <summary>
    /// Summary description for QtVersionManager.
    /// </summary>
    public class QtVersionManager {
        private static QtVersionManager instance = null;
        private string regVersionPath = null;
        private string strVersionKey = null;
        private Hashtable versionCache = null;

        protected QtVersionManager() {
            strVersionKey = "Versions";
            regVersionPath = Resources.registryVersionPath;
        }

        static public QtVersionManager The() {
            return instance = instance ?? new QtVersionManager();
        }

        public VersionInformation GetVersionInfo( string name ) {
            if ( name == null ) {
                return null;
            }
            if ( name == "$(DefaultQtVersion)" ) {
                name = GetDefaultVersion();
            }
            versionCache = versionCache ?? new Hashtable();

            var information = versionCache[ name ] as VersionInformation;
            if ( information != null ) {
                return information;
            }

            var qtDir = GetInstallPath( name );
            information = new VersionInformation( qtDir );
            versionCache[ name ] = information;
            return information;
        }

        public VersionInformation GetVersionInfo( EnvDTE.Project project ) {
            return GetVersionInfo( GetProjectQtVersion( project ) );
        }

        public void ClearVersionCache() {
            if ( versionCache != null ) {
                versionCache.Clear();
            }
        }

        public string[] GetVersions() {
            return GetVersions( Registry.CurrentUser );
        }

        public string GetQtVersionFromInstallDir( string qtDir ) {
            if ( qtDir == null ) {
                return null;
            }

            var versions = GetVersions();
            foreach ( string version in versions ) {
                var installPath = GetInstallPath( version );
                if ( installPath == null ) {
                    continue;
                }
                if ( installPath.Equals( qtDir, StringComparison.OrdinalIgnoreCase ) ) {
                    return version;
                }
            }

            return null;
        }

        public string[] GetVersions( RegistryKey root ) {
            var key = root.OpenSubKey( "SOFTWARE\\" + Resources.registryRootPath, false );
            if ( key == null )
                return new string[] { };
            var versionKey = key.OpenSubKey( strVersionKey, false );
            if ( versionKey == null )
                return new string[] { };
            return versionKey.GetSubKeyNames();
        }

        private class QtVersion {
            public QtVersion( string _name, VersionInformation _info ) {
                name = _name;
                info = _info;
            }

            public string name {
                get;
                private set;
            }

            public VersionInformation info {
                get;
                private set;
            }
        }

        /// <summary>
        /// Check if all Qt versions are valid and readable.
        /// </summary>
        /// Also sets the default Qt version to the newest version, if needed.
        /// <param name="errorMessage"></param>
        /// <returns>true, if we found an invalid version</returns>
        public bool HasInvalidVersions( out string errorMessage ) {
            var validVersions = new List<QtVersion>();
            var invalidVersions = new List<string>();

            foreach ( string v in GetVersions() ) {
                if ( v == "$(DefaultQtVersion)" )
                    continue;
                try {
                    var info = new VersionInformation( GetInstallPath( v ) );
                    var version = new QtVersion( v, info );
                    //version.name = v;
                    //version.info = info;

                    validVersions.Add( version );
                }
                catch ( Exception ) {
                    invalidVersions.Add( v );
                }
            }

            if ( invalidVersions.Count > 0 ) {
                errorMessage = "These Qt version are inaccessible:\n";
                foreach ( string invalidVersion in invalidVersions )
                    errorMessage += invalidVersion + " in " + GetInstallPath( invalidVersion ) + "\n";
                errorMessage += "Make sure that you have read access to all files in your Qt directories.";

                // Is the default Qt version invalid?
                bool isDefaultQtVersionInvalid = false;
                string defaultQtVersionName = GetDefaultVersion();
                if ( String.IsNullOrEmpty( defaultQtVersionName ) ) {
                    isDefaultQtVersionInvalid = true;
                }
                else {
                    foreach ( string name in invalidVersions ) {
                        if ( name == defaultQtVersionName ) {
                            isDefaultQtVersionInvalid = true;
                            break;
                        }
                    }
                }

                // find the newest valid Qt version that can be used as default version
                if ( isDefaultQtVersionInvalid && validVersions.Count > 0 ) {
                    QtVersion defaultQtVersion = null;
                    foreach ( QtVersion v in validVersions ) {
                        if ( v.info.IsWinCEVersion() )
                            continue;
                        if ( defaultQtVersion == null ) {
                            defaultQtVersion = v;
                            continue;
                        }
                        if ( defaultQtVersion.info.qtMajor < v.info.qtMajor ||
                               ( defaultQtVersion.info.qtMajor == v.info.qtMajor && ( defaultQtVersion.info.qtMinor < v.info.qtMinor ||
                                   ( defaultQtVersion.info.qtMinor == v.info.qtMinor && defaultQtVersion.info.qtPatch < v.info.qtPatch ) ) ) ) {
                            defaultQtVersion = v;
                        }
                    }
                    if ( defaultQtVersion != null )
                        SaveDefaultVersion( defaultQtVersion.name );
                }

                return true;
            }
            errorMessage = null;
            return false;
        }

        public string GetInstallPath( string version ) {
            if ( version == "$(DefaultQtVersion)" )
                version = GetDefaultVersion();
            return GetInstallPath( version, Registry.CurrentUser );
        }

        public string GetInstallPath( string version, RegistryKey root ) {
            if ( version == "$(DefaultQtVersion)" )
                version = GetDefaultVersion( root );
            if ( version == "$(QTDIR)" )
                return System.Environment.GetEnvironmentVariable( "QTDIR" );

            var key = root.OpenSubKey( "SOFTWARE\\" + Resources.registryRootPath, false );
            if ( key == null )
                return null;
            var versionKey = key.OpenSubKey( strVersionKey + "\\" + version, false );
            if ( versionKey == null )
                return null;
            return ( string )versionKey.GetValue( "InstallDir" );
        }

        public string GetInstallPath( EnvDTE.Project project ) {
            string version = GetProjectQtVersion( project );
            if ( version == "$(DefaultQtVersion)" )
                version = GetDefaultVersion();
            if ( version == null )
                return null;
            return GetInstallPath( version );
        }

        public bool SaveVersion( string versionName, string path ) {
            string verName = versionName.Trim();
            string dir = "";
            if ( verName != "$(QTDIR)" ) {
                var di = new DirectoryInfo( path );
                if ( verName.Length < 1 || !di.Exists )
                    return false;
                dir = di.FullName;
            }
            var key = Registry.CurrentUser.OpenSubKey( "SOFTWARE\\" + Resources.registryRootPath, true );
            if ( key == null ) {
                key = Registry.CurrentUser.CreateSubKey( "SOFTWARE\\" + Resources.registryRootPath );
                if ( key == null )
                    return false;
            }
            var versionKey = key.CreateSubKey( strVersionKey + "\\" + verName );
            if ( versionKey == null )
                return false;
            versionKey.SetValue( "InstallDir", dir );
            return true;
        }

        public void RemoveVersion( string versionName ) {
            var key = Registry.CurrentUser.OpenSubKey( "SOFTWARE\\" + regVersionPath, true );
            if ( key == null ) {
                return;
            }
                
            key.DeleteSubKey( versionName );
        }

        private bool IsVersionAvailable( string version ) {
            var versions = GetVersions();
            foreach ( string ver in versions ) {
                if ( version == ver ) {
                    return true;
                }
            }

            return false;
        }

        public bool SaveProjectQtVersion( EnvDTE.Project project, string version ) {
            return SaveProjectQtVersion( project, version, project.ConfigurationManager.ActiveConfiguration.PlatformName );
        }

        public bool SaveProjectQtVersion( EnvDTE.Project project, string version, string platform ) {
            if ( !IsVersionAvailable( version ) && version != "$(DefaultQtVersion)" )
                return false;
            string key = "Qt5Version " + platform;
            if ( !project.Globals.get_VariableExists( key ) || project.Globals[ key ].ToString() != version )
                project.Globals[ key ] = version;
            if ( !project.Globals.get_VariablePersists( key ) )
                project.Globals.set_VariablePersists( key, true );
            return true;
        }

        public string GetProjectQtVersion( EnvDTE.Project project ) {
            string platformName = null;
            try {
                platformName = project.ConfigurationManager.ActiveConfiguration.PlatformName;
            }
            catch {
                // Accessing the ActiveConfiguration property throws an exception
                // if there's an "unconfigured" platform in the Solution platform combo box.
                platformName = "Win32";
            }
            string version = GetProjectQtVersion( project, platformName );

            if ( version == null && project.Globals.get_VariablePersists( "Qt5Version" ) ) {
                version = ( string )project.Globals[ "Qt5Version" ];
                ExpandEnvironmentVariablesInQtVersion( ref version );
                return VerifyIfQtVersionExists( version ) ? version : null;
            }

            if ( version == null )
                version = GetSolutionQtVersion( project.DTE.Solution );

            return version;
        }

        public string GetProjectQtVersion( EnvDTE.Project project, string platform ) {
            string key = "Qt5Version " + platform;
            if ( !project.Globals.get_VariablePersists( key ) )
                return null;
            string version = ( string )project.Globals[ key ];
            ExpandEnvironmentVariablesInQtVersion( ref version );
            return VerifyIfQtVersionExists( version ) ? version : null;
        }

        private static void ExpandEnvironmentVariablesInQtVersion( ref string version ) {
            if ( version != "$(QTDIR)" && version != "$(DefaultQtVersion)" ) {
                // Make it possible to specify the version name
                // via an environment variable
                System.Text.RegularExpressions.Regex regExp =
                    new System.Text.RegularExpressions.Regex( "\\$\\((?<VarName>\\S+)\\)" );
                System.Text.RegularExpressions.Match match = regExp.Match( version );
                if ( match.Success ) {
                    string env = match.Groups[ "VarName" ].Value;
                    version = System.Environment.GetEnvironmentVariable( env );
                }
            }
        }

        public bool SaveSolutionQtVersion( EnvDTE.Solution solution, string version ) {
            if ( !IsVersionAvailable( version ) && version != "$(DefaultQtVersion)" )
                return false;
            solution.Globals[ "Qt5Version" ] = version;
            if ( !solution.Globals.get_VariablePersists( "Qt5Version" ) )
                solution.Globals.set_VariablePersists( "Qt5Version", true );
            return true;
        }

        public string GetSolutionQtVersion( EnvDTE.Solution solution ) {
            if ( solution == null )
                return null;

            if ( solution.Globals.get_VariableExists( "Qt5Version" ) ) {
                string version = ( string )solution.Globals[ "Qt5Version" ];
                return VerifyIfQtVersionExists( version ) ? version : null;
            }

            return null;
        }

        public string GetDefaultVersion() {
            return GetDefaultVersion( Registry.CurrentUser );
        }

        public string GetDefaultVersion( RegistryKey root ) {
            string defaultVersion = null;
            try {
                var key = root.OpenSubKey( "SOFTWARE\\" + regVersionPath, false );
                if ( key != null )
                    defaultVersion = ( string )key.GetValue( "DefaultQtVersion" );
            }
            catch {
                Messages.DisplayWarningMessage( SR.GetString( "QtVersionManager_CannotLoadQtVersion" ) );
            }

            if ( defaultVersion == null ) {
                MergeVersions();
                RegistryKey key = root.OpenSubKey( "SOFTWARE\\" + regVersionPath, false );
                if ( key != null ) {
                    string[] versions = GetVersions();
                    if ( versions != null && versions.Length > 0 )
                        defaultVersion = versions[ versions.Length - 1 ];
                    if ( defaultVersion != null )
                        SaveDefaultVersion( defaultVersion );
                }
                if ( defaultVersion == null ) {
                    // last fallback... try QTDIR
                    string qtDir = System.Environment.GetEnvironmentVariable( "QTDIR" );
                    if ( qtDir == null )
                        return null;
                    DirectoryInfo d = new DirectoryInfo( qtDir );
                    SaveVersion( d.Name, d.FullName );
                    if ( SaveDefaultVersion( d.Name ) )
                        defaultVersion = d.Name;
                }
            }
            return VerifyIfQtVersionExists( defaultVersion ) ? defaultVersion : null;
        }

        public string GetDefaultWinCEVersion() {
            try {
                var key = Registry.CurrentUser.OpenSubKey( "SOFTWARE\\" + regVersionPath, false );
                if ( key != null )
                    return ( string )key.GetValue( "WinCEQtVersion" );
            }
            catch {
                Messages.DisplayWarningMessage( SR.GetString( "QtVersionManager_CannotLoadQtVersion" ) );
            }

            return GetDefaultVersion();
        }

        public bool SaveDefaultVersion( string version ) {
            if ( version == "$(DefaultQtVersion)" )
                return false;
            var key = Registry.CurrentUser.CreateSubKey( "SOFTWARE\\" + regVersionPath );
            if ( key == null )
                return false;
            key.SetValue( "DefaultQtVersion", version );
            return true;
        }

        public bool SaveDefaultWinCEVersion( string version ) {
            RegistryKey key = Registry.CurrentUser.CreateSubKey( "SOFTWARE\\" + regVersionPath );
            if ( key == null )
                return false;
            key.SetValue( "WinCEQtVersion", version );
            return true;
        }

        public static bool HasProjectQtVersion( EnvDTE.Project project ) {
            if ( project == null )
                return false;
            string platform = project.ConfigurationManager.ActiveConfiguration.PlatformName;
            if ( project.Globals.get_VariablePersists( "Qt5Version " + platform )
                || project.Globals.get_VariablePersists( "Qt5Version" ) )
                return true;
            else
                return false;
        }

        private void MergeVersions() {
            string[] hkcuVersions = GetVersions();
            string[] hklmVersions = GetVersions( Registry.LocalMachine );

            string[] hkcuInstDirs = new string[ hkcuVersions.Length ];
            for ( int i = 0; i < hkcuVersions.Length; ++i )
                hkcuInstDirs[ i ] = GetInstallPath( hkcuVersions[ i ] );
            string[] hklmInstDirs = new string[ hklmVersions.Length ];
            for ( int i = 0; i < hklmVersions.Length; ++i )
                hklmInstDirs[ i ] = GetInstallPath( hklmVersions[ i ], Registry.LocalMachine );

            for ( int i = 0; i < hklmVersions.Length; ++i ) {
                if ( hklmInstDirs[ i ] == null )
                    continue;

                bool found = false;
                for ( int j = 0; j < hkcuInstDirs.Length; ++j ) {
                    if ( hkcuInstDirs[ j ] != null &&
                         hkcuInstDirs[ j ].Equals( hklmInstDirs[ i ], StringComparison.OrdinalIgnoreCase ) ) {
                        found = true;
                        break;
                    }
                }
                if ( !found ) {
                    for ( int j = 0; j < hkcuVersions.Length; ++j ) {
                        if ( hkcuVersions[ j ] != null
                            && hkcuVersions[ j ] == hklmVersions[ i ] ) {
                            found = true;
                            break;
                        }
                    }
                    if ( !found )
                        SaveVersion( hklmVersions[ i ], hklmInstDirs[ i ] );
                }
            }
        }

        private bool VerifyIfQtVersionExists( string version ) {
            if ( version == "$(DefaultQtVersion)" )
                version = GetDefaultVersion();
            if ( version != null && version.Length > 0 ) {
                System.Text.RegularExpressions.Regex regExp =
                    new System.Text.RegularExpressions.Regex( "\\$\\(.*\\)" );
                if ( regExp.IsMatch( version ) )
                    return true;
                return Directory.Exists( GetInstallPath( version ) );
            }

            return false;
        }
    }
}
