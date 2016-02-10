namespace QtWizard {
    using System.IO;
    using System.Windows.Forms;

    static class WizardFormUtilities {
        static public void SetDefault( TextBox textBox, ToolTip toolTip ) {
            textBox.BackColor = System.Drawing.SystemColors.Window;
            toolTip.RemoveAll();
        }

        static public void ShowMessage( TextBox textBox, ToolTip toolTip, string message ) {
            toolTip.RemoveAll();
            toolTip.Show( message, textBox, 0, 21 );
        }

        static public void ShowWarning( TextBox textBox, ToolTip toolTip, string message ) {
            textBox.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            ShowMessage( textBox, toolTip, message );
        }

        static public void ShowError( TextBox textBox, ToolTip toolTip, string message ) {
            textBox.BackColor = System.Drawing.Color.MistyRose;
            ShowMessage( textBox, toolTip, message );
        }

        public static bool CheckValidIdentifier( TextBox textBox, ToolTip toolTip ) {
            var text = textBox.Text;
            var isValid = QtWizard.ValidateIdentifier( text );
            if ( !isValid ) {
                ShowError( textBox, toolTip, "Not valid identifier" );
            }

            return isValid;
        }

        public static bool CheckValidFileName( TextBox textBox, ToolTip toolTip ) {
            var text = textBox.Text;
            var isValid = QtWizard.ValidateFileName( text );
            if ( !isValid ) {
                ShowError( textBox, toolTip, "Not valid name" );
            }

            return isValid;
        }

        public static bool CheckValidLocation( TextBox textBox, ToolTip toolTip ) {
            var text = textBox.Text;
            var isValid = !string.IsNullOrWhiteSpace( text );
            if ( !isValid ) {
                ShowError( textBox, toolTip, "Location is empty" );
            }

            return isValid;
        }

        public static bool CheckNotExistsInProject( TextBox textBox, ToolTip toolTip, string path ) {
            var isExists = !QtWizard.CheckFile( path );
            if ( isExists ) {
                ShowError( textBox, toolTip, "File already exists in project" );
            }

            return !isExists;
        }

        public static bool CheckNotExistsFile( TextBox textBox, ToolTip toolTip, string path ) {
            var isExists = File.Exists( path );
            if ( isExists ) {
                ShowWarning( textBox, toolTip, "File already exists" );
            }

            return !isExists;
        }
    }
}
