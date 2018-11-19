using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawingToolkit.Command;

namespace DrawingToolkit.Tools
{
    public class SelectTool : ToolStripButton, ITool
    {
        private ICanvas canvas;
        private DrawingObject selectedObject;
        private int xInitial, xPrevInitial;
        private int yInitial, yPrevInitial;

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

        public SelectTool()
        {
            this.Name = "Select Tool";
            this.ToolTipText = "Select Tool";
            this.Image = IconSet.cursor;
            this.CheckOnClick = true;
        }
        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            /*List<DrawingObject> ListObjects = this.canvas.GetListObjects();
            foreach (DrawingObject dobject in ListObjects)
            {

                if (dobject.isSelected(e.Location))
                {

                    this.canvas.Repaint();
                }
                else
                {
                    dobject.isNotSelected();
                    this.canvas.Repaint();
                }

            }*/
            this.xInitial = e.X;
            this.yInitial = e.Y;
            this.xPrevInitial = e.X;
            this.yPrevInitial = e.Y;

            if (e.Button == MouseButtons.Left && canvas != null)
            {
                canvas.DeselectAllObjects();
                selectedObject = canvas.SelectObjectAt(e.X, e.Y);
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && canvas != null)
            {
                if (selectedObject != null)
                {
                    int xAmount = e.X - xPrevInitial;
                    int yAmount = e.Y - yPrevInitial;
                    xPrevInitial = e.X;
                    yPrevInitial = e.Y;

                    selectedObject.Translate(xAmount, yAmount);
                }
            }
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            int xAmount = xPrevInitial - xInitial;
            int yAmount = yPrevInitial - yInitial;
            selectedObject.Translate(-xAmount, -yAmount);

            MoveCommand command = new MoveCommand(selectedObject, xAmount, yAmount);
            canvas.ExecuteCommand(command);
        }
    }
}
