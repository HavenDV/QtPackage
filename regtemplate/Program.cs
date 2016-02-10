using System.Linq;
using System.IO;
using System.IO.Compression;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace regtemplate {
    class Program {
        static void Main( string[] args ) {
            if ( args.Count() < 2 ) {
                return;
            }

            var vsPath = args[ 1 ].Trim( '\'' );
            var packagePath = args[ 0 ].Trim( '\'' );
            var zipPath = packagePath + @"Qt5\templates\";
            var vcPath = vsPath + @"VC\";
            var qtWizardsPath = vcPath + @"VCWizards\Qt5 Wizards\";

            try {
                registerDll( packagePath + @"Qt5ProjectLib.dll" );
                registerDll( packagePath + @"Qt5ProjectEngineLib.dll" );
                
                deleteDir( vcPath + @"VCAddClass\Qt5 Classes\" );
                deleteDir( vcPath + @"vcprojects\Qt5 Projects\" );
                deleteDir( vcPath + @"vcprojectitems\Qt5 Resourses\" );
                deleteDir( vcPath + @"vcprojectitems\Qt5 UI\" );
                deleteDir( qtWizardsPath );

                unpack( zipPath + @"Qt5 Classes.dll", vcPath + @"VCAddClass\" );
                unpack( zipPath + @"Qt5 Projects.dll", vcPath + @"vcprojects\" );
                unpack( zipPath + @"Qt5 Resourses.dll", vcPath + @"vcprojectitems\" );
                unpack( zipPath + @"Qt5 UI.dll", vcPath + @"vcprojectitems\" );
                unpack( zipPath + @"wizards.dll", qtWizardsPath );

                updateVsz( vcPath + @"VCAddClass\Qt5 Classes\", qtWizardsPath );
                updateVsz( vcPath + @"vcprojects\Qt5 Projects\", qtWizardsPath );
                updateVsz( vcPath + @"vcprojectitems\Qt5 Resourses\", qtWizardsPath );
                updateVsz( vcPath + @"vcprojectitems\Qt5 UI\", qtWizardsPath );

                setAsInstalled( vcPath );
            }
            catch ( Exception exception ) {
                Console.WriteLine( exception.ToString() );
            }
            //Console.ReadKey();
        }

        static void setAsInstalled( string vcPath ) {
            var filePath = vcPath + @"vcprojects\Qt5 Projects\install_v1.3.9";
            if ( File.Exists( filePath ) ) {
                return;
            }

            File.Create( filePath );
        }

        static void registerDll( string dllPath ) {
            //var regasmPath = RuntimeEnvironment.GetRuntimeDirectory() + @"regasm.exe";
            var regasmPath = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\regasm.exe";

            var info = new ProcessStartInfo();
            info.FileName = regasmPath;
            info.Arguments = "/codebase \"" + dllPath + "\"";
            info.UseShellExecute = false;
            info.Verb = "runas";
            info.WindowStyle = ProcessWindowStyle.Hidden;
            //processInfo.RedirectStandardOutput = true;
            //processInfo.RedirectStandardError = true;

            var process = Process.Start( info );
            process.WaitForExit();
        }

        static void deleteDir( string dir ) {
            if ( Directory.Exists( dir ) ) {
                Directory.Delete( dir, true );
            }
        }

        static void unpack( string zipPath, string outPath ) {
            ZipFile.ExtractToDirectory( zipPath, outPath );
        }

        static void updateVsz( string path, string vsWizardsPath ) {
            foreach ( var filePath in Directory.GetFiles( path ) ) {
                if ( Path.GetExtension( filePath ) != ".vsz" ) {
                    continue;
                }

                var fileName = Path.GetFileNameWithoutExtension( filePath );
                var file = File.Create( filePath );
                var writer = new StreamWriter( file );
                writer.WriteLine( "VSWIZARD 7.0" );
                writer.WriteLine( "Wizard=VsWizard.VsWizardEngine.14.0" );
                writer.WriteLine( "" );
                writer.WriteLine( "Param=\"WIZARD_NAME = " + fileName + "\"" );
                writer.WriteLine( "Param=\"ABSOLUTE_PATH = " + vsWizardsPath + fileName + "\"" );
                writer.WriteLine( "Param=\"FALLBACK_LCID = 1033\"" );
                writer.Flush();
            }
        }
    }
}
