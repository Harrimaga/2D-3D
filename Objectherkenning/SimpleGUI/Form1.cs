using DarkNetImplementation;

namespace SimpleGUI
{
    public partial class Form1 : Form
    {
        private PersonDetection pD;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pD = new PersonDetection();

            pD.videoStream  = @"..\..\..\..\DarkNetImplementation\Resources\test.mp4";
            pD.labels       = @"..\..\..\..\DarkNetImplementation\NetworkModels\coco.names";
            pD.weights      = @"..\..\..\..\DarkNetImplementation\NetworkModels\yolov4-tiny.weights";
            pD.cfg          = @"..\..\..\..\DarkNetImplementation\NetworkModels\yolov4-tiny.cfg";

            if (textBox1.Text != "")
                pD.videoStream = textBox1.Text;

            pD.showConsoleOutput = consoleOutputCheckbox.Checked;
            pD.showImageOutput = imageOutputCheckbox.Checked;
            pD.showDebug = debugCheckbox.Checked;
            pD.Run();

            MessageBox.Show("Finished!");
        }
    }
}