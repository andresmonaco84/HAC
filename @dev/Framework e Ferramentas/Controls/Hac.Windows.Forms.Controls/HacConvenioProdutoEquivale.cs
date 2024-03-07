using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using HospitalAnaCosta.Framework.Events;
using HospitalAnaCosta.Services.Produto.DTO;
using HospitalAnaCosta.Services.Produto.Interface;
using HospitalAnaCosta.SGS.Cadastro.Interface;

using HospitalAnaCosta.SGS.Cadastro;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacConvenioProdutoEquivale : HacUserControl
    {
        #region

        private IConvenioProdutoEquivalencia _convenioProdutoEquivalencia;
        public IConvenioProdutoEquivalencia ConvenioProdutoEquivalencia
        {
            get { return _convenioProdutoEquivalencia != null ? _convenioProdutoEquivalencia : _convenioProdutoEquivalencia = (IConvenioProdutoEquivalencia)CommonServices.GetObject(typeof(IConvenioProdutoEquivalencia)); }
        }
        #endregion

        public HacConvenioProdutoEquivale()
        {
            InitializeComponent();
        }

        ~HacConvenioProdutoEquivale()
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
            txtCodigoProcedimento.Enabled = true;
            txtDescricaoProcedimento.Enabled = false;
            btnPesquisarProcedimento.Enabled = true;

            txtDescricaoProcedimento.Text = string.Empty;
            txtCodigoProcedimento.Text = string.Empty;

            DtoProcedimento = null;
           // IdtConvenio = null;
            CodigoTabelaMedicaDestino = string.Empty;
            CodigoTabelaMedicaOrigem = string.Empty;
            CodigoEspecialidadeProcedimento = string.Empty;
            CodigoGrupoProcedimento = null;
            TipoProduto = string.Empty;
            //IdtLocal = null;
           // IdtProdutoOrigem = null;
            //IdtProdutoDestino = null;
        }


        #region
        private bool naoAjustarEdicao;
        public bool NaoAjustarEdicao
        {
            get { return naoAjustarEdicao; }
            set
            {
                txtCodigoProcedimento.NaoAjustarEdicao = value;
                txtDescricaoProcedimento.NaoAjustarEdicao = value;
                naoAjustarEdicao = value;
            }
        }

       
        //private bool _convenioProdutoEquivale = false;
        //[Category("Hac")]
        //[Description("True - carrega produtos destino da ass. TB_ASS_CPE_CONV_PROD_EQUIVALE que estejam vigentes, conforme tabela,local,convenio selecionados.")]
        //public bool ConvenioProdutoEquivaleDestino
        //{
        //    get { return _convenioProdutoEquivale; }
        //    set { _convenioProdutoEquivale = value; }
        //}
        private string codigoTabelaMedicaDestino;
        public string CodigoTabelaMedicaDestino
        {
            get { return codigoTabelaMedicaDestino; }
            set { codigoTabelaMedicaDestino = value; }
        }

        private string codigoTabelaMedicaOrigem;
        public string CodigoTabelaMedicaOrigem
        {
            get { return codigoTabelaMedicaOrigem; }
            set { codigoTabelaMedicaOrigem = value; }
        }

        private string codigoEspecialidadeProcedimento;
        public string CodigoEspecialidadeProcedimento
        {
            get { return codigoEspecialidadeProcedimento; }
            set { codigoEspecialidadeProcedimento = value; }
        }

        private string codigoGrupoProcedimento;
        public string CodigoGrupoProcedimento
        {
            get { return codigoGrupoProcedimento; }
            set { codigoGrupoProcedimento = value; }
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
                    txtCodigoProcedimento.Enabled = true;
                    txtDescricaoProcedimento.Enabled = false;
                    btnPesquisarProcedimento.Enabled = true;
                }
                else
                {
                    txtCodigoProcedimento.Enabled = false;
                    txtDescricaoProcedimento.Enabled = false;
                    btnPesquisarProcedimento.Enabled = false;
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
                txtCodigoProcedimento.Obrigatorio = value;
                obrigatorio = value;
            }
        }

        private string obrigatorioMensagem;
        public string ObrigatorioMensagem
        {
            get { return obrigatorioMensagem; }
            set
            {
                txtCodigoProcedimento.ObrigatorioMensagem = value;
                obrigatorioMensagem = value;
            }
        }

        private ConvenioProdutoEquivalenciaDTO _DtoProcedimento;
        public ConvenioProdutoEquivalenciaDTO DtoProcedimento
        {
            get
            {
                return _DtoProcedimento;
            }

            set
            {
                _DtoProcedimento = value;
            }
        }

        private int idtConvenio;
        public int IdtConvenio
        {
            get { return idtConvenio; }
            set { idtConvenio = value; }
        }
        private int idtLocal;
        public int IdtLocal
        {
            get { return idtLocal; }
            set { idtLocal = value; }
        }
        private int idtProdutoOrigem;
        public int IdtProdutoOrigem
        {
            get { return idtProdutoOrigem; }
            set { idtProdutoOrigem = value; }
        }
        private int idtProdutoDestino;
        public int IdtProdutoDestino
        {
            get { return idtProdutoDestino; }
            set { idtProdutoDestino = value; }
        }
        private DataRow rowResultado;
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


        private DataTable PesquisarConvenioProcedimentoEquivale(int idtProcedimento)
        {
            if (IdtConvenio > 0 && IdtLocal > 0)
            {
                return ConvenioProdutoEquivalencia.ListarVigentes(null, idtProcedimento, null, null, IdtConvenio, IdtLocal, null, codigoTabelaMedicaDestino);
            }
            else
            {
                return ConvenioProdutoEquivalencia.ListarVigentes(null, idtProcedimento, null, null, null, null, null, codigoTabelaMedicaDestino);
            }
           
        }

        private DataTable PesquisarConvenioProcedimentoEquivale(string codigoProcedimento)
        {
            if (IdtConvenio > 0 && IdtLocal > 0)
            {
                return ConvenioProdutoEquivalencia.ListarVigentes(null, null, null, codigoProcedimento, IdtConvenio, IdtLocal, null, codigoTabelaMedicaDestino);            
            }
            else
            {
                return ConvenioProdutoEquivalencia.ListarVigentes(null, null, null, codigoProcedimento, null, null, null, codigoTabelaMedicaDestino);            
            }
            
        }

        private void btnPesquisarProcedimento_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataTable dtbConvenioProdutoEquivale = PesquisarConvenioProcedimentoEquivale(null);            
            Cursor.Current = Cursors.Arrow;

            if (dtbConvenioProdutoEquivale.Rows.Count == 0)
            {
                MessageBox.Show("Nenhum Procedimento cadastrado.", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricaoProcedimento.Text = string.Empty;
                _DtoProcedimento = null;
            }
            else
            {
                rowResultado = Forms.FrmPesquisaConvenioProdutoEquivale.AbrirPesquisaConvenioProdutoEquivalencia(dtbConvenioProdutoEquivale);
                
                if (rowResultado != null)
                {
                    txtCodigoProcedimento.Text = rowResultado[ConvenioProdutoEquivalenciaDTO.FieldNames.IdtProdutoDestino].ToString();
                    txtDescricaoProcedimento.Text = rowResultado["CAD_PRD_DS_DESCRICAO_DESTINO"].ToString();
                    IdtConvenio = Convert.ToInt32(rowResultado[ConvenioProdutoEquivalenciaDTO.FieldNames.IdtConvenio]);
                    IdtProdutoDestino = Convert.ToInt32(rowResultado[ConvenioProdutoEquivalenciaDTO.FieldNames.IdtProdutoDestino]);
                    IdtProdutoOrigem = Convert.ToInt32(rowResultado[ConvenioProdutoEquivalenciaDTO.FieldNames.IdtProdutoOrigem]);
                    IdtLocal = Convert.ToInt32(rowResultado[ConvenioProdutoEquivalenciaDTO.FieldNames.IdtLocalAtendimento]);
                }
            }

            OnSelecionar(new EventArgs());
            txtCodigoProcedimento.RetirarVermelhoCampo();
        }

        private void txtCodigoProcedimento_Leave(object sender, EventArgs e)
        {
            if (txtCodigoProcedimento.Text != string.Empty)
            {
                DataTable dtbConvenioProdutoEquivale = PesquisarConvenioProcedimentoEquivale(txtCodigoProcedimento.Text);

                if (dtbConvenioProdutoEquivale.Rows.Count == 0)
                {
                    MessageBox.Show("Procedimento não encontrado!", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescricaoProcedimento.Text = string.Empty;
                    _DtoProcedimento = null;
                }
                else if (dtbConvenioProdutoEquivale.Rows.Count == 1)
                {
                    txtDescricaoProcedimento.DataBindings.Clear();
                    txtDescricaoProcedimento.DataBindings.Add(new Binding("Text", dtbConvenioProdutoEquivale, "CAD_PRD_DS_DESCRICAO_DESTINO"));
                   // _DtoProcedimento = dtbConvenioProdutoEquivale.TypedRow(0);
                }
            }
            else
            {
                txtDescricaoProcedimento.Text = string.Empty;
                _DtoProcedimento = null;
            }

            OnSelecionar(new EventArgs());
        }


        public void CarregarProcedimento()
        {
            DataTable dtbConvenioProdutoEquivale = PesquisarConvenioProcedimentoEquivale(null);

            if (dtbConvenioProdutoEquivale.Rows.Count > 0)
            {
                IdtConvenio = Convert.ToInt32(rowResultado[ConvenioProdutoEquivalenciaDTO.FieldNames.IdtConvenio]);
                IdtProdutoDestino = Convert.ToInt32(rowResultado[ConvenioProdutoEquivalenciaDTO.FieldNames.IdtProdutoDestino]);
                IdtProdutoOrigem = Convert.ToInt32(rowResultado[ConvenioProdutoEquivalenciaDTO.FieldNames.IdtProdutoOrigem]);
                IdtLocal = Convert.ToInt32(rowResultado[ConvenioProdutoEquivalenciaDTO.FieldNames.IdtLocalAtendimento]);
            }
        }

        public void CarregarProcedimento(int idtProduto)
        {
            if (!DtoProcedimento.IdtConvenioProdutoEquivalencia.Value.IsNull)
            {
                DataTable dtbProcedimento;
                dtbProcedimento = PesquisarConvenioProcedimentoEquivale(idtProduto);

                if (dtbProcedimento.Rows.Count > 0)
                {
                    txtDescricaoProcedimento.DataBindings.Clear();
                    txtDescricaoProcedimento.DataBindings.Add(new Binding("Text", dtbProcedimento, "CAD_PRD_DS_DESCRICAO_DESTINO"));

                    txtCodigoProcedimento.DataBindings.Clear();
                    txtCodigoProcedimento.DataBindings.Add(new Binding("Text", dtbProcedimento, "CAD_PRD_ID_DESTINO"));

                    IdtConvenio = Convert.ToInt32(rowResultado[ConvenioProdutoEquivalenciaDTO.FieldNames.IdtConvenio]);
                    IdtProdutoDestino =Convert.ToInt32( rowResultado[ConvenioProdutoEquivalenciaDTO.FieldNames.IdtProdutoDestino]);
                    IdtProdutoOrigem = Convert.ToInt32(rowResultado[ConvenioProdutoEquivalenciaDTO.FieldNames.IdtProdutoOrigem]);
                    IdtLocal = Convert.ToInt32(rowResultado[ConvenioProdutoEquivalenciaDTO.FieldNames.IdtLocalAtendimento]);
                }
            }
        }
    }
}
