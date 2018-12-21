using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawingToolkit.Command;

namespace DrawingToolkit.Layer
{
    public abstract class AddTextTool : ToolStripButton, ITool
    {
        protected ICanvas canvas;
        protected String name;

        public abstract String Name { get; set; }

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

        protected void Create(DrawingObject obj)
        {
            ConnectorCommand command = new ConnectorCommand(obj, canvas);
            this.canvas.ExecuteCommand(command);
        }

        protected string PopUpForm(string placeholder)
        {
            string formValue = "";
            using (TextBoxWindow textBoxWindow = new TextBoxWindow(placeholder))
            {
                if (textBoxWindow.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    textBoxWindow.ShowDialog();
                }
                formValue = textBoxWindow.value;
            }
            return formValue;
        }

        public abstract void ToolMouseDown(object sender, MouseEventArgs e);

        public abstract void ToolMouseMove(object sender, MouseEventArgs e);

        public abstract void ToolMouseUp(object sender, MouseEventArgs e);
    }
}
