using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace UnitTest
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void hacButton1_Click(object sender, EventArgs e)
        {
            hacConvenio1.Enabled = true;
        }

        private void hacButton2_Click(object sender, EventArgs e)
        {
            hacConvenio1.Enabled = false;
        }

    }
}
