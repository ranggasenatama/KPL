using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Shapes
{
    class Class : DrawingObject
    {
        private Pen pen;

        List<DrawingObject> drawingObjects = new List<DrawingObject>();

        public Class()
        {
            this.pen = new Pen(Color.Black);
            Rectangle obj1 = new Rectangle(10, 10);
            drawingObjects.Add(obj1);
            Rectangle obj2 = new Rectangle(20, 20);
            drawingObjects.Add(obj2);
        }

        public override void Draw()
        {
            foreach (DrawingObject obj in this.drawingObjects)
            {
                obj.State.Draw(obj);
            }
        }

        public override bool isSelected(Point mouse)
        {
            foreach (DrawingObject obj in this.drawingObjects)
            {
                if (obj.isSelected(mouse))
                {
                    return true;
                }
            }
            return false;
        }

        public override void isNotSelected()
        {
            pen.Color = Color.FromArgb(255, 0, 0, 0);
        }

        public override bool Intersect(int xTest, int yTest)
        {
            foreach (DrawingObject obj in this.drawingObjects)
            {
                if (obj.Intersect(xTest, yTest))
                {
                    return true;
                }
            }
            return false;
        }

        public override void RenderOnStaticView()
        {
            this.pen.Color = Color.Black;
            this.pen.DashStyle = DashStyle.Solid;
            foreach (DrawingObject obj in this.drawingObjects)
            {
                obj.State.Draw(obj);
            }
        }
        public override void RenderOnEditingView()
        {
            this.pen.Color = Color.Blue;
            this.pen.DashStyle = DashStyle.Solid;
            foreach (DrawingObject obj in this.drawingObjects)
            {
                obj.State.Draw(obj);
            }
        }
        public override void RenderOnPreview()
        {
            this.pen.Color = Color.Red;
            this.pen.DashStyle = DashStyle.DashDot;
            foreach (DrawingObject obj in this.drawingObjects)
            {
                obj.State.Draw(obj);
            }
        }

        public override void Translate(int x, int y, int xAmount, int yAmount)
        {
            foreach (DrawingObject obj in this.drawingObjects)
            {
                obj.Translate(x, y, xAmount, yAmount);
            }
        }
    }
}
