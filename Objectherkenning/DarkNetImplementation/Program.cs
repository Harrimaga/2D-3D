﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV.Dnn;
using Emgu.CV;
using Emgu.CV.Util;
using Emgu.CV.Structure;
using System.Drawing;
using System.Diagnostics;
using System.Reflection;
using DarkNetImplementation.Models;

namespace DarkNetImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            string labels = @"..\..\..\NetworkModels\coco.names";
            string weights = @"..\..\..\NetworkModels\yolov4-tiny.weights";
            string cfg = @"..\..\..\NetworkModels\yolov4-tiny.cfg";
            string video = @"..\..\..\Resources\test.mp4";
            int fps = 1000;

            //VideoCapture cap = new VideoCapture("rtsp://wowzaec2demo.streamlock.net/vod/mp4:BigBuckBunny_115k.mp4");
            //VideoCapture cap = new VideoCapture("http://192.168.0.4:4747/video");
            //VideoCapture cap = new VideoCapture("http://10.6.0.2:4747/video");
            //VideoCapture cap = new VideoCapture("http://192.168.2.6:4747/video");
            VideoCapture cap = new VideoCapture(video);

            Console.WriteLine("[INFO] Loading Model...");
            //GPU
            DarknetYOLO model = new DarknetYOLO(labels, weights, cfg, PreferredBackend.Cuda, PreferredTarget.Cuda);

            //CPU
            //DarknetYOLO model = new DarknetYOLO(labels, weights, cfg, PreferredBackend.Default, PreferredTarget.Cpu);
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
                catch (Exception e)
                {
                    Console.WriteLine("VideoEnded");
                    frame = null;
                }
                if (frame == null)
                    break;
                Stopwatch watch = new Stopwatch();
                watch.Start();
                List<YoloPrediction> results = model.Predict(frame.ToBitmap(), 200, 200);
                watch.Stop();
                Console.WriteLine($"Frame Processing time: {watch.ElapsedMilliseconds} ms." + $" FPS: {1000f / watch.ElapsedMilliseconds}");

                foreach (YoloPrediction p in results)
                {
                    //if(p.Label == "Person")
                    //{
                    double xPosition = (p.Rectangle.X + p.Rectangle.Width) / 2;
                    double yPosition = (p.Rectangle.Y + p.Rectangle.Height) / 2;
                    Console.WriteLine("Found: " + p.Label + " at position " + xPosition + "," + yPosition);
                    //}
                }
                foreach (var item in results)
                {
                    string text = item.Label + " " + item.Confidence;
                    CvInvoke.Rectangle(frame, new Rectangle(item.Rectangle.X - 2, item.Rectangle.Y - 33, item.Rectangle.Width + 4, 40), new MCvScalar(255, 0, 0), -1);
                    CvInvoke.PutText(frame, text, new Point(item.Rectangle.X, item.Rectangle.Y - 15), Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.6, new MCvScalar(255, 255, 255), 2);
                    CvInvoke.Rectangle(frame, item.Rectangle, new MCvScalar(255, 0, 0), 3);
                }
                CvInvoke.Imshow("test", frame);
                CvInvoke.WaitKey(1000 / fps);
            }

            Console.ReadKey();
        }
    }
}
