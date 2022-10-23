using From2Dto3D.Controller;
using From2Dto3D.View;
using From2Dto3D.Model;

namespace From2Dto3D
{
	public class Core
	{
		public Viewer Viewer { get; private set; }
		internal MainModel Model { get; set; }
		internal MainController MainController { get; set; }
		public Core(string arg)
		{
			string[] args	= arg.Split();
			Model			= new();
			Viewer			= getView(args[0], Model);
			MainController	= new(Viewer, Model);
		}

		private static Viewer getView(string s, MainModel model) => s switch
		{
			"Console"	=> new ConsoleViewer(model),
			"WPF"		=> new WPFViewer    (model),
			"Forms"		=> new FormsViewer  (model),
			_			=> new ConsoleViewer(model),
		};
	}
}