using Microsoft.VisualBasic.Logging;
using System.Timers;
using System.Windows.Forms;

namespace SnakeGame
{
    public partial class Form1 : Form
    {
        public enum Directions { north = Keys.Up, east = Keys.Right, south = Keys.Down, west = Keys.Left }
        public Directions _snakeDirection = Directions.north;
        static System.Windows.Forms.Timer _myTimer = new System.Windows.Forms.Timer();
        //public int _

        private void Form1_Load(object sender, EventArgs e)
        {
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

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}