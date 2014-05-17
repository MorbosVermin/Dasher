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
    public partial class AddCipherForm : Form
    {

        private BindingList<IAlgorithm> cipherAlgs;

        public IAlgorithm Encoder
        {
            get
            {
                IAlgorithm cipher = (IAlgorithm)comboBox1.SelectedItem;
                return cipher;
            }
        }

        public string Key
        {
            get { return textBox1.Text; }
        }

        public bool Encoding
        {
            get
            {
                return radioButton1.Checked;
            }
        }

        public AddCipherForm()
        {
            InitializeComponent();
            this.cipherAlgs = new BindingList<IAlgorithm>();
            cipherAlgs.Add(new Base64());
            cipherAlgs.Add(new Rot13());
            cipherAlgs.Add(new XOR());
            cipherAlgs.Add(new URL());
            cipherAlgs.Add(new Hex());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            IAlgorithm alg = (IAlgorithm)comboBox1.SelectedItem;
            label4.Enabled = (alg is XOR);
            textBox1.Enabled = (alg is XOR);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            Dispose();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            radioButton2.Checked = (!radioButton1.Checked);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            radioButton1.Checked = (!radioButton2.Checked);
        }

        private void AddCipherForm_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = cipherAlgs;
        }
    }
}
