namespace From2Dto3D.Model
{
	interface IDetectedObjectCollection
	{
		public DetectedObject this[ObjectID id]
		{
			get; set;
		}
		public void addObject(DetectedObject obj);
		void addObject();
		public void updateObject(ObjectID id);
		public IEnumerable<DetectedObject> GetLiveObjects(float PredictabilityThreshold);
	}

}
