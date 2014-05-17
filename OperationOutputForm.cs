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
    public partial class OperationOutputForm : Form
    {

        public string Output
        {
            get { return txtOutput.Text; }
            set { txtOutput.Text = value; }
        }

        public OperationOutputForm()
        {
            InitializeComponent();
        }

        private void OperationOutputForm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.Filter = "All files (*.*)|*.*";
            DialogResult r = saveFileDialog1.ShowDialog(this);
            if (r == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    File.WriteAllText(saveFileDialog1.FileName, Output);
                    Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(String.Format("Could not save output: {0}", ex.Message), 
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
