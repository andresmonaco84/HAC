using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacBtnSair : HacButton
    {
        public HacBtnSair()
        {
            InitializeComponent();
        }

        public HacBtnSair(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override void OnClick(EventArgs e)
        {
            this.FindForm().Close();
            //base.OnClick(e);
        }
    }
}