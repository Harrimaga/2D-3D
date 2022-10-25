using From2Dto3D.Model;
using From2Dto3D;
using Wpf_2D3D;
using System.Windows;

namespace From2Dto3D.View
{
    class WPFViewer : Viewer
	{
		public WPFViewer(MainModel mainModel) : base(mainModel)
		{
			Wpf_2D3D.MainWindow WPFWindow = new Wpf_2D3D.MainWindow();
			WPFWindow.Show();
		}

		//internal override event EventHandler<EventArgs>? ViewChanged;
	}
}
