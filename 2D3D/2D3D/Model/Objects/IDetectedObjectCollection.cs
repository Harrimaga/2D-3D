namespace From2Dto3D.Model
{
	internal interface IDetectedObjectCollection :ICollection<DetectedObject>
	{
		public DetectedObject this[int id]
		{
			get; set;
		}

	}
}