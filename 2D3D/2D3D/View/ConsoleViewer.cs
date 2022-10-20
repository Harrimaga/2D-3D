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
			string[] key = Console.ReadLine().Split(':',2);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

			if(key[0] == "start")
			{
				OnButtonEvent(ButtonName.Start, key[1]);
			}
			else if(key[1] == "end")
			{
				OnButtonEvent(ButtonName.End, key[1]);
			}
			else
			{
				Console.WriteLine("Invalid button press");
			}
		}
	}
}
