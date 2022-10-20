using System.Drawing;
using From2Dto3D.Model.Enums;

namespace From2Dto3D.Model
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
