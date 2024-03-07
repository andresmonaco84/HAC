using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.Componentes;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;


namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmTransfMatMed : FrmBase
    {
        public FrmTransfMatMed()
        {
            InitializeComponent();
        }

        #region OBJETOS SERVIÇOS

        private const int _IdUnitarização = 2632; //ID UNITARIZACAO
        private const int _IdCentroCir = 61; //ID CENTRO CIRURGICO

        // MatMed
        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject( typeof(IMaterialMedicamento)); }
        }

        // Estoque
        private IEstoqueLocal _estoque;
        private IEstoqueLocal Estoque
        {
            get { return _estoque != null ? _estoque : _estoque = (IEstoqueLocal)Global.Common.GetObject( typeof(IEstoqueLocal)); }
        }
        private EstoqueLocalDTO dtoEstoqueOrigem;
        private EstoqueLocalDTO dtoEstoqueDestino;

        // Movimentos
        private MovimentacaoDTO dtoMovimento;        
        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject( typeof(IMovimentacao)); }
        }

        private IHistoricoNotaFiscal _histNF;
        private IHistoricoNotaFiscal HistoricoNotaFiscal
        {
            get { return _histNF != null ? _histNF : _histNF = (IHistoricoNotaFiscal)Global.Common.GetObject(typeof(IHistoricoNotaFiscal)); }
        }        

        private IMatMedSetorConfig _matMedConfig;
        private IMatMedSetorConfig MatMedSetorConfig
        {
            get { return _matMedConfig != null ? _matMedConfig : _matMedConfig = (IMatMedSetorConfig)Global.Common.GetObject(typeof(IMatMedSetorConfig)); }
        }

        private ISetor _setor;
        private ISetor Setor
        {
            get { return _setor != null ? _setor : _setor = (ISetor)Global.Common.GetObject(typeof(ISetor)); }
        }

        private IKit _kit;
        private IKit Kit
        {
            get { return _kit != null ? _kit : _kit = (IKit)Global.Common.GetObject(typeof(IKit)); }
        }

        Generico gen = new Generico();

        #endregion

        public static void Transferencia(MovimentacaoDTO dto)
        {
            FrmTransfMatMed frmtransf = new FrmTransfMatMed();
            MaterialMedicamentoDTO dtoMaterial = new MaterialMedicamentoDTO();
            frmtransf.MdiParent = FrmPrincipal.ActiveForm;
            frmtransf.Show();

            frmtransf.cmbUnidade.SelectedValue = dto.IdtUnidade.Value;
            frmtransf.cmbLocal.SelectedValue = dto.IdtLocal.Value;
            frmtransf.cmbSetor.SelectedValue = dto.IdtSetor.Value;
            if (frmtransf.cmbUnidade.SelectedValue == null ||
                frmtransf.cmbLocal.SelectedValue == null ||
                frmtransf.cmbSetor.SelectedValue == null)
            {
                MessageBox.Show("Setor não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                frmtransf.Close();
                return;
            }
            frmtransf.tsHac_NovoClick(frmtransf.tsHac);
            dtoMaterial.Idt.Value = dto.IdtProduto.Value;
            dtoMaterial = frmtransf.MatMed.SelChave(dtoMaterial);
            dtoMaterial.IdtLote.Value = dto.IdtLote.Value;
            frmtransf.dtoMatMed = dtoMaterial;
            frmtransf.CarregarProduto();
            if (dto.IdtFilial.Value == (decimal)FilialMatMedDTO.Filial.HAC)
            {
                frmtransf.rbHac.Checked = true;
            }
            //else if (dto.IdtFilial.Value == (decimal)FilialMatMedDTO.Filial.ACS)
            //{
            //    frmtransf.rbAcs.Checked = true;
            //}
            else if (dto.IdtFilial.Value == (decimal)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA)
            {
                frmtransf.rbCE.Checked = true;
            }
            else if (dto.IdtFilial.Value == (decimal)FilialMatMedDTO.Filial.CONSIGNADO)
            {
                frmtransf.rbConsig.Checked = true;
            }
            frmtransf.cmbUnidadeDestino.Enabled = true;
            frmtransf.cmbLocalDestino.Enabled = true;
            frmtransf.cmbSetorDestino.Enabled = true;
            frmtransf.txtQtdTransf.Enabled = true;
            frmtransf.rbHac.Enabled = frmtransf.rbCE.Enabled = frmtransf.rbConsig.Enabled = true;
            // frmtransf.txtQtdTransf.Focus();
        }

        #region FUNÇÕES

        private bool AlmoxarifadoCentral(int idSetor)
        {
            SetorDTO dtoSetor = new SetorDTO();
            dtoSetor.Idt.Value = idSetor;
            dtoSetor = Setor.SelChave(dtoSetor);
            if (dtoSetor.FlAlmoxCentral.Value == (byte)SetorDTO.AlmoxarifadoCentral.SIM)
                return true;
            else
                return false;
        }

        private bool PodeTransferirItemAlmoxCentral(int idSetor)
        {
            if (AlmoxarifadoCentral(idSetor))
            {
                if (!gen.VerificaAcessoFuncionalidade("TransferirAlmoxCentral"))
                {                    
                    MessageBox.Show("Usuário sem acesso para realizar transferência envolvendo o Almoxarifado Central.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }
       
        private void ConfiguraEstoquesDTO()
        {
            if (cmbUnidade.SelectedValue == null || cmbLocal.SelectedValue == null || cmbSetor.SelectedValue == null) return;

            dtoEstoqueOrigem = new EstoqueLocalDTO();
            dtoEstoqueDestino = new EstoqueLocalDTO();

            dtoEstoqueOrigem.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
            dtoEstoqueOrigem.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
            dtoEstoqueOrigem.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
            dtoEstoqueOrigem.IdtProduto.Value = dtoMatMed.Idt.Value;

            if (cmbSetorDestino.SelectedIndex != -1)
            {
                dtoEstoqueDestino.IdtUnidade.Value = cmbUnidadeDestino.SelectedValue.ToString();
                dtoEstoqueDestino.IdtLocal.Value = cmbLocalDestino.SelectedValue.ToString();
                dtoEstoqueDestino.IdtSetor.Value = cmbSetorDestino.SelectedValue.ToString();
                dtoEstoqueDestino.IdtProduto.Value = dtoMatMed.Idt.Value;
            }            

            if (rbHac.Checked)
            {
                dtoEstoqueOrigem.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
                dtoEstoqueDestino.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
            }
            //else if (rbAcs.Checked)
            //{
            //    dtoEstoqueOrigem.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;
            //    dtoEstoqueDestino.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.ACS;
            //}
            else if (rbCE.Checked)
            {
                dtoEstoqueOrigem.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
                dtoEstoqueDestino.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.CARRINHO_EMERGENCIA;
                //Quando Origem é Estoque Único, destino será HAC
                //MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();
                //dtoCfg.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                //dtoCfg.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                //dtoCfg.Idtsetor.Value = cmbSetor.SelectedValue.ToString();
                //dtoCfg = MatMedSetorConfig.SetorCfg(dtoCfg);
                //if (dtoCfg.EstoqueUnificadoHAC.Value.IsNull) dtoCfg.EstoqueUnificadoHAC.Value = 0;
                //if (dtoCfg.EstoqueUnificadoHAC.Value == 1)
                //    dtoEstoqueDestino.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
            }
            else if (rbConsig.Checked)
            {
                dtoEstoqueOrigem.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.CONSIGNADO;
                dtoEstoqueDestino.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.CONSIGNADO;
            }
            //if (lblObsEU.Visible)
            //    dtoEstoqueDestino.IdtFilial.Value = (byte)FilialMatMedDTO.Filial.HAC;
        }

        private void CarregarComboKit()
        {
            KitDTO dtoKit = new KitDTO();
            dtoKit.Ativo.Value = 1;
            cmbKit.DataSource = Kit.Listar(dtoKit);
            cmbKit.IniciaLista();
        }

        private void CarregarProduto()
        {
            if (dtoMatMed == null)
            {
                MessageBox.Show("Material/medicamento não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDsProduto.Text = string.Empty;
                txtIdProduto.Focus();
            }                               
            else if( dtoMatMed.FlAtivo.Value == 0 )
            {
                MessageBox.Show("Material/medicamento Inativo", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtDsProduto.Text = string.Empty;
                txtIdProduto.Focus();
            }                               
            else 
            {
                txtDsProduto.Text = dtoMatMed.NomeFantasia.Value;
            }
            this.AtualizarQtdEstoques();

            if (!gen.PermitirMovimentacaoItemNaoPadrao(dtoEstoqueOrigem, dtoMatMed))
            {
                MessageBox.Show("Movimentação permitida apenas para MAT/MED Padrão (referente ao Setor Origem)!", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                dtoMatMed = null;
                LimparQtdEstoques();
                txtIdProduto.Text = txtDsProduto.Text = string.Empty;
                txtIdProduto.Focus();
                return;
            }

            txtIdProduto.Text = txtQtdTransf.Text = string.Empty;            
            txtQtdTransf.Focus();
        }

        private void AtualizarQtdEstoques()
        {
            this.LimparQtdEstoques();
            if (dtoMatMed != null)
            {
                this.Cursor = Cursors.WaitCursor;
                this.ConfiguraEstoquesDTO();

                if (dtoEstoqueOrigem == null || dtoEstoqueOrigem.IdtSetor.Value.IsNull)
                {
                    this.Cursor = Cursors.Default;
                    return;
                }

                txtEstoqueOrigem.Text = "0";
                lblNumLote.Text = string.Empty;
                if ((int)dtoMatMed.IdtGrupo.Value == 1)
                {
                    lblLote.Visible = txtQtdLote.Visible = true;
                    if (!dtoMatMed.IdtLote.Value.IsNull)
                        dtoEstoqueOrigem.IdtLote.Value = dtoMatMed.IdtLote.Value;
                }
                else
                    lblLote.Visible = txtQtdLote.Visible = false;

                dtoEstoqueOrigem = Estoque.EstoqueLocalProduto(dtoEstoqueOrigem);
                if (!dtoEstoqueOrigem.Qtde.Value.IsNull) txtEstoqueOrigem.Text = dtoEstoqueOrigem.Qtde.Value.ToString();
                if (!dtoEstoqueOrigem.QtdeLote.Value.IsNull && txtQtdLote.Visible)
                {
                    txtQtdLote.Text = dtoEstoqueOrigem.QtdeLote.Value.ToString();

                    HistoricoNotaFiscalDTO dtoHistNF = new HistoricoNotaFiscalDTO();
                    dtoHistNF.IdtProduto.Value = dtoMatMed.Idt.Value;
                    dtoHistNF.IdtLote.Value = dtoMatMed.IdtLote.Value;
                    dtoHistNF.IdtFilial.Value = (decimal)FilialMatMedDTO.Filial.HAC;

                    HistoricoNotaFiscalDataTable dtbHNF = HistoricoNotaFiscal.Sel(dtoHistNF);
                    if (dtbHNF.Rows.Count > 0)
                    {                        
                        lblNumLote.Text = dtbHNF.TypedRow(0).NumLote.Value;
                        if (!lblNumLote.Visible) lblNumLote.Visible = true;
                    }
                }

                if (cmbSetorDestino.SelectedIndex != -1)
                {
                    txtEstoqueDestino.Text = "0";
                    dtoEstoqueDestino = Estoque.EstoqueLocalProduto(dtoEstoqueDestino);
                    if (!dtoEstoqueDestino.Qtde.Value.IsNull) txtEstoqueDestino.Text = dtoEstoqueDestino.Qtde.Value.ToString();
                    if (!dtoEstoqueDestino.QtdePadrao.Value.IsNull)
                    {
                        lblQtdPadrao.Visible = txtQtdPadrao.Visible = true;
                        txtQtdPadrao.Text = dtoEstoqueDestino.QtdePadrao.Value.ToString();
                    }               
                }                
            }
            this.Cursor = Cursors.Default;
        }

        private void LimparQtdEstoques()
        {
            txtEstoqueOrigem.Text = txtQtdLote.Text = string.Empty;
            this.LimparQtdEstoquesDestino();
        }

        private void LimparQtdEstoquesDestino()
        {
            txtEstoqueDestino.Text = string.Empty;
            txtQtdPadrao.Text = string.Empty;
            lblQtdPadrao.Visible = txtQtdPadrao.Visible = false;
        }

        private bool ValidarFiliais(bool mostrarMsgBox)
        {
            if (!rbHac.Checked && !rbCE.Checked && !rbConsig.Checked)
            {
                if (mostrarMsgBox) MessageBox.Show("Selecione a Filial de Origem", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            //else if (!rbAcsDestino.Checked && !rbHacDestino.Checked)
            //{
            //    if (mostrarMsgBox) MessageBox.Show("Selecione a Filial de Destino", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return false;
            //}
            return true;
        }

        private bool ValidarSetorOrigemTransferirTudo()
        {
            if (cmbSetor.SelectedIndex == -1 || cmbSetor.SelectedValue == null)
            {
                MessageBox.Show("Selecione o Setor Origem", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbSetor.Focus();
                return false;
            }
            else if (grbTodoSaldo.Visible && chbTodoSaldo.Enabled && chbTodoSaldo.Checked)
            {
                int idSetor = int.Parse(cmbSetor.SelectedValue.ToString());
                if (AlmoxarifadoCentral(idSetor))
                {
                    MessageBox.Show("Apenas Administrador do Sistema tem permissão para transferir todo o Estoque do Almoxaridado Central.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else if (gen.SetorFarmacia(idSetor) || idSetor == _IdUnitarização)
                {
                    MessageBox.Show("Apenas Administrador do Sistema tem permissão para transferir todo o Estoque da Farmácia/Unitarização.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else if (idSetor == _IdCentroCir)
                {
                    MessageBox.Show("Apenas Administrador do Sistema tem permissão para transferir todo o Estoque do Centro Cirúrgico.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else
                {
                    EstoqueLocalDTO dtoEstoqueCentDisp = new EstoqueLocalDTO();
                    dtoEstoqueCentDisp.IdtUnidade.Value = int.Parse(cmbUnidade.SelectedValue.ToString());
                    dtoEstoqueCentDisp.IdtSetor.Value = int.Parse(cmbSetor.SelectedValue.ToString());
                    dtoEstoqueCentDisp.IdtLocal.Value = int.Parse(cmbLocal.SelectedValue.ToString());
                    bool estoqueCentroDispensacao = Estoque.EstoqueCentroDispensacao(dtoEstoqueCentDisp);
                    if (estoqueCentroDispensacao)
                    {
                        MessageBox.Show("Apenas Administrador do Sistema tem permissão para transferir todo o Estoque de um Centro de Dispensação.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
            }

            return true;
        }

        private bool Validar()
        {
            if (!this.ValidarFiliais(true)) return false;            

            if (grbProduto.Visible)
            {
                if (dtoMatMed == null)
                {
                    MessageBox.Show("Selecione o Mat/Med", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                if (int.Parse(txtQtdTransf.Text) > int.Parse(txtEstoqueOrigem.Text))
                {
                    MessageBox.Show("Qtd. Transferência deve ser menor ou igual à Qtd. Estoque no Setor de Origem", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                #region Se for Pedido Padrão, a soma da qtd em estoque destino atual com a qtd a ser transferida tem que ser menor ou igual à qtd padrão


                if (txtQtdPadrao.Text != string.Empty && txtQtdPadrao.Visible)
                {
                    if (int.Parse(cmbSetorDestino.SelectedValue.ToString()) != _IdUnitarização)
                    {
                        EstoqueLocalDTO dtoEstoqueCentDisp = new EstoqueLocalDTO();
                        dtoEstoqueCentDisp.IdtUnidade.Value = int.Parse(cmbUnidadeDestino.SelectedValue.ToString());
                        dtoEstoqueCentDisp.IdtSetor.Value = int.Parse(cmbSetorDestino.SelectedValue.ToString());
                        dtoEstoqueCentDisp.IdtLocal.Value = int.Parse(cmbLocalDestino.SelectedValue.ToString());
                        bool EstoqueCentroDispensacao = Estoque.EstoqueCentroDispensacao(dtoEstoqueCentDisp);

                        int qtdMaximaPermitidaTransf = (int.Parse(txtQtdPadrao.Text) - int.Parse(txtEstoqueDestino.Text));
                        if (qtdMaximaPermitidaTransf <= 0 && !EstoqueCentroDispensacao)
                        {
                            MessageBox.Show("Você não pode realizar esta transferência, pois a Qtd. Estoque no Setor de Destino não pode ultrapassar sua Qtd. Padrão", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;

                        }
                        else if (int.Parse(txtQtdTransf.Text) > qtdMaximaPermitidaTransf && !EstoqueCentroDispensacao)
                        {
                            MessageBox.Show("Qtd. Transferência deve ser menor ou igual a " + qtdMaximaPermitidaTransf +
                                            ", pois a Qtd. Estoque no Setor de Destino não pode ultrapassar sua Qtd. Padrão", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return false;
                        }
                    }
                }

                #endregion

                if (int.Parse(txtQtdTransf.Text) <= 0)
                {
                    MessageBox.Show("Qtd. Transferência deve ser maior que 0", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            else
            {
                if (chbItensKit.Checked && cmbKit.SelectedIndex == -1)
                {
                    MessageBox.Show("Selecione o Kit", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else if (chbItensKit.Checked)
                {
                    RequisicaoDTO dtoReq = new RequisicaoDTO();
                    dtoReq.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
                    dtoReq.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
                    dtoReq.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                    dtoReq.IdKit.Value = cmbKit.SelectedValue.ToString();

                    string materiaisSemSaldo = Estoque.KitMateriaisSaldoInsuficiente(dtoReq);
                    if (!string.IsNullOrEmpty(materiaisSemSaldo))
                    {
                        MessageBox.Show("Itens com saldo insuficiente:\n\n" + materiaisSemSaldo.Replace(", ", "\n"), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
                else if (chbTodoSaldo.Checked)
                {                    
                    EstoqueLocalDTO dtoEstoque = new EstoqueLocalDTO();
                    dtoEstoque.IdtSetor.Value = cmbSetor.SelectedValue.ToString();
                    dtoEstoque.IdtFilial.Value = gen.RetornaFilial(rbHac, new RadioButton(), rbCE, rbConsig);

                    string medVencidos = Estoque.MedicamentosVencidos(dtoEstoque);
                    if (!string.IsNullOrEmpty(medVencidos))
                    {
                        MessageBox.Show("Não é possível transferir todo o saldo, é necessário registrar perda dos medicamentos vencidos:\n\n" + medVencidos.Replace(", ", "\n"), "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return false;
                    }
                }
            }
            
            return true;
        }

        //private void VerificaEstoqueUnificadoOrigem()
        //{
        //    MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();
        //    dtoCfg.IdtUnidade.Value = cmbUnidade.SelectedValue.ToString();
        //    dtoCfg.IdtLocal.Value = cmbLocal.SelectedValue.ToString();
        //    dtoCfg.Idtsetor.Value = cmbSetor.SelectedValue.ToString();
        //    dtoCfg = MatMedSetorConfig.SetorCfg(dtoCfg);
        //    if (dtoCfg.EstoqueUnificadoHAC.Value.IsNull) dtoCfg.EstoqueUnificadoHAC.Value = 0;
        //    if (dtoCfg.EstoqueUnificadoHAC.Value == 1)
        //    {
        //        //rbCE.Text = "EU";
        //        //rbCE.Checked = true;
        //        rbHac.Checked = true;
        //        //grbFilial.Enabled = false;
        //    }
        //    else
        //    {
        //        rbCE.Text = "CE";
        //        rbCE.Checked = false;
        //        grbFilial.Enabled = true;
        //    }
        //}        

        //private void VerificaEstoqueUnificadoDestino()
        //{
        //    MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();
        //    dtoCfg.IdtUnidade.Value = cmbUnidadeDestino.SelectedValue.ToString();
        //    dtoCfg.IdtLocal.Value = cmbLocalDestino.SelectedValue.ToString();
        //    dtoCfg.Idtsetor.Value = cmbSetorDestino.SelectedValue.ToString();
        //    dtoCfg = MatMedSetorConfig.SetorCfg(dtoCfg);
        //    if (dtoCfg.EstoqueUnificadoHAC.Value.IsNull) dtoCfg.EstoqueUnificadoHAC.Value = 0;
        //    if (dtoCfg.EstoqueUnificadoHAC.Value == 1)            
        //        lblObsEU.Visible = true;
        //    else            
        //        lblObsEU.Visible = false;
        //}

        private bool VerificaEstoqueUnificadoDestino()
        {            
            if (cmbSetorDestino.SelectedValue != null)
                return VerificaEstoqueUnificado(cmbUnidadeDestino, cmbLocalDestino, cmbSetorDestino);

            return false;
        }

        private bool VerificaEstoqueUnificadoOrigem()
        {
            if (cmbSetor.SelectedValue != null)
                return VerificaEstoqueUnificado(cmbUnidade, cmbLocal, cmbSetor);

            return false;
        }

        private bool VerificaEstoqueUnificado(HacCmbUnidade cmbUnidadeRef, HacCmbLocal cmbLocalRef, HacCmbSetor cmbSetorRef)
        {
            MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();
            dtoCfg.IdtUnidade.Value = cmbUnidadeRef.SelectedValue.ToString();
            dtoCfg.IdtLocal.Value = cmbLocalRef.SelectedValue.ToString();
            dtoCfg.Idtsetor.Value = cmbSetorRef.SelectedValue.ToString();
            dtoCfg = MatMedSetorConfig.SetorCfg(dtoCfg);
            if (dtoCfg.EstoqueUnificadoHAC.Value.IsNull) dtoCfg.EstoqueUnificadoHAC.Value = 0;
            if (dtoCfg.EstoqueUnificadoHAC.Value == 1)
                return true;

            return false;
        }
        
        private bool SetorDestinoCarrinhoEmergencia()
        {
            if (cmbSetorDestino.SelectedValue != null)
            {
                int? setorCarrEmergPai = gen.SetorCarrinhoEmergencia(int.Parse(cmbSetorDestino.SelectedValue.ToString()));
                if (setorCarrEmergPai != null)
                    return true;
            }
            
            return false;
        }

        private bool Salvar()
        {
            if (!this.Validar()) return false;

            if (!grbProduto.Visible && (chbTodoSaldo.Checked || chbItensKit.Checked))
            {
                string mensagem = "Deseja realmente transferir todo o Saldo deste Setor?";
                if (chbItensKit.Checked) mensagem = "Deseja realmente transferir este Kit deste Setor?";
                
                if (MessageBox.Show(mensagem, "Gestão de Materiais e Medicamentos", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return false;
            }

            try
            {
                this.Cursor = Cursors.WaitCursor;
                dtoMovimento = new MovimentacaoDTO();

                // unidade de baixa
                dtoMovimento.IdtUnidadeBaixa.Value = cmbUnidade.SelectedValue.ToString();
                dtoMovimento.IdtLocalBaixa.Value = cmbLocal.SelectedValue.ToString();
                dtoMovimento.IdtSetorBaixa.Value = cmbSetor.SelectedValue.ToString();

                // unidade de entrada
                dtoMovimento.IdtUnidade.Value = cmbUnidadeDestino.SelectedValue.ToString();
                dtoMovimento.IdtLocal.Value = cmbLocalDestino.SelectedValue.ToString();
                dtoMovimento.IdtSetor.Value = cmbSetorDestino.SelectedValue.ToString();

                dtoMovimento.IdtFilial.Value = gen.RetornaFilial(rbHac, new RadioButton(), rbCE, rbConsig);

                //if (rbHac.Checked)
                //{
                //    dtoMovimento.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;
                //}
                //else
                //{
                //    dtoMovimento.IdtFilial.Value = (int)FilialMatMedDTO.Filial.ACS;
                //}

                if (grbProduto.Visible)
                {
                    dtoMovimento.IdtProduto.Value = dtoMatMed.Idt.Value;
                    if (!dtoMatMed.IdtLote.Value.IsNull && (decimal)dtoMatMed.IdtLote.Value != 0) dtoMovimento.IdtLote.Value = dtoMatMed.IdtLote.Value;
                    dtoMovimento.Qtde.Value = txtQtdTransf.Text;
                }

                dtoMovimento.IdtTipo.Value = (byte)MovimentacaoDTO.TipoMovimento.ENTRADA;
                dtoMovimento.IdtTipoBaixa.Value = (byte)MovimentacaoDTO.TipoMovimento.SAIDA;
                dtoMovimento.IdtSubTipo.Value = (byte)MovimentacaoDTO.SubTipoMovimento.TRANSFERENCIA_ENTRADA;
                dtoMovimento.IdtSubTipoBaixa.Value = (byte)MovimentacaoDTO.SubTipoMovimento.TRANSFERENCIA_SAIDA;
                dtoMovimento.IdtUsuario.Value = FrmPrincipal.dtoSeguranca.Idt.Value;

                if (grbProduto.Visible)
                    Movimento.TransfereEstoqueProduto(dtoMovimento);
                else
                {
                    if (chbTodoSaldo.Checked)
                        Movimento.TransferirEstoque(dtoMovimento);
                    else if (chbItensKit.Checked)
                    {
                        KitDTO dtoKit = new KitDTO();
                        dtoKit.IdKit.Value = cmbKit.SelectedValue.ToString();
                        KitDataTable dtbKit = Kit.ListarItem(dtoKit);
                        foreach (DataRow row in dtbKit.Rows)
                        {
                            if (int.Parse(row[MaterialMedicamentoDTO.FieldNames.IdtGrupo].ToString()) != 1) //Não baixar medicamento
                            {
                                dtoMovimento.IdtLote.Value = new Framework.DTO.TypeDecimal();
                                dtoMovimento.IdtProduto.Value = row[KitDTO.FieldNames.IdProduto].ToString();
                                dtoMovimento.Qtde.Value = int.Parse(row[KitDTO.FieldNames.QtdeItem].ToString());

                                Movimento.TransfereEstoqueProduto(dtoMovimento);
                            }
                        }
                        cmbKit.IniciaLista();
                    }
                }                

                if (grbProduto.Visible)
                {
                    dtoMatMed = null;
                    txtIdProduto.Text = txtDsProduto.Text = txtQtdTransf.Text = string.Empty;

                    this.AtualizarQtdEstoques();
                }

                MessageBox.Show("Transferência realizada com sucesso", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (txtIdProduto.Enabled) txtIdProduto.Focus();
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Default;
                return false;
            }

            return true;
        }

        #endregion

        #region EVENTOS

        private void FrmTransfMatMed_Load(object sender, EventArgs e)
        {
            cmbUnidade.Carregaunidade();
            Generico.ConfiguraCombos(cmbUnidade,cmbLocal,cmbSetor,FrmPrincipal.dtoSeguranca);

            if (!PodeTransferirItemAlmoxCentral(int.Parse(cmbSetor.SelectedValue.ToString())))
                cmbSetor.SelectedIndex = -1;

            //VerificaEstoqueUnificadoOrigem();
            cmbUnidadeDestino.Carregaunidade();

            chbTodoSaldo.Enabled = gen.VerificaAcessoFuncionalidade("TransferirTodoEstoque");
            chbItensKit.Enabled = gen.VerificaAcessoFuncionalidade("TransferirKitItens");
            cmbKit.Enabled = false; //chbItensKit.Enabled;
            if (chbItensKit.Enabled) CarregarComboKit();

            if (chbTodoSaldo.Enabled || chbItensKit.Enabled)
                grbTodoSaldo.Visible = true;
        }

        private void cmbUnidade_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dtoMatMed = null;
            tsHac.Controla(Evento.eCancelar);
        }

        private void cmbLocal_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dtoMatMed = null;
            tsHac.Controla(Evento.eCancelar);
        }        

        private void cmbSetor_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dtoMatMed = null;
            tsHac.Controla(Evento.eCancelar);
            //VerificaEstoqueUnificadoOrigem();

            if (!PodeTransferirItemAlmoxCentral(int.Parse(cmbSetor.SelectedValue.ToString())))
                cmbSetor.SelectedIndex = -1;

            if (chbTodoSaldo.Checked && !ValidarSetorOrigemTransferirTudo())
                chbTodoSaldo.Checked = false;
        }

        private void cmbUnidadeDestino_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.LimparQtdEstoquesDestino();
        }

        private void cmbLocalDestino_SelectionChangeCommitted(object sender, EventArgs e)
        {
            this.LimparQtdEstoquesDestino();
        }

        private void cmbLocalDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLocalDestino.SelectedIndex != -1 && cmbSetor.SelectedIndex != -1 && cmbSetorDestino.DataSource != null)
            {
                if (cmbUnidadeDestino.SelectedValue.ToString() == cmbUnidade.SelectedValue.ToString() &&
                    cmbLocalDestino.SelectedValue.ToString() == cmbLocal.SelectedValue.ToString())
                {
                    SetorDataTable dtbSetor = (SetorDataTable)cmbSetorDestino.DataSource;

                    dtbSetor.Rows.RemoveAt(cmbSetor.SelectedIndex);
                    cmbSetorDestino.IniciaLista();
                }                
            }
        }

        private void cmbSetorDestino_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (!PodeTransferirItemAlmoxCentral(int.Parse(cmbSetorDestino.SelectedValue.ToString())))
                cmbSetorDestino.SelectedIndex = -1;
            else
            {
                if (SetorDestinoCarrinhoEmergencia() && !rbCE.Checked)
                {                    
                    MessageBox.Show("Permitido movimentação apenas entre Carrinhos de Emergência.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    rbCE.Checked = true;
                    return;
                }
                this.AtualizarQtdEstoques();

                //VerificaEstoqueUnificadoDestino();
                //if (lblObsEU.Visible && rbAcs.Checked)
                //if (VerificaEstoqueUnificadoOrigem() && rbAcs.Checked)
                //{
                //    MessageBox.Show("Estoque de Origem não pode ser do ACS quando Estoque Único", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    //rbAcs.Checked = false;
                //    return;
                //}
                //else if (VerificaEstoqueUnificadoDestino() && rbAcs.Checked)
                //{
                //    MessageBox.Show("Estoque de Origem não pode ser do ACS quando destino é Estoque Único", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                //    //rbAcs.Checked = false;
                //    return;
                //}
                //else
                //    this.AtualizarQtdEstoques();
            }
        }

        private bool tsHac_NovoClick(object sender)
        {
            tsHac_CancelarClick(sender);
            return true;
        }

        private bool tsHac_AfterNovo(object sender)
        {
            //VerificaEstoqueUnificadoOrigem();
            cmbUnidadeDestino.IniciaLista();           
            rbHac.Checked = rbCE.Checked = rbConsig.Checked = false;
            return default(bool);
        }

        private bool tsHac_CancelarClick(object sender)
        {
            dtoMatMed = null;
            rbCE.Text = "CE";
            lblNumLote.Text = string.Empty;
            grbFilial.Enabled = true;
            lblObsEU.Visible = false;
            grbProduto.Visible = true;
            if (grbTodoSaldo.Visible)
            {
                chbTodoSaldo.Checked = chbItensKit.Checked = false;
                chbTodoSaldo_Click(null, null);
            }
            return true;
        }

        private void tsHac_AfterCancelar(object sender)
        {
            cmbUnidadeDestino.IniciaLista();
            rbHac.Checked = rbCE.Checked = rbConsig.Checked = false;
        }        

        private bool tsHac_SalvarClick(object sender)
        {
            if (!gen.VerificaAcessoFuncionalidade("FrmTransfMatMed"))
            {
                MessageBox.Show("Usuário sem permissão para esta funcionalidade", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (int.Parse(cmbSetorDestino.SelectedValue.ToString()) == 2252) //ATENDIMENTO DOMICILIAR
            {
                MessageBox.Show("Não é permitido transferir para ATENDIMENTO DOMICILIAR", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            this.Salvar();
            return false;
        }        

        private bool tsHac_MatMedClick(object sender)
        {
            if (!grbProduto.Visible) return false;
            if (!this.ValidarFiliais(true)) return false;

            MaterialMedicamentoDTO dtoMatMedAux = new MaterialMedicamentoDTO();           

            if (rbHac.Checked || rbConsig.Checked)
            {
                dtoMatMedAux.IdtFilial.Value = (int)FilialMatMedDTO.Filial.HAC;
            }            
            dtoMatMedAux.TpPesquisa.Value = (int)MaterialMedicamentoDTO.TipoDePesquisa.SEM_ESTOQUE;
            dtoMatMedAux.FlAtivo.Value = 1;
            dtoMatMedAux = FrmPesquisaMatMed.SelecionaMatMed(dtoMatMedAux);

            if (dtoMatMedAux != null)
            {
                if (!dtoMatMedAux.Idt.Value.IsNull)
                {
                    if ((int)dtoMatMedAux.IdtGrupo.Value == 1)
                    {
                        MessageBox.Show("Obrigatório baixa pelo Código de Barra para Medicamentos !", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtIdProduto.Focus();
                        return false;
                    }
                    else
                    {
                        dtoMatMed = dtoMatMedAux;
                        this.CarregarProduto();
                    }
                }
            }  

            return true;
        }

        private void txtIdProduto_Validating(object sender, CancelEventArgs e)
        {
            if (txtIdProduto.Text != string.Empty)
            {
                if (!this.ValidarFiliais(true))
                {
                    txtIdProduto.Text = string.Empty;
                    return;
                } 

                CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();

                dtoCodigoBarra.CdBarra.Value = txtIdProduto.Text;
                // BUSCA TODAS AS INFORMAÇÕES DO PRODUTO PELO CODIGO DE BARRA
                dtoMatMed = MatMed.BuscaCodigoBarra(dtoCodigoBarra);

                this.CarregarProduto(); 
            }
        }

        private void rbHac_CheckedChanged(object sender, EventArgs e)
        {
            if (SetorDestinoCarrinhoEmergencia() && rbHac.Checked)
            {
                MessageBox.Show("Permitido movimentação apenas entre Carrinhos de Emergência.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rbCE.Checked = true;
                return;
            }
            this.AtualizarQtdEstoques();
        }

        private void rbAcs_CheckedChanged(object sender, EventArgs e)
        {
            this.AtualizarQtdEstoques();
            //if (SetorDestinoCarrinhoEmergencia() && rbAcs.Checked)
            //{
            //    MessageBox.Show("Permitido movimentação apenas entre Carrinhos de Emergência.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    rbCE.Checked = true;
            //    return;
            //}
            //if (lblObsEU.Visible && rbAcs.Checked)
            //if (VerificaEstoqueUnificadoOrigem() && rbAcs.Checked)
            //{
            //    MessageBox.Show("Estoque de Origem não pode ser do ACS quando Estoque Único", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    rbAcs.Checked = false;
            //    return;
            //}
            //else if (VerificaEstoqueUnificadoDestino() && rbAcs.Checked)
            //{
            //    MessageBox.Show("Estoque de Origem não pode ser do ACS quando destino é Estoque Único", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    rbAcs.Checked = false;
            //    return;
            //}
            //else
            //    this.AtualizarQtdEstoques();
        }

        private void rbCE_CheckedChanged(object sender, EventArgs e)
        {
            this.AtualizarQtdEstoques();
        }

        private void rbConsig_CheckedChanged(object sender, EventArgs e)
        {
            if (SetorDestinoCarrinhoEmergencia() && rbConsig.Checked)
            {
                MessageBox.Show("Permitido movimentação apenas entre Carrinhos de Emergência.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                rbCE.Checked = true;
                return;
            }
            this.AtualizarQtdEstoques();
        }     

        private void chbTodoSaldo_Click(object sender, EventArgs e)
        {
            if (!cmbUnidadeDestino.Enabled)
            {
                chbTodoSaldo.Checked = chbItensKit.Checked = false;
                return;
            }
            if (chbTodoSaldo.Checked && !ValidarSetorOrigemTransferirTudo())
            {
                chbTodoSaldo.Checked = false;
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            cmbKit.IniciaLista();
            cmbKit.Enabled = false;

            if (chbTodoSaldo.Checked)
                chbItensKit.Enabled = false;
            else if (chbItensKit.Checked)
            {
                chbTodoSaldo.Enabled = false;
                cmbKit.Enabled = true;
            }
            else
            {
                chbTodoSaldo.Enabled = gen.VerificaAcessoFuncionalidade("TransferirTodoEstoque");
                chbItensKit.Enabled = gen.VerificaAcessoFuncionalidade("TransferirKitItens");
            }

            if (chbTodoSaldo.Checked || chbItensKit.Checked)
                grbProduto.Visible = false;
            else
                grbProduto.Visible = true;

            this.Cursor = Cursors.Default;
        }

        private void chbItensKit_Click(object sender, EventArgs e)
        {
            chbTodoSaldo_Click(sender, e);
        }          

        //private void rbHacDestino_CheckedChanged(object sender, EventArgs e)
        //{
        //    this.AtualizarQtdEstoques();
        //}

        //private void rbAcsDestino_CheckedChanged(object sender, EventArgs e)
        //{
        //    this.AtualizarQtdEstoques();
        //}

        #endregion
    }
}