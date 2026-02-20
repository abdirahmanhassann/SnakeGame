using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        private int[] _ballPosition;
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
            myTimer.Interval = 60;
            myTimer.Start();
            _snakePosition.Add([this.ClientSize.Width / 2, this.ClientSize.Height / 2]);
            GenerateBallPosition(_snakePosition[0]);
        }
        private void GameTimer(object sender, EventArgs e)
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
                }
                _snakePosition[0] = [_snakePosition[0][0], _snakePosition[0][1] - 10];
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
                }
                _snakePosition[0] = [_snakePosition[0][0] + 10, _snakePosition[0][1]];
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
                }
                _snakePosition[0] = [_snakePosition[0][0], _snakePosition[0][1]+10];
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
                }
                _snakePosition[0] = [_snakePosition[0][0] - 10, _snakePosition[0][1]];
                snake.Location = new Point(_snakePosition[0][0], _snakePosition[0][1]);
            }
        }

        private int[] GenerateBallPosition(int[] initialSnakePosition)
        {
            bool isBallOnSnake;
            Random rand = new();
            while (true)
            {
                _ballPosition = new int[2];
                _ballPosition[0] = rand.Next(0, this.ClientSize.Width);
                _ballPosition[1] = rand.Next(0, this.ClientSize.Height);
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
                    return _ballPosition;
                }
            }
        }

        private void snake_Click(object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                _snakeDirection = 1;
            }
            if (e.KeyCode == Keys.Right)
            {
                _snakeDirection = 2;
            }
            if (e.KeyCode == Keys.Down)
            {
                _snakeDirection = 3;
            }
            if (e.KeyCode == Keys.Left)
            {
                _snakeDirection = 4;
            }
        }
    }
}
