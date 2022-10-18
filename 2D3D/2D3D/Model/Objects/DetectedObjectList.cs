using System.Collections;

namespace From2Dto3D.Model
{
	class DetectedObjectList : IDetectedObjectCollection<int>
	{
		private List<DetectedObject> objects;
		public DetectedObjectList()
		{
			objects = new();
		}
		public DetectedObjectList(int capacity)
		{
			objects = new(capacity);
		}
		public DetectedObjectList(IEnumerable<DetectedObject> em)
		{
			objects = new(em);
		}
		public DetectedObject this[int index] 
		{
			get
			{
				if(index > Count()) 
					throw new IndexOutOfRangeException($"{index} is larger than the current list size{Count()}");
				return objects[index];
			}
			set => objects.Add(value);
		}
		public bool addObject(DetectedObject obj, out int id)
		{
			objects.Add(obj);
			id = Count();
			return true;
		}
		public bool contains(int id) => throw new NotImplementedException();
		public int Count() => objects.Count;
		public IEnumerable<DetectedObject> GetAllObjects(float PredictabilityThreshold = 100) => throw new NotImplementedException();
		public IEnumerator<DetectedObject> GetEnumerator() => throw new NotImplementedException();
		public bool remove(int id) => throw new NotImplementedException();
		public bool updateObject(DetectedObject obj, out int id) => throw new NotImplementedException();
		IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
	}

}
