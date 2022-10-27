using From2Dto3D.Core.Controller;
using From2Dto3D.Core.Model;
using From2Dto3D.Core.View;
namespace From2Dto3D.Core
{
    public class Core
    {
        public IView Viewer { get; private set; }
        internal MainModel Model { get; set; }
        internal MainController MainController { get; set; }
        public Core(string arg, IView viewer)
        {
            string[] args = arg.Split();
            Model = new();
            Viewer = viewer;
            MainController = new(Viewer, Model);
        }
    }
}