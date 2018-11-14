using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DrawingToolkit.Shapes
{
    public class Connector: DrawingObject
    {
        private const double EPSILON = 3.0;

        public Point startPoint { get; set; }
        public Point finishPoint { get; set; }

        private DrawingObject start;
        private DrawingObject end;

        private Pen pen;

        public Connector()
        {
            this.pen = new Pen(Color.Black);
        }

        public Connector(Point initX) : this()
        {
            this.startPoint = initX;
        }

        public Connector(Point initX, Point initY) : this(initX)
        {
            this.finishPoint = initY;
        }

        public void initStartAndEndObject(DrawingObject start, DrawingObject end)
        {
            this.start = start;
            this.end = end;
            //start.Observable += Update;
            //end.Observable += Update;
            Debug.WriteLine("init "+start);
            Debug.WriteLine("init "+end);
            Update();
        }

        public void Update()
        {
            Debug.WriteLine(start);
            Debug.WriteLine(end);
            if (start == null || end == null)
            {
                Debug.WriteLine("null");
                return;
            }
            //startPoint = start.GetPoint;
            //finishPoint = end.GetPoint;
        }

        public override void Draw()
        {
            this.Graphics.DrawLine(this.pen, startPoint, finishPoint);
        }

        public override bool isSelected(Point mouse)
        {
            double m = (double)(finishPoint.Y - startPoint.Y) / (double)(finishPoint.X - startPoint.X);
            double b = finishPoint.Y - m * finishPoint.X;
            double y_point = m * mouse.X + b;

            if (Math.Abs(mouse.Y - y_point) < EPSILON)
            {
                pen.Color = Color.FromArgb(255, 255, 0, 0);
                return true;
            }
            return false;
        }

        public override void isNotSelected()
        {
            pen.Color = Color.FromArgb(255, 0, 0, 0);
        }

        public override bool Intersect(int xTest, int yTest)
        {
            double m = GetSlope();
            double b = finishPoint.Y - m * finishPoint.X;
            double y_point = m * xTest + b;
            if (Math.Abs(yTest - y_point) < EPSILON)
            {
                return true;
            }
            return false;
        }

        private double GetSlope()
        {
            double m = (double)(finishPoint.Y - startPoint.Y) / (double)(finishPoint.X - startPoint.X);
            return m;
        }

        public override void RenderOnStaticView()
        {
            pen.Color = Color.Black;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;
            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawLine(pen, this.startPoint, this.finishPoint);
            }
        }
        public override void RenderOnEditingView()
        {
            pen.Color = Color.Blue;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.Solid;
            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawLine(pen, this.startPoint, this.finishPoint);
            }
        }
        public override void RenderOnPreview()
        {
            pen.Color = Color.Red;
            pen.Width = 1.5f;
            pen.DashStyle = DashStyle.DashDotDot;
            if (this.Graphics != null)
            {
                this.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                this.Graphics.DrawLine(pen, this.startPoint, this.finishPoint);
            }
        }

        public override void Translate(int x, int y, int xAmount, int yAmount)
        {
            this.startPoint = new Point(this.startPoint.X + xAmount, this.startPoint.Y + yAmount);
            this.finishPoint = new Point(this.finishPoint.X + xAmount, this.finishPoint.Y + yAmount);
        }
    }
}
