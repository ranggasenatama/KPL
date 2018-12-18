using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingToolkit
{
    public partial class TextBoxWindow : Form
    {
        private DrawingObject obj;
        private ICanvas canvas;
        public TextBoxWindow(string text, DrawingObject obj, ICanvas canvas)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.textBox1.Text = text;
            this.obj = obj;
            this.canvas = canvas;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextBoxWindow_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
