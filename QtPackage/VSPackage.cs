using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

using EnvDTE;
using System.Windows.Forms;
using System.IO;

using Digia.Qt5ProjectLib;
using Microsoft.VisualStudio.VSHelp80;
using Microsoft.VisualStudio.VSHelp;

namespace QtPackage {
    [PackageRegistration( UseManagedResourcesOnly = true )]
    [InstalledProductRegistration( "#110", "#112", "1.3.9", IconResourceID = 400 )]
    [Guid( VSPackageGuids.PackageGuidString )]
    [ProvideAutoLoad( UIContextGuids.SolutionExists )]
    [SuppressMessage( "StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms" )]
    [ProvideMenuResource( "Menus.ctmenu", 1 )]
    [ProvideEditorFactory( typeof( uiEditorFactory ), 101, CommonPhysicalViewAttributes = 0 )]
    [ProvideEditorLogicalView( typeof( uiEditorFactory ), VSConstants.LOGVIEWID.TextView_string )]
    [ProvideEditorExtension( typeof( uiEditorFactory ), ".ui", 50 )]
    [ProvideEditorExtension( typeof( uiEditorFactory ), ".*", 1 )]
    [ProvideEditorFactory( typeof( qrcEditorFactory ), 102, CommonPhysicalViewAttributes = 0 )]
    [ProvideEditorLogicalView( typeof( qrcEditorFactory ), VSConstants.LOGVIEWID.TextView_string )]
    [ProvideEditorExtension( typeof( qrcEditorFactory ), ".qrc", 50 )]
    [ProvideEditorExtension( typeof( qrcEditorFactory ), ".*", 1 )]
    [ProvideEditorFactory( typeof( tsEditorFactory ), 103, CommonPhysicalViewAttributes = 0 )]
    [ProvideEditorLogicalView( typeof( tsEditorFactory ), VSConstants.LOGVIEWID.TextView_string )]
    [ProvideEditorExtension( typeof( tsEditorFactory ), ".ts", 50 )]
    [ProvideEditorExtension( typeof( tsEditorFactory ), ".*", 1 )]

    public sealed class VSPackage : Package {
        private AddInEventHandler eventHandler = null;

        public static VSPackage Instance {
            get;
            private set;
        }

        public VSPackage() {
            Instance = this;
        }

        #region Package Members

        public static DTE dte {
            get;
            private set;
        }

        public static Help2 help2 {
            get;
            private set;
        }

        public static ExtLoader extLoader {
            get;
            private set;
        }

        protected override void Initialize() {
            try
            {
                Commands.Initialize(this);
                base.Initialize();

                RegisterEditorFactory(new tsEditorFactory(this));
                RegisterEditorFactory(new qrcEditorFactory(this));
                RegisterEditorFactory(new uiEditorFactory(this));

                dte = ( DTE )GetService( typeof( DTE ) );
                help2 = ( Help2 )GetService( typeof( SVsHelp ) );
                
                var manager = QtVersionManager.The();
                string error = null;
                if ( manager.HasInvalidVersions( out error ) ) {
                    Messages.DisplayErrorMessage( error );
                }
                eventHandler = new AddInEventHandler( dte );
                extLoader = new ExtLoader();
                if ( !isTemplatesInstalled() ) {
                    InstallTemplates();
                }

                //var info = new VersionInformation( @"D:\Qt\5.6.0_beta_x64\5.6\msvc2015_64" ).GetInformationString();
                //MessageBox.Show( info );
            }
            catch ( Exception e ) {
                MessageBox.Show( "VSPackage.Initialize: " + e.Message + "\r\n\r\nStacktrace:\r\n" + e.StackTrace );
            }
        }

        public static string path {
            //Instance.UserDataPath UserLocalDataPath
            get {
                Uri uri = new Uri( System.Reflection.Assembly.GetExecutingAssembly().EscapedCodeBase );
                string path = Path.GetDirectoryName( Uri.UnescapeDataString( uri.AbsolutePath ) );
                return path + "\\";
            }
        }

        public static string idePath {
            get {
                return Instance.ApplicationRegistryRoot.GetValue( "InstallDir" ) as string;
            }
        }

        public static string vsPath {
            get {
                return Path.GetDirectoryName( Path.GetDirectoryName( Path.GetDirectoryName( idePath ) ) ) + @"\";
            }
        }

        public static string qt5Path {
            get {
                return path + @"Qt5\";
            }
        }

        public static string appWrapperPath {
            get {
                return qt5Path + "qt5appwrapper.exe";
            }
        }

        public static string qMakeFileReaderPath {
            get {
                return qt5Path + "qmakefilereader.exe";
            }
        }
        public static string qrcEditorPath {
            get {
                return qt5Path + "q5rceditor.exe";
            }
        }

        public static bool isTemplatesInstalled() {
            var path = vsPath + @"VC\vcprojects\Qt5 Projects\install_v1.3.9";
            return File.Exists( path );
        }

        //public static bool isRedistInstall()
        //{
        //var key = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\DevDiv\VC\Servicing\14.0\RuntimeMinimum");
        //var isInstall = key.GetValue("Install") ;

        //return isInstall;
        //}

        public static void InstallTemplates() {
            if ( MessageBox.Show( SR.GetString( "InstallTemplates" ),
                                SR.GetString( "InstallTemplatesTitle" ),
                                MessageBoxButtons.YesNo ) != DialogResult.Yes ) {
                return;
            }

            var processInfo = new ProcessStartInfo();

            processInfo.FileName = qt5Path + "regtemplate.exe";

            processInfo.Arguments = "\"'" + path + "'\" \"'" + vsPath + "'\"";
            processInfo.UseShellExecute = true;
            processInfo.Verb = "runas";
            processInfo.WindowStyle = ProcessWindowStyle.Hidden;

            System.Diagnostics.Process.Start( processInfo );
        }

        #endregion
    }
}
