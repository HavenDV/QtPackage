namespace QtWizard {
    using System;
    using EnvDTE;
    using Microsoft.VisualStudio.VCProjectEngine;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.VCCodeModel;
    static class ProjectUtilities {
        /// <summary>
        /// Determine whether project is Visual C++ project
        /// </summary>
        /// <param name="project">Project for test</param>
        /// <returns></returns>
        public static bool IsVCProject( Project project ) {
            //var type = ( string )project.Properties.Item( "ProjectType" ).Value;
            var vcProjectGuid = new Guid( "{8BC9CEB8-8B4A-11D0-8D11-00A0C91BC942}" );
            var guid = new Guid( project.Kind );
            return guid == vcProjectGuid;
        }

        /// <summary>
        /// This method returned selected project in manager
        /// or active window project
        /// </summary>
        /// <param name="dte">Automation IDE Object</param>
        /// <returns>Return selected Visual C++ project</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Project GetSelectedProject( _DTE dte ) {
            if ( dte == null ) {
                throw new ArgumentNullException( "dte" );
            }

            var projects = ( Array )dte.ActiveSolutionProjects;
            foreach ( var project in projects ) {
                return ( Project )project;
            }

            return dte.ActiveWindow.Project;
        }

        /// <summary>
        /// This method returned compiler tool for Visual C++ project
        /// </summary>
        /// <param name="project">Visual C++ Project</param>
        /// <returns>Return Visual C++ compiler tool</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static VCCLCompilerTool GetCompilerTool( Project project ) {
            if ( project == null ) {
                throw new ArgumentNullException( "project" );
            }

            if ( !IsVCProject( project ) ) {
                throw new ArgumentException(
                    "Argument not valid. Need Visual C++ project", "project" );
            }

            var vcProject = ( VCProject )project.Object;
            var configuration = vcProject.ActiveConfiguration;
            var tools = ( IVCCollection )configuration.Tools;
            var tool = ( VCCLCompilerTool )tools.Item( "VCCLCompilerTool" );
            return tool;
        }

        private static void AddProjectItemsToList( ProjectItems items, List<ProjectItem> list ) {
            foreach ( ProjectItem item in items ) {
                list.Add( item );
                AddProjectItemsToList( item.ProjectItems, list );
            }
        }

        /// <summary>
        /// This method returned list of all project items
        /// without child/parent structure
        /// </summary>
        /// <param name="project">Any Project</param>
        /// <returns>Return list of all project items</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static List<ProjectItem> GetAllProjectItems( Project project ) {
            if ( project == null ) {
                throw new ArgumentNullException( "project" );
            }

            var list = new List< ProjectItem >();
            AddProjectItemsToList( project.ProjectItems, list );
            return list;
        }

        /*
        public static string NormalizePath( string path ) {
            return Path.GetFullPath( path )
                       .TrimEnd( Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar )
                       .ToLowerInvariant();
        }

        public static bool comparePath( string path1, string path2 ) {
            return NormalizePath( path1 ) == NormalizePath( path2 );
        }
        */

        /// <summary>
        /// This method returned project item by path
        /// </summary>
        /// <param name="project">Any Project</param>
        /// <param name="path">Path</param>
        /// <returns>Return project item</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ProjectItem GetProjectItemByPath( Project project, string path ) {
            if ( project == null ) {
                throw new ArgumentNullException( "project" );
            }

            if ( path == null ) {
                throw new ArgumentNullException( "path" );
            }

            var list = GetAllProjectItems( project );
            foreach ( var item in list ) {
                if ( item.FileCount > 0 &&
                     string.Equals( item.FileNames[ 0 ], path, StringComparison.OrdinalIgnoreCase ) ) {
                    return item;
                }
            }

            return null;
        }

        /// <summary>
        /// This method returned last selected project item
        /// </summary>
        /// <param name="dte">Automation IDE Object</param>
        /// <returns>Return project item</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ProjectItem GetLastSelectedItem( _DTE dte ) {
            if ( dte == null ) {
                throw new ArgumentNullException( "dte" );
            }

            if ( dte.SelectedItems == null ) {
                return null;
            }

            ProjectItem lastSelectedItem = null;
            foreach ( SelectedItem item in dte.SelectedItems ) {
                //Skip files
                if ( System.IO.Path.GetExtension( item.Name ) != "" ) {
                    continue;
                }

                lastSelectedItem = item.ProjectItem;
            }
            return lastSelectedItem;
        }

        /// <summary>
        /// This method returned last selected project items
        /// or project items of current project
        /// </summary>
        /// <param name="dte">Automation IDE Object</param>
        /// <returns>Return parent project items</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ProjectItems GetCurrentParentFilter( _DTE dte ) {
            if ( dte == null ) {
                throw new ArgumentNullException( "dte" );
            }
            
            var parent = GetLastSelectedItem( dte );
            if ( parent != null ) {
                return parent.ProjectItems;
            }

            var project = GetSelectedProject( dte );
            if ( project != null ) {
                return project.ProjectItems;
            }

            return null;
        }

        /// <summary>
        /// This method return Visual C++ Language Manager
        /// </summary>
        /// <param name="dte">Automation IDE Object</param>
        /// <returns>Return Visual C++ Language Manager</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static VCLanguageManager GetVCLanguageManager( _DTE dte ) {
            if ( dte == null ) {
                throw new ArgumentNullException( "dte" );
            }

            return ( VCLanguageManager )dte.GetObject( "VCLanguageManager" );
        }
    }
}
