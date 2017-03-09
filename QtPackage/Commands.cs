//------------------------------------------------------------------------------
// <copyright file="Commands.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

//using Qt5VSAddin;
using Digia.Qt5ProjectLib;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace QtPackage
{
    /// <summary>
    /// Command handler
    /// </summary>
    internal sealed class Commands {
        /// <summary>
        /// Command ID.
        /// </summary>
        public const int loadDesignerCommandId = 0x0100;
        public const int loadLinguistCommandId = 0x0101;
        public const int importProFileCommandId = 0x0102;
        public const int importPriFileCommandId = 0x0103;
        public const int exportPriFileCommandId = 0x0104;
        public const int exportProFileCommandId = 0x0105;
        public const int createNewTranslationFileCommandId = 0x0106;
        public const int lupdateProjectCommandId = 0x0107;
        public const int lreleaseProjectCommandId = 0x0108;
        public const int lupdateSolutionCommandId = 0x0109;
        public const int lreleaseSolutionCommandId = 0x010A;
        public const int convertToQtCommandId = 0x010B;
        public const int convertToQMakeCommandId = 0x010C;
        public const int projectQtSettingsCommandId = 0x010D;
        public const int changeProjectQtVersionCommandId = 0x010E;
        public const int vsQtOptionsCommandId = 0x0110;
        public const int changeSolutionQtVersionCommandId = 0x0111;
        public const int lupdateCommandId = 0x0112;
        public const int lreleaseCommandId = 0x0113;
        public const int helpQtCommandId = 0x0114;
        public const int reinstallCommandId = 0x0115;

        /// <summary>
        /// Command menu group (command set GUID).
        /// </summary>
        public static readonly Guid MenuGroup = new Guid("36bf54a4-75f5-44e6-bed1-5b264018a433");

        /// <summary>
        /// VS Package that provides this command, not null.
        /// </summary>
        private readonly Package package;

        private FormChangeQtVersion formChangeQtVersion = null;
        private FormVSQtSettings formQtVersions = null;
        private FormProjectQtSettings formProjectQtSettings = null;
        private OleMenuCommandService commandService = null;

        private Dictionary<string, MenuCommand> menuCommands;



        public static Commands Instance {
            get;
            private set;
        }

        /// <summary>
        /// Gets the service provider from the owner package.
        /// </summary>
        private IServiceProvider ServiceProvider => package;

        /// <summary>
        /// Initializes a new instance of the <see cref="Command1"/> class.
        /// Adds our command handlers for menu (commands must exist in the command table file)
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        private Commands( Package package ) {
            if ( package == null ) {
                throw new ArgumentNullException( "package" );
            }
            this.package = package;

            menuCommands = new Dictionary<string, MenuCommand>();
            menuCommands[ "loadDesigner" ] = addCommand( loadDesignerCommandId, loadDesigner );
            menuCommands[ "loadLinguist" ] = addCommand( loadLinguistCommandId, loadLinguist );
            menuCommands[ "importProFile" ] = addCommand( importProFileCommandId, importProFile );
            menuCommands[ "importPriFile" ] = addCommand( importPriFileCommandId, importPriFile );
            menuCommands[ "exportPriFile" ] = addCommand( exportPriFileCommandId, exportPriFile );
            menuCommands[ "exportProFile" ] = addCommand( exportProFileCommandId, exportProFile );
            menuCommands[ "createNewTranslationFile" ] = addCommand( createNewTranslationFileCommandId, createNewTranslationFile );
            menuCommands[ "lupdateProject" ] = addCommand( lupdateProjectCommandId, lupdateProject );
            menuCommands[ "lreleaseProject" ] = addCommand( lreleaseProjectCommandId, lreleaseProject );
            menuCommands[ "lupdateSolution" ] = addCommand( lupdateSolutionCommandId, lupdateSolution );
            menuCommands[ "lreleaseSolution" ] = addCommand( lreleaseSolutionCommandId, lreleaseSolution );
            menuCommands[ "convertToQt" ] = addCommand( convertToQtCommandId, convertToQt );
            menuCommands[ "convertToQMake" ] = addCommand( convertToQMakeCommandId, convertToQMake );
            menuCommands[ "projectQtSettings" ] = addCommand( projectQtSettingsCommandId, projectQtSettings );
            menuCommands[ "changeProjectQtVersion" ] = addCommand( changeProjectQtVersionCommandId, changeProjectQtVersion );
            menuCommands[ "vsQtOptions" ] = addCommand( vsQtOptionsCommandId, vsQtOptions );
            menuCommands[ "changeSolutionQtVersion" ] = addCommand( changeSolutionQtVersionCommandId, changeSolutionQtVersion );
            menuCommands[ "lupdate" ] = addCommand( lupdateCommandId, lupdate );
            menuCommands[ "lrelease" ] = addCommand( lreleaseCommandId, lrelease );
            menuCommands[ "helpQt" ] = addCommand( helpQtCommandId, helpQt );
            menuCommands[ "reinstall" ] = addCommand( reinstallCommandId, reinstallTemlates );
        }


        /// <summary>
        /// Initializes the singleton instance of the command.
        /// </summary>
        /// <param name="package">Owner package, not null.</param>
        public static void Initialize( Package package ) {
            Instance = new Commands( package );
        }

        private void reinstallTemlates( object sender, EventArgs e ) {
            VSPackage.InstallTemplates();
        }

        private void loadDesigner( object sender, EventArgs e ) {
            VSPackage.extLoader.loadDesigner( null );
        }

        private void loadLinguist( object sender, EventArgs e ) {
            ExtLoader.loadLinguist( null );
        }

        private void importProFile( object sender, EventArgs e ) {
            ExtLoader.ImportProFile();
            menuCommands[ "importProFile" ].Enabled = false;
        }
        private void importPriFile( object sender, EventArgs e ) {
            Project pro = HelperFunctions.GetSelectedQtProject( VSPackage.dte );
            ExtLoader.ImportPriFile( pro );
        }
        private void exportPriFile( object sender, EventArgs e ) {
            ExtLoader.ExportPriFile();
        }
        private void exportProFile( object sender, EventArgs e ) {
            ExtLoader.ExportProFile();
        }
        private void createNewTranslationFile( object sender, EventArgs e ) {
            Project pro = HelperFunctions.GetSelectedQtProject( VSPackage.dte );
            Translation.CreateNewTranslationFile( pro );
        }
        private void lupdateProject( object sender, EventArgs e ) {
            Project pro = HelperFunctions.GetSelectedQtProject( VSPackage.dte );
            Translation.RunlUpdate( pro );
        }
        private void lreleaseProject( object sender, EventArgs e ) {
            Project pro = HelperFunctions.GetSelectedQtProject( VSPackage.dte );
            Translation.RunlRelease( pro );
        }
        private void lupdateSolution( object sender, EventArgs e ) {
            Translation.RunlUpdate( VSPackage.dte.Solution );
        }
        private void lreleaseSolution( object sender, EventArgs e ) {
            Translation.RunlRelease( VSPackage.dte.Solution );
        }
        private void convertToQt( object sender, EventArgs e ) {
            if ( MessageBox.Show( SR.GetString( "ConvertConfirmation" ),
                                SR.GetString( "ConvertTitle" ),
                                MessageBoxButtons.YesNo ) == DialogResult.Yes ) {
                Project pro = HelperFunctions.GetSelectedProject( VSPackage.dte );
                HelperFunctions.ToggleProjectKind( pro );
            }
        }

        private void convertToQMake( object sender, EventArgs e ) {
            convertToQt( sender, e );
        }

        private void projectQtSettings( object sender, EventArgs e ) {
            var project = HelperFunctions.GetSelectedQtProject( VSPackage.dte );
            if ( project == null ) {
                MessageBox.Show( SR.GetString( "NoProjectOpened" ) );
                return;
            }

            formProjectQtSettings = formProjectQtSettings ?? new FormProjectQtSettings();
            formProjectQtSettings.SetProject( project );
            formProjectQtSettings.StartPosition = FormStartPosition.CenterParent;
            var wrapper = new MainWinWrapper( VSPackage.dte );
            formProjectQtSettings.ShowDialog( wrapper );
        }

        private void changeProjectQtVersion( object sender, EventArgs e ) {
            var project = HelperFunctions.GetSelectedProject( VSPackage.dte );
            if ( project != null && HelperFunctions.IsQMakeProject( project ) ) {
                if ( formChangeQtVersion == null )
                    formChangeQtVersion = new FormChangeQtVersion();
                formChangeQtVersion.UpdateContent( ChangeFor.Project );
                var ww = new MainWinWrapper( VSPackage.dte );
                if ( formChangeQtVersion.ShowDialog( ww ) == DialogResult.OK ) {
                    string qtVersion = formChangeQtVersion.GetSelectedQtVersion();
                    QtVersionManager vm = QtVersionManager.The();
                    string qtPath = vm.GetInstallPath( qtVersion );
                    HelperFunctions.SetDebuggingEnvironment( project, "PATH=" + qtPath + "\\bin;$(PATH)", true );
                }
            }
        }
        private void vsQtOptions( object sender, EventArgs e ) {
            if ( formQtVersions == null ) {
                formQtVersions = new FormVSQtSettings();
                formQtVersions.LoadSettings();
            }
            formQtVersions.StartPosition = FormStartPosition.CenterParent;
            var ww = new MainWinWrapper( VSPackage.dte );
            if ( formQtVersions.ShowDialog( ww ) == DialogResult.OK )
                formQtVersions.SaveSettings();
        }
        private void changeSolutionQtVersion( object sender, EventArgs e ) {
            var manager = QtVersionManager.The();
            if ( formChangeQtVersion == null ) {
                formChangeQtVersion = new FormChangeQtVersion();
            }
            formChangeQtVersion.UpdateContent( ChangeFor.Solution );
            if ( formChangeQtVersion.ShowDialog() == DialogResult.OK ) {
                var newQtVersion = formChangeQtVersion.GetSelectedQtVersion();
                if ( newQtVersion != null ) {
                    string currentPlatform = null;
                    try {
                        //SolutionConfiguration config = VSPackage.dte.Solution.SolutionBuild.ActiveConfiguration;
                        //SolutionConfiguration2 config2 = config as SolutionConfiguration2;
                        //currentPlatform = config2.PlatformName;
                        Project prj = VSPackage.dte.Solution.Projects.Item( 1 );
                        Configuration config = prj.ConfigurationManager.ActiveConfiguration;
                        currentPlatform = config.PlatformName;
                    }
                    catch {
                    }
                    if ( string.IsNullOrEmpty( currentPlatform ) ) {
                        return;
                    }


                    foreach ( var project in HelperFunctions.ProjectsInSolution( VSPackage.dte ) ) {
                        if ( HelperFunctions.IsQtProject( project ) ) {
                            string OldQtVersion = manager.GetProjectQtVersion( project, currentPlatform );
                            if ( OldQtVersion == null )
                                OldQtVersion = manager.GetDefaultVersion();

                            var qtProject = QtProject.Create( project );
                            var newProjectCreated = false;
                            qtProject.ChangeQtVersion( OldQtVersion, newQtVersion, ref newProjectCreated );
                        }
                    }
                    manager.SaveSolutionQtVersion( VSPackage.dte.Solution, newQtVersion );
                }
            }
        }
        private void lupdate( object sender, EventArgs e ) {
            Translation.RunlUpdate( HelperFunctions.GetSelectedFiles( VSPackage.dte ),
                                HelperFunctions.GetSelectedQtProject( VSPackage.dte ) );
        }
        private void lrelease( object sender, EventArgs e ) {
            Translation.RunlRelease( HelperFunctions.GetSelectedFiles( VSPackage.dte ) );
        }

        private void helpQt( object sender, EventArgs e ) {
            if ( VSPackage.dte.ActiveDocument == null ) {
                return;
            }

            var objSel = VSPackage.dte.ActiveDocument.Selection as TextSelection;
            if ( objSel == null ) {
                return;
            }

            objSel.WordLeft( true );
            var first = objSel.Text;
            objSel.WordRight( true );
            var text = first + objSel.Text;

            System.Diagnostics.Process.Start( "http://doc.qt.io/qt-5/search-results.html?q=" + text );

            //VSPackage.help2.DisplayTopicFromF1Keyword("Owner");
            //MessageBox.Show(VSPackage.help2.Collection);
            //MessageBox.Show(VSPackage.help.FilterQuery);
            //VSPackage.help2.SetCollection("http://doc.qt.io/qt-5/search-results.html?q=", "");
            //VSPackage.help2.DisplayTopicFromF1Keyword("Owner");
            //VSPackage.help2.HowDoI();
            //VSPackage.dte.ExecuteCommand("Help.F1Help", "override");
        }

        private MenuCommand addCommand( int commandID, EventHandler eventHandler ) {
            if ( commandService == null )
            {
                commandService = ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            }
            if (commandService == null)
            {
                throw new MissingMemberException("IMenuCommandService not found in ServiceProvider");
            }

            CommandID menuCommandID = new CommandID( MenuGroup, commandID );
            OleMenuCommand menuItem = new OleMenuCommand( eventHandler, menuCommandID );
            commandService.AddCommand( menuItem );
            menuItem.BeforeQueryStatus += OnBeforeQueryStatus;

            return menuItem;
        }

        private void OnBeforeQueryStatus( object sender, EventArgs e ) {
            //HelperFunctions.solutionHaveQtProjects(VSPackage.dte);

            Project prj = HelperFunctions.GetSelectedProject( VSPackage.dte );
            bool isNoQtProject = prj != null &&
                !HelperFunctions.IsQMakeProject( prj ) &&
                !HelperFunctions.IsQtProject( prj );

            var command = sender as OleMenuCommand;
            if ( command == null )
                return;
            int commandID = command.CommandID.ID;
            command.Supported = true;
            command.Enabled = true;
            command.Visible = true;
            try {
                if ( ( commandID == loadDesignerCommandId ) ||
                    ( commandID == loadLinguistCommandId ) ||
                    ( commandID == vsQtOptionsCommandId ) ||
                    ( commandID == importProFileCommandId ) ) {
                }
                else if ( ( commandID == importPriFileCommandId ) ||
                        ( commandID == exportPriFileCommandId ) ||
                        ( commandID == exportProFileCommandId ) ||
                        ( commandID == createNewTranslationFileCommandId ) ||
                        ( commandID == lupdateProjectCommandId ) ||
                        ( commandID == lreleaseProjectCommandId ) ) {
                    //Project prj = HelperFunctions.GetSelectedProject(VSPackage.dte);
                    if ( isNoQtProject ) {
                        command.Visible = false;
                    }
                    else if ( !HelperFunctions.IsQtProject( prj ) ) {
                        command.Enabled = false;
                    }
                }
                else if ( commandID == projectQtSettingsCommandId ||
                        commandID == convertToQMakeCommandId ) {
                    //Project prj = HelperFunctions.GetSelectedProject(VSPackage.dte);
                    if ( isNoQtProject ) {
                        command.Visible = false;
                    }
                    if ( prj == null ) {
                        command.Enabled = false;
                    }
                    else if ( HelperFunctions.IsQMakeProject( prj ) ) {
                        command.Visible = false;
                    }
                }
                else if ( commandID == changeProjectQtVersionCommandId ||
                        commandID == convertToQtCommandId ) {
                    //Project prj = HelperFunctions.GetSelectedProject(VSPackage.dte);
                    if ( prj == null || isNoQtProject || HelperFunctions.IsQtProject( prj ) ) {
                        command.Visible = false;
                    }
                }
                else if ( ( commandID == changeSolutionQtVersionCommandId ) ||
                        ( commandID == lupdateSolutionCommandId ) ||
                        ( commandID == lreleaseSolutionCommandId ) ) {
                    if ( !VSPackage.dte.Solution.IsOpen ) {
                        command.Enabled = false;
                    }
                }
                else if ( commandID == lupdateCommandId ||
                        commandID == lreleaseCommandId ) {
                    //Project prj = HelperFunctions.GetSelectedProject(VSPackage.dte);
                    if ( prj == null || !HelperFunctions.IsQtProject( prj ) ||
                        VSPackage.dte.SelectedItems.Count == 0 ) {
                        command.Visible = false;
                    }
                    else {
                        foreach ( SelectedItem si in VSPackage.dte.SelectedItems ) {
                            if ( !si.Name.ToLower().EndsWith( ".ts" ) ) {
                                command.Visible = false;
                                break;
                            }
                        }
                    }
                }
            }
            catch ( System.Exception ex ) {
                MessageBox.Show( ex.Message + "\r\n\r\nStacktrace:\r\n" + ex.StackTrace );
            }
        }


    }
}
