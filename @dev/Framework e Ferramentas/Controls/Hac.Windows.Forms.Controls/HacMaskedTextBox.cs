using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacMaskedTextBox : MaskedTextBox, IHacRequiredControl
    {
        #region Construtor

        public HacMaskedTextBox()
        {
            this.Inicializar();
        }

        public HacMaskedTextBox(IContainer container)
        {
            this.Inicializar();
            this.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            container.Add(this);            
        }

        #endregion

        public override string Text
        {
            get 
            {
                switch (AcceptedFormatMasked)
                {
                    case AcceptedFormatMasked.Data:
                        if (base.Text == "__/__/____") return string.Empty;
                        break;
                    case AcceptedFormatMasked.Hora:
                        if (base.Text == "__:__") return string.Empty;
                        break;
                    case AcceptedFormatMasked.Telefone:
                        if (base.Text == "(__)____-____") return string.Empty;
                        break;
                    case AcceptedFormatMasked.CPF:
                        if (base.Text == "___.___.___-__") return string.Empty;
                        break;
                    case AcceptedFormatMasked.CEP:
                        if (base.Text == "_____-___") return string.Empty;
                        break;
                    case AcceptedFormatMasked.CNPJ:
                        if (base.Text == "__.___.___/____-__") return string.Empty;
                        break;
                    case AcceptedFormatMasked.NumericoValor:
                        if (base.Text == "###.###.##0,00") return string.Empty;
                        break;
                    case AcceptedFormatMasked.NumericoPercentual:
                        if (base.Text == "##0,000") return string.Empty;
                        break;                    
                    default:
                        break;
                }

                return base.Text;                 
            }
        }

        #region Eventos "override"

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }

            if (acceptedFormat == AcceptedFormatMasked.Data)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
            }
        }


        protected override void OnLostFocus(EventArgs e)
        {
            if (this.Text != string.Empty)
            {
                if (!CommonCtrl.ValidateContentType(acceptedFormat, this.Text))
                {
                    // this.Clear();
                    this.Focus();
                }
            }
            base.OnLostFocus(e);
        }

        protected override void OnModifiedChanged(EventArgs e)
        {
            base.OnModifiedChanged(e);
            if (this.Modified && !this.NaoAjustarEdicao) ((FrmBase)this.FindForm()).AjustaModoTela(ModoEdicao.Edicao);
        }

        protected override void OnTextChanged(EventArgs e)
        {

            //O evento TextChanged � executado duas vezes quando o controle � criado em modo de design
            //por isso foi feita esta verifica��o. Na primeira vez a propriedade Text � igual ao nome do controle.
            //Na segunda a propriedade Text igual vazio.
            if (!this.DesignMode)
            {
                Form frm = this.FindForm();
                if (frm != null)
                {
                    if (this.Text != string.Empty  && !this.NaoAjustarEdicao) ((FrmBase)frm).AjustaModoTela(ModoEdicao.Edicao);
                }
            }
            base.OnTextChanged(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Honeydew;
            base.OnGotFocus(e);
            if (selectAllOnFocus)
            {
                this.SelectAll();
            }

        }

        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (selectAllOnFocus)
            {
                this.SelectAll();
            }
        }

        #endregion

        #region Propriedades P�blicas

        #region Vari�veis Propriedades

        private bool apresentarDataAtual = false;
        private bool naoAjustarEdicao = false;
        private bool obrigatorio = false;
        private bool limpar = false;
        private EstadoObjeto estadoinicial = EstadoObjeto.Habilitado;
        private ControleEdicao editavel = ControleEdicao.Nunca;
        private string obrigatoriomensagem = string.Empty;
        private bool selectAllOnFocus = false;
        private AcceptedFormatMasked acceptedFormat;
        private bool prevalidado = false;
        private string prevalidacaomensagem = string.Empty;
        private bool habilitado;

        #endregion

        [Category("Hac")]
        [Description("Define se todo o texto dentro do campo ser� selecionado quando o objeto receber o foco")]
        public bool SelectAllOnFocus
        {
            get { return selectAllOnFocus; }
            set { selectAllOnFocus = value; }
        }

        [Category("Hac")]
        [Description("Define formato do campo")]
        [DefaultValueAttribute("Data")]
        public AcceptedFormatMasked AcceptedFormatMasked
        {
            get { return this.acceptedFormat; }
            set 
            {
                this.acceptedFormat = value;
                switch (AcceptedFormatMasked)
                {
                    case AcceptedFormatMasked.Data:
                        this.Mask = "00/00/0000";
                        this.Width = 70;
                        break;
                    case AcceptedFormatMasked.Hora:
                        this.Mask = "00:00";
                        this.Width = 42;
                        break;
                    case AcceptedFormatMasked.Telefone:
                        this.Mask = "(00)0000-0000";
                        this.Width = 91;
                        break;
                    case AcceptedFormatMasked.CPF:
                        this.Mask = "###.###.###-##";
                        this.Width = 96;
                        break;
                    case AcceptedFormatMasked.CEP:
                        this.Mask = "00000-000";
                        this.Width = 70;
                        break;
                    case AcceptedFormatMasked.CNPJ:
                        this.Mask = "##.###.###/####-##";
                        this.Width = 140;
                        break;
                    case AcceptedFormatMasked.NumericoValor:
                        this.Mask = "###.###.##0,00";
                        this.Width = 115;
                        break;
                    case AcceptedFormatMasked.NumericoPercentual:
                        this.Mask = "##0,000";
                        this.Width = 60;
                        break;                    
                    default:
                        break;
                }
            }
        }
        
        [Category("Hac")]
        [Description("N�o ajusta modo de tela para edi��o quando o texto � modificado")]
        public bool NaoAjustarEdicao
        {
            get { return naoAjustarEdicao; }
            set { naoAjustarEdicao = value; }
        }

        [Category("Hac")]
        [Description("Define se Campo ser� limpo quando o usu�rio clicar nos bot�es Novo/Cancelar")]
        public bool Limpar
        {
            get { return limpar; }
            set { limpar = value; }
        }

        [Category("Hac")]
        [Description("Define Estado Inicial do campo ( Habilitado/Desabilitado)")]
        public EstadoObjeto EstadoInicial
        {
            get { return estadoinicial; }
            set
            {
                if (value == EstadoObjeto.Habilitado)
                {
                    CommonCtrl.Habilitar(this);
                }
                else
                {
                    CommonCtrl.Desabilitar(this);
                }
                estadoinicial = value;
            }
        }

        [Category("Hac")]
        [Description("Define quando campo ser� editavel")]
        public ControleEdicao Editavel
        {
            get { return editavel; }
            set { editavel = value; }
        }

        [Category("Hac")]
        [Description("Define quando o campo � obrigat�rio antes de entrar em modo de Inser��o (Click Bot�o novo)")]
        public bool PreValidado
        {
            get { return prevalidado; }
            set { prevalidado = value; }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (this.Enabled)
                CommonCtrl.Habilitar(this);
            else
                CommonCtrl.Desabilitar(this);

            base.OnEnabledChanged(e);
        }

        [Category("Hac")]
        [Description("Define Mensagem de erro quando usu�rio deixar um campo obrigat�rio em branco")]
        [DisplayName("Mensagem para Campo Obrigat�rio")]
        public string ObrigatorioMensagem
        {
            get { return obrigatoriomensagem; }
            set { obrigatoriomensagem = value; }
        }

        [Category("Hac")]
        [Description("Indica se � campo obrigat�rio")]
        public bool Obrigatorio
        {
            get { return obrigatorio; }
            set { obrigatorio = value; }
        }

        [Category("Hac")]
        [Description("Mensagem caso campo Pre Validado esteja em Branco")]
        [DisplayName("Mensagem de Pr� Valida��o")]
        public string PreValidacaoMensagem
        {
            get { return prevalidacaomensagem; }
            set { prevalidacaomensagem = value; }
        }

        #endregion        

        #region M�todos Internos

        private void Inicializar()
        {
            InitializeComponent();
            this.ControlaEstadoObjeto(Evento.eInicio);

        }

        /// <summary>
        /// Habilita ou desabilita os objetos conforme parametros de configura��o
        /// </summary>
        /// <param name="e"></param>
        private void ControlaEstadoObjeto(Evento e)
        {
            if (this.Editavel != ControleEdicao.Nunca)
            {
                switch (e)
                {
                    case Evento.eNovo:
                        if (this.Editavel == ControleEdicao.Sempre || this.Editavel == ControleEdicao.NovoRegistro)
                        {
                            CommonCtrl.Habilitar(this);
                        }
                        else
                        {
                            CommonCtrl.Desabilitar(this);

                        }
                        this.Modified = false;
                        break;
                    case Evento.eSalvar:
                    case Evento.eCancelar:
                    case Evento.eInicio:
                        if (this.EstadoInicial == EstadoObjeto.Habilitado && (this.Editavel == ControleEdicao.Pesquisa || this.Editavel == ControleEdicao.Sempre))
                        {
                            CommonCtrl.Habilitar(this);
                        }
                        else
                        {
                            CommonCtrl.Desabilitar(this);
                        }
                        this.Modified = false;
                        break;
                    case Evento.eExcluir:
                        break;
                    default:
                        break;
                }
            }
        }             

        #endregion

        #region M�todos P�blicos

        /// <summary>
        /// Valida se o componente
        /// </summary>
        public void ValidateRequired(Control controlOwner)
        {
            CommonCtrl.ValidateRequired(controlOwner, false);
        }

        /// <summary>
        /// Faz a valida��o se o campo esta preenchido
        /// </summary>
        /// <returns></returns>
        public bool ValidateRequired()
        {
            bool retorno = false;

            if (this.Text == this.Mask)
                retorno = true;
            else if (string.IsNullOrEmpty(this.Text))
                retorno = true;

            return retorno;
        }

        /// <summary>
        /// Faz as Valida��es necess�rias para o objeto
        /// </summary>
        /// <param name="e">Evento</param>
        public bool ValidaObjeto(Evento e, ref  String Mensagem)
        {
            // Chamado de CommonCtr
            Boolean retorno = true;

            switch (e)
            {
                case Evento.eNovo:
                    //  verifica se � campo obrigat�rio
                    if ((this.PreValidado && this.Text == string.Empty) && this.Enabled && this.Visible)
                    {
                        Mensagem = this.ObrigatorioMensagem;
                        this.BackColor = Color.LightPink;
                        retorno = false;
                    }
                    break;
                case Evento.eSalvar:
                    //  verifica se � campo obrigat�rio
                    if ((this.Obrigatorio && this.Text == string.Empty) && this.Enabled && this.Visible)
                    {
                        Mensagem = this.ObrigatorioMensagem;
                        this.BackColor = Color.LightPink;
                        retorno = false;
                    }
                    if (this.Text != string.Empty && this.Enabled && this.Visible && AcceptedFormatMasked == AcceptedFormatMasked.CPF)
                    {
                        if (!CommonCtrl.ValidarCPF(this.Text))
                        {
                            Mensagem = "CPF inv�lido.";
                            this.BackColor = Color.LightPink;
                            retorno = false;
                        }
                    }
                    if (this.Text != string.Empty && this.Enabled && this.Visible && AcceptedFormatMasked == AcceptedFormatMasked.Hora)
                    {
                        string[] horaMinuto = this.Text.Split(new char[]{':'});

                        if (!CommonCtrl.ValidarHora(horaMinuto[0], horaMinuto[1]))
                        {
                            Mensagem = "A Hora digitada � inv�lida.";
                            this.BackColor = Color.LightPink;
                            retorno = false;
                        }
                    }
                    if (this.Text != string.Empty && this.Enabled && this.Visible && AcceptedFormatMasked == AcceptedFormatMasked.Data)
                    {
                        if (!HospitalAnaCosta.Framework.BasicFunctions.ValidarData(this.Text))
                        {
                            Mensagem = "Data inv�lida.";
                            this.BackColor = Color.LightPink;
                            retorno = false;
                        }
                    }

                    break;
                case Evento.eCancelar:
                    break;
                case Evento.eExcluir:
                    break;
                case Evento.eInicio:
                    break;
                default:
                    break;
            }
            return retorno;


        }

        /// <summary>
        /// Faz as Valida��es necess�rias para o objeto
        /// </summary>
        /// <param name="e">Evento</param>
        public void Controla(Evento e)
        {
            // Chamado de CommonCtr
            switch (e)
            {
                case Evento.eNovo:
                    this.LimparTextBox();
                    this.ControlaEstadoObjeto(e);
                    break;
                case Evento.eSalvar:
                    this.ControlaEstadoObjeto(e);
                    break;
                case Evento.eCancelar:
                    this.LimparTextBox();
                    this.ControlaEstadoObjeto(e);
                    break;
                case Evento.eExcluir:
                    break;
                case Evento.eInicio:
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Funciona apenas se a propriedade Limpar = True
        /// </summary>
        public void LimparTextBox()
        {
            if (this.Limpar) this.Clear();
        }

        #endregion
     }
}