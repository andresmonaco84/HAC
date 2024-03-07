using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes.Exceptions;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HacFramework.Windows.Helpers;
using HospitalAnaCosta.Framework;
using MVC = HospitalAnaCosta.Framework;





namespace HospitalAnaCosta.SGS.Componentes
{
    public partial class FrmBase : Form
    {   
        private ModoEdicao modotela;
        // public SegurancaDTO dtoSegurancaBase;

        public FrmBase()
        {
            InitializeComponent();
        }

        #region PROPRIEDADES PÚBLICAS

        private string titulo = "SGS ";

        /// <summary>
        /// Ajusta Modo Atual da Tela
        /// </summary>
        public ModoEdicao ModoTela
        {
            get { return modotela; }
            set { modotela = value; }
        }

        /// <summary>
        /// Titulo do Sistema
        /// </summary>
        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }


        //

        #endregion

        #region FUNÇÕES PÚBLICAS


        public void ShowError(HacException exception)
        {
            MessageBox.Show(exception.Message, "Erro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public bool Confirma(string Msg)
        {
            bool retorno = false;
            if (MessageBox.Show(Msg ,this.Text,MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                retorno = true;
            }
            return retorno;
        }

        public void AjustaModoTela(ModoEdicao e)
        {
            // this.Text = string.Format("{0} {1}",this.Titulo, this.Text);

            switch (e)
            {
                case ModoEdicao.Inicio:
                    this.ModoTela = ModoEdicao.Inicio;                    
                    break;
                case ModoEdicao.Novo:
                    this.ModoTela = ModoEdicao.Novo;
                    break;
                case ModoEdicao.Edicao:
                    this.ModoTela = ModoEdicao.Edicao;
                    foreach (Control ctr in this.Controls)
                    {
                        if (ctr is HacToolStrip)
                        {
                            ((HacToolStrip)ctr).Controla(Evento.eEditar);
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Controla estado dos Objetos
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public void Controla(Evento e)
        {
            this.ControlarObjetos(e, this.Controls);
        }

        private StringBuilder Linhas;

        public bool ValidaObjeto(Evento e)
        {
            Linhas = new StringBuilder();
            ValidaObjeto(e, this.Controls);

            if (Linhas.Length > 0)
            {
                MessageBox.Show(Linhas.ToString(), "SGS - Validação de Informações", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            else
            {
                return true;
            }                        
        }

        /// <summary>
        /// Faz Validação dos Objetos ( FrmBase )
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public void ValidaObjeto(Evento e, Control.ControlCollection controls)
        {
            // chamada da toolstrip
            foreach (Control ObjFilhos in controls)
            {
                try
                {
                    CommonCtrl.ValidaObjeto(e, ObjFilhos);
                }
                catch (HacRequiredFieldException ex)
                {
                    Linhas.AppendLine(string.Format(" >> {0}", ex.Message));
                }
                catch (HacException ex)
                {
                    Linhas.AppendLine(string.Format(" >> {0}", ex.Message));
                }

                if (ObjFilhos.HasChildren && ObjFilhos.Visible && ObjFilhos.Enabled)
                    this.ValidaObjeto(e, ObjFilhos.Controls);
            }
        }        

        #endregion

        #region FUNÇÕES PÚBLICAS (UTILITÁRIOS)

        public bool IsNumber(string valor)
        {
            if (valor != null && valor != string.Empty)
            {
                double retornoNumber;
                return Double.TryParse(valor, out retornoNumber);
            }

            return false;
        }

        protected void LimparControles(Control.ControlCollection controls)
        {
            foreach (Control ctr in controls)
            {
                if (ctr.HasChildren) LimparControles(ctr.Controls);
                if (ctr is HacTextBox) ((HacTextBox)ctr).Text = string.Empty;
                if (ctr is HacComboBox) ((HacComboBox)ctr).SelectedValue = "-1";
                if (ctr is HacCheckBox) ((HacCheckBox)ctr).Checked = false;
                if (ctr is HacMaskedTextBox) ((HacMaskedTextBox)ctr).Text = string.Empty;
                if (ctr is HacDataGridView) ((HacDataGridView)ctr).Rows.Clear();
            }
        }

        protected void ConfigurarControles(Control.ControlCollection controls, bool habilitar)
        {
            foreach (Control ctr in controls)
            {
                if (ctr.HasChildren) ConfigurarControles(ctr.Controls, habilitar);
                if (ctr is HacTextBox) ((HacTextBox)ctr).Enabled = habilitar;
                if (ctr is HacComboBox) ((HacComboBox)ctr).Enabled = habilitar;
                if (ctr is HacRadioButton) ((HacRadioButton)ctr).Enabled = habilitar;
                if (ctr is HacCheckBox) ((HacCheckBox)ctr).Enabled = habilitar;
                if (ctr is HacButton) ((HacButton)ctr).Enabled = habilitar;
                if (ctr is HacMaskedTextBox) ((HacMaskedTextBox)ctr).Enabled = habilitar;
                if (ctr is HacDataGridView) ((HacDataGridView)ctr).Enabled = habilitar;
                if (ctr is Button) ((Button)ctr).Enabled = habilitar;
            }
        }

        #endregion

        #region FUNÇÕES PRIVADAS

         private void ControlarObjetos(Evento e, Control.ControlCollection controls)
        {
            foreach (Control objFilho in controls)
            {
                CommonCtrl.Controla(e, objFilho);
                if (objFilho.HasChildren && objFilho.Visible) this.ControlarObjetos(e, objFilho.Controls);
            }
        }

        #endregion

        //private void FrmBase_Load(object sender, EventArgs e)
        //{
        //    this.AjustaModoTela(ModoEdicao.Inicio);
        //}

        #region EVENTOS
        
        protected override void OnLoad(EventArgs e)
        {
            this.Text = string.Format("{0} {1}", this.Titulo, this.Text);
            base.OnLoad(e);
            this.AjustaModoTela(ModoEdicao.Inicio);
        }
        
        #endregion

        


    }
}