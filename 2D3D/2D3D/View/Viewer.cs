using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using From2Dto3D.Model;

namespace From2Dto3D.View
{
	/// <summary>
	/// This interface enforces member variables and events that each IView (such as a console app/GUI) needs to implement.
	/// </summary>
	public abstract class Viewer
	{
		protected readonly MainModel mainModel;
		public MainModel Model => mainModel;
		internal virtual event EventHandler<EventArgs>? ViewChanged;
		public virtual event EventHandler<PathArg> SourcePath;
		protected Viewer(MainModel mainModel)
		{
			this.mainModel = mainModel;
		}

	}
	public class PathArg : EventArgs
	{
		public string Path;
		public PathArg(string Path)
		{
			this.Path = Path;
		}
	}
}
