namespace QtWizard {
    using Properties;
    using System;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public enum FormType {
        None,
        DialogWithBottomButton,
        DialogWithRightButton,
        MainWindow,
        Widget
    }

    public partial class QtFormForm : Form {

        public QtFormForm( string name, string location, bool isEnabled = true ) {
            InitializeComponent();

            CancelButton = cancelButton;
            AcceptButton = finishButton;

            this.name = name;
            this.location = location;

            nameTextBox.Enabled = isEnabled;
            locationTextBox.Enabled = isEnabled;
        }

        public string name {
            get {
                return nameTextBox.Text;
            }
            private set {
                nameTextBox.Text = value;
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

        public string path {
            get {
                if ( location == null || name == null ) {
                    return "";
                }
                return Path.Combine( location, name );
            }
        }

        public FormType GetSelectedType() {
            return  dialogBottomRadioButton.Checked ? 
                        FormType.DialogWithBottomButton :
                    dialogRightRadioButton.Checked ? 
                        FormType.DialogWithRightButton :
                    mainWindowRadioButton.Checked ? 
                        FormType.MainWindow :
                    widgetRadioButton.Checked ? 
                        FormType.Widget : 
                        FormType.None;
        }

        public string GetSelectedResourceName() {
            switch( GetSelectedType() ) {
                case FormType.DialogWithBottomButton:
                    return "dialogButtonsBottom";
                case FormType.DialogWithRightButton:
                    return "dialogButtonsRight";
                case FormType.MainWindow:
                    return "mainWindow";
                case FormType.Widget:
                    return "widget";
            }
            return null;
        }

        public string GetSelectedName() {
            return GetSelectedResourceName() + ".ui";
        }

        private void UpdatePreview() {
            previewPictureBox.Image = ( Image )Resources.ResourceManager.GetObject( GetSelectedResourceName() ) ;
        }

        private bool CheckNameTextBox() {
            WizardFormUtilities.SetDefault( nameTextBox, nameToolTip );
            WizardFormUtilities.CheckNotExistsFile( nameTextBox, nameToolTip, path ); //warning
            return WizardFormUtilities.CheckNotExistsInProject( nameTextBox, nameToolTip, path ); //error
        }

        private bool CheckLocationTextBox() {
            WizardFormUtilities.SetDefault( locationTextBox, locationToolTip );
            return WizardFormUtilities.CheckValidLocation( locationTextBox, locationToolTip ); //error
        }

        private bool IsValid() {
            return  CheckNameTextBox() &&
                    CheckLocationTextBox();
        }

        private void dialogBottomRadioButton_CheckedChanged( object sender, EventArgs e ) {
            UpdatePreview();
        }

        private void dialogRightRadioButton_CheckedChanged( object sender, EventArgs e ) {
            UpdatePreview();
        }

        private void mainWindowRadioButton_CheckedChanged( object sender, EventArgs e ) {
            UpdatePreview();
        }

        private void widgetRadioButton_CheckedChanged( object sender, EventArgs e ) {
            UpdatePreview();
        }

        private void backButton_Click( object sender, EventArgs e ) {
            Hide();
        }

        private void finishButton_Click( object sender, EventArgs e ) {
            if ( !IsValid() ) {
                return;
            }

            var fileIsDeleted = FileUtilities.DeleteWithMessage( path );
            if ( !fileIsDeleted ) {
                IsValid();
                return;
            }

            DialogResult = DialogResult.OK;
            Hide();
        }

        private void cancelButton_Click( object sender, EventArgs e ) {
            Hide();
        }

        private void nameTextBox_TextChanged( object sender, EventArgs e ) {
            IsValid();
        }

        private void locationTextBox_TextChanged( object sender, EventArgs e ) {
            IsValid();
        }

        private void browseButton_Click( object sender, EventArgs e ) {
            folderBrowserDialog.SelectedPath = location;
            if ( folderBrowserDialog.ShowDialog() != DialogResult.OK ) {
                return;
            }
            location = folderBrowserDialog.SelectedPath;
        }
    }
}
