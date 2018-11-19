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
        public List<DrawingObject> drawingObjects { get; private set; } = new List<DrawingObject>();

        public Class(int initX, int initY) : base()
        {
            Rectangle obj1 = new Rectangle(initX, initY);
            drawingObjects.Add(obj1);
            Rectangle obj2 = new Rectangle(initX, initY);
            drawingObjects.Add(obj2);
            Rectangle obj3 = new Rectangle(initX, initY);
            drawingObjects.Add(obj3);
        }

        public override void ChangeState(DrawingState drawingState)
        {
            base.ChangeState(drawingState);
            foreach (DrawingObject obj in this.drawingObjects)
            {
                //obj.Graphics = Graphics;
                obj.ChangeState(drawingState);
                //obj.State.Draw(obj);
            }
        }

        public override void Draw()
        {
            foreach (DrawingObject obj in this.drawingObjects)
            {
                obj.Graphics = Graphics;
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
            foreach (DrawingObject obj in this.drawingObjects)
            {
                obj.Graphics = Graphics;
                obj.State.Draw(obj);
            }
        }
        public override void RenderOnEditingView()
        {
            foreach (DrawingObject obj in this.drawingObjects)
            {
                obj.Graphics = Graphics;
                obj.State.Draw(obj);
            }
        }
        public override void RenderOnPreview()
        {
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
                obj.Translate(x, y, xAmount, yAmount);
            }
        }
    }
}
