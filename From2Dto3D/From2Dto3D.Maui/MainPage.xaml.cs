using From2Dto3D;
using From2Dto3D.Core;
using From2Dto3D.Core.View;

namespace From2Dto3D.Maui
{
	public partial class MainPage : ContentPage, Core.View.IView
	{
		int count = 0;
		From2Dto3D.Core.Core core;
		public MainPage()
		{
			InitializeComponent();
			core = new("", this);
		}

		private void OnCounterClicked(object sender, EventArgs e)
		{
			count++;

			if(count == 1)
				CounterBtn.Text = $"Clicked {count} time";
			else
				CounterBtn.Text = $"Clicked {count} times";
			SourcePath.Invoke(this, new PathArg($"{count}"));
			SemanticScreenReader.Announce(CounterBtn.Text);
		}

		public event EventHandler<EventArgs> ViewChanged;
		public event EventHandler<PathArg> SourcePath;
	}
}