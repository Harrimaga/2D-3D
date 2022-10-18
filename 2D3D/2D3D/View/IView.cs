using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace From2Dto3D.View
{
    /// <summary>
    /// This interface enforces member variables and events that each IView (such as a console app/GUI) needs to implement.
    /// </summary>
    internal interface IView
    {
        
        event EventHandler<EventArgs> ViewChanged;
    }
}
