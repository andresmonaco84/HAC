using System;
using System.Data;
using System.ComponentModel;
using System.Windows.Forms;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Cadastro.Interface;
using HospitalAnaCosta.SGS.Cadastro.DTO;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacCmbUnidade_ : HacComboBox
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

        private bool _fatura = false;
        [Category("Hac")]
        [Description("True - Carrega Unidades que faturam")]
        public bool Fatura
        {
            get { return _fatura; }
            set { _fatura = value; }
        }

        private bool _internacao = false;
        [Category("Hac")]
        [Description("True - Carrega Unidades que Gravam Internacao, que estao associadas ao local Internacao")]
        public bool Internacao
        {
            get { return _internacao; }
            set { _internacao = value; }
        }

        private string _nomeComboLocal;
        [Category("Hac")]
        [Description("Nome do objeto combo referente ao Local. Se este campo não está preenchido, ele pega todo objeto HacCmbLocal_")]            
        public string NomeComboLocal
        {
            get { return _nomeComboLocal; }
            set { _nomeComboLocal = value; }
        }

        private string _nomeComboSetor;
        [Category("Hac")]
        [Description("Nome do objeto combo referente ao Setor. Se este campo não está preenchido, ele pega todo objeto HacCmbSetor_")]            
        public string NomeComboSetor
        {
            get { return _nomeComboSetor; }
            set { _nomeComboSetor = value; }
        }

        private Decimal _idtConvenio = 0;
        [Category("Hac")]
        [Description("Se maior que 0, listar apenas as unidades que tenham relacionamento com o convênio")]
        public Decimal IdtConvenio
        {
            get { return _idtConvenio; }
            set { _idtConvenio = value; }
        }

        byte Inicio;
        private IUnidade _unidade;
        protected IUnidade Unidade
        {
            get { return _unidade != null ? _unidade : _unidade = (IUnidade)CommonServices.GetObject(typeof(IUnidade)); }
        }

        private IAssociacaoConvenioUnidade _assConvUnidade;
        protected IAssociacaoConvenioUnidade AssConvenioUnidade
        {
            get { return _assConvUnidade != null ? _assConvUnidade : _assConvUnidade = (IAssociacaoConvenioUnidade)CommonServices.GetObject(typeof(IAssociacaoConvenioUnidade)); }
        }

        public HacCmbUnidade_()
        {
            InitializeComponent();
        }

        public HacCmbUnidade_(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

        }

        public void Carregaunidade()
        {
            UnidadeDTO dtoUnidade = new UnidadeDTO();
            DataTable dtb = new DataTable();
            Inicio = 1;

            if (_gravaAtendimento)
            {
                dtoUnidade.GravaAtendimentoFL.Value = "S";
            }

            if (_fatura)
            {
                dtoUnidade.FaturaUnidadeFL.Value = "S";
            }

            if (_somenteAtiva)
            {
                dtoUnidade.Status.Value = "A";
            }

            if (_internacao)
                dtb = Unidade.ListarUnidadeDoLocal(dtoUnidade, 29); //29 = Local Internado    
            else if (IdtConvenio > 0)
            {
                dtb = AssConvenioUnidade.ListarUnidadesConvenio((int)IdtConvenio);
                if (_somenteAtiva)
                {
                    dtb = new DataView(dtb,
                                       string.Format("{0} = 'A'", UnidadeDTO.FieldNames.Status),
                                       string.Empty,
                                       DataViewRowState.CurrentRows).ToTable();
                    dtb = (DataTable)BasicFunctions.ValidarVigencia(AssociacaoConvenioUnidadeDTO.FieldNames.DataInicioVigencia, AssociacaoConvenioUnidadeDTO.FieldNames.DataFimVigencia, dtb);
                }
            }
            else
                //this.DataSource = Unidade.Sel(dtoUnidade);
                dtb = Unidade.Sel(dtoUnidade);

            CarregarComboComSelecione(this, dtb, UnidadeDTO.FieldNames.Idt, UnidadeDTO.FieldNames.DsUnidade);

            this.IniciaLista();

            if (!_somenteUnidade)
            {
                Inicio = 0;
                Form frm = this.FindForm();
                object obj = FindLocal(frm.Controls);
                if (obj != null)
                {
                    ((HacCmbLocal_)obj).Limpa();
                }

                Form frmSetor = this.FindForm();
                object objSetor = FindSetor(frmSetor.Controls);
                if (objSetor != null)
                {
                    ((HacCmbSetor_)objSetor).Limpa();
                }
            }
        }

        private HacCmbLocal_ FindLocal(ControlCollection controls)
        {
            Control control = null;
            foreach (Control ctr in controls)
            {
                if ((ctr is HacCmbLocal_ && string.IsNullOrEmpty(this.NomeComboLocal)) ||
                    (ctr is HacCmbLocal_ && ctr.Name == this.NomeComboLocal))
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
            return control == null ? null : (HacCmbLocal_)control;              
        }

        private HacCmbSetor_ FindSetor(ControlCollection controls)
        {
            Control control = null;
            foreach (Control ctr in controls)
            {
                if ((ctr is HacCmbSetor_ && string.IsNullOrEmpty(this.NomeComboSetor)) ||
                    (ctr is HacCmbSetor_ && ctr.Name == this.NomeComboSetor))
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
            return control == null ? null : (HacCmbSetor_)control;         
        }

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            if (!_somenteUnidade)
            {
                Form frm = this.FindForm();
                
                LocalAtendimentoDTO dtoLocal = new LocalAtendimentoDTO();
                SetorDTO dtoSetor = new SetorDTO();

                object obj = FindLocal(frm.Controls);
                object obj1 = FindSetor(frm.Controls);

                if (this.SelectedIndex != -1)
                {
                    if (Inicio == 0)
                    {
                        dtoLocal.IdtUnidade.Value = Convert.ToInt32(this.SelectedValue);
                        dtoLocal.AtivoOK.Value = "S";

                        if (obj != null)
                        {
                            ((HacCmbLocal_)obj).CarregaLocal(dtoLocal);
                        }
                        if (obj1 != null)
                        {
                            if (!dtoLocal.IdtUnidade.Value.IsNull)
                            {
                                dtoSetor.IdtUnidade.Value = dtoLocal.IdtUnidade.Value;
                            }
                            if (!dtoLocal.Idt.Value.IsNull)
                            {
                                dtoSetor.IdtLocalAtendimento.Value = dtoLocal.Idt.Value;
                            }
                            ((HacCmbSetor_)obj1).CarregaSetor(dtoSetor);
                        }
                    }
                }
                else
                {
                    if (obj != null)
                    {
                        ((HacCmbLocal_) obj).Limpa();
                    }
                    if (obj1 != null)
                    {
                        ((HacCmbSetor_)obj1).Limpa();
                    }
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
                    HacCmbSetor_ cmbSetor = this.FindSetor(this.FindForm().Controls);
                    HacCmbLocal_ cmbLocal = this.FindLocal(this.FindForm().Controls);

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