using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace HospitalAnaCosta.SGS.Componentes
{
    public partial class HacBtnMatMed : HacButton
    {
        public HacBtnMatMed()
        {
            InitializeComponent();
        }

        public HacBtnMatMed(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
