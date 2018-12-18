using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingToolkit.Shapes;
using System.Windows.Forms;

namespace DrawingToolkit.Tools
{
    public class ClassDiagramTool : CreateTool
    {
        private ClassDiagram classDiagram;

        public override String Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }

        public ClassDiagramTool()
        {
            this.Name = "Class Diagram Tool";
            this.ToolTipText = "Class Diagram Tool";
            this.Image = IconSet.rectangle;
            this.CheckOnClick = true;
        }

        public override void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.classDiagram = new ClassDiagram(e.X, e.Y);
                Create(this.classDiagram);
            }
        }

        public override void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                RectangleWithText rectangle1 = (this.classDiagram.listDrawingObjects[0] as RectangleWithText);
                Text text1 = (rectangle1.drawingObjects[0] as Text);
                RectangleWithText rectangle2 = (this.classDiagram.listDrawingObjects[1] as RectangleWithText);
                Text text2 = (rectangle2.drawingObjects[0] as Text);
                RectangleWithText rectangle3 = (this.classDiagram.listDrawingObjects[2] as RectangleWithText);
                Text text3 = (rectangle3.drawingObjects[0] as Text);
                int width = e.X - rectangle1.X;
                int height = e.Y - rectangle1.Y;
                height /= 3;

                if (width > 0 && height > 0)
                {
                    //1
                    rectangle1.Width = width;
                    rectangle1.Height = height;
                    text1.X = rectangle1.X + (width/3);
                    text1.Y = rectangle1.Y + (height/3);

                    //2
                    rectangle2.Width = width;
                    rectangle2.Height = height;
                    rectangle2.Y = rectangle1.Y + rectangle1.Height;
                    text2.Y = rectangle2.Y + (height / 3);

                    //3
                    rectangle3.Width = width;
                    rectangle3.Height = height;
                    rectangle3.Y = rectangle2.Y + rectangle1.Height;
                    text3.Y = rectangle3.Y + (height / 3);
                }
            }
        }

        public override void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (classDiagram != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    DrawingObject obj = canvas.GetObjectAt(e.X, e.Y);
                    string passingText = "halo";
                    using (TextBoxWindow textBoxWindow = new TextBoxWindow(passingText, obj, canvas))
                    {
                        if (textBoxWindow.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            textBoxWindow.ShowDialog();
                        }
                    }
                    this.classDiagram.Select();
                }
            }
        }
    }
}
