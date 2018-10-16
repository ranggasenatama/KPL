using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Drawing_App_Fast
{
    public partial class Form1 : Form
    {
        public struct Coordinate
        {
            public Point start, end;
        }

        Graphics g;
        int x = -1;
        int y = -1;
        String mode = "line";
        bool moving = false;
        Pen pen;
        
        List<Coordinate> drawLines = new List<Coordinate>();
        List<Coordinate> drawCircles = new List<Coordinate>();

        private void init()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen = new Pen(Color.Black, 5);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
        }

        public Form1()
        {
            init();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            mode = p.AccessibleName;
        }

        private void startDraw(int initialX, int initialY)
        {
            moving = true;
            x = initialX;
            y = initialY;
            panel1.Cursor = Cursors.Cross;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            startDraw(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (moving && x != -1 && y != -1)
            {
                dispayListDraw();
                refreshScreen();
                if (mode == "line")
                {   
                    drawLine(e);
                }
                else if(mode == "circle")
                {
                    drawCircle(e);
                }
            }
        }

        private void refreshScreen()
        {
            this.Refresh();
        }

        private void drawLine(MouseEventArgs e)
        {
            g.DrawLine(pen, new Point(x, y), e.Location);
        }

        private Rectangle currentRectangle(int currentX, int currentY, int initialX, int initialY)
        {
            return new Rectangle(Math.Min(currentX, initialX), Math.Min(currentY, initialY),
                                            Math.Abs(currentX - initialX), Math.Abs(currentY - initialY));
        }

        private void drawCircle(MouseEventArgs e)
        {
            Rectangle rect = currentRectangle(e.X, e.Y, x, y);

            g.DrawEllipse(pen, rect);
        }

        private void defaultForm()
        {
            moving = false;
            x = -1;
            y = -1;
            panel1.Cursor = Cursors.Default;
        }

        private void persistCoor(MouseEventArgs e)
        {
            Coordinate coor = new Coordinate();
            coor.start = new Point(x, y);
            coor.end = new Point(e.X, e.Y);
            if (mode == "line")
            {
                drawLines.Add(coor);
            }
            else if (mode == "circle")
            {
                drawCircles.Add(coor);
            }
        }

        private void dispayListDraw()
        {
            foreach (Coordinate line in drawLines)
            {
                g.DrawLine(pen, line.start, line.end);
            }
            foreach (Coordinate circ in drawCircles)
            {
                g.DrawEllipse(pen, currentRectangle(circ.end.X, circ.end.Y, circ.start.X, circ.start.Y));
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            persistCoor(e);
            dispayListDraw();
            defaultForm();
        }
    }
}
