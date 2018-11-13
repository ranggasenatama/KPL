using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrawingToolkit.Tools;
using System.Windows.Forms;

namespace DrawingToolkit
{
    public partial class DrawingWindow : Form
    {
        private IToolbox toolbox;
        private ICanvas canvas;

        public DrawingWindow()
        {
            InitializeComponent();

            this.canvas = new DefaultCanvas();
            this.toolStripContainer1.ContentPanel.Controls.Add((Control)this.canvas);


            this.toolbox = new DefaultToolBox();
            this.toolStripContainer1.TopToolStripPanel.Controls.Add((Control)this.toolbox);


            this.toolbox.AddTool(new LineTool());
            this.toolbox.AddTool(new CircleTool());
            this.toolbox.AddTool(new SelectTool());
            //this.toolbox.AddTool(new StatefulLineTool());
            this.toolbox.ToolSelected += Toolbox_ToolSelected;

        }

        private void Toolbox_ToolSelected(ITool tool)
        {
            if (this.canvas != null)
            {
                this.canvas.SetActiveTool(tool);
                tool.TargetCanvas = this.canvas;
            }
        }
    }
}
