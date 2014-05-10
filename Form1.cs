using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dasher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "All files (*.*)|*.*";
            DialogResult r = openFileDialog1.ShowDialog(this);
            if(r == System.Windows.Forms.DialogResult.OK)  
            {
                textBox2.Text = openFileDialog1.FileName;
            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Checked = (!radioButton1.Checked);
            textBox1.Enabled = radioButton1.Checked;
            textBox2.Enabled = radioButton2.Checked;
            button1.Enabled = radioButton2.Checked;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = (!radioButton2.Checked);
            textBox1.Enabled = radioButton1.Checked;
            textBox2.Enabled = radioButton2.Checked;
            button1.Enabled = radioButton2.Checked;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult r = new AddCipherForm().ShowDialog(this);
            if (r != System.Windows.Forms.DialogResult.Cancel)
            {

            }
        }
    }
}
