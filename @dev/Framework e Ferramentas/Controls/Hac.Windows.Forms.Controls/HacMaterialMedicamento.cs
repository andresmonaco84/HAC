using System;
using System.ComponentModel;
using System.Windows.Forms;
using HospitalAnaCosta.Services.Produto.DTO;
using HospitalAnaCosta.Services.Produto.Interface;
using Hac.Windows.Forms.Controls;
using System.Data;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacMaterialMedicamento : HacUserControl
    {
        #region OBJETOS SERVIÇO
        
        private IMaterialMedicamento _materialMedicamento;
        public IMaterialMedicamento MaterialMedicamento
        {
            get { return _materialMedicamento != null ? _materialMedicamento : _materialMedicamento = (IMaterialMedicamento)CommonServices.GetObject(typeof(IMaterialMedicamento)); }
        }

      
        #endregion

        #region [evento]
        public delegate void SelecionarDelegate(object sender, EventArgs e);
        [Category("Hac")]
        public event SelecionarDelegate Selecionar;
        [Category("Hac")]
        protected virtual void OnSelecionar(EventArgs e)
        {
            if (Selecionar != null)
            {
                Selecionar(this, e);
            }
        }
        #endregion

        public HacMaterialMedicamento()
        {
            InitializeComponent();            
        }

        ~HacMaterialMedicamento()
        {
            try
            {
                Dispose();
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }

        public void Inicializar()
        {
            //O nome do procedimento é apenas exibição
            txtCodigoProduto.Enabled = true;
            txtDescricaoProduto.Enabled = false;
            btnPesquisarProduto.Enabled = true;

            txtDescricaoProduto.Text = string.Empty;
            txtCodigoProduto.Text = string.Empty;

            dtoMaterialMedicamento = null;
            if (this.InicializarTodosRegistros && TodosProdutos == null) TodosProdutos = this.PesquisarProduto();
        }

        public void Carregar(decimal id)
        {
            dtoMaterialMedicamento = new MaterialMedicamentoDTO();
            dtoMaterialMedicamento.Idt.Value = id;
            dtoMaterialMedicamento = MaterialMedicamento.SelChave(dtoMaterialMedicamento);

            txtCodigoProduto.Text = dtoMaterialMedicamento.CodMne.Value.ToString();
            txtDescricaoProduto.Text = dtoMaterialMedicamento.Descricao.Value;
        }
              

        #region PROPRIEDADES
        private bool _inicializarTodosRegistros;
        [Category("Hac")]
        public bool InicializarTodosRegistros
        {
            get { return _inicializarTodosRegistros; }
            set { _inicializarTodosRegistros = value; }            
        }

        private bool naoAjustarEdicao;
        [Category("Hac")]
        public bool NaoAjustarEdicao
        {
            get { return naoAjustarEdicao; }
            set
            {
                txtCodigoProduto.NaoAjustarEdicao = value;
                txtDescricaoProduto.NaoAjustarEdicao = value;
                naoAjustarEdicao = value;
            }
        }

        private string _diluente;
        [Category("Hac")]
        public string Diluente
        {
            get { return _diluente; }
            set { _diluente = value; }
        }

        private string _dieta;
        [Category("Hac")]
        public string Dieta
        {
            get { return _dieta; }
            set { _dieta = value; }
        }

        private string _materialPrescricao;
        [Category("Hac")]
        public string MaterialPrescricao
        {
            get { return _materialPrescricao; }
            set { _materialPrescricao = value; }
        }

        private string _medicamentosComSAL;
        [Category("Hac")]
        public string MedicamentosComSAL
        {
            get { return _medicamentosComSAL; }
            set { _medicamentosComSAL = value; }
        }
        
        private string codigoTabelaMedica;
        public string CodigoTabelaMedica
        {
            get { return codigoTabelaMedica; }
            set { codigoTabelaMedica = value; }
        }

    
        
        private string _nomeComboTabela;
        [Category("Hac")]
        [Description("Nome do objeto combo referente a Tabela. Se este campo não está preenchido, ele pega todo objeto HacCmbTabelaMedica")]
        public string NomeComboTabela
        {
            get { return _nomeComboTabela; }
            set { _nomeComboTabela = value; }
        }
        private string _nomeComboGrupo;
        [Category("Hac")]
        [Description("Nome do objeto combo referente a Grupo. Se este campo não está preenchido, ele pega todo objeto HacCmbGrupoProdutoMaterialMecicamento")]
        public string NomeComboGrupo
        {
            get { return _nomeComboGrupo; }
            set { _nomeComboGrupo = value; }
        }

         private string _nomeComboSubGrupo;
        [Category("Hac")]
        [Description("Nome do objeto combo referente a SubGrupo. Se este campo não está preenchido, ele pega todo objeto HacCmbSubGrupoMaterialMedicamento")]
        public string NomeComboSubGrupo
        {
            get { return _nomeComboSubGrupo; }
            set { _nomeComboSubGrupo = value; }
        }        

        private string tipoProduto;
        public string TipoProduto
        {
            get { return tipoProduto; }
            set { tipoProduto = value; }
        }

        private bool enabled;
        public bool Enabled
        {
            get { return enabled; }
            set
            {
                if (value)
                {
                    txtCodigoProduto.Enabled = true;
                    txtDescricaoProduto.Enabled = false;
                    btnPesquisarProduto.Enabled = true;
                }
                else
                {
                    txtCodigoProduto.Enabled = false;
                    txtDescricaoProduto.Enabled = false;
                    btnPesquisarProduto.Enabled = false;
                }

                enabled = value;
            }
        }

        private bool obrigatorio;
        public bool Obrigatorio
        {
            get { return obrigatorio; }
            set
            {
                txtCodigoProduto.Obrigatorio = value;
                obrigatorio = value;
            }
        }

        private string obrigatorioMensagem;
        public string ObrigatorioMensagem
        {
            get { return obrigatorioMensagem; }
            set
            {
                txtCodigoProduto.ObrigatorioMensagem = value;
                obrigatorioMensagem = value;
            }
        }

        private MaterialMedicamentoDTO _dtoMaterialMedicamento;
        public MaterialMedicamentoDTO dtoMaterialMedicamento
        {
            get
            {
                return _dtoMaterialMedicamento;
            }
            set
            {
                _dtoMaterialMedicamento = value;
            }
        }

        private MaterialMedicamentoDataTable _dtbMaterialMedicamento;
        public MaterialMedicamentoDataTable TodosProdutos
        {
            get
            {
                return _dtbMaterialMedicamento;
            }
            set
            {
                _dtbMaterialMedicamento = value;
            }
        }
        #endregion

        private MaterialMedicamentoDataTable PesquisarProduto()
        {
            MaterialMedicamentoDTO dtoMaterialMedicamento = new MaterialMedicamentoDTO();

            dtoMaterialMedicamento.Tabelamedica.Value = CodigoTabelaMedica;

           // if (ApenasKits) dtoMaterialMedicamento.FlagKit.Value = "S";
           // if (DiferenteDeKits) dtoMaterialMedicamento.FlagKit.Value = "N";
            
            if (txtCodigoProduto.Text != string.Empty) dtoMaterialMedicamento.CodMne.Value = txtCodigoProduto.Text;

           // if (!string.IsNullOrEmpty(CodigoCaracteristicaMatMed)) dtoMaterialMedicamento.CaracteristicaMatMed.Value = CodigoCaracteristicaMatMed;

            dtoMaterialMedicamento.FlAtivo.Value = 1;

            if (!string.IsNullOrEmpty(Diluente) && Diluente == "1")
                dtoMaterialMedicamento.FlagDiluente.Value = 1;

            if (!string.IsNullOrEmpty(Dieta) && Dieta == "1")
                dtoMaterialMedicamento.IdtSubGrupo.Value = 930;

            if (!string.IsNullOrEmpty(MaterialPrescricao) && MaterialPrescricao == "1")
                return MaterialMedicamento.ObterMaterialPrescricao(txtCodigoProduto.Text);
            else if (!string.IsNullOrEmpty(MedicamentosComSAL) && MedicamentosComSAL == "1")
                return MaterialMedicamento.ObterMedicamentosComSal(txtCodigoProduto.Text);

            return MaterialMedicamento.Sel(dtoMaterialMedicamento);
        }

        //private DataTable PesquisarProdutoDiluente()
        //{
        //    MaterialMedicamentoDTO dtoMaterialMedicamento = new MaterialMedicamentoDTO();

        //    dtoMaterialMedicamento.Tabelamedica.Value = CodigoTabelaMedica;

        //    // if (ApenasKits) dtoMaterialMedicamento.FlagKit.Value = "S";
        //    // if (DiferenteDeKits) dtoMaterialMedicamento.FlagKit.Value = "N";

        //    if (txtCodigoProduto.Text != string.Empty) dtoMaterialMedicamento.CodMne.Value = txtCodigoProduto.Text;

        //    // if (!string.IsNullOrEmpty(CodigoCaracteristicaMatMed)) dtoMaterialMedicamento.CaracteristicaMatMed.Value = CodigoCaracteristicaMatMed;
        //    if(Diluente.Length>0 && Diluente== "1")
        //        dtoMaterialMedicamento.FlagDiluente.Value = 1;

        //    dtoMaterialMedicamento.FlAtivo.Value = 1;

        //    return MaterialMedicamento.SelTodos(dtoMaterialMedicamento, Diluente);
        //}

        private void btnPesquisarProduto_Click(object sender, EventArgs e)
        {
            //if (this.dtoProduto != null && sender is Hac.Windows.Forms.Controls.HacButton) this.Inicializar();

            if (string.IsNullOrEmpty(CodigoTabelaMedica) )
            {
                MessageBox.Show("Informe a Tabela", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MaterialMedicamentoDataTable dtbMaterialMedicamento;             
            if (sender is Hac.Windows.Forms.Controls.HacButton &&
                this.InicializarTodosRegistros && TodosProdutos != null)
            {
                dtbMaterialMedicamento = TodosProdutos;
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
               // if(Diluente.Length==0)
                    dtbMaterialMedicamento = PesquisarProduto();
               // else
                  //  dtbMaterialMedicamento = (MaterialMedicamentoDataTable)PesquisarProdutoDiluente();

                Cursor.Current = Cursors.Arrow;
            }

            if (dtbMaterialMedicamento.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum Material/Medicamento encontrado.", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricaoProduto.Text = string.Empty;
                _dtoMaterialMedicamento = null;
            }
            else if (dtbMaterialMedicamento.Rows.Count == 1)
            {
                txtDescricaoProduto.DataBindings.Clear();
                txtDescricaoProduto.DataBindings.Add(new Binding("Text", dtbMaterialMedicamento, MaterialMedicamentoDTO.FieldNames.Descricao));
                _dtoMaterialMedicamento = dtbMaterialMedicamento.TypedRow(0);
                txtCodigoProduto.Text = dtoMaterialMedicamento.CodMne.Value;

            }
            else
            {
                MaterialMedicamentoDTO dtoMaterialMedicamento = Forms.FrmPesquisaMatMed.AbrirPesquisaMaterialMedicamento(dtbMaterialMedicamento,false, Diluente, MedicamentosComSAL == "1");

                if (dtoMaterialMedicamento != null)
                {
                    txtCodigoProduto.Text = dtoMaterialMedicamento.CodMne.Value;
                    txtDescricaoProduto.Text = dtoMaterialMedicamento.Descricao.Value;
                    _dtoMaterialMedicamento = dtoMaterialMedicamento;
                }
            }
            txtCodigoProduto.RetirarVermelhoCampo();
            OnSelecionar(new EventArgs());
        }

        private void txtCodigoProduto_Leave(object sender, EventArgs e)
        {
            if (txtCodigoProduto.Text != string.Empty)
            {
                btnPesquisarProduto_Click(sender, e);
            }
            else
            {
                txtDescricaoProduto.Text = string.Empty;
                _dtoMaterialMedicamento = null;
            }
            OnSelecionar(new EventArgs());
        }       
    }
}