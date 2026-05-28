using Microsoft.VisualBasic.Devices;
using Microsoft.VisualBasic.Logging;
using System.ComponentModel;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        public enum Directions
        {
            north = Keys.Up,
            east = Keys.Right,
            south = Keys.Down,
            west = Keys.Left
        }
        public Directions _snakeDirection = Directions.north;
        private System.Windows.Forms.Timer _myTimer = new System.Windows.Forms.Timer();
        public List<PictureBox> _Snake = new();
        public int _x;
        public int _y;
        public int gridSize = 15;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitialValues();
            _myTimer.Tick += new EventHandler(GameLoop);
            _myTimer.Interval = 200;
            _myTimer.Start();
        }
        private void GameLoop(object sender, EventArgs e)
        {

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && _snakeDirection != Directions.south)
            {
                _snakeDirection = Directions.north;
            }
            if (e.KeyCode == Keys.Right && _snakeDirection != Directions.west)
            {
                _snakeDirection = Directions.east;
            }
            if (e.KeyCode == Keys.Down && _snakeDirection != Directions.north)
            {
                _snakeDirection = Directions.south;
            }
            if (e.KeyCode == Keys.Left && _snakeDirection != Directions.east)
            {
                _snakeDirection = Directions.west;
            }
        }
        private void InitialValues()
        {
            _snakeDirection = Directions.west;
            _x = this.ClientSize.Width / gridSize;
            _y = this.ClientSize.Height / gridSize;
            _Snake.Add(CreateSnakePictureBox());
            GenerateMousePosition();
        }
        private PictureBox CreateSnakePictureBox()
        {
            Random ran = new();
            PictureBox snakePictureBox = new();
            snakePictureBox.Name = $"snakePictureBox{_Snake.Count + 1}";
            snakePictureBox.Location = new Point(GenerateInitialSnakePosition(), GenerateInitialSnakePosition());
            snakePictureBox.Size = new Size(this.ClientSize.Width / gridSize, this.ClientSize.Height / gridSize);
            snakePictureBox.TabIndex = 0;
            snakePictureBox.TabStop = false;
            snakePictureBox.BackColor = Color.FromArgb(255, 255, 20);
            this.Controls.Add(snakePictureBox);
            return snakePictureBox;
        }
        private int GenerateInitialSnakePosition()
        {
            Random rand = new();
            int axis = rand.Next(1, gridSize);
            return axis * _x;
        }

        private void GenerateMousePosition()
        {
            bool isBallOnSnake;
            Random rand = new();
            while (true)
            {
                int[] mousePosition = new int[2];
                mousePosition[0] = rand.Next(0, this.ClientSize.Width);
                mousePosition[1] = rand.Next(0, this.ClientSize.Width);
                //formula to generate ball on square grid.
                //wrote this a couple months ago
                //dont remember why i took this approach.
                //not the most efficient code, but it works and i cba figuring out a better way.
                mousePosition[0] = mousePosition[0] - (mousePosition[0] % gridSize);
                mousePosition[1] = mousePosition[1] - (mousePosition[1] % gridSize);

                isBallOnSnake = false;
                for (int i = 0; i < _Snake.Count; i++)
                {
                    if (_Snake[i].Location.X == mousePosition[0] && _Snake[i].Location.Y == mousePosition[1])
                    {
                        isBallOnSnake = true;
                        break;
                    }
                }
                if (!isBallOnSnake)
                {
                    mousePictureBox.Location = new Point(mousePosition[0], mousePosition[1]);
                    break;
                    // return _ballPosition;
                }
            }

        }

        private void mousePictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}