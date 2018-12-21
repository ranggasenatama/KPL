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
    public class MethodTextTool : AddTextTool
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

        public MethodTextTool()
        {
            this.Name = "Add Method Text Tool";
            this.ToolTipText = "Add Method Text Tool";
            this.Image = IconSet.method;
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
                    string value = PopUpForm("Method Name");
                    classDiagram.AddMethodText(value);
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
