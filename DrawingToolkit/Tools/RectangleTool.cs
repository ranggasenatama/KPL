using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingToolkit.Shapes;
using System.Windows.Forms;

namespace DrawingToolkit.Tools
{
    public class RectangleTool : CreateTool
    {
        private Rectangle rectangle;

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

        public RectangleTool()
        {
            this.Name = "Rectangle Tool";
            this.ToolTipText = "Rectangle Tool";
            this.Image = IconSet.rectangle;
            this.CheckOnClick = true;
        }

        public override void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.rectangle = new Rectangle(e.X, e.Y);
                Create(this.rectangle);
            }
        }

        public override void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int width = e.X - this.rectangle.X;
                int height = e.Y - this.rectangle.Y;

                if (width > 0 && height > 0)
                {
                    this.rectangle.Width = width;
                    this.rectangle.Height = height;
                }
            }
        }

        public override void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (rectangle != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    this.rectangle.Select();
                }
            }
        }

    }
}
