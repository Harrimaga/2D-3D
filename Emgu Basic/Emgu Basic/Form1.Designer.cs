
namespace Emgu_Basic
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoadBTN = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.pedestrianCheck = new System.Windows.Forms.CheckBox();
            this.yoloBox = new System.Windows.Forms.CheckBox();
            this.timeLBL = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadBTN
            // 
            this.LoadBTN.Location = new System.Drawing.Point(611, 11);
            this.LoadBTN.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.LoadBTN.Name = "LoadBTN";
            this.LoadBTN.Size = new System.Drawing.Size(191, 47);
            this.LoadBTN.TabIndex = 0;
            this.LoadBTN.Text = "Load Image AND Detect";
            this.LoadBTN.UseVisualStyleBackColor = true;
            this.LoadBTN.Click += new System.EventHandler(this.LoadBTN_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(12, 63);
            this.pictureBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(790, 457);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // pedestrianCheck
            // 
            this.pedestrianCheck.AutoSize = true;
            this.pedestrianCheck.Location = new System.Drawing.Point(12, 12);
            this.pedestrianCheck.Name = "pedestrianCheck";
            this.pedestrianCheck.Size = new System.Drawing.Size(94, 20);
            this.pedestrianCheck.TabIndex = 2;
            this.pedestrianCheck.Text = "Pedestrian";
            this.pedestrianCheck.UseVisualStyleBackColor = true;
            this.pedestrianCheck.CheckedChanged += new System.EventHandler(this.pedestrianCheck_CheckedChanged);
            // 
            // yoloBox
            // 
            this.yoloBox.AutoSize = true;
            this.yoloBox.Checked = true;
            this.yoloBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.yoloBox.Location = new System.Drawing.Point(12, 38);
            this.yoloBox.Name = "yoloBox";
            this.yoloBox.Size = new System.Drawing.Size(124, 20);
            this.yoloBox.TabIndex = 3;
            this.yoloBox.Text = "Yolo Dectection";
            this.yoloBox.UseVisualStyleBackColor = true;
            this.yoloBox.CheckedChanged += new System.EventHandler(this.yoloBox_CheckedChanged);
            // 
            // timeLBL
            // 
            this.timeLBL.AutoSize = true;
            this.timeLBL.Location = new System.Drawing.Point(9, 533);
            this.timeLBL.Name = "timeLBL";
            this.timeLBL.Size = new System.Drawing.Size(88, 16);
            this.timeLBL.TabIndex = 5;
            this.timeLBL.Text = "Load Image...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 562);
            this.Controls.Add(this.timeLBL);
            this.Controls.Add(this.yoloBox);
            this.Controls.Add(this.pedestrianCheck);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.LoadBTN);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadBTN;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.CheckBox pedestrianCheck;
        private System.Windows.Forms.CheckBox yoloBox;
        private System.Windows.Forms.Label timeLBL;
    }
}

