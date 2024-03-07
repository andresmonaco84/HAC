using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacLabel : Label
    {
        public HacLabel()
        {
            InitializeComponent();
        }

        public HacLabel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
