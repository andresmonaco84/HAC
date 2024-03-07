using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using HospitalAnaCosta.SGS.Cadastro.Interface;
using System.Threading;


namespace Hac.Windows.Forms.Controls
{

    public partial class HacProfissionalSolicitante : HacUserControl
    {

        /// <summary>
        /// Internado Agenda Eletiva
        /// </summary>
        private IProfissionalSolicitante _profissionalSolicitante;
        public IProfissionalSolicitante ProfissionalSolicitante
        {
            get
            {
                return _profissionalSolicitante != null ? _profissionalSolicitante : _profissionalSolicitante =
                    (IProfissionalSolicitante)CommonServices.GetObject(typeof(IProfissionalSolicitante));
            }
        }

        /// <summary>
        /// Conselho Profissional
        /// </summary>
        private IConselhoProfissional _conselhoProfissional;
        public IConselhoProfissional ConselhoProfissional
        {
            get
            {
                return _conselhoProfissional != null ? _conselhoProfissional : _conselhoProfissional =
                    (IConselhoProfissional)CommonServices.GetObject(typeof(IConselhoProfissional));
            }
        }

        /// <summary>
        /// UF
        /// </summary>
        private IUF _uf;
        public IUF UF
        {
            get
            {
                return _uf != null ? _uf : _uf =
                    (IUF)CommonServices.GetObject(typeof(IUF));
            }
        }

        public HacProfissionalSolicitante()
        {
            InitializeComponent();
        }

        ~HacProfissionalSolicitante()
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

        public delegate void PesquisarDelegate(object sender, EventArgs e);

        [Category("Hac")]
        public event PesquisarDelegate Pesquisar;

        [Category("Hac")]
        protected virtual void OnPesquisar(EventArgs e)
        {
            if (Pesquisar != null)
            {
                Pesquisar(this, e);
            }
        }

        public void Inicializar()
        {
            CarregarTipoConselhoProfissionalSolicitante();
            CarregarUFConselhoProfissionalSolicitante();

            //Deverá sempre apresentar CRM como padrão 
            cboTipoConselhoProfissionalSolicitante.SelectedIndex = cboTipoConselhoProfissionalSolicitante.FindString("CRM");

            //Deverá sempre apresentar SP como padrão 
            cboUfConselhoProfissionalSolicitante.SelectedIndex = cboUfConselhoProfissionalSolicitante.FindString("SP");

            //O nome do profissional é apenas exibição
            txtNomeProfissionalSolicitante.Enabled = false;

            txtCodigoProfissionalSolicitante.Text = string.Empty;
            txtNomeProfissionalSolicitante.Text = string.Empty;
            
            DtoProfissionalSolicitante = null;
        }

        private bool naoAjustarEdicao;
        public bool NaoAjustarEdicao
        {
            get { return naoAjustarEdicao; }
            set
            {
                txtCodigoProfissionalSolicitante.NaoAjustarEdicao = value;
                txtNomeProfissionalSolicitante.NaoAjustarEdicao = value;
                naoAjustarEdicao = value;
            }
        }

        private bool enabled;
        public new bool Enabled
        {
            get { return enabled; }
            set
            {
                if (value)
                {
                    cboTipoConselhoProfissionalSolicitante.Enabled = true;
                    cboUfConselhoProfissionalSolicitante.Enabled = true;
                    txtCodigoProfissionalSolicitante.Enabled = true;
                    txtNomeProfissionalSolicitante.Enabled = false;
                    btnPesquisarProfissionalSolicitante.Enabled = true;
                }
                else
                {
                    cboTipoConselhoProfissionalSolicitante.Enabled = false;
                    cboUfConselhoProfissionalSolicitante.Enabled = false;
                    txtCodigoProfissionalSolicitante.Enabled = false;
                    txtNomeProfissionalSolicitante.Enabled = false;
                    btnPesquisarProfissionalSolicitante.Enabled = false;
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
                txtCodigoProfissionalSolicitante.Obrigatorio = value;
                obrigatorio = value;
            }
        }

        private string obrigatorioMensagem;
        public string ObrigatorioMensagem
        {
            get { return obrigatorioMensagem; }
            set
            {
                txtCodigoProfissionalSolicitante.ObrigatorioMensagem = value;
                obrigatorioMensagem = value;
            }
        }

        private ProfissionalSolicitanteDataTable PesquisarProfissionalSolicitante(string ufConselho, string tipoConselho, string codigoConselho, string nome)
        {
            try
            {
                ProfissionalSolicitanteDTO dtoProfissionalSolicitante = new ProfissionalSolicitanteDTO();
                dtoProfissionalSolicitante.UFConselho.Value = ufConselho;
                dtoProfissionalSolicitante.TipoConselho.Value = tipoConselho;
                if (codigoConselho != null) dtoProfissionalSolicitante.CodigoConselho.Value = codigoConselho;
                dtoProfissionalSolicitante.FlAtivoOk.Value = "S";
                if (nome != null) dtoProfissionalSolicitante.NomeProfissional.Value = "%"+nome+"%";

                return ProfissionalSolicitante.Listar(dtoProfissionalSolicitante);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void CarregarTipoConselhoProfissionalSolicitante()
        {
            ConselhoProfissionalDTO dtoConselho = new ConselhoProfissionalDTO();
            cboTipoConselhoProfissionalSolicitante.DisplayMember = ConselhoProfissionalDTO.FieldNames.CodigoTipoConselho;
            cboTipoConselhoProfissionalSolicitante.ValueMember = ConselhoProfissionalDTO.FieldNames.CodigoTipoConselho;
            cboTipoConselhoProfissionalSolicitante.DataSource = ConselhoProfissional.Listar(dtoConselho);
            cboTipoConselhoProfissionalSolicitante.IniciaLista();
        }

        private void CarregarUFConselhoProfissionalSolicitante()
        {
            UFDTO dtoUF = new UFDTO();
            cboUfConselhoProfissionalSolicitante.DisplayMember = UFDTO.FieldNames.Codigo;
            cboUfConselhoProfissionalSolicitante.ValueMember = UFDTO.FieldNames.Codigo;
            cboUfConselhoProfissionalSolicitante.DataSource = UF.Listar(dtoUF);
            cboUfConselhoProfissionalSolicitante.IniciaLista();
        }

        private void btnPesquisarProfissionalSolicitante_Click(object sender, EventArgs e)
        {
            if (cboUfConselhoProfissionalSolicitante.SelectedValue == null ||
                cboTipoConselhoProfissionalSolicitante.SelectedValue == null)
            {
                MessageBox.Show("Selecione o Tipo Conselho e o Estado", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtCodigoProfissionalSolicitante.Text.Length > 0)
            {
                ProfissionalSolicitanteDataTable dtbProfissionalSolicitante =
                   PesquisarProfissionalSolicitante(cboUfConselhoProfissionalSolicitante.SelectedValue.ToString(),
                       cboTipoConselhoProfissionalSolicitante.SelectedValue.ToString().Trim(),
                       txtCodigoProfissionalSolicitante.Text,
                       txtNomeProfissionalSolicitante.Text);

                if (dtbProfissionalSolicitante.Rows.Count == 0)
                {
                    MessageBox.Show("Nenhum Profissional encontrado para este UF/CRM!", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNomeProfissionalSolicitante.Text = string.Empty;
                    _DtoProfissionalSolicitante = null;
                }
                else
                {
                    ProfissionalSolicitanteDTO dtoProfissionalSolicitante = Forms.FrmPesquisaProfissionalSolicitante.AbrirPesquisaProfissionalSolicitante(dtbProfissionalSolicitante, new ProfissionalSolicitanteDTO());

                    if (dtoProfissionalSolicitante != null)
                    {
                        cboTipoConselhoProfissionalSolicitante.SelectedValue = dtoProfissionalSolicitante.TipoConselho.Value;
                        cboUfConselhoProfissionalSolicitante.SelectedValue = dtoProfissionalSolicitante.UFConselho.Value;
                        txtCodigoProfissionalSolicitante.Text = dtoProfissionalSolicitante.CodigoConselho.Value;
                        txtNomeProfissionalSolicitante.Text = dtoProfissionalSolicitante.NomeProfissional.Value;

                        _DtoProfissionalSolicitante = dtoProfissionalSolicitante;
                    }
                }
                //OnPesquisar(new EventArgs());
                //txtCodigoProfissionalSolicitante.RetirarVermelhoCampo();
            }
            else
            {
                _DtoProfissionalSolicitante = new ProfissionalSolicitanteDTO();
                if (cboTipoConselhoProfissionalSolicitante.SelectedIndex > 0)
                    _DtoProfissionalSolicitante.TipoConselho.Value = cboTipoConselhoProfissionalSolicitante.SelectedValue.ToString();
                if (cboUfConselhoProfissionalSolicitante.SelectedIndex > 0)
                    _DtoProfissionalSolicitante.UFConselho.Value = cboUfConselhoProfissionalSolicitante.SelectedValue.ToString();
                _DtoProfissionalSolicitante.CodigoConselho.Value = txtCodigoProfissionalSolicitante.Text;
                _DtoProfissionalSolicitante.NomeProfissional.Value = txtNomeProfissionalSolicitante.Text;

                ProfissionalSolicitanteDTO dtoProfissionalSolicitante = Forms.FrmPesquisaProfissionalSolicitante.AbrirPesquisaProfissionalSolicitante(new ProfissionalSolicitanteDataTable(), _DtoProfissionalSolicitante);
                _DtoProfissionalSolicitante = null;

                if (dtoProfissionalSolicitante != null)
                {
                    cboTipoConselhoProfissionalSolicitante.SelectedValue = dtoProfissionalSolicitante.TipoConselho.Value;
                    cboUfConselhoProfissionalSolicitante.SelectedValue = dtoProfissionalSolicitante.UFConselho.Value;
                    txtCodigoProfissionalSolicitante.Text = dtoProfissionalSolicitante.CodigoConselho.Value;
                    txtNomeProfissionalSolicitante.Text = dtoProfissionalSolicitante.NomeProfissional.Value;

                    _DtoProfissionalSolicitante = dtoProfissionalSolicitante;
                }
            }
            OnPesquisar(new EventArgs());
            txtCodigoProfissionalSolicitante.RetirarVermelhoCampo();

           
       }

        private void txtCodigoProfissionalSolicitante_Leave(object sender, EventArgs e)
        {
            if (txtCodigoProfissionalSolicitante.Text != string.Empty)
            {
                if (cboUfConselhoProfissionalSolicitante.SelectedValue == null ||
                cboTipoConselhoProfissionalSolicitante.SelectedValue == null)
                {
                    MessageBox.Show("Selecione o Tipo Conselho e o Estado", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Cursor.Current = Cursors.Arrow;
                ProfissionalSolicitanteDataTable dtbProfissionalSolicitante =
                        PesquisarProfissionalSolicitante(cboUfConselhoProfissionalSolicitante.SelectedValue.ToString(),
                            cboTipoConselhoProfissionalSolicitante.SelectedValue.ToString(),
                            txtCodigoProfissionalSolicitante.Text,
                            txtNomeProfissionalSolicitante.Text);
                Cursor.Current = Cursors.Arrow;

                if (dtbProfissionalSolicitante.Rows.Count == 0)
                {
                    MessageBox.Show("Profissional não encontrado!", Code.Funcoes.tituloSistema, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNomeProfissionalSolicitante.Text = string.Empty;
                    _DtoProfissionalSolicitante = null;
                }
                else if (dtbProfissionalSolicitante.Rows.Count == 1)
                {
                    txtNomeProfissionalSolicitante.DataBindings.Clear();
                    txtNomeProfissionalSolicitante.DataBindings.Add(new Binding("Text",
                            dtbProfissionalSolicitante, ProfissionalSolicitanteDTO.FieldNames.NomeProfissional));

                    _DtoProfissionalSolicitante = dtbProfissionalSolicitante.TypedRow(0);
                }
            }
            else
            {
                txtNomeProfissionalSolicitante.Text = string.Empty;
                _DtoProfissionalSolicitante = null;
            }
            OnPesquisar(new EventArgs());
        }

        public void CarregarProfissionalSolicitante(ProfissionalSolicitanteDTO dtoProfissionalSolicitante)
        {
            cboTipoConselhoProfissionalSolicitante.SelectedValue = dtoProfissionalSolicitante.TipoConselho.Value;
            cboUfConselhoProfissionalSolicitante.SelectedValue = dtoProfissionalSolicitante.UFConselho.Value;
            txtCodigoProfissionalSolicitante.Text = dtoProfissionalSolicitante.CodigoConselho.Value;

            ProfissionalSolicitanteDataTable dtbProfissionalSolicitante =
                    PesquisarProfissionalSolicitante(cboUfConselhoProfissionalSolicitante.SelectedValue.ToString(),
                        cboTipoConselhoProfissionalSolicitante.SelectedValue.ToString().Trim(),
                        txtCodigoProfissionalSolicitante.Text,
                        txtNomeProfissionalSolicitante.Text);
            
            if (dtbProfissionalSolicitante.Rows.Count > 0)
            {
                txtNomeProfissionalSolicitante.DataBindings.Clear();
                txtNomeProfissionalSolicitante.DataBindings.Add(new Binding("Text",
                        dtbProfissionalSolicitante, ProfissionalSolicitanteDTO.FieldNames.NomeProfissional));

                _DtoProfissionalSolicitante = dtbProfissionalSolicitante.TypedRow(0);
            }
            OnPesquisar(new EventArgs());
        }

        private ProfissionalSolicitanteDTO _DtoProfissionalSolicitante;

        public ProfissionalSolicitanteDTO DtoProfissionalSolicitante
        {
            get 
            { 
                return _DtoProfissionalSolicitante; 
            }
            set
            {
                _DtoProfissionalSolicitante = value;
            }
        }

    }
}
