using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.Interface;
using HospitalAnaCosta.SGS.Seguranca.View;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.Framework;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Cadastro
{
    public partial class FrmSetorPedidoAutoParam : FrmBase
    {
        private const int PadraoHoraCorteProcesso = 18;
        private const int PadraoQtdTotalHrsGerar = 24;

        #region OBJETOS SERVIÇO

        // Requisição
        private RequisicaoDTO dtoRequisicao;
        private RequisicaoDataTable dtbRequisicao;
        private IRequisicao _requisicao;
        private IRequisicao Requisicao
        {
            get { return _requisicao != null ? _requisicao : _requisicao = (IRequisicao)Global.Common.GetObject(typeof(IRequisicao)); }
        }

        private IRequisicaoItens _requisicaoitens;
        private IRequisicaoItens RequisicaoItens
        {
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject(typeof(IRequisicaoItens)); }
        }
        
        // Utilitario
        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }        

        Generico gen = new Generico();

        #endregion

        #region FUNÇÕES

        public FrmSetorPedidoAutoParam()
        {
            InitializeComponent();
        }

        private bool ValidarHora(TextBox txtHora)
        {
            if (BasicFunctions.IsNumeric(txtHora.Text))
            {
                if (int.Parse(txtHora.Text) >= 24)
                {
                    MessageBox.Show("Hora inválida.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtHora.Focus();
                    return false;
                }
                return true;
            }
            return false;
        }

        private void ConfigGrid()
        {
            dtgPeriodo.AutoGenerateColumns = false;
            dtgPeriodo.Columns[colDtIni.Name].DataPropertyName = RequisicaoDTO.FieldNames.SetorPedidoAutoDtHoraIniVigencia;
            dtgPeriodo.Columns[colDtIni.Name].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dtgPeriodo.Columns[colDtFim.Name].DataPropertyName = RequisicaoDTO.FieldNames.SetorPedidoAutoDtHoraFimVigencia;
            dtgPeriodo.Columns[colDtFim.Name].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            dtgTodosSetores.AutoGenerateColumns = false;
            dtgTodosSetores.Columns[colDataInicioTodos.Name].DataPropertyName = RequisicaoDTO.FieldNames.SetorPedidoAutoDtHoraIniVigencia;
            dtgTodosSetores.Columns[colDataInicioTodos.Name].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dtgTodosSetores.Columns[colDataFimTodos.Name].DataPropertyName = RequisicaoDTO.FieldNames.SetorPedidoAutoDtHoraFimVigencia;
            dtgTodosSetores.Columns[colDataFimTodos.Name].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dtgTodosSetores.Columns[colSetor.Name].DataPropertyName = SetorDTO.FieldNames.Descricao;
            dtgTodosSetores.Columns[colIdUnidade.Name].DataPropertyName = SetorDTO.FieldNames.IdtUnidade;
            dtgTodosSetores.Columns[colIdLocal.Name].DataPropertyName = SetorDTO.FieldNames.IdtLocalAtendimento;
            dtgTodosSetores.Columns[colIdSetor.Name].DataPropertyName = SetorDTO.FieldNames.Idt;
        }

        private RequisicaoDataTable CarregarGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            RequisicaoDTO dtoReq = new RequisicaoDTO();
            dtoReq.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            RequisicaoDataTable dtbReq = Requisicao.ListarParamPedidoAuto(dtoReq);
            dtgPeriodo.DataSource = dtbReq;
            dtgPeriodo.ClearSelection();
            this.Cursor = Cursors.Default;
            return dtbReq;
        }

        private void CarregarTodos()
        {
            this.Cursor = Cursors.WaitCursor;
            RequisicaoDataTable dtbReq = Requisicao.ListarParamPedidoAuto(new RequisicaoDTO());
            dtbReq = (RequisicaoDataTable)gen.ValidarVigencia(Utilitario.ObterDataHoraServidor(),
                                                              RequisicaoDTO.FieldNames.SetorPedidoAutoDtHoraIniVigencia,
                                                              RequisicaoDTO.FieldNames.SetorPedidoAutoDtHoraFimVigencia,
                                                              dtbReq);
            dtgTodosSetores.DataSource = dtbReq;
            dtgTodosSetores.ClearSelection();
            this.Cursor = Cursors.Default;
        }

        private RequisicaoDTO ObterRegistroSetor(string dtIni, string hrIni)
        {
            if (cmbSetor.SelectedIndex == -1 || cmbSetor.SelectedValue == null) 
            {
                MessageBox.Show("Selecione o Setor.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return null;
            }

            this.Cursor = Cursors.WaitCursor;

            RequisicaoDTO dtoReq = new RequisicaoDTO();

            dtoReq.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoReq.SetorPedidoAutoDtHoraIniVigencia.Value = BasicFunctions.JuntarData(DateTime.Parse(dtIni), hrIni.Replace(":","")).ToString();

            RequisicaoDataTable dtbReq = Requisicao.ListarParamPedidoAuto(dtoReq);

            if (dtbReq.Rows.Count > 0)
                dtoReq = dtbReq.TypedRow(0);
            else
                dtoReq = null;

            this.Cursor = Cursors.Default;

            return dtoReq;
        }

        private bool ValidarVigencia(bool verificarRegistroSetor)
        {
            DateTime dtIni;
            DateTime? dtFim = null;
            if (string.IsNullOrEmpty(txtDtInicio.Text) || string.IsNullOrEmpty(txtHrIniVig.Text))
            {
                MessageBox.Show("Data/Hora Início Obrigatória.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDtInicio.Focus();
                return false;
            }
            else
                dtIni = BasicFunctions.JuntarData(DateTime.Parse(txtDtInicio.Text), txtHrIniVig.Text + "00");

            RequisicaoDataTable dtbReq = CarregarGrid();

            if (!string.IsNullOrEmpty(txtDtFim.Text))
            {
                if (string.IsNullOrEmpty(txtHrFimVig.Text))
                {
                    MessageBox.Show("Digite a Hora Fim.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtDtInicio.Focus();
                    return false;
                }
                else
                    dtFim = BasicFunctions.JuntarData(DateTime.Parse(txtDtFim.Text), txtHrFimVig.Text + "00");

                if (dtIni > dtFim)
                {
                    MessageBox.Show("Data Fim Vigência deve ser maior ou igual que a Data Início.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if (dtFim < Utilitario.ObterDataHoraServidor())
                {
                    MessageBox.Show("Data Fim Vigência deve ser maior ou igual que a Data Atual.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if (dtFim != dtIni)
                {
                    if (dtFim < dtIni.AddHours(PadraoQtdTotalHrsGerar))
                    {
                        MessageBox.Show("Data Fim Vigência deve ser superior à " + PadraoQtdTotalHrsGerar + " horas da Data Início de Vigência.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    RequisicaoDTO dtoReqVerifica;
                    foreach (DataRow row in dtbReq.Rows)
                    {
                        dtoReqVerifica = (RequisicaoDTO)row;
                        if (DateTime.Parse(dtoReqVerifica.SetorPedidoAutoDtHoraIniVigencia.Value.ToString()) > dtIni)
                        {
                            if (dtFim > DateTime.Parse(dtoReqVerifica.SetorPedidoAutoDtHoraIniVigencia.Value.ToString()))
                            {
                                MessageBox.Show("Já há um registro posterior em Vigência, a Data Fim deve ser menor que o Início das próximas Vigências.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return false;
                            }
                        }
                    }
                }
            }
            else
            {
                RequisicaoDTO dtoReqVerifica;
                foreach (DataRow row in dtbReq.Rows)
                {
                    dtoReqVerifica = (RequisicaoDTO)row;
                    if (DateTime.Parse(dtoReqVerifica.SetorPedidoAutoDtHoraIniVigencia.Value.ToString()) > dtIni)
                    {
                        if (dtoReqVerifica.SetorPedidoAutoDtHoraFimVigencia.Value.IsNull || DateTime.Parse(dtoReqVerifica.SetorPedidoAutoDtHoraFimVigencia.Value.ToString()) > Utilitario.ObterDataHoraServidor())
                        {
                            MessageBox.Show("Já há um registro posterior em Vigência, tornando a Data Fim obrigatória.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }                        
                    }
                }
            }

            if (verificarRegistroSetor)
            {
                if (dtIni < Utilitario.ObterDataHoraServidor())
                {
                    MessageBox.Show("Data Início Vigência deve ser maior ou igual que a Data Atual.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }                
                if (dtbReq.Rows.Count > 0)
                {
                    if (dtbReq.TypedRow(0).SetorPedidoAutoDtHoraFimVigencia.Value.IsNull)
                    {
                        MessageBox.Show("Última Data Fim Vigência deve estar cadastrada para poder inserir um novo registro.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                    else if (((DateTime)dtbReq.TypedRow(0).SetorPedidoAutoDtHoraIniVigencia.Value) != ((DateTime)dtbReq.TypedRow(0).SetorPedidoAutoDtHoraFimVigencia.Value))
                    {
                        if (dtIni < ((DateTime)dtbReq.TypedRow(0).SetorPedidoAutoDtHoraIniVigencia.Value).AddHours(PadraoQtdTotalHrsGerar))
                        {
                            MessageBox.Show("Data Início Vigência deve ser superior à " + PadraoQtdTotalHrsGerar + " horas do último Início de Vigência.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                    }                                      
                    dtbReq = (RequisicaoDataTable)gen.ValidarVigencia(BasicFunctions.JuntarData(DateTime.Parse(txtDtInicio.Text), txtHrIniVig.Text + "01"),
                                                                                                RequisicaoDTO.FieldNames.SetorPedidoAutoDtHoraIniVigencia,
                                                                                                RequisicaoDTO.FieldNames.SetorPedidoAutoDtHoraFimVigencia,
                                                                                                dtbReq);
                    if (dtbReq.Rows.Count > 0)
                    {
                        MessageBox.Show("Vigência já existente.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
            }

            return true;
        }        

        private void Salvar()
        {
            this.Cursor = Cursors.WaitCursor;
            dtoRequisicao = new RequisicaoDTO();

            dtoRequisicao.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoRequisicao.SetorPedidoAutoDtHoraIniVigencia.Value = BasicFunctions.JuntarData(DateTime.Parse(txtDtInicio.Text), txtHrIniVig.Text + "00");
            if (!string.IsNullOrEmpty(txtDtFim.Text) && !string.IsNullOrEmpty(txtHrFimVig.Text))
                dtoRequisicao.SetorPedidoAutoDtHoraFimVigencia.Value = BasicFunctions.JuntarData(DateTime.Parse(txtDtFim.Text), txtHrFimVig.Text + "00");
            dtoRequisicao.SetorPedidoAutoHoraInicioProcesso.Value = txtHoraInicio.Text;
            dtoRequisicao.SetorPedidoAutoHorasTotaisGerar.Value = PadraoQtdTotalHrsGerar; //txtQtdTotalHorasGerar.Text;
            dtoRequisicao.SetorPedidoAutoHorasPeriodoDose.Value = cmbPeriodoGerar.SelectedValue.ToString();
            dtoRequisicao.SetorPedidoAutoHorasMinimaIniciar.Value = txtQtdMinimaHorasAbast.Text;
            dtoRequisicao.SetorPedidoAutoFlNaoGerar.Value = chbNaoGerar.Checked ? 1 : 0;
            dtoRequisicao.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

            if (txtDtInicio.Enabled)
            {
                Requisicao.InsParamPedidoAuto(dtoRequisicao);
            }
            else
            {
                Requisicao.UpdParamPedidoAuto(dtoRequisicao);
            }
            this.Cursor = Cursors.Default;
        }

        #endregion

        #region EVENTOS

        private void FrmSetorPedidoAutoParam_Load(object sender, EventArgs e)
        {            
            cmbUnidade.Carregaunidade();
            cmbPeriodoGerar.Carregar();
            ConfigGrid();
            CarregarTodos();
        }

        private bool tsHac_NovoClick(object sender)
        {
            return true;
        }

        private bool tsHac_AfterNovo(object sender)
        {
            if (cmbSetor.SelectedIndex != -1 && cmbSetor.SelectedValue != null)
            {
                RequisicaoDataTable dtbReq = CarregarGrid();
                if (dtbReq.Rows.Count > 0)
                {
                    if (dtbReq.TypedRow(0).SetorPedidoAutoDtHoraFimVigencia.Value.IsNull)
                    {
                        Controla(Evento.eCancelar);
                        return false;
                    }
                }
            }
            else
            {
                dtbRequisicao = new RequisicaoDataTable();
                dtgPeriodo.DataSource = dtbRequisicao;
            }
            btnExcluir.Visible = false;
            cmbUnidade.Enabled = cmbLocal.Enabled = cmbSetor.Enabled = false;
            txtHoraInicio.Text = PadraoHoraCorteProcesso.ToString();
            //txtQtdTotalHorasGerar.Text = PadraoQtdTotalHrsGerar.ToString();
            txtDtInicio.Focus();
            return true;
        }

        private bool tsHac_CancelarClick(object sender)
        {
            return true;
        }

        private void tsHac_AfterCancelar(object sender)
        {
            dtoRequisicao = null;
            dtbRequisicao = new RequisicaoDataTable();
            dtgPeriodo.DataSource = dtbRequisicao;
            btnExcluir.Visible = false;

            //cmbUnidade.IniciaLista();
            //cmbLocal.IniciaLista();
            cmbSetor.IniciaLista();
        }

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Controla(Evento.eCancelar);
            dtbRequisicao = new RequisicaoDataTable();
            dtgPeriodo.DataSource = dtbRequisicao;
            tsHac.Items["tsBtnNovo"].Enabled = true;
        }

        private bool tsHac_SalvarClick(object sender)
        {
            if (cmbSetor.SelectedIndex == -1 || cmbSetor.SelectedValue == null)
            {
                MessageBox.Show("Selecione o Setor.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (int.Parse(txtHoraInicio.Text) > 23)
            {
                MessageBox.Show("Hora corte inválida.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtHoraInicio.Focus();
                return false;
            }
            if (!txtDtFim.Enabled)
            {
                MessageBox.Show("Vigência já fechada não permitindo alteração.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (txtDtInicio.Enabled)
            {
                this.Cursor = Cursors.WaitCursor;
                if (!this.ValidarVigencia(true))
                {
                    this.Cursor = Cursors.Default;
                    return false;
                }
                this.Cursor = Cursors.Default;
            }
            else
            {
                if (!this.ValidarVigencia(false)) return false;
            }
            if (int.Parse(txtQtdMinimaHorasAbast.Text) > 4)
            {
                MessageBox.Show("Qtd. Horas Início Emissão não pode ser maior que 4.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            
            this.Salvar();
            this.CarregarGrid();
            this.CarregarTodos();
            txtDtInicio.Enabled = txtHrIniVig.Enabled = false;

            return true;
        }

        private void txtDtInicio_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDtInicio.Text) && BasicFunctions.ValidarData(txtDtInicio.Text))
            {
                //txtHrIniVig.Text = string.Empty;
                txtHrIniVig.Focus();
            }
        }

        private void txtHrIniVig_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtHrIniVig.Text) || !txtHrIniVig.Enabled) return;
            if (!string.IsNullOrEmpty(txtHrIniVig.Text) && this.ValidarHora(txtHrIniVig))
            {
                dtoRequisicao = this.ObterRegistroSetor(txtDtInicio.Text, txtHrIniVig.Text + "00");
                if (dtoRequisicao != null)
                {
                    MessageBox.Show("Data/Hora já cadastrada.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }

        private void txtDtFim_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDtFim.Text) && BasicFunctions.ValidarData(txtDtFim.Text))
            {
                //txtHrFimVig.Text = string.Empty;
                txtHrFimVig.Focus();
            }
        }

        private void txtHrFimVig_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtHrFimVig.Text) && !this.ValidarHora(txtHrFimVig))
                txtHrFimVig.Text = string.Empty;
        }

        private void dtgPeriodo_SelectionChanged(object sender, EventArgs e) {}

        private void dtgPeriodo_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnExcluir.Visible = false;
            if (e != null && e.RowIndex > -1)
            {
                dtoRequisicao = this.ObterRegistroSetor(((DateTime)dtgPeriodo.CurrentRow.Cells[colDtIni.Name].Value).ToString("dd/MM/yyyy"),
                                                        ((DateTime)dtgPeriodo.CurrentRow.Cells[colDtIni.Name].Value).ToString("HHmm"));

                if (dtoRequisicao == null) return;

                if (!dtoRequisicao.SetorPedidoAutoDtHoraFimVigencia.Value.IsNull)
                {
                    if (DateTime.Parse(dtoRequisicao.SetorPedidoAutoDtHoraFimVigencia.Value.ToString()) >= Utilitario.ObterDataHoraServidor())
                        Controla(Evento.eNovo);
                    else
                        Controla(Evento.eCancelar);

                    txtDtFim.Text = ((DateTime)dtoRequisicao.SetorPedidoAutoDtHoraFimVigencia.Value).ToString("dd/MM/yyyy");
                    txtHrFimVig.Text = ((DateTime)dtoRequisicao.SetorPedidoAutoDtHoraFimVigencia.Value).ToString("HH");
                }
                else
                    Controla(Evento.eNovo);                

                txtDtInicio.Text = ((DateTime)dtoRequisicao.SetorPedidoAutoDtHoraIniVigencia.Value).ToString("dd/MM/yyyy");
                txtHrIniVig.Text = ((DateTime)dtoRequisicao.SetorPedidoAutoDtHoraIniVigencia.Value).ToString("HH");

                txtHoraInicio.Text = dtoRequisicao.SetorPedidoAutoHoraInicioProcesso.Value;
                //txtQtdTotalHorasGerar.Text = dtoRequisicao.SetorPedidoAutoHorasTotaisGerar.Value;
                cmbPeriodoGerar.SelectedValue = dtoRequisicao.SetorPedidoAutoHorasPeriodoDose.Value.ToString();
                txtQtdMinimaHorasAbast.Text = dtoRequisicao.SetorPedidoAutoHorasMinimaIniciar.Value;
                if (dtoRequisicao.SetorPedidoAutoFlNaoGerar.Value.IsNull) dtoRequisicao.SetorPedidoAutoFlNaoGerar.Value = 0;
                chbNaoGerar.Checked = dtoRequisicao.SetorPedidoAutoFlNaoGerar.Value == 1 ? true : false; 

                if (e.RowIndex == 0) btnExcluir.Visible = btnExcluir.Enabled = true;
                cmbUnidade.Enabled = cmbLocal.Enabled = cmbSetor.Enabled = false;
                txtDtInicio.Enabled = txtHrIniVig.Enabled = false;
                if (string.IsNullOrEmpty(txtDtFim.Text)) txtDtFim.Focus();
            }
        }

        private void dtgTodosSetores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e != null && e.RowIndex > -1)
            {
                Controla(Evento.eCancelar);
                cmbUnidade.SelectedValue = dtgTodosSetores.CurrentRow.Cells[colIdUnidade.Name].Value.ToString();
                cmbLocal.SelectedValue = dtgTodosSetores.CurrentRow.Cells[colIdLocal.Name].Value.ToString();
                cmbSetor.SelectedValue = dtgTodosSetores.CurrentRow.Cells[colIdSetor.Name].Value.ToString();
                cmbSetor_SelectionChangeCommitted(null, null);                
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            RequisicaoDTO dtoReq = new RequisicaoDTO();
            RequisicaoItensDTO dtoReqItem = new RequisicaoItensDTO();
            dtoReq.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoReq.DataRequisicao.Value = BasicFunctions.JuntarData(DateTime.Parse(txtDtInicio.Text), txtHrIniVig.Text + "00");
            dtoReqItem.IdUsuarioPedidoAutoCancelado.Value = FrmPrincipal.dtoSeguranca.Idt.Value; //Passa o usuário para não trazer cancelados            
            RequisicaoItensDataTable dtbRI = RequisicaoItens.ListarPedidoAutoControle(dtoReqItem, dtoReq, 1);
            if (dtbRI.Rows.Count > 0)
            {
                MessageBox.Show("Há pedidos pendentes de geração ou dispensados, impossibilitando a exclusão. Neste caso é aconselhável fechar a vigência neste cadastro, ou cancelar as pendências.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Cursor = Cursors.Default;
                return;
            }
            if (MessageBox.Show("Deseja realmente excluir este registro ?",
                                "Gestão de Materiais e Medicamentos",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RequisicaoDTO dtoReqExcluir = new RequisicaoDTO();

                dtoReqExcluir.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                dtoReqExcluir.SetorPedidoAutoDtHoraIniVigencia.Value = BasicFunctions.JuntarData(DateTime.Parse(txtDtInicio.Text), txtHrIniVig.Text + "00");
                dtoReqExcluir.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                Requisicao.DelParamPedidoAuto(dtoReqExcluir);

                this.CarregarGrid();
                this.CarregarTodos();
                Controla(Evento.eCancelar);
                btnExcluir.Visible = false;
            }
            this.Cursor = Cursors.Default;
        }

        #endregion
        
    }
}