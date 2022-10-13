using Detection;
using System;
using System.Drawing;

namespace objectherkenning
{
    internal class Program
    {
        static Bitmap b;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            VideoStream v = new VideoStream();
            Console.Read();
        }
    }
}
