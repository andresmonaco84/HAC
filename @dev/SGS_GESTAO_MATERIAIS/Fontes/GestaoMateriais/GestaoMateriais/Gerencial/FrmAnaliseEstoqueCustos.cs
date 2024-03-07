using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HospitalAnaCosta.SGS.GestaoMateriais;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.Componentes;
using System.Web.UI.WebControls;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.GestaoMateriais.Gerencial;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Movimentacao
{
    public partial class FrmAnaliseEstoqueCustos : FrmBase
    {        
        public FrmAnaliseEstoqueCustos()
        {
            InitializeComponent();
        }

        public static void AbreIndiceRotatividade(MaterialMedicamentoDTO dto)
        {
            FrmAnaliseEstoqueCustos frm = new FrmAnaliseEstoqueCustos();
            frm.MdiParent = FrmPrincipal.ActiveForm;
            // frm.MatMed = dto;
            if (dto.IdtFilial.Value == (decimal)FilialMatMedDTO.Filial.HAC)
            {
                frm.rbHac.Checked = true;
            }
            else if (dto.IdtFilial.Value == (decimal)FilialMatMedDTO.Filial.ACS)
            {
                frm.rbAcs.Checked = true;
            }
            else if (dto.IdtFilial.Value == (decimal)FilialMatMedDTO.Filial.CONSIGNADO)
            {
                frm.rbConsig.Checked = true;
            }
            object sender = null;
            frm.Show();
            frm.txtIdProduto.Text = dto.Idt.Value.ToString();
            frm.txtIdProduto_Validating(sender , null );
        }
        private FrmManutProd frmProduto;
        #region OBJETOS SERVIÇOS

        // Utilitario
        private IUtilitario _utilitario;
        private IUtilitario Utilitario
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        // MatMed
        private MaterialMedicamentoDTO dtoMatMed;
        private IMaterialMedicamento _matMed;
        private IMaterialMedicamento MatMed
        {
            get { return _matMed != null ? _matMed : _matMed = (IMaterialMedicamento)Global.Common.GetObject( typeof(IMaterialMedicamento)); }
        }

        // GrupoMatMed
        private GrupoMatMedDTO dtoGrupo;
        private IGrupoMatMed _grupoMatMed;
        private IGrupoMatMed GrupoMatMed
        {
            get { return _grupoMatMed != null ? _grupoMatMed : _grupoMatMed = (IGrupoMatMed)Global.Common.GetObject( typeof(IGrupoMatMed)); }
        }

        // SubGrupoMatMed
        private SubGrupoMatMedDTO dtoSubGrupo;
        private ISubGrupoMatMed _subGrupoMatMed;
        private ISubGrupoMatMed SubGrupoMatMed
        {
            get { return _subGrupoMatMed != null ? _subGrupoMatMed : _subGrupoMatMed = (ISubGrupoMatMed)Global.Common.GetObject( typeof(ISubGrupoMatMed)); }
        }

        // Estoque
        private IEstoqueLocal _estoque;
        private IEstoqueLocal Estoque
        {
            get { return _estoque != null ? _estoque : _estoque = (IEstoqueLocal)Global.Common.GetObject( typeof(IEstoqueLocal)); }
        }
        private EstoqueLocalDTO dtoEstoque;
        private EstoqueLocalDataTable dtbEstoque;

        // HistoricoNotaFiscal
        private IHistoricoNotaFiscal _histNF;
        private IHistoricoNotaFiscal HistoricoNotaFiscal
        {
            get { return _histNF != null ? _histNF : _histNF = (IHistoricoNotaFiscal)Global.Common.GetObject( typeof(IHistoricoNotaFiscal)); }
        }
        private HistoricoNotaFiscalDTO dtoHistNF;
        private HistoricoNotaFiscalDataTable dtbHistNF;

        private ITipoFracao _tipofracao;
        private ITipoFracao TipoFracao
        {
            get { return _tipofracao != null ? _tipofracao : _tipofracao = (ITipoFracao)Global.Common.GetObject(typeof(ITipoFracao)); }
        }

        private IMovimentacaoMensal _movitacaomensal;
        private IMovimentacaoMensal MovimentacaoMensal
        {
            get { return _movitacaomensal != null ? _movitacaomensal : _movitacaomensal = (IMovimentacaoMensal)Global.Common.GetObject(typeof(IMovimentacaoMensal)); }
        }

        private IMovimentacao _movimento;
        private IMovimentacao Movimento
        {
            get { return _movimento != null ? _movimento : _movimento = (IMovimentacao)Global.Common.GetObject(typeof(IMovimentacao)); }
        }


        #endregion

        Generico gen = new Generico();

        //DateTime Data1i;
        //DateTime Data1f;
        //DateTime Data2i;
        //DateTime Data2f;
        //DateTime Data3i;
        //DateTime Data3f;

        decimal Mes0;
        decimal Mes1;
        decimal Mes2;
        decimal Mes3;

        decimal Ano0;
        decimal Ano1;
        decimal Ano2;
        decimal Ano3;

        decimal? TotalDiasMes;

        int MesCfg1 = 1;
        int MesCfg2 = 2;
        int MesCfg3 = 3;

        #region FUNÇÕES

        /// <summary>
        /// Busca Informações sobre o Produto selecionado
        /// </summary>
        private void CarregarProduto()
        {            
            this.Cursor = Cursors.WaitCursor;
            dtbHistNF = null;
            dtbEstoque = null;
            base.Controla(Evento.eNovo);
            btnMarcas.Enabled = false;
            if (dtoMatMed != null)
            {
                if (!dtoMatMed.Idt.Value.IsNull)
                {
                    txtDsProduto.Text = string.Format("{0}-{1}", dtoMatMed.Idt.Value.ToString(), dtoMatMed.NomeFantasia.Value);
                    txtCodMne.Text = dtoMatMed.CodMne.Value;
                    chkAtivo.Checked = (dtoMatMed.FlAtivo.Value == 1 ? true : false);
                    //txtCdFabricante.Text = dtoMatMed.CdFabricante.Value;                    
                    txtUnidCompra.Text = dtoMatMed.DsUnidadeCompra.Value;
                    txtUnidControle.Text = dtoMatMed.DsUnidadeControle.Value;
                    txtUnidVenda.Text = dtoMatMed.DsUnidadeVenda.Value;
                    chkFracionado.Checked = (dtoMatMed.FlFracionado.Value == 1 ? true : false);
                    chkMAV.Visible = false;
                    if (decimal.Parse(dtoMatMed.Tabelamedica.Value.ToString()) == (decimal)MaterialMedicamentoDTO.TipoMatMed.MATERIAL)
                        rbMaterial.Checked = true;
                    else
                    {
                        rbMedicamento.Checked = chkMAV.Visible = true;                        
                        if (dtoMatMed.MedAltaVigilancia.Value.IsNull) dtoMatMed.MedAltaVigilancia.Value = "N";
                        chkMAV.Checked = (dtoMatMed.MedAltaVigilancia.Value == "S" ? true : false);                        
                    }                    

                    dtoGrupo = new GrupoMatMedDTO();
                    dtoGrupo.Idt = dtoMatMed.IdtGrupo;
                    dtoGrupo = GrupoMatMed.SelChave(dtoGrupo);

                    txtGrupo.Text = dtoGrupo.DsGrupo.Value;

                    // TELA DE INFORMAÇÕES
                    try
                    {
                        dtoSubGrupo = new SubGrupoMatMedDTO();
                        dtoSubGrupo.Idt.Value = dtoMatMed.IdtSubGrupo.Value;
                        dtoSubGrupo.IdtGrupo.Value = dtoMatMed.IdtGrupo.Value;
                        if (!dtoSubGrupo.Idt.Value.IsNull && dtoSubGrupo.Idt.Value != 0)
                        {
                            dtoSubGrupo = SubGrupoMatMed.SelChave(dtoSubGrupo);

                            txtSubGrupo.Text = dtoSubGrupo.DsSubGrupo.Value;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Problema no Grupo ou Sub Grupo deste Produto");
                    }
                    if (ValidarFilial(false))
                    {
                        BuscaHistoricoNotaFiscal();
                        InfoProduto();
                        BuscaMovimentacao();
                        //this.PreencherUltimosConsumos();
                    }
                    this.BuscaEstoquesLocais();
                    if (dtoGrupo.Idt.Value == 6) btnMarcas.Enabled = true; //MATERIAL MEDICO HOSPITALAR
                }
                else
                {
                    dtoMatMed = null;
                    //this.ZerarUltimosConsumos();
                    txtIdProduto.Focus();
                }
            }
            else
            {
                //this.ZerarUltimosConsumos();
                txtIdProduto.Focus();
            }
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Configura Grid Com Estoque local de cada unidade
        /// </summary>
        private void ConfigurarConsumoDTG()
        {
            dtgConsumo.AutoGenerateColumns = false;
            dtgConsumo.Columns["colDsUnidade"].DataPropertyName = EstoqueLocalDTO.FieldNames.DsUnidade;
            dtgConsumo.Columns["colSaldo"].DataPropertyName = EstoqueLocalDTO.FieldNames.Qtde;
            dtgConsumo.Columns["colSaldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgConsumo.Columns["colSaldo"].DefaultCellStyle.Format = "N0";
            dtgConsumo.Columns["colDsSetor"].DataPropertyName = EstoqueLocalDTO.FieldNames.DsSetor;
            dtgConsumo.Columns["colQtdPadrao"].DataPropertyName = EstoqueLocalDTO.FieldNames.QtdePadrao;
            dtgConsumo.Columns["colQtdPadrao"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgConsumo.Columns["colQtdPadrao"].DefaultCellStyle.Format = "N0";

            // dtgConsumo.Columns["colConsDiario"].DataPropertyName = EstoqueLocalDTO.FieldNames.;
            // dtgConsumo.Columns["colConsDiario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            // dtgConsumo.Columns["colConsDiario"].DefaultCellStyle.Format = "N0";

            dtgConsumo.Columns["colPercentual"].DataPropertyName = EstoqueLocalDTO.FieldNames.Percentual;
            dtgConsumo.Columns["colPercentual"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgConsumo.Columns["colPercentual"].DefaultCellStyle.Format = "N0";

            dtgConsumo.Columns["colDtFornecimento"].DataPropertyName = EstoqueLocalDTO.FieldNames.DataFornecimento;
            dtgConsumo.Columns["colDtFornecimento"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

            dtgConsumo.Columns["colQtdeFracionada"].DataPropertyName = EstoqueLocalDTO.FieldNames.QtdeFracionada;
            dtgConsumo.Columns["colQtdeCE"].DataPropertyName = EstoqueLocalDTO.FieldNames.QtdCE;
            dtgConsumo.Columns["colIdUnidade"].DataPropertyName = EstoqueLocalDTO.FieldNames.IdtUnidade;
            dtgConsumo.Columns["colIdLocal"].DataPropertyName = EstoqueLocalDTO.FieldNames.IdtLocal;
            dtgConsumo.Columns["colIdSetor"].DataPropertyName = EstoqueLocalDTO.FieldNames.IdtSetor;

            dtgConsumo.ContextMenuStrip = MnPopUp;
        }

        /// <summary>
        /// Configura Grid de Notas Ficais
        /// </summary>
        private void ConfigurarComprasDTG()
        {
            dtgCompras.AutoGenerateColumns = false;
            dtgCompras.Columns["colIdMov"].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.NrNota;
            dtgCompras.Columns["colFornecedor"].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.DsFornecedor;
            dtgCompras.Columns["colData"].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.DataPrcMedio;
            dtgCompras.Columns["colData"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";
            dtgCompras.Columns["colQtd"].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.Qtde;
            dtgCompras.Columns["colQtd"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgCompras.Columns["colQtd"].DefaultCellStyle.Format = "N0";
            dtgCompras.Columns["colUnidade"].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.UnidadeCompra; // (unidade (compra))
            dtgCompras.Columns["colVlrUnitario"].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.PrecoUnitario;
            dtgCompras.Columns["colVlrUnitario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgCompras.Columns["colTpMovimento"].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.TpMovimento;

            dtgCompras.Columns["colSaldoanterior"].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.SaldoAnterior;
            dtgCompras.Columns["colSaldoanterior"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtgCompras.Columns["colSaldoanterior"].DefaultCellStyle.Format = "N0";

            dtgCompras.Columns["colCustoMedio"].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.CustoMedio;
            dtgCompras.Columns["colCustoMedio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

            dtgCompras.Columns["colQtdeCompra"].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.QtdeTotalNota;
            dtgCompras.Columns["colQtdeCompra"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;

            dtgCompras.Columns[colCodLote.Name].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.CodLote;
            dtgCompras.Columns[colIdLote.Name].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.IdtLote;
            dtgCompras.Columns[colLoteFab.Name].DataPropertyName = HistoricoNotaFiscalDTO.FieldNames.NumLote;
            // dtgCompras.Columns["colCustoMedio"].DefaultCellStyle.Format = "N0";
        }

        /// <summary>
        /// Busca Estoque do Produto em todos os setores
        /// </summary>
        private void BuscaEstoquesLocais()
        {
            if (dtoMatMed != null)
            {
                dtoEstoque = new EstoqueLocalDTO();
                EstoqueLocalDTO _dto = new EstoqueLocalDTO();
                decimal soma = 0;
                decimal somaCE = 0;
                dtoEstoque.Origem.Value = 1;
                dtoEstoque.IdtFilial.Value = gen.RetornaFilial(rbHac, rbAcs, new System.Windows.Forms.RadioButton(), rbConsig);
                dtoEstoque.IdtProduto = dtoMatMed.Idt;
                dtbEstoque = Estoque.EstoqueOnLine(dtoEstoque);

                // totaliza colunas 
                for (int i = 0; i < dtbEstoque.Rows.Count; i++)
                {
                    _dto = dtbEstoque.TypedRow(i);
                    _dto.Qtde.Value = (_dto.Qtde.Value.IsNull ? 0 : _dto.Qtde.Value);
                    soma = soma + (decimal)_dto.Qtde.Value;
                    _dto.QtdCE.Value = (_dto.QtdCE.Value.IsNull ? 0 : _dto.QtdCE.Value);
                    somaCE = somaCE + (decimal)_dto.QtdCE.Value;
                }
                // txtTotalSaldo.Text = soma.ToString();
                txtTotalSaldo.Text = Convert.ToString((soma+somaCE));
                txtTotalCe.Text = somaCE.ToString();
                dtgConsumo.DataSource = dtbEstoque;                             
            }  
        }
        
        /// <summary>
        /// Busca entrada de notas dos últimos 12 meses
        /// </summary>
        private void BuscaHistoricoNotaFiscal()
        {
            txtPrecoMedio.Text = string.Empty;
            if (dtoMatMed != null)
            {
                if (!ValidarFilial(true)) return;

                dtoHistNF = new HistoricoNotaFiscalDTO();

                dtoHistNF.IdtProduto = dtoMatMed.Idt;
                dtoHistNF.DataPrcMedio.Value = Utilitario.ObterDataHoraServidor().AddMonths(-12);
                dtoHistNF.IdtFilial.Value = gen.RetornaFilial(rbHac, rbAcs, new System.Windows.Forms.RadioButton(), rbConsig);

                dtbHistNF = HistoricoNotaFiscal.Sel(dtoHistNF);
                dtgCompras.DataSource = dtbHistNF;
                if (!new Generico().VerificaAcessoFuncionalidade("EstornoNF"))
                    dtgCompras.Columns[0].Visible = false;
            }            
        }

        /// <summary>
        /// Limpa obsjetos com o consumo/Entrada/I.R.
        /// </summary>
        private void LimparConsumoPeriodo()
        {
            txtRessuprimento.Text = string.Empty;
            txtRotatividade.Text = string.Empty;

            txtConsPeriodo.Text = string.Empty;
            txtEntrPeriodo.Text = string.Empty;

            txtEntrada1.Text = string.Empty;
            txtEntrada2.Text = string.Empty;
            txtEntrada3.Text = string.Empty;

            txtEntDia1.Text = string.Empty;
            txtEntDia2.Text = string.Empty;
            txtEntDia3.Text = string.Empty;

            txtConsumo1.Text = string.Empty;
            txtConsumo2.Text = string.Empty;
            txtConsumo3.Text = string.Empty;

            txtConsDia1.Text = string.Empty;
            txtConsDia2.Text = string.Empty;
            txtConsDia3.Text = string.Empty;

            txtIr1.Text = string.Empty;
            txtIr2.Text = string.Empty;
            txtIr3.Text = string.Empty;
        }

        private void LimparGrids()
        {
            dtgCompras.DataSource = null;
            dtgConsumo.DataSource = null;
        }

        /// <summary>
        /// Busca a movimentação dos meses passado como parâmetro
        /// </summary>
        private void BuscaMovimentacao()
        {
            if (dtoMatMed != null)
            {
                if (!ValidarFilial(true)) return;

                MovimentacaoMensalDTO dtoMensal = new MovimentacaoMensalDTO();
                MovimentacaoMensalDTO dtoMensalResultado = new MovimentacaoMensalDTO();
                MovimentacaoMensalDataTable dtbMensalResultado = new MovimentacaoMensalDataTable();
                MovimentacaoDTO dtoMovAlmox = new MovimentacaoDTO();
                dtoMovAlmox.IdtProduto.Value = dtoMatMed.Idt.Value;
                dtoMovAlmox.IdtFilial.Value = dtoMatMed.IdtFilial.Value;
                dtoMovAlmox.IdtUnidade.Value = 244;
                dtoMovAlmox.IdtLocal.Value = 33;
                dtoMovAlmox.IdtSetor.Value = 29; //ALMOXARIFADO CENTRAL

                // decimal consumoMedio, iRotatividade, nEntrada;                
                // DateTime dt1, dt2;
                lblMes0.Text = Utilitario.ObterDataHoraServidor().ToString("MM/yyyy").ToString();
                Mes0 = Convert.ToDecimal(Utilitario.ObterDataHoraServidor().Month);
                Ano0 = Convert.ToDecimal(Utilitario.ObterDataHoraServidor().Year);

                lblMes1.Text = Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg1).ToString("MM/yyyy").ToString();
                Mes1 = Convert.ToDecimal(Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg1).ToString("MM"));
                Ano1 = Convert.ToDecimal(Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg1).ToString("yyyy"));

                lblMes2.Text = Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg2).ToString("MM/yyyy").ToString();
                Mes2 = Convert.ToDecimal(Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg2).ToString("MM"));
                Ano2 = Convert.ToDecimal(Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg2).ToString("yyyy"));

                lblMes3.Text = Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg3).ToString("MM/yyyy").ToString();
                Mes3 = Convert.ToDecimal(Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg3).ToString("MM"));
                Ano3 = Convert.ToDecimal(Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg3).ToString("yyyy"));

                // M E S  A T U A L

                dtoMensal.IdtProduto.Value = dtoMatMed.Idt.Value;
                dtoMensal.IdtFilial.Value = dtoMatMed.IdtFilial.Value;
                dtoMensal.Mes.Value = Mes0;
                dtoMensal.Ano.Value = Ano0;
                dtoMensal.TipoMovimento.Value = 1;
                dtoMensal.SubTipoMovimento.Value = 0;

                dtbMensalResultado = MovimentacaoMensal.Sel(dtoMensal);
                if (dtbMensalResultado.Rows.Count > 0)
                {
                    dtoMensalResultado = dtbMensalResultado.TypedRow(0);

                    txtEntrada0.Text = Generico.FormataNumero(dtoMensalResultado.QtdeEntrada.Value);
                    txtConsumo0.Text = Generico.FormataNumero(dtoMensalResultado.QtdeSaida.Value);

                    TotalDiasMes = Convert.ToInt16(Utilitario.ObterDataHoraServidor().Day);

                    txtEntDia0.Text = Generico.FormataNumero((dtoMensalResultado.QtdeEntrada.Value / TotalDiasMes), 2);
                    txtConsDia0.Text = Generico.FormataNumero((dtoMensalResultado.QtdeSaida.Value / TotalDiasMes), 2);

                    if (dtoMensal != null)
                    {
                        dtoMensal = MovimentacaoMensal.ObtemIndiceRotatividade(dtoMensal);
                        txtIr0.Text = dtoMensal.IndiceRotatividade.Value.ToString(); ;
                    }
                }
                else
                {
                    txtEntrada0.Text = string.Empty;
                    txtConsumo0.Text = string.Empty;
                    txtEntDia0.Text = string.Empty;
                    txtConsDia0.Text = string.Empty;
                    txtIr0.Text = string.Empty;
                }
                
                dtoMovAlmox.DataMovimento.Value = Utilitario.ObterDataHoraServidor().ToString("01/MM/yyyy");
                dtoMovAlmox.DataAte.Value = Utilitario.ObterDataHoraServidor().ToString();

                txtMedSaiAlmox0.Text = Movimento.ObterSaidasMensalSetor(dtoMovAlmox).ToString("N2");
                TotalDiasMes = null;

                // P R I M E I R O  M E S  

                dtoMensal.IdtProduto.Value = dtoMatMed.Idt.Value;
                dtoMensal.IdtFilial.Value = dtoMatMed.IdtFilial.Value;
                dtoMensal.Mes.Value = Mes1;
                dtoMensal.Ano.Value = Ano1;
                dtoMensal.TipoMovimento.Value = 1;
                dtoMensal.SubTipoMovimento.Value = 0;
                // dtoMensalResultado = MovimentacaoMensal.Sel(dtoMensal).TypedRow(0);
                dtbMensalResultado = MovimentacaoMensal.Sel(dtoMensal);
                if (dtbMensalResultado.Rows.Count > 0)
                {
                    dtoMensalResultado = dtbMensalResultado.TypedRow(0);

                    txtEntrada1.Text = Generico.FormataNumero(dtoMensalResultado.QtdeEntrada.Value);
                    txtConsumo1.Text = Generico.FormataNumero(dtoMensalResultado.QtdeSaida.Value);

                    TotalDiasMes = DateTime.DaysInMonth(Convert.ToInt16(Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg1).ToString("yyyy")), Convert.ToInt16(Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg1).ToString("MM")));

                    txtEntDia1.Text = Generico.FormataNumero((dtoMensalResultado.QtdeEntrada.Value / TotalDiasMes), 2);
                    txtConsDia1.Text = Generico.FormataNumero((dtoMensalResultado.QtdeSaida.Value / TotalDiasMes), 2);

                    if (dtoMensal != null)
                    {
                        dtoMensal = MovimentacaoMensal.ObtemIndiceRotatividade(dtoMensal);
                        txtIr1.Text = dtoMensal.IndiceRotatividade.Value.ToString();
                    }
                }
                else
                {
                    txtEntrada1.Text = string.Empty;
                    txtConsumo1.Text = string.Empty;
                    txtEntDia1.Text = string.Empty;
                    txtConsDia1.Text = string.Empty;
                    txtIr1.Text = string.Empty;
                }

                txtMedSaiAlmox1.Text = string.Empty;
                if (TotalDiasMes != null && TotalDiasMes.Value > 0)
                {
                    dtoMovAlmox.DataMovimento.Value = Utilitario.ObterDataHoraServidor().AddMonths(-1).ToString("01/MM/yyyy");
                    dtoMovAlmox.DataAte.Value = TotalDiasMes.ToString() + Utilitario.ObterDataHoraServidor().AddMonths(-1).ToString("/MM/yyyy 23:59:59");

                    txtMedSaiAlmox1.Text = Movimento.ObterSaidasMensalSetor(dtoMovAlmox).ToString("N2");
                }
                TotalDiasMes = null;

                // S E G U N D O  M E S   

                dtoMensal.IdtProduto.Value = dtoMatMed.Idt.Value;
                dtoMensal.IdtFilial.Value = dtoMatMed.IdtFilial.Value;
                dtoMensal.Mes.Value = Mes2;
                dtoMensal.Ano.Value = Ano2;
                dtoMensal.TipoMovimento.Value = 1;
                dtoMensal.SubTipoMovimento.Value = 0;
                // dtoMensalResultado = MovimentacaoMensal.Sel(dtoMensal).TypedRow(0);
                dtbMensalResultado = MovimentacaoMensal.Sel(dtoMensal);
                if (dtbMensalResultado.Rows.Count > 0)
                {
                    dtoMensalResultado = dtbMensalResultado.TypedRow(0);

                    txtEntrada2.Text = Generico.FormataNumero(dtoMensalResultado.QtdeEntrada.Value);
                    txtConsumo2.Text = Generico.FormataNumero(dtoMensalResultado.QtdeSaida.Value);

                    TotalDiasMes = DateTime.DaysInMonth(Convert.ToInt16(Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg2).ToString("yyyy")), Convert.ToInt16(Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg2).ToString("MM")));
                    txtEntDia2.Text = Generico.FormataNumero((dtoMensalResultado.QtdeEntrada.Value / TotalDiasMes), 2);
                    txtConsDia2.Text = Generico.FormataNumero((dtoMensalResultado.QtdeSaida.Value / TotalDiasMes), 2);

                    if (dtoMensal != null)
                    {
                        dtoMensal = MovimentacaoMensal.ObtemIndiceRotatividade(dtoMensal);
                        txtIr2.Text = dtoMensal.IndiceRotatividade.Value.ToString();
                    }
                }
                else
                {
                    txtEntrada2.Text = string.Empty;
                    txtConsumo2.Text = string.Empty;
                    txtEntDia2.Text = string.Empty;
                    txtConsDia2.Text = string.Empty;
                    txtIr2.Text = string.Empty;
                }

                txtMedSaiAlmox2.Text = string.Empty;
                if (TotalDiasMes != null && TotalDiasMes.Value > 0)
                {
                    dtoMovAlmox.DataMovimento.Value = Utilitario.ObterDataHoraServidor().AddMonths(-2).ToString("01/MM/yyyy");
                    dtoMovAlmox.DataAte.Value = TotalDiasMes.ToString() + Utilitario.ObterDataHoraServidor().AddMonths(-2).ToString("/MM/yyyy 23:59:59");

                    txtMedSaiAlmox2.Text = Movimento.ObterSaidasMensalSetor(dtoMovAlmox).ToString("N2");
                }
                TotalDiasMes = null;

                // T E R C E I R O  M E S

                dtoMensal.IdtProduto.Value = dtoMatMed.Idt.Value;
                dtoMensal.IdtFilial.Value = dtoMatMed.IdtFilial.Value;
                dtoMensal.Mes.Value = Mes3;
                dtoMensal.Ano.Value = Ano3;
                dtoMensal.TipoMovimento.Value = 1;
                dtoMensal.SubTipoMovimento.Value = 0;
                // dtoMensalResultado = MovimentacaoMensal.Sel(dtoMensal).TypedRow(0);
                dtbMensalResultado = MovimentacaoMensal.Sel(dtoMensal);
                if (dtbMensalResultado.Rows.Count > 0)
                {
                    dtoMensalResultado = dtbMensalResultado.TypedRow(0);

                    txtEntrada3.Text = Generico.FormataNumero(dtoMensalResultado.QtdeEntrada.Value);
                    txtConsumo3.Text = Generico.FormataNumero(dtoMensalResultado.QtdeSaida.Value);

                    TotalDiasMes = DateTime.DaysInMonth(Convert.ToInt16(Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg3).ToString("yyyy")), Convert.ToInt16(Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg3).ToString("MM")));
                    txtEntDia3.Text = Generico.FormataNumero((dtoMensalResultado.QtdeEntrada.Value / TotalDiasMes), 2);
                    txtConsDia3.Text = Generico.FormataNumero((dtoMensalResultado.QtdeSaida.Value / TotalDiasMes), 2);

                    if (dtoMensal != null)
                    {
                        dtoMensal = MovimentacaoMensal.ObtemIndiceRotatividade(dtoMensal);
                        txtIr3.Text = dtoMensal.IndiceRotatividade.Value.ToString();
                    }
                }
                else
                {
                    txtEntrada3.Text = string.Empty;
                    txtConsumo3.Text = string.Empty; 
                    txtEntDia3.Text =  string.Empty;
                    txtConsDia3.Text = string.Empty;
                    txtIr3.Text = string.Empty;
                }

                txtMedSaiAlmox3.Text = string.Empty;
                if (TotalDiasMes != null && TotalDiasMes.Value > 0)
                {
                    dtoMovAlmox.DataMovimento.Value = Utilitario.ObterDataHoraServidor().AddMonths(-3).ToString("01/MM/yyyy");
                    dtoMovAlmox.DataAte.Value = TotalDiasMes.ToString() + Utilitario.ObterDataHoraServidor().AddMonths(-3).ToString("/MM/yyyy 23:59:59");

                    txtMedSaiAlmox3.Text = Movimento.ObterSaidasMensalSetor(dtoMovAlmox).ToString("N2");
                }
                TotalDiasMes = null;

                //if (!DateTime.TryParse(txtInicio.Text, out dt1)) dt1 = ObterInicioPadraoConsulta();
                //if (!DateTime.TryParse(txtFim.Text, out dt2)) dt2 = ObterFimPadraoConsulta();
                
                //ConfiguraMatMedDTO();

                //// MatMed.ObterStatusConsumo(dtoMatMed, Data1i, Data1f, out consumoMedio, out iRotatividade, out nEntrada);

                //TotalDiasMes = DateTime.DaysInMonth(Convert.ToInt16(Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg1).ToString("yyyy")),
                //                      Convert.ToInt16(Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg1).ToString("MM")));

                //txtEntrada1.Text =  (nEntrada * TotalDiasMes).ToString("N0");
                //txtEntDia1.Text = nEntrada.ToString("N0");

                //txtConsumo1.Text = (consumoMedio * TotalDiasMes).ToString("N0");
                //txtConsDia1.Text = consumoMedio.ToString("N0");
                //txtIr1.Text = iRotatividade.ToString();

                //MatMed.ObterStatusConsumo(dtoMatMed, Data2i, Data2f, out consumoMedio, out iRotatividade, out nEntrada);

                //TotalDiasMes = DateTime.DaysInMonth(Convert.ToInt16(Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg2).ToString("yyyy")),
                //                      Convert.ToInt16(Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg2).ToString("MM")));


                //txtEntrada2.Text = (nEntrada * TotalDiasMes).ToString("N0");
                //txtEntDia2.Text = nEntrada.ToString("N0");

                //txtConsumo2.Text = (consumoMedio * TotalDiasMes).ToString("N0");
                //txtConsDia2.Text = consumoMedio.ToString("N0");

                //txtIr2.Text = iRotatividade.ToString();

                //MatMed.ObterStatusConsumo(dtoMatMed, Data3i, Data3f, out consumoMedio, out iRotatividade, out nEntrada);

                //TotalDiasMes = DateTime.DaysInMonth(Convert.ToInt16(Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg3).ToString("yyyy")),
                //                      Convert.ToInt16(Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg3).ToString("MM")));


                //txtEntrada3.Text = (nEntrada * TotalDiasMes).ToString("N0");
                //txtEntDia3.Text = nEntrada.ToString("N0");

                //txtConsumo3.Text = (consumoMedio * TotalDiasMes).ToString("N0");
                //txtConsDia3.Text = consumoMedio.ToString("N0");
                //txtIr3.Text = iRotatividade.ToString();

                //dt1 = Convert.ToDateTime(txtInicio.Text);
                //dt2 = Convert.ToDateTime(txtFim.Text);
                //MatMed.ObterStatusConsumo(dtoMatMed, dt1, dt2 , out consumoMedio, out iRotatividade, out nEntrada);
                ////txtConsumoMedio.Text = consumoMedio.ToString();
                //txtEntrPeriodo.Text = nEntrada.ToString();
                //txtConsPeriodo.Text = consumoMedio.ToString();
                //txtRotatividade.Text = iRotatividade.ToString();                
            }     
        }

        /// <summary>
        /// Busca Estoque contabil e data do último consumo
        /// </summary>
        private void InfoProduto()
        {
            txtQtdeEstoque.Text = string.Empty;
            txtTotalSaldo.Text = string.Empty;
            txtUltimoConsumo.Text = string.Empty;
            txtPrecoMedio.Text = string.Empty;

            if (dtoMatMed != null)
            {
                if (!ValidarFilial(true)) return;
                ConfiguraMatMedDTO();
                dtoMatMed = MatMed.InfoContabil(dtoMatMed);

                //txtQtdeEstoque.Text = Generico.FormataNumero(dtoMatMed.QtdeEstoqueContabil.Value);
                txtUltimoConsumo.Text = dtoMatMed.DtUltimoConsumo.Value.ToString();
                txtPrecoMedio.Text = dtoMatMed.CustoMedio.Value.ToString();
            }
        }

        private void ConfiguraMatMedDTO()
        {
            if (dtoMatMed != null)
            {
                dtoMatMed.IdtFilial.Value = gen.RetornaFilial(rbHac, rbAcs, new System.Windows.Forms.RadioButton(), rbConsig);
                dtoMatMed.QtdeEstoqueContabil.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
                dtoMatMed.DtUltimoConsumo.Value = new HospitalAnaCosta.Framework.DTO.TypeDateTime();
                dtoMatMed.CustoMedio.Value = new HospitalAnaCosta.Framework.DTO.TypeDecimal();
            }
        }

        /// <summary>
        /// Verifica se alguma filial foi selecionada
        /// </summary>
        /// <param name="mostrarMsgBox"></param>
        /// <returns></returns>
        private bool ValidarFilial(bool mostrarMsgBox)
        {
            if (!rbAcs.Checked && !rbHac.Checked && !rbConsig.Checked)
            {
                if (mostrarMsgBox) MessageBox.Show("Selecione a Filial", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Limpa os objetos da tela e refaz a busca das informações
        /// </summary>
        private void RotinaTrocaFilial()
        {
            this.Cursor = Cursors.WaitCursor;
            this.LimparConsumoPeriodo();
            LimparGrids();
            BuscaHistoricoNotaFiscal();
            InfoProduto();
            this.BuscaMovimentacao();
            //this.PreencherUltimosConsumos();
            BuscaEstoquesLocais();
            this.Cursor = Cursors.Default;
        }

        /// <summary>
        /// Retorna primeiro dia do mês atual
        /// </summary>
        /// <returns></returns>
        private DateTime ObterInicioPadraoConsulta()
        {
            return DateTime.Parse("1/" + Utilitario.ObterDataHoraServidor().Month + "/" + Utilitario.ObterDataHoraServidor().Year);
        }

        /// <summary>
        /// Retorna data atual
        /// </summary>
        /// <returns></returns>
        private DateTime ObterFimPadraoConsulta()
        {
            return Utilitario.ObterDataHoraServidor();
        }

        /// <summary>
        /// cria as datas que serão usadas para pesquisa de consumo/entrada e calculo do IR
        /// </summary>
        private void FormataDatasPesquisa()
        {
            // lblMes1.Text = string.Format("{0}/{1}", Utilitario.ObterDataHoraServidor().AddMonths(-3).ToString("MM/yyyy"), Utilitario.ObterDataHoraServidor().add.Year);
            //lblMes1.Text = Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg1).ToString("MM/yyyy").ToString();
            //Mes1 = Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg1).ToString("MM");
            //Ano1 = Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg1).ToString("YYYY");

            //lblMes2.Text = Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg2).ToString("MM/yyyy").ToString();
            //Mes2 = Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg2).ToString("MM");
            //Ano2 = Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg2).ToString("YYYY");

            //lblMes3.Text = Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg3).ToString("MM/yyyy").ToString();
            //Mes3 = Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg3).ToString("MM");
            //Ano3 = Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg3).ToString("YYYY");


            //Data1i = DateTime.Parse("1/" + Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg3).ToString("MM/yyyy"));
            //Data1f = Convert.ToDateTime(
            //    DateTime.DaysInMonth(Convert.ToInt16(Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg3).ToString("yyyy")),
            //                          Convert.ToInt16(Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg3).ToString("MM"))).ToString() + "/" +
            //                          Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg3).ToString("MM/yyyy"));
            ////
            // lblMes2.Text = Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg2).ToString("MM/yyyy").ToString();
            //Data2i = DateTime.Parse("1/" + Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg2).ToString("MM/yyyy"));
            //Data2f = Convert.ToDateTime(
            //    DateTime.DaysInMonth(Convert.ToInt16(Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg2).ToString("yyyy")),
            //                          Convert.ToInt16(Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg2).ToString("MM"))).ToString() + "/" +
            //                          Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg2).ToString("MM/yyyy"));
            ////
            // lblMes3.Text = Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg1).ToString("MM/yyyy").ToString();
            //Data3i = DateTime.Parse("1/" + Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg1).ToString("MM/yyyy"));
            //Data3f = Convert.ToDateTime(
            //    DateTime.DaysInMonth(Convert.ToInt16(Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg1).ToString("yyyy")),
            //                          Convert.ToInt16(Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg1).ToString("MM"))).ToString() + "/" +
            //                          Utilitario.ObterDataHoraServidor().AddMonths(-MesCfg1).ToString("MM/yyyy"));
        }

        private void Cancelar()
        {
            dtoMatMed = null;
            base.Controla(Evento.eNovo);
            btnMarcas.Enabled = false;
            // this.ZerarUltimosConsumos();
            txtIdProduto.Focus();
        }

        #endregion

        #region EVENTOS

        private void FrmMovimentacao_Load(object sender, EventArgs e)
        {
            btnMarcas.Visible = false;
            ConfigurarComprasDTG();
            ConfigurarConsumoDTG();
            tsHac.Controla(Evento.eNovo);
            txtInicio.Text = ObterInicioPadraoConsulta().ToString("dd/MM/yyyy");
            txtFim.Text = ObterFimPadraoConsulta().ToString("dd/MM/yyyy");
            FormataDatasPesquisa();
            MnPopUp.Items["MnItemOutroSetor"].Visible = gen.VerificaAcessoFuncionalidade("FrmTransfMatMed");
            btnEndAlmox.Visible = gen.VerificaAcessoFuncionalidade("CadEnderecoAlmox");
            #if DEBUG
            btnMovimentacao.Visible = true;
            txtTotalSaldo.Visible = true;
            txtQtdeEstoque.Visible = true;
            txtTotalCe.Visible = true;
            btnEndAlmox.Visible = true;
            #else
            btnMovimentacao.Visible = false;
            txtTotalSaldo.Visible = true;
            txtQtdeEstoque.Visible = false;
            txtTotalCe.Visible = false;
            #endif
        }
        
        private bool tsHac_MatMedClick(object sender)
        {
            MaterialMedicamentoDTO dtoMatMedAux = new MaterialMedicamentoDTO();
            dtoMatMedAux.TpPesquisa.Value = (int)MaterialMedicamentoDTO.TipoDePesquisa.SEM_ESTOQUE;
            dtoMatMedAux = FrmPesquisaMatMed.SelecionaMatMed(dtoMatMedAux);

            if (dtoMatMedAux != null)
            {
                dtoMatMed = dtoMatMedAux;
                CarregarProduto();
            }                
            
            return true;
        }

        private bool tsHac_CancelarClick(object sender)
        {
            Cancelar();
            return false;
        }

        private void txtIdProduto_Validating(object sender, CancelEventArgs e)
        {
            if (txtIdProduto.Text != string.Empty)
            {
                if (!ValidarFilial(true))
                {
                    txtIdProduto.Text = string.Empty;
                    return;
                } 

                // BUSCA PELO CODIGO DO PRODDUTO
                MaterialMedicamentoDTO dtoIdProduto = new MaterialMedicamentoDTO();
                try
                {

                    dtoIdProduto.Idt.Value = txtIdProduto.Text;
                    dtoMatMed = null;
                    dtoMatMed = MatMed.SelChave(dtoIdProduto);
                    if (dtoMatMed == null)
                        throw new Exception("não achou");
                }          
                catch
                {
                    // NÃO ACHOU PELO ID DO PRODUTO PROCURA PELO CODIGO DE BARRA
                    CodigoBarraDTO dtoCodigoBarra = new CodigoBarraDTO();

                    dtoCodigoBarra.CdBarra.Value = txtIdProduto.Text;
                    // BUSCA TODAS AS INFORMAÇÕES DO PRODUTO PELO CODIGO DE BARRA
                    try
                    {
                        dtoMatMed = MatMed.BuscaCodigoBarra(dtoCodigoBarra);
                        if (dtoMatMed == null)
                            throw new Exception("não achou");

                    }
                    catch (Exception ex)
                    {
                        // NAO ACHOU PELO CÓDIGO PROCURA PELO CODMNE
                        try
                        {
                            MaterialMedicamentoDTO dtoCdMne = new MaterialMedicamentoDTO();
                            dtoCdMne.CodMne.Value = txtIdProduto.Text;
                            dtoMatMed = MatMed.Sel(dtoCdMne).TypedRow(0);
                            //MaterialMedicamentoDataTable dtCdMne = MatMed.Sel(dtoCdMne);
                            //if (dtCdMne.Rows.Count > 0)
                            //{
                            //    dtoMatMed = new MaterialMedicamentoDTO();
                            //    dtoMatMed.Idt.Value = dtCdMne.TypedRow(0).Idt.Value;
                            //    dtoMatMed = MatMed.SelChave(dtoMatMed);
                            //}
                            //else
                            //{
                            //    MessageBox.Show("Não foi encontrado produto, pesquisando por Id do Produto/Código de Barras/Código Mne");
                            //    return;
                            //}
                        }
                        catch(Exception exmne )
                        {
                           MessageBox.Show("Não foi encontrado produto, pesquisando por Id do Produto/Código de Barras/Código Mne");
                           return;
                        }
                    }
                }
                
                if (dtoMatMed == null)
                {
                    MessageBox.Show("Material/medicamento não identificado", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtIdProduto.Focus();
                }
                else
                {
                    this.CarregarProduto();
                }

                txtIdProduto.Text = string.Empty;
                txtIdProduto.Focus();
            }
        }

        private void btnRastrearProduto_Click(object sender, EventArgs e)
        {
            //this.Cursor = Cursors.WaitCursor;
            //InfoProduto();
            //BuscaEstoquesLocais();
            //this.Cursor = Cursors.Default;
            this.RotinaTrocaFilial();
        }

        private void rbHac_CheckedChanged(object sender, EventArgs e)
        {
            if ( rbHac.Checked)
                this.RotinaTrocaFilial();
        }

        private void rbAcs_CheckedChanged(object sender, EventArgs e)
        {
            if ( rbAcs.Checked)
                this.RotinaTrocaFilial();
        }

        private void rbConsig_CheckedChanged(object sender, EventArgs e)
        {
            if (rbConsig.Checked)
                this.RotinaTrocaFilial();
        }

        private void btnCalculoConsumo_Click(object sender, EventArgs e)
        {
            btnCalculoConsumo.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            InfoProduto();
            this.BuscaMovimentacao();
            this.BuscaEstoquesLocais();
            this.Cursor = Cursors.Default;
            btnCalculoConsumo.Enabled = true;
        }

        private void btnLimpaConsumo_Click(object sender, EventArgs e)
        {
            LimparConsumoPeriodo();
        }

        private void btnSimilares_Click(object sender, EventArgs e)
        {
            if (dtoMatMed != null)
            {
                MaterialMedicamentoDTO dtoMatMedRetorno = new FrmPesquisaSimilares().VisualizarSimilares(dtoMatMed);
                if (dtoMatMedRetorno != null && dtoMatMedRetorno.Idt.Value.ToString() != dtoMatMed.Idt.Value.ToString())
                {
                    dtoMatMed = dtoMatMedRetorno;
                    this.CarregarProduto();
                }
            }
        }

        private void btnMarcas_Click(object sender, EventArgs e)
        {
            if (dtoMatMed != null) new FrmMarcas().Visualizar(dtoMatMed);
        }

        private void btnGrafRot_Click(object sender, EventArgs e)
        {
            if (dtoMatMed != null)
            {
                DateTime dt1, dt2;

                txtInicio.Text = ObterInicioPadraoConsulta().AddMonths(-2).ToString("dd/MM/yyyy");
                txtFim.Text = ObterFimPadraoConsulta().ToString("dd/MM/yyyy");

                //Força que o período tenha os meses com todos os seus respectivos dias (ou seja, meses cheios)

                if (!DateTime.TryParse(txtInicio.Text, out dt1))
                {
                    dt1 = ObterInicioPadraoConsulta();
                }
                if (dt1.Day != 1)
                {                    
                    dt1 = DateTime.Parse("1/" + dt1.Month + "/" + dt1.Year);
                }

                if (!DateTime.TryParse(txtFim.Text, out dt2))
                {
                    dt2 = ObterFimPadraoConsulta();
                }
                if (DateTime.DaysInMonth(dt2.Year, dt2.Month) != dt2.Day)
                {
                    dt2 = DateTime.Parse(DateTime.DaysInMonth(dt2.Year, dt2.Month) + "/" + dt2.Month + "/" + dt2.Year);
                }

                if (dt1 > dt2)
                {
                    dt1 = ObterInicioPadraoConsulta();
                    dt2 = ObterFimPadraoConsulta();
                }

                //Força que haja um período de no mínimo 2 meses

                TimeSpan dateDif = dt2.Subtract(dt1.AddDays(-1));

                if (dateDif.Days < 58) dt1 = dt1.AddMonths(-1);
                
                ConfiguraMatMedDTO();

                new FrmGraficoRotatividade().GerarGrafico(dtoMatMed, dt1, dt2);
            } 
        }

        private void btnAbrirPainel_Click(object sender, EventArgs e)
        {
            if (dtoMatMed != null)
            {
                // pnlPainelProduto.Visible = true;
                if (frmProduto == null || frmProduto.IsDisposed)
                {
                    frmProduto = new FrmManutProd(dtoMatMed);
                    frmProduto.MdiParent = FrmPrincipal.ActiveForm;
                }

                frmProduto.Show();
                frmProduto.WindowState = FormWindowState.Normal;
                frmProduto.Focus();
            }
        }

        private void btnEndAlmox_Click(object sender, EventArgs e)
        {
            if (dtoMatMed != null) new FrmEnderecoAlmoxarifado().Visualizar((decimal)dtoMatMed.Idt.Value);
        }

        private void btnMovimentacao_Click(object sender, EventArgs e)
        {
            if (dtoMatMed != null)
            {
                MovimentacaoDTO dtoMovimentacao = new MovimentacaoDTO();
                dtoMovimentacao.IdtProduto.Value = dtoMatMed.Idt.Value;
                dtoMovimentacao.DsProduto.Value = dtoMatMed.Descricao.Value;
                // dtoMovimentacao.IdtUnidade.Value = dtoEstoque.IdtUnidade.Value;
                // dtoMovimentacao.IdtLocal.Value = dtoEstoque.IdtLocal.Value;
                // dtoMovimentacao.IdtSetor.Value = dtoEstoque.IdtSetor.Value;
                dtoMovimentacao.IdtFilial.Value = dtoMatMed.IdtFilial.Value;
                dtoMovimentacao.DataMovimento.Value = DateTime.Parse("1/" + Utilitario.ObterDataHoraServidor().Month + "/" + Utilitario.ObterDataHoraServidor().Year);
                // dtoMovimentacao.Qtde.Value = Convert.ToInt32(dtgMatMed.Rows[e.RowIndex].Cells["colQtdeEstoque"].Value.ToString());
                new Movimentacao.FrmMovimentacao().Movimentacao(dtoMovimentacao);
            }
        }

        private void btnHistDev_Click(object sender, EventArgs e)
        {
            if (dtoMatMed != null)
            {
                dtoMatMed.IdtFilial.Value = rbHac.Checked ? (byte)FilialMatMedDTO.Filial.HAC : (byte)FilialMatMedDTO.Filial.ACS;
                FrmHistDevolucoesNF.ExclusoesProduto(dtoMatMed);
            }
        }

        private void dtgCompras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                HistoricoNotaFiscalDTO dtoNF = null;
                if (dtgCompras.Columns[e.ColumnIndex].Name == colExcluir.Name ||
                    dtgCompras.Columns[e.ColumnIndex].Name == "colIdMov")
                {
                    DataRow[] drNotas = dtbHistNF.Select(string.Format("{0} = '{1}' AND {2} = '{3}'",
                                                                               HistoricoNotaFiscalDTO.FieldNames.NrNota,
                                                                               dtgCompras.Rows[e.RowIndex].Cells["colIdMov"].Value,
                                                                               HistoricoNotaFiscalDTO.FieldNames.DsFornecedor,
                                                                               dtgCompras.Rows[e.RowIndex].Cells["colFornecedor"].Value));
                    if (drNotas.Length == 1)
                    {
                        dtoNF = (HistoricoNotaFiscalDTO)drNotas[0];
                        //dtoNF.IdtLote.Value = new Framework.DTO.TypeDecimal();
                    }
                    else
                    {   //Buscar por lote também
                        dtoNF = (HistoricoNotaFiscalDTO)dtbHistNF.Select(string.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = {5}",
                                                                                       HistoricoNotaFiscalDTO.FieldNames.NrNota,
                                                                                       dtgCompras.Rows[e.RowIndex].Cells["colIdMov"].Value,
                                                                                       HistoricoNotaFiscalDTO.FieldNames.DsFornecedor,
                                                                                       dtgCompras.Rows[e.RowIndex].Cells["colFornecedor"].Value,
                                                                                       HistoricoNotaFiscalDTO.FieldNames.IdtLote,
                                                                                       dtgCompras.Rows[e.RowIndex].Cells["colIdLote"].Value))[0];
                    }
                }
                if (dtgCompras.Columns[e.ColumnIndex].Name == colExcluir.Name)
                {                    
                    if (// DateTime.Parse(dtoNF.DataPrcMedio.Value.ToString()).Date >= Utilitario.ObterDataHoraServidor().Date.AddDays(-7) &&
                        DateTime.Parse(dtoNF.DataPrcMedio.Value.ToString()).Date.ToString("MMyyyy") == Utilitario.ObterDataHoraServidor().Date.ToString("MMyyyy"))
                    {
                        if (FrmExclusaoItemNF.SolicitarExclusao(dtoNF, dtoMatMed))
                            this.RotinaTrocaFilial();
                    }
                    else
                    {
                        MessageBox.Show("Estorno inválido, pois esta nota não é referente ao mês atual.", "Gestão de Materiais e Medicamentos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else if (dtgCompras.Columns[e.ColumnIndex].Name == "colIdMov")
                {
                    if (FrmNFProdutos.Pesquisar(dtoNF))
                        this.RotinaTrocaFilial();
                }
            }
        }
        
        private void dtgConsumo_MouseMove(object sender, MouseEventArgs e)
        {
            if (dtgConsumo.Rows.Count > 0)
            {
                dtgConsumo.ClearSelection();
                int curRowIndex = dtgConsumo.HitTest(e.X, e.Y).RowIndex;
                if (curRowIndex >= 0 && curRowIndex != dtgConsumo.NewRowIndex)
                {
                    dtgConsumo.Rows[curRowIndex].Selected = true;
                    dtgConsumo.CurrentCell = dtgConsumo.Rows[curRowIndex].Cells[0];                    
                }
            }
        }

        private void MnItemOutroSetor_Click(object sender, EventArgs e)
        {
            if (dtoMatMed != null && base.Confirma(string.Format("{0} {1}?", "Deseja Fazer Transferência entre estoques do produto", dtoMatMed.NomeFantasia.Value)))
            {
                MovimentacaoDTO dtoTransfere = new MovimentacaoDTO();
                dtoTransfere.IdtUnidade.Value = dtgConsumo.CurrentRow.Cells["colIdUnidade"].Value.ToString();
                dtoTransfere.IdtLocal.Value = dtgConsumo.CurrentRow.Cells["colIdLocal"].Value.ToString();
                dtoTransfere.IdtSetor.Value = dtgConsumo.CurrentRow.Cells["colIdSetor"].Value.ToString();
                dtoTransfere.IdtProduto.Value = dtoMatMed.Idt.Value;
                dtoTransfere.DsProduto.Value = dtoMatMed.NomeFantasia.Value;
                dtoTransfere.IdtFilial.Value = gen.RetornaFilial(rbHac, rbAcs, new System.Windows.Forms.RadioButton(), rbConsig);
                FrmTransfMatMed.Transferencia(dtoTransfere);                
            }
        }

        #endregion          
    }
}