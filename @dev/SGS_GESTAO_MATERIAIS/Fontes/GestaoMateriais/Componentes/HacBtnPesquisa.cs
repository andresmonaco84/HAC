using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace HospitalAnaCosta.SGS.Componentes
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
