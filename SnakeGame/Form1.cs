using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        private int[] _ballPosition;
        private bool isActive = true;
        private List<int[]> _snakePosition = new List<int[]>();
        private int _snakeDirection = 3;
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                myTimer.Tick += new EventHandler(GameTimer);
                myTimer.Interval = 200;
                myTimer.Start();
                _snakePosition.Add([(this.ClientSize.Width / 2) - ((this.ClientSize.Width / 2) %snake.Size.Width ) , 
                    (this.ClientSize.Height / 2) - ((this.ClientSize.Height / 2) % snake.Size.Height)]);
                GenerateBallPosition(_snakePosition);
        }
        private void GameTimer(object sender, EventArgs e)
        {
            if (!isActive) return;
            if(snake.Location.X <=0 || snake.Location.X >= this.ClientSize.Width - snake.Size.Width || snake.Location.Y <=0 || snake.Location.Y >= this.ClientSize.Height - snake.Size.Height)
            {
                isActive = false;
                myTimer.Stop();
                MessageBox.Show($"Game Over, your score is {_snakePosition.Count}");
                GenerateBallPosition(_snakePosition);
                return;
            }
            if (_snakePosition[0][0] == _ballPosition[0] && _snakePosition[0][1] == _ballPosition[1])
            {
                int width = 0;
                int height = 0;

                if (_snakeDirection == 2) 
                {
                    width = _snakePosition[_snakePosition.Count - 1][0] - snake.Size.Width;
                }
                if (_snakeDirection == 4)
                {
                    width = _snakePosition[_snakePosition.Count - 1][0] + snake.Size.Width;
                }
                if (_snakeDirection == 1)
                {
                    height = _snakePosition[_snakePosition.Count - 1][0] + snake.Size.Height;
                }
                if (_snakeDirection == 3)
                {
                    height = _snakePosition[_snakePosition.Count - 1][0] - snake.Size.Height;
                }
                _snakePosition.Add([width,height]);
                GenerateBallPosition(_snakePosition);
            }
                SnakeMovement();
        }

        private void GenerateBallPosition(List<int[]> initialSnakePosition)
        {
            bool isBallOnSnake;
            Random rand = new();
            while (true)
            {
                _ballPosition = new int[2];
                _ballPosition[0] = rand.Next(0, this.ClientSize.Width - snake.Size.Width);
                _ballPosition[1] = rand.Next(0, this.ClientSize.Height- snake.Size.Height);
                //formula to generate ball on 4x4 grid
                _ballPosition[0] = _ballPosition[0] - (_ballPosition[0] % snake.Size.Width);
                _ballPosition[1] = _ballPosition[1] - (_ballPosition[1] % snake.Size.Height);

                isBallOnSnake = false;
                for (int i = 0; i < _snakePosition.Count; i++)
                {
                    if (_snakePosition[i][0] == _ballPosition[0] && _snakePosition[i][1] == _ballPosition[1])
                    {
                        isBallOnSnake = true;
                        break;
                    }
                }
                if (!isBallOnSnake)
                {
                    mouse.Location = new Point(_ballPosition[0], _ballPosition[1]);
                    break;
                   // return _ballPosition;
                }
            }
        }

        private void snake_Click(object sender, EventArgs e)
        {
        }
        private void SnakeMovement()
        {
            if (_snakeDirection == 1)
            {
                int[] temp;
                int i = 0;
                //_snakePosition[0].ToArray();
                while (i < _snakePosition.Count - 1)
                {
                    temp = _snakePosition[i + 1];
                    _snakePosition[i] = _snakePosition[i + 1];
                    i++;
                }
                _snakePosition[0] = [_snakePosition[0][0], _snakePosition[0][1] - snake.Size.Height];
                snake.Location = new Point(_snakePosition[0][0], _snakePosition[0][1]);
            }
            if (_snakeDirection == 2)
            {
                int[] temp;
                int i = 0;
                //_snakePosition[0].ToArray();
                while (i < _snakePosition.Count - 1)
                {
                    temp = _snakePosition[i + 1];
                    _snakePosition[i] = _snakePosition[i + 1];
                    i++;
                }
                _snakePosition[0] = [_snakePosition[0][0] + snake.Size.Height, _snakePosition[0][1]];
                snake.Location = new Point(_snakePosition[0][0], _snakePosition[0][1]);
            }
            if (_snakeDirection == 3)
            {
                int[] temp;
                int i = 0;
                //_snakePosition[0].ToArray();
                while (i < _snakePosition.Count - 1)
                {
                    temp = _snakePosition[i + 1];
                    _snakePosition[i] = _snakePosition[i + 1];
                    i++;
                }
                _snakePosition[0] = [_snakePosition[0][0], _snakePosition[0][1] + snake.Size.Height];
                snake.Location = new Point(_snakePosition[0][0], _snakePosition[0][1]);
            }
            if (_snakeDirection == 4)
            {
                int[] temp;
                int i = 0;
                //_snakePosition[0].ToArray();
                while (i < _snakePosition.Count - 1)
                {
                    temp = _snakePosition[i + 1];
                    _snakePosition[i] = _snakePosition[i + 1];
                    i++;
                }
                _snakePosition[0] = [_snakePosition[0][0] - snake.Size.Height, _snakePosition[0][1]];
                snake.Location = new Point(_snakePosition[0][0], _snakePosition[0][1]);
            }

        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up && _snakeDirection !=3)
            {
                _snakeDirection = 1;
            }
            if (e.KeyCode == Keys.Right && _snakeDirection != 4)
            {
                _snakeDirection = 2;
            }
            if (e.KeyCode == Keys.Down && _snakeDirection != 1)
            {
                _snakeDirection = 3;
            }
            if (e.KeyCode == Keys.Left && _snakeDirection !=2)
            {
                _snakeDirection = 4;
            }
        }
    }
}
