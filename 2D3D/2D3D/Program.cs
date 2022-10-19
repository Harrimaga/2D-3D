using From2Dto3D.Controller;
using From2Dto3D.View;
using From2Dto3D.Model;

namespace From2Dto3D
{
	internal class Program
	{
		static void Main(string[] args)
		{
			MainModel model = new();
			Viewer viewer = getView(args[0], model);
			MainController mainController = new(viewer, model);
		}

		private static Viewer getView(string s, MainModel model) => s switch
		{
			"Console" => new ConsoleViewer(model),
			"WPF" => new WPFViewer(model),
			_ => new ConsoleViewer(model),
		};
	}
}