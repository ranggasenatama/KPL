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

        public void AddClassText(string value)
        {
            RectangleWithText rectangleWithText = (listDrawingObjects[0] as RectangleWithText);
            rectangleWithText.AddText(value);
            syncWidthText(value, rectangleWithText);
        }

        public void AddPropertyText(string value)
        {
            RectangleWithText rectangleWithText = (listDrawingObjects[1] as RectangleWithText);
            rectangleWithText.AddText(value);
            syncWidthText(value, rectangleWithText);
            
            UpdateMethodRectangle(rectangleWithText);
        }

        public void AddMethodText(string value)
        {
            RectangleWithText rectangleWithText = (listDrawingObjects[2] as RectangleWithText);
            rectangleWithText.AddText(value);
            syncWidthText(value, rectangleWithText);
        }

        public SizeF getSizeOfTextString(string value)
        {
            FontFamily fontFamily = new FontFamily("Arial");
            Font font = new Font(fontFamily, 16, FontStyle.Regular, GraphicsUnit.Pixel);
            Graphics grfx = Graphics.FromImage(new Bitmap(1, 1));
            SizeF size = grfx.MeasureString(value, font, new PointF(0, 0), new StringFormat(StringFormatFlags.MeasureTrailingSpaces));
            return size;
        }

        public void syncWidthText(string value, RectangleWithText rectangleWithText)
        {
            SizeF size = getSizeOfTextString(value);
            if (rectangleWithText.Width < size.Width)
            {
                updateWidthMembers(size.Width);
            }
            updateClassCenterText();
        }

        public void updateWidthMembers(float width)
        {
            foreach (DrawingObject obj in this.listDrawingObjects)
            {
                (obj as RectangleWithText).Width = (int)width;
            }
        }

        public void updateClassCenterText()
        {
            RectangleWithText rectangleWithText = (listDrawingObjects[0] as RectangleWithText);
            Text text = (rectangleWithText.drawingObjects[0] as Text);
            string value = (rectangleWithText.drawingObjects[0] as Text).Value;
            SizeF size = getSizeOfTextString(value);
            float xText = (rectangleWithText.Width / 2) - (size.Width / 2) + rectangleWithText.X;
            float yText = (rectangleWithText.Height / 2) - (size.Height / 2) + rectangleWithText.Y;
            text.X = (int)xText;
            text.Y = (int)yText;
        }

        public void UpdateMethodRectangle(RectangleWithText rectangleProperty)
        {
            int yMethod = rectangleProperty.Height + rectangleProperty.Y;
            RectangleWithText rectangleWithText = (listDrawingObjects[2] as RectangleWithText);
            rectangleWithText.UpdateYMembers(yMethod);
        }
    }
}
