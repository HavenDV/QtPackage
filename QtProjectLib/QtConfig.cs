namespace Digia.Qt5ProjectLib {
    /// <summary>
    /// This class represent qconfig.pri file.
    /// </summary>
    class QtConfig {
        private ConfigParser parser = null;

        public QtConfig( string qtDir ) {
            parser = new ConfigParser( qtDir + @"\mkspecs\qconfig.pri" );
        }

        public bool IsStaticBuild {
            get {
                return parser.CheckValue( "CONFIG", "static" );
            }
        }

        public string SignatureFile {
            get {
                return parser.GetValue( "DEFAULT_SIGNATURE" );
            }
        }

        public uint qtMajor {
            get {
                return parser.GetUInt( "QT_MAJOR_VERSION" );
            }
        }

        public uint qtMinor {
            get {
                return parser.GetUInt( "QT_MINOR_VERSION" );
            }
        }

        public uint qtPatch {
            get {
                return parser.GetUInt( "QT_PATCH_VERSION" );
            }
        } 

        public string qtVersion {
            get {
                return parser.GetValue( "QT_VERSION" );
            }
        }

        public string qtLibInfix {
            get {
                return parser.GetString( "QT_LIBINFIX" );
            }
        }

        public string qtEdition {
            get {
                return parser.GetValue( "QT_EDITION" );
            }
        }

        public string qtLiCheck {
            get {
                return parser.GetValue( "QT_LICHECK" );
            }
        }

        public string qtReleaseDate {
            get {
                return parser.GetValue( "QT_RELEASE_DATE" );
            }
        }

        public string qtArch {
            get {
                return parser.GetValue( "QT_ARCH" );
            }
        }
    }
}
