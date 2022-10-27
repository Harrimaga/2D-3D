using Backend = Emgu.CV.Dnn.Backend;
using Target = Emgu.CV.Dnn.Target;

namespace From2Dto3D.EmguCV
{
	public struct DarkNetConfiguration
	{
		public float ConfidenceThreshold { get; set; }
		public float NonMaxSuppressionThreshold { get; set; }
		public string WeightPath { get; set; }
		public string ConfigPath { get; set; }
		public Backend backend { get; set; }
		public Target Target { get; set; }
	}
}