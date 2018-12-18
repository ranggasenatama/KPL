using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingToolkit.Shapes;
using System.Windows.Forms;
using System.Diagnostics;
using DrawingToolkit.Command;
using DrawingToolkit.Layer;

namespace DrawingToolkit.Tools
{
    public class ConnectorTool : ConnectTool
    {
        private Connector connector;


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

        public ConnectorTool()
        {
            this.Name = "Connector Tool";
            this.ToolTipText = "Connector Tool";
            this.Image = IconSet.connector;
            this.CheckOnClick = true;
        }

        public override void ToolMouseDown(object sender, MouseEventArgs e)
        {
            connector = new Connector(new System.Drawing.Point(e.X, e.Y));
            connector.finishPoint = new System.Drawing.Point(e.X, e.Y);
            canvas.AddDrawingObjectInZeroIndex(this.connector);
        }

        public override void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (this.connector != null)
                {
                    connector.finishPoint = new System.Drawing.Point(e.X, e.Y);
                }
            }
        }

        public override void ToolMouseUp(object sender, MouseEventArgs e)
        {
            if (this.connector != null)
            {
                if (e.Button == MouseButtons.Left)
                {
                    canvas.RemoveDrawingObject(this.connector);
                    connector.finishPoint = new System.Drawing.Point(e.X, e.Y);
                    DrawingObject startObject = canvas.GetObjectAt(connector.startPoint.X, connector.startPoint.Y);
                    DrawingObject endObject = canvas.GetObjectAt(connector.finishPoint.X, connector.finishPoint.Y);
                    connector.initStartAndEndObject(startObject, endObject);
                    connector.Select();
                    Create(this.connector);
                }
            }
        }
    }
}
