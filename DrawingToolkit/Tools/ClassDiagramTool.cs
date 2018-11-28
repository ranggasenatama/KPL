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
                Rectangle rectangle1 = (this.classDiagram.drawingObjects[0] as Rectangle);
                Rectangle rectangle2 = (this.classDiagram.drawingObjects[1] as Rectangle);
                Rectangle rectangle3 = (this.classDiagram.drawingObjects[2] as Rectangle);
                int width = e.X - rectangle1.X;
                int height = e.Y - rectangle1.Y;
                height /= 3;

                if (width > 0 && height > 0)
                {
                    rectangle1.Width = width;
                    rectangle1.Height = height;
                    rectangle2.Width = width;
                    rectangle2.Height = height;
                    rectangle2.Y = rectangle1.Y + rectangle1.Height;
                    rectangle3.Width = width;
                    rectangle3.Height = height;
                    rectangle3.Y = rectangle2.Y + rectangle1.Height;
                }
            }
        }

        public override void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (classDiagram != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.classDiagram.Select();
                }
            }
        }
    }
}
