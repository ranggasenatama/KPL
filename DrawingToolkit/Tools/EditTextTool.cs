using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawingToolkit.Command;
using DrawingToolkit.Shapes;

namespace DrawingToolkit.Tools
{
    public class EditTextTool : ToolStripButton, ITool
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

        public EditTextTool()
        {
            this.Name = "Edit Text Tool";
            this.ToolTipText = "Edit Text Tool";
            this.Image = IconSet.cursor;
            this.CheckOnClick = true;
        }
        public void ToolMouseDown(object sender, MouseEventArgs e)
        {
            DrawingObject obj = canvas.GetObjectAt(e.X, e.Y);
            string passingText = "halo";
            using (TextBoxWindow textBoxWindow = new TextBoxWindow(passingText, obj, canvas))
            {
                if (textBoxWindow.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textBoxWindow.ShowDialog();
                }
            }
        }

        public void ToolMouseMove(object sender, MouseEventArgs e)
        {
            
        }

        public void ToolMouseUp(object sender, MouseEventArgs e)
        {
            
        }

        public void ToolMouseDoublClick(object sender, MouseEventArgs e)
        {

        }
    }
}
