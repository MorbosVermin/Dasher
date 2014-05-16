using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            private IAlgorithm encoder;

            public Operation(bool encoding, IAlgorithm encoder, string key)
            {
                this.encoding = encoding;
                this.encoder = encoder;
                Icon = (encoding) ? Properties.Resources.stock_lock : Properties.Resources.stock_lock_open;
                if (key.Length > 0 && encoder is XOR)
                    ((XOR)this.encoder).Key = key;

                Description = encoder.ToString();                
            }

            public Operation(bool encoding, IAlgorithm encoder) : this(encoding, encoder, "") { }

            public bool isEncoding()
            {
                return this.encoding;
            }

            public IAlgorithm GetEncoderObject()
            {
                return this.encoder;
            }

        }

        public bool Wait
        {
            get { return Application.UseWaitCursor; }
            set
            {
                Application.UseWaitCursor = value;
                Application.DoEvents();
            }
        }

        private BindingList<Operation> operations;

        public Form1()
        {
            InitializeComponent();
            operations = new BindingList<Operation>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = operations;
            dataGridView1.Columns[0].Width = 24;
            dataGridView1.Columns[1].Width = dataGridView1.Width - 24;

            backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
        }

        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Wait = false;
            byte[] output = (byte[])e.Result;
            OperationOutputForm form = new OperationOutputForm();
            form.Output = Encoding.UTF8.GetString(output);
            form.ShowDialog(this);
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

        private void button5_Click(object sender, EventArgs e)
        {
            /*
             * Perform (en|de)coding.
             */
            Wait = true;
            backgroundWorker1.RunWorkerAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*
             * Remove selected (en|de)oding operation.
             */
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Operation op = (Operation)dataGridView1.SelectedRows[0].DataBoundItem;
                operations.Remove(op);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            byte[] input = (radioButton1.Checked) ? Encoding.UTF8.GetBytes(textBox1.Text) : File.ReadAllBytes(textBox2.Text);
            foreach(Operation op in operations)  
            {
                input = (op.isEncoding()) ? ((IAlgorithm)op.GetEncoderObject()).Encode(input) : ((IAlgorithm)op.GetEncoderObject()).Decode(input);
            }

            e.Result = input;
        }
    }
}
