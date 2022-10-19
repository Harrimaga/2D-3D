using From2Dto3D.View;
using From2Dto3D.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace From2Dto3D.Controller
{
	internal class MainController
    {
		private readonly Viewer viewer;
		private readonly MainModel model;
        public MainController(Viewer viewer, MainModel model)
        {
            this.viewer = viewer;
			this.model = model;
        }
    }
}
