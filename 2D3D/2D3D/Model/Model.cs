﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace From2Dto3D.Model
{
	internal class Model
	{
		IDetectedObjectCollection<int> Objects;
		public Model()
		{
			Objects = new DetectedObjectList();
		}

	}

}
