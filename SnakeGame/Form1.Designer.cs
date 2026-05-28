using Microsoft.VisualBasic.Devices;

namespace SnakeGame
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
        public void InitializeComponent()
        {
            mousePictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)mousePictureBox).BeginInit();
            SuspendLayout();
            // 
            // mousePictureBox
            // 
            mousePictureBox.BackColor = SystemColors.ControlDark;
            mousePictureBox.Location = new Point(169, 187);
            mousePictureBox.Name = "mousePictureBox";
            mousePictureBox.Size = new Size(52, 51);
            mousePictureBox.TabIndex = 0;
            mousePictureBox.TabStop = false;
            mousePictureBox.Click += mousePictureBox_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 800);
            Controls.Add(mousePictureBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)mousePictureBox).EndInit();
            ResumeLayout(false);
            //       ResumeLayout(false);
        }

        #endregion

        private PictureBox snakePictureBox;
        private PictureBox mousePictureBox;
    }
}
