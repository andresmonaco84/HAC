using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace HospitalAnaCosta.SGS.Componentes
{
    public partial class HacButton : Button
    {
        private bool alterarStatus;
        private bool habilitado;

        [Category("Hac")]
        public bool AlterarStatus
        {
            get { return alterarStatus; }
            set { alterarStatus = value; }
        }

        public HacButton()
        {
            InitializeComponent();
            AlterarStatus = true;
        }

        public HacButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
            AlterarStatus = true;
        }


        protected override void OnEnabledChanged(EventArgs e)
        {
            if (this.Enabled)
                CommonCtrl.Habilitar(this);
            else
                CommonCtrl.Desabilitar(this);

            base.OnEnabledChanged(e);
        }

        /// <summary>
        /// Funciona apenas se a propriedade AlterarStatus = True
        /// </summary>
        public void Habilitar()
        {
            if (this.AlterarStatus) this.Enabled = true;
        }

        /// <summary>
        /// Funciona apenas se a propriedade AlterarStatus = True
        /// </summary>
        public void Desabilitar()
        {
            if (this.AlterarStatus) this.Enabled = false;
        }
    }
}