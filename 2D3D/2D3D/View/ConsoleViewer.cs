using From2Dto3D.Model;

namespace From2Dto3D.View
{
	//TODO Implement ConsoleViewer
	internal class ConsoleViewer : Viewer
	{
		public ConsoleViewer(MainModel mainModel) : base(mainModel)
		{
			Console.WriteLine("Enter filepath to simulate button press");
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
			string key = Console.ReadLine();
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

			if(key.StartsWith("start: "))
			{
				OnButtonEvent(ButtonName.Start, key);
			}
			else if(key.StartsWith("end: "))
			{
				OnButtonEvent(ButtonName.End, key);
			}
			else
			{
				Console.WriteLine("Invalid button press");
			}
		}
	}
}
