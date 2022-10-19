using From2Dto3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace From2Dto3D.Model
{
	internal class MainModel
	{
		IDetectedObjectCollection DetectedObjects;
		public MainModel()
		{
			DetectedObjects = new DetectedObjectList();
		}
	}
}
