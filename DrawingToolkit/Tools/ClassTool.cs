using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingToolkit.Shapes;
using System.Windows.Forms;

namespace DrawingToolkit.Tools
{
    public class ClassTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private Class classs;

        public Cursor Cursor
        {
            get
            {
                return Cursors.Arrow;
            }
        }

        public ICanvas TargetCanvas
        {
            get
            {
                return this.canvas;
            }
            set
            {
                this.canvas = value;
            }
        }

        public ClassTool()
        {
            this.Name = "Rectangle Tool";
            this.ToolTipText = "Rectangle Tool";
            this.Image = IconSet.rectangle;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.classs = new Class(e.X, e.Y);
                System.Console.WriteLine(this.classs.State);
                this.canvas.AddDrawingObject(this.classs);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Rectangle rectangle1 = (this.classs.drawingObjects[0] as Rectangle);
                Rectangle rectangle2 = (this.classs.drawingObjects[1] as Rectangle);
                Rectangle rectangle3 = (this.classs.drawingObjects[2] as Rectangle);
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

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (classs != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.classs.Select();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    canvas.RemoveDrawingObject(this.classs);
                }
            }
        }
    }
}
