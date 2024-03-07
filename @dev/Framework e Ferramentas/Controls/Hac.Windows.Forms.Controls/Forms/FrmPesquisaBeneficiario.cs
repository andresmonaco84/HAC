using System;
using System.Data;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using Hac.Windows.Forms;

namespace Hac.Windows.Forms.Controls
{
    public partial class FrmPesquisaBeneficiario : FrmBase
    {

        private DataTable _dtbPacientes;
        protected DataTable dtbPacientes
        {
            get { return _dtbPacientes; }
        }

        private CadastroPacienteDTO _dtoPaciente;
        public CadastroPacienteDTO dtoPaciente
        {
            get { return _dtoPaciente; }
        }

        private bool isHOMECARE = false;
        public bool IsHOMECARE
        {
            get { return isHOMECARE; }
            set { isHOMECARE = value; }
        }

        public FrmPesquisaBeneficiario()
        {
            InitializeComponent();

            Titulo = "Pesquisa de Beneficiários";
        }


        ~FrmPesquisaBeneficiario()
        {
            try
            {
                _dtoPaciente = null;

                if (_dtbPacientes != null)
                {
                    _dtbPacientes.Dispose();
                    _dtbPacientes = null;
                }
            }
            finally
            {
                Dispose();
            }
        }


        public static CadastroPacienteDTO Inicializar(DataTable dtbPessoas)
        {
            FrmPesquisaBeneficiario frmPesqBenef = new FrmPesquisaBeneficiario();

            //frmPesqBenef.grdBeneficiario.DataSource = dtbPessoas;
                        
            AbrirFormularioDialog(frmPesqBenef);
            frmPesqBenef._dtbPacientes.Dispose();
            return frmPesqBenef._dtoPaciente;
        }


        private void FrmPesquisaBeneficiario_Load(object sender, EventArgs e)
        {
            if (isHOMECARE)
                radServicoPrestado.Enabled = false;

            grdBeneficiario.AutoGenerateColumns = false;

            CarregarSexo(cboSexo);

            //tspCommand_CancelarClick(sender);
        }


        public static void AbrirPesquisaBeneficiario(bool isHOMECARE)
        {
            FrmPesquisaBeneficiario frmPesquisa = new FrmPesquisaBeneficiario();
            frmPesquisa.IsHOMECARE = true;
            AbrirFormularioDialog(frmPesquisa);
        }


        private void CarregarACS()
        {
            BeneficiarioDTO dto = new BeneficiarioDTO();

            dto.NomeBeneficiario.Value = RemoveAcentos(txtNome.Text.ToUpper().Trim());
            if (txtDataNascimento.Text.Length > 0)
            {
                dto.DtNascimentoBeneficiario.Value = txtDataNascimento.Text;
            }
            if (cboSexo.SelectedIndex > 0)
            {
                dto.SexoBeneficiario.Value = cboSexo.SelectedValue.ToString();
            }

            //dependente checado
            if (radDependente.Checked)
            {
                dto.IndicacaoTitular.Value = "N";
            }
            //titular checado
            else if (radTitular.Checked)
            {
                dto.IndicacaoTitular.Value = "S";
            }

            //nenhum checado retorna todos

            DataTable dtbBeneficiario;
            dtbBeneficiario = Beneficiario.Listar(dto);


            DataTable dtbBeneficiarioAlterado = dtbBeneficiario.Copy();

            for (int i = 0; i < dtbBeneficiarioAlterado.Rows.Count; i++)
            {
                DataRow rowBeneficiario = dtbBeneficiarioAlterado.Rows[i];

                switch (rowBeneficiario[BeneficiarioDTO.FieldNames.CdEstadoCivilBeneficiario].ToString())
                {
                    case "V":
                        rowBeneficiario[BeneficiarioDTO.FieldNames.CdEstadoCivilBeneficiario] = "VIÚVO";
                        break;
                    case "D":
                        rowBeneficiario[BeneficiarioDTO.FieldNames.CdEstadoCivilBeneficiario] = "DIVORCIADO";
                        break;
                    case "C":
                        rowBeneficiario[BeneficiarioDTO.FieldNames.CdEstadoCivilBeneficiario] = "CASADO";
                        break;
                    case "S":
                        rowBeneficiario[BeneficiarioDTO.FieldNames.CdEstadoCivilBeneficiario] = "SOLTEIRO";
                        break;
                    default:
                        break;
                }
            }

            grdBeneficiario.DataSource = dtbBeneficiarioAlterado;

            if (grdBeneficiario.Rows.Count <= 0)
            {
                MessageBox.Show("Nenhum resultado encontrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void CarregarSP()
        {
            string md5 = Pessoa.GerarMD5Pessoa (txtNome.Text, Convert.ToDateTime(txtDataNascimento.Text), cboSexo.SelectedValue.ToString());

            _dtbPacientes = Paciente.ListarPacienteMD5(md5);

            grdBeneficiario.DataSource = dtbPacientes;

            if (grdBeneficiario.Rows.Count <= 0)
            {
                MessageBox.Show("Nenhum resultado encontrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }


        #region "RadioButton"
        private void radAcsFuncionarios_CheckedChanged(object sender, EventArgs e)
        {
            LimparObrigatorios();

            if (radAcsFuncionarios.Checked)
            {
                txtNome.Focus();
                grdBeneficiario.DataSource = null;

                radDependente.Enabled = radTitular.Enabled = radTitular.Checked = true;
            }
        }

        private void radServicoPrestado_CheckedChanged(object sender, EventArgs e)
        {
            LimparObrigatorios();

            if (radServicoPrestado.Checked)
            {
                txtNome.Focus();
                grdBeneficiario.DataSource = null;

                radDependente.Checked = radTitular.Checked = false;

                radDependente.Enabled = radTitular.Enabled = false;
            }
        }
        #endregion


        #region "tspCommand"
        private bool tspCommand_CancelarClick(object sender)
        {
            LimparObrigatorios();

            radServicoPrestado.Checked = radAcsFuncionarios.Checked = false;
            txtNome.Text = txtDataNascimento.Text = string.Empty;
            cboSexo.Text = "<Selecione>";
            radDependente.Checked = radTitular.Checked = false;

            radAcsFuncionarios.Checked = true;

            radTitular.Checked = true;

            radAcsFuncionarios_CheckedChanged(sender, new EventArgs());

            txtNome.Focus();

            return true;
        }

        private bool tspCommand_PesquisarClick(object sender)
        {
            if (radAcsFuncionarios.Checked)
            {
                CarregarACS();
            }
            else if (radServicoPrestado.Checked)
            {
                CarregarSP();
            }

            return true;
        }


        private void tspCommand_BeforePesquisar(object sender)
        {
            if (radAcsFuncionarios.Checked)
            {
                txtNome.Obrigatorio = true;
                txtNome.ObrigatorioMensagem = "Campo Nome Obrigatório.";
            }
            if (radServicoPrestado.Checked)
            {
                txtNome.Obrigatorio = true;
                txtNome.ObrigatorioMensagem = "Campo Nome Obrigatório.";

                txtDataNascimento.Obrigatorio = true;
                txtDataNascimento.ObrigatorioMensagem = "Campo Data de Nascimento Obrigatório.";

                cboSexo.Obrigatorio = true;
                cboSexo.ObrigatorioMensagem = "Campo Sexo Obrigatório.";
            }
        }
        #endregion


        private void grdBeneficiario_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex != -1)
            //{
            //    DataRowView row = (DataRowView)grdBeneficiario.SelectedRows[0].DataBoundItem;
            //    _dtoPaciente = new CadastroPacienteDTO();

            //    if (radAcsFuncionarios.Checked)
            //    {
            //        ConvenioDTO dtoConvenio = new ConvenioDTO();
            //        dtoConvenio.CodigoHACPrestador.Value = row[BeneficiarioDTO.FieldNames.CodigoEmpresa].ToString();

            //        ConvenioDataTable dtbConvenio = base.Convenio.Listar(dtoConvenio);
            //        dtoConvenio = dtbConvenio.TypedRow(0);

            //        dtbConvenio.Dispose();
            //        dtbConvenio = null;

            //        PlanoDTO dtoPlano = new PlanoDTO();
            //        dtoPlano.IdtConvenio.Value = dtoConvenio.IdtConvenio.Value;
            //        dtoPlano.CodigoPlanoHAC.Value = row["CODPLA"].ToString();

            //        PlanoDataTable dtbPlano = base.Plano.Listar(dtoPlano);

            //        dtoPlano = dtbPlano.TypedRow(0);

            //        dtbPlano.Dispose();
            //        dtbPlano = null;
            //        _dtoPaciente.CodigoCredencial.Value = string.Format("{0}{1}{2}", row[BeneficiarioDTO.FieldNames.CodigoLoja].ToString().PadLeft(3, '0'),
            //                                                                         row[BeneficiarioDTO.FieldNames.CodigoMatricula].ToString().PadLeft(7, '0'),
            //                                                                         row[BeneficiarioDTO.FieldNames.CodigoSeqMatricula].ToString().PadLeft(2, '0'));

            //        _dtoPaciente.IdtConvenio.Value = dtoConvenio.IdtConvenio.Value;
            //        _dtoPaciente.IdtPlano.Value = dtoPlano.IdtPlano.Value;

            //        //_dtoPaciente = Paciente.Pesquisar(_dtoPaciente);
            //    }
            //    else
            //    {
            //        _dtoPaciente.IdtPaciente.Value = row[CadastroPacienteDTO.FieldNames.IdtPaciente].ToString();
            //        //_dtoPaciente = Paciente.Pesquisar(_dtoPaciente);
            //    }
            //    //Close();
            //}
        }

        private void tspCommand_AfterLimpar(object sender)
        {
            CarregarSexo(cboSexo);
        }

        private bool tspCommand_LimparClick(object sender)
        {
            LimparObrigatorios();

            return true;
        }

        private void LimparObrigatorios()
        {
            txtNome.Obrigatorio = 
                txtNome.Obrigatorio = 
                txtDataNascimento.Obrigatorio = 
                cboSexo.Obrigatorio = false;
        }
    }
}

