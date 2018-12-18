using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit
{
    public class DefaultToolBox : ToolStrip, IToolbox
    {
        private ITool activeTool;

        public ITool ActiveTool
        {
            get
            {
                return this.activeTool;
            }
        }

        public event ToolSelectedEventHandler ToolSelected;

        public void AddTool(ITool tool)
        {
            if(tool is ToolStripButton)
            {
                ToolStripButton toggleButton = (ToolStripButton)tool;

                if (toggleButton.CheckOnClick)
                {
                    toggleButton.CheckedChanged += toggleButton_CheckedChanged;
                }

                this.Items.Add(toggleButton);
            }

        }

        private void toggleButton_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is ToolStripButton)
            {
                ToolStripButton button = (ToolStripButton)sender;

                if (button.Checked)
                {
                    if (button is ITool)
                    {
                        this.activeTool = (ITool)button;

                        if (ToolSelected != null)
                        {
                            ToolSelected(this.activeTool);
                        }

                        UncheckInactiveToggleButtons();
                    }
                    else
                    {
                        throw new InvalidCastException("The tool is not an instance of ITool.");
                    }
                }
            }
        }

        private void UncheckInactiveToggleButtons()
        {
            foreach (ToolStripItem item in this.Items)
            {
                if (item != this.activeTool)
                {
                    if (item is ToolStripButton)
                    {
                        ((ToolStripButton)item).Checked = false;
                    }
                }
            }
        }

        public void RemoveTool(ITool tool)
        {
            foreach (ToolStripItem i in this.Items)
            {
                if (i is ITool)
                {
                    if (i.Equals(tool))
                    {
                        this.Items.Remove(i);
                    }
                }
            }
        }
    }
}
