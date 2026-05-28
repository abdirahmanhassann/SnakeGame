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
        public int gridSize = 20;
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
            CheckSnakeCollision();
            CheckMouseCollision();
            SnakeMovement();
            CheckOutOfBounds();
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
            ///_snakeDirection = Directions.north;
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
            if (_Snake.Count == 0)
            {
                snakePictureBox.Location = new Point(GenerateInitialSnakePosition(), GenerateInitialSnakePosition());
            }
            else 
            { 
                if(_snakeDirection == Directions.north)
                {
                    snakePictureBox.Location = new Point(_Snake[_Snake.Count-1].Location.X, _Snake[_Snake.Count - 1].Location.Y - snakePictureBox.Height);
                }
                else if (_snakeDirection == Directions.east)
                {
                    snakePictureBox.Location = new Point(_Snake[_Snake.Count - 1].Location.X + snakePictureBox.Width, _Snake[_Snake.Count - 1].Location.Y);
                }
                else if (_snakeDirection == Directions.south)
                {
                    snakePictureBox.Location = new Point(_Snake[_Snake.Count - 1].Location.X, _Snake[_Snake.Count - 1].Location.Y + snakePictureBox.Height);

                }
                else if (_snakeDirection == Directions.west)
                {
                    snakePictureBox.Location = new Point(_Snake[_Snake.Count - 1].Location.X - snakePictureBox.Width, _Snake[_Snake.Count - 1].Location.Y - snakePictureBox.Height);
                }
            }
            snakePictureBox.Size = new Size(_x, _y);
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
            return axis * _x - ((axis * _x) % gridSize);
        }

        private void GenerateMousePosition()
        {
            bool isMouseOnSnake;
            Random rand = new();
            while (true)
            {
                //refactored to handle gridbased mvmnt
                int[] mousePosition = new int[2];
                mousePosition[0] = rand.Next(0, gridSize);
                mousePosition[1] = rand.Next(0, gridSize);
                mousePosition[0] = mousePosition[0]*_x;
                mousePosition[1] = mousePosition[1] *_y;

                isMouseOnSnake = false;
                for (int i = 0; i < _Snake.Count; i++)
                {
                    if (_Snake[i].Location.X == mousePosition[0] && _Snake[i].Location.Y == mousePosition[1])
                    {
                        isMouseOnSnake = true;
                        break;
                    }
                }
                if (!isMouseOnSnake)
                {
                    mousePictureBox.Location = new Point(mousePosition[0], mousePosition[1]);
                    break;
                    // return _ballPosition;
                }
            }

        }

        private void SnakeMovement()
        {
            Point previousLocation = _Snake[0].Location;
            if (_snakeDirection == Directions.north)
            {
                _Snake[0].Location = new Point(
                    _Snake[0].Location.X,
                    _Snake[0].Location.Y - _y);
            }

            if (_snakeDirection == Directions.east)
            {
                _Snake[0].Location = new Point(
                    _Snake[0].Location.X + _x,
                    _Snake[0].Location.Y);
            }

            if (_snakeDirection == Directions.south)
            {
                _Snake[0].Location = new Point(
                    _Snake[0].Location.X,
                    _Snake[0].Location.Y + _y);
            }

            if (_snakeDirection == Directions.west)
            {
                _Snake[0].Location = new Point(
                    _Snake[0].Location.X - _x,
                    _Snake[0].Location.Y);
            }
            for (int i = 1; i < _Snake.Count; i++)
            {
                Point temp = _Snake[i].Location;

                _Snake[i].Location = previousLocation;

                previousLocation = temp;
            }
        }
        

        private void CheckMouseCollision()
        {
            if (_Snake[0].Location == mousePictureBox.Location)
            {
                GenerateMousePosition();
                _Snake.Add(CreateSnakePictureBox());
            }
        }

        private void CheckSnakeCollision()
        {
            for (int i = 1; i < _Snake.Count(); i++)
            {
                if (_Snake[i].Location.X == _Snake[0].Location.X && _Snake[i].Location.Y == _Snake[0].Location.Y)
                {
                    _myTimer.Stop();
                    _myTimer.Dispose();
                    MessageBox.Show($"Game Over,\n Your score is {_Snake.Count() - 1}");
                    
                }
            }
        }
        private void CheckOutOfBounds()
        {
            if (_Snake[0].Location.X < 0 || _Snake[0].Location.Y < 0 || _Snake[0].Location.X > ClientSize.Width || _Snake[0].Location.Y > ClientSize.Height)
            {
                _myTimer.Stop();
                _myTimer.Dispose();
                MessageBox.Show($"Game Over,\n Your score is {_Snake.Count() - 1}");
            }
        }
        private void mousePictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}