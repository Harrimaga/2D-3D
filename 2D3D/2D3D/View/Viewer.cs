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
    internal abstract class Viewer
    {
		private readonly MainModel mainModel;

		internal virtual event EventHandler<EventArgs>? ViewChanged;
		protected Viewer(MainModel mainModel)
		{
			this.mainModel = mainModel;
		}

    }
}
