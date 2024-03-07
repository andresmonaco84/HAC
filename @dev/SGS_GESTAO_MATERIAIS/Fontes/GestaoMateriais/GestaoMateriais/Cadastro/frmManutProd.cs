using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.Seguranca.Forms;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar
{
    public partial class FrmManutProd : FrmBase
    {
        public FrmManutProd()
        {
            InitializeComponent();
        }

        public FrmManutProd(MaterialMedicamentoDTO dto)
        {
            dtoMatMed = dto;
            InitializeComponent();
        }

        #region OBJETOS SERVIÇOS

        // MatMed
        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject( typeof(IMaterialMedicamento)); }
        }


        private ITipoFracao _tipofracao;
        private ITipoFracao TipoFracao
        {
            get { return _tipofracao != null ? _tipofracao : _tipofracao = (ITipoFracao)Global.Common.GetObject(typeof(ITipoFracao)); }
        }

        #endregion

        #region FUNÇÕES

        private void CarregarProduto()
        {
            if (dtoMatMed != null)
            {
                txtIdProduto.Text = dtoMatMed.Idt.Value.ToString();
                txtDsProduto.Text = dtoMatMed.NomeFantasia.Value;

                txtUnidCompra.Text = dtoMatMed.DsUnidadeCompra.Value;
                txtUnidControle.Text = dtoMatMed.DsUnidadeControle.Value;
                txtUnidVenda.Text = dtoMatMed.DsUnidadeVenda.Value;
                txtIdRm.Text = dtoMatMed.CdRm.Value;
                txtCodMne.Text = dtoMatMed.CodMne.Value;
                txtCodAnvisa.Text = dtoMatMed.CodAnvisa.Value;
                txtTpFracao.Text = string.Empty;
                if (!dtoMatMed.TpFracao.Value.IsNull)
                {
                    txtTpFracao.Visible = true;
                    TipoFracaoDTO dtoTpFracao = new TipoFracaoDTO();
                    dtoTpFracao.IdtTpFracao.Value = dtoMatMed.TpFracao.Value;
                    dtoTpFracao = TipoFracao.SelChave(dtoTpFracao);
                    txtTpFracao.Text = dtoTpFracao.DsTpFracao.Value;
                }
                else { txtTpFracao.Visible = false; }

                chkAtivo.Checked = ( dtoMatMed.FlAtivo.Value==1?true:false );
                chkBaixaAutomatica.Checked = (dtoMatMed.FlBaixaAutomatica.Value == 1 ? true : false);
                chkFracionado.Checked = (dtoMatMed.FlFracionado.Value == 1 ? true : false);
                chkReutilizavel.Checked = (dtoMatMed.FlReutilizavel.Value == 1 ? true : false);
                chkMaterEstoque.Checked = (dtoMatMed.FlManterEstoque.Value == 1 ? true : false);
                chkCobrado.Checked = (dtoMatMed.FlFaturado.Value == 1 ? true : false);
                chkPadrao.Checked = (dtoMatMed.FlPadrao.Value == 1 ? true : false); 
                if (decimal.Parse(dtoMatMed.Tabelamedica.Value.ToString()) == (decimal)MaterialMedicamentoDTO.TipoMatMed.MATERIAL)
                {
                    rbMaterial.Checked = true;
                    chkMAV.Visible = chkControlaLote.Visible = chkDiluente.Visible = false;
                }
                else
                {
                    rbMedicamento.Checked = chkMAV.Visible = chkControlaLote.Visible =  true;

                    if (dtoMatMed.MedAltaVigilancia.Value.IsNull) dtoMatMed.MedAltaVigilancia.Value = "N";
                    chkMAV.Checked = (dtoMatMed.MedAltaVigilancia.Value == "S" ? true : false);

                    if (dtoMatMed.FlControlaLote.Value.IsNull) dtoMatMed.FlControlaLote.Value = 0;
                    chkControlaLote.Checked = ((decimal)dtoMatMed.FlControlaLote.Value == 1 ? true : false);

                    if (dtoMatMed.FlDiluente.Value.IsNull) dtoMatMed.FlDiluente.Value = 0;
                    chkDiluente.Checked = ((decimal)dtoMatMed.FlDiluente.Value == 1 ? true : false);                        
                }
            }
            else
            {
                
                txtDsProduto.Text = string.Empty;
            }
        }

        private bool ValidarUsuario(out SegurancaDTO dtoUsuario)
        {
            this.Cursor = Cursors.WaitCursor;
            dtoUsuario = FrmLogin.Logar(true);
            if (dtoUsuario != null)
            {
                if (!new Generico().VerificaAcessoFuncionalidade(new FrmPrincipioAtivo().Name, dtoUsuario))
                {
                    MessageBox.Show("Usuário sem permissão para esta funcionalidade.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Cursor = Cursors.Default;
                    return false;
                }
            }
            else
            {
                this.Cursor = Cursors.Default;
                return false;
            }
            this.Cursor = Cursors.Default;
            return true;
        }
      
        #endregion

        #region EVENTOS

        private void FrmManutProd_Load(object sender, EventArgs e)
        {
            CarregarProduto();
            chkDiluente.Focus();
        }

        private void chkDiluente_Click(object sender, EventArgs e)
        {
            SegurancaDTO dtoUsuario;
            if (!ValidarUsuario(out dtoUsuario))
            {
                chkDiluente.Checked = !chkDiluente.Checked;
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            if (chkDiluente.Checked)
                dtoMatMed.FlDiluente.Value = 1;
            else
                dtoMatMed.FlDiluente.Value = 0;

            MatMed.AtualizarDiluente(dtoMatMed);

            this.Cursor = Cursors.Default;
        }        

        //private void txtIdProduto_Validating(object sender, CancelEventArgs e)
        //{
        //    if (txtIdProduto.Text != string.Empty)
        //    {
        //        CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();

        //        dtoCodigoBarra.CdBarra.Value = txtIdProduto.Text;
        //        // BUSCA TODAS AS INFORMAÇÕES DO PRODUTO PELO CODIGO DE BARRA
        //        dtoMatMed = MatMed.BuscaCodigoBarra(dtoCodigoBarra);

        //        this.CarregarProduto();

        //        if (dtoMatMed == null)
        //        {
        //            MessageBox.Show("Material/medicamento não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //            txtIdProduto.Focus();
        //        }
        //    }
        //}

        #endregion
    }
}