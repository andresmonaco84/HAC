using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Hac.Windows.Forms.Controls.Forms
{
    public partial class FrmWebPopup : FrmBase
    {
        public FrmWebPopup(int width, int height)
        {
            InitializeComponent();
        }

        public WebBrowser Browser
        {
            get { return webBrowser; }
        }
    }
}
