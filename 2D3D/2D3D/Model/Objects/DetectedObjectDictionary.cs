namespace From2Dto3D.Model
{

	class DetectedObjectDictionary : IDetectedObjectCollection
	{
		public DetectedObject this[ObjectID id] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public void addObject(DetectedObject obj) => throw new NotImplementedException();
		public void addObject() => throw new NotImplementedException();
		public IEnumerable<DetectedObject> GetLiveObjects(float PredictabilityThreshold) => throw new NotImplementedException();
		public void updateObject(ObjectID id) => throw new NotImplementedException();
	}
}