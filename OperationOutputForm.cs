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
    }
}
