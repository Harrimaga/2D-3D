using _2D3D.Controller;
using _2D3D.View;

namespace _2D3D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IView view = getView(args[0]);
            MainController mc = new(view);

        }
        static IView getView(string s)
        {
            return s switch
            {
                "Console" => new ConsoleViewer(),
                "WPF" => new WPFViewer(),
                _ => new ConsoleViewer(),
            };
        }
    }
}