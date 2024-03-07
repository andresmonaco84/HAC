using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Drawing;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacActionToolStrip : HacUserControl, IHacRequiredControl
    {
        public HacActionToolStrip()
        {
            InitializeComponent();
        }

        #region [eventos]
        
        //adicionar
        public delegate void AdicionarDelegate(object sender, CancelEventArgs e);

        [Category("Hac")]
        public event AdicionarDelegate Adicionar;

        [Category("Hac")]
        protected virtual void OnAdicionar(CancelEventArgs e)
        {
            if (Adicionar != null)
            {
                Adicionar(this, e);
            }
        }

        //cancelar
        public delegate void CancelarDelegate(object sender, CancelEventArgs e);

        [Category("Hac")]
        public event CancelarDelegate Cancelar;

        [Category("Hac")]
        protected virtual void OnCancelar(CancelEventArgs e)
        {
            if (Cancelar != null)
            {
                Cancelar(this, e);
            }
        }

        //confirmar
        public delegate void ConfirmarDelegate(object sender, CancelEventArgs e);

        [Category("Hac")]
        public event ConfirmarDelegate Confirmar;

        [Category("Hac")]
        protected virtual void OnConfirmar(CancelEventArgs e)
        {
            if (Confirmar != null)
            {
                Confirmar(this, e);
            }
        }

        //remover
        public delegate void RemoverDelegate(object sender, CancelEventArgs e);

        [Category("Hac")]
        public event RemoverDelegate Remover;

        [Category("Hac")]
        protected virtual void OnRemover(CancelEventArgs e)
        {
            if (Remover != null)
            {
                Remover(this, e);
            }
        }

        [Category("Hac")]
        [Description("Define mensagem do campo Adicionar")]
        public string ToolTipAdicionar
        {
            get { return toolTip1.GetToolTip(btnConfirmar); }
            set { toolTip1.SetToolTip(btnConfirmar, value); }
        }

        [Category("Hac")]
        [Description("Define estado do campo Confirmar (Habilitado/Desabilitado)")]
        [DefaultValue(true)]
        public bool EstadoConfirmar
        {
            get { return btnConfirmar.Enabled; }
            set { btnConfirmar.Enabled = value; }
        }


        [Category("Hac")]
        [Description("Define estado do campo Cancelar (Habilitado/Desabilitado)")]
        [DefaultValue(true)]
        public bool EstadoCancelar
        {
            get { return btnCancelar.Enabled; }
            set { btnCancelar.Enabled = value; }
        }


        [Category("Hac")]
        [Description("Define estado do campo Remover (Habilitado/Desabilitado)")]
        [DefaultValue(true)]
        public bool EstadoRemover
        {
            get { return btnRemover.Enabled; }
            set { btnRemover.Enabled = value; }
        }


        #endregion

        private EstadoObjeto estadoinicial;
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


        private bool limpar;
        [Category("Hac")]
        [Description("Define se Campo ser� limpo quando o usu�rio clicar nos bot�es Novo/Cancelar")]
        public bool Limpar
        {
            get { return limpar; }
            set { limpar = value; }
        }

        private string obrigatoriomensagem;
        [Category("Hac")]
        [Description("Define Mensagem de erro quando usu�rio deixar um campo obrigat�rio em branco")]
        [DisplayName("Mensagem para Campo Obrigat�rio")]
        public string ObrigatorioMensagem
        {
            get { return obrigatoriomensagem; }
            set { obrigatoriomensagem = value; }
        }

        private bool obrigatorio;
        [Category("Hac")]
        [Description("Indica se � campo obrigat�rio")]
        public bool Obrigatorio
        {
            get { return obrigatorio; }
            set { obrigatorio = value; }
        }

        private ControleEdicao editavel;
        [Category("Hac")]
        [Description("Define quando campo ser� editavel")]
        public ControleEdicao Editavel
        {
            get { return editavel; }
            set { editavel = value; }
        }

        private bool prevalidado;
        [Category("Hac")]
        [Description("Define quando o campo � obrigat�rio antes de entrar em modo de Inser��o (Click Bot�o novo)")]
        public bool PreValidado
        {
            get { return prevalidado; }
            set { prevalidado = value; }
        }

        string prevalidacaomensagem;
        [Category("Hac")]
        [Description("Mensagem caso campo Pre Validado esteja em Branco")]
        [DisplayName("Mensagem de Pr� Valida��o")]
        public string PreValidacaoMensagem
        {
            get { return prevalidacaomensagem; }
            set { prevalidacaomensagem = value; }
        }

        /// <summary>
        /// Valida se o componente
        /// </summary>
        public void ValidateRequired(Control controlOwner)
        {
            CommonCtrl.ValidateRequired(controlOwner, false);
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
                    //this.LimparTextBox();
                    //this.ControlaEstadoObjeto(e);
                    break;
                case Evento.eSalvar:
                    //this.ControlaEstadoObjeto(e);
                    break;
                case Evento.eCancelar:
                    //this.LimparTextBox();
                    //this.ControlaEstadoObjeto(e);
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
        /// Faz a valida��o se o campo esta preenchido
        /// </summary>
        /// <returns></returns>
        public bool ValidateRequired()
        {
            return !btnCancelar.Enabled;
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
                case Evento.eSalvar:
                    //  verifica se � campo obrigat�rio
                    if ((this.Obrigatorio && this.btnCancelar.Enabled) && this.Enabled && this.Visible)
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


        private void HacActionToolStrip_Load(object sender, EventArgs e)
        {
            EstadoInicialIniciar();
            
        }

        public void EstadoInicialIniciar()
        {
            btnConfirmar.Enabled = true;

            btnCancelar.Enabled = btnRemover.Enabled = false;

            this.BackColor = DefaultBackColor;
        }
        
        //cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CancelEventArgs cancelEventArgs = new CancelEventArgs();
            cancelEventArgs.Cancel = false;
            OnCancelar(cancelEventArgs);

            if (!cancelEventArgs.Cancel)
            {
                EstadoInicialIniciar();
            }
        }
        
        //remover
        private void btnRemover_Click(object sender, EventArgs e)
        {
            CancelEventArgs cancelEventArgs = new CancelEventArgs();
            cancelEventArgs.Cancel = false;
            OnRemover(cancelEventArgs);

            if (!cancelEventArgs.Cancel)
            {
                EstadoInicialIniciar();
            }
        }
        
        //confirmar
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            CancelEventArgs cancelEventArgs = new CancelEventArgs();
            cancelEventArgs.Cancel = false;
            OnConfirmar(cancelEventArgs);

            if (!cancelEventArgs.Cancel)
            {
                EstadoInicialIniciar();
            }
        }
        
        //adicionar
        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            CancelEventArgs cancelEventArgs = new CancelEventArgs();
            cancelEventArgs.Cancel = false;
            OnAdicionar(cancelEventArgs);

            if (!cancelEventArgs.Cancel)
            {
                btnCancelar.Enabled = btnConfirmar.Enabled = true;
                btnRemover.Enabled = false;
            }
        }

        public void Editar()
        {
            btnCancelar.Enabled = btnConfirmar.Enabled = btnRemover.Enabled = true;
        }    

    }
}