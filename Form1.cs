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

        private class Operation
        {
            public Image Icon { get; set;  }
            public string Description { get; set;  }
            private bool encoding;
            private string key;
            private object encoder;

            public Operation(bool encoding, object encoder, string key)
            {
                this.encoding = encoding;
                this.encoder = encoder;
                this.key = key;
                Icon = (encoding) ? Properties.Resources.stock_lock : Properties.Resources.stock_lock_open;
                Description = ((encoding) ? "Encoding" : "Decoding") + " using " + encoder.ToString();
            }

            public string GetKey()
            {
                return this.key;
            }

            public bool isEncoding()
            {
                return this.encoding;
            }

            public object GetEncoderObject()
            {
                return this.encoder;
            }

        }

        private BindingList<Operation> operations;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = operations;
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
            AddCipherForm form = new AddCipherForm();
            DialogResult r = form.ShowDialog(this);
            if (r != System.Windows.Forms.DialogResult.Cancel)
            {
                operations.Add(new Operation(form.Encoding, form.Encoder, form.Key));
            }
        }
    }
}
