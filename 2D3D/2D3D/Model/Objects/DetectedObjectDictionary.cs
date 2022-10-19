using System.Collections;

namespace From2Dto3D.Model
{

	class DetectedObjectDictionary : IDetectedObjectCollection
	{
		private int IDIndexer;
		private readonly Dictionary<int, DetectedObject> objects;

		public DetectedObjectDictionary()
		{
			objects = new Dictionary<int, DetectedObject>();
		}

		public DetectedObject this[int id] { get => objects[id]; set => objects[id] = value; }
		public int Count => objects.Count;
		public bool IsReadOnly => false;
		public void Add(DetectedObject item)
		{
			IDIndexer++;
			item.ID = IDIndexer;
			objects.Add(item.ID, item);
		}
		public void Clear()
		{
			IDIndexer = 0;
			objects.Clear();
		}
		public bool Contains(int id) => objects.ContainsKey(id);
		public bool Contains(DetectedObject item) => objects.ContainsKey(item.ID);
		public void CopyTo(DetectedObject[] array, int arrayIndex) => throw new NotImplementedException();
		public IEnumerator<DetectedObject> GetEnumerator() => new enumy(objects.GetEnumerator());
		public bool Remove(int id) => objects.Remove(id);
		public bool Remove(DetectedObject item) => objects.Remove(item.ID);
		IEnumerator IEnumerable.GetEnumerator() => objects.GetEnumerator();
	}
	class enumy : IEnumerator<DetectedObject>
	{
		Dictionary<int, DetectedObject>.Enumerator enumerator;
		public enumy(Dictionary<int, DetectedObject>.Enumerator enumerator)
		{
			this.enumerator = enumerator;
		}
		public DetectedObject Current => enumerator.Current.Value;
		object IEnumerator.Current => enumerator.Current.Value;
		public void Dispose() => enumerator.Dispose();
		public bool MoveNext() => enumerator.MoveNext();
		public void Reset() => enumerator.Dispose();
	}
}