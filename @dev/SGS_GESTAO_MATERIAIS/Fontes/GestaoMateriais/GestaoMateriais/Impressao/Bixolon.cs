using System;
using System.Collections.Generic;
using System.Text;
using PrinterClassDll;
using HospitalAnaCosta.SGS.GestaoMateriais.Interface;
using HospitalAnaCosta.SGS.GestaoMateriais.Estoque;
using HospitalAnaCosta.SGS.GestaoMateriais.DTO;
using HospitalAnaCosta.SGS.GestaoMateriais.Auxiliar;
using HospitalAnaCosta.SGS.GestaoMateriais;
using HospitalAnaCosta.SGS.Seguranca.DTO;
using HospitalAnaCosta.Framework;
using HospitalAnaCosta.Services.BeneficiarioACS.Interface;
using HospitalAnaCosta.Services.BeneficiarioACS.DTO;
using HospitalAnaCosta.Services.BeneficiarioACS.View;
using System.Data;

namespace HospitalAnaCosta.SGS.GestaoMateriais.Impressao
{
    public class ImpBixolon
    {
        public ImpBixolon()
        {
        }

        private const int _ANTIMICROBIANOS_USO_RESTRITO = 981;
        private const int _CONTROLADO_PSICOTROPICO1 = 12;
        private const int _CONTROLADO_PSICOTROPICO2 = 912;
        private bool _imprimirEndereco = false;

        #region OBJETOS SERVIÇOS

        private CommonBeneficiarioACS _commonBnfACS;
        private CommonBeneficiarioACS CommonBnfACS
        {
            get { return _commonBnfACS != null ? _commonBnfACS : _commonBnfACS = new CommonBeneficiarioACS(null); }
        }

        // Atendimento
        private PacienteDTO dtoAtendimento;
        // private PacienteDataTable dtbAtendimento;
        private IPaciente _atendimento;
        private IPaciente Atendimento
        {
            get { return _atendimento != null ? _atendimento : _atendimento = (IPaciente)Global.Common.GetObject(typeof(IPaciente)); }
        }

        // Itens Requisição
        private IRequisicaoItens _requisicaoitens;
        private IRequisicaoItens RequisicaoItens
        {
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject(typeof(IRequisicaoItens)); }
        }
        private RequisicaoItensDataTable dtbRequisicaoItem;
        private RequisicaoItensDTO dtoRequisicaoItem;

        // Requisição
        private IRequisicao _requisicao;
        private IRequisicao Requisicao
        {
            get { return _requisicao != null ? _requisicao : _requisicao = (IRequisicao)Global.Common.GetObject(typeof(IRequisicao)); }
        }               

        // Beneficiario ACS
        private IBenefHomeCare _bnfhomecare;
        private IBenefHomeCare BnfHomeCare
        {
            get { return _bnfhomecare != null ? _bnfhomecare : _bnfhomecare = (IBenefHomeCare)CommonBnfACS.GetObject(typeof(IBenefHomeCare)); }
        }

        // Utilitario
        private IUtilitario _utilitario;
        private IUtilitario UtilitarioServico
        {
            get { return _utilitario != null ? _utilitario : _utilitario = (IUtilitario)Global.Common.GetObject(typeof(IUtilitario)); }
        }

        private IMatMedSetorConfig _matMedConfig;
        private IMatMedSetorConfig MatMedSetorConfig
        {
            get { return _matMedConfig != null ? _matMedConfig : _matMedConfig = (IMatMedSetorConfig)Global.Common.GetObject(typeof(IMatMedSetorConfig)); }
        }

        #endregion

        public void Imprimir(RequisicaoDTO dtoRequisicao, bool origemDispensacao)
        {
            if (dtoRequisicao.IdtTipoRequisicao.Value == (decimal)RequisicaoDTO.TipoRequisicao.PERSONALIZADO ||
                dtoRequisicao.IdtTipoRequisicao.Value == (decimal)RequisicaoDTO.TipoRequisicao.INTERNACAO_DOMICILIAR)
            {
                this.ImprimirReqPersonalizada(dtoRequisicao, origemDispensacao, null);
            }
            else
            {
                this.ImprimirReqAvulsaPadraoCarrinho(dtoRequisicao, origemDispensacao);
            }
        }

        private bool ImprimirEndereco(bool origemDispensacao)
        {            
            if (dtbRequisicaoItem.Rows.Count > 0 && !origemDispensacao)
            {
                //if (string.IsNullOrEmpty(dtbRequisicaoItem.Rows[0][RequisicaoDTO.FieldNames.SetorFarmacia].ToString()) &&
                if (FrmPrincipal.dtoSeguranca.IdtUnidade.Value == 244) //244 = SANTOS
                    return true;
            }
            return false;
        }

        private bool TemAntimicrobiano()
        {
            if (dtbRequisicaoItem == null) return false;
            
            System.Data.DataRow[] rowsAntimicro = dtbRequisicaoItem.Select(string.Format("{0} IN ({1})", MaterialMedicamentoDTO.FieldNames.IdtSubGrupo, _ANTIMICROBIANOS_USO_RESTRITO));
            if (rowsAntimicro.Length > 0)
                return true;
            else
                return false;
        }

        private void ImprimirReqAvulsaPadraoCarrinho(RequisicaoDTO dtoRequisicao, bool origemDispensacao)
        {
            //Obtém os Ítens da Requisição
            dtoRequisicaoItem = new RequisicaoItensDTO();
            dtoRequisicaoItem.Idt.Value = dtoRequisicao.Idt.Value;            

            if (FrmPrincipal.dtoSeguranca.IdtSetor.Value == 29 && !origemDispensacao && //Se for Pedido Padrão dispensado pelo Almoxarifado, ordenar pelo Endereço
                dtoRequisicao.IdtTipoRequisicao.Value == (decimal)RequisicaoDTO.TipoRequisicao.PADRAO)
            {
                dtbRequisicaoItem = RequisicaoItens.Sel(dtoRequisicaoItem, true, false);
            }
            else
                dtbRequisicaoItem = RequisicaoItens.Sel(dtoRequisicaoItem);

            if (dtbRequisicaoItem.Select(string.Format("{0} > 0", RequisicaoItensDTO.FieldNames.QtdSolicitada)).Length == 0) return;

            Win32PrintClass w32prn = new Win32PrintClass();
            string dsHospitalAmbulatorio;
            string dsReferencia;

            _imprimirEndereco = ImprimirEndereco(origemDispensacao);

            if (dtoRequisicao.IdtLocal.Value.ToString() == "27") //27 = AMBULATORIO
            {
                dsHospitalAmbulatorio = "Ambulatorio";
            }
            else
            {
                dsHospitalAmbulatorio = (dtoRequisicao.TpAtendimento.Value == "I" || dtoRequisicao.TpAtendimento.Value.IsNull) ? "Hospital" : "Ambulatorio";
            }

            if (dtoRequisicao.Urgencia.Value.IsNull) dtoRequisicao.Urgencia.Value = 0;
            if (dtoRequisicao.IdtTipoRequisicao.Value == (decimal)RequisicaoDTO.TipoRequisicao.ESTOQUE_LOCAL_MAT_MED && dtoRequisicao.Urgencia.Value == 0)
            {
                dsReferencia = "ESTOQUE LOCAL HAC";
            }
            else if (dtoRequisicao.IdtTipoRequisicao.Value == (decimal)RequisicaoDTO.TipoRequisicao.ESTOQUE_LOCAL_MAT_MED && dtoRequisicao.Urgencia.Value != 0)
            {
                dsReferencia = "URGENTE - ESTOQUE LOC.";
            }
            else if (dtoRequisicao.IdtTipoRequisicao.Value == (decimal)RequisicaoDTO.TipoRequisicao.CARRINHO_EMERGENCIA)
            {
                dsReferencia = "CARRO EMERG. - HAC";
            }
            else if (dtoRequisicao.IdtTipoRequisicao.Value == (decimal)RequisicaoDTO.TipoRequisicao.HIGIENIZACAO)
            {
                dsReferencia = "HAC - HIGIENIZACAO";
            }
            else if (dtoRequisicao.IdtTipoRequisicao.Value == (decimal)RequisicaoDTO.TipoRequisicao.OUTROS)
            {
                dsReferencia = "HAC - AVULSO";
            }
            else if (dtoRequisicao.IdtTipoRequisicao.Value == (decimal)RequisicaoDTO.TipoRequisicao.IMPRESSOS_MAT_EXPEDIENTE)
            {
                dsReferencia = "HAC - IMP/MAT EXP";
            }
            else
            {
                dsReferencia = (dtoRequisicao.IdtFilial.Value == (decimal)FilialMatMedDTO.Filial.HAC) ? "HOSPITAL ANA COSTA" : "PLANO DE SAUDE";
            }

            string nomeImpressora = Utilitario.ObterRegistroWindows(Utilitario.ModeloImpressoraPedidosNomeRegistroBixolon());
            if (string.IsNullOrEmpty(nomeImpressora)) nomeImpressora = "BIXOLON SRP-350";
            w32prn.SetPrinterName(nomeImpressora);

            w32prn.OpenCashdrawer(2);	// 2 pin cashdrawer

            w32prn.SetDeviceFont(7.5f, "FontA2x2", false, false);
            w32prn.PrintText(dsReferencia);

            w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
            w32prn.PrintText("w");

            if (dtoRequisicao.FlPendente.Value == (byte)RequisicaoDTO.Pendente.SIM)
            {
                w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);
                w32prn.PrintText("------------------------------------------");
                w32prn.PrintText("PEDIDO PENDENTE");
                w32prn.PrintText("------------------------------------------");
            }

            w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);
            w32prn.PrintText(Utilitario.FormatarCampo(dsHospitalAmbulatorio, 20) + "Pedido Num.");
            w32prn.PrintText(Utilitario.FormatarCampo(dtoRequisicao.DsUnidade.Value, 20) + Utilitario.FormatarCampo(dtoRequisicao.Idt.Value, 12) + Utilitario.FormatarCampo("", 0));

            w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
            w32prn.PrintText("w");

            w32prn.SetDeviceFont(7.5f, "FontB2x1", true, true);
            w32prn.PrintText(Utilitario.FormatarCampo(dtoRequisicao.DsSetor.Value, 28));

            w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
            w32prn.PrintText("w");

            w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);
            w32prn.PrintText("          Dt. Pedido: " + dtoRequisicao.DataRequisicao.Value.ToString());

            if (origemDispensacao)
            {
                w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);
                w32prn.PrintText("------------------------------------------");
                w32prn.PrintText("ITENS ENTREGUES");
            }
            w32prn.PrintText("------------------------------------------");

            w32prn.SetDeviceFont(7.5f, "FontB2x1", true, true);
            w32prn.PrintText(Utilitario.FormatarCampo("PRODUTO", 24) + Utilitario.FormatarCampo("QTD", 0));

            w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
            w32prn.PrintText("w");

            w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);

            long qtd;
            long cont = 0;
            string linha2; string linhaVia = null;
            //Imprime os ítens da requisição
            for (int indice = 0; indice < dtbRequisicaoItem.Rows.Count; ++indice)
            {
                dtoRequisicaoItem = this.dtbRequisicaoItem.TypedRow(indice);

                if (origemDispensacao)
                    qtd = (long)dtoRequisicaoItem.QtdFornecida.Value;
                else
                    qtd = (long)dtoRequisicaoItem.QtdSolicitada.Value;

                if (qtd > 0)
                {
                    cont += 1;
                    if (cont > 1)
                    {
                        w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
                        w32prn.PrintText("w");
                        w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);
                    }
                    linha2 = null;

                    w32prn.PrintText(ObterLinhaProdutoQtd(qtd, 
                                                          ref linha2,
                                                          EnderecoPedido(dtbRequisicaoItem.Rows[indice]),
                                                          ref linhaVia));

                    if (!string.IsNullOrEmpty(linha2))
                        w32prn.PrintText(linha2);
                }
            }

            #region IMPRESSÃO ITENS PENDENTES
            if (origemDispensacao)
            {
                RequisicaoDTO dtoReqItemPend = new RequisicaoDTO();
                dtoReqItemPend.Idt.Value = dtoRequisicao.Idt.Value;
                RequisicaoItensDataTable dtbReqItemPend = RequisicaoItens.SelReqItensPendentes(dtoReqItemPend);
                if (dtbReqItemPend.Rows.Count > 0)
                {
                    w32prn.PrintText("------------------------------------------");
                    w32prn.PrintText("ITENS NAO ENTREGUES");
                    w32prn.PrintText("------------------------------------------");

                    w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
                    w32prn.PrintText("w");

                    w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);

                    //Imprime os ítens que ficaram pendentes
                    for (int indice = 0; indice < dtbReqItemPend.Rows.Count; ++indice)
                    {
                        dtoRequisicaoItem = dtbReqItemPend.TypedRow(indice);

                        qtd = (long)dtoRequisicaoItem.QtdSolicitada.Value - (long)dtoRequisicaoItem.QtdFornecida.Value;

                        if (qtd > 0)
                        {
                            cont += 1;
                            if (cont > 1)
                            {
                                w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
                                w32prn.PrintText("w");
                                w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);
                            }
                            linha2 = null; linhaVia = null;

                            w32prn.PrintText(ObterLinhaProdutoQtd(qtd,
                                                                  ref linha2,
                                                                  EnderecoPedido(dtbRequisicaoItem.Rows[indice]),
                                                                  ref linhaVia));
                            if (!string.IsNullOrEmpty(linha2))
                                w32prn.PrintText(linha2);

                            if (!string.IsNullOrEmpty(linhaVia))
                                w32prn.PrintText(linhaVia);
                        }
                    }
                }
            }
            #endregion

            w32prn.PrintText("------------------------------------------");

            if (origemDispensacao &&
                (dtoRequisicao.IdtTipoRequisicao.Value == (decimal)RequisicaoDTO.TipoRequisicao.CARRINHO_EMERGENCIA ||
                 dtoRequisicao.IdtTipoRequisicao.Value == (decimal)RequisicaoDTO.TipoRequisicao.PADRAO))
            {
                w32prn.PrintText("Data/hora recebimento: __ /__ /__ ___:___ ");
                w32prn.PrintText("                                          ");
                w32prn.PrintText("       Nome recebedor: ___________________");
                w32prn.PrintText("                                          ");
                w32prn.PrintText(" Assinatura recebedor: ___________________");
                w32prn.PrintText("------------------------------------------");
            }

            w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
            w32prn.PrintText("x"); //Centralizar
            //w32prn.PrintText("r"); //Não imprimir cabeçalho

            if (Utilitario.ObterRegistroWindows(Utilitario.ModeloImpressoraPedidosNomeRegistroBixolon()).IndexOf("350III") > -1)
                w32prn.SetDeviceFont(12f, "Barcode1", false, false);
            else
                w32prn.SetDeviceFont(12f, "JAN13(EAN)", false, false);

            w32prn.PrintText(dtoRequisicao.Idt.Value.ToString().PadLeft(12, '0'));

            w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
            w32prn.PrintText("w");

            w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);
            w32prn.PrintText("S: " + dtoRequisicao.DsUsuarioRequisicao.Value);
            w32prn.PrintText("                                          ");
            w32prn.PrintText(UtilitarioServico.ObterDataHoraServidor().ToShortDateString() + " " + UtilitarioServico.ObterDataHoraServidor().ToLongTimeString() + "  Total de Itens: " + cont.ToString());
            w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
            w32prn.PrintText("w");
            w32prn.PrintText("                                          ");

            w32prn.EndDoc();
        }

        private void ImprimirReqPersonalizada(RequisicaoDTO dtoRequisicao, bool origemDispensacao, RequisicaoItensDataTable dtbReqItemPsicotropSeparado)
        {
            if (dtoRequisicao.IdtTipoRequisicao.Value != (decimal)RequisicaoDTO.TipoRequisicao.INTERNACAO_DOMICILIAR)
            {
                //Obtém Dados do Atendimento                
                dtoAtendimento = new PacienteDTO();

                dtoAtendimento.Idt.Value = dtoRequisicao.IdtAtendimento.Value;
                dtoAtendimento.TpAtendimento.Value = dtoRequisicao.TpAtendimento.Value;
                dtoAtendimento.IdtUnidade.Value = dtoRequisicao.IdtUnidade.Value;
                dtoAtendimento.IdtLocalAtendimento.Value = dtoRequisicao.IdtLocal.Value;
                dtoAtendimento.IdtSetor.Value = dtoRequisicao.IdtSetor.Value;
                                
                dtoAtendimento = Atendimento.SelChave(dtoAtendimento);

                if (dtoAtendimento == null && dtoRequisicao.TpAtendimento.Value.ToString() != "I")
                {
                    dtoAtendimento = new PacienteDTO();
                    dtoAtendimento.Idt.Value = dtoRequisicao.IdtAtendimento.Value;
                    dtoAtendimento.TpAtendimento.Value = "I";
                    dtoAtendimento.IdtUnidade.Value = dtoRequisicao.IdtUnidade.Value;
                    dtoAtendimento.IdtLocalAtendimento.Value = dtoRequisicao.IdtLocal.Value;
                    dtoAtendimento.IdtSetor.Value = dtoRequisicao.IdtSetor.Value;

                    dtoAtendimento = Atendimento.SelChave(dtoAtendimento);
                }
            }
            else
                dtoAtendimento = new PacienteDTO();

            if (dtoAtendimento == null &&
                (dtoRequisicao.IdtTipoRequisicao.Value != (decimal)RequisicaoDTO.TipoRequisicao.INTERNACAO_DOMICILIAR &&
                 dtoRequisicao.TpAtendimento.Value == "I"))
            {
                bool cancelarPorAlta = true;
                dtoRequisicaoItem = new RequisicaoItensDTO();
                dtoRequisicaoItem.Idt.Value = dtoRequisicao.Idt.Value;
                if (!RequisicaoItens.Sel(dtoRequisicaoItem).TypedRow(0).IdPrescricao.Value.IsNull)
                {
                    if (RequisicaoItens.Sel(dtoRequisicaoItem).Select(string.Format("{0} > 0", RequisicaoItensDTO.FieldNames.QtdFornecida)).Length > 0) 
                        cancelarPorAlta = false; //Não cancelar caso tenha algum antimicrobiano dispensado
                }
                if (cancelarPorAlta)
                {
                    dtoRequisicao.Status.Value = (byte)RequisicaoDTO.StatusRequisicao.CANCELADA_POR_ALTA;
                    Requisicao.Upd(dtoRequisicao);
                }
            }
            else
            {                
                bool psicotropSeparadoImpresso = false;                
                BenefHomeCareDTO dtoHomecare = new BenefHomeCareDTO();
                RequisicaoItensDataTable dtbReqItemMAV = new RequisicaoItensDataTable();                
                dtbReqItemMAV.Columns.Add("CAD_MTMD_ENDERECO_ALMOX_HAC");
                dtbReqItemMAV.Columns.Add("CAD_MTMD_ENDERECO_ALMOX_ACS");
                //Obtém os itens da requisição
                dtoRequisicaoItem = new RequisicaoItensDTO();
                dtoRequisicaoItem.Idt.Value = dtoRequisicao.Idt.Value;
                if (dtbReqItemPsicotropSeparado != null)
                {
                    dtbRequisicaoItem = dtbReqItemPsicotropSeparado;
                    psicotropSeparadoImpresso = true;
                }                
                else
                {
                    if (dtbReqItemPsicotropSeparado == null)
                    {
                        if (origemDispensacao)
                            dtbRequisicaoItem = RequisicaoItens.Sel(dtoRequisicaoItem);
                        else
                        {
                            if (dtoRequisicao.IdtSetor.Value == 2252 ||
                                (dtoRequisicao.IdtSetor.Value == 61 && dtoRequisicao.SetorFarmacia.Value.IsNull)) //Se for HomeCare ou C.Cir. ordenar pelo Endereço
                                dtbRequisicaoItem = RequisicaoItens.Sel(dtoRequisicaoItem, true, false);
                            else
                                dtbRequisicaoItem = new Generico().PedidoOrdenadoKit(dtoRequisicaoItem);
                        }

                        if (dtbRequisicaoItem.Select(string.Format("{0} > 0", RequisicaoItensDTO.FieldNames.QtdSolicitada)).Length == 0) return;

                        _imprimirEndereco = ImprimirEndereco(origemDispensacao);    
                        foreach (DataRow row in dtbRequisicaoItem.Rows)
                        {
                            if (//(row[MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia] == null || row[MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia].ToString() == "N") &&
                                    row[MaterialMedicamentoDTO.FieldNames.IdtSubGrupo] != null &&
                                    (int.Parse(row[MaterialMedicamentoDTO.FieldNames.IdtSubGrupo].ToString()) == _CONTROLADO_PSICOTROPICO1 ||
                                     int.Parse(row[MaterialMedicamentoDTO.FieldNames.IdtSubGrupo].ToString()) == _CONTROLADO_PSICOTROPICO2))
                            {
                                if (dtbReqItemPsicotropSeparado == null)
                                {
                                    dtbReqItemPsicotropSeparado = new RequisicaoItensDataTable();
                                    dtbReqItemPsicotropSeparado.Columns.Add("CAD_MTMD_ENDERECO_ALMOX_HAC");
                                    dtbReqItemPsicotropSeparado.Columns.Add("CAD_MTMD_ENDERECO_ALMOX_ACS");
                                }

                                DataRow rowAdd = dtbReqItemPsicotropSeparado.NewRow();

                                for (int count = 0; count <= rowAdd.Table.Columns.Count - 1; count++)
                                {
                                    if (rowAdd.Table.Columns[count].ColumnName != "CAD_MTMD_ENDERECO_ALMOX_HAC" &&
                                        rowAdd.Table.Columns[count].ColumnName != "CAD_MTMD_ENDERECO_ALMOX_ACS")
                                        rowAdd[count] = row[count];
                                }
                                rowAdd["CAD_MTMD_ENDERECO_ALMOX_HAC"] = row["CAD_MTMD_ENDERECO_ALMOX_HAC"];
                                rowAdd["CAD_MTMD_ENDERECO_ALMOX_ACS"] = row["CAD_MTMD_ENDERECO_ALMOX_ACS"];

                                row.Delete();
                                dtbReqItemPsicotropSeparado.Rows.Add(rowAdd);
                            }
                        }
                        dtbRequisicaoItem.AcceptChanges();
                        if (dtbReqItemPsicotropSeparado != null) dtbReqItemPsicotropSeparado.AcceptChanges();

                        if (dtbReqItemPsicotropSeparado != null &&
                            (dtbRequisicaoItem.Rows.Count == 0 || dtbReqItemPsicotropSeparado.Rows.Count == 0))
                        {
                            if (dtbReqItemPsicotropSeparado.Rows.Count == 0)
                                dtbReqItemPsicotropSeparado = null;
                            else if (dtbReqItemPsicotropSeparado.Rows.Count > 0 && dtbRequisicaoItem.Rows.Count == 0)
                            {
                                dtbRequisicaoItem = dtbReqItemPsicotropSeparado;
                                psicotropSeparadoImpresso = true;
                            }                            
                        }
                    }
                    if (dtbRequisicaoItem.Rows.Count > 0 && !psicotropSeparadoImpresso)
                    {                        
                        foreach (DataRow row in dtbRequisicaoItem.Rows)
                        {
                            if (row[MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia] != null && row[MaterialMedicamentoDTO.FieldNames.MedAltaVigilancia].ToString() == "S")
                            {
                                DataRow rowAdd = dtbReqItemMAV.NewRow();

                                for (int count = 0; count <= rowAdd.Table.Columns.Count - 1; count++)
                                {
                                    if (rowAdd.Table.Columns[count].ColumnName != "CAD_MTMD_ENDERECO_ALMOX_HAC" &&
                                        rowAdd.Table.Columns[count].ColumnName != "CAD_MTMD_ENDERECO_ALMOX_ACS")
                                        rowAdd[count] = row[count];
                                }
                                rowAdd["CAD_MTMD_ENDERECO_ALMOX_HAC"] = row["CAD_MTMD_ENDERECO_ALMOX_HAC"];
                                rowAdd["CAD_MTMD_ENDERECO_ALMOX_ACS"] = row["CAD_MTMD_ENDERECO_ALMOX_ACS"];

                                row.Delete();
                                dtbReqItemMAV.Rows.Add(rowAdd);
                            }
                        }                        
                        if (dtbReqItemMAV.Rows.Count > 0)
                        {
                            dtbRequisicaoItem.AcceptChanges();
                            dtbReqItemMAV.AcceptChanges();
                        }
                    }
                }
                
                string dsHospitalAmbulatorio = null; string dsHospitalPlanoSaude = null;

                if (dtoRequisicao.IdtTipoRequisicao.Value != (decimal)RequisicaoDTO.TipoRequisicao.INTERNACAO_DOMICILIAR)
                {
                    dsHospitalAmbulatorio = (dtoRequisicao.TpAtendimento.Value == "I") ? "Hospital" : "Ambulatorio";
                    dsHospitalPlanoSaude = (dtoRequisicao.IdtFilial.Value == (decimal)FilialMatMedDTO.Filial.HAC) ? "HOSPITAL ANA COSTA" : "PLANO DE SAUDE";
                    if (dtoRequisicao.Urgencia.Value.IsNull) dtoRequisicao.Urgencia.Value = 0;
                    if (dtoRequisicao.Urgencia.Value != 0) dsHospitalPlanoSaude = "URGENTE - HAC";
                }
                else
                {
                    dtoHomecare.CodigoHomeCare.Value = dtoRequisicao.IdtAtendimento.Value;
                    dtoHomecare = BnfHomeCare.SelChave(dtoHomecare);

                    dsHospitalPlanoSaude = "ATENDIMENTO DOMICILIAR";
                }

                string nomeImpressora = Utilitario.ObterRegistroWindows(Utilitario.ModeloImpressoraPedidosNomeRegistroBixolon());
                if (string.IsNullOrEmpty(nomeImpressora)) nomeImpressora = "BIXOLON SRP-350";
                Win32PrintClass w32prn = new Win32PrintClass();
                w32prn.SetPrinterName(nomeImpressora);

                w32prn.OpenCashdrawer(2);	// 2 pin cashdrawer

                w32prn.SetDeviceFont(7.5f, "FontA2x2", false, false);
                w32prn.PrintText(dsHospitalPlanoSaude);

                w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
                w32prn.PrintText("w");

                w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);

                if (dtoRequisicao.FlPendente.Value == (byte)RequisicaoDTO.Pendente.SIM)
                {
                    w32prn.PrintText("------------------------------------------");
                    w32prn.PrintText("PEDIDO PENDENTE");
                    if (psicotropSeparadoImpresso)
                        w32prn.PrintText("PSICOTROPICOS");                    

                    if (dtbRequisicaoItem.Rows.Count > 0)
                    {
                        if (!dtbRequisicaoItem.TypedRow(0).IdPrescricao.Value.IsNull || TemAntimicrobiano())
                            w32prn.PrintText("ANTIMICROBIANOS");
                    }

                    w32prn.PrintText("------------------------------------------");
                }
                else if (psicotropSeparadoImpresso)
                {
                    w32prn.SetDeviceFont(7.5f, "FontA2x2", false, false);
                    w32prn.PrintText("---------------------");
                    w32prn.PrintText("PSICOTROPICOS");
                    w32prn.PrintText("---------------------");
                    w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);
                }                
                else if (dtbRequisicaoItem.Rows.Count > 0)
                {
                    if (!dtbRequisicaoItem.TypedRow(0).IdPrescricao.Value.IsNull || TemAntimicrobiano())
                    {
                        w32prn.SetDeviceFont(7.5f, "FontA2x2", false, false);
                        w32prn.PrintText("---------------------");
                        w32prn.PrintText("ANTIMICROBIANOS");
                        w32prn.PrintText("---------------------");
                        w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);
                    }
                    else if (!dtbRequisicaoItem.TypedRow(0).FlItemGeladeira.Value.IsNull)
                    {
                        if ((decimal)dtbRequisicaoItem.TypedRow(0).FlItemGeladeira.Value == 1)
                        {
                            w32prn.SetDeviceFont(7.5f, "FontA2x2", false, false);
                            w32prn.PrintText("---------------------");
                            w32prn.PrintText("ITENS GELADEIRA");
                            w32prn.PrintText("---------------------");
                            w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);
                        }
                    }
                }                

                if (!dtoRequisicao.DescricaoKit.Value.IsNull)
                {
                    w32prn.SetDeviceFont(7.5f, "FontA2x2", false, false);
                    if (dtoRequisicao.FlPendente.Value.IsNull || dtoRequisicao.FlPendente.Value == (byte)RequisicaoDTO.Pendente.NAO)
                        w32prn.PrintText("---------------------");
                    w32prn.PrintText("KIT - " + dtoRequisicao.DescricaoKit.Value.ToString().ToUpper().Replace("KIT ", ""));
                    w32prn.PrintText("---------------------");
                    w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);
                }

                if (dtoRequisicao.IdtTipoRequisicao.Value != (decimal)RequisicaoDTO.TipoRequisicao.INTERNACAO_DOMICILIAR)
                {
                    if (dtoAtendimento != null)
                    {
                        string dtNasc = string.Empty;
                        if (!dtoAtendimento.DtNascimento.Value.IsNull)
                            dtNasc = DateTime.Parse(dtoAtendimento.DtNascimento.Value.ToString()).ToString("dd/MM/yy");

                        w32prn.PrintText(Utilitario.FormatarCampo(dsHospitalAmbulatorio, 18) + "Quarto Leito  Dt.Nasc.");
                        w32prn.PrintText(Utilitario.FormatarCampo(dtoRequisicao.DsUnidade.Value, 18) + Utilitario.FormatarCampo(dtoAtendimento.CdQuarto.Value, 7) + Utilitario.FormatarCampo(dtoAtendimento.CdLeito.Value, 7) + dtNasc);
                    }
                    else
                    {
                        w32prn.PrintText(Utilitario.FormatarCampo(dsHospitalAmbulatorio, 20));
                        w32prn.PrintText(Utilitario.FormatarCampo(dtoRequisicao.DsUnidade.Value, 20));
                    }

                    w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
                    w32prn.PrintText("w");

                    w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);

                    if (dtoAtendimento != null)
                    {
                        w32prn.PrintText("Atendimento  Convenio       Pedido Num.");
                        w32prn.PrintText(Utilitario.FormatarCampo(dtoAtendimento.Idt.Value, 13) + Utilitario.FormatarCampo(dtoAtendimento.CdPlano.Value, 15) + Utilitario.FormatarCampo(dtoRequisicao.Idt.Value, 0));
                    }
                    else
                    {
                        w32prn.PrintText("Pedido Num.");
                        w32prn.PrintText(Utilitario.FormatarCampo(dtoRequisicao.Idt.Value, 0));
                    }

                    w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
                    w32prn.PrintText("w");

                    if (dtoAtendimento != null)
                    {
                        bool temNomeSocial = false;
                        if (!dtoAtendimento.NmSocial.Value.IsNull)
                        {
                            if (dtoAtendimento.NmSocial.Value.ToString().Trim() != dtoAtendimento.NmPaciente.Value.ToString().Trim())
                                temNomeSocial = true;
                        }

                        if (temNomeSocial)
                        {
                            w32prn.SetDeviceFont(7.5f, "FontA1x1", true, false);
                            w32prn.PrintText("Paciente: " + dtoAtendimento.NmSocial.Value);

                            w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
                            w32prn.PrintText("w");

                            w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);
                            w32prn.PrintText("        - " + dtoAtendimento.NmPaciente.Value);
                        }
                        else
                        {
                            w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);
                            w32prn.PrintText("Paciente: " + dtoAtendimento.NmPaciente.Value);
                        }
                    }

                    w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
                    w32prn.PrintText("w");

                    w32prn.SetDeviceFont(7.5f, "FontB2x1", true, true);
                    w32prn.PrintText(Utilitario.FormatarCampo(dtoRequisicao.DsSetor.Value, 28));

                    w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
                    w32prn.PrintText("w");

                    w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);
                    w32prn.PrintText("           Dt. Pedido: " + dtoRequisicao.DataRequisicao.Value.ToString());
                }
                else
                {
                    w32prn.PrintText(Utilitario.FormatarCampo("Matricula", 11) + Utilitario.FormatarCampo("Convenio", 13) + "Pedido Num.");
                    w32prn.PrintText(Utilitario.FormatarCampo(Utilitario.FormatarMatricula(dtoHomecare.CodigoMatriculaBenef.Value, dtoHomecare.CodigoSeqMatriculaBenef.Value), 11)
                                   + Utilitario.FormatarCampo(dtoHomecare.CodigoPlano.Value, 13)
                                   + Utilitario.FormatarCampo(dtoRequisicao.Idt.Value, 0));

                    w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
                    w32prn.PrintText("w");

                    w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);
                    w32prn.PrintText("Paciente: " + dtoHomecare.NomeBeneficiario.Value);

                    w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
                    w32prn.PrintText("w");

                    w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);
                    w32prn.PrintText("Endereco");
                    w32prn.PrintText(Utilitario.FormatarCampo(Utilitario.RetornarEndereco(dtoHomecare), 0));

                    w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
                    w32prn.PrintText("w");

                    w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);
                    w32prn.PrintText("           Dt. Pedido: " + dtoRequisicao.DataAtualizacao.Value.ToString());
                }

                if (origemDispensacao)
                {
                    w32prn.PrintText("------------------------------------------");
                    w32prn.PrintText("ITENS ENTREGUES");
                }
                w32prn.PrintText("------------------------------------------");

                w32prn.SetDeviceFont(7.5f, "FontB2x1", true, true);
                w32prn.PrintText(Utilitario.FormatarCampo("PRODUTO", 24) + Utilitario.FormatarCampo("QTD", 0));

                w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
                w32prn.PrintText("w");

                w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);

                long qtd;
                long cont = 0;
                string linha2; string linhaVia;
                //Imprime os ítens da requisição
                for (int indice = 0; indice < dtbRequisicaoItem.Rows.Count; ++indice)
                {
                    dtoRequisicaoItem = this.dtbRequisicaoItem.TypedRow(indice);

                    if (origemDispensacao)
                        qtd = (long)dtoRequisicaoItem.QtdFornecida.Value;
                    else
                        qtd = (long)dtoRequisicaoItem.QtdSolicitada.Value;

                    if (qtd > 0)
                    {
                        cont += 1;
                        if (cont > 1)
                        {
                            w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
                            w32prn.PrintText("w");
                            w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);
                        }
                        linha2 = null; linhaVia = null;                        

                        w32prn.PrintText(ObterLinhaProdutoQtd(qtd, 
                                                              ref linha2,
                                                              EnderecoPedidoPersonalizado(dtoRequisicao, dtbRequisicaoItem.Rows[indice]),
                                                              ref linhaVia));
                        if (!string.IsNullOrEmpty(linha2))
                            w32prn.PrintText(linha2);

                        if (!string.IsNullOrEmpty(linhaVia))
                            w32prn.PrintText(linhaVia);
                    }
                }

                #region IMPRESSÃO MAV
                if (dtbReqItemMAV.Rows.Count > 0)
                {
                    w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
                    w32prn.PrintText("w");

                    w32prn.SetDeviceFont(7.5f, "FontB2x1", true, true);
                    w32prn.PrintText("MEDIC. ALTO RISCO");

                    w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
                    w32prn.PrintText("w");

                    w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);

                    qtd = cont = 0;
                    //Imprime os ítens da requisição
                    for (int indice = 0; indice < dtbReqItemMAV.Rows.Count; ++indice)
                    {
                        dtoRequisicaoItem = dtbReqItemMAV.TypedRow(indice);

                        if (origemDispensacao)
                            qtd = (long)dtoRequisicaoItem.QtdFornecida.Value;
                        else
                            qtd = (long)dtoRequisicaoItem.QtdSolicitada.Value;

                        if (qtd > 0)
                        {
                            cont += 1;
                            if (cont > 1)
                            {
                                w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
                                w32prn.PrintText("w");
                                w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);
                            }
                            linha2 = null; linhaVia = null;

                            w32prn.PrintText(ObterLinhaProdutoQtd(qtd, 
                                                                  ref linha2,
                                                                  EnderecoPedidoPersonalizado(dtoRequisicao, dtbReqItemMAV.Rows[indice]),
                                                                  ref linhaVia));

                            if (!string.IsNullOrEmpty(linha2))
                                w32prn.PrintText(linha2);

                            if (!string.IsNullOrEmpty(linhaVia))
                                w32prn.PrintText(linhaVia);
                        }
                    }
                }
                #endregion

                #region IMPRESSÃO ITENS PENDENTES
                if (origemDispensacao)
                {
                    RequisicaoDTO dtoReqItemPend = new RequisicaoDTO();
                    dtoReqItemPend.Idt.Value = dtoRequisicao.Idt.Value;
                    RequisicaoItensDataTable dtbReqItemPend = RequisicaoItens.SelReqItensPendentes(dtoReqItemPend);
                    if (dtbReqItemPend.Rows.Count > 0)
                    {
                        w32prn.PrintText("------------------------------------------");
                        w32prn.PrintText("ITENS NAO ENTREGUES");
                        w32prn.PrintText("------------------------------------------");

                        w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
                        w32prn.PrintText("w");

                        w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);

                        //Imprime os ítens que ficaram pendentes
                        for (int indice = 0; indice < dtbReqItemPend.Rows.Count; ++indice)
                        {
                            dtoRequisicaoItem = dtbReqItemPend.TypedRow(indice);

                            qtd = (long)dtoRequisicaoItem.QtdSolicitada.Value - (long)dtoRequisicaoItem.QtdFornecida.Value;

                            if (qtd > 0)
                            {
                                cont += 1;
                                if (cont > 1)
                                {
                                    w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
                                    w32prn.PrintText("w");
                                    w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);
                                }
                                linha2 = null; linhaVia = null;

                                w32prn.PrintText(ObterLinhaProdutoQtd(qtd,
                                                                      ref linha2,
                                                                      EnderecoPedidoPersonalizado(dtoRequisicao, dtbRequisicaoItem.Rows[indice]),
                                                                      ref linhaVia));
                                if (!string.IsNullOrEmpty(linha2))
                                    w32prn.PrintText(linha2);

                                if (!string.IsNullOrEmpty(linhaVia))
                                    w32prn.PrintText(linhaVia);
                            }
                        }
                    }
                }
                #endregion

                w32prn.PrintText("------------------------------------------");

                if (origemDispensacao)
                {
                    w32prn.PrintText("Data/hora recebimento: __ /__ /__ ___:___ ");
                    w32prn.PrintText("                                          ");
                    w32prn.PrintText("       Nome recebedor: ___________________");
                    w32prn.PrintText("                                          ");
                    w32prn.PrintText(" Assinatura recebedor: ___________________");
                    w32prn.PrintText("------------------------------------------");
                }

                w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
                //w32prn.PrintText("r"); //Não imprimir cabeçalho
                w32prn.PrintText("x"); //Centralizar
                
                if (Utilitario.ObterRegistroWindows(Utilitario.ModeloImpressoraPedidosNomeRegistroBixolon()).IndexOf("350III") > -1)
                    w32prn.SetDeviceFont(12f, "Barcode1", false, false);
                else
                    w32prn.SetDeviceFont(12f, "JAN13(EAN)", false, false);

                w32prn.PrintText(dtoRequisicao.Idt.Value.ToString().PadLeft(12, '0'));

                w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
                w32prn.PrintText("w");

                w32prn.SetDeviceFont(7.5f, "FontA1x1", false, false);
                w32prn.PrintText("S: " + dtoRequisicao.DsUsuarioRequisicao.Value);
                w32prn.PrintText("                                          ");
                w32prn.PrintText(UtilitarioServico.ObterDataHoraServidor().ToShortDateString() + " " + UtilitarioServico.ObterDataHoraServidor().ToLongTimeString() + "  Total de Itens: " + cont.ToString());
                w32prn.SetDeviceFont(7.5f, "FontControl", false, false);
                w32prn.PrintText("w");
                w32prn.PrintText("                                          ");

                w32prn.EndDoc();

                if (!psicotropSeparadoImpresso && dtbReqItemPsicotropSeparado != null && dtbReqItemPsicotropSeparado.Rows.Count > 0)
                    this.ImprimirReqPersonalizada(dtoRequisicao, origemDispensacao, dtbReqItemPsicotropSeparado);
            }
        }

        private string EnderecoPedidoPersonalizado(RequisicaoDTO dtoRequisicao, DataRow row)
        {
            string endereco = string.Empty;
            if (dtoRequisicao.IdtSetor.Value == 2252 || 
                (dtoRequisicao.IdtSetor.Value == 61 && dtoRequisicao.SetorFarmacia.Value.IsNull)) //Se for HomeCare ou C.Cir. imprimir Endereço Almox. Central
                endereco = row["CAD_MTMD_ENDERECO_ALMOX_HAC"].ToString();
            else if (!string.IsNullOrEmpty(row["CAD_MTMD_ENDERECO_ALMOX_ACS"].ToString()))
                endereco = row["CAD_MTMD_ENDERECO_ALMOX_ACS"].ToString();

            return endereco;
        }

        private string EnderecoPedido(DataRow row)
        {
            //Se não for Pedido da Farmácia, trazer do Almox. Central
            //Caso contrário, trazer endereço da Farmácia Central. ("CAD_MTMD_ENDERECO_ALMOX_ACS" = Endereço da Farmácia)
            string endereco = string.Empty;
            if (string.IsNullOrEmpty(dtbRequisicaoItem.Rows[0][RequisicaoDTO.FieldNames.SetorFarmacia].ToString()) &&
                !string.IsNullOrEmpty(row["CAD_MTMD_ENDERECO_ALMOX_HAC"].ToString()))
                endereco = row["CAD_MTMD_ENDERECO_ALMOX_HAC"].ToString();
            else if (!string.IsNullOrEmpty(dtbRequisicaoItem.Rows[0][RequisicaoDTO.FieldNames.SetorFarmacia].ToString()) &&  
                     !string.IsNullOrEmpty(row["CAD_MTMD_ENDERECO_ALMOX_ACS"].ToString()))
                endereco = row["CAD_MTMD_ENDERECO_ALMOX_ACS"].ToString();         
            
            return endereco;
        }

        private string ObterLinhaProdutoQtd(long qtd, ref string linha2, string endereco, ref string linhaVia)
        {
            if (_imprimirEndereco && !string.IsNullOrEmpty(endereco))
                endereco = endereco + " ";
            else
                endereco = string.Empty;
            string produto = endereco + dtoRequisicaoItem.DsProduto.Value;            
            string retorno;

            if (produto.Length >= 35)
                produto = Utilitario.TruncarCampo(produto, 35);            

            retorno = Utilitario.FormatarCampo(produto, 36) + Utilitario.FormatarCampo(qtd.ToString(), 5);

            if (dtoRequisicaoItem.DsProduto.Value.ToString().Length > 35)
            {
                linha2 = Utilitario.TruncarCampo(dtoRequisicaoItem.DsProduto.Value.ToString().Substring(35), 36);
                if (dtoRequisicaoItem.DsProduto.Value.ToString().Length > 71) linha2 += "..";
            }

            if (!dtoRequisicaoItem.Via.Value.IsNull)
                linhaVia = "Via: " + dtoRequisicaoItem.Via.Value;
            
            return retorno;
        }

        private string AbreviarDescricao(string descricao)
        {
            descricao = descricao.ToLower().Replace("caixa", "cx");
            descricao = descricao.ToLower().Replace("unidades", "un");
            descricao = descricao.ToLower().Replace("conjunto", "cj");
            descricao = descricao.ToLower().Replace("frasco", "fsc");
            descricao = descricao.ToLower().Replace("pacote", "pct");
            descricao = descricao.ToLower().Replace("com ", "");
            descricao = descricao.ToLower().Replace("ampola", "amp");
            descricao = descricao.ToLower().Replace("pares", "p.");
            descricao = descricao.ToLower().Replace("gramas", "gr");
            descricao = descricao.ToLower().Replace("metro", "mt");
            descricao = descricao.ToLower().Replace("litro", "lt");
            descricao = descricao.ToLower().Replace("bloco", "blc");

            return descricao.Trim();
        }
    }
}