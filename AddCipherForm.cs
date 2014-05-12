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

        class CipherAlg
        {
            public string Name { get; set; }
            public string Description { get; set; }

            public CipherAlg(string name, string desc)
            {
                this.Name = name;
                this.Description = desc;
            }

            public override string ToString()
            {
                return String.Format("{0} - {1}", Name, Description);
            }
        }

        private BindingList<CipherAlg> cipherAlgs;

        public object Encoder
        {
            get
            {
                CipherAlg cipher = (CipherAlg)comboBox1.SelectedItem;
                if (cipher.Name.Equals("Base64"))
                {
                    return new Base64();
                }
                else if (cipher.Name.Equals("ROT13"))
                {
                    return new Rot13();
                }
                else if (cipher.Name.Equals("URL"))
                {
                    return new URL();
                }
                else if (cipher.Name.Equals("XOR"))
                {
                    return new XOR();
                }

                return new Hex();
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
            this.cipherAlgs = new BindingList<CipherAlg>();
            cipherAlgs.Add(new CipherAlg("Base64", "An integrity cipher that cannot be relied upon solely for any security."));
            cipherAlgs.Add(new CipherAlg("ROT13", "Simple character rotation scheme."));
            cipherAlgs.Add(new CipherAlg("URL", "Scheme used by web applications to normalize data from the web."));
            cipherAlgs.Add(new CipherAlg("XOR", "XOR encryption using a shared-key. A key is required."));
            cipherAlgs.Add(new CipherAlg("HEX", "Hexidecimal encoding."));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CipherAlg alg = (CipherAlg)comboBox1.SelectedItem;
            label4.Enabled = alg.Name.Equals("XOR");
            textBox1.Enabled = alg.Name.Equals("XOR");
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
