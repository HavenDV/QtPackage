namespace QtWizard {
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TemplateWizard;
    using EnvDTE;
    using System.IO;

    public class QtWizard : IWizard {
        virtual public void BeforeOpeningFile( ProjectItem item ) {
            //var vcItem = (VCProjectItem)item;
            //var vcProject = (VCProject)item.ContainingProject.Object;
            //vcProject.Files;
            //vcProject.FindFile( path );
        }

        virtual public void ProjectFinishedGenerating( Project project ) {}
        virtual public void ProjectItemFinishedGenerating( ProjectItem item ) {}

        public static _DTE dte {
            get;
            protected set;
        }

        public static Project project {
            get;
            protected set;
        }

        virtual public void RunFinished() {}

        virtual public void RunStarted( object dteObject,
            Dictionary<string, string> dictionary,
            WizardRunKind runKind, object[] customParams ) {}

        virtual public bool ShouldAddProjectItem( string fileName ) {
            return true;
        }

        public static bool ValidateFileName( string name ) {
            var manager = ProjectUtilities.GetVCLanguageManager( dte );
            return manager.ValidateFileName( name );
        }

        public static bool ValidateIdentifier( string name ) {
            //CodeCompiler.ValidateIdentifiers( class1 );
            //System.CodeDom.Compiler.CodeGenerator.IsValidLanguageIndependentIdentifier( className );
            var manager = ProjectUtilities.GetVCLanguageManager( dte );
            return manager.ValidateIdentifier( name );
        }

        public static bool CheckFile( string path ) {
            //Check exists path
            //( if true - replace original )
            if ( ProjectUtilities.GetProjectItemByPath( project, path ) != null ) {
                return false;
            }

            //Check exists in current filter
            //( if true - no error, two elements in same name )
            var fileName = Path.GetFileName( path );
            var parent = ProjectUtilities.GetCurrentParentFilter( dte );
            foreach ( ProjectItem item in parent ) {
                if ( item.Name == fileName ) {
                    return false;
                }
            }

            return true;
        }
    }
}