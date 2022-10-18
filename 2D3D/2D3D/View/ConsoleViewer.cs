namespace From2Dto3D.View
{
	//TODO Implement ConsoleViewer
	internal class ConsoleViewer : IView
    {
        public event EventHandler<EventArgs> ViewChanged;
		public void t()
		{

			ViewChanged.Invoke(this, EventArgs.Empty);
		}
	}
	class eventdinges : EventArgs {
		string path;

	}

}
