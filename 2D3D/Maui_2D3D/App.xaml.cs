using From2Dto3D.View;
using From2Dto3D;

namespace Maui_2D3D
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            MainPage = new AppShell();
            
        }

        public event EventHandler<EventArgs> ViewChanged;
        public event EventHandler<PathArg> SourcePath;
    }
}