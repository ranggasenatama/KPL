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
        public string value { get; set; }
        public TextBoxWindow(string text)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.textBox1.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.value = textBox1.Text;
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
