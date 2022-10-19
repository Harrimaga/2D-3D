using From2Dto3D.Model.Enums;

namespace From2Dto3D.Model
{
	internal abstract class DetectedObject
	{
		public int ID { get; set; }
		public float ConfidenceScore { get; set; }
		public DateTime TimeOfCreation { get; }
		public ObjectType ObjectType { get; set; }
		public DetectedObject(int ID)
		{
			this.ID = ID;
			TimeOfCreation = DateTime.Now;
		}
	}
}
