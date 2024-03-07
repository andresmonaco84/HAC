using System;
using System.ComponentModel;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Cadastro.Interface;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using HospitalAnaCosta.Framework;

namespace Hac.Windows.Forms.Controls
{
    public partial class HacClinica : HacUserControl
    {
        private bool pesquisarTodosStatus = false;

        /// <summary>
        /// Clinica
        /// </summary>
        private IClinica _Clinica;
        public IClinica Clinica
        {
            get
            {
                return _Clinica != null ? _Clinica : _Clinica =
                    (IClinica)CommonServices.GetObject(typeof(IClinica));
            }
        }

        public HacClinica()
        {
            InitializeComponent();

            txtCodigoClinica.NaoAjustarEdicao = true;
            txtDescricaoClinica.NaoAjustarEdicao = true;
            this.Limpar = true;
        }

        ~HacClinica()
        {
            try
            {
                //_CommonServices = null;
                _Clinica = null;
                _DtoClinica = null;
                Dispose();
            }
            finally
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
            }
        }

        [Category("Hac")]
        [Description("Estado Codigo Clinica")]
        public bool EstadoCodigoClinica
        {
            get { return txtCodigoClinica.Enabled; }
        }

        public delegate void PesquisarDelegate(object sender, EventArgs e);

        [Category("Hac")]
        public event PesquisarDelegate Pesquisar;

        [Category("Hac")]
        protected virtual void OnPesquisar(CancelEventArgs e)
        {
            if (Pesquisar != null)
            {

                Pesquisar(this, e);
            }
        }

        public void Inicializar()
        {
            //O nome do procedimento é apenas exibição
            txtCodigoClinica.Enabled = true;
            btnPesquisarClinica.Enabled = true;
            txtDescricaoClinica.Enabled = false;            
            txtCodigoClinica.Text = string.Empty;
            txtDescricaoClinica.Text = string.Empty;

            _DtoClinica = null;
        }

        public void Inicializar(bool pesquisarTodosStatus)
        {
            Inicializar();
            this.pesquisarTodosStatus = pesquisarTodosStatus;
        }

        public void Focus()
        {
            txtCodigoClinica.Focus();
        }

        private bool enabled;

        public bool Enabled
        {
            get { return enabled; }
            set
            {
                if (value)
                {
                    txtCodigoClinica.Enabled = true;
                    btnPesquisarClinica.Enabled = true;
                    txtDescricaoClinica.Enabled = false;
                }
                else
                {
                    txtCodigoClinica.Enabled = false;
                    btnPesquisarClinica.Enabled = false;
                    txtDescricaoClinica.Enabled = false;
                }
                enabled = value;
            }
        }
                
        private bool obrigatorio;
        [Category("Hac")]
        public bool Obrigatorio
        {
            get { return obrigatorio; }
            set
            {
                txtCodigoClinica.Obrigatorio = value;              
                obrigatorio = value;
            }
        }

        private string obrigatorioMensagem;
        [Category("Hac")]
        public string ObrigatorioMensagem
        {
            get { return obrigatorioMensagem; }
            set
            {
                txtCodigoClinica.ObrigatorioMensagem = value;
                obrigatorioMensagem = value;
            }
        }

        private bool naoAjustarEdicao;
        [Category("Hac")]
        public bool NaoAjustarEdicao
        {
            get { return naoAjustarEdicao; }
            set
            {
                txtCodigoClinica.NaoAjustarEdicao = value;
                txtDescricaoClinica.NaoAjustarEdicao = value;
                naoAjustarEdicao = value;
            }
        }

        private bool limpar;
        [Category("Hac")]
        public bool Limpar
        {
            get { return limpar; }
            set
            {
                txtCodigoClinica.Limpar = value;
                txtDescricaoClinica.Limpar = value;
                limpar = value;
            }
        }

        private ClinicaDataTable PesquisarClinica(string codigoClinica)
        {
            // se for inicializado para trazer todos os status, não passa o "A" na pesquisa
            if (pesquisarTodosStatus)
                return PesquisarClinica(codigoClinica, null);

            return PesquisarClinica(codigoClinica, "A");
        }

        private ClinicaDataTable PesquisarClinica(string codigoClinica, string status)
        {
            ClinicaDTO dtoClinica = new ClinicaDTO();

            if (status != null && status.Length > 0)
                dtoClinica.Status.Value = status;

            if (codigoClinica != null)
                dtoClinica.CodigoClinica.Value = codigoClinica;

            ClinicaDataTable dtbClinica = (ClinicaDataTable)Clinica.Listar(dtoClinica);

            return dtbClinica;
        }
        private ClinicaDTO PesquisarClinica(decimal idtClinica)
        {
            ClinicaDataTable dtbClinica = null;
            ClinicaDTO dtoClinica = new ClinicaDTO();
 
            dtoClinica.Idt.Value = idtClinica;
            dtbClinica = (ClinicaDataTable) Clinica.Listar(dtoClinica);
            if (dtbClinica.Rows.Count > 0)
            {
                dtoClinica = dtbClinica.TypedRow(0);
            }

            return dtoClinica;
        }

        private void btnPesquisarClinica_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ClinicaDataTable dtbClinica = PesquisarClinica(null);
            Cursor.Current = Cursors.Arrow;

            if (dtbClinica.Rows.Count == 0)
            {
                MessageBox.Show("Nenhuma Clínica cadastrado.", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescricaoClinica.Text = string.Empty;
                _DtoClinica = null;
            }
            else
            {
                ClinicaDTO dtoClinica = Forms.FrmPesquisaClinica.AbrirPesquisaClinica(dtbClinica);

                if (dtoClinica != null)
                {
                    txtCodigoClinica.Text = dtoClinica.CodigoClinica.Value;
                    txtDescricaoClinica.Text = dtoClinica.Descricao.Value;

                    _DtoClinica = dtoClinica;
                    
                }
            }

            CancelEventArgs eCancel = new CancelEventArgs();
            eCancel.Cancel = !ValidarRegrasClinica();
            OnPesquisar(eCancel);

            txtCodigoClinica.RetirarVermelhoCampo();
        }

        private void txtCodigoClinica_Leave(object sender, EventArgs e)
        {
            if (txtCodigoClinica.Text != string.Empty)
            {
                ClinicaDataTable dtbClinica = PesquisarClinica(txtCodigoClinica.Text);

                if (dtbClinica.Rows.Count == 0)
                {
                    if (txtCodigoClinica.Text.Length >= 4)
                        MessageBox.Show("Clinica não encontrada!", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtDescricaoClinica.Text = string.Empty;
                    _DtoClinica = null;
                }
                else if (dtbClinica.Rows.Count == 1)
                {
                    txtDescricaoClinica.DataBindings.Clear();
                    txtDescricaoClinica.DataBindings.Add(new Binding("Text", dtbClinica, ClinicaDTO.FieldNames.Descricao));

                    _DtoClinica = dtbClinica.TypedRow(0);
                }
            }
            else
            {
                txtDescricaoClinica.Text = string.Empty;
                _DtoClinica = null;
            }

            CancelEventArgs eCancel = new CancelEventArgs();
            eCancel.Cancel = !ValidarRegrasClinica();
            OnPesquisar(eCancel);
        }        

        private void txtCodigoClinica_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigoClinica.Text != string.Empty)
            {
                ClinicaDataTable dtbClinica = PesquisarClinica(txtCodigoClinica.Text);

                if (dtbClinica.Rows.Count == 0)
                {
                    if (txtCodigoClinica.Text.Length >= 5)
                        MessageBox.Show("Clinica não encontrada!", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    txtDescricaoClinica.Text = string.Empty;
                    _DtoClinica = null;
                }
                else if (dtbClinica.Rows.Count == 1)
                {
                    txtDescricaoClinica.DataBindings.Clear();
                    txtDescricaoClinica.DataBindings.Add(new Binding("Text", dtbClinica, ClinicaDTO.FieldNames.Descricao));

                    _DtoClinica = dtbClinica.TypedRow(0);
                }
            }
            else
            {
                txtDescricaoClinica.Text = string.Empty;
                _DtoClinica = null;
            }

            CancelEventArgs eCancel = new CancelEventArgs();
            eCancel.Cancel = !ValidarRegrasClinica();
            OnPesquisar(eCancel);
        }        

        private bool ValidarRegrasClinica()
        {
            bool result = true;

            txtDescricaoClinica.ForeColor = System.Drawing.Color.Black;
            txtCodigoClinica.ForeColor = System.Drawing.Color.Black;

            if (DtoClinica != null)
            {
                switch (DtoClinica.Status.Value)
                {
                    case "I":
                        if (!pesquisarTodosStatus)
                        {
                            MessageBox.Show("Clínica Inativo.", ((FrmBase) this.FindForm()).Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            txtDescricaoClinica.ForeColor = System.Drawing.Color.Red;
                            txtCodigoClinica.ForeColor = System.Drawing.Color.Red;
                        }
                        break;
                }
            }

            return result;
        }

        public void CarregarClinica(ClinicaDTO dtoClinica)
        {
            dtoClinica = PesquisarClinica(Convert.ToDecimal(dtoClinica.Idt.Value));
            txtCodigoClinica.Text = dtoClinica.CodigoClinica.Value;

            if (dtoClinica != null)
            {                
                txtDescricaoClinica.Text = dtoClinica.Descricao.Value;
                _DtoClinica = dtoClinica;
            }
        }


        private ClinicaDTO _DtoClinica;
        public ClinicaDTO DtoClinica
        {
            get
            {
                return _DtoClinica;
            }
        }
    }
}