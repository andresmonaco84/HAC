using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacBtnPesquisa : HacButton
    {
        public HacBtnPesquisa()
        {
            InitializeComponent();
        }

        public HacBtnPesquisa(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
