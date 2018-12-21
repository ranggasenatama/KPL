using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingToolkit.Shapes;
using System.Windows.Forms;
using System.Diagnostics;

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
            this.Image = IconSet.classdiagram;
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
                RectangleWithText rectangle2 = (this.classDiagram.listDrawingObjects[1] as RectangleWithText);
                RectangleWithText rectangle3 = (this.classDiagram.listDrawingObjects[2] as RectangleWithText);
                
                int width = e.X - rectangle1.X;
                int height = e.Y - rectangle1.Y;
                height /= 3;

                if (width > 0 && height > 0)
                {
                    //1
                    rectangle1.Width = width;
                    rectangle1.Height = height * 2;
                    
                    //2
                    rectangle2.Width = width;
                    rectangle2.Height = height / 2;
                    rectangle2.Y = rectangle1.Y + rectangle1.Height;
                    
                    //3
                    rectangle3.Width = width;
                    rectangle3.Height = height / 2;
                    rectangle3.Y = rectangle2.Y + rectangle2.Height;
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
                    string passingText = "class name";
                    using (TextBoxWindow textBoxWindow = new TextBoxWindow(passingText))
                    {
                        if (textBoxWindow.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            textBoxWindow.ShowDialog();
                        }
                        string formValue = textBoxWindow.value;
                        this.classDiagram.AddClassText(formValue);
                    }
                    this.classDiagram.Select();
                }
            }
        }
    }
}
