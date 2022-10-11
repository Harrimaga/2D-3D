using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Cuda;
using Emgu.CV.Models;
using Accord.Video.FFMPEG;
using System.Threading.Tasks;
using System.IO;



namespace Emgu_Basic
{
    public partial class Form1 : Form
    {
        Image<Bgr, byte> image;
        CudaImage<Bgr, byte> image2;
        Yolo yolo = new Yolo();
        VideoFileReader vFReader = new VideoFileReader();
        PedestrianDetector detector = new PedestrianDetector();
        bool video = false;
        System.Windows.Forms.Timer timer1 = new Timer();
        Stopwatch stopwatch = new Stopwatch();
        int frameElappsed = 0;
        bool pedestianDetection = false;

        public Form1()
        {
            InitializeComponent();
            Debug.Write(CudaInvoke.HasCuda.ToString());
            init();
        }

        private async void init()
        {
            await yolo.Init(Yolo.YoloVersion.YoloV4Tiny, null);
            await detector.Init();
        }

        private void videoDetection()
        {
            stopwatch = Stopwatch.StartNew();
            timer1.Interval = 10;
            timer1.Tick += yoloDectionTimer;
            timer1.Start();
            if(frameElappsed >= vFReader.FrameCount)
            {
                stop();
            }
        }

        private void stop()
        {
            timer1.Stop();
            stopwatch.Stop();
            vFReader.Close();
            timeLBL.Text = "Done in " + stopwatch.ElapsedMilliseconds + " ms";
        }

       
        private void yoloDectionTimer(object sender, EventArgs myEventArgs)
        {
            Bitmap bmpBaseOriginal = vFReader.ReadVideoFrame();
            if(bmpBaseOriginal != null)
            {
                image = bmpBaseOriginal.ToImage<Bgr, byte>();
                string text = yolo.ProcessAndRender(image, image);
                timeLBL.Text = text;
                byte[] bytes = image.ToJpegData();
                Image x = (Bitmap)((new ImageConverter()).ConvertFrom(bytes));
                pictureBox.Image = x;
                frameElappsed++;
            }
        }

        private void yoloDection()
        {
            string text = yolo.ProcessAndRender(image2, image);
            timeLBL.Text = text;
            byte[] bytes = image.ToJpegData();
            Image x = (Bitmap)((new ImageConverter()).ConvertFrom(bytes));
            pictureBox.Image = x;
        }

        private void detectPersons()
        {
            string text = detector.ProcessAndRender(image2, image);
            timeLBL.Text = text;
            byte[] bytes = image.ToJpegData();
            Image x = (Bitmap)((new ImageConverter()).ConvertFrom(bytes));
            pictureBox.Image = x;
        }

        private void LoadBTN_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                video = Path.GetExtension(dialog.FileName) == ".mp4";
                if (video)
                {
                    vFReader.Open(dialog.FileName);
                    videoDetection();
                }
                else
                {
                    image = new Image<Bgr, byte>(dialog.FileName);
                    if (pedestianDetection)
                    {
                        image2 = new CudaImage<Bgr, byte>(image);
                        detectPersons();
                    }
                    else
                    {
                        yoloDection();
                    }
                }
            }
        }

        private void pedestrianCheck_CheckedChanged(object sender, EventArgs e)
        {
            pedestianDetection = pedestrianCheck.Checked;
            yoloBox.Checked = !pedestrianCheck.Checked;
        }

        private void yoloBox_CheckedChanged(object sender, EventArgs e)
        {
            yoloBox.Checked = yoloBox.Checked;
            pedestrianCheck.Checked = !yoloBox.Checked;
            pedestianDetection = !yoloBox.Checked;
        }
    }
}
