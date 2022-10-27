using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace From2Dto3D.Core.View
{
    public class PathArg : EventArgs
    {
        public string Path;
        public PathArg(string Path)
        {
            this.Path = Path;
        }
    }
}
