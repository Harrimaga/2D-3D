using DarkNetImplementation.Models;
using Emgu.CV.Structure;
using Emgu.CV;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DarkNetImplementation
{
    public class PersonDetection
    {
        public string videoStream = @"..\..\..\Resources\test.mp4";
        public string labels = @"..\..\..\NetworkModels\coco.names";
        public string weights = @"..\..\..\NetworkModels\yolov4-tiny.weights";
        public string cfg = @"..\..\..\NetworkModels\yolov4-tiny.cfg";
        public int fps = 1000;
        public int resizeImageWidth = 200;
        public int resizeImageHeight = 200;
        public bool showImageOutput = true;
        public bool showConsoleOutput = true;
        public bool showDebug = false;
        public float NMSThreshold = 0.4f;
        public float ConfidenceThreshold = 0.5f;
        private DarknetYOLO ?model;

        public void Run()
        {
            VideoCapture cap = new VideoCapture(videoStream);

            if (showDebug)
            {
                Console.WriteLine("[DEBUG] Loading Model...");
                Console.WriteLine("[DEBUG] using " + resizeImageHeight.ToString() + "," + resizeImageWidth + " as resolution");
            }

            //Check if it is possible to run the recognition with Cuda enabled
            if (false && Emgu.CV.Cuda.CudaInvoke.HasCuda)
            {
                if (showDebug)
                    Console.WriteLine("[DEBUG] Running program with GPU");
                model = new DarknetYOLO(labels, weights, cfg, PreferredBackend.Cuda, PreferredTarget.Cuda);
            }
            else
            {
                if (showDebug)
                    Console.WriteLine("[DEBUG] Running program on CPU");
                model = new DarknetYOLO(labels, weights, cfg, PreferredBackend.Default, PreferredTarget.Cpu);
            }

            model.NMSThreshold = NMSThreshold;
            model.ConfidenceThreshold = ConfidenceThreshold;

            while (true)
            {
                Mat frame = new();
                try
                {
                    cap.Read(frame);
                    CvInvoke.Resize(frame, frame, new Size(1280, 768));
                }
                catch (Exception e)
                {
                    if (showDebug)
                        Console.WriteLine("[DEBUG] VideoEnded");
                    frame = null;
                }
                if (frame == null)
                    break;
                Stopwatch watch = new Stopwatch();
                watch.Start();
                List<YoloPrediction> results = model.Predict(frame.ToBitmap(), resizeImageWidth, resizeImageHeight);
                watch.Stop();
                if (showDebug)
                    Console.WriteLine($"[DEBUG] Frame Processing time: {watch.ElapsedMilliseconds} ms." + $" FPS: {1000f / watch.ElapsedMilliseconds}");

                ShowOutput(results, frame);

                CvInvoke.WaitKey(1000 / fps);
            }

            CvInvoke.DestroyWindow("Output");
        }
        private void ShowOutput(List<YoloPrediction> input, Mat frame)
        {
            foreach (YoloPrediction item in input)
            {
                if (showConsoleOutput)
                {
                    double xPosition = (item.Rectangle.X + item.Rectangle.Width) / 2;
                    double yPosition = (item.Rectangle.Y + item.Rectangle.Height) / 2;
                    Console.WriteLine("[INFO] Found: " + item.Label + " at position " + xPosition + "," + yPosition + " with confidence: " + item.Confidence);
                }

                if (showImageOutput)
                {
                    string text = item.Label + " " + item.Confidence;
                    CvInvoke.Rectangle(frame, new Rectangle(item.Rectangle.X - 2, item.Rectangle.Y - 33, item.Rectangle.Width + 4, 40), new MCvScalar(255, 0, 0), -1);
                    CvInvoke.PutText(frame, text, new Point(item.Rectangle.X, item.Rectangle.Y - 15), Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.6, new MCvScalar(255, 255, 255), 2);
                    CvInvoke.Rectangle(frame, item.Rectangle, new MCvScalar(255, 0, 0), 3);
                }
            }
            if(showImageOutput)
                CvInvoke.Imshow("Output", frame);
        }
    }
}