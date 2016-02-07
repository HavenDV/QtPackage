namespace QtWizard {
    using System;
    using System.IO;
    using System.Windows.Forms;

    public partial class QtClassForm : Form {

        public QtClassForm( string name, string location ) {
            InitializeComponent();
            CancelButton = cancelButton;
            AcceptButton = finishButton;

            this.className = name;
            this.location = location;
            //isValid();
            classTextBox.Focus();
        }

        public string namespaceName {
            get {
                var text = classTextBox.Text;
                var index = text.LastIndexOf( "::" );
                return index >= 0 ? text.Substring( 0, index ) : "";
            }
        }

        public string className {
            get {
                var text = classTextBox.Text;
                var index = text.LastIndexOf( "::" );
                return index >= 0 ? text.Substring( index + 2 ) : text;
            }
            private set {
                classTextBox.Text = value;
            }
        }

        public string hppName {
            get {
                return hppFileTextBox.Text;
            }
            private set {
                hppFileTextBox.Text = value;
            }
        }

        public string cppName {
            get {
                return cppFileTextBox.Text;
            }
            private set {
                cppFileTextBox.Text = value;
            }
        }

        public string uiName {
            get {
                return uiFileTextBox.Text;
            }
            private set {
                uiFileTextBox.Text = value;
            }
        }

        public string location {
            get {
                return locationTextBox.Text;
            }
            private set {
                locationTextBox.Text = value;
            }
        }

        public string hppPath {
            get {
                if ( location == null || hppName == null ) {
                    return "";
                }
                return Path.Combine( location, hppName );
            }
        }

        public string cppPath {
            get {
                if ( location == null || cppName == null ) {
                    return "";
                }
                return Path.Combine( location, cppName );
            }
        }

        public string uiPath {
            get {
                if ( location == null || uiName == null ) {
                    return "";
                }
                return Path.Combine( location, uiName );
            }
        }

        public string signature {
            get {
                return signatureComboBox.Text;
            }
            private set {
                signatureComboBox.Text = value;
            }
        }

        public string baseClassName {
            get {
                return baseClassTextBox.Text;
            }
            private set {
                baseClassTextBox.Text = value;
            }
        }

        public bool insertQObject {
            get {
                return insertQObjectCheckBox.Checked;
            }
        }

        public bool includeGuard {
            get {
                return includeGuardCheckBox.Checked;
            }
        }

        public string defaultValue {
            get {
                return defaultValueComboBox.Text;
            }
            private set {
                defaultValueComboBox.Text = value;
            }
        }

        public bool isGuiClass {
            get {
                return guiClassRadioButton.Checked;
            }
        }

        public bool isInternalGui {
            get {
                return internalUiButton.Checked;
            }
        }

        public bool isInheritGui {
            get {
                return inheritUiButton.Checked;
            }
        }

        public bool isPointerGui {
            get {
                return pointerUiButton.Checked;
            }
        }

        private void UserInputForm_FormClosed( object sender, FormClosedEventArgs e ) {
            Hide();
        }

        private void cancelButton_Click( object sender, EventArgs e ) {
            Hide();
        }

        private void finishButton_Click( object sender, EventArgs e ) {
            if ( !isValid() ) {
                return;
            }

            var fileIsDeleted = true;
            fileIsDeleted = fileIsDeleted && FileUtilities.DeleteWithMessage( hppPath );
            fileIsDeleted = fileIsDeleted && FileUtilities.DeleteWithMessage( cppPath );
            if ( isGuiClass ) {
                fileIsDeleted = fileIsDeleted && FileUtilities.DeleteWithMessage( uiPath );
            }
            if ( !fileIsDeleted ) {
                //MessageBox.Show( "Please select new names for the files that you have not deleted" );
                isValid();
                return;
            } 

            DialogResult = DialogResult.OK;
            Hide();
        }

        private void updateFileNames() {
            var fileName = lowerCaseCheckBox.Checked ? className.ToLower() : className;
            hppName = fileName + ".hpp";
            cppName = fileName + ".cpp";
            uiName = fileName + ".ui";
            //isValid();
        }
 
        private void classTextBox_TextChanged( object sender, EventArgs e ) {
            updateFileNames();
        }

        private void lowerCaseCheckBox_CheckedChanged( object sender, EventArgs e ) {
            updateFileNames();
        }

        private void baseClassTextBox_TextChanged( object sender, EventArgs e ) {
            var isEmpty = string.IsNullOrWhiteSpace( baseClassName );
            signatureComboBox.Enabled = !isEmpty;
        }

        private void browseButton_Click( object sender, EventArgs e ) {
            folderBrowserDialog.SelectedPath = location;
            if ( folderBrowserDialog.ShowDialog() != DialogResult.OK ) {
                return;
            }

            location = folderBrowserDialog.SelectedPath;
        }

        private void guiClassRadioButton_CheckedChanged( object sender, EventArgs e ) {
            uiFileLabel.Enabled = isGuiClass;
            uiFileTextBox.Enabled = isGuiClass;
            uiInitTypeGroupBox.Enabled = isGuiClass;
            insertQObjectCheckBox.Enabled = !isGuiClass;
            signatureComboBox.Enabled = !isGuiClass;
            var index = isGuiClass ? 1 : 0;
            signature = ( string )signatureComboBox.Items[ index ];
            baseClassName = isGuiClass ? "QWidget" : "QObject";
            isValid();
        }

        private bool isValid() {
            return  checkClassTextBox() &
                    checkBaseClassTextBox() &
                    checkcppTextBox() &
                    checkhppTextBox() &
                    CheckUITextBox() &
                    checkLocationTextBox();
        }

        private void backButton_Click( object sender, EventArgs e ) {
            Hide();
        }

        private bool checkClassTextBox() {
            WizardFormUtilities.SetDefault( classTextBox, classToolTip );
            return WizardFormUtilities.CheckValidIdentifier( classTextBox, classToolTip ); //error
        }

        private bool checkBaseClassTextBox() {
            WizardFormUtilities.SetDefault( baseClassTextBox, baseClassToolTip );
            return WizardFormUtilities.CheckValidIdentifier( baseClassTextBox, baseClassToolTip ); //error
        }

        private bool checkhppTextBox() {
            WizardFormUtilities.SetDefault( hppFileTextBox, hppToolTip );
            WizardFormUtilities.CheckNotExistsFile( hppFileTextBox, hppToolTip, hppPath ); //warning
            return  WizardFormUtilities.CheckValidFileName( hppFileTextBox, hppToolTip ) &&
                    WizardFormUtilities.CheckNotExistsInProject( hppFileTextBox, hppToolTip, hppPath ); //errors
        }

        private bool checkcppTextBox() {
            WizardFormUtilities.SetDefault( cppFileTextBox, cppToolTip );
            WizardFormUtilities.CheckNotExistsFile( cppFileTextBox, cppToolTip, cppPath ); //warning
            return WizardFormUtilities.CheckValidFileName( cppFileTextBox, cppToolTip ) &&
                   WizardFormUtilities.CheckNotExistsInProject( cppFileTextBox, cppToolTip, cppPath ); //errors
        }

        private bool CheckUITextBox() {
            WizardFormUtilities.SetDefault( uiFileTextBox, uiToolTip );
            if ( !isGuiClass ) {
                return true;
            }

            WizardFormUtilities.CheckNotExistsFile( uiFileTextBox, uiToolTip, uiPath ); //warning
            return WizardFormUtilities.CheckNotExistsInProject( uiFileTextBox, uiToolTip, uiPath ); //error
        }

        private bool checkLocationTextBox() {
            WizardFormUtilities.SetDefault( locationTextBox, locationToolTip );
            return WizardFormUtilities.CheckValidLocation( locationTextBox, locationToolTip ); //error
        }

        private void hppFileTextBox_TextChanged( object sender, EventArgs e ) {
            isValid();
        }

        private void cppFileTextBox_TextChanged( object sender, EventArgs e ) {
            isValid();
        }

        private void uiFileTextBox_TextChanged( object sender, EventArgs e ) {
            isValid();
        }

        private void locationTextBox_TextChanged( object sender, EventArgs e ) {
            isValid();
        }

        private void signatureComboBox_TextChanged( object sender, EventArgs e ) {
            var isEmpty = string.IsNullOrWhiteSpace( signature );
            defaultValueComboBox.Enabled = !isEmpty;
        }

        private void signatureComboBox_EnabledChanged( object sender, EventArgs e ) {
            defaultValueComboBox.Enabled = signatureComboBox.Enabled;
        }
    }
}
