using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingToolkit.Shapes
{
    class ClassDiagram : DrawingObject
    {
        public List<DrawingObject> listDrawingObjects { get; private set; } = new List<DrawingObject>();

        public ClassDiagram(int initX, int initY) : base()
        {
            RectangleWithText obj1 = new RectangleWithText(initX, initY);
            listDrawingObjects.Add(obj1);
            RectangleWithText obj2 = new RectangleWithText(initX, initY);
            listDrawingObjects.Add(obj2);
            RectangleWithText obj3 = new RectangleWithText(initX, initY);
            listDrawingObjects.Add(obj3);
        }

        public void AddClassText(string value)
        {
            RectangleWithText rectangleWithText = (listDrawingObjects[0] as RectangleWithText);
            rectangleWithText.AddText(value);
        }

        public void AddPropertyText(string value)
        {
            RectangleWithText rectangleWithText = (listDrawingObjects[1] as RectangleWithText);
            rectangleWithText.AddText(value);
        }

        public void AddMethodText(string value)
        {
            RectangleWithText rectangleWithText = (listDrawingObjects[2] as RectangleWithText);
            rectangleWithText.AddText(value);
        }

        public override void ChangeState(DrawingState drawingState)
        {
            base.ChangeState(drawingState);
            foreach (DrawingObject obj in this.listDrawingObjects)
            {
                obj.ChangeState(drawingState);
            }
        }

        public override void Draw()
        {
            foreach (DrawingObject obj in this.listDrawingObjects)
            {
                obj.Graphics = Graphics;
                obj.State.Draw(obj);
            }
        }

        public override bool isSelected(Point mouse)
        {
            foreach (DrawingObject obj in this.listDrawingObjects)
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
            foreach (DrawingObject obj in this.listDrawingObjects)
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
            foreach (DrawingObject obj in this.listDrawingObjects)
            {
                obj.Graphics = Graphics;
                obj.State.Draw(obj);
            }
        }
        public override void RenderOnEditingView()
        {
            foreach (DrawingObject obj in this.listDrawingObjects)
            {
                obj.Graphics = Graphics;
                obj.State.Draw(obj);
            }
        }
        public override void RenderOnPreview()
        {
            foreach (DrawingObject obj in this.listDrawingObjects)
            {
                obj.Graphics = Graphics;
                obj.State.Draw(obj);
            }
        }

        public override void Translate(int xAmount, int yAmount)
        {
            foreach (DrawingObject obj in this.listDrawingObjects)
            {
                obj.Translate(xAmount, yAmount);
            }
            this.centerPoint = listDrawingObjects[1].centerPoint;
            notify();
        }
    }
}
