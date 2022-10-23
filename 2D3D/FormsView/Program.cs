using System.DirectoryServices.ActiveDirectory;
using System.Windows.Forms;
using From2Dto3D;
using From2Dto3D.View;

namespace FormsView
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Core program     = new("Forms");
            FormsViewer view = (FormsViewer)program.Viewer;
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1(view));
        }
    }
}