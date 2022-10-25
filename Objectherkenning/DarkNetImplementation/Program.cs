using Emgu.CV;
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
            PersonDetection p = new();
            //p.videoStream = "rtsp://wowzaec2demo.streamlock.net/vod/mp4:BigBuckBunny_115k.mp4";
            //p.videoStream = "http://192.168.0.4:4747/video";
            //p.videoStream = "http://10.6.0.2:4747/video";
            //p.videoStream = "http://192.168.2.6:4747/video";
            //p.videoStream = "rtsp://user1:2D3Dproject@192.168.0.200:554/profile2/media.smp";
            p.resizeImageWidth = 512;
            p.resizeImageHeight = 512;
            p.Run();
        }
    }
}
