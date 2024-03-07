using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Web.UI.WebControls;
using HospitalAnaCosta.SGS.Cadastro.Interface;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using System.Windows.Forms;
using System.Data;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacCmbSetor : HacComboBox
    {
        private string _nomeComboLocal;
        [Category("Hac")]
        [Description("Nome do objeto combo referente ao Local. Se este campo não está preenchido, ele pega todo objeto HacCmbLocal")]
        public string NomeComboLocal
        {
            get { return _nomeComboLocal; }
            set { _nomeComboLocal = value; }
        }
        private bool _internacao;

        [Category("Hac")]
        public bool Internacao
        {
            get { return _internacao; }
            set { _internacao = value; }
        }

        private bool _permiteInternacao = false;
        [Description("True - Carrega Setores que Permitam Internacao")]
        [Category("Hac")]
        public bool PermiteInternacao
        {
            get { return _permiteInternacao; }
            set { _permiteInternacao = value; }
        }

        private bool _permiteLibLeito = false;
        [Description("True - Carrega Setores que Permitem Liberar Leito")]
        [Category("Hac")]
        public bool PermiteLiberarLeito
        {
            get { return _permiteLibLeito; }
            set { _permiteLibLeito = value; }
        }

        private bool _gravaAtendimento = false;
        [Category("Hac")]
        [Description("True - Carrega Setores que Permitam Atendimento")]
        public bool GravaAtendimento
        {
            get { return _gravaAtendimento; }
            set { _gravaAtendimento = value; }
        }

        private bool _controlaProntuario = false;
        [Category("Hac")]
        [Description("True - Carrega Setores que Controlam Prontuário")]
        public bool ControlaProntuario
        {
            get { return _controlaProntuario; }
            set { _controlaProntuario = value; }
        }
        private bool _movimentaPacienteInternado = false; //CAD_SET_FL_MOVIMENTAPACINT_OK
        [Description("True - Carrega Setores que Movimentam Pacientes da Internacao")]
        [Category("Hac")]
        public bool MovimentaPacienteInternado
        {
            get { return _movimentaPacienteInternado; }
            set { _movimentaPacienteInternado = value; }
        }
        private bool _permiteOUmovimentaPacienteInternado = false; //CAD_SET_FL_MOVIMENTAPACINT_OK
        [Description("True - Carrega Setores que Permitem ou Movimentam Pacientes da Internacao")]
        [Category("Hac")]
        public bool PermiteOUMovimentaPacienteInternado
        {
            get { return _permiteOUmovimentaPacienteInternado; }
            set { _permiteOUmovimentaPacienteInternado = value; }
        }
        protected DataTable _dtbSetor;
        public DataTable Setores
        {
            get { return _dtbSetor; }
        }
        private ISetor _setor;
        protected ISetor Setor
        {
            get { return _setor != null ? _setor : _setor = (ISetor)CommonServices.GetObject(typeof(ISetor)); }
        }

        private IUnidade _unidade;
        protected IUnidade Unidade
        {
            get { return _unidade != null ? _unidade : _unidade = (IUnidade)CommonServices.GetObject(typeof(IUnidade)); }
        }

        public HacCmbSetor()
        {            
            InitializeComponent();
            Internacao = true;
        }
        
        public HacCmbSetor(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            Internacao = true;
            
        }
        public void CarregaSetorComOpcaoTodos(SetorDTO dtoSetor)
        { 
            Carrega( dtoSetor);

            CarregarComboComSelecioneTodos(this, _dtbSetor, SetorDTO.FieldNames.Idt, SetorDTO.FieldNames.Descricao);

            this.IniciaLista();
        }
        public void CarregaSetor(SetorDTO dtoSetor)
        {
            Carrega(dtoSetor);
            
            CarregarComboComSelecione(this, _dtbSetor, SetorDTO.FieldNames.Idt, SetorDTO.FieldNames.Descricao);

            this.IniciaLista();
        }
        private void Carrega(SetorDTO dtoSetor)
        {
            this.Limpa();

            if (!_permiteOUmovimentaPacienteInternado)
            {
                if (_permiteInternacao && !_permiteLibLeito)
                    dtoSetor.PermiteInternacao.Value = "S";
                if (_movimentaPacienteInternado)
                    dtoSetor.MovimentaPacienteInternado.Value = "S";
            }

            if (_gravaAtendimento)
                dtoSetor.GravaAtendimento.Value = "S";

            if (_controlaProntuario)
                dtoSetor.FlControleProntuario.Value = "S";

            if (_permiteLibLeito && !_permiteInternacao)
                dtoSetor.PermiteLiberarLeito.Value = "S";

            _dtbSetor = Setor.Sel(dtoSetor);

            if (_permiteLibLeito && _permiteInternacao)
            {
                DataView dv = _dtbSetor.DefaultView;
                dv.RowFilter = string.Format("{0} = 'S' or {1} = 'S'", SetorDTO.FieldNames.PermiteInternacao, SetorDTO.FieldNames.PermiteLiberarLeito);
                _dtbSetor = dv.ToTable();
            }

            if (_permiteOUmovimentaPacienteInternado)
            {
                DataView dv = _dtbSetor.DefaultView;
                dv.RowFilter = string.Format("{0} = 'S' or {1} = 'S'", SetorDTO.FieldNames.PermiteInternacao, SetorDTO.FieldNames.MovimentaPacienteInternado);
                _dtbSetor = dv.ToTable();
            }

            if (_controlaProntuario)
            {
                DataRow row = _dtbSetor.NewRow();
                row[SetorDTO.FieldNames.Idt] = "0";
                row[SetorDTO.FieldNames.Descricao] = "OUTROS";
                _dtbSetor.Rows.Add(row);
            }
        }
        
        public void CarregaSetor(Int32 idtUnidade,Int32 idtLocalAtendimento,Int32? idtSetor)
        {
            SetorDTO dtoSetor = new SetorDTO();
            dtoSetor.IdtUnidade.Value = idtUnidade;
            dtoSetor.IdtLocalAtendimento.Value = idtLocalAtendimento;
            if(idtSetor !=null)
                dtoSetor.Idt.Value=idtSetor;
            CarregaSetor(dtoSetor);
        }
        public void AdicionarDescricaoUnidadeSetor()
        {
            //SetorDataTable dtbSetor = _dtbSetor;
            DataTable dtbUnidade = Unidade.Sel(new UnidadeDTO());
            SetorDTO dto;
            string filtroId, unidade;            

            foreach (DataRow row in _dtbSetor.Rows)
            {
                dto = (SetorDTO)row;                
                filtroId = string.Format("{0}={1}", UnidadeDTO.FieldNames.Idt, dto.IdtUnidade.Value.ToString());
                unidade = dtbUnidade.Select(filtroId)[0][UnidadeDTO.FieldNames.DsUnidade].ToString();                
                row[SetorDTO.FieldNames.Descricao] = string.Format("{0} - {1}", unidade, dto.Descricao.Value);
            }

            CarregarComboComSelecione(this, 
                                      new DataView(_dtbSetor, string.Empty, string.Format("{0}, {1}", UnidadeDTO.FieldNames.DsUnidade, SetorDTO.FieldNames.Descricao), DataViewRowState.CurrentRows).ToTable(),
                                      SetorDTO.FieldNames.Idt, 
                                      SetorDTO.FieldNames.Descricao);
            
            //Este código abaixo não ordena pela unidade, e sim apenas pelo setor
            //foreach (HacFramework.Windows.Helpers.ListItem item in (List<HacFramework.Windows.Helpers.ListItem>)this.DataSource)
            //{
            //    if (item.Key != "-1")
            //    {
            //        filtroId = string.Format("{0}={1}", SetorDTO.FieldNames.Idt, item.Key);
            //        filtroId = string.Format("{0}={1}", UnidadeDTO.FieldNames.Idt, dtbSetor.Select(filtroId)[0][SetorDTO.FieldNames.IdtUnidade].ToString());
            //        unidade = dtbUnidade.Select(filtroId)[0][UnidadeDTO.FieldNames.DsUnidade].ToString();
            //        item.Value = string.Format("{0} - {1}", unidade, item.Value);
            //        //item.Value = string.Format("{0} - {1}", item.Value, unidade);
            //    }                
            //}            
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

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            HacCmbLocal cmbLocal = FindLocal(this.FindForm().Controls);

            if (cmbLocal != null)
            {
                if (cmbLocal.SelectedIndex == -1)
                {
                    if (this.SelectedIndex == -1) this.Limpa();
                }                
            }            
            
            base.OnSelectedIndexChanged(e);
        }

        /// <summary>
        /// Funciona apenas se a propriedade Limpar = True.        
        /// </summary>
        public void LimparCmbSetor()
        {
            if (this.Limpar) this.LimparComboBox();
        }

        /// <summary>
        /// Zera o DataSource e os itens deste combo
        /// </summary>
        public void Limpa()
        {
            this.DataSource = null;
            this.Items.Clear();
            this.Text = string.Empty;
        }
    }
}