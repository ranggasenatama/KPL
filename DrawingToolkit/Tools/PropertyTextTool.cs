using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawingToolkit.Shapes;
using DrawingToolkit.Layer;

namespace DrawingToolkit.Tools
{
    public class PropertyTextTool : AddTextTool
    {
        private DrawingObject selectedObject;

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

        public PropertyTextTool()
        {
            this.Name = "Add Property Text Tool";
            this.ToolTipText = "Add Property Text Tool";
            this.Image = IconSet.cursor;
            this.CheckOnClick = true;
        }

        public override void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && canvas != null)
            {
                canvas.DeselectAllObjects();
                selectedObject = canvas.SelectObjectAt(e.X, e.Y);
                if (selectedObject is ClassDiagram)
                {
                    ClassDiagram classDiagram = (selectedObject as ClassDiagram);
                    string value = PopUpForm("Property Name");
                    classDiagram.AddPropertyText(value);
                }
            }
        }

        public override void ToolMouseMove(object sender, MouseEventArgs e)
        {
            
        }

        public override void ToolMouseUp(object sender, MouseEventArgs e)
        {
            
        }
    }
}
