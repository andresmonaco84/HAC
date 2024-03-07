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
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.Seguranca.View;
using HospitalAnaCosta.SGS.Seguranca.Interface;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Estoque
{
    public partial class FrmPesquisaMatMed : FrmBase
    {
        private bool usaMatMedFunc = false;

        #region OBJETOS SERVIÇOS

        private CommonSeguranca _commonSeguranca;
        protected CommonSeguranca CommonSeguranca
        {
            get { return _commonSeguranca != null ? _commonSeguranca : _commonSeguranca = new CommonSeguranca(null); }
        }

        // Funcionalidade
        private IFuncionalidade _funcionalidade;
        private IFuncionalidade Funcionalidade
        {
            get { return _funcionalidade != null ? _funcionalidade : _funcionalidade = (IFuncionalidade)CommonSeguranca.GetObject(typeof(IFuncionalidade)); }
        }

        //private static decimal? _idtFilial;                
        private MaterialMedicamentoDTO dtoMatMed;
        private MaterialMedicamentoDTO dtoMatMedAux;
        private MaterialMedicamentoDataTable dtbMatMed;        
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get
            {
                return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject( typeof(IMaterialMedicamento));
            }
        }

        private MatMedFuncionalidadeDTO dtoMatMedFunc;
        private MatMedFuncionalidadeDataTable dtbMatMedFunc;
        private IMatMedFuncionalidade _matMedFuncionalidade;
        private IMatMedFuncionalidade MatMedFuncionalidade
        {
            get { return _matMedFuncionalidade != null ? _matMedFuncionalidade : _matMedFuncionalidade = (IMatMedFuncionalidade)Global.Common.GetObject(typeof(IMatMedFuncionalidade)); }
        }

        #endregion

        public FrmPesquisaMatMed()
        {
            InitializeComponent();
        }       

        public static MaterialMedicamentoDTO SelecionaMatMed(MaterialMedicamentoDTO dto)
        {
            FrmPesquisaMatMed frmPesquisaMatMed = new FrmPesquisaMatMed();

            SetorDTO _dtoSetorSelSubGrupoPermissao = new SetorDTO();
            _dtoSetorSelSubGrupoPermissao.Idt.Value = dto.IdtSetor.Value;
            _dtoSetorSelSubGrupoPermissao.IdtUnidade.Value = dto.IdtUnidade.Value;
            _dtoSetorSelSubGrupoPermissao.IdtLocalAtendimento.Value = dto.IdtLocal.Value;

            // _enumTipoMatMed = dto.Tabelamedica.Value; // Tipo do Produto
            // _idtFilial = dto.IdtFilial.Value;
            frmPesquisaMatMed.dtoMatMed = dto;
            // frmPesquisaMatMed.MdiParent = frmOpener;
            frmPesquisaMatMed.ShowDialog();

            return frmPesquisaMatMed.dtoMatMed;
        }           

        /// <summary>
        /// Busca Produtos na Base conforme informações digitadas pelo usuário
        /// </summary>
        private void CarregaGrid()
        {
            this.Cursor = Cursors.WaitCursor;
            // dtoMatMedAux = new MaterialMedicamentoDTO();
            dtoMatMedAux = dtoMatMed;
            try
            {
                if (txtNomeFantasia.Text.IndexOf("%") == -1)
                    dtoMatMed.NomeFantasia.Value = string.Format("{0}%", txtNomeFantasia.Text.Trim());
                else
                    dtoMatMed.NomeFantasia.Value = txtNomeFantasia.Text.Trim();
                
                // BUSCA PRODUTOS QUE SETOR TEM ACESSO
                if (dtoMatMed.TpPesquisa.Value == (int)MaterialMedicamentoDTO.TipoDePesquisa.COM_PERMISSAO_SUBGRUPO)
                {
                    int idFilial = 0;
                    if (!dtoMatMed.IdtFilial.Value.IsNull)
                    {
                        idFilial = (int)dtoMatMed.IdtFilial.Value;
                        if (!dtoMatMedAux.IdtFilial.Value.IsNull)
                            dtoMatMedAux.IdtFilial.Value = new Framework.DTO.TypeDecimal();
                    }

                    dtbMatMed = MatMed.SelSubGrupoSetorPermissao(dtoMatMedAux);

                    dtoMatMedAux.IdtFilial.Value = idFilial;
                }
                // BUSCA PRODUTOS QUE ESTÃO CADASTRADOS NA TABELA QUE LIBERA ACESSO
                else if (dtoMatMed.TpPesquisa.Value == (int)MaterialMedicamentoDTO.TipoDePesquisa.COM_PERMISSAO)
                {
                    FuncionalidadeDTO dtoFunc = new FuncionalidadeDTO();
                    dtoFunc.NmPagina.Value = "OutrosProdutosAvulsos";
                    dtoFunc.FiltraAssociados.Value = 2;
                    FuncionalidadeDataTable dtbFunc = Funcionalidade.Sel(dtoFunc);
                    if (dtbFunc.Rows.Count == 0)
                    {
                        MessageBox.Show("Funcionalidade 'PEDIDO DE PRODUTOS AVULSOS (OUTROS) - OutrosProdutosAvulsos' não cadastrada. Contate um administrador do sistema.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dtoMatMed = null;
                        dtoMatMedAux = null;
                        Close();
                        return;
                    }
                    else
                    {
                        dtoMatMedFunc = new MatMedFuncionalidadeDTO();
                        dtoMatMedFunc.IdFuncionalidade.Value = dtbFunc.TypedRow(0).Idt.Value;
                        dtoMatMedFunc.NomeFantasia.Value = string.Format("{0}%", txtNomeFantasia.Text);
                        dtbMatMedFunc = MatMedFuncionalidade.Sel(dtoMatMedFunc);                        
                    }
                    usaMatMedFunc = true;
                }
                // TODOS DO CADASTRO
                else
                {
                    dtbMatMed = MatMed.Sel(dtoMatMedAux);
                }

                dtgMatMed.AutoGenerateColumns = false;
                dtgMatMed.Columns["colDescricao"].DataPropertyName = MaterialMedicamentoDTO.FieldNames.NomeFantasia;
                dtgMatMed.Columns["colIdt"].DataPropertyName = MaterialMedicamentoDTO.FieldNames.Idt;
                dtgMatMed.Columns["colDsUnidadeVenda"].DataPropertyName = MaterialMedicamentoDTO.FieldNames.UnidadeVenda;
                dtgMatMed.Columns["colFracionado"].DataPropertyName = MaterialMedicamentoDTO.FieldNames.FlFracionado;

                if (!usaMatMedFunc)
                {
                    dtgMatMed.DataSource = dtbMatMed;
                }
                else
                {
                    dtgMatMed.DataSource = dtbMatMedFunc;
                }
                
                if (dtgMatMed.Rows.Count == 0)
                {
                    MessageBox.Show("Não foi encontrado nenhum Produto no formato digitado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNomeFantasia.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format("{0}", ex.Message), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Cursor = Cursors.Default;
        }

        private void btnPesquisa_Click(object sender, EventArgs e)
        {
            if (txtNomeFantasia.Text != string.Empty)
            {
                //txtNomeFantasia.Text = txtNomeFantasia.Text.Replace("%", "");
                if (txtNomeFantasia.Text.Length <= 3)
                {
                    MessageBox.Show("Digitar 4 ou mais caracteres.", "Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtNomeFantasia.Focus();
                }
                else
                {
                    CarregaGrid();
                }
            }
        }

        private void dtgMatMed_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!usaMatMedFunc)
            {
                //Se usa tabela de matmed não precisa ir no banco novamente
                dtoMatMed = (MaterialMedicamentoDTO)dtbMatMed.Rows.Find(Convert.ToInt64(dtgMatMed.SelectedRows[0].Cells["colIdt"].Value));
            }
            else
            {
                dtoMatMed = new MaterialMedicamentoDTO();
                dtoMatMed.Idt.Value = dtgMatMed.Rows[e.RowIndex].Cells["colIdt"].Value.ToString();
                dtoMatMed = MatMed.SelChave(dtoMatMed);
            }
            Close();
        }

        private void txtNomeFantasia_Validated(object sender, EventArgs e)
        {
            btnPesquisa_Click(sender, e);
        }

        private void FrmPesquisaMatMed_Shown(object sender, EventArgs e)
        {
            txtNomeFantasia.Focus();
        }

        private bool tsHac_SairClick(object sender)
        {
            dtoMatMed = null;
            dtoMatMedAux = null;
            return true;
        }
    }
}