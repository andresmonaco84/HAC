using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;

namespace HospitalAnaCosta.SGS.GestaoMateriais.ComponenteMatMed
{
    public partial class FrmMensagem : FrmBase
    {

        string sTexto_ini = null;
        string sTexto_fim = null;

        public FrmMensagem()
        {
            InitializeComponent();
        }

        private void FrmMensagem_Load(object sender, EventArgs e)
        {
            sTexto_ini = "<font>";
        }
    }
}