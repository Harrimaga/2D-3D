using From2Dto3D.View;
namespace FormsView
{
    public partial class Form1 : Form
    {
        private readonly FormsViewer view;
        public Form1(FormsViewer view)
        {
            this.view = view;
            InitializeComponent();
            button1.Text = view.CurrentPath;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            view.SendPath(textBox1.Text);
        }
    }
}