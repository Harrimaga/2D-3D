using From2Dto3D.Core;
using From2Dto3D.Core.Model.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace From2Dto3D.Core.Model
{

    public class MainModel
    {
        public string MeshPath { get; set; }
        IDetectedObjectCollection DetectedObjects;
        public MainModel()
        {
            MeshPath = "";
            DetectedObjects = new DetectedObjectList();
        }
    }

}
