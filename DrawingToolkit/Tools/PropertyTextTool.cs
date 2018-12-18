using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawingToolkit.Shapes;

namespace DrawingToolkit.Tools
{
    public class PropertyTextTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private DrawingObject selectedObject;

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

        public PropertyTextTool()
        {
            this.Name = "Property Text Tool";
            this.ToolTipText = "Property Text Tool";
            this.Image = IconSet.cursor;
            this.CheckOnClick = true;
        }
        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && canvas != null)
            {
                canvas.DeselectAllObjects();
                selectedObject = canvas.SelectObjectAt(e.X, e.Y);
                if (selectedObject is ClassDiagram)
                {
                    ClassDiagram classDiagram = (selectedObject as ClassDiagram);
                    RectangleWithText rectangleWithTextProperty = (classDiagram.listDrawingObjects[1] as RectangleWithText);
                    Text text = new Text(rectangleWithTextProperty.X, rectangleWithTextProperty.Y + rectangleWithTextProperty.Height, "Property");
                    rectangleWithTextProperty.Add(text);
                    rectangleWithTextProperty.AddHeight();
                    RectangleWithText rectangleWithTextMethod = (classDiagram.listDrawingObjects[2] as RectangleWithText);
                    rectangleWithTextMethod.UpdateY(rectangleWithTextProperty.Height + rectangleWithTextProperty.Y);
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            
        }
    }
}
