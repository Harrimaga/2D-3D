using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;
using System.Drawing;
using System.Diagnostics;
using DarkNetImplementation.Models;

namespace DarkNetImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            string labels    = Path.GetFullPath(@"..\..\..\..\NetworkModels\coco.names");
            string weights   = Path.GetFullPath(@"..\..\..\..\NetworkModels\yolov4-tiny.weights");
            string cfg       = Path.GetFullPath(@"..\..\..\..\NetworkModels\yolov4-tiny.cfg");
            string video     = Path.GetFullPath(@"..\..\..\..\Resources\test.mp4");
    
            int fps = 1000;

            int resizeImageWidth = 200;
            int resizeImageHeight = 200;

            //VideoCapture cap = new VideoCapture("rtsp://wowzaec2demo.streamlock.net/vod/mp4:BigBuckBunny_115k.mp4");
            //VideoCapture cap = new VideoCapture("http://192.168.0.4:4747/video");
            //VideoCapture cap = new VideoCapture("http://10.6.0.2:4747/video");
            //VideoCapture cap = new VideoCapture("http://192.168.2.6:4747/video");
            VideoCapture cap = new VideoCapture(video);

            Console.WriteLine("[INFO] Loading Model...");

            DarknetYOLO model;

            //GPU
            if (Emgu.CV.Cuda.CudaInvoke.HasCuda)
            {
                Console.WriteLine("Running program with GPU");
                model = new DarknetYOLO(labels, weights, cfg, PreferredBackend.Cuda, PreferredTarget.Cuda);
            }
            else
            {
                Console.WriteLine("Running program on CPU");
                model = new DarknetYOLO(labels, weights, cfg, PreferredBackend.Default, PreferredTarget.Cpu);
            }

            model.NMSThreshold = 0.4f;
            model.ConfidenceThreshold = 0.5f;

            while (true)
            {
                Mat frame = new Mat();
                try
                {
                    cap.Read(frame);
                    CvInvoke.Resize(frame, frame, new Size(1280, 768));
                }
                catch(Exception e)
                {
                    Console.WriteLine("VideoEnded");
                    frame = null;
                }
                if (frame == null)
                {
                    cap = new VideoCapture(video);
                    continue;
                }
                Stopwatch watch = new Stopwatch();
                watch.Start();
                List<YoloPrediction> results = model.Predict(frame.ToBitmap(), resizeImageWidth, resizeImageHeight);
                watch.Stop();
                Console.WriteLine($"Frame Processing time: {watch.ElapsedMilliseconds} ms." + $" FPS: {1000f / watch.ElapsedMilliseconds}");

                //ShowImage(results, frame);
                
                CvInvoke.WaitKey(1000 / fps);
            }

            Console.ReadKey();
        }
        private static void ShowImage(List<YoloPrediction> input, Mat frame)
        {
            foreach (var item in input)
            {
                double xPosition = (item.Rectangle.X + item.Rectangle.Width) / 2;
                double yPosition = (item.Rectangle.Y + item.Rectangle.Height) / 2;
                Console.WriteLine("Found: " + item.Label + " at position " + xPosition + "," + yPosition);

                string text = item.Label + " " + item.Confidence;
                CvInvoke.Rectangle(frame, new Rectangle(item.Rectangle.X - 2, item.Rectangle.Y - 33, item.Rectangle.Width + 4, 40), new MCvScalar(255, 0, 0), -1);
                CvInvoke.PutText(frame, text, new Point(item.Rectangle.X, item.Rectangle.Y - 15), Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.6, new MCvScalar(255, 255, 255), 2);
                CvInvoke.Rectangle(frame, item.Rectangle, new MCvScalar(255, 0, 0), 3);
            }
            CvInvoke.Imshow("Output", frame);
        }
    }
}
