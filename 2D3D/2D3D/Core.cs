using From2Dto3D.Controller;
using From2Dto3D.View;
using From2Dto3D.Model;

namespace From2Dto3D
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