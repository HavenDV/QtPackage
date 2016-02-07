namespace Digia.Qt5ProjectLib {
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Text.RegularExpressions;

    public class VersionInformation {
        public string qtDir = null;
        public uint   qtMajor = 0; // X in version x.y.z
        public uint   qtMinor = 0; // Y in version x.y.z
        public uint   qtPatch = 0; // Z in version x.y.z
        public bool   qt5Version = true;
        private QtConfig qtConfig = null;
        private QMakeConf qmakeConf = null;
        private string vsPlatformName = null;
        private bool qtWinCEVersion = false;

        public VersionInformation( string qtDirIn ) {
            qtDir = qtDirIn ?? Environment.GetEnvironmentVariable( "QTDIR" );
            if ( qtDir == null ) {
                return;
            }

            SetupPlatformSpecificData();
            qtConfig = new QtConfig( qtDir );
            qtMajor = qtConfig.qtMajor;
            qtMinor = qtConfig.qtMinor;
            qtPatch = qtConfig.qtPatch;
            qt5Version = qtMajor == 5;
            if ( qtMajor != 0 ) {
                return;
            }

            try {
                string[] candidates = { "qglobal.h", "qconfig.h" };
                foreach ( var filename in candidates ) {
                    if ( FindVersionNumber( filename ) ) {
                        return;
                    }
                }
            }
            catch ( Exception /*e*/ ) {}
            qtDir = null;
        }

        public bool FindVersionNumber( string hFilename ) {
            var regex = new Regex( "#define\\s*QT_VERSION\\s*0x(?<number>\\d+)", RegexOptions.Multiline );
            var file = LocatehFile( hFilename );
            if ( file == null ) {
                return false;
            }

            var content = File.ReadAllText( file );
            var match = regex.Match( content );

            if ( !match.Success ) {
                return false;
            }

            var versionString = match.Groups[ 1 ].ToString();
            var version = Convert.ToUInt32( versionString, 16 );
            qtMajor = version >> 16;
            qtMinor = ( version >> 8 ) & 0xFF;
            qtPatch = version & 0xFF;
            qt5Version = qtMajor == 5;
            return true;
        }

        public bool IsStaticBuild() {
            qtConfig = qtConfig ?? new QtConfig( qtDir );
            return qtConfig.IsStaticBuild;
        }

        public string getLibInfix() {
            qtConfig = qtConfig ?? new QtConfig( qtDir );
            return qtConfig.qtLibInfix;
        }

        public string GetSignatureFile() {
            qtConfig = qtConfig ?? new QtConfig( qtDir );
            return qtConfig.SignatureFile;
        }

        public string GetInformationString() {
            return "Qt" + qtMajor + "." + qtMinor + "." + qtPatch + "_" + vsPlatformName;
        }

        public string GetQMakeConfEntry( string entryName ) {
            qmakeConf = qmakeConf ?? new QMakeConf( this );
            return qmakeConf.Get( entryName );
        }

        /// <summary>
        /// Returns the platform name in a way Visual Studio understands.
        /// </summary>
        public string GetVSPlatformName() {
            return vsPlatformName;
        }

        public bool IsWinCEVersion() {
            return qtWinCEVersion;
        }

        /// <summary>
        /// Read platform name and whether this is a WinCE version from qmake.conf.
        /// </summary>
        private void SetupPlatformSpecificData() {
            qmakeConf = qmakeConf ?? new QMakeConf( this );
            qtWinCEVersion = false;

            string ceSDK = qmakeConf.Get( "CE_SDK" );
            string ceArch = qmakeConf.Get( "CE_ARCH" );
            if ( ceSDK != null && ceArch != null ) {
                vsPlatformName = ceSDK + " (" + ceArch + ")";
                qtWinCEVersion = true;
            }
            else if ( is64Bit() )
                vsPlatformName = "x64";
            else
                vsPlatformName = "Win32";
        }

        private string LocatehFile( string name ) {
            string[] candidates = { qtDir + "\\include\\" + name,
                                    qtDir + "\\src\\corelib\\global\\" + name,
                                    qtDir + "\\include\\QtCore\\" + name };

            foreach ( var filename in candidates ) {
                if ( !File.Exists( filename ) ) {
                    continue;
                }

                // check whether we look at the real file or just a "pointer"
                var regex = new Regex( "#include\\s+\"(.+" + name + ")\"", RegexOptions.Multiline );
                var content = File.ReadAllText( filename );
                var match = regex.Match( content );

                if ( !match.Success ) {
                    return filename;
                }

                if ( match.Groups.Count >= 2 ) {
                    var temp = Directory.GetCurrentDirectory();
                    Directory.SetCurrentDirectory( Path.GetDirectoryName( filename ) );
                    var includeFile = Path.GetFullPath( match.Groups[ 1 ].ToString() );
                    Directory.SetCurrentDirectory( temp );
                    if ( File.Exists( includeFile ) ) {
                        return includeFile;
                    }
                }
            }

            return null;
        }

        public enum MachineType : ushort {
            IMAGE_FILE_MACHINE_UNKNOWN = 0x0,
            IMAGE_FILE_MACHINE_AM33 = 0x1d3,
            IMAGE_FILE_MACHINE_AMD64 = 0x8664,
            IMAGE_FILE_MACHINE_ARM = 0x1c0,
            IMAGE_FILE_MACHINE_EBC = 0xebc,
            IMAGE_FILE_MACHINE_I386 = 0x14c,
            IMAGE_FILE_MACHINE_IA64 = 0x200,
            IMAGE_FILE_MACHINE_M32R = 0x9041,
            IMAGE_FILE_MACHINE_MIPS16 = 0x266,
            IMAGE_FILE_MACHINE_MIPSFPU = 0x366,
            IMAGE_FILE_MACHINE_MIPSFPU16 = 0x466,
            IMAGE_FILE_MACHINE_POWERPC = 0x1f0,
            IMAGE_FILE_MACHINE_POWERPCFP = 0x1f1,
            IMAGE_FILE_MACHINE_R4000 = 0x166,
            IMAGE_FILE_MACHINE_SH3 = 0x1a2,
            IMAGE_FILE_MACHINE_SH3DSP = 0x1a3,
            IMAGE_FILE_MACHINE_SH4 = 0x1a6,
            IMAGE_FILE_MACHINE_SH5 = 0x1a8,
            IMAGE_FILE_MACHINE_THUMB = 0x1c2,
            IMAGE_FILE_MACHINE_WCEMIPSV2 = 0x169,
        }

        public static MachineType GetDllMachineType( string dllPath ) {
            // 
            // See http://www.microsoft.com/whdc/system/platform/firmware/PECOFF.mspx
            // Offset to PE header is always at 0x3C.
            // The PE header starts with "PE\0\0" =  0x50 0x45 0x00 0x00,
            // followed by a 2-byte machine type field (see the document above for the enum).
            //
            if ( !File.Exists( dllPath ) ) {
                return MachineType.IMAGE_FILE_MACHINE_UNKNOWN;
            }

            var stream = new FileStream( dllPath, FileMode.Open, FileAccess.Read );
            var reader = new BinaryReader( stream );
            stream.Seek( 0x3c, SeekOrigin.Begin );
            var peOffset = reader.ReadInt32();
            stream.Seek( peOffset, SeekOrigin.Begin );
            var peHead = reader.ReadUInt32();

            if ( peHead != 0x00004550 ) { // "PE\0\0", little-endian
                throw new Exception( "Can't find PE header" );
            }

            var type = ( MachineType )reader.ReadUInt16();
            reader.Close();
            stream.Close();
            return type;
        }

        public static bool? UnmanagedDllIs64Bit( string dllPath ) {
            switch ( GetDllMachineType( dllPath ) ) {
                case MachineType.IMAGE_FILE_MACHINE_AMD64:
                case MachineType.IMAGE_FILE_MACHINE_IA64:
                    return true;
                case MachineType.IMAGE_FILE_MACHINE_I386:
                    return false;
                default:
                    return null;
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern int GetBinaryTypeA(string lpApplicationName, ref int lpBinaryType);

        public bool is64Bit() {
            //Check PE header.
            string[] candidates = {
                qtDir + @"\bin\Qt5Core.dll",
                qtDir + @"\bin\QtCore4.dll",
                qtDir + @"\bin\Qt5Core" + getLibInfix() + ".dll",
                qtDir + @"\bin\QtCore" + getLibInfix() + "4.dll" };

            foreach ( var dllPath in candidates ) {
                var value = UnmanagedDllIs64Bit( dllPath );
                if ( value != null ) {
                    return value == true ? true : false;
                }
            }
            
            //Or check qmake binary type
            var filepath = qtDir + "\\bin\\qmake.exe";
            if ( !File.Exists( filepath ) )
                throw new QtVSException( "Can't find " + filepath );

            int binaryType = 0;
            bool success = GetBinaryTypeA( filepath, ref binaryType ) != 0;
            if ( !success )
                throw new QtVSException("GetBinaryTypeA failed");

            const int SCS_32BIT_BINARY = 0;
            const int SCS_64BIT_BINARY = 6;
            if (binaryType == SCS_32BIT_BINARY)
                return false;
            else if (binaryType == SCS_64BIT_BINARY)
                return true;
            
            throw new QtVSException("GetBinaryTypeA return unknown executable format for " + filepath );
        }
    }
}
