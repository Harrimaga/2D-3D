using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace From2Dto3D.Core.Model.Objects
{
    internal interface IDetectedObjectCollection : ICollection<DetectedObject>
    {
        public DetectedObject this[int id]
        {
            get; set;
        }
    }
}
