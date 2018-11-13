using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingToolkit.Shapes;
using System.Windows.Forms;

namespace DrawingToolkit.Tools
{
    public class CircleTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private Circle circle;

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

        public CircleTool()
        {
            this.Name = "Circle Tool";
            this.ToolTipText = "Circle Tool";
            this.Image = IconSet.circle;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.circle = new Circle(e.X, e.Y);
                this.canvas.AddDrawingObject(this.circle);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int width = e.X - this.circle.cirX;
                int height = e.Y - this.circle.cirY;

                if (width > 0 && height > 0)
                {
                    this.circle.cirWidth = width;
                    this.circle.cirHeight = height;
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (circle != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.circle.Select();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    canvas.RemoveDrawingObject(this.circle);
                }
            }
        }
    }
}
