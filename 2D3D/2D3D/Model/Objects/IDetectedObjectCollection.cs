namespace From2Dto3D.Model
{
	interface IDetectedObjectCollection<T> :IEnumerable<DetectedObject>
	{
		public DetectedObject this[T id]
		{
			get; set;
		}
		public bool addObject(DetectedObject obj, out T id);
		public bool updateObject(DetectedObject obj, out T id);
		public IEnumerable<DetectedObject> GetAllObjects(float PredictabilityThreshold = 100);
		public int Count();
		public bool remove(T id);
		public bool contains(T id);
	}
}
