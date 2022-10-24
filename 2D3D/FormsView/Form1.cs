using From2Dto3D.View;
namespace FormsView
{
    public partial class Form1 : Form , IView
    {
        //private readonly FormsViewer view;
        //public Form1(FormsViewer view)
        public Form1()
        {
            InitializeComponent();
            //button1.Text = view.CurrentPath;
        }

        public event EventHandler<EventArgs>? ViewChanged;
        public event EventHandler<PathArg>? SourcePath;

        private void button1_Click(object sender, EventArgs e)
        {
          //  SourcePath = new()
            SourcePath.Invoke(this, new PathArg(textBox1.Text));
            Console.WriteLine(textBox1.Text);
        }
    }
}