using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using System.Threading;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmPrincipioAtivo : FrmBase
    {
        public FrmPrincipioAtivo()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇO

        private int _grupoAnteriorSelecionado = 0;
        // MatMed
        private MaterialMedicamentoDTO dtoMatMed;        
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject( typeof(IMaterialMedicamento)); }
        }

        // Similar
        private MatMedSimilarDataTable dtbSimilar;
        private MatMedSimilarDTO dtoSimilar;
        private IMatMedSimilar _similar;
        private IMatMedSimilar Similar
        {
            get { return _similar != null ? _similar : _similar = (IMatMedSimilar)Global.Common.GetObject(typeof(IMatMedSimilar)); }
        }

        private IPrincipioAtivo _principioAtivo;
        private IPrincipioAtivo PrincipioAtivo
        {
            get { return _principioAtivo != null ? _principioAtivo : _principioAtivo = (IPrincipioAtivo)Global.Common.GetObject(typeof(IPrincipioAtivo)); }
        }

        #endregion

        #region FUNÇÕES

        private void ConfiguraDTG()
        {
            dtgMatMed.AutoGenerateColumns = false;
            dtgMatMed.Columns["colMatMedIdt"].DataPropertyName = MatMedSimilarDTO.FieldNames.IdProduto;
            dtgMatMed.Columns["colMatMedDescricao"].DataPropertyName = MatMedSimilarDTO.FieldNames.DsProduto;
        }

        private void CarregarMatMedRelacionado()
        {
            dtoSimilar.IdProduto.Value = dtoMatMed.Idt.Value;
            dtoSimilar.IdPrincipioAtivo.Value = dtoMatMed.IdtPrincipioAtivo.Value;
            dtoSimilar.FlAtivo.Value = (byte)MatMedSimilarDTO.Ativo.SIM;
            dtbSimilar = Similar.ListarSimilares(dtoSimilar, null);
            dtgMatMed.DataSource = dtbSimilar;
        }

        /// <summary>
        /// Método a ser usado na execução da thread
        /// </summary>        
        private void CarregarComboMatMed()
        {
            MaterialMedicamentoDTO dtoMatMedAux = new MaterialMedicamentoDTO();

            dtoMatMedAux.TpPesquisa.Value = (int)MaterialMedicamentoDTO.TipoDePesquisa.SEM_ESTOQUE;
            
            if ((int)dtoMatMed.IdtGrupo.Value == 1)
                dtoMatMedAux.Tabelamedica.Value = ((int)MaterialMedicamentoDTO.TipoMatMed.MEDICAMENTO).ToString();
            else if ((int)dtoMatMed.IdtGrupo.Value == 6)
                dtoMatMedAux.IdtGrupo.Value = 6;

            dtoMatMedAux.NomeFantasia.Value = "%";

            CarregaComboDelegate carregaComboDelegate = new CarregaComboDelegate(CarregarComboMatMed);
            try
            {
                cmbMatMed.Invoke(carregaComboDelegate, MatMed.Sel(dtoMatMedAux));                
            }
            catch
            {
                //Se cair aqui é porque o usuário abriu e fechou a tela rapidamente
            }

            dtoMatMedAux = null;
        }

        private delegate void CarregaComboDelegate(MaterialMedicamentoDataTable dtb);
        /// <summary>
        /// Método a ser usado pelo delegate CarregaComboDelegate
        /// </summary>        
        private void CarregarComboMatMed(MaterialMedicamentoDataTable dtb)
        {
            cmbMatMed.ValueMember = MaterialMedicamentoDTO.FieldNames.Idt;
            cmbMatMed.DisplayMember = MaterialMedicamentoDTO.FieldNames.NomeFantasia;
            cmbMatMed.DataSource = dtb;
            cmbMatMed.IniciaLista();
            cmbMatMed.Enabled = true;
        }

        private void AdicionarItem()
        {
            if (cmbMatMed.SelectedIndex > -1)
            {
                if (dtoMatMed.Idt.Value.ToString() == cmbMatMed.SelectedValue.ToString())
                {
                    MessageBox.Show("Não pode ser adicionado o próprio item na lista dos seus similares", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbMatMed.Focus();
                    return;
                }
                if (dtbSimilar.Select(string.Format("{0} = {1}",
                                      MatMedSimilarDTO.FieldNames.IdProduto,
                                      cmbMatMed.SelectedValue.ToString())).Length > 0)
                {
                    MessageBox.Show("Já foi adicionado o item selecionado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbMatMed.Focus();
                    return;
                }

                dtoSimilar.IdProduto.Value = cmbMatMed.SelectedValue.ToString();
                MaterialMedicamentoDTO dtoMatMedAux = new MaterialMedicamentoDTO();
                dtoMatMedAux.Idt.Value = dtoSimilar.IdProduto.Value;
                dtoSimilar.DsProduto.Value = MatMed.SelChave(dtoMatMedAux).NomeFantasia.Value;
                dtoSimilar.IdUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                dtbSimilar.Add(dtoSimilar);
                dtgMatMed.DataSource = dtbSimilar;

                cmbMatMed.IniciaLista();                
            }
            cmbMatMed.Focus();
        }

        #endregion

        #region EVENTOS

        private void FrmPrincipioAtivo_Load(object sender, EventArgs e)
        {
            ConfiguraDTG();
            tsHac.Controla(Evento.eNovo);            
        }

        private bool tsHac_MatMedClick(object sender)
        {
            MaterialMedicamentoDTO dtoMatMedAux = new MaterialMedicamentoDTO();

            //dtoMatMedAux.Tabelamedica.Value = ((int)MaterialMedicamentoDTO.TipoMatMed.MEDICAMENTO).ToString();
            dtoMatMedAux.TpPesquisa.Value = (int)MaterialMedicamentoDTO.TipoDePesquisa.SEM_ESTOQUE;
            dtoMatMedAux = FrmPesquisaMatMed.SelecionaMatMed(dtoMatMedAux);
            lblSal.Text = lblFormaFarm.Text = lblFormaFarm.Text = "--";
            grbDadosMed.Enabled = true; ConfigurarControles(grbDadosMed.Controls, true);
            cmbMatMed.Enabled = false; cbIrritante.Checked = cbVesicante.Checked = cbFlebitante.Checked = btnSalvar.Enabled = false;
            txtOrientacao.Text = string.Empty;

            if (dtoMatMedAux != null && !dtoMatMedAux.Idt.Value.IsNull)
            {
                if ((int)dtoMatMedAux.IdtGrupo.Value != 1 && (int)dtoMatMedAux.IdtGrupo.Value != 6)
                {
                    MessageBox.Show("Só é possível selecionar produtos que são Grupo 1 ou 6.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtoMatMed = null;
                    return false;
                }
                //if (dtoMatMedAux.IdtPrincipioAtivo.Value == 0)
                //{
                //    MessageBox.Show(string.Format("Este medicamento não tem princípio ativo cadastrado para poder ser vinculado algum similar a ele.\n\nSelecione um similar de {0}, e o inclua como similar, para incluir o seu princípio ativo e poder realizar esta operação.", 
                //                    dtoMatMedAux.NomeFantasia.Value), 
                //                    "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //}
                //else
                //{                    
                dtoMatMed = dtoMatMedAux;

                dtoSimilar = new MatMedSimilarDTO();

                lblMed.Text = dtoMatMed.NomeFantasia.Value;
                lblSal.Text = dtoMatMed.Sal.Value;
                lblFormaFarm.Text = dtoMatMed.FormaFarmaceutica.Value;
                lblDosagem.Text = dtoMatMed.Dosagem.Value;
                if ((int)dtoMatMed.IdtGrupo.Value == 1 && dtoMatMed.IdtPrincipioAtivo.Value != 0)
                {
                    PrincipioAtivoDTO dtoPA = new PrincipioAtivoDTO();
                    dtoPA.Idt.Value = dtoMatMed.IdtPrincipioAtivo.Value;
                    dtoPA = PrincipioAtivo.SelChave(dtoPA);
                    cbIrritante.Checked = (dtoPA.FlIrritante.Value.IsNull || dtoPA.FlIrritante.Value == 0) ? false : true;
                    cbVesicante.Checked = (dtoPA.FlVesicante.Value.IsNull || dtoPA.FlVesicante.Value == 0) ? false : true;
                    cbFlebitante.Checked = (dtoPA.FlFlebitante.Value.IsNull || dtoPA.FlFlebitante.Value == 0) ? false : true;
                    txtOrientacao.Text = (dtoPA.DsOrientacao.Value.IsNull || dtoPA.DsOrientacao.Value == string.Empty) ? string.Empty : dtoPA.DsOrientacao.Value.ToString();
                    btnSalvar.Enabled = true;
                }
                else if ((int)dtoMatMed.IdtGrupo.Value == 1)
                    btnSalvar.Enabled = true;
                else
                    grbDadosMed.Enabled = false;

                CarregarMatMedRelacionado();
                grbAddMed.Enabled = true;
                btnAdd.Enabled = true;
                cmbMatMed.Focus();
                //}

                if (_grupoAnteriorSelecionado != (int)dtoMatMed.IdtGrupo.Value)
                {
                    cmbMatMed.Text = "A G U A R D E !!!";
                    //Iniciar thread que carrega o combo 
                    new Thread(new ThreadStart(CarregarComboMatMed)).Start();
                }
                else
                    cmbMatMed.Enabled = true;

                _grupoAnteriorSelecionado = (int)dtoMatMedAux.IdtGrupo.Value;
            }
            else if (dtoMatMed != null && !dtoMatMed.Idt.Value.IsNull)
                cmbMatMed.Enabled = true;

            dtoMatMedAux = null;
            return false;
        }

        private bool tsHac_SalvarClick(object sender)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                btnSalvar_Click(null, null);
                dtoSimilar = new MatMedSimilarDTO();
                dtoSimilar.IdUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                dtoSimilar.IdProduto.Value = dtoMatMed.Idt.Value;
                if (dtoMatMed.IdtPrincipioAtivo.Value.IsNull) dtoMatMed.IdtPrincipioAtivo.Value = 0;
                dtoSimilar.IdPrincipioAtivo.Value = dtoMatMed.IdtPrincipioAtivo.Value;
                Similar.Grava(dtbSimilar, ref dtoSimilar);
                if (!dtoSimilar.IdPrincipioAtivo.Value.IsNull && dtoSimilar.IdPrincipioAtivo.Value > 0 && dtoMatMed.IdtPrincipioAtivo.Value != dtoSimilar.IdPrincipioAtivo.Value)
                    dtoMatMed.IdtPrincipioAtivo.Value = dtoSimilar.IdPrincipioAtivo.Value;
                CarregarMatMedRelacionado();
                MessageBox.Show("Registro(s) salvo(s) com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AdicionarItem();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (dtoMatMed != null && !dtoMatMed.Idt.Value.IsNull && (int)dtoMatMed.IdtGrupo.Value == 1)
            {
                this.Cursor = Cursors.WaitCursor;
                PrincipioAtivoDTO dtoPA = new PrincipioAtivoDTO();
                dtoPA.DsPrincipioAtivo.Value = lblSal.Text;
                dtoPA.FlIrritante.Value = cbIrritante.Checked ? 1 : 0;
                dtoPA.FlVesicante.Value = cbVesicante.Checked ? 1 : 0;
                dtoPA.FlFlebitante.Value = cbFlebitante.Checked ? 1 : 0;
                if (!string.IsNullOrEmpty(txtOrientacao.Text)) dtoPA.DsOrientacao.Value = txtOrientacao.Text;
                dtoPA.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                if (dtoMatMed.IdtPrincipioAtivo.Value != 0)
                {
                    dtoPA.Idt.Value = dtoMatMed.IdtPrincipioAtivo.Value;
                    PrincipioAtivo.Upd(dtoPA);
                }
                else
                {
                    dtoPA = PrincipioAtivo.Ins(dtoPA);
                    dtoMatMed.IdtPrincipioAtivo.Value = dtoPA.Idt.Value;
                    MatMed.AtualizarPrincipioAtivo(dtoMatMed);
                    
                    dtoSimilar = new MatMedSimilarDTO();
                    dtoSimilar.IdUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;
                    dtoSimilar.IdProduto.Value = dtoMatMed.Idt.Value;                
                    dtoSimilar.IdPrincipioAtivo.Value = dtoMatMed.IdtPrincipioAtivo.Value;
                    Similar.Ins(dtoSimilar);

                    if (dtbSimilar != null)
                    {
                        foreach (DataRow row in dtbSimilar.Rows)
                        {
                            row[MatMedSimilarDTO.FieldNames.IdPrincipioAtivo] = dtoSimilar.IdPrincipioAtivo.Value;
                        }
                    }
                }

                if (sender != null) MessageBox.Show("Registro salvo com sucesso.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Cursor = Cursors.Default;
            }
        }

        private void cmbMatMed_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbMatMed.SelectedIndex != -1)
            {
                //Se teclar enter, foca btnAdd
                //if (e.KeyValue == 13) btnAdd.Focus();

                //Se teclar enter, adiciona no grid
                if (e.KeyValue == 13) btnAdd_Click(sender, e);
            }
        }

        private void dtgMatMed_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgMatMed.Columns[e.ColumnIndex].Name == "colDeletar")
            {
                if (MessageBox.Show("Deseja deletar esse produto da lista ?",
                                     "Gestão de Materiais e Medicamentos",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    for (int nCount = 0; nCount < dtbSimilar.Rows.Count; nCount++)
                    {
                        if (dtbSimilar.Rows[nCount].RowState != DataRowState.Deleted)
                        {
                            if (dtbSimilar.Rows[nCount][MatMedSimilarDTO.FieldNames.IdProduto].ToString() == dtgMatMed.Rows[e.RowIndex].Cells["colMatMedIdt"].Value.ToString())
                            {
                                dtbSimilar.Rows[nCount].Delete();
                                break;
                            }
                        }
                    }
                }

            }
        }        

        #endregion
    }
}