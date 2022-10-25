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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "RTSP Stream";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(110, 27);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(471, 23);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "rtsp://user1:2D3Dproject@192.168.0.200:554/profile2/media.smp";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(586, 26);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 22);
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
            this.imageOutputCheckbox.Location = new System.Drawing.Point(26, 68);
            this.imageOutputCheckbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.imageOutputCheckbox.Name = "imageOutputCheckbox";
            this.imageOutputCheckbox.Size = new System.Drawing.Size(132, 19);
            this.imageOutputCheckbox.TabIndex = 3;
            this.imageOutputCheckbox.Text = "Show Image Output";
            this.imageOutputCheckbox.UseVisualStyleBackColor = true;
            // 
            // consoleOutputCheckbox
            // 
            this.consoleOutputCheckbox.AutoSize = true;
            this.consoleOutputCheckbox.Checked = true;
            this.consoleOutputCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.consoleOutputCheckbox.Location = new System.Drawing.Point(183, 68);
            this.consoleOutputCheckbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.consoleOutputCheckbox.Name = "consoleOutputCheckbox";
            this.consoleOutputCheckbox.Size = new System.Drawing.Size(142, 19);
            this.consoleOutputCheckbox.TabIndex = 4;
            this.consoleOutputCheckbox.Text = "Show Console Output";
            this.consoleOutputCheckbox.UseVisualStyleBackColor = true;
            // 
            // debugCheckbox
            // 
            this.debugCheckbox.AutoSize = true;
            this.debugCheckbox.Location = new System.Drawing.Point(350, 68);
            this.debugCheckbox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.debugCheckbox.Name = "debugCheckbox";
            this.debugCheckbox.Size = new System.Drawing.Size(93, 19);
            this.debugCheckbox.TabIndex = 5;
            this.debugCheckbox.Text = "Show Debug";
            this.debugCheckbox.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(471, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Resolution";
            // 
            // resolutionInput
            // 
            this.resolutionInput.Location = new System.Drawing.Point(545, 68);
            this.resolutionInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.resolutionInput.Name = "resolutionInput";
            this.resolutionInput.Size = new System.Drawing.Size(112, 23);
            this.resolutionInput.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 112);
            this.Controls.Add(this.resolutionInput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.debugCheckbox);
            this.Controls.Add(this.consoleOutputCheckbox);
            this.Controls.Add(this.imageOutputCheckbox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
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
    }
}