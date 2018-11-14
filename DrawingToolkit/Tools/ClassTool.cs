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
                this.classs = new Class();
                this.canvas.AddDrawingObject(obj2);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                
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
