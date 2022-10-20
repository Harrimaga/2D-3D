using System.Drawing;

namespace From2Dto3D.Model
{
	internal class PersonObject : DetectedObject
	{
		//TO DO: position als membervariabele verwerken (kan pas als preprocessing af is)
		//TO DO: datatype pixel navragen bij WK en DK
		//TO DO: wat voor datatypes rotation en scale??
		public PersonObject(int id, Point pixelPosition) : base(id, pixelPosition)
		{

		}
	}
}