using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.DepthAI;
using Emgu.CV.Dnn;
using Emgu.CV.Structure;
using Emgu.CV.Util;

using From2Dto3D.Core;

using Backend = Emgu.CV.Dnn.Backend;
using Target = Emgu.CV.Dnn.Target;

namespace From2Dto3D.EmguCV
{
	public class DarknetDetector
	{
		public float ConfidenceThreshold
		{
			get => configuration.ConfidenceThreshold;
			set => configuration.ConfidenceThreshold = value;
		}
		public float NonMaxSuppressionThreshold
		{
			get => configuration.NonMaxSuppressionThreshold;
			set => configuration.NonMaxSuppressionThreshold = value;
		}
		private DarkNetConfiguration configuration;
		private Size frameSize = new(640, 480);
		public int FrameWidth
		{
			get => frameSize.Width;
			set => frameSize.Width = resize(value);
		}
		public int FrameHeight
		{
			get => frameSize.Height;
			set => frameSize.Height = resize(value);
		}
		private readonly string[] openLayers;
		private readonly Net Network;
		public DarknetDetector(DarkNetConfiguration configuration)
		{
			this.configuration = configuration;
			Network = createNetwork(configuration.ConfigPath, configuration.WeightPath, configuration.Target, configuration.backend);
			openLayers = Network.UnconnectedOutLayersNames;
		}
		/// <summary>
		/// Runs an image through the Darknetmodel. 
		/// The image is resized using this instance's FrameWidth and FrameHeight, as well as converted to a 4 dimensional Mat in NCHW dimension order.
		/// </summary>
		/// <remarks>
		/// N: Batch| C: Channels| D: Depth| H: Height| W: Width
		/// </remarks>
		/// <param name="image">any image in RGB format</param>
		/// <returns>An array with the prediction in NCHW format ()</returns>
		public VectorOfMat Predict(IInputArray image)
		{
			VectorOfMat outputArray = new(openLayers.Length);
			Network.SetInput(DnnInvoke.BlobFromImage(image, size: frameSize));
			Network.Forward(outputArray, openLayers);
			return outputArray;
		}
		private static Net createNetwork(string configPath, string weightsPath, Target target, Backend backend)
		{
			Net net = DnnInvoke.ReadNetFromDarknet(configPath, weightsPath);
			net.SetPreferableTarget(target);
			net.SetPreferableBackend(backend);
			return net;
		}
		private static int resize(int s, int q = 32) => s % q < q / 2 ? s - (s % q) : s - (s % q) + q;
	}
}