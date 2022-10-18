using System.Collections;

namespace From2Dto3D.Model
{

	class DetectedObjectDictionary : IDetectedObjectCollection<ulong>
	{
		public DetectedObject this[ulong id] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

		public void addObject(ulong obj) => throw new NotImplementedException();
		public void addObject() => throw new NotImplementedException();
		public bool addObject(DetectedObject obj, out ulong id) => throw new NotImplementedException();
		public bool contains(ulong id) => throw new NotImplementedException();
		public int Count() => throw new NotImplementedException();
		public IEnumerable<DetectedObject> GetAllObjects(float PredictabilityThreshold = 100) => throw new NotImplementedException();
		public IEnumerator<DetectedObject> GetEnumerator() => throw new NotImplementedException();
		public IEnumerable<DetectedObject> GetLiveObjects(float PredictabilityThreshold) => throw new NotImplementedException();
		public bool remove(ulong id) => throw new NotImplementedException();
		public void updateObject(ulong id) => throw new NotImplementedException();
		public bool updateObject(DetectedObject obj, out ulong id) => throw new NotImplementedException();
		IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
	}
}