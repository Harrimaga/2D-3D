using From2Dto3D.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace From2Dto3D.Controller
{
    internal class MainController
    {
		private readonly IView view;

        public MainController(IView view)
        {
            this.view = view;
            
        }
    }
}
