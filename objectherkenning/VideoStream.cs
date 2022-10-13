using Emgu.CV;
//using Emgu.CV.BitmapExtension.ToImage as timg;
using Emgu.CV.Structure;
using RtspClientSharp;
using RtspClientSharp.RawFrames.Video;
using RtspClientSharp.Rtsp;
using SimpleRtspPlayer.RawFramesDecoding;
using SimpleRtspPlayer.RawFramesDecoding.FFmpeg;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using PixelFormat = SimpleRtspPlayer.RawFramesDecoding.PixelFormat;


namespace Detection
{
    internal class VideoStream
    {

        private readonly Dictionary<FFmpegVideoCodecId, FFmpegVideoDecoder> _videoDecodersMap = new Dictionary<FFmpegVideoCodecId, FFmpegVideoDecoder>();
        private Bitmap bmp;
        private TransformParameters transformParameters;
        private CancellationTokenSource _cancellationTokenSource;

        public VideoStream()
        {
            //StartPlay("rtsp://user1:2D3Dproject@192.168.0.200:554/profile2/media.smp");
            StartPlay("rtsp://wowzaec2demo.streamlock.net/vod/mp4:BigBuckBunny_115k.mp4");
        }

        public async void StartPlay(string url)
        {
            var connectionParameters = new ConnectionParameters(new Uri(url));
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = null;
            }
            _cancellationTokenSource = new CancellationTokenSource();
            TimeSpan delay = TimeSpan.FromSeconds(1);
            using (var rtspClient = new RtspClient(connectionParameters))
            {
                rtspClient.FrameReceived += RtspClient_FrameReceived;
                while (true)
                {
                    try
                    {
                        await rtspClient.ConnectAsync(_cancellationTokenSource.Token);
                        await rtspClient.ReceiveAsync(_cancellationTokenSource.Token);
                    }
                    catch (OperationCanceledException)
                    {
                        return;
                    }
                    catch (RtspClientException e)
                    {
                        await Task.Delay(delay);
                    }
                }
            }
        }

        public void Stop()
        {
            _cancellationTokenSource?.Cancel();
            bmp?.Dispose();
            bmp = null;
        }

        private void RtspClient_FrameReceived(object sender, RtspClientSharp.RawFrames.RawFrame e)
        {
            if (_cancellationTokenSource == null || _cancellationTokenSource.IsCancellationRequested)
            {
                return;
            }

            if (!(e is RawVideoFrame rawVideoFrame))
            {
                return;
            }

            var codecId = DetectCodecId(rawVideoFrame);
            if (!_videoDecodersMap.TryGetValue(codecId, out FFmpegVideoDecoder decoder))
            {
                decoder = FFmpegVideoDecoder.CreateDecoder(codecId);
                _videoDecodersMap.Add(codecId, decoder);
            }
            var decodedVideoFrame = decoder.TryDecode(rawVideoFrame);
            if (decodedVideoFrame != null)
            {
                if (bmp != null)
                {
                    bmp.Dispose();
                }

                int width = 1280;
                int height = 720;

                transformParameters = new TransformParameters(RectangleF.Empty, new System.Drawing.Size(width, height), ScalingPolicy.Stretch, PixelFormat.Bgra32, ScalingQuality.FastBilinear);
                bmp = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

                // Lock the bitmap's bits.  
                var bmpData = bmp.LockBits(new Rectangle(new Point(0, 0), new Size(1280, 720)), System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat);

                IntPtr ptr = bmpData.Scan0;
                decodedVideoFrame.TransformTo(ptr, bmpData.Stride, transformParameters);

                //unlock bitmap's bits.
                bmp.UnlockBits(bmpData);

                Image<Bgr, byte> imageCV = bmp.ToImage<Bgr, byte>();

                CvInvoke.Imshow("test", imageCV);

            }
        }

        private FFmpegVideoCodecId DetectCodecId(RawVideoFrame videoFrame)
        {
            if (videoFrame is RawJpegFrame)
                return FFmpegVideoCodecId.MJPEG;
            if (videoFrame is RawH264Frame)
                return FFmpegVideoCodecId.H264;

            throw new ArgumentOutOfRangeException(nameof(videoFrame));
        }
    }
}

