using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using Emgu.CV;
using Emgu.CV.Dnn;
using Emgu.CV.Util;

using Backend = Emgu.CV.Dnn.Backend;

namespace From2Dto3D.EmguCV
{
	public struct DetectedObject
	{
		public float Confidence { get; private set; }
		public Rectangle BoundingBox { get; private set; }
		public CocoNames CocoNames { get; private set; }
		public DetectedObject(float confidence, Rectangle boundingBox, CocoNames cocoNames)
		{
			Confidence = confidence;
			BoundingBox = boundingBox;
			CocoNames = cocoNames;
		}

	}
	internal class DetectorViewer
	{
		internal static void Main()
		{
			DarkNetConfiguration cfg = new()
			{
				ConfidenceThreshold = 0.5f,
				NonMaxSuppressionThreshold = 0.4f,
				WeightPath = @"Z:\Documenten\GitHub\2D-3D\Objectherkenning\DarkNetImplementation\NetworkModels\yolov4-tiny.weights",
				ConfigPath = @"Z:\Documenten\GitHub\2D-3D\Objectherkenning\DarkNetImplementation\NetworkModels\yolov4-tiny.cfg",
				//ConfigPath = @"Z:\2D-3D\2D3D\DarkNetImplementation\NetworkModels\yolov4-tiny.cfg",
				backend = Backend.Default,
				Target = Target.Cpu
			};
			DarknetDetector dn = new(cfg);
			VectorOfMat v = dn.Predict(new Mat(@"Z:\Documenten\GitHub\2D-3D\Objectherkenning\DarkNetImplementation\Resources\cars road.jpg"));

			float[]		Conf = new float[    v[0].Rows];
			Rectangle[] Rect = new Rectangle[v[0].Rows];
			float[][]	ResM = new float[v[0].Rows][];

			for(int i = 0; i < v[0].Rows; i++)
			{
				Conf[i] = GetDoubleValue(v[0], i , 0);
				Rect[i] = GetRect(v[0], i, dn.FrameWidth, dn.FrameHeight);
			}
			//float c = GetDoubleValue(v[0], 0, 0);
			//float[] q = GetPointConfidence(v[0], 0);
			//Mat mvr = new Mat(v[0], new Emgu.CV.Structure.Range(0, v[0].Rows), new Emgu.CV.Structure.Range(0, 3));
			//VectorOfRect vr = new(v[0].Rows);
			//mvr.CopyTo(vr);
			var result = DnnInvoke.NMSBoxes(Rect, Conf, dn.ConfidenceThreshold, dn.ConfidenceThreshold);
			List<DetectedObject> objects = new(result.Length);
			foreach(int i in result)
			{
				objects.Add(new DetectedObject(Conf[0], Rect[i], getName(i, v[0]) ));
			}
		}
		public static float GetDoubleValue(Mat mat, int row, int col)
		{
			float[] value = new float[1];
			Marshal.Copy(mat.DataPointer + (((row * mat.Cols) + col) * mat.ElementSize), value, 0, 1);
			return value[0];
		}
		/// <summary>
		/// Creates a shallow copy of a specified row from the Mat.
		/// </summary>
		/// <param name="mat">a float[,] Mat</param>
		/// <param name="row">The row to obtain, which corresponds to a detected object</param>
		/// <returns>a float[85], where 0-3 correspond to the boundingbox, 4 the Confidence and 5-84 to the individual label scores</returns>
		public static float[] GetPointConfidence(Mat mat, int row)
		{
			float[] value = new float[85];
			Marshal.Copy(mat.DataPointer + (row * mat.Cols * mat.ElementSize), value, 0, 85);
			return value;
		}
		public static CocoNames getName(int row, Mat mat)
		{
			var labels = getLabels(mat, row);
			float max = 0;
			CocoNames cocoNames = CocoNames.None;
			for(int i = 0; i < labels.Length; i++)
				if(labels[i] > max)
				{
					cocoNames = (CocoNames)i;
					max = labels[i];
				}
			return cocoNames;
		}
		public static Rectangle GetRect(Mat mat, int row, int width, int height)
		{
			float[] value = new float[5];
			Marshal.Copy(mat.DataPointer + (row * mat.Cols * mat.ElementSize), value, 0, 4);

			return toRect(value[0], value[1], value[2], value[3], width, height);
		}
		private static Rectangle toRect(float x1, float y1, float x2, float y2, int width, int height)
		{
			int Ix1 = (int)(x1*width);
			int Ix2 = (int)(x2*width);
			int Iy1 = (int)(y1*height);
			int Iy2 = (int)(y2*height);
			return new Rectangle(Ix1 - (Ix2 / 2), Iy1 - (Iy2 / 2), Ix2, Iy2);
		}
		public static float[] getLabels(Mat mat, int row)
		{
			float[] value = new float[80];
			Marshal.Copy(mat.DataPointer + (row * mat.Cols * mat.ElementSize)+4, value, 0, 80);
			return value;
		}
	}
}