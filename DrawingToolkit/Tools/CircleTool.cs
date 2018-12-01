using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingToolkit.Shapes;
using System.Windows.Forms;
using DrawingToolkit.Command;

namespace DrawingToolkit.Tools
{
    public class CircleTool : CreateTool
    {
        private Circle circle;

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

        public CircleTool()
        {
            this.name = "Circle Tool";
            this.ToolTipText = "Circle Tool";
            this.Image = IconSet.circle;
            this.CheckOnClick = true;
        }

        public override void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.circle = new Circle(e.X, e.Y);
                Create(this.circle);
            }
        }

        public override void ToolMouseMove(object sender, MouseEventArgs e)
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

        public override void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (circle != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.circle.Select();
                }
            }
        }
    }
}
