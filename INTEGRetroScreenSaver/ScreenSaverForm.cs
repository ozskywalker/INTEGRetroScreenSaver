using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace INTEGRetroScreenSaver
{
    public partial class ScreenSaverForm : Form
    {
        //private Point mouseLocation;
        //private Random rand = new Random();
        //private bool PreviewMode;
        private Screen screen;
        private Graphics drawingPad;
        private PlayGround sandpit;
        private Point mouseLocation;
        private UserPreferences settings;
        
        public ScreenSaverForm(Screen screen)
        {
            InitializeComponent();

            // need to keep a reference
            this.screen = screen;

            // load in user preferences
            this.settings = new UserPreferences();
            settings.GetRegistrySettings();

            // lets cover the screeeeeeeeeeeeeeeeeeen...
            this.StartPosition = FormStartPosition.Manual;
            this.Left = screen.Bounds.Left;
            this.Top = screen.Bounds.Top;
            this.Width = screen.Bounds.Width;
            this.Height = screen.Bounds.Height;

            // start the show, give us our playground
            sandpit = new PlayGround(this.CreateGraphics(), this.settings);
        }

        private void ScreenSaverForm_Load(object sender, EventArgs e)
        {
            Cursor.Hide();
#if !DEBUG
            TopMost = true;
#endif
            sandpit.drawMap();

            moveTimer.Interval = this.settings.nMoveInterval;
            moveTimer.Tick += new EventHandler(moveTimer_Tick);
            moveTimer.Start();
        }

        private void drawText(string message, float x=0, float y=0)
        {
            // obtain reference to the graphics object and let's.. abuse its surface..
            drawingPad = this.CreateGraphics();
            Font drawFont = new Font("Consolas", 10);
            SolidBrush drawBrush = new SolidBrush(Color.White);
            PointF drawPoint = new PointF(x, y);

            drawingPad.DrawString(message, drawFont, drawBrush, drawPoint);
        }

        private void moveTimer_Tick(object sender, System.EventArgs e)
        {
            sandpit.moveTrolls();
            sandpit.drawMap();
        }

        private void ScreenSaverForm_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void ScreenSaverForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            Application.Exit();
        }

        private void ScreenSaverForm_MouseMove(object sender, MouseEventArgs e)
        {
            mouseLocation = e.Location;
            
            if (!mouseLocation.IsEmpty)
            {
                if (Math.Abs(mouseLocation.X - e.X) > 5 || Math.Abs(mouseLocation.Y - e.Y) > 5)
                    Application.Exit();
            }
        }
    }

    public static class RandomProvider
    {
        private static int seed = Environment.TickCount;

        private static ThreadLocal<Random> randomWrapper = new ThreadLocal<Random>(() =>
            new Random(Interlocked.Increment(ref seed))
        );

        public static Random GetThreadRandom()
        {
            return randomWrapper.Value;
        }
    }

    public class Letter
    {
        public string chr;
        public Color color;
        public int x, y;
        public int oldx, oldy;

        public Letter(string chr, Color color, int x = 0, int y = 3)
        {
            this.chr = chr;
            this.color = color;
            this.x = x;
            this.y = y;
            this.oldx = x;
            this.oldy = y;
        }
    }

    public class Troll
    {
        /*
         * Welcome to the Troll Class .. reponsible for holding each
         * Letter instance as well as directional control
         * 
         * Eventually this class should be extended to allow for Troll
         * 'personalities' in which different movement and direction
         * can be accounted for, amongst other crazy behaviours
         * 
         * All co-ords assume playground co-ords
         * 
         */

        public Letter[] body;
        public enum MoveDir { Up=1, Down, Left, Right };
        public MoveDir currentDirection, oldDirection, startDirection;
        public string Name;
        public Color first, second, third;
        public int startX, startY;
        private int steps = 0;
        private int stepsmax;

        private static Random _r = RandomProvider.GetThreadRandom();

        public Troll(string newname, int startposX, int startposY, MoveDir startdir, int MaxSteps, params object[] argsRest)
        {
            int cpos = 0; // color position
            body = new Letter[newname.Length];

            // create randomisation
            _r = new Random(DateTime.Now.Hour + DateTime.Now.Minute
                + DateTime.Now.Second + DateTime.Now.Millisecond);

            // check for randomisation requests
            if (startposX == 0)
            {
                startposX = (int)_r.Next(1, 60);
            }

            _r = new Random(DateTime.Now.Hour + DateTime.Now.Minute
                + (DateTime.Now.Second * DateTime.Now.Millisecond));

            if (startposY == 0)
            {
                startposY = (int)_r.Next(1, 60);
            }
            
            // record details for UserPreferences later
            this.Name = newname;
            this.startX = startposX;
            this.startY = startposY;
            this.startDirection = startdir;

            // Passing the settings down to us...
            stepsmax = MaxSteps;

            // set initial direction
            if (startdir == 0)
            {
                currentDirection = RandomDirection();
            }
            else
            {
                currentDirection = startdir;
            }

            // save colours (up to 3)
            first = (System.Drawing.Color)argsRest[0];
            second = (System.Drawing.Color)argsRest[1];
            third = (System.Drawing.Color)argsRest[2];

            // setup letters + colours for the troll
            for (int x = 0; x < Name.Length; x++)
            {              
                body[x] = new Letter(
                    Name[x].ToString(),
                    (System.Drawing.Color)argsRest[cpos],
                    startposX,
                    startposY + x);

                if (cpos == argsRest.Length - 1)
                {
                    cpos = 0;
                }
                else
                {
                    cpos++;
                }
            }

            oldDirection = currentDirection;

            // set text to match direction
            switch (currentDirection)
            {
                case MoveDir.Right:
                case MoveDir.Down:
                    SwapTextDirection();
                    break;
            }
        }

        public MoveDir RandomDirection()
        {
            return (MoveDir)_r.Next((int)MoveDir.Up, (int)MoveDir.Right);
        }

        private void SwapTextDirection()
        {
            char[] tmpArray = new char[body.GetLength(0)];
            for (int i = 0; i < body.GetLength(0); i++)
                tmpArray[i] = Convert.ToChar(body[i].chr);

            Array.Reverse(tmpArray);

            for (int i = 0; i < body.GetLength(0); i++)
                body[i].chr = tmpArray[i].ToString();
        }

        // TODO: MoveOneStep(): Reintroduce eating-the-tail bug
        public void MoveOneStep(int BoundaryX, int BoundaryY)
        {
            // MoveOneStep() - Movement behaviour is to mimic INTEG's screen saver handling
            steps++;
            
            if (steps == stepsmax)
            {
                oldDirection = currentDirection;
                currentDirection = RandomDirection();
                steps = 0;

                // Make also we wrap the text so it's facing the "right way" on dir change
#region change direction
                switch (currentDirection)
                {
                    case MoveDir.Up:
                        if ((oldDirection == MoveDir.Down) || (oldDirection == MoveDir.Right))
                            SwapTextDirection();
                        break;

                    case MoveDir.Down:
                        if ((oldDirection == MoveDir.Left) || (oldDirection == MoveDir.Up))
                            SwapTextDirection();
                        break;

                    case MoveDir.Left:
                        if ((oldDirection == MoveDir.Right) || (oldDirection == MoveDir.Down))
                            SwapTextDirection();
                        break;

                    case MoveDir.Right:
                        if ((oldDirection == MoveDir.Left) || (oldDirection == MoveDir.Up))
                            SwapTextDirection();
                        break;
                }
            }
#endregion

            // Do we need to wrap around the screen?  Focus on mobing the head of the troll first
#region check for direction switch
            switch (currentDirection)
            {
                case MoveDir.Up:
                    body[0].oldy = body[0].y;
                    if (body[0].y == 0)
                    {
                        body[0].y = BoundaryY;
                        
                    }
                    else
                    {
                        body[0].y--;
                    }
                    break;

                case MoveDir.Down:
                    body[0].oldy = body[0].y;
                    if (body[0].y == BoundaryY)
                    {
                        body[0].y = 0;
                    }
                    else
                    {
                        body[0].y++;
                    }
                    break;

                case MoveDir.Left:
                    body[0].oldx = body[0].x;
                    if (body[0].x == 0)
                    {
                        body[0].x = BoundaryX;
                    }
                    else
                    {
                        body[0].x--;
                    }
                    break;

                case MoveDir.Right:
                    body[0].oldx = body[0].x;
                    if (body[0].x == BoundaryX)
                    {
                        body[0].x = 0;
                    }
                    else
                    {
                        body[0].x++;
                    }
                    break;
            }
#endregion

            // now we get to move the rest of the troll
#region move rest of the troll
            for (int n = 1; n < body.GetUpperBound(0)+1; n++)
            {
                body[n].oldx = body[n].x;
                body[n].oldy = body[n].y;

                // Need to compensate for shift on Y/X-axis so tail chases behind it
                if (n == 1)
                {
                    if ((currentDirection == MoveDir.Up) || (currentDirection == MoveDir.Down))
                    {
                        body[n].x = body[n - 1].x;
                        body[n].y = body[n - 1].oldy;
                    }

                    if ((currentDirection == MoveDir.Left) || (currentDirection == MoveDir.Right))
                    {
                        body[n].x = body[n - 1].oldx;
                        body[n].y = body[n - 1].y;
                    }
                }
                else 
                {
                    body[n].x = body[n - 1].oldx;
                    body[n].y = body[n - 1].oldy;
                }
            }
#endregion
        }
    }

    public class PlayGround
    {
        /*  
         * Class is responsible for handling the overall playground including
         * collection of Troll instances, co-ord-to-PointF(x,y) mapping
         * 
         * As an example... 1920x1200 res should give us a 192x120 grid (23,040 squares)
         * 
         * NOTE:  Old method has been discarded, where in we were using a 2D array to
         *  map all objects on the map.  Instead, since nothing else is on the map,
         *  it's quicker to track co-ords via Letter instances within each Troll instance
         *  
         *  Just in case I've commented and left the old method in..
         *  
         */

        public Troll[] trolls;
        public int BoundaryX, BoundaryY;    // playground boundary
        private Graphics drawingPad;
        private Font chrFont = new Font("Consolas", 10);

        public PlayGround(Graphics g, UserPreferences settings)
        {
            drawingPad = g;
            BoundaryX = (int)(drawingPad.VisibleClipBounds.X + drawingPad.VisibleClipBounds.Width) / 10;
            BoundaryY = (int)(drawingPad.VisibleClipBounds.Y + drawingPad.VisibleClipBounds.Height) / 10;

            trolls = settings.trolls;
        }

        static public string EncodeTo64(string toEncode)
        {
            return System.Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(toEncode));
        }

        static public string DecodeFrom64(string encodedData)
        {
            return System.Text.ASCIIEncoding.ASCII.GetString(System.Convert.FromBase64String(encodedData));
        }

        public int realCoord(int coord)
        {
            return coord * 10;
        }

        public void moveTrolls()
        {
            foreach (Troll troll in trolls)
            {
                troll.MoveOneStep(BoundaryX, BoundaryY);
            }
        }

        public void drawDebugNotes()
        {
            drawingPad.DrawString(
                "BoundaryX = " + BoundaryX.ToString(),
                chrFont,
                new SolidBrush(Color.White),
                new PointF(0, 0)
                );

            drawingPad.DrawString(
                "BoundaryY = " + BoundaryY.ToString(),
                chrFont,
                new SolidBrush(Color.White),
                new PointF(0, 10)
                );

            drawingPad.DrawString(
                "Troll1 (X,Y) = " + trolls[0].startX.ToString() + "," + trolls[0].startY.ToString(),
                chrFont,
                new SolidBrush(Color.White),
                new PointF(0, 20)
                );

            drawingPad.DrawString(
                "Troll2 (X,Y) = " + trolls[1].startX.ToString() + "," + trolls[1].startY.ToString(),
                chrFont,
                new SolidBrush(Color.White),
                new PointF(0, 30)
                );
        }

        public void drawMap()
        {
            drawingPad.Clear(Color.Black);
#if DEBUG
            drawDebugNotes();
#endif
            foreach (Troll troll in trolls)
                for (int t = 0; t <= troll.body.GetUpperBound(0); t++)
                    drawingPad.DrawString(
                        troll.body[t].chr,
                        chrFont,
                        new SolidBrush(troll.body[t].color),
                        new PointF(realCoord(troll.body[t].x), realCoord(troll.body[t].y)));
        }
    }
}
