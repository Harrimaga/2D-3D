using Emgu.CV;
using Emgu.CV.Structure;
using System.Drawing;
using System.Diagnostics;
using Emgu.CV.Dnn;
using DnnBackend = Emgu.CV.Dnn.Backend;
using DnnTarget = Emgu.CV.Dnn.Target;
using Emgu.CV.Util;
using static EmguDetector.CFG;

namespace EmguDetector
{
    //Target: OpenCL  |  Backend: OpenCV
    //Target: OpenCLFp16  |  Backend: OpenCV
    //Target: Cpu  |  Backend: OpenCV
    //Target: Cuda  |  Backend: Cuda
    //Target: CudaFp16  |  Backend: Cuda
    internal static class CFG
    {
        internal static float NonMaxSupressionThreshold = 0.4f,
                                    ConfidenceThreshold = 0.5f;

        internal static int              fps = 1000,
                            resizeImageWidth =  200,
                           resizeImageHeight =  200;

        internal static DmmModel getModel(ModelType type) => type switch
        {
            ModelType.Yolov4 => new DmmModel()
            {
                LabelPath  = @"..\..\..\..\NetworkModels\coco.names",
                WeightPath = @"..\..\..\..\NetworkModels\yolov4-tiny.weights",
                ConfigPath = @"..\..\..\..\NetworkModels\yolov4-tiny.cfg"
            },
            _ => throw new Exception($"Model {type} not found"),
        };
        internal static string GetVideoPath(VideoSource source) => source switch
        {
            VideoSource.Default      => @"..\..\..\..\Resources\test.mp4",
            VideoSource.BigBuckBunny => @"rtsp://wowzaec2demo.streamlock.net/vod/mp4:BigBuckBunny_115k.mp4",
            VideoSource.IP1          => @"http://192.168.0.4:4747/video",
            VideoSource.IP2          => @"http://10.6.0.2:4747/video",
            VideoSource.IP3          => @"http://192.168.2.6:4747/video",
            _ => throw new Exception($"Source {source} not found"),
        };
        internal struct DmmModel
        {
            public string LabelPath { get; set; }
            public string WeightPath { get; set; }
            public string ConfigPath { get; set; }
        }
        internal static BackendTargetPair GetBackend(Backends backends) => DnnInvoke.AvailableBackends[(int)backends];
    }
    enum Backends
    {
        OpenCL_OpenCV = 0,
        OpenCLFp16_OpenCV = 1,
        Cpu_OpenCV = 2,
        Cuda_Cuda = 3,
        CudaFp16_Cuda = 4
    }
    enum ModelType
    {
        Yolov4
    }
    enum VideoSource
    {
        Default,
        BigBuckBunny,
        IP1,
        IP2,
        IP3
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            VideoCapture video = CreateVideoCapture();
            Net NeuralNetwork = createNetwork(ModelType.Yolov4, Backends.Cuda_Cuda);
            string[] labels = File.ReadAllLines(getModel(ModelType.Yolov4).LabelPath);


        }

        static Net createNetwork(ModelType modelType, Backends backends) => createNetwork(CFG.getModel(modelType), CFG.GetBackend(backends));
        static Net createNetwork(DmmModel dmmModel, BackendTargetPair backendTargetPair) => createNetwork(dmmModel.LabelPath, dmmModel.WeightPath, dmmModel.ConfigPath, backendTargetPair.Target, backendTargetPair.Backend);
        
        static Net createNetwork(string LabelPath, string WeightPath, string ConfigPath, DnnTarget target, DnnBackend backend)
        {
            Net net = DnnInvoke.ReadNetFromDarknet(ConfigPath, WeightPath);
            net.SetPreferableTarget(target);
            net.SetPreferableBackend(backend);
            return net;
        }
        static VideoCapture CreateVideoCapture() => CreateVideoCapture(VideoSource.Default);
        static VideoCapture CreateVideoCapture(VideoSource videoSource) => CreateVideoCapture(CFG.GetVideoPath(videoSource));
        static VideoCapture CreateVideoCapture(string source)
        {
            VideoCapture video = new(source);
            for (int i = 0; i < 10 && !video.IsOpened; i++)
            {
                Console.Write('.');
                Thread.Sleep(1000);
            }
            return video.IsOpened ? video : throw new Exception($"Video with source ``{source}`` not found");
        }



        static void Main2()
        {

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
                {
                    cap = new VideoCapture(video);
                    continue;
                }
                Stopwatch watch = new Stopwatch();
                watch.Start();
                List<YoloPrediction> results = model.Predict(frame.ToBitmap(), resizeImageWidth, resizeImageHeight);
                watch.Stop();
                Console.WriteLine($"Frame Processing time: {watch.ElapsedMilliseconds} ms." + $" FPS: {1000f / watch.ElapsedMilliseconds}");
                ShowImage(results, frame);
                CvInvoke.WaitKey(1000 / fps);
            }

            Console.ReadKey();
        }
        private static void ShowImage(List<YoloPrediction> input, Mat frame)
        {
            foreach (var item in input)
            {
                double xPosition = (item.BoundingBox.X + item.BoundingBox.Width) / 2;
                double yPosition = (item.BoundingBox.Y + item.BoundingBox.Height) / 2;
                Console.WriteLine("Found: " + item.Label + " at position " + xPosition + "," + yPosition);

                string text = item.Label + " " + item.Confidence;
                CvInvoke.Rectangle(frame, new Rectangle(item.BoundingBox.X - 2, item.BoundingBox.Y - 33, item.BoundingBox.Width + 4, 40), new MCvScalar(255, 0, 0), -1);
                CvInvoke.PutText(frame, text, new Point(item.BoundingBox.X, item.BoundingBox.Y - 15), Emgu.CV.CvEnum.FontFace.HersheySimplex, 0.6, new MCvScalar(255, 255, 255), 2);
                CvInvoke.Rectangle(frame, item.BoundingBox, new MCvScalar(255, 0, 0), 3);
            }
            CvInvoke.Imshow("Output", frame);
        }
    }
    public class DarknetYOLO
    {
        public Net Network { get; set; }
        public float ConfidenceThreshold { get; set; }
        public float NMSThreshold { get; set; }
        private string[] _labels;
        public DarknetYOLO(string labelsPath, string weightsPath, string configPath, DnnBackend backend, DnnTarget target)
        {
            Network = DnnInvoke.ReadNetFromDarknet(configPath, weightsPath);
            Network.SetPreferableBackend(backend);
            Network.SetPreferableTarget(target);
            _labels = File.ReadAllLines(labelsPath);
        }

        public List<YoloPrediction> Predict(Bitmap inputImage, int resizedWidth = 512, int resizedHeight = 512)
        {
            if (resizedWidth % 32 is int rest)
            {
                if (resizedWidth < 32)
                    resizedWidth = 32;
                if (rest < 16)
                    resizedWidth = (int)(32 * Math.Floor(resizedWidth / 32f));
                else
                    resizedWidth = (int)(32 * Math.Ceiling(resizedWidth / 32f));
            }

            if (resizedHeight % 32 is int rest2)
            {
                if (resizedHeight < 32)
                    resizedHeight = 32;
                if (rest2 < 16)
                    resizedHeight = (int)(32 * Math.Floor(resizedHeight / 32f));
                else
                    resizedHeight = (int)(32 * Math.Ceiling(resizedHeight / 32f));
            }

            Mat t = new Mat();
            int width = inputImage.Width;
            int height = inputImage.Height;
            VectorOfMat layerOutputs = new VectorOfMat();
            string[] outNames = Network.UnconnectedOutLayersNames;
            var blob = DnnInvoke.BlobFromImage(inputImage.ToImage<Bgr, byte>(), 1 / 255f, new Size(resizedWidth, resizedHeight), swapRB: true, crop: false);
            Network.SetInput(blob);
            Network.Forward(layerOutputs, outNames);

            List<Rectangle> boxes = new List<Rectangle>();
            List<float> confidences = new List<float>();
            List<int> classIDs = new List<int>();
            for (int k = 0; k < layerOutputs.Size; k++)
            {
                float[,] lo = (float[,])layerOutputs[k].GetData();
                int len = lo.GetLength(0);
                for (int i = 0; i < len; i++)
                {
                    if (lo[i, 4] < ConfidenceThreshold)
                        continue;
                    float max = 0;
                    int idx = 0;

                    int len2 = lo.GetLength(1);
                    for (int j = 5; j < len2; j++)
                        if (lo[i, j] > max)
                        {
                            max = lo[i, j];
                            idx = j - 5;
                        }

                    if (max > ConfidenceThreshold)
                    {
                        lo[i, 0] *= width;
                        lo[i, 1] *= height;
                        lo[i, 2] *= width;
                        lo[i, 3] *= height;

                        int x = (int)(lo[i, 0] - lo[i, 2] / 2);
                        int y = (int)(lo[i, 1] - lo[i, 3] / 2);

                        var rect = new Rectangle(x, y, (int)lo[i, 2], (int)lo[i, 3]);

                        rect.X = rect.X < 0 ? 0 : rect.X;
                        rect.X = rect.X > width ? width - 1 : rect.X;
                        rect.Y = rect.Y < 0 ? 0 : rect.Y;
                        rect.Y = rect.Y > height ? height - 1 : rect.Y;
                        rect.Width = rect.X + rect.Width > width ? width - rect.X - 1 : rect.Width;
                        rect.Height = rect.Y + rect.Height > height ? height - rect.Y - 1 : rect.Height;

                        boxes.Add(rect);
                        confidences.Add(max);
                        classIDs.Add(idx);
                    }
                }
            }
            int[] bIndexes = DnnInvoke.NMSBoxes(boxes.ToArray(), confidences.ToArray(), ConfidenceThreshold, NMSThreshold);

            List<YoloPrediction> filteredBoxes = new();
            if (bIndexes.Length > 0)
            {
                foreach (int idx in bIndexes)
                {
                    filteredBoxes.Add(new YoloPrediction()
                    {
                        BoundingBox = boxes[idx],
                        Confidence = Math.Round(confidences[idx], 4),
                        Label = _labels[classIDs[idx]]
                    });
                }
            }
            return filteredBoxes;
        }

    }
    public struct YoloPrediction
    {
        public Rectangle BoundingBox { get; set; }
        public string Label { get; set; }
        public double Confidence { get; set; }
    }

}