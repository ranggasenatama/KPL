using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Shapes
{
    public class RectangleWithText : DrawingObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        private Pen pen;

        public List<DrawingObject> drawingObjects { get; private set; } = new List<DrawingObject>();

        public RectangleWithText() : base()
        {
            this.pen = new Pen(Color.Black);
        }

        public RectangleWithText(int initX, int initY, String value) : this()
        {
            this.X = initX;
            this.Y = initY;
            Text text = new Text(initX, initY, value);
            Add(text);
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

        public override void ChangeState(DrawingState drawingState)
        {
            base.ChangeState(drawingState);
            foreach (DrawingObject obj in this.drawingObjects)
            {
                obj.ChangeState(drawingState);
            }
        }

        public void Add(DrawingObject obj)
        {
            drawingObjects.Add(obj);
        }

        public void AddHeight()
        {
            this.Height += this.Height / drawingObjects.Count;
        }

        public void UpdateY(int Y)
        {
            this.Y = Y;
            int prevYText = this.Y;
            foreach (DrawingObject obj in this.drawingObjects)
            {
                Text text = obj as Text;
                text.Y = prevYText;
                prevYText = text.Y;
            }
        }

        public void Remove(DrawingObject obj)
        {
            drawingObjects.Remove(obj);
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
            foreach (DrawingObject obj in this.drawingObjects)
            {
                obj.Graphics = Graphics;
                obj.State.Draw(obj);
            }
        }
        public override void RenderOnEditingView()
        {
            this.pen.Color = Color.Blue;
            this.pen.DashStyle = DashStyle.Solid;
            Graphics.DrawRectangle(this.pen, X, Y, Width, Height);
            foreach (DrawingObject obj in this.drawingObjects)
            {
                obj.Graphics = Graphics;
                obj.State.Draw(obj);
            }
        }
        public override void RenderOnPreview()
        {
            this.pen.Color = Color.Red;
            this.pen.DashStyle = DashStyle.DashDot;
            Graphics.DrawRectangle(this.pen, X, Y, Width, Height);
            foreach (DrawingObject obj in this.drawingObjects)
            {
                obj.Graphics = Graphics;
                obj.State.Draw(obj);
            }
        }

        public override void Translate(int xAmount, int yAmount)
        {
            foreach (DrawingObject obj in this.drawingObjects)
            {
                obj.Translate(xAmount, yAmount);
            }
            this.X += xAmount;
            this.Y += yAmount;
            this.centerPoint = drawingObjects[0].centerPoint;
            notify();
        }
    }
}
