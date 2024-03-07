using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacTextBox : TextBox, IHacRequiredControl
    {
        #region Construtor

        public HacTextBox()
        {
            this.Inicializar();
        }

        public HacTextBox(IContainer container)
        {
            this.Inicializar();
            container.Add(this);
        }

        #endregion

        #region Eventos "override"

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);

            if (!this.Multiline && e.KeyChar == 13)
            {
                e.Handled = true;
                SendKeys.Send("{TAB}");
            }

            if (acceptedFormat == AcceptedFormat.Numerico || acceptedFormat == AcceptedFormat.Data)
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
            }
            else if (acceptedFormat == AcceptedFormat.Decimal)
            {
                if (e.KeyChar != ',' && e.KeyChar != '.')
                {
                    if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar)) e.Handled = true;
                }
            }
        }

        protected override void OnKeyUp(KeyEventArgs e)
        {
            base.OnKeyUp(e);

            if (acceptedFormat == AcceptedFormat.Data)
            {
                // Se tecla for diferente de Delete e BacksPace
                if (e.KeyValue != 46 && e.KeyValue != 8)
                {
                    bool duasBarras = false;
                    string texto = this.Text;

                    if (texto.IndexOf("/") > -1)
                    {
                        texto = texto.Remove(texto.IndexOf("/"), 1);
                    }
                    if (texto.IndexOf("/") > -1)
                    {
                        duasBarras = true;
                    }

                    if (!duasBarras)
                    {
                        if (this.Text.Length == 2 || this.Text.Length == 5) this.AppendText("/");
                    }
                }
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.Text))
            {
                if (acceptedFormat != AcceptedFormat.AlfaNumerico)
                {
                    if (!CommonCtrl.ValidateContentType(acceptedFormat, this.Text))
                    {
                        // this.Clear();
                        this.Focus();
                    }
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
            base.OnTextChanged(e);

            //O evento TextChanged é executado duas vezes quando o controle é criado em modo de design
            //por isso foi feita esta verificação. Na primeira vez a propriedade Text é igual ao nome do controle.
            //Na segunda a propriedade Text igual vazio.
            if (!this.DesignMode)
            {
                Form frm = this.FindForm();
                if (frm != null)
                    if (this.Text != string.Empty && !this.NaoAjustarEdicao) ((FrmBase)frm).AjustaModoTela(ModoEdicao.Edicao);
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            RetirarVermelhoCampo();
            base.OnGotFocus(e);
            if (selectAllOnFocus)
            {
                this.SelectAll();                
            }

        }

        public void RetirarVermelhoCampo()
        {
            this.BackColor = System.Drawing.Color.Honeydew;
        }


        protected override void OnEnter(EventArgs e)
        {
            base.OnEnter(e);
            if (selectAllOnFocus)
            {
                this.SelectAll();
            }
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (Enabled)
                CommonCtrl.Habilitar(this);
            else
                CommonCtrl.Desabilitar(this);

            base.OnEnabledChanged(e);
        }

        #endregion

        #region Propriedades Públicas

        #region Variáveis Propriedades

        private bool naoAjustarEdicao = false;
        private bool obrigatorio = false;
        private bool limpar = false;
        private EstadoObjeto estadoinicial = EstadoObjeto.Habilitado;
        private ControleEdicao editavel = ControleEdicao.Nunca;
        private string obrigatoriomensagem = string.Empty;
        private bool selectAllOnFocus = false;
        private AcceptedFormat acceptedFormat;
        private bool prevalidado = false;
        private string prevalidacaomensagem = string.Empty;

        #endregion

        [Category("Hac")]
        [Description("Define se todo o texto dentro do campo será selecionado quando o objeto receber o foco")]
        public bool SelectAllOnFocus
        {
            get { return selectAllOnFocus; }
            set { selectAllOnFocus = value; }
        }

        [Category("Hac")]
        [Description("Define formato do campo")]
        public AcceptedFormat AcceptedFormat
        {
            get { return this.acceptedFormat; }
            set 
            {
                this.acceptedFormat = value;
                if (value == AcceptedFormat.Data)
                    this.MaxLength = 10;
                else
                    this.MaxLength = 32767;
            }
        }

        [Category("Hac")]
        [Description("Não ajusta modo de tela para edição quando o texto é modificado")]
        public bool NaoAjustarEdicao
        {
            get { return naoAjustarEdicao; }
            set { naoAjustarEdicao = value; }
        }

        [Category("Hac")]
        [Description("Define se Campo será limpo quando o usuário clicar nos botões Novo/Cancelar")]
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
        [Description("Define quando campo será editavel")]
        public ControleEdicao Editavel
        {
            get { return editavel; }
            set { editavel = value; }
        }

        [Category("Hac")]
        [Description("Define quando o campo é obrigatório antes de entrar em modo de Inserção (Click Botão novo)")]
        public bool PreValidado
        {
            get { return prevalidado; }
            set { prevalidado = value; }
        }

        [Category("Hac")]
        [Description("Define Mensagem de erro quando usuário deixar um campo obrigatório em branco")]
        [DisplayName("Mensagem para Campo Obrigatório")]
        public string ObrigatorioMensagem
        {
            get { return obrigatoriomensagem; }
            set { obrigatoriomensagem = value; }
        }

        [Category("Hac")]
        [Description("Indica se é campo obrigatório")]
        public bool Obrigatorio
        {
            get { return obrigatorio; }
            set { obrigatorio = value; }
        }

        [Category("Hac")]
        [Description("Mensagem caso campo Pre Validado esteja em Branco")]
        [DisplayName("Mensagem de Pré Validação")]
        public string PreValidacaoMensagem
        {
            get { return prevalidacaomensagem; }
            set { prevalidacaomensagem = value; }
        }

        #endregion        

        #region Métodos Internos

        private void Inicializar()
        {
            InitializeComponent();
            this.ControlaEstadoObjeto(Evento.eInicio);            
        }

        /// <summary>
        /// Habilita ou desabilita os objetos conforme parametros de configuração
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

        #region Métodos Públicos

        /// <summary>
        /// Valida se o componente
        /// </summary>
        public void ValidateRequired(Control controlOwner)
        {
            CommonCtrl.ValidateRequired(controlOwner, false);
        }

        /// <summary>
        /// Faz a validação se o campo esta preenchido
        /// </summary>
        /// <returns></returns>
        public bool ValidateRequired()
        {
            return !string.IsNullOrEmpty(this.Text);
        }

        /// <summary>
        /// Faz as Validações necessárias para o objeto
        /// </summary>
        /// <param name="e">Evento</param>
        public bool ValidaObjeto(Evento e, ref  String Mensagem)
        {
            // Chamado de CommonCtr
            Boolean retorno = true;

            switch (e)
            {
                case Evento.eNovo:
                    // verifica se é campo Pré Validado
                    if ((this.PreValidado && this.Text == string.Empty) && this.Enabled && this.Visible)
                    {
                        Mensagem = this.PreValidacaoMensagem;
                        this.BackColor = Color.LightPink;
                        retorno = false;
                    }
                    break;
                case Evento.eSalvar:
                    //  verifica se é campo obrigatório
                    if ((this.Obrigatorio && this.Text == string.Empty) && this.Enabled && this.Visible)
                    {
                        Mensagem = this.ObrigatorioMensagem;
                        this.BackColor = Color.LightPink;
                        retorno = false;
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
        /// Faz as Validações necessárias para o objeto
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