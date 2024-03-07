using System;
using System.ComponentModel;
using HospitalAnaCosta.SGS.Cadastro.Interface;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using System.Windows.Forms;

using System.Data;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacCmbSetor_ : HacComboBox
    {
        private string _nomeComboLocal;
        [Category("Hac")]
        [Description("Nome do objeto combo referente ao Local. Se este campo não está preenchido, ele pega todo objeto HacCmbLocal_")]
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

        private bool _gravaAtendimento = false;
        [Category("Hac")]
        [Description("True - Carrega Setores que Permitam Atendimento")]
        public bool GravaAtendimento
        {
            get { return _gravaAtendimento; }
            set { _gravaAtendimento = value; }
        }

        private bool _dependenciaUnidade = false;
        [Category("Hac")]
        [Description("True - Não carrega Setor antes de selecionar Unidade. False - Carrega Setor independente de selecionar Unidade.")]
        public bool DependenciaUnidade
        {
            get { return _dependenciaUnidade; }
            set { _dependenciaUnidade = value; }
        }

        private bool _dependenciaLocal = false;
        [Category("Hac")]
        [Description("True - Não carrega Setor antes de selecionar Local. False - Carrega Setor independente de selecionar Local.")]
        public bool DependenciaLocal
        {
            get { return _dependenciaLocal; }
            set { _dependenciaLocal = value; }
        }

        private bool _distinct = false;
        [Category("Hac")]
        [Description("True - Carrega Setor usando distinct. False - Carrega Setor sem usar distinct.")]
        public bool Distinct
        {
            get { return _distinct; }
            set { _distinct = value; }
        }

        protected SetorDataTable _dtbSetor;
        public SetorDataTable Setores
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

        public HacCmbSetor_()
        {            
            InitializeComponent();
            Internacao = true;
        }
        
        public HacCmbSetor_(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
            Internacao = true;
            
        }
        public void CarregaSetor(SetorDTO dtoSetor)
        {
            this.Limpa();
            
            DataTable _dtbSetorDistinct = new DataTable();
            
            DataTable dtbSetorDistinct = new DataTable();
            
            if (_gravaAtendimento)            
                dtoSetor.GravaAtendimento.Value = "S";

            _dtbSetor = Setor.Sel(dtoSetor);

            if (_distinct)
            {
                _dtbSetorDistinct = SelectDistinct("_dtbSetor", _dtbSetor, SetorDTO.FieldNames.Idt, SetorDTO.FieldNames.Descricao);
                CarregarComboComSelecione(this, _dtbSetorDistinct, SetorDTO.FieldNames.Idt, SetorDTO.FieldNames.Descricao);
            }
            else
            {
                CarregarComboComSelecione(this, _dtbSetor, SetorDTO.FieldNames.Idt, SetorDTO.FieldNames.Descricao);
            }

            this.IniciaLista();
        }



        #region "Distinct"
        public DataSet ds;
        public DataTable SelectDistinct(string TableName, DataTable SourceTable, string FieldName1, string FieldName2)
        {
            DataTable dt = new DataTable(TableName);
            dt.Columns.Add(FieldName1, SourceTable.Columns[FieldName1].DataType); //idt
            dt.Columns.Add(FieldName2, SourceTable.Columns[FieldName2].DataType); //descricao

            object LastValue = null;
            foreach (DataRow dr in SourceTable.Select("", FieldName2))
            {
                if (LastValue == null || !(ColumnEqual(LastValue, dr[FieldName2])))
                {
                    LastValue = dr[FieldName2];
                    dt.Rows.Add(new object[] {dr[FieldName1], dr[FieldName2]});
                }
            }
            if (ds != null)
                ds.Tables.Add(dt);
            return dt;
        }
        private bool ColumnEqual(object A, object B)
        {

            // Compares two values to see if they are equal. Also compares DBNULL.Value.
            // Note: If your DataTable contains object fields, then you must extend this
            // function to handle them in a meaningful way if you intend to group on them.

            if (A == DBNull.Value && B == DBNull.Value) //  both are DBNull.Value
                return true;
            if (A == DBNull.Value || B == DBNull.Value) //  only one is DBNull.Value
                return false;
            return (A.Equals(B));  // value type standard comparison
        }
        #endregion




        public void AdicionarDescricaoUnidadeSetor()
        {
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

        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            HacCmbLocal_ cmbLocal = FindLocal(this.FindForm().Controls);

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