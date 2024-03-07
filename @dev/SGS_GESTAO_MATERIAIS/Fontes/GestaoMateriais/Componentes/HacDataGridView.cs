using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace HospitalAnaCosta.SGS.Componentes
{
    public partial class HacDataGridView : DataGridView, IHacRequiredControl
    {
        
        private bool grdPesquisa = false;
        private bool alterarStatus;
        private bool naoAjustarEdicao;
        private bool limpar;
        private EstadoObjeto estadoinicial;
        private ControleEdicao editavel;
        private string obrigatoriomensagem;
        private bool selectAllOnFocus;
        private AcceptedFormat acceptedFormat;
        private bool prevalidado;
        private string prevalidacaomensagem;
        private bool obrigatorio;

        [Category("Hac")]
        [Description("N�o ajusta modo de tela para edi��o quando o texto � modificado")]
        public bool NaoAjustarEdicao
        {
            get { return naoAjustarEdicao; }
            set { naoAjustarEdicao = value; }
        }

        [Category("Hac")]
        public bool GridPesquisa
        {
            get { return grdPesquisa; }
            set { grdPesquisa = value; }
        }

        [Category("Hac")]
        [Description("Define se Campo ser� limpo quando o usu�rio clicar nos bot�es Novo/Cancelar")]
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


        public HacDataGridView()
        {
            this.Inicializar();
        }        

        public HacDataGridView(IContainer container)
        {
            container.Add(this);
            this.Inicializar();
        }

        private void Inicializar()
        {
            InitializeComponent();

            // this.Limpar = true;
            // this.AlterarStatus = true;
        }

        protected override void OnRowsAdded(DataGridViewRowsAddedEventArgs e)
        {
            if (!this.DesignMode)
            {
                if (!this.NaoAjustarEdicao) ((FrmBase)this.FindForm()).AjustaModoTela(ModoEdicao.Edicao);
                base.OnRowsAdded(e);
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (!this.NaoAjustarEdicao) ((FrmBase)this.FindForm()).AjustaModoTela(ModoEdicao.Edicao);
            base.OnMouseClick(e);
        }

        protected override void OnCellMouseDoubleClick(DataGridViewCellMouseEventArgs e)
        {
            if (!this.NaoAjustarEdicao) ((FrmBase)this.FindForm()).AjustaModoTela(ModoEdicao.Edicao);
            base.OnCellMouseDoubleClick(e);
        }


        /// <summary>
        /// Funciona apenas se a propriedade Limpar = True
        /// </summary>
        public void LimparDataGridView()
        {
            if (this.Limpar)
            {
                this.DataSource = null;
            }
        }


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
            return !string.IsNullOrEmpty(this.Text);
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
                    // verifica se � campo Pr� Validado
                    if ((this.PreValidado && this.Text == string.Empty) && this.Enabled && this.Visible)
                    {
                        Mensagem = this.PreValidacaoMensagem;
                        this.BackColor = System.Drawing.Color.LightPink;
                        retorno = false;
                    }
                    break;
                case Evento.eSalvar:
                    //  verifica se � campo obrigat�rio
                    if ((this.Obrigatorio && this.Text == string.Empty) && this.Enabled && this.Visible)
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
        /// Faz as Valida��es necess�rias para o objeto
        /// </summary>
        /// <param name="e">Evento</param>
        public void Controla(Evento e)
        {
            // Chamado de CommonCtr
            switch (e)
            {
                case Evento.eNovo:
                    this.LimparDataGridView();
                    this.ControlaEstadoObjeto(e);
                    break;
                case Evento.eSalvar:
                    this.ControlaEstadoObjeto(e);
                    break;
                case Evento.eCancelar:
                    this.LimparDataGridView();
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



        /*
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
        */
    }
}