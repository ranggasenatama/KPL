using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Shapes
{
    class Rectangle : DrawingObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Action Observable { get; set; }

        private Pen pen;

        public Rectangle() : base()
        {
            this.pen = new Pen(Color.Black);
        }

        public Rectangle(int initX, int initY) : this()
        {
            this.X = initX;
            this.Y = initY;
        }

        public Rectangle(int initX, int initY, int initWidth, int initHeight) : this(initX, initY)
        {
            this.Width = initWidth;
            this.Height = initHeight;
        }

        public override bool isSelected(Point mouse)
        {
            if ((mouse.X >= X && mouse.X <= X + Width) && (mouse.Y >= Y && mouse.Y <= Y + Height))
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
            if ((xTest >= X && xTest <= X + Width) && (yTest >= Y && yTest <= Y + Height))
            {
                return true;
            }
            return false;
        }

        public override void RenderOnStaticView()
        {
            this.pen.Color = Color.Black;
            this.pen.DashStyle = DashStyle.Solid;
            Graphics.DrawRectangle(this.pen, X, Y, Width, Height);
        }
        public override void RenderOnEditingView()
        {
            this.pen.Color = Color.Blue;
            this.pen.DashStyle = DashStyle.Solid;
            Graphics.DrawRectangle(this.pen, X, Y, Width, Height);
        }
        public override void RenderOnPreview()
        {
            this.pen.Color = Color.Red;
            this.pen.DashStyle = DashStyle.DashDot;
            Graphics.DrawRectangle(this.pen, X, Y, Width, Height);
        }

        public override void Translate(int xAmount, int yAmount)
        {
            this.X += xAmount;
            this.Y += yAmount;
        }
    }
}
