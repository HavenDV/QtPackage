namespace Digia.Qt5ProjectLib {
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class ConfigParser {
        private IDictionary< string, string > m_entries = null;
        private string m_path = null;

        public ConfigParser( string path ) {
            try {
                m_entries = new Dictionary< string, string >();
                m_path = path;
                Init( path );
            }
            catch( Exception /*exception*/ ) {
                //System.Windows.Forms.MessageBox.Show( exception.Message );
            }
        }

        //return key value or null
        public string GetValue( string key ) {
            if ( !m_entries.ContainsKey( key ) ) {
                return null;
            }

            return m_entries[ key ];
        }

        //return key string or ""
        public string GetString( string key ) {
            var value = GetValue( key );
            return value == null ? "" : value;
        }

        //return key uint value or 0
        public uint GetUInt( string key ) {
            uint result;
            if ( uint.TryParse( GetString( key ), out result ) ) {
                return result;
            }
            return 0U;
        }

        //Return true if checkValue is part of key value.
        public bool CheckValue( string key, string checkValue ) {
            var value = GetValue( key );
            if ( value == null ) {
                return false;
            }

            var subvalues = value.Split( new char[] { ' ', '\t' } );
            foreach ( string subvalue in subvalues ) {
                if ( subvalue.Equals( checkValue, StringComparison.OrdinalIgnoreCase ) ) {
                    return true;
                } 
            }
            return false;
        }

        protected void Init( string path ) {
            if ( !File.Exists( path ) ) {
                return;
            }

            using ( var reader = new StreamReader( path ) ) {
                var line = reader.ReadLine();
                while ( line != null ) {
                    ParseLine( line );
                    line = reader.ReadLine();
                }
            }
        }

        private string RemoveComments( string line ) {
            int commentStartIndex = line.IndexOf( '#' );
            if ( commentStartIndex >= 0 ) {
                line = line.Remove( commentStartIndex );
            }
            return line;
        }

        private void ParseLine( string line ) {
            line = line.Trim();
            line = RemoveComments( line );
            int pos = line.IndexOf( '=' );
            if ( pos > 0 ) {
                var operation = "=";
                if ( line[ pos - 1 ] == '+' || line[ pos - 1 ] == '-' ) {
                    operation = line[ pos - 1 ] + "=";
                }

                var key = line.Substring( 0, pos - operation.Length + 1 ).Trim();
                var value = ExpandVariables( line.Substring( pos + 1 ).Trim() );

                if ( operation == "+=" && m_entries.ContainsKey( key ) ) {
                    m_entries[ key ] += " " + value;
                }
                else if ( operation == "-=" ) {
                    foreach ( var removeValue in value.Split( new char[] { ' ', '\t' } ) ) {
                        RemoveValue( key, removeValue );
                    }
                }
                else {
                    m_entries[ key ] = value;
                }
            }
            else if ( line.StartsWith( "include" ) ) {
                var start = line.IndexOf( '(' );
                var end = line.LastIndexOf( ')' );
                if ( start > 0 && start < end ) {
                    var includeFile = line.Substring( start + 1, end - start - 1 );
                    var temp = Environment.CurrentDirectory;
                    Environment.CurrentDirectory = Path.GetDirectoryName( m_path );
                    if ( File.Exists( includeFile ) ) {
                        var includeParser = new ConfigParser( Path.GetFullPath( includeFile ) );
                        foreach ( var data in includeParser.m_entries ) {
                            if ( m_entries.ContainsKey( data.Key ) ) {
                                m_entries[ data.Key ] += data.Value;
                            }
                            else {
                                m_entries[ data.Key ] = data.Value;
                            }
                        }
                    }
                    Environment.CurrentDirectory = temp;
                }
            }
        }

        private string ExpandVariables( string value ) {
            var pos = value.IndexOf( "$$" );
            while ( pos != -1 ) {
                int startPos = pos + 2;
                int endPos = startPos;

                if ( value[ startPos ] != '[' )  // at the moment no handling of qmake internal variables
                {
                    for ( ; endPos < value.Length; ++endPos ) {
                        if ( ( Char.IsPunctuation( value[ endPos ] ) && value[ endPos ] != '_' )
                            || Char.IsWhiteSpace( value[ endPos ] ) ) {
                            break;
                        }
                    }
                    if ( endPos > startPos ) {
                        string varName = value.Substring( startPos, endPos - startPos );
                        object varValueObj = m_entries[ varName ];
                        string varValue = "";
                        if ( varValueObj != null ) {
                            varValue = varValueObj.ToString();
                        }
                        value = value.Substring( 0, pos ) + varValue + value.Substring( endPos );
                        endPos = pos + varValue.Length;
                    }
                }

                pos = value.IndexOf( "$$", endPos );
            }
            return value;
        }

        private void RemoveValue( string key, string removeValue ) {
            if ( !m_entries.ContainsKey( key ) ) {
                return;
            }

            m_entries[ key ].Replace( removeValue, "" );
            //var value = m_entries[ key ];
            //var pos = value.IndexOf( removeValue );
            //while ( pos >= 0 ) {
            //    value = value.Remove( pos, removeValue.Length );
            //    pos = value.IndexOf( removeValue );
            //}
            //m_entries[ key ] = value;
        }

    }
}
