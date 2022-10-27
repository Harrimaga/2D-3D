using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace From2Dto3D.Core.View
{
    public interface IView
    {
        public event EventHandler<EventArgs>? ViewChanged;
        public event EventHandler<PathArg>? SourcePath;
    }
}
