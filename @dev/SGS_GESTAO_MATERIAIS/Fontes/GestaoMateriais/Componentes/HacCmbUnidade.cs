using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Web.UI.WebControls;
using System.Data;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.Interface;



namespace HospitalAnaCosta.SGS.Componentes
{
    public partial class HacCmbUnidade : HacComboBox
    {
        private bool _somenteUnidade = false;
        [Category("Hac")]
        [Description("True - Não carrega combos local e setor. False - Carrega combos local e setor.")]
        public bool SomenteUnidade
        {
            get { return _somenteUnidade; }
            set { _somenteUnidade = value; }
        }

        private bool _somenteAtiva = false;
        [Category("Hac")]
        [Description("True - Somente unidades ativas")]
        public bool SomenteAtiva
        {
            get { return _somenteAtiva; }
            set { _somenteAtiva = value; }
        }

        private bool _gravaAtendimento = false;
        [Category("Hac")]
        [Description("True - Carrega Unidades que Gravam Atendimento")]
        public bool GravaAtendimento
        {
            get { return _gravaAtendimento; }
            set { _gravaAtendimento = value; }
        }

        //private bool _internacao = false;
        //[Category("Hac")]
        //[Description("True - Carrega Unidades que Gravam Internacao, que estao associadas ao local Internacao")]
        //public bool Internacao
        //{
        //    get { return _internacao; }
        //    set { _internacao = value; }
        //}

        private string _nomeComboLocal;
        [Category("Hac")]
        [Description("Nome do objeto combo referente ao Local. Se este campo não está preenchido, ele pega todo objeto HacCmbLocal")]            
        public string NomeComboLocal
        {
            get { return _nomeComboLocal; }
            set { _nomeComboLocal = value; }
        }

        private string _nomeComboSetor;
        [Category("Hac")]
        [Description("Nome do objeto combo referente ao Setor. Se este campo não está preenchido, ele pega todo objeto HacCmbSetor")]            
        public string NomeComboSetor
        {
            get { return _nomeComboSetor; }
            set { _nomeComboSetor = value; }
        }

        private bool _unidadeusuario;
        [Category("Hac")]
        [DefaultValue(false)]
        [DisplayName("Filtra Unidades Usuário")]
        [Description("Filtra unidades que usuário tem acesso")]
        public bool UnidadeUsuario
        {
            get { return _unidadeusuario; }
            set { _unidadeusuario = value; }
        }

        private decimal _idtusuario;
        [Category("Hac")]
        [Description("ID do usuário conectado")]
        public decimal IdtUsuario
        {
            get { return _idtusuario; }
            set { _idtusuario = value; }
        }


        byte Inicio;

        private IUnidade _unidade;
        protected IUnidade Unidade
        {
            get { return _unidade != null ? _unidade : _unidade = (IUnidade)GlobalComponentes.Componentes.GetObject(typeof(IUnidade)); }
        }

        private IUsuarioUnidade _serunidadeusuario;
        protected IUsuarioUnidade ServicoUnidadeUsuario
        {
            get { return _serunidadeusuario != null ? _serunidadeusuario : _serunidadeusuario = (IUsuarioUnidade)GlobalComponentes.Seguranca.GetObject(typeof(IUsuarioUnidade)); }
        }

        
        public HacCmbUnidade()
        {
            InitializeComponent();
        }

        public HacCmbUnidade(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

        }

        public void Carregaunidade()
        {
            UnidadeDTO dtoUnidade = new UnidadeDTO();
            Inicio = 1;
            this.ValueMember = UnidadeDTO.FieldNames.Idt;
            this.DisplayMember = UnidadeDTO.FieldNames.DsUnidade;
            if (_gravaAtendimento)
            {
                dtoUnidade.GravaAtendimentoFL.Value = "S";
            }

            if (_somenteAtiva)
            {
                dtoUnidade.Status.Value = "A";
            }

            //if (_internacao)
            //    this.DataSource = Unidade.ListarUnidadeDoLocal(dtoUnidade, 29); //29 = Local Internado          
            //else
            if (_unidadeusuario)
            {
                if (IdtUsuario == 0)
                {
                    MessageBox.Show("Falta ID do usuário", "Dentro Componente", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;

                }
                UsuarioUnidadeDTO dtoUUnidade = new UsuarioUnidadeDTO();
                dtoUUnidade.IdtUsuario.Value = IdtUsuario;
                this.DataSource = ServicoUnidadeUsuario.Sel(dtoUUnidade);
            }
            else
                this.DataSource = Unidade.Sel(dtoUnidade);

            this.IniciaLista();

            if (!_somenteUnidade)
            {
                Inicio = 0;
                Form frm = this.FindForm();
                object obj = FindLocal(frm.Controls);
                if (obj != null)
                {
                    ((HacCmbLocal)obj).Limpa();
                }

                Form frmSetor = this.FindForm();
                object objSetor = FindSetor(frmSetor.Controls);
                if (objSetor != null)
                {
                    ((HacCmbSetor)objSetor).Limpa();
                }
            }
        }

        private HacCmbLocal FindLocal(ControlCollection controls)
        {
            Control control = null;
            foreach (Control ctr in controls)
            {
                if ((ctr is HacCmbLocal && string.IsNullOrEmpty(this.NomeComboLocal)) ||
                    (ctr is HacCmbLocal && ctr.Name == this.NomeComboLocal))
                {
                    control = ctr;
                    break;
                }
                else
                {
                    control = FindLocal(ctr.Controls);
                    if (control != null) break;
                }
            }
            return control == null ? null : (HacCmbLocal)control;              
        }

        private HacCmbSetor FindSetor(ControlCollection controls)
        {
            Control control = null;
            foreach (Control ctr in controls)
            {
                if ((ctr is HacCmbSetor && string.IsNullOrEmpty(this.NomeComboSetor)) ||
                    (ctr is HacCmbSetor && ctr.Name == this.NomeComboSetor))
                {
                    control = ctr;
                    break;
                }
                else
                {
                    control = FindSetor(ctr.Controls);
                    if (control != null) break;
                }
            }
            return control == null ? null : (HacCmbSetor)control;         
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (!_somenteUnidade)
            {
                Form frm = this.FindForm();
                LocalAtendimentoDTO dtoLocal = new LocalAtendimentoDTO();
                object obj = FindLocal(frm.Controls);
                //ListItem item = (ListItem)this.SelectedItem;     
                if (this.SelectedIndex != -1)
                {
                    if (Inicio == 0)
                    {
                        dtoLocal.IdtUnidade.Value = Convert.ToInt32(this.SelectedValue);

                        if (obj != null)
                        {
                            ((HacCmbLocal)obj).CarregaLocal(dtoLocal);
                        }
                    }
                }
                else
                {
                    if (obj != null) ((HacCmbLocal)obj).Limpa();
                }
            }
            base.OnSelectedIndexChanged(e);
        }

        /// <summary>
        /// Funciona apenas se a propriedade Limpar = True.
        /// Limpa também os combos de Local e Setor.
        /// </summary>
        public void LimparCmbUnidade()
        {
            if (this.Limpar)
            {
                if (!_somenteUnidade)
                {
                    HacCmbSetor cmbSetor = this.FindSetor(this.FindForm().Controls);
                    HacCmbLocal cmbLocal = this.FindLocal(this.FindForm().Controls);

                    if (cmbSetor != null) cmbSetor.Limpa();
                    if (cmbLocal != null) cmbLocal.Limpa();
                }
                this.IniciaLista();
            }
        }
        public void True()
        {
            if (this.GravaAtendimento) this.Enabled = true;
        }

        /// <summary>
        /// Funciona apenas se a propriedade AlterarStatus = True
        /// </summary>
        public void False()
        {
            if (this.GravaAtendimento) this.Enabled = false;
        }

       
    }    
}