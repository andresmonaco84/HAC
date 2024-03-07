using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Hac.Windows.Forms;

namespace UnitTest
{
    public partial class Form1 : FrmBaseInternacao
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void hacButton1_Click(object sender, EventArgs e)
        {
            hacConvenio1.Enabled = true;
        }

        private void hacButton2_Click(object sender, EventArgs e)
        {
            hacConvenio1.Enabled = false;
            MessageBox.Show(hacMaskedTextBox1.Text);
        }


    }
}