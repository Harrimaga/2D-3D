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

            //FormsViewer view = (FormsViewer)program.Viewer;
            ApplicationConfiguration.Initialize();
            Form1 f = new();
            Core program = new("", f);
            Console.WriteLine("Hello");
            Application.Run(f);

        }
    }
}