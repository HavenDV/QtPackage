namespace Digia.Qt5ProjectLib {
    using System.IO;
    using System.Threading;

    /// <summary>
    /// This class represent qmake.conf file.
    /// </summary>
    public class QMakeConf {
        private string qmakespecFolder = "";
        private ConfigParser parser = null;

        public QMakeConf( VersionInformation versionInfo ) {
            Init( versionInfo );
        }

        public enum InitType {
            InitQtInstallPath, InitQMakeConf
        }

        /// <param name="str">string for initialization</param>
        /// <param name="itype">determines the use of str</param>
        public QMakeConf( string str, InitType itype ) {
            switch ( itype ) {
                case InitType.InitQtInstallPath:
                    Init( new VersionInformation( str ) );
                    break;
                case InitType.InitQMakeConf:
                    Init( str );
                    break;
            }
        }

        protected void Init( VersionInformation versionInfo ) {
            string filename = versionInfo.qtDir + "\\mkspecs\\default\\qmake.conf";

            // Starting from Qt5 beta2 there is no more "\\mkspecs\\default" folder available
            // To find location of "qmake.conf" there is a need to run "qmake -query" command
            // This is what happens below.
            if ( !File.Exists( filename ) ) {
                var query = new QMakeQuery( versionInfo );

                query.ReadyEvent += new QMakeQuery.EventHandler( this.CloseEventHandler );
                var thread = new Thread( new ThreadStart( query.RunQMakeQuery ) );
                thread.Start();
                thread.Join();

                if ( query.ErrorValue != 0 ) {
                    throw new QtVSException( "qmake.conf not found" );
                }

                if ( qmakespecFolder.Length > 0 ) {
                    filename = versionInfo.qtDir + "\\mkspecs\\" + qmakespecFolder + "\\qmake.conf";
                }
            }

            Init( filename );
        }

        // Qmake thread calls this handler to set qmake.conf folder
        private void CloseEventHandler( string foldername ) {
            qmakespecFolder = foldername;
        }

        protected void Init( string filename ) {
            parser = new ConfigParser( filename );
        }

        public string Get( string key ) {
            return parser.GetValue( key );
        }
    }
}
