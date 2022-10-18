namespace _2D3D.Model.DetectedObject
{
	class DetectedObjectList : IDetectedObjectCollection
	{
		private List<(ObjectID, DetectedObject)> objects = new();

		public DetectedObject this[ObjectID id]
		{
			get => throw new NotImplementedException(); set => throw new NotImplementedException();
		}
		public void addObject(DetectedObject obj) => throw new NotImplementedException();
		public void updateObject(ObjectID id) => throw new NotImplementedException();
	}

}
