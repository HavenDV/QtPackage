namespace QtWizard {
    using System.IO;
    using System.Windows.Forms;

    static class FileUtilities {
        /// <summary>
        /// If file is exists run message box
        /// and if yes clicked delete this file. 
        /// Return true if file deleted or not exists
        /// </summary>
        /// <param name="path">Path to file</param>
        /// <returns>True if file deleted or not exists</returns>
        static public bool DeleteWithMessage( string path ) {
            if ( !File.Exists( path ) ) {
                return true;
            }

            if ( MessageBox.Show(
                 "File \"" + path + "\" already exists. Delete him?",
                 "File already exists",
                 MessageBoxButtons.YesNo,
                 MessageBoxIcon.Warning ) != DialogResult.Yes ) {
                return false;
            }

            File.Delete( path );
            return true;
        }
    }
}
