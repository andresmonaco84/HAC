using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace HospitalAnaCosta.SGS.Componentes
{
    public partial class HacCheckBox : CheckBox, IHacRequiredControl
    {

        public HacCheckBox()
        {
            this.Inicializar();
        }

        public HacCheckBox(IContainer container)
        {
            container.Add(this);
            this.Inicializar();
        }

        private void Inicializar()
        {
            InitializeComponent();
            this.Editavel = ControleEdicao.Sempre;
        }

        /// <summary>
        /// Funciona apenas se a propriedade Limpar = True
        /// </summary>
        public void LimparCheckBox()
        {
            if (this.Limpar) this.Checked = false;
        }

        protected override void OnGotFocus(EventArgs e)
        {
            this.BackColor = Control.DefaultBackColor;
            base.OnGotFocus(e);
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            //((FrmBase)this.FindForm()).AjustaModoTela(ModoEdicao.Edicao);
        }

        private bool obrigatorio;
        private bool limpar;
        private EstadoObjeto estadoinicial;
        private ControleEdicao editavel;
        private string obrigatoriomensagem;
        private bool prevalidado;
        private string prevalidacaomensagem;
        private bool habilitado;


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

        protected override void OnEnabledChanged(EventArgs e)
        {
            if (this.Enabled)
                CommonCtrl.Habilitar(this);
            else
                CommonCtrl.Desabilitar(this);

            base.OnEnabledChanged(e);
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
        public bool ValidaObjeto(Evento e,ref String Mensagem)
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
                        this.BackColor = System.Drawing.Color.LightPink;
                        retorno = false;
                    }
                    break;
                case Evento.eSalvar:
                    //  verifica se é campo obrigatório
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
        /// Faz as Validações necessárias para o objeto
        /// </summary>
        /// <param name="e">Evento</param>
        public void Controla(Evento e)
        {
            // Chamado de CommonCtr
            switch (e)
            {
                case Evento.eNovo:
                    this.LimparCheckBox();
                    this.ControlaEstadoObjeto(e);
                    break;
                case Evento.eSalvar:
                    this.ControlaEstadoObjeto(e);
                    break;
                case Evento.eCancelar:
                    this.LimparCheckBox();
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
        

    }
}