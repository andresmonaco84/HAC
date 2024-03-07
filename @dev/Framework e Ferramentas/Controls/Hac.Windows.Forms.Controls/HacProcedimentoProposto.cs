using System;
using System.ComponentModel;
using System.Windows.Forms;
using HospitalAnaCosta.Services.Produto.DTO;
using HospitalAnaCosta.Services.Produto.Interface;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacProcedimentoProposto : HacUserControl
    {
        #region
        private IProduto _produto;
        public IProduto Produto
        {
            get { return _produto != null ? _produto : _produto = (IProduto)CommonServices.GetObject(typeof(IProduto)); }
        }
        #endregion

        public HacProcedimentoProposto()
        {
            InitializeComponent();

        }

        ~HacProcedimentoProposto()
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
            txtCodigoProcedimentoProposto.Enabled = true;
            txtDescricaoProcedimentoProposto.Enabled = false;
            btnPesquisarProcedimentoProposto.Enabled = true;

            txtDescricaoProcedimentoProposto.Text = string.Empty;
            txtCodigoProcedimentoProposto.Text = string.Empty;

            DtoProcedimentoProposto = null;
        }


        
        private bool naoAjustarEdicao;
        public bool NaoAjustarEdicao
        {
            get { return naoAjustarEdicao; }
            set
            {
                txtCodigoProcedimentoProposto.NaoAjustarEdicao = value;
                txtDescricaoProcedimentoProposto.NaoAjustarEdicao = value;
                naoAjustarEdicao = value;
            }
        }

        private bool enabled;
        public bool Enabled
        {
            get { return enabled; }
            set
            {
                if (value)
                {
                    txtCodigoProcedimentoProposto.Enabled = true;
                    txtDescricaoProcedimentoProposto.Enabled = false;
                    btnPesquisarProcedimentoProposto.Enabled = true;
                }
                else
                {
                    txtCodigoProcedimentoProposto.Enabled = false;
                    txtDescricaoProcedimentoProposto.Enabled = false;
                    btnPesquisarProcedimentoProposto.Enabled = false;
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
                txtCodigoProcedimentoProposto.Obrigatorio = value;
                obrigatorio = value;
            }
        }

        private string obrigatorioMensagem;
        public string ObrigatorioMensagem
        {
            get { return obrigatorioMensagem; }
            set
            {
                txtCodigoProcedimentoProposto.ObrigatorioMensagem = value;
                obrigatorioMensagem = value;
            }
        }

        private ProdutoDTO _DtoProcedimentoProposto;
        public ProdutoDTO DtoProcedimentoProposto
        {
            get
            {
                return _DtoProcedimentoProposto;
            }

            set
            {
                _DtoProcedimentoProposto = value;
            }
        }





        private bool apenasTUSS = false;
        [Category("Hac")]
        [Description("Traz apenas TUSS na pesquisa")]
        [DefaultValue(false)]
        public bool ApenasTuss
        {
            get { return apenasTUSS; }
            set { apenasTUSS = value; }
        }







        private ProdutoDataTable PesquisarProcedimentoProposto(int idtProcedimentoProposto)
        {
            ProdutoDTO dtoProcedimentoProposto = new ProdutoDTO();
            dtoProcedimentoProposto.Idt.Value = idtProcedimentoProposto;
            if (apenasTUSS)
            {
                dtoProcedimentoProposto.CodigoTabelaMedica.Value = "16";
            }
            return Produto.Listar(dtoProcedimentoProposto);
        }

        private ProdutoDataTable PesquisarProcedimentoProposto(string codigoProcedimentoProposto)
        {
            ProdutoDTO dtoProcedimentoProposto = new ProdutoDTO();
            dtoProcedimentoProposto.CodigoTabelaMedica.Value = "2";
            if (codigoProcedimentoProposto != null) 
                dtoProcedimentoProposto.Codigo.Value = codigoProcedimentoProposto;
            if (apenasTUSS)
            {
                dtoProcedimentoProposto.CodigoTabelaMedica.Value = "16";
            }
            return Produto.Listar(dtoProcedimentoProposto);
        }

        private void btnPesquisarProcedimentoProposto_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ProdutoDataTable dtbProcedimentoProposto = PesquisarProcedimentoProposto(null);
            Cursor.Current = Cursors.Arrow;

            if (dtbProcedimentoProposto.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum Procedimento cadastrado.", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricaoProcedimentoProposto.Text = string.Empty;
                _DtoProcedimentoProposto = null;
            }
            else
            {
                ProdutoDTO dtoProcedimentoProposto = Forms.FrmPesquisaProcedimentoProposto.AbrirPesquisaProcedimentoProposto(dtbProcedimentoProposto);

                if (dtoProcedimentoProposto != null)
                {
                    txtCodigoProcedimentoProposto.Text = dtoProcedimentoProposto.Codigo.Value;
                    txtDescricaoProcedimentoProposto.Text = dtoProcedimentoProposto.Descricao.Value;
                    _DtoProcedimentoProposto = dtoProcedimentoProposto;
                }
            }
            txtCodigoProcedimentoProposto.RetirarVermelhoCampo();
        }

        private void txtCodigoProcedimentoProposto_Leave(object sender, EventArgs e)
        {
            if (txtCodigoProcedimentoProposto.Text != string.Empty)
            {
                ProdutoDataTable dtbProcedimentoProposto = PesquisarProcedimentoProposto(txtCodigoProcedimentoProposto.Text);

                if (dtbProcedimentoProposto.Rows.Count == 0)
                {
                    MessageBox.Show("Procedimento não encontrado!", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescricaoProcedimentoProposto.Text = string.Empty;
                    _DtoProcedimentoProposto = null;
                }
                else if (dtbProcedimentoProposto.Rows.Count == 1)
                {
                    txtDescricaoProcedimentoProposto.DataBindings.Clear();
                    txtDescricaoProcedimentoProposto.DataBindings.Add(new Binding("Text", dtbProcedimentoProposto, ProdutoDTO.FieldNames.Descricao));
                    _DtoProcedimentoProposto = dtbProcedimentoProposto.TypedRow(0);
                }
            }
            else
            {
                txtDescricaoProcedimentoProposto.Text = string.Empty;
                _DtoProcedimentoProposto = null;
            }
        }

        public void CarregarProcedimentoProposto(ProdutoDTO dtoProcedimentoProposto)
        {
            if (!dtoProcedimentoProposto.Idt.Value.IsNull)
            {
                ProdutoDataTable dtbProcedimentoProposto = PesquisarProcedimentoProposto(Convert.ToInt32(dtoProcedimentoProposto.Idt.Value));

                if (dtbProcedimentoProposto.Rows.Count > 0)
                {
                    txtDescricaoProcedimentoProposto.DataBindings.Clear();
                    txtDescricaoProcedimentoProposto.DataBindings.Add(new Binding("Text", dtbProcedimentoProposto, ProdutoDTO.FieldNames.Descricao));

                    txtCodigoProcedimentoProposto.DataBindings.Clear();
                    txtCodigoProcedimentoProposto.DataBindings.Add(new Binding("Text", dtbProcedimentoProposto, ProdutoDTO.FieldNames.Codigo));

                    _DtoProcedimentoProposto = dtbProcedimentoProposto.TypedRow(0);
                }
            }
        }

        

    }
}
