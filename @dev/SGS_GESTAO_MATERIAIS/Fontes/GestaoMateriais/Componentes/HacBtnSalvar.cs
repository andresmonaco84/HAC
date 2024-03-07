using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace HospitalAnaCosta.SGS.Componentes
{
    public partial class HacBtnSalvar : HacButton
    {
        public HacBtnSalvar()
        {
            InitializeComponent();
        }

        public HacBtnSalvar(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}