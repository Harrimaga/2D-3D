using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using From2Dto3D.Model;

namespace From2Dto3D.View
{
	/// <summary>
	/// This interface enforces member variables and events that each IView (such as a console app/GUI) needs to implement.
	/// </summary>
	internal abstract class Viewer
	{
		private readonly MainModel mainModel;

		//internal virtual event EventHandler<EventArgs>? ViewChanged;
		public Button button = new Button();
		public enum ButtonName { Start, End }
		protected Viewer(MainModel mainModel)
		{
			this.mainModel = mainModel;
		}

		public void OnButtonEvent(ButtonName name, string path)
		{
			switch(name)
			{
				case ButtonName.Start:
					button.buttonEvent += (s, args) =>
					{
						Console.WriteLine("Start button is pressed with path: " + args.FilePath);
					};
					break;
				case ButtonName.End:
					button.buttonEvent += (s, args) =>
					{
						Console.WriteLine("End button is pressed");
					};
					break;

			}
			button.OnClick(name, path);
		}

		public class Button
		{
			internal event EventHandler<ButtonArgs>? buttonEvent;
			public void OnClick(ButtonName name, string path)
			{
				ButtonArgs buttonArgs = new ButtonArgs();
				buttonArgs.Name = name;
				buttonArgs.FilePath = path;
				buttonEvent?.Invoke(this, buttonArgs);
			}
		}

		public class ButtonArgs : EventArgs
		{
			public ButtonName Name { get; set; }
			public string? FilePath { get; set; }
		}
	}
}
