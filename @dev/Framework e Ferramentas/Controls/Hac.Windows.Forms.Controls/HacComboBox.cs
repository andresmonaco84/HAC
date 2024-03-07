using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Data;
using System.Windows.Forms;
using HacFramework.Windows.Helpers;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacComboBox : ComboBox, IHacRequiredControl
    {

        private CommonServicesView _commonServices;
        protected CommonServicesView CommonServices
        {
            get
            {
                return _commonServices != null
                           ? _commonServices
                           : _commonServices = new CommonServicesView(FrmBase.DtoPassport);
            }
        }

        private bool obrigatorio;
        private bool limpar;
        private EstadoObjeto estadoinicial;
        private ControleEdicao editavel;
        private string obrigatoriomensagem;
        private bool prevalidado;
        private string prevalidacaomensagem;
        private bool habilitado;

        public HacComboBox()
        {
            this.Inicializar();
        }

        public HacComboBox(IContainer container)
        {
            container.Add(this);
            this.Inicializar();
        }

        private void Inicializar()
        {
            InitializeComponent();
            this.IniciaLista();

        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (!this.DesignMode)
            {
                if (this.SelectedIndex != -1)
                {
                    if (this.SelectedValue != null && this.SelectedValue.ToString() != "-1")
                    {
                        if (!this.NaoAjustarEdicao) ((FrmBase) this.FindForm()).AjustaModoTela(ModoEdicao.Edicao);
                    }
                }
                base.OnSelectedIndexChanged(e);
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            this.BackColor = System.Drawing.Color.Honeydew;
            base.OnGotFocus(e);
        }


        private bool naoAjustarEdicao = true;
        [Category("Hac")]
        [DefaultValue(true)]
        [Description("N�o ajusta modo de tela para edi��o quando o texto � modificado")]        
        public bool NaoAjustarEdicao
        {
            get { return naoAjustarEdicao; }
            set { naoAjustarEdicao = value; }
        }

        /// <summary>        
        /// Serve para deselecionar o item selecionado (caso tenha algum), 
        /// atribuindo o seguinte texto ao SelectedIndex -1: Selecione.
        /// </summary>
        public void LimparComboBox()
        {
            //this.DataSource = null;
            
            if (this.Limpar)
            {
                this.IniciaLista();   
            }
           
        }

        public void IniciaLista()
        {
            this.SelectedIndex = -1;
            this.Text = "<Selecione>";
        }

        [Category("Hac")]
        [Description("Define se Campo ser� limpo quando o usu�rio clicar nos bot�es Novo/Cancelar")]
        public bool Limpar
        {
            get { return limpar; }
            set { limpar = value; }
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

        [Category("Hac")]
        [Description("Define Mensagem de erro quando usu�rio deixar um campo obrigat�rio em branco")]
        [DisplayName ("Mensagem para Campo Obrigat�rio")]
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
        [DisplayName ("Mensagem de Pre Valida��o")]
        public string PreValidacaoMensagem
        {
            get { return prevalidacaomensagem; }
            set { prevalidacaomensagem = value; }
        }

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
            return !string.IsNullOrEmpty(this.Text);
        }

        /// <summary>
        /// Faz as Valida��es necess�rias para o objeto
        /// </summary>
        /// <param name="e">Evento</param>
        public bool ValidaObjeto(Evento e, ref String Mensagem)
        {
            // Chamado de CommonCtr
            Boolean retorno = true;

            switch (e)
            {
                case Evento.eNovo:
                    // verifica se � campo Pr� Validado
                    if ((this.PreValidado && (this.SelectedIndex == -1 || this.SelectedValue.ToString() == "-1")) && this.Enabled && this.Visible)
                    {
                        Mensagem = this.PreValidacaoMensagem;
                        this.BackColor = System.Drawing.Color.LightPink;
                        retorno = false;
                    }
                    break;
                case Evento.eSalvar:
                    //  verifica se � campo obrigat�rio
                    if ((this.Obrigatorio && (this.SelectedIndex == -1 || this.SelectedValue.ToString() == "-1")) && this.Enabled && this.Visible)
                    {
                        Mensagem = this.ObrigatorioMensagem;
                        this.BackColor = System.Drawing.Color.LightPink;
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
        /// Limpa e Habilita objetos conforme configura��o
        /// </summary>
        /// <param name="e">Evento</param>
        public void Controla(Evento e)
        {
            // Chamado de CommonCtr
            switch (e)
            {
                case Evento.eNovo:
                    this.LimparComboBox();
                    this.ControlaEstadoObjeto(e);
                    break;
                case Evento.eSalvar:
                    this.ControlaEstadoObjeto(e);
                    break;
                case Evento.eCancelar:
                    this.LimparComboBox();
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

        
        public void ControlaEstadoObjeto(Evento e)
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
                        break;
                    case Evento.eExcluir:
                        break;
                    default:
                        break;
                }
            }
        }

        protected void CarregarComboComSelecioneTodos(ComboBox objCombo, DataTable dtbDados, string nomeKey, string nomeValue)
        {
            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("-1", "<Selecione>"));
            list.Add(new ListItem("0", "<TODOS>"));

            for (int i = 0; i < dtbDados.Rows.Count; i++)
            {
                list.Add(new ListItem(dtbDados.Rows[i][nomeKey].ToString(), dtbDados.Rows[i][nomeValue].ToString()));
            }

            objCombo.ValueMember = ListItem.FieldNames.Key;
            objCombo.DisplayMember = ListItem.FieldNames.Value;
            objCombo.DataSource = list;
            if (objCombo.Items.Count > 1)
                objCombo.SelectedIndex = 0;
        }

        protected void CarregarComboComSelecione(ComboBox objCombo, DataTable dtbDados, string nomeKey, string nomeValue)
        {
            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("-1", "<Selecione>"));

            for (int i = 0; i < dtbDados.Rows.Count; i++)
            {
                list.Add(new ListItem(dtbDados.Rows[i][nomeKey].ToString(), dtbDados.Rows[i][nomeValue].ToString()));
            }

            objCombo.ValueMember = ListItem.FieldNames.Key;
            objCombo.DisplayMember = ListItem.FieldNames.Value;
            objCombo.DataSource = list;
            if (objCombo.Items.Count > 1)
                objCombo.SelectedIndex = 0;
        }

        protected void CarregarComboComSelecione(ComboBox objCombo, DataTable dtbDados, string nomeKey, string nomeValue1,string nomeValue2)
        {
            List<ListItem> list = new List<ListItem>();
            list.Add(new ListItem("-1", "<Selecione>"));

            for (int i = 0; i < dtbDados.Rows.Count; i++)
            {
                list.Add(new ListItem(dtbDados.Rows[i][nomeKey].ToString(), string.Format("{0} - {1}", dtbDados.Rows[i][nomeValue1].ToString(),dtbDados.Rows[i][nomeValue2].ToString())));
            }

            objCombo.ValueMember = ListItem.FieldNames.Key;
            objCombo.DisplayMember = ListItem.FieldNames.Value;
            objCombo.DataSource = list;
            if (objCombo.Items.Count > 1)
                objCombo.SelectedIndex = 0;
        }


    }
}