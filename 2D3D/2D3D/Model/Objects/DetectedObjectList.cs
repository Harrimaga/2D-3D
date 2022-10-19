using System.Collections;

namespace From2Dto3D.Model
{
	class DetectedObjectList : IDetectedObjectCollection
	{
		private int IDIndexer;
		private List<DetectedObject> objects;
		int ICollection<DetectedObject>.Count => objects.Count;

		public bool IsReadOnly => false;

		public DetectedObjectList()
		{
			objects = new();
		}
		public DetectedObjectList(int capacity)
		{
			objects = new(capacity);
		}
		public DetectedObjectList(ICollection<DetectedObject> em)
		{
			objects = new(em.Count);
			foreach(DetectedObject o in em) Add(o);
		}
		public DetectedObject this[int id]
		{
			get => Contains(id) ? objects[id] : throw new KeyNotFoundException($"{id} was not found");
			set => Add(value);
		}
		public void Add(DetectedObject obj)
		{
			IDIndexer++;
			obj.ID = IDIndexer;
			objects.Add(obj);
		}
		public void Clear()
		{
			IDIndexer = 0;
			objects.Clear();
		}
		public bool Contains(int id) => objects.Any(x => x.ID == id);
		public bool Contains(DetectedObject item) => objects.Any(x => x == item);
		public void CopyTo(DetectedObject[] array, int arrayIndex) => objects.CopyTo(new DetectedObject[objects.Count - arrayIndex], arrayIndex);
		public bool Remove(int id) => objects.RemoveAll(x => x.ID == id) > 0;
		public bool Remove(DetectedObject item) => objects.Remove(item);
		public IEnumerator<DetectedObject> GetEnumerator() => objects.GetEnumerator();
		IEnumerator IEnumerable.GetEnumerator() => objects.GetEnumerator();
	}
}
