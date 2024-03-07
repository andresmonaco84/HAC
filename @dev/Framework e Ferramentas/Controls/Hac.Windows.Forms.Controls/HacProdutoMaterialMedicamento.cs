using System;
using System.ComponentModel;
using System.Windows.Forms;
using HospitalAnaCosta.Services.Produto.DTO;
using HospitalAnaCosta.Services.Produto.Interface;
using Hac.Windows.Forms.Controls;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacProdutoMaterialMedicamento : HacUserControl
    {
        #region OBJETOS SERVIÇO
        
        private IMaterialMedicamento _materialMedicamento;
        public IMaterialMedicamento MaterialMedicamento
        {
            get { return _materialMedicamento != null ? _materialMedicamento : _materialMedicamento = (IMaterialMedicamento)CommonServices.GetObject(typeof(IMaterialMedicamento)); }
        }

        private IProduto _produto;
        public IProduto Produto
        {
            get { return _produto != null ? _produto : _produto = (IProduto)CommonServices.GetObject(typeof(IProduto)); }
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

        public HacProdutoMaterialMedicamento()
        {
            InitializeComponent();            
        }

        ~HacProdutoMaterialMedicamento()
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

            dtoProduto = null;
            if (this.InicializarTodosRegistros && TodosProdutos == null) TodosProdutos = this.PesquisarProduto();
        }

        public void Carregar(decimal id)
        {
            dtoProduto = new ProdutoDTO();
            dtoProduto.Idt.Value = id;
            dtoProduto = Produto.Pesquisar(dtoProduto);

            txtCodigoProduto.Text = dtoProduto.Mnemonico.Value.ToString();
            txtDescricaoProduto.Text = dtoProduto.Descricao.Value;
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

        private bool apenasKits;
        [Category("Hac")]
        [Description("Traz apenas kits na pesquisa")]
        public bool ApenasKits
        {
            get { return apenasKits; }
            set { apenasKits = value; }            
        }

        private bool diferenteDeKits;
        [Category("Hac")]
        [Description("Traz tudo que não é kit na pesquisa")]
        public bool DiferenteDeKits
        {
            get { return diferenteDeKits; }
            set { diferenteDeKits = value; }
        }
        
        private string codigoTabelaMedica;
        public string CodigoTabelaMedica
        {
            get { return codigoTabelaMedica; }
            set { codigoTabelaMedica = value; }
        }

        private string codigoCaracteristicaMatMed;
        public string CodigoCaracteristicaMatMed
        {
            get { return codigoCaracteristicaMatMed; }
            set { codigoCaracteristicaMatMed = value; }
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

        private ProdutoDTO _dtoProduto;
        public ProdutoDTO dtoProduto
        {
            get
            {
                return _dtoProduto;
            }
            set
            {
                _dtoProduto = value;
            }
        }

        private ProdutoDataTable _dtbProduto;
        public ProdutoDataTable TodosProdutos
        {
            get
            {
                return _dtbProduto;
            }
            set
            {
                _dtbProduto = value;
            }
        }
        #endregion

        private ProdutoDataTable PesquisarProduto()
        {
            ProdutoDTO dtoProduto = new ProdutoDTO();
            
            dtoProduto.CodigoTabelaMedica.Value = CodigoTabelaMedica;

            if (ApenasKits) dtoProduto.FlagKit.Value = "S";
            if (DiferenteDeKits) dtoProduto.FlagKit.Value = "N";

            if (txtCodigoProduto.Text != string.Empty) dtoProduto.Mnemonico.Value = txtCodigoProduto.Text;

            if (!string.IsNullOrEmpty(CodigoCaracteristicaMatMed)) dtoProduto.CaracteristicaMatMed.Value = CodigoCaracteristicaMatMed;

            dtoProduto.Status.Value = "A";

            return Produto.Listar(dtoProduto);
        }

        private void btnPesquisarProduto_Click(object sender, EventArgs e)
        {
            //if (this.dtoProduto != null && sender is Hac.Windows.Forms.Controls.HacButton) this.Inicializar();

            if (string.IsNullOrEmpty(CodigoTabelaMedica) )
            {
                MessageBox.Show("Informe a Tabela", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ProdutoDataTable dtbProduto;             
            if (sender is Hac.Windows.Forms.Controls.HacButton &&
                this.InicializarTodosRegistros && TodosProdutos != null)
            {
                dtbProduto = TodosProdutos;
            }
            else
            {
                Cursor.Current = Cursors.WaitCursor;
                dtbProduto = PesquisarProduto();
                Cursor.Current = Cursors.Arrow;
            }

            if (dtbProduto.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum Material/Medicamento encontrado.", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricaoProduto.Text = string.Empty;
                _dtoProduto = null;
            }
            else if (dtbProduto.Rows.Count == 1)
            {
                txtDescricaoProduto.DataBindings.Clear();
                txtDescricaoProduto.DataBindings.Add(new Binding("Text", dtbProduto, ProdutoDTO.FieldNames.Descricao));
                _dtoProduto = dtbProduto.TypedRow(0);
                txtCodigoProduto.Text = dtoProduto.Mnemonico.Value;

            }
            else
            {
                ProdutoDTO dtoProduto = Forms.FrmPesquisaMaterialMedicamento.AbrirPesquisaMaterialMedicamento(dtbProduto);

                if (dtoProduto != null)
                {
                    txtCodigoProduto.Text = dtoProduto.Mnemonico.Value;
                    txtDescricaoProduto.Text = dtoProduto.Descricao.Value;
                    _dtoProduto = dtoProduto;
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
                _dtoProduto = null;
            }
            OnSelecionar(new EventArgs());
        }       
    }
}