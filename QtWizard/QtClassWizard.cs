namespace QtWizard {
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TemplateWizard;
    using System.Windows.Forms;
    using EnvDTE;
    using System.IO;
    using Microsoft.VisualStudio.VCProjectEngine;

    public class QtClassWizard : QtWizard {
        private QtClassForm form;
        private const string tempExtension = ".temp";

        public override void ProjectItemFinishedGenerating( ProjectItem item ) {
            var path = item.FileNames[ 0 ];
            item.Remove();
            var name = Path.GetFileName( path ).Replace( tempExtension, "" );
            var location = form.location;
            var outPath = Path.Combine( location, name );
            Directory.CreateDirectory( location );
            File.Move( path, outPath );

            //CLInlcude "FIX"
            var parent = ProjectUtilities.GetCurrentParentFilter( dte );
            try { parent.AddFromFile( outPath ); } catch {}
            
            //Don't open .ui file
            if ( Path.GetExtension( name ) == ".ui" ) {
                return;
            }

            var outItem = ProjectUtilities.GetProjectItemByPath( project, outPath );
            outItem.Open().Activate();
        }

        public override void RunFinished() {
            form.Dispose();
        }

        public override void RunStarted( object dteObject,
            Dictionary<string, string> dictionary,
            WizardRunKind runKind, object[] customParams ) {
            try {
                dte = ( _DTE )dteObject;
                project = ProjectUtilities.GetSelectedProject( dte );

                string inputName, inputLocation;
                dictionary.TryGetValue( "$safeitemname$", out inputName );
                dictionary.TryGetValue( "$rootname$", out inputLocation );
                inputLocation = Path.GetDirectoryName( inputLocation );

                form = new QtClassForm( inputName, inputLocation );

                //string dataString = "";
                //foreach ( var data in dictionary ) {
                //    dataString += data.Key + ": " + data.Value + Environment.NewLine;
                //}
                //MessageBox.Show( dataString );

                var result = form.ShowDialog();

                switch ( result ) {
                    case DialogResult.Cancel:
                        throw new WizardCancelledException();

                    case DialogResult.Retry:
                        throw new WizardBackoutException();
                }


                var className = form.className;
                var hppName = form.hppName;
                var cppName = form.cppName;
                var uiName = form.uiName;
                var baseClass = form.baseClassName;
                var namespaceName = form.namespaceName;

                var isNamespaced = !string.IsNullOrWhiteSpace( namespaceName );
                var namespaceBegin = "";
                var namespaceEnd = "";
                if ( isNamespaced ) {
                    var names = namespaceName.Split( new string[] { "::" },
                                                     StringSplitOptions.None );
                    foreach ( var name in names ) {
                        namespaceBegin += Environment.NewLine + "namespace " + name + " {";
                        namespaceEnd += Environment.NewLine + "}";
                    }
                }

                var isQObject = !string.IsNullOrWhiteSpace( baseClass );
                var qObject = isQObject && form.insertQObject ? "Q_OBJECT" : "";
                var baseClassInclude = isQObject ? "#include <" + baseClass + ">" : "";
                var baseClassInherit = isQObject ? " : public " + baseClass : "";

                var isSignatured = isQObject && !string.IsNullOrWhiteSpace( form.signature );
                var defaultValueExists = !string.IsNullOrWhiteSpace( form.defaultValue );
                var defaultValue = defaultValueExists ? " = " + form.defaultValue : "";
                var signature = isSignatured ? form.signature : "";
                var signatureDecl = isSignatured ? signature + defaultValue : "";
                var signatureImpl = isQObject ? " : " + baseClass + ( isSignatured ? "(parent)" : "(this)" ) : "";

                dictionary[ "$CLASS$" ] = className;
                dictionary[ "$HPP_FILENAME$" ] = hppName + tempExtension;
                dictionary[ "$HPP_FILENAME_CPP$" ] = hppName;
                dictionary[ "$CPP_FILENAME$" ] = cppName + tempExtension;
                dictionary[ "$UI_FILENAME$" ] = uiName + tempExtension;
                dictionary[ "$NAMESPACE_BEGIN$" ] = namespaceBegin;
                dictionary[ "$NAMESPACE_END$" ] = namespaceEnd;
                dictionary[ "$BASE_CLASS$" ] = baseClass;
                dictionary[ "$BASE_CLASS_INCLUDE$" ] = baseClassInclude;
                dictionary[ "$BASE_CLASS_INHERIT$" ] = baseClassInherit;
                dictionary[ "$SIGNATURE$" ] = signature;
                dictionary[ "$SIGNATURE_DECL$" ] = signatureDecl;
                dictionary[ "$SIGNATURE_IMPL$" ] = signatureImpl;
                dictionary[ "$Q_OBJECT$" ] = qObject;

                var pchInclude = IsUsePrecompiledHeader() ?
                    "#include <" + GetPrecompiledHeaderName() + ">"
                    + Environment.NewLine : "";
                dictionary[ "$PCH_INCLUDE$" ] = pchInclude;

                var isGuiClass = form.isGuiClass;
                var isInternalGui = isGuiClass && form.isInternalGui;
                var isInheritGui = isGuiClass && form.isInheritGui;
                var isPointerGui = isGuiClass && form.isPointerGui;
                var includeGui = Environment.NewLine + "#include \"ui_" + className.ToLower() + ".h\"";
                var uiInclude = isPointerGui ? Environment.NewLine + "namespace Ui {class " + className + ";}" : 
                                isGuiClass ? includeGui : "";
                var uiIncludeCpp = isPointerGui ? includeGui : "";
                var uiInherit = isInheritGui ? ", public Ui::" + className  : "";
                var uiDecl =    isInternalGui ? "Ui::" + className + " ui;" : 
                                isPointerGui ? "Ui::" + className + " *ui;" : "";
                var uiInit =    isInternalGui ? "ui.setupUi(this);" :
                                isInheritGui ? "setupUi(this);" :
                                isPointerGui ? "ui = new Ui::" + className + "();" +
                                Environment.NewLine + "\tui->setupUi(this); " : "";
                var uiDelete = isPointerGui ? "delete ui;" : "";
                dictionary[ "$UI_INCLUDE$" ] = uiInclude;
                dictionary[ "$UI_INCLUDE_CPP$" ] = uiIncludeCpp;
                dictionary[ "$UI_INHERIT$" ] = uiInherit;
                dictionary[ "$UI_DECL$" ] = uiDecl;
                dictionary[ "$UI_INIT$" ] = uiInit;
                dictionary[ "$UI_DELETE$" ] = uiDelete;

                var isIncludeGuard = form.includeGuard;
                var includeGuardDefine = className.ToUpper() + "_HPP";
                var includeGuardBegin = isIncludeGuard ?
                    Environment.NewLine + "#ifndef " + includeGuardDefine + 
                    Environment.NewLine + "#define " + includeGuardDefine : "";
                var includeGuardEnd = isIncludeGuard ? 
                    Environment.NewLine + "#endif // " + includeGuardDefine : "";
                dictionary[ "$INCLUDE_GUARD_BEGIN$" ] = includeGuardBegin;
                dictionary[ "$INCLUDE_GUARD_END$" ] = includeGuardEnd;

                var centralWidget =
                    baseClass == "QMainWindow" ?
                        Environment.NewLine + "  <widget class=\"QMenuBar\" name=\"menuBar\" />" +
                        Environment.NewLine + "  <widget class=\"QToolBar\" name=\"mainToolBar\" />" +
                        Environment.NewLine + "  <widget class=\"QWidget\" name=\"centralWidget\" />" +
                        Environment.NewLine + "  <widget class=\"QStatusBar\" name=\"statusBar\" />" :
                    baseClass == "QDockWidget" ?
                        Environment.NewLine + "  <widget class=\"QWidget\" name=\"widget\" />" : "";
                dictionary[ "$CENTRAL_WIDGET$" ] = centralWidget;
                
                //dictionary[ "$rootname$" ];
                //dictionary[ "$destinationdirectory$" ];
            }
            catch ( WizardBackoutException exception ) {
                throw exception;
            }
            catch ( WizardCancelledException exception ) {
                throw exception;
            }
            catch ( Exception exception ) {
                MessageBox.Show( "Exception: " + exception.ToString() );
                throw new WizardCancelledException();
            }
            finally {
                form.Dispose();
            }
        }

        public override bool ShouldAddProjectItem( string fileName ) {
            if ( Path.GetExtension( fileName ) == ".ui" ) {
                return form.isGuiClass;
            }

            return true;
        }

        public static bool IsUsePrecompiledHeader() {
            var tool = ProjectUtilities.GetCompilerTool( project );
            var option = tool?.UsePrecompiledHeader;
            return option != null ? option != pchOption.pchNone : false;
        }

        public static string GetPrecompiledHeaderName() {
            var tool = ProjectUtilities.GetCompilerTool( project );
            return tool?.PrecompiledHeaderThrough;
        }
    }
}