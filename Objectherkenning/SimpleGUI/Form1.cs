using DarkNetImplementation;
using Microsoft.VisualBasic.ApplicationServices;

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

            

            //pD.weights = @"..\..\..\..\DarkNetImplementation\NetworkModels\yolov7\yolov7-tiny.weights";
            //pD.cfg = @"..\..\..\..\DarkNetImplementation\NetworkModels\yolov7\yolov7-tiny_darknet.cfg";

            //pD.weights = @"C:\Users\Wai Kei Law\Documents\GitHub\2D-3D\Objectherkenning\DarkNetImplementation\NetworkModels\yolov7\yolov7-tiny_darknet.cfg";
            //pD.cfg = @"C:\Users\Wai Kei Law\Documents\GitHub\2D-3D\Objectherkenning\DarkNetImplementation\NetworkModels\yolov7\yolov7-tiny.weights";

            //pD.ConfidenceThreshold = 0.3f;
            if (resolutionInput.Text != "")
            {
                if (!int.TryParse(resolutionInput.Text, out pD.resizeImageHeight))
                { MessageBox.Show("Resolution is not a number"); return; }
            }
            else pD.resizeImageHeight = 512;

            pD.resizeImageWidth = pD.resizeImageHeight;

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