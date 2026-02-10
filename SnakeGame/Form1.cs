using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        private int[] _ballPosition;
        private List<int[]> _snakePosition = new List<int[]>();
        static System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //myTimer.Tick += new EventHandler(GameTimer);

            //myTimer.Interval = 60;
            //myTimer.Start();
            Random randomSnakePositionX = new();
            Random randomSnakePositionY = new();
            int[] arrayOfInts = new int[2];
            arrayOfInts[0] = randomSnakePositionX.Next(0, this.ClientSize.Width);
            arrayOfInts[1] = randomSnakePositionY.Next(0, this.ClientSize.Height);
            _snakePosition.Add(arrayOfInts);
            GenerateBallPosition(arrayOfInts);
        }
        private void GameTimer()
        {

        }
        private int[] GenerateBallPosition(int[] initialSnakePosition)
        {
            bool isBallOnSnake;
            var rand = new Random();
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
                    // set the PictureBox here or in the caller
                    pictureBox1.Location = new Point(_ballPosition[0], _ballPosition[1]);
                    return _ballPosition;
                }
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
