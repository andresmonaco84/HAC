using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacListBox : ListBox
    {
        private bool limpar;
        private bool alterarStatus;

        [Category("Hac")]
        public bool Limpar
        {
            get { return limpar; }
            set { limpar = value; }
        }

        [Category("Hac")]
        public bool AlterarStatus
        {
            get { return alterarStatus; }
            set { alterarStatus = value; }
        }

        public HacListBox()
        {
            this.Inicializar();
        }

        public HacListBox(IContainer container)
        {
            container.Add(this);
            this.Inicializar();
        }

        private void Inicializar()
        {
            InitializeComponent();

            this.Limpar = true;
            this.AlterarStatus = true;
        }

        /// <summary>
        /// Funciona apenas se a propriedade Limpar = True.
        /// Se parâmetro limparDataSource = false, apenas deseleciona todos os itens.
        /// </summary>
        /// <param name="limparDataSourc"></param>
        public void LimparListBox(bool limparDataSource)
        {
            if (this.Limpar)
            {
                if (limparDataSource)
                {
                    this.DataSource = null;
                }
                else
                {
                    this.ClearSelected();
                }
            } 
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