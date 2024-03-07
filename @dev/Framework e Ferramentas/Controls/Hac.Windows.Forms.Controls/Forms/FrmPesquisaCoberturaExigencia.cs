using System;
using System.Data;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Cadastro.DTO;
using HospitalAnaCosta.SGS.Cadastro.Interface;
using System.Drawing;


namespace Hac.Windows.Forms.Controls
{
    public partial class FrmPesquisaCoberturaExigencia : FrmBase
    {
        private DataTable dtbAssConvenioUnidadeTpAcomodacao;
        private DataTable dtbDocsExigidos;
        private ICadastroPaciente _paciente;
        

        private ICadastroPaciente Paciente
        {
            get { return _paciente != null ? _paciente : _paciente = (ICadastroPaciente)CommonServices.GetObject(typeof(ICadastroPaciente)); }
        }

        public static Boolean flagPesquisaCoberturaExigenciaInternacao = false;

        public FrmPesquisaCoberturaExigencia()
        {
            InitializeComponent();
            ctlConvenio.Inicializar();
            ctlPlano.Inicializar();
            Titulo = "Pesquisa de Coberturas e Exigências";
            ConfigurarGrids();
            
            txtCodEst.Enabled = txtCodBen.Enabled = txtCodSeqBen.Enabled = false;
        }

        public static void AbrirPesquisaCoberturaExigencia(CadastroPacienteDTO dtoPaciente)
        {
            flagPesquisaCoberturaExigenciaInternacao = false;

            FrmPesquisaCoberturaExigencia frmPesquisa = new FrmPesquisaCoberturaExigencia();
            if (dtoPaciente != null)
            {
                flagPesquisaCoberturaExigenciaInternacao = true;
                frmPesquisa.PesquisarCoberturaExigencia(Convert.ToInt32(dtoPaciente.IdtConvenio.Value), Convert.ToInt32(dtoPaciente.IdtPlano.Value), dtoPaciente.CodigoCredencial.Value);
            }
            FrmBase.AbrirFormulario(frmPesquisa);
        }

        private void ctlConvenio_Pesquisar(object sender, EventArgs e)
        {
            txtCodEst.Text = txtCodBen.Text = txtCodSeqBen.Text = string.Empty;

            if (ctlConvenio.DtoConvenio != null)
            {
                ctlPlano.IdtConvenio = Convert.ToInt32(ctlConvenio.DtoConvenio.IdtConvenio.Value); 

                if (ctlConvenio.DtoConvenio.CodigoHACPrestador.Value == "SD01")
                {
                    txtCodEst.Enabled = txtCodBen.Enabled = txtCodSeqBen.Enabled = true;
                }
                else
                {
                    txtCodEst.Enabled = txtCodBen.Enabled = txtCodSeqBen.Enabled = false;
                }
            }
        }

        private void ConfigurarGrids()
        {
            grdTipoAtendimento.AutoGenerateColumns = false;
            grdLocalAtendimento.AutoGenerateColumns = false;
            grdTipoAcomodacao.AutoGenerateColumns = false;
            grdDocumentosExigidos.AutoGenerateColumns = false;

            grdLocalAtendimento.Columns["ASS_CUL_DT_INI_VIGENCIA"].DefaultCellStyle.Format = "dd/MM/yyyy";
            grdLocalAtendimento.Columns["ASS_CUL_DT_FIM_VIGENCIA"].DefaultCellStyle.Format = "dd/MM/yyyy";
            
            grdTipoAtendimento.Columns["ASS_PTA_DT_INI_VIGENCIA"].DefaultCellStyle.Format = "dd/MM/yyyy";
            grdTipoAtendimento.Columns["ASS_PTA_DT_FIM_VIGENCIA"].DefaultCellStyle.Format = "dd/MM/yyyy";

            grdTipoAcomodacao.Columns["ASS_CTP_DT_INI_VIGENCIA"].DefaultCellStyle.Format = "dd/MM/yyyy";
            grdTipoAcomodacao.Columns["ASS_CTP_DT_FIM_VIGENCIA"].DefaultCellStyle.Format = "dd/MM/yyyy";            
        }

        private void PesquisarCoberturaExigencia(int idtConvenio, int idtPlano, string codigoCredencial)
        {
            grdTipoAtendimento.DataSource = AssTipoAtendimento.ListarConvenioPlanoTPAtendimento(idtConvenio, idtPlano);

            PlanoDTO dtoPlano = new PlanoDTO();
            dtoPlano.IdtConvenio.Value = idtConvenio;
            dtoPlano.IdtPlano.Value = idtPlano;

            PlanoDTO planoDTO = new PlanoDTO();
            planoDTO.IdtConvenio.Value = idtConvenio;
            planoDTO.IdtPlano.Value = idtPlano;
            planoDTO = (PlanoDTO)Plano.Listar(planoDTO).TypedRow(0);
            txtOrientacao.Text = string.Format("{0} - {1}", planoDTO.CodigoPlanoHAC, planoDTO.Orientacao.Value);

            //Carregar os componentes Convenio e Plano
            ConvenioDTO dtoCNV = new ConvenioDTO();
            dtoCNV.IdtConvenio.Value = idtConvenio;
            PlanoDTO dtoPLA = new PlanoDTO();
            dtoPLA.IdtPlano.Value = idtPlano;
            ctlConvenio.CarregarConvenio(dtoCNV);
            ctlPlano.CarregarPlano(dtoPLA);

            if (ctlConvenio.DtoConvenio.CodigoHACPrestador.Value == "SD01")
            {
                txtCodEst.Text = codigoCredencial.Substring(0, 3);
                txtCodBen.Text = codigoCredencial.Substring(3, 7);
                txtCodSeqBen.Text = codigoCredencial.Substring(10, 2);

                if (txtCodEst.Text.Length == 0 || txtCodBen.Text.Length == 0 || txtCodSeqBen.Text.Length == 0)
                {
                    MessageBox.Show("Informe a Credencial para pesquisa", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                   
                    dtbAssConvenioUnidadeTpAcomodacao =
                        TipoAcomodacaoACS.ListarTipoAcomodacaoACS(Convert.ToInt32(dtoPlano.IdtConvenio.Value),
                                                                  Convert.ToInt32(dtoPlano.IdtPlano.Value), null,
                                                                  Convert.ToInt32(txtCodEst.Text),
                                                                  Convert.ToInt32(txtCodBen.Text),  
                                                                  Convert.ToInt32(txtCodSeqBen.Text));
                }
            }
            else
            {
                dtbAssConvenioUnidadeTpAcomodacao =
                    AssConvenioUnidadePlanoTipoAcomodacao.ListarUnidadeLocalConvenioPlanoTPAcomodacao(dtoPlano);
            }

            dtbDocsExigidos = AssDocumentoConvenio.ListarLocalConvenioDocumento(idtConvenio, idtPlano);
                        
            grdLocalAtendimento.DataSource = AssConvenioUnidadeLocal.ListarUnidadeLocal(idtConvenio, idtPlano);

            ctlConvenio.Enabled = false;
            ctlPlano.Enabled = false;
        }
        
        private void tspCommand_BeforePesquisar(object sender)
        {
            if (txtCodBen.Text != string.Empty)
            {
                if (txtCodSeqBen.Text == string.Empty)
                {
                    txtCodSeqBen.Text = "00";
                }
            }

            string codigoCredencial = string.Format("{0}{1}{2}",
                                                    txtCodEst.Text.PadLeft(3, '0'),
                                                    txtCodBen.Text.PadLeft(7, '0'),
                                                    txtCodSeqBen.Text.PadLeft(2, '0'));

            if (ctlConvenio.DtoConvenio != null && ctlPlano.DtoPlano != null)
            {
                PesquisarCoberturaExigencia(Convert.ToInt32(ctlConvenio.DtoConvenio.IdtConvenio.Value), Convert.ToInt32(ctlPlano.DtoPlano.IdtPlano.Value), codigoCredencial);
            }
            else
            {
                MessageBox.Show("Informe o Convênio e Plano.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BeneficiarioDTO dtoBeneficiario = new BeneficiarioDTO();
            
            dtoBeneficiario.CodigoLoja.Value = txtCodEst.Text;
            dtoBeneficiario.CodigoMatricula.Value = txtCodBen.Text;
            dtoBeneficiario.CodigoSeqMatricula.Value = txtCodSeqBen.Text;
            dtoBeneficiario.CodigoEmpresa.Value = ctlPlano.DtoPlano.CodigoPlanoHAC.Value;

            dtoBeneficiario = Beneficiario.Pesquisar(dtoBeneficiario);

            if (dtoBeneficiario != null)
            {
                Beneficiario.ValidarBeneficiarioACS(ref dtoBeneficiario);

                //_paciente.VerificarBeneficiarioTransferido(dtoBeneficiario);
                dtoBeneficiario = _paciente.VerificarBeneficiarioTransferido(dtoBeneficiario);

                PlanoDTO dtoPlano = new PlanoDTO();
                dtoPlano.IdtConvenio.Value = ctlConvenio.DtoConvenio.IdtConvenio.Value;
                dtoPlano.CodigoPlanoHAC.Value = dtoBeneficiario.CodigoEmpresa.Value;

                PlanoDataTable dtbPlano = Plano.Listar(dtoPlano);
                PlanoDTO _dtoPlano = dtbPlano.TypedRow(0);

                ctlPlano.CarregarPlano(_dtoPlano);

                txtCodEst.Text = dtoBeneficiario.CodigoLoja.Value.ToString().PadLeft(3, '0');
                dtoBeneficiario.CodigoMatricula.Value.ToString().PadLeft(7, '0');
                dtoBeneficiario.CodigoSeqMatricula.Value.ToString().PadLeft(2, '0');
            }
            else if (ctlPlano.DtoPlano.CodigoTipoPlano.Value == "GB" ||
                ctlPlano.DtoPlano.CodigoTipoPlano.Value == "PL" ||
                ctlPlano.DtoPlano.CodigoTipoPlano.Value == "ACS")
            {
                MessageBox.Show("Beneficiário não encontrado. Informações sobre o Tipo de Acomodação não disponíveis.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
         
        private bool tspCommand_LimparClick(object sender)
        {
            ctlConvenio.Enabled = true;
            ctlPlano.Enabled = true;
            return true;
        }
                
        private void grdLocalAtendimento_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //PELA REGRA, TIPO ACOMODAÇÃO É POR UNIDADE
            DataView dtvAssConvenioUnidadeTpAcomodacao = new DataView(dtbAssConvenioUnidadeTpAcomodacao,
                                                                      string.Format("{0}={1}", UnidadeDTO.FieldNames.Idt,
                                                                                               grdLocalAtendimento.Rows[e.RowIndex].Cells[colUnidadeId.Name].Value.ToString()),
                                                                      string.Empty,
                                                                      DataViewRowState.OriginalRows);
            grdTipoAcomodacao.DataSource = dtvAssConvenioUnidadeTpAcomodacao.ToTable();

            //PELA REGRA, DOCUMENTO É POR LOCAL
            DataView dtvDocs = new DataView(dtbDocsExigidos,
                                            string.Format("{0}={1}", LocalAtendimentoDTO.FieldNames.Idt,
                                                                     grdLocalAtendimento.Rows[e.RowIndex].Cells[colLocalId.Name].Value.ToString()),
                                            DocumentoDTO.FieldNames.DescricaoDocumento,
                                            DataViewRowState.OriginalRows);
            grdDocumentosExigidos.DataSource = dtvDocs.ToTable();
        }

        private void txtCodEst_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = SoNumeros((TextBox)sender, e);
        }

        private void txtCodBen_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = SoNumeros((TextBox)sender, e);
        }

        private void txtCodSeqBen_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = SoNumeros((TextBox)sender, e);
        }

        private void ConfiguraPlano()
        {
            if (ctlConvenio.DtoConvenio != null)
            {
                if (ctlPlano.DtoPlano != null)
                {
                    bool isACS = Paciente.IsFuncionarioACS(ctlConvenio.DtoConvenio.IdtConvenio.Value.ToString());

                    if (isACS)
                    {
                        txtCodEst.Text = "000";
                        txtCodBen.Focus();
                    }
                }
            }
        }

        private void ctlPlano_Pesquisar(object sender, EventArgs e)
        {
            if (((TextBox)ctlConvenio.Controls["txtCodigoConvenio"]).Text == string.Empty)
            {
                ctlPlano.Inicializar();
                MessageBox.Show("Informe o convênio antes de pesquisar o plano.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ctlPlano.DtoPlano != null)
            {
                ConfiguraPlano();
            }
        }
        
        private void grdLocalAtendimento_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ColorirGrid();
            grdLocalAtendimento.ClearSelection();
        }
        private void ColorirGrid()
        {
            for (int i = 0; i < grdLocalAtendimento.Rows.Count; i++)
            {
                grdLocalAtendimento.Rows[i].DefaultCellStyle.Font = new Font(grdLocalAtendimento.DefaultCellStyle.Font.FontFamily, 8, FontStyle.Regular);

                if (grdLocalAtendimento.Rows[i].Cells[LocalAtendimento.Name].Value.ToString().ToUpper() == "INTERNADO")
                    grdLocalAtendimento.Rows[i].DefaultCellStyle.Font = new Font(grdLocalAtendimento.DefaultCellStyle.Font.FontFamily, 7, FontStyle.Bold);
            }
        }
    }
}