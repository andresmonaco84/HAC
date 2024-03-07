using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;

namespace HospitalAnaCosta.SGS.Componentes
{
    public partial class HacToolStrip : ToolStrip
    {
        #region Construtor

        public HacToolStrip()
        {
            InitializeComponent();
            ControlaBotoes(Evento.eInicio);
        }

        public HacToolStrip(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            ControlaBotoes(Evento.eInicio);
        }

        #endregion        

        #region Propriedades
       
        private ToolStripItem btnNovo
        {
            get { return this.Items["tsBtnNovo"]; }
        }

        private ToolStripItem btnSalvar
        {
            get { return this.Items["tsBtnSalvar"]; }
        }

        private ToolStripItem btnCancelar
        {
            get { return this.Items["tsBtnCancelar"]; }
        }

        private ToolStripItem btnExcluir
        {
            get { return this.Items["tsBtnExcluir"]; }
        }

        private ToolStripItem btnMatMed
        {
            get { return this.Items["tsBtnMatMed"]; }
        }

        private ToolStripItem btnImprimir
        {
            get { return this.Items["tsBtnPrint"]; }
        }

        private ToolStripItem btnSair
        {
            get { return this.Items["tsBtnSair"]; }
        }

        private ToolStripItem lblTitulo
        {
            get { return this.Items["tsLblTitulo"]; }
        }

        private ToolStripItem btnPesquisar
        {
            get { return this.Items["tsBtnPesquisar"]; }
        }

        private ToolStripItem btnLimpar
        {
            get { return this.Items["tsBtnLimpar"]; }
        }


        private bool novovisivel = true;
        private bool salvarvisivel = true;
        private bool cancelarvisivel =  true;
        private bool excluirvisivel=true ;
        private bool matmedvisivel = true;
        private bool imprimirvisivel = true;
        private bool sairvisivel = true;
        private bool pesquisarvisivel = true;
        private bool limparvisivel = true;
        private string _nomeControleFocus;
        // private bool _execLimparHabilitar;
        private string titulo;

        [Category("Hac")]
        [Description("Nome do Controle que irá receber o Foco quando o botão Novo for clicado")]
        public string NomeControleFoco
        {
            get { return _nomeControleFocus; }
            set { _nomeControleFocus = value; }
        }

        [Category("Hac")]
        [DefaultValue(true)]
        [Description("Botão Novo estará Visivel ?")]
        public bool NovoVisivel
        {
            get { return novovisivel; }
            set 
            {
                btnNovo.Visible = value;
                btnNovo.Enabled = value;
                novovisivel = value; 
            }
        }

        [Category("Hac")]
        [DefaultValue(true)]
        [Description("Botão Pesquisar estará Visivel ?")]
        public bool PesquisarVisivel
        {
            get { return pesquisarvisivel; }
            set
            {
                btnPesquisar.Visible = value;
                btnPesquisar.Enabled = value;
                pesquisarvisivel = value;
            }
        }

        [Category("Hac")]
        [DefaultValue(true)]
        [Description("Botão Limpar estará Visivel ?")]
        public bool LimparVisivel
        {
            get { return limparvisivel; }
            set
            {
                btnLimpar.Visible = value;
                btnLimpar.Enabled = value;
                limparvisivel = value;
            }
        }

        [Category("Hac")]
        [DefaultValue(true)]
        [Description("Botão Salvar estará Visivel ?")]
        public bool SalvarVisivel
        {
            get { return salvarvisivel; }
            set 
            {
                btnSalvar.Visible = value;
                btnSalvar.Enabled = value;
                salvarvisivel = value; 
            }
        }

        [Category("Hac")]
        [DefaultValue(true)]
        [Description("Botão Cancelar estará Visivel ?")]
        public bool CancelarVisivel
        {
            get { return cancelarvisivel; }
            set 
            {
                btnCancelar.Visible = value;
                btnCancelar.Enabled = value;
                cancelarvisivel = value; 
            }
        }

        [Category("Hac")]
        [DefaultValue(true)]
        [Description("Botão Excluir estará Visivel ?")]
        public bool ExcluirVisivel
        {
            get { return excluirvisivel; }
            set
            {
                btnExcluir.Visible = value;
                btnExcluir.Enabled = value;
                excluirvisivel = value; 
            }
        }

        [Category("Hac")]
        [DefaultValue(true)]
        [Description("Botão MatMed estará Visivel ?")]
        public bool MatMedVisivel
        {
            get { return matmedvisivel; }
            set
            {
                btnMatMed.Visible = value;
                btnMatMed.Enabled = value;
                matmedvisivel = value;
            }
        }

        [Category("Hac")]
        [DefaultValue(true)]
        [Description("Botão Imprimir estará Visivel ?")]
        public bool ImprimirVisivel
        {
            get { return imprimirvisivel; }
            set
            {
                btnImprimir.Visible = value;
                btnImprimir.Enabled = value;
                imprimirvisivel = value;
            }
        }

        [Category("Hac")]
        [DefaultValue(true)]
        [Description("Botão Sair estará Visivel ?")]
        public bool SairVisivel
        {
            get { return sairvisivel; }
            set
            {
                btnSair.Visible = value;
                btnSair.Enabled = value;
                sairvisivel = value;
            }
        }

        [Category("Hac")]
        [Description("Define Título da tela")]
        public string TituloTela
        {
            get { return titulo; }
            set
            {
                lblTitulo.Text = value;
                titulo = value;
            }


        }
        #endregion

        #region Declaração dos Eventos Públicos

        [Category("Hac")]
        public event ToolStripHacEventHandler NovoClick;
        [Category("Hac")]
        public event ToolStripHacEventHandler AfterNovo;

        [Category("Hac")]
        public event AfterBeforeHacEventHandler BeforePesquisar;
        [Category("Hac")]
        public event ToolStripHacEventHandler PesquisarClick;
        [Category("Hac")]
        public event AfterBeforeHacEventHandler AfterPesquisar;


        [Category("Hac")]
        public event ToolStripHacEventHandler CancelarClick;
        [Category("Hac")]
        public event AfterBeforeHacEventHandler AfterCancelar;

        [Category("Hac")]
        public event AfterBeforeHacEventHandler BeforeSalvar;
        [Category("Hac")]
        public event ToolStripHacEventHandler SalvarClick;
        [Category("Hac")]
        public event AfterBeforeHacEventHandler AfterSalvar;
        

        [Category("Hac")]
        public event ToolStripHacEventHandler LimparClick;
        [Category("Hac")]
        public event AfterBeforeHacEventHandler AfterLimpar;

        [Category("Hac")]
        public event AfterBeforeHacEventHandler BeforeImprimir;
        [Category("Hac")]
        public event ToolStripHacEventHandler ImprimirClick;
        [Category("Hac")]
        public event AfterBeforeHacEventHandler AfterImprimir;


        [Category("Hac")]
        public event ToolStripHacEventHandler ExcluirClick;
        [Category("Hac")]
        public event ToolStripHacEventHandler MatMedClick;
        [Category("Hac")]
        public event ToolStripHacEventHandler SairClick;


        #endregion   
    
        #region Eventos Internos

        protected virtual void OnAfterCancelar()
        {
            if (AfterCancelar != null) AfterCancelar(this);
        }

        protected virtual void OnAfterLimpar()
        {
            if (AfterLimpar != null) AfterLimpar(this);
        }

        protected virtual void OnAfterSalvar()
        {
            if (AfterSalvar != null) AfterSalvar(this);
        }

        protected virtual void OnAfterNovo()
        {
            if (AfterNovo != null) AfterNovo(this);
        }

        protected virtual bool OnBeforePesquisar()
        {
            if (BeforePesquisar != null)
            {
                BeforePesquisar(this);
                return ((FrmBase)this.FindForm()).ValidaObjeto(Evento.eSalvar);
            }
            else
                return false;
        }

        protected virtual void OnBeforeSalvar()
        {
            if (BeforeSalvar != null) BeforeSalvar(this);
        }

        protected virtual void OnAfterPesquisar()
        {
            if (AfterPesquisar != null) AfterPesquisar(this);
        }
        protected virtual void OnAfterImprimir()
        {
            if (AfterImprimir != null) AfterImprimir(this);
        }
      
        protected virtual bool OnBeforeImprimir()
        {
            if (BeforeImprimir != null)
            {
                BeforeImprimir(this);
                return ((FrmBase)this.FindForm()).ValidaObjeto(Evento.eSalvar);
            }
            else
                return false;
        }

        private void tsBtnNovo_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            if (((FrmBase)this.FindForm()).ValidaObjeto(Evento.eNovo))
            {
                // se existir metodo criado pelo usuário
                if (NovoClick != null)
                {
                    if (this.NovoClick(sender))
                    {
                        ControlaBotoes(Evento.eNovo);
                        if (AfterNovo != null) OnAfterNovo();
                    }
                }
                // se não existe so executa o padrão
                else
                {
                    ControlaBotoes(Evento.eNovo);
                }
            }
            System.Windows.Forms.Cursor.Current = Cursors.Arrow;
        }

        private void tsBtnSalvar_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            if (BeforeSalvar != null) OnBeforeSalvar();

            if (((FrmBase)this.FindForm()).ValidaObjeto(Evento.eSalvar))
            {
                if (SalvarClick != null)
                {
                    if (this.SalvarClick(sender))
                    {
                        ControlaBotoes(Evento.eSalvar);
                        if (AfterSalvar != null) OnAfterSalvar();
                    }
                }
                else
                {
                    ControlaBotoes(Evento.eSalvar);
                }
            }
            System.Windows.Forms.Cursor.Current = Cursors.Arrow;
        }

        private void tsBtnPesquisar_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            if (BeforePesquisar == null)
            {
                if (PesquisarClick != null)
                {
                    this.PesquisarClick(sender);
                }
            }
            else if (OnBeforePesquisar())
            {
                // se existir metodo criado pelo usuário
                if (PesquisarClick != null)
                {
                    if (this.PesquisarClick(sender))
                    {
                        if (AfterPesquisar != null) OnAfterPesquisar();
                    }
                }
            }
            System.Windows.Forms.Cursor.Current = Cursors.Arrow;
        }

        private void tsBtnCancelar_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            if (CancelarClick != null)
            {
                if (this.CancelarClick(sender)) ControlaBotoes(Evento.eCancelar);
                if (AfterCancelar != null) OnAfterCancelar();
            }
            else
            {
                ControlaBotoes(Evento.eCancelar);
            }
            System.Windows.Forms.Cursor.Current = Cursors.Arrow;
        }

        private void tsBtnLimpar_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            if (LimparClick != null)
            {
                if (this.LimparClick(sender)) ControlaBotoes(Evento.eCancelar);
                if (AfterLimpar != null) OnAfterLimpar();
            }
            else
            {
                ControlaBotoes(Evento.eCancelar);
            }
            System.Windows.Forms.Cursor.Current = Cursors.Arrow;
        }

        private void tsBtnExcluir_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            if (ExcluirClick != null)
            {
                if (this.ExcluirClick(sender)) ControlaBotoes(Evento.eExcluir);
            }
            else
            {
                ControlaBotoes(Evento.eCancelar);
            }
            System.Windows.Forms.Cursor.Current = Cursors.Arrow;
        }

        private void tsBtnSair_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            if (SairClick != null)
            {
                if (this.SairClick(sender)) this.FindForm().Close();
            }
            else
            {
                this.FindForm().Close();
            }
            System.Windows.Forms.Cursor.Current = Cursors.Arrow;
        }

        private void tsBtnMatmed_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            if (MatMedClick != null)
            {
                this.MatMedClick(sender);
            }
            System.Windows.Forms.Cursor.Current = Cursors.Arrow;
        }

        private void tsBtnPrint_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
            if (BeforeImprimir == null)
            {
                if (ImprimirClick != null)
                {
                    this.ImprimirClick(sender);
                }
            }
            else if (OnBeforeImprimir())
            {
                // se existir metodo criado pelo usuário
                if (ImprimirClick != null)
                {
                    if (this.ImprimirClick(sender))
                    {
                        if (AfterImprimir != null) OnAfterImprimir();
                    }
                }
            }
            System.Windows.Forms.Cursor.Current = Cursors.Arrow;
        }

        //private void tsBtnImprimir_Click(object sender, EventArgs e)
        //{
        //    if (BeforeImprimir == null)
        //    {
        //        if (ImprimirClick != null)
        //        {
        //            this.ImprimirClick(sender);
        //        }
        //    }
        //    else if (OnBeforeImprimir())
        //    {
        //        // se existir metodo criado pelo usuário
        //        if (ImprimirClick != null)
        //        {
        //            if (this.ImprimirClick(sender))
        //            {
        //                if (AfterImprimir != null) OnAfterImprimir();
        //            }
        //        }
        //    }
        //}
       

        #endregion

        #region Métodos Públicos

        /// <summary>
        /// Para dar acesso ao controle de botões
        /// </summary>
        public void Controla(Evento e)
        {
            // chamada de FrmBase
            ControlaBotoes(e);
        }

        

        #endregion

        #region Métodos Internos

        private void ControlaBotoes(Evento e)
        {
            FrmBase frm;
            frm = (FrmBase)this.FindForm();
            this.btnNovo.Enabled = false;
            this.btnPesquisar.Enabled = false;
            this.btnSalvar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnExcluir.Enabled = false;
            this.btnMatMed.Enabled = false;
            this.btnImprimir.Enabled = this.ImprimirVisivel;

            if (e == Evento.eNovo)
            {
                // chama metodo do FrmBase
                frm.Controla(Evento.eNovo);
                frm.AjustaModoTela(ModoEdicao.Novo);
                // this.btnSalvar.Enabled = this.SalvarVisivel;
                this.btnCancelar.Enabled = this.CancelarVisivel;
                this.btnMatMed.Enabled = this.MatMedVisivel;
                if (!string.IsNullOrEmpty(this.NomeControleFoco)) this.FindForm().Controls[this.NomeControleFoco].Focus();
            }
            else if (e == Evento.eSalvar)
            {
                frm.Controla(Evento.eSalvar);
                frm.AjustaModoTela(ModoEdicao.Inicio);
                this.btnNovo.Enabled = this.NovoVisivel;     
                this.btnPesquisar.Enabled = this.PesquisarVisivel;
                // this.btnMatMed.Enabled = this.MatMedVisivel;
            }
            else if (e == Evento.eCancelar)
            {
                this.btnNovo.Enabled = this.NovoVisivel;
                this.btnPesquisar.Enabled = this.PesquisarVisivel;
                frm.Controla(Evento.eCancelar);
                frm.AjustaModoTela(ModoEdicao.Inicio);
            }
            else if (e == Evento.eLimpar)
            {
                frm.Controla(Evento.eCancelar);
                frm.AjustaModoTela(ModoEdicao.Inicio);
            }

            else if (e == Evento.eExcluir)
            {
                this.btnNovo.Enabled = this.NovoVisivel;
                this.btnPesquisar.Enabled = this.PesquisarVisivel;
            }
            else if (e == Evento.eInicio)
            {
                this.btnNovo.Enabled = this.NovoVisivel;
                this.btnPesquisar.Enabled = this.PesquisarVisivel;
                // ((FrmBase)this.FindForm()).Controla(Evento.eInicio);
                // ((FrmBase)this.FindForm()).AjustaModoTela(ModoEdicao.Inicio);
            }
            else if (e == Evento.eEditar)
            {
                this.btnSalvar.Enabled = this.SalvarVisivel;
                this.btnCancelar.Enabled = this.CancelarVisivel;
                this.btnMatMed.Enabled = this.MatMedVisivel;
                this.btnExcluir.Enabled = this.btnExcluir.Visible;
            }
        }        

        #endregion
    }
}