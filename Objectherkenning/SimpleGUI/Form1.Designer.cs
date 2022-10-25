namespace SimpleGUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.imageOutputCheckbox = new System.Windows.Forms.CheckBox();
            this.consoleOutputCheckbox = new System.Windows.Forms.CheckBox();
            this.debugCheckbox = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.resolutionInput = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.usingSingleImage = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "RTSP Stream";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(126, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(538, 27);
            this.textBox1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(670, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // imageOutputCheckbox
            // 
            this.imageOutputCheckbox.AutoSize = true;
            this.imageOutputCheckbox.Checked = true;
            this.imageOutputCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.imageOutputCheckbox.Location = new System.Drawing.Point(30, 90);
            this.imageOutputCheckbox.Name = "imageOutputCheckbox";
            this.imageOutputCheckbox.Size = new System.Drawing.Size(163, 24);
            this.imageOutputCheckbox.TabIndex = 3;
            this.imageOutputCheckbox.Text = "Show Image Output";
            this.imageOutputCheckbox.UseVisualStyleBackColor = true;
            // 
            // consoleOutputCheckbox
            // 
            this.consoleOutputCheckbox.AutoSize = true;
            this.consoleOutputCheckbox.Checked = true;
            this.consoleOutputCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.consoleOutputCheckbox.Location = new System.Drawing.Point(209, 90);
            this.consoleOutputCheckbox.Name = "consoleOutputCheckbox";
            this.consoleOutputCheckbox.Size = new System.Drawing.Size(174, 24);
            this.consoleOutputCheckbox.TabIndex = 4;
            this.consoleOutputCheckbox.Text = "Show Console Output";
            this.consoleOutputCheckbox.UseVisualStyleBackColor = true;
            // 
            // debugCheckbox
            // 
            this.debugCheckbox.AutoSize = true;
            this.debugCheckbox.Location = new System.Drawing.Point(400, 90);
            this.debugCheckbox.Name = "debugCheckbox";
            this.debugCheckbox.Size = new System.Drawing.Size(116, 24);
            this.debugCheckbox.TabIndex = 5;
            this.debugCheckbox.Text = "Show Debug";
            this.debugCheckbox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(670, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Resolution";
            // 
            // resolutionInput
            // 
            this.resolutionInput.Location = new System.Drawing.Point(755, 89);
            this.resolutionInput.Name = "resolutionInput";
            this.resolutionInput.Size = new System.Drawing.Size(127, 27);
            this.resolutionInput.TabIndex = 7;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(796, 34);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 30);
            this.button2.TabIndex = 8;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // usingSingleImage
            // 
            this.usingSingleImage.AutoSize = true;
            this.usingSingleImage.Location = new System.Drawing.Point(522, 90);
            this.usingSingleImage.Name = "usingSingleImage";
            this.usingSingleImage.Size = new System.Drawing.Size(118, 24);
            this.usingSingleImage.TabIndex = 9;
            this.usingSingleImage.Text = "Single image";
            this.usingSingleImage.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 149);
            this.Controls.Add(this.usingSingleImage);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.resolutionInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.debugCheckbox);
            this.Controls.Add(this.consoleOutputCheckbox);
            this.Controls.Add(this.imageOutputCheckbox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Demo personen detectie";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Button button1;
        private CheckBox imageOutputCheckbox;
        private CheckBox consoleOutputCheckbox;
        private CheckBox debugCheckbox;
        private Label label2;
        private TextBox resolutionInput;
        private Button button2;
        private CheckBox usingSingleImage;
    }
}