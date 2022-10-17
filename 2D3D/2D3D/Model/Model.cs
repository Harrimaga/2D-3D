using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D3D.Model
{
	internal class Model
	{
		IDetectedObjectCollection Objects;
		public Model()
		{
			Objects = new DetectedObjectList();
		}

	}

}
