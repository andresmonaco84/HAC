using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using HospitalAnaCosta.Framework.DataSetHelper;
using Hac.Windows.Forms;

namespace Hac.Windows.Forms.Controls.Forms
{
    public partial class FrmSelecaoPessoaPaciente : FrmBase
    {
        private DataSet dsPaciente;
        protected DataSet DsPaciente
        {
            get { return dsPaciente; }
            set { dsPaciente = value; }
        }

        private bool retorno = false;

        private bool _isHomeCare = false;
        protected bool IsHomeCare
        {
            get { return _isHomeCare; }
            set { _isHomeCare = value; }
        }

        private bool _isNovoPacienteRN = false;
        protected bool IsNovoPacienteRN
        {
            get { return _isNovoPacienteRN; }
            set { _isNovoPacienteRN = value; }
        }

        public FrmSelecaoPessoaPaciente()
        {
            InitializeComponent();
            Titulo = "Seleção de Pessoa / Paciente";
        }

        public static bool AbrirSelecaoPessoaPaciente(ref DataSet dsPaciente, bool isHomeCare, bool isNovoPacienteRN)
        {
            FrmSelecaoPessoaPaciente frmSelecaoPessoaPaciente = new FrmSelecaoPessoaPaciente();
            frmSelecaoPessoaPaciente._isHomeCare = isHomeCare;
            frmSelecaoPessoaPaciente._isNovoPacienteRN = isNovoPacienteRN;
            frmSelecaoPessoaPaciente.DsPaciente = dsPaciente;
            frmSelecaoPessoaPaciente.ShowDialog();
            dsPaciente = frmSelecaoPessoaPaciente.DsPaciente;
            return frmSelecaoPessoaPaciente.retorno;
        }

        private DataSetHelper dsHelper;

        private void FrmSelecaoPessoaPaciente_Load(object sender, EventArgs e)
        {
            //Carregar o grid de pessoa
            dgvPessoas.AutoGenerateColumns = false;
            dgvPessoas.Columns[colIdtPessoa.Name].DataPropertyName = CadastroPessoaDTO.FieldNames.IdtPessoa;
            dgvPessoas.Columns[colNome.Name].DataPropertyName = CadastroPessoaDTO.FieldNames.NomePessoa;
            dgvPessoas.Columns[colDataNascimento.Name].DataPropertyName = CadastroPessoaDTO.FieldNames.DataNascimento;
            dgvPessoas.Columns[colSexo.Name].DataPropertyName = "DescricaoSexo";
            dgvPessoas.Columns[colNomeMae.Name].DataPropertyName = CadastroPessoaDTO.FieldNames.NomeMae;
            dgvPessoas.Columns[colEstadoCivil.Name].DataPropertyName = "DescricaoEstadoCivil";
            dgvPessoas.Columns[colRG.Name].DataPropertyName = CadastroPessoaDTO.FieldNames.RG;
            dgvPessoas.Columns[colCPF.Name].DataPropertyName = CadastroPessoaDTO.FieldNames.CNPJCPF;
            dgvPessoas.Columns[colDataAtualizacaoPessoa.Name].DataPropertyName = CadastroPessoaDTO.FieldNames.DataUltimaAtualizacao;
            dgvPessoas.Columns[colPessoaFlagAtivoOK.Name].DataPropertyName = CadastroPessoaDTO.FieldNames.FlagAtivoOK;

            dsHelper = new DataSetHelper(ref dsPaciente);
            DataTable dtJoinPessoa = dsHelper.SelectJoinInto("CadastroPessoa",
                dsPaciente.Tables["CadastroPessoa"], CadastroPessoaDTO.FieldNames.FlagAtivoOK + "<>'N'", CadastroPessoaDTO.FieldNames.DataUltimaAtualizacao + " DESC",
                new string[]
                {
                    CadastroPessoaDTO.FieldNames.IdtPessoa,
                    CadastroPessoaDTO.FieldNames.NomePessoa,
                    CadastroPessoaDTO.FieldNames.DataNascimento,
                    "relSexo.DescricaoSexo",
                    CadastroPessoaDTO.FieldNames.NomeMae,
                    "relEstadoCivil.DescricaoEstadoCivil",
                    CadastroPessoaDTO.FieldNames.RG,
                    CadastroPessoaDTO.FieldNames.CNPJCPF,                                
                    CadastroPessoaDTO.FieldNames.DataUltimaAtualizacao,
                    CadastroPessoaDTO.FieldNames.FlagAtivoOK
                });
            
            dgvPessoas.DataSource = dtJoinPessoa;

            dgvPessoas.Select();
           // CarregarGridPaciente(Convert.ToDecimal(dtJoinPessoa.Rows[0][CadastroPessoaDTO.FieldNames.IdtPessoa]));
            dgvPessoas.ClearSelection();
        }

        private void CarregarGridPaciente(Decimal idtPessoa)
        {
            //Carregar o grid de paciente
            dgvPacientes.AutoGenerateColumns = false;
            dgvPacientes.Columns[colIdtPaciente.Name].DataPropertyName = CadastroPacienteDTO.FieldNames.IdtPaciente;
            dgvPacientes.Columns[colConvenio.Name].DataPropertyName = ConvenioDTO.FieldNames.CodigoHACPrestador;
            dgvPacientes.Columns[colNomeConvenio.Name].DataPropertyName = ConvenioDTO.FieldNames.NomeFantasia;
            dgvPacientes.Columns[colPlano.Name].DataPropertyName = PlanoDTO.FieldNames.CodigoPlanoHAC;
            dgvPacientes.Columns[colNomePlano.Name].DataPropertyName = PlanoDTO.FieldNames.NomePlano;
            dgvPacientes.Columns[colCredencial.Name].DataPropertyName = CadastroPacienteDTO.FieldNames.CodigoCredencial;
            dgvPacientes.Columns[colProntuario.Name].DataPropertyName = CadastroPacienteDTO.FieldNames.Prontuario;
            dgvPacientes.Columns[colDataAtualizacao.Name].DataPropertyName = CadastroPacienteDTO.FieldNames.DataUltimaAtualizacao;
            dgvPacientes.Columns[colStatusPlano.Name].DataPropertyName = PlanoDTO.FieldNames.FlSituacaoPlano;
            dgvPacientes.Columns[colPacienteFlagAtivoOK.Name].DataPropertyName = CadastroPacienteDTO.FieldNames.FlagAtivoOK;

            DataTable dtJoinPaciente = dsHelper.SelectJoinInto("CadastroPaciente", dsPaciente.Tables["CadastroPaciente"],
                string.Format("{0} = {1} AND {2} in ('S','P')", CadastroPessoaDTO.FieldNames.IdtPessoa, idtPessoa, CadastroPacienteDTO.FieldNames.FlagAtivoOK), CadastroPacienteDTO.FieldNames.DataUltimaAtualizacao + " DESC",
                new string[]
                {
                    CadastroPacienteDTO.FieldNames.IdtPaciente,
                    "relConvenio." + ConvenioDTO.FieldNames.CodigoHACPrestador,
                    "relConvenio." + ConvenioDTO.FieldNames.NomeFantasia,
                    "relPlano." + PlanoDTO.FieldNames.CodigoPlanoHAC,
                    "relPlano." + PlanoDTO.FieldNames.NomePlano,
                    "relPlano." + PlanoDTO.FieldNames.FlSituacaoPlano,
                    CadastroPacienteDTO.FieldNames.CodigoCredencial,
                    CadastroPacienteDTO.FieldNames.Prontuario,
                    CadastroPacienteDTO.FieldNames.DataUltimaAtualizacao
                });

            for (int i = 0; i < dtJoinPaciente.Rows.Count; i++)
            {
                dtJoinPaciente.Rows[i][PlanoDTO.FieldNames.FlSituacaoPlano] = dtJoinPaciente.Rows[i][PlanoDTO.FieldNames.FlSituacaoPlano].ToString() == "A" ? "ATIVO" : "INATIVO";

                //if (_isHomeCare && dtJoinPaciente.Rows[i][ConvenioDTO.FieldNames.CodigoHACPrestador].ToString() != "SD01")
                //    dtJoinPaciente.Rows[i][PlanoDTO.FieldNames.FlSituacaoPlano] = "INATIVO";
            }

            dgvPacientes.DataSource = dtJoinPaciente;
            FormatarInativosGrid();
        
            dgvPacientes.ClearSelection();
            
        }

        private void FormatarInativosGrid()
        {
            for (int i = 0; i < dgvPacientes.Rows.Count; i++)
            {
                dgvPacientes.Rows[i].DefaultCellStyle.ForeColor = dgvPacientes.Rows[i].Cells[colStatusPlano.Name].Value.ToString() == "ATIVO" ? Color.Black : Color.Gray;

                if(_isHomeCare)
                    dgvPacientes.Rows[i].DefaultCellStyle.ForeColor = (dgvPacientes.Rows[i].Cells[colConvenio.Name].Value.ToString() == "SD01" ||
                dgvPacientes.Rows[i].Cells[colConvenio.Name].Value.ToString() == "GG05" ||
                dgvPacientes.Rows[i].Cells[colConvenio.Name].Value.ToString() == "S077") ? Color.Black : Color.Gray;
            }
        }
        
        private void dgvPessoas_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Decimal idtPessoa = new Decimal();

                //Recupero a linha selecionada no grid e o idtPessoa
                DataRow rowJoinedPessoa = ((DataRowView)dgvPessoas.Rows[e.RowIndex].DataBoundItem).Row;

                if (rowJoinedPessoa[CadastroPessoaDTO.FieldNames.IdtPessoa] != DBNull.Value)
                {
                    idtPessoa = Convert.ToDecimal(rowJoinedPessoa[CadastroPessoaDTO.FieldNames.IdtPessoa]);
                    if(rowJoinedPessoa[CadastroPessoaDTO.FieldNames.FlagAtivoOK].ToString() == "O")
                    {
                        MessageBox.Show("Registro não permitido. Favor entrar em contato com o setor APP ou TI - Tel. 3228-9000, ramal: 380.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                CarregarGridPaciente(idtPessoa);
            }
        }

        private void dgvPessoas_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Decimal idtPessoa = new Decimal();

                //Recupero a linha selecionada no grid e o idtPessoa
                DataRow rowJoinedPessoa = ((DataRowView)dgvPessoas.Rows[e.RowIndex].DataBoundItem).Row;

                if (rowJoinedPessoa[CadastroPessoaDTO.FieldNames.IdtPessoa] != DBNull.Value)
                {
                    idtPessoa = Convert.ToDecimal(rowJoinedPessoa[CadastroPessoaDTO.FieldNames.IdtPessoa]);

                    if (rowJoinedPessoa[CadastroPessoaDTO.FieldNames.FlagAtivoOK].ToString() == "O")
                    {
                        MessageBox.Show("Registro não permitido. Favor entrar em contato com o setor APP ou TI - Tel. 3228-9000, ramal: 380.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                        dgvPacientes.ClearSelection();
                        return;
                    }
                }

                //Removo todos os Pacientes não pertencem a pessoa selecionada
                DataRow[] listRowPaciente = dsPaciente.Tables["CadastroPaciente"].Select(CadastroPacienteDTO.FieldNames.IdtPessoa + "<>" + idtPessoa);
                foreach (DataRow rowPaciente in listRowPaciente)
                {
                    dsPaciente.Tables["CadastroPaciente"].Rows.Remove(rowPaciente);
                }
                
                //Removo todos as Pessoas não selecionados
                DataRow[] listRowPessoa = dsPaciente.Tables["CadastroPessoa"].Select(CadastroPessoaDTO.FieldNames.IdtPessoa + "<>" + idtPessoa);
                foreach (DataRow rowPessoa in listRowPessoa)
                {
                    dsPaciente.Tables["CadastroPessoa"].Rows.Remove(rowPessoa);
                }
                
                //Adicionar Prontuario
                string prontuario = string.Empty;
                if (dsPaciente.Tables["CadastroPaciente"].Rows.Count > 0)
                     prontuario = FrmSelecaoProntuario.AbrirSelecaoProntuario(idtPessoa);
                DataTable dtbProntuario = new DataTable("Prontuario");
                dtbProntuario.Columns.Add("Prontuario");
                DataRow rowProntuario = dtbProntuario.NewRow();
                rowProntuario["Prontuario"] = prontuario;
                dtbProntuario.Rows.Add(rowProntuario);
                dsPaciente.Tables.Add(dtbProntuario);
                
                //Removo todos os pacientes
                dsPaciente.Tables["CadastroPaciente"].Rows.Clear();

                //Removo todos os convenios
                dsPaciente.Tables["Convenio"].Rows.Clear();

                //Removo todos os planos
                dsPaciente.Tables["Plano"].Rows.Clear();

                //Faz o commit no DataSet
                dsPaciente.AcceptChanges();

                //Se escolher um Pessoa retorno = true, continua com a pesquisa
                retorno = true;
                Close();
            }
        }

        private void dgvPacientes_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                DataSet dsCopiaPaciente = new DataSet();
                dsCopiaPaciente = dsPaciente.Copy();


                if (_isHomeCare && dgvPacientes.Rows[e.RowIndex].DefaultCellStyle.ForeColor == Color.Gray &&
                    Convert.ToDecimal(dgvPacientes.Rows[e.RowIndex].Cells[colIdtPaciente.Name].Value) != 2838543 &&
                    Convert.ToDecimal(dgvPacientes.Rows[e.RowIndex].Cells[colIdtPaciente.Name].Value) != 2959889)
                {
                    MessageBox.Show("Seleção não permitida. O Atendimento Domiciliar é permitido somente para beneficiários dos planos do convênio ANA COSTA SAÚDE, GG05 e S077.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvPacientes.ClearSelection();
                    return;
                }

                //Recupero a linha selecionada no grid e o idtPaciente
                DataRow rowJoinedPaciente = ((DataRowView)dgvPacientes.Rows[e.RowIndex].DataBoundItem).Row;
                Decimal idtPaciente = Convert.ToDecimal(rowJoinedPaciente[CadastroPacienteDTO.FieldNames.IdtPaciente]);
                
                //Removo todos os pacientes não selecionados
                DataRow[] listRowPaciente = dsCopiaPaciente.Tables["CadastroPaciente"].Select(CadastroPacienteDTO.FieldNames.IdtPaciente + "<>" + idtPaciente);
                foreach (DataRow rowPaciente in listRowPaciente)
                {
                    dsCopiaPaciente.Tables["CadastroPaciente"].Rows.Remove(rowPaciente);
                }
                 
                CadastroPacienteDTO dtoPacienteVerificaInativo = new CadastroPacienteDTO();
                dtoPacienteVerificaInativo.IdtPaciente.Value = dsCopiaPaciente.Tables["CadastroPaciente"].Rows[0][CadastroPacienteDTO.FieldNames.IdtPaciente].ToString();
                dtoPacienteVerificaInativo = Paciente.PesquisarChave(dtoPacienteVerificaInativo);
                
                if (dtoPacienteVerificaInativo != null && !dtoPacienteVerificaInativo.IdtConvenio.Value.IsNull)
                {
                    ConvenioDTO dtoConvenioVerificaInativo = new ConvenioDTO();
                    dtoConvenioVerificaInativo.IdtConvenio.Value = dtoPacienteVerificaInativo.IdtConvenio.Value;
                    dtoConvenioVerificaInativo = Convenio.Pesquisar(dtoConvenioVerificaInativo);
                    if (dtoConvenioVerificaInativo.StatusConvenio.Value != "A")
                    {
                        MessageBox.Show("Não é possível selecionar esse Paciente, o Convênio está inativo.", Titulo,MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                        dgvPacientes.ClearSelection();
                        return;
                    }

                    PlanoDTO dtoPlanoVerificaInativo = new PlanoDTO();
                    dtoPlanoVerificaInativo.IdtPlano.Value = dtoPacienteVerificaInativo.IdtPlano.Value;
                    dtoPlanoVerificaInativo = Plano.Pesquisar(dtoPlanoVerificaInativo);
                    if (dtoPlanoVerificaInativo.FlSituacaoPlano.Value != "A")
                    {
                        MessageBox.Show("Não é possível selecionar esse Paciente, o Plano está inativo.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvPacientes.ClearSelection();
                        return;
                    }

                    try
                    {
                        if (Paciente.IsFuncionarioACS(dtoPacienteVerificaInativo.IdtConvenio.Value.ToString()))
                        {
                            CadastroPessoaDTO dtoPessoa = new CadastroPessoaDTO();
                            dtoPessoa.IdtPessoa.Value = dsCopiaPaciente.Tables["CadastroPaciente"].Rows[0][CadastroPacienteDTO.FieldNames.IdtPessoa].ToString();
                            dtoPessoa = Pessoa.Pesquisar(dtoPessoa);

                            if (Paciente.ValidarDataNascimentoBeneficiarioPaciente(dtoPacienteVerificaInativo))
                            {
                                BeneficiarioDTO dtoBeneficiario = Paciente.ValidarBeneficiarioPorCredencial(Convert.ToInt32(dtoPacienteVerificaInativo.IdtPlano.Value), dtoPacienteVerificaInativo.CodigoCredencial.Value.ToString());
                                if (dtoBeneficiario.CodigoEmpresa.Value != rowJoinedPaciente[PlanoDTO.FieldNames.CodigoPlanoHAC].ToString() ||
                                    dtoBeneficiario.CodigoMatricula.Value != rowJoinedPaciente[CadastroPacienteDTO.FieldNames.CodigoCredencial].ToString().Substring(3, 7))
                                {
                                    if (dtoBeneficiario != null)
                                        dsCopiaPaciente = Paciente.CriarPacienteBeneficiario(dtoBeneficiario);
                                    else
                                        throw new HacException("Beneficiário não encontrado.");
                                }
                            }
                            else 
                            {
                                if (Convert.ToDateTime(dtoPessoa.DataNascimento.Value) < Convert.ToDateTime(DateTime.Now.Date.AddDays(-30)))// se não for RN
                                {
                                    MessageBox.Show("A data de nascimento do paciente selecionado é diferente da data de nascimento do beneficiário!", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    dgvPacientes.ClearSelection();
                                }
                            }
                        }
                    }
                    catch (HacException ex)
                    {
                        MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgvPacientes.ClearSelection();
                        return;
                    }
                }

                dsPaciente = dsCopiaPaciente;

                //Encontro a pessoa do paciente selecionado
                Decimal idtPessoa = Convert.ToDecimal(dsPaciente.Tables["CadastroPaciente"].Rows[0][CadastroPessoaDTO.FieldNames.IdtPessoa]);

                //Removo todos as pessoas não selecionados
                DataRow[] listRowPessoa = dsPaciente.Tables["CadastroPessoa"].Select(CadastroPessoaDTO.FieldNames.IdtPessoa + "<>" + idtPessoa);
                foreach (DataRow rowPessoa in listRowPessoa)
                {
                    dsPaciente.Tables["CadastroPessoa"].Rows.Remove(rowPessoa);
                }

                //Faz o commit no DataSet
                dsPaciente.AcceptChanges();

                //Se escolher um paciente retorno = true, continua com a pesquisa
                retorno = true;
                Close();
            }
        }

        private bool tspCommand_SairClick(object sender)
        {
            retorno = false;
            return true;
        }

        private void btnAdicionarNovoPaciente_Click(object sender, EventArgs e)
        {
            retorno = true;

            //Removo todos os pacientes
            dsPaciente.Tables["CadastroPaciente"].Rows.Clear();

            //Removo todas as pessoas
            dsPaciente.Tables["CadastroPessoa"].Rows.Clear();

            //Removo todos os convenios
            dsPaciente.Tables["Convenio"].Rows.Clear();

            //Removo todos os planos
            dsPaciente.Tables["Plano"].Rows.Clear();

            //Faz o commit no DataSet
            dsPaciente.AcceptChanges();

            this.Close();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void dgvPacientes_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (dgvPacientes.Rows[e.RowIndex].DefaultCellStyle.ForeColor == Color.Gray)
                    dgvPacientes.ClearSelection();
            }
            catch(Exception)
            {
            }
        }

        private void dgvPacientes_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvPacientes.Rows[e.RowIndex].DefaultCellStyle.ForeColor == Color.Gray)
                    dgvPacientes.ClearSelection();
            }
            catch (Exception)
            {
            }
            
        }
    }
}