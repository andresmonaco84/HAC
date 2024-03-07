using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace HospitalAnaCosta.SGS.Componentes
{
    public partial class HacBtnNovo : HacButton
    {
        public HacBtnNovo()
        {
            InitializeComponent();
        }

        public HacBtnNovo(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        
        protected override void OnClick(EventArgs e)
        {
            this.Enabled = false;

            foreach (Control ctr in this.FindForm().Controls)
            {
                if (ctr is HacBtnCancelar)
                {
                    ctr.Enabled = true;                    
                }
                else if (ctr is HacBtnSalvar)
                {
                    ctr.Enabled = true;
                }
                else if (ctr is HacBtnMatMed)
                {
                    ctr.Enabled = false;
                }
            }            
            
            base.OnClick(e);            
        }
    }
}
