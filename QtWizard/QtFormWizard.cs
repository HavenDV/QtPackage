namespace QtWizard {
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TemplateWizard;
    using System.Windows.Forms;
    using EnvDTE;
    using System.IO;

    public class QtFormWizard : QtWizard {
        private QtFormForm form = null;

        public override void RunFinished() {
            form.Dispose();
        }

        public override void RunStarted( object dteObject,
                Dictionary<string, string> dictionary,
                WizardRunKind runKind, object[] customParams ) {
            dte = ( _DTE )dteObject;
            project = ProjectUtilities.GetSelectedProject( dte );
            DialogResult result = DialogResult.None;
            string inputPath;
            dictionary.TryGetValue( "$rootname$", out inputPath );
            var inputLocation = Path.GetDirectoryName( inputPath );
            var inputName = Path.GetFileName( inputPath );

            try {
                form = new QtFormForm( inputName, inputLocation );
                result = form.ShowDialog();
            }
            catch ( Exception exception ) {
                form.Dispose();
                MessageBox.Show( "Exception: " + exception.ToString() );
                throw new WizardCancelledException();
            }

            switch ( result ) {
                case DialogResult.Cancel:
                    throw new WizardCancelledException();

                case DialogResult.Retry:
                    throw new WizardBackoutException();
            }
        }

        public override bool ShouldAddProjectItem( string fileName ) {
            if ( fileName == form.GetSelectedName() ) {
                return true;
            }

            return false;
        }
    }
}