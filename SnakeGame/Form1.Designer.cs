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
        private void InitializeComponent()
        {
            mouse = new PictureBox();
            snake = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)mouse).BeginInit();
            ((System.ComponentModel.ISupportInitialize)snake).BeginInit();
            SuspendLayout();
            // 
            // mouse
            // 
            mouse.BackColor = SystemColors.ActiveCaption;
            mouse.Location = new Point(88, 89);
            mouse.Name = "mouse";
            mouse.Size = new Size(19, 19);
            mouse.TabIndex = 0;
            mouse.TabStop = false;
            // 
            // snake
            // 
            snake.BackColor = SystemColors.MenuText;
            snake.Location = new Point(321, 189);
            snake.Name = "snake";
            snake.Size = new Size(19, 19);
            snake.TabIndex = 2;
            snake.TabStop = false;
            snake.Click += snake_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(snake);
            Controls.Add(mouse);
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            ((System.ComponentModel.ISupportInitialize)mouse).EndInit();
            ((System.ComponentModel.ISupportInitialize)snake).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox mouse;
        private PictureBox snake;
    }
}
