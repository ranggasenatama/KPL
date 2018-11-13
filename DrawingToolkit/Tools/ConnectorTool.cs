using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingToolkit.Shapes;
using System.Windows.Forms;

namespace DrawingToolkit.Tools
{
    public class ConnectorTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private Connector connector;
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

        public ConnectorTool()
        {
            this.Name = "Connector Tool";
            this.ToolTipText = "Connector Tool";
            this.Image = IconSet.connector;
            this.CheckOnClick = true;
        }

        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            connector = new Connector(new System.Drawing.Point(e.X, e.Y));
            connector.finishPoint = new System.Drawing.Point(e.X, e.Y);
            canvas.AddDrawingObject(connector);
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.connector != null)
                {
                    connector.finishPoint = new System.Drawing.Point(e.X, e.Y);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (this.connector != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    connector.finishPoint = new System.Drawing.Point(e.X, e.Y);
                    connector.Select();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    canvas.RemoveDrawingObject(this.connector);
                }
            }
        }
    }
}
