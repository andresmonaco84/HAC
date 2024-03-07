using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.Componentes;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmCodBarraMatMed : FrmBase
    {
        public FrmCodBarraMatMed()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇOS

        // CodigoBarra        
        private CodigoBarraDTO dtoCodigoBarra;
        private CodigoBarraDataTable dtbCodigoBarra;
        private ICodigoBarra _codigoBarra;
        private ICodigoBarra CodigoBarra
        {
            get { return _codigoBarra != null ? _codigoBarra : _codigoBarra = (ICodigoBarra)Global.Common.GetObject( typeof(ICodigoBarra)); }
        }

        // MatMed
        private MaterialMedicamentoDTO dtoMatMed;

        #endregion

        #region EVENTOS

        private bool tsHac_NovoClick(object sender)
        {   
            return true;
        }

        private bool tsHac_SalvarClick(object sender)
        {   
            return this.Salvar();
        }

        private bool tsHac_ExcluirClick(object sender)
        {
            bool retorno = false;

            try
            {
                if (this.dtoCodigoBarra == null)
                {
                    MessageBox.Show("Este produto não possui código de barras cadastrado.",
                                     "Gestão de Materiais e Medicamentos",
                                     MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (MessageBox.Show("Confirma a exclusão do código de barras ?",
                                         "Gestão de Materiais e Medicamentos",
                                         MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        CodigoBarraDTO dtoCodBarra = new CodigoBarraDTO();

                        dtoCodBarra.IdtFilial.Value = this.ObterFilial();
                        dtoCodBarra.IdtLote.Value = 1;
                        dtoCodBarra.IdtProduto.Value = this.dtoMatMed.Idt.Value;

                        CodigoBarra.Del(dtoCodBarra);                        

                        this.LimparFormulario();

                        retorno = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return retorno;
        }

        private bool tsHac_MatMedClick(object sender)
        {
            if (!ValidarFilial()) return false;

            this.dtoMatMed = new MaterialMedicamentoDTO();            
            
            this.dtoMatMed.IdtFilial.Value = this.ObterFilial();
            dtoMatMed.TpPesquisa.Value = (int)MaterialMedicamentoDTO.TipoDePesquisa.SEM_ESTOQUE;

            this.dtoMatMed = FrmPesquisaMatMed.SelecionaMatMed(this.dtoMatMed);

            this.CarregarMatMed(this.dtoMatMed);

            txtIdProduto.Focus();

            return true;
        }
        
        private void rbHac_CheckedChanged(object sender, EventArgs e)
        {
            this.LimparFormulario();
            this.HabilitarCodigoBarras();
        }

        private void rbAcs_CheckedChanged(object sender, EventArgs e)
        {
            this.LimparFormulario();
            this.HabilitarCodigoBarras();
        }

        #endregion  

        #region Métodos

        private bool ValidarCodigoBarras()
        {
            bool codBarrasValido = false;            
                            
            CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();

            dtoCodigoBarra.CdBarra.Value = txtIdProduto.Text;            

            if (this.CodigoBarra.Existe(dtoCodigoBarra))
            {
                MessageBox.Show("Este código de barras já está associado a um produto !", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtIdProduto.Text = string.Empty;
                txtIdProduto.Focus();
            }
            else
            {
                codBarrasValido = true;
            }

            return codBarrasValido;
        }

        private bool Validar()
        {
            //Valida a Filial
            if (!ValidarFilial()) return false;

            //Valida o Produto
            if (this.dtoMatMed == null)
            {
                MessageBox.Show("Selecione o produto (Mat/Med)", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return false;
            }

            //Valida o Código de Barras
            if (!this.ValidarCodigoBarras()) return false;            

            return true;
        }

        private bool ValidarFilial()
        {
            if (!rbAcs.Checked && !rbHac.Checked)
            {
                MessageBox.Show("Selecione a Filial", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private bool Salvar()
        {
            try
            {  
                if (this.Validar())
                {
                    CodigoBarraDTO dtoCodBarra = new CodigoBarraDTO();

                    dtoCodBarra.CdBarra.Value = txtIdProduto.Text;
                    dtoCodBarra.IdtFilial.Value = this.ObterFilial();
                    dtoCodBarra.IdtLote.Value = 1;
                    dtoCodBarra.IdtProduto.Value = this.dtoMatMed.Idt.Value;

                    CodigoBarra.Gravar(dtoCodBarra);

                    this.LimparFormulario();

                    MessageBox.Show("Registro Salvo com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void CarregarMatMed(MaterialMedicamentoDTO dtoMatMed)
        {
            if (this.dtoMatMed != null)
            {
                txtIdProduto.Text = string.Empty;
                txtDsProduto.Text = this.dtoMatMed.NomeFantasia.Value;

                CodigoBarraDTO dtoCodBarra = new CodigoBarraDTO();

                dtoCodBarra.IdtFilial.Value = this.ObterFilial();
                dtoCodBarra.IdtLote.Value = 1;
                dtoCodBarra.IdtProduto.Value = this.dtoMatMed.Idt.Value;

                this.dtbCodigoBarra = this.CodigoBarra.Sel(dtoCodBarra, null);

                if (this.dtbCodigoBarra.Rows.Count > 0)
                {
                    this.dtoCodigoBarra = this.dtbCodigoBarra.TypedRow(0);

                    txtIdProduto.Text = this.dtoCodigoBarra.CdBarra.Value;                    
                }
            }
        }

        private void LimparFormulario()
        {
            this.LimparPesquisas();
                        
            txtDsProduto.Text = string.Empty;
            txtIdProduto.Text = string.Empty;
        }

        private void LimparPesquisas()
        {
            if (this.dtbCodigoBarra != null) this.dtbCodigoBarra.Rows.Clear();
            this.dtoCodigoBarra = null;
            this.dtoMatMed = null;
        }

        private decimal ObterFilial()
        {
            decimal filial;

            if (rbHac.Checked)
            {
                filial = (decimal)FilialMatMedDTO.Filial.HAC;
            }
            else
            {
                filial = (decimal)FilialMatMedDTO.Filial.ACS;
            }

            return filial;
        }

        private void HabilitarCodigoBarras()
        {
            if ((rbHac.Checked) || (rbAcs.Checked))
            {
                txtIdProduto.Enabled = true;
            }
            else
            {
                txtIdProduto.Enabled = false;
            }
        }

        #endregion

        private void txtIdProduto_Validating(object sender, CancelEventArgs e)
        {

        }
    }
}