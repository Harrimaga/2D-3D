using From2Dto3D.Core.Model.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace From2Dto3D.Core.Model.Objects
{
    internal abstract class DetectedObject
    {
        public int ID { get; set; }
        public float ConfidenceScore { get; set; }
        public Point PixelPosition { get; private set; }
        public DateTime TimeOfCreation { get; }
        public ObjectType ObjectType { get; set; }
        public DetectedObject(int id, Point pixelPosition)
        {
            id = ID;
            TimeOfCreation = DateTime.Now;
        }

        protected DetectedObject(int iD) => ID = iD;
    }
}
