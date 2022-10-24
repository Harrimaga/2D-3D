using From2Dto3D.View;
using From2Dto3D.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace From2Dto3D.Controller
{
	internal class MainController
    {
		private readonly IView viewer;
		private readonly MainModel model;
        public MainController(IView viewer, MainModel model)
        {
            this.viewer = viewer;
			this.model = model;
			this.viewer.SourcePath += PathReceiver;
        }
		private void PathReceiver(object? obj, PathArg pathArg)
		{
			model.MeshPath  = Path.GetFullPath(pathArg.Path, Path.GetTempPath());
			Debug.WriteLine(model.MeshPath);
		}
    }
}
