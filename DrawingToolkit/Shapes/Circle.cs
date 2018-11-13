using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Shapes
{
    public class Circle : DrawingObject
    {
        public int cirX { get; set; }
        public int cirY { get; set; }
        public int cirWidth { get; set; }
        public int cirHeight { get; set; }

        private Pen pen;

        public Circle()
        {
            this.pen = new Pen(Color.Black);
        }

        public Circle(int initX, int initY) : this()
        {
            this.cirX = initX;
            this.cirY = initY;
        }

        public Circle(int initX, int initY, int initWidth, int initHeight) : this(initX, initY)
        {
            this.cirWidth = initWidth;
            this.cirHeight = initHeight;
        }

        public override void Draw()
        {
            this.Graphics.DrawEllipse(pen, cirX, cirY, cirWidth, cirHeight);
        }

        public override bool isSelected(Point mouse)
        {
            if ((mouse.X >= cirX && mouse.X <= cirX + cirWidth) && (mouse.Y >= cirY && mouse.Y <= cirY + cirHeight))
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
            if ((xTest >= cirX && xTest <= cirX + cirWidth) && (yTest >= cirY && yTest <= cirY + cirHeight))
            { 
                return true;
            }
            return false;
        }

        public override void RenderOnStaticView()
        {
            this.pen.Color = Color.Black;
            this.pen.DashStyle = DashStyle.Solid;
            Graphics.DrawRectangle(this.pen, cirX, cirY, cirWidth, cirHeight);
        }
        public override void RenderOnEditingView()
        {
            this.pen.Color = Color.Blue;
            this.pen.DashStyle = DashStyle.Solid;
            Graphics.DrawRectangle(this.pen, cirX, cirY, cirWidth, cirHeight);
        }
        public override void RenderOnPreview()
        {
            this.pen.Color = Color.Red;
            this.pen.DashStyle = DashStyle.DashDot;
            Graphics.DrawRectangle(this.pen, cirX, cirY, cirWidth, cirHeight);
        }

        public override void Translate(int x, int y, int xAmount, int yAmount)
        {
            this.cirX += xAmount;
            this.cirY += yAmount;
        }
    }
}
