using System;
using System.Collections.Generic;
using System.Text;
using Bematech.Comunicacao;
using Bematech.MiniImpressoras;
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
//using System.Runtime.InteropServices;

//Documentação de comandos da MiniImpressora Bematech
//http://blog.tools.sisgel.com/files/2012/04/esc-Bema.pdf
//http://www.bematech.com.br/MA/arquivos/equipamentos/Manual_do_Usuario_MP-20_MI.pdf
//http://partners.bematech.com.br/2012/05/edicao-121-diferencas-entre-comandos-escpos-e-escbema/

namespace HospitalAnaCosta.SGS.GestaoMateriais.Impressao
{
    #region classe comentada por não ter sido utilizada (referente a impressora MP-4200 TH que está utilizando driver da BIXOLON SRP-350 pra imprimir na porta USB)
    //class MP2032
    //{        
    //    [DllImport("MP2032.dll")]
    //    public static extern int ConfiguraModeloImpressora(int iModelo);

    //    [DllImport("MP2032.dll")]
    //    public static extern int IniciaPorta(string porta);

    //    [DllImport("MP2032.dll")]
    //    public static extern int FechaPorta();

    //    [DllImport("MP2032.dll")]
    //    public static extern int ComandoTX(string comando, int iComando);

    //    [DllImport("MP2032.dll")]
    //    public static extern int FormataTX(string texto, int tipoLetra, int italico, int sublinhado, int expandido, int enfatizado);

    //    [DllImport("MP2032.dll")]
    //    public static extern int BematechTX(string texto);

    //    [DllImport("MP2032.dll")]
    //    public static extern int ConfiguraCodigoBarras(int altura, int largura, int posicaoCaracteres, int fonte, int margem);

    //    [DllImport("MP2032.dll")]
    //    public static extern int ImprimeCodigoBarrasEAN8(string cCodigo);

    //    [DllImport("MP2032.dll")]
    //    public static extern int ImprimeCodigoBarrasEAN13(string cCodigo);

    //    [DllImport("MP2032.dll")]
    //    public static extern int AcionaGuilhotina(int guilhotina);
    //}
    #endregion    

    public class ImpBematech
    {        
        public ImpBematech()
        {
        }

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
            get { return _requisicaoitens != null ? _requisicaoitens : _requisicaoitens = (IRequisicaoItens)Global.Common.GetObject( typeof(IRequisicaoItens)); }
        }
        private RequisicaoItensDataTable dtbRequisicaoItem;
        private RequisicaoItensDTO dtoRequisicaoItem;

        // Requisição
        private IRequisicao _requisicao;
        private IRequisicao Requisicao
        {
            get { return _requisicao != null ? _requisicao : _requisicao = (IRequisicao)Global.Common.GetObject( typeof(IRequisicao)); }
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
                this.ImprimirReqPersonalizada(dtoRequisicao, origemDispensacao);
            }
            else
            {
                this.ImprimirReqAvulsaPadraoCarrinho(dtoRequisicao, origemDispensacao);
            }
        }

        private void ImprimirReqAvulsaPadraoCarrinho(RequisicaoDTO dtoRequisicao, bool origemDispensacao)
        {
            ImpressoraNaoFiscal Linha = new ImpressoraNaoFiscal(Bematech.ModeloImpressoraNaoFiscal.MP2100TH, Utilitario.PortaComunicacao.Paralela1);
            //Bematech.CodigosDeBarras.EAN13 CdBar = new Bematech.CodigosDeBarras.EAN13();            
            string dsHospitalAmbulatorio;
            string dsReferencia;
            string abreNegrito = string.Empty;
            string fechaNegrito = string.Empty;

            //Obtém os Ítens da Requisição
            dtoRequisicaoItem = new RequisicaoItensDTO();

            dtoRequisicaoItem.Idt.Value = dtoRequisicao.Idt.Value;

            dtbRequisicaoItem = RequisicaoItens.Sel(dtoRequisicaoItem);

            if (dtoRequisicao.IdtLocal.Value.ToString() == "27") //27 = AMBULATORIO
            {
                dsHospitalAmbulatorio = "Ambulatório";
            }
            else
            {
                dsHospitalAmbulatorio = (dtoRequisicao.TpAtendimento.Value == "I" || dtoRequisicao.TpAtendimento.Value.IsNull) ? "Hospital" : "Ambulatório";
            }            

            if (dtoRequisicao.IdtTipoRequisicao.Value == (decimal)RequisicaoDTO.TipoRequisicao.CARRINHO_EMERGENCIA)
            {
                //MatMedSetorConfigDTO dtoCfg = new MatMedSetorConfigDTO();

                //dtoCfg.IdtUnidade.Value = dtoRequisicao.IdtUnidade.Value;
                //dtoCfg.IdtLocal.Value = dtoRequisicao.IdtLocal.Value;
                //dtoCfg.Idtsetor.Value = dtoRequisicao.IdtSetor.Value;

                //dtoCfg = MatMedSetorConfig.SetorCfg(dtoCfg);

                //if (dtoCfg.EstoqueUnificadoHAC.Value.IsNull) dtoCfg.EstoqueUnificadoHAC.Value = 0;
                //if (dtoCfg.EstoqueUnificadoHAC.Value == 1)                
                //    dsReferencia = "ESTOQUE ÚNICO HAC";
                //else
                //    dsReferencia = "CARRO EMERG. - HAC";

                dsReferencia = "CARRO EMERG. - HAC";
            }
            else if (dtoRequisicao.IdtTipoRequisicao.Value == (decimal)RequisicaoDTO.TipoRequisicao.HIGIENIZACAO)
            {
                dsReferencia = "HAC - HIGIENIZAÇÃO";
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
                dsReferencia = (dtoRequisicao.IdtFilial.Value == (decimal)FilialMatMedDTO.Filial.HAC) ? "HOSPITAL ANA COSTA" : "PLANO DE SAÚDE";
            }

            Linha.Imprimir(Utilitario.chr(14) + "   " + dsReferencia + "\n\r\n\r" + Utilitario.chr(20));

            if (dtoRequisicao.FlPendente.Value == (byte)RequisicaoDTO.Pendente.SIM)
            {
                Linha.Imprimir("-----------------------------------------------\n\r");
                Linha.Imprimir(Utilitario.chr(14) + "PEDIDO PENDENTE\n\r" + Utilitario.chr(20));
                Linha.Imprimir("-----------------------------------------------\n\r");
            }

            #region DESCRIÇÃO COMANDOS
            // chr(27) + chr(97) + "1": Centraliza Linha
            // chr(27) + chr(97) + "0": Alinha a esquerda
            #endregion

            Linha.Imprimir(Utilitario.chr(27) + Utilitario.chr(97) + "0" + Utilitario.FormatarCampo(dsHospitalAmbulatorio, 24) + "Pedido        C.C.\n\r");
            Linha.Imprimir(Utilitario.chr(27) + Utilitario.chr(97) + "0" + Utilitario.FormatarCampo(dtoRequisicao.DsUnidade.Value, 24) + Utilitario.FormatarCampo(dtoRequisicao.Idt.Value, 14) + Utilitario.FormatarCampo("", 0) + "\n\r");
            Linha.Imprimir("Setor                   Dt. Pedido       \n\r");
            Linha.Imprimir(Utilitario.chr(27) + Utilitario.chr(97) + "0" + Utilitario.FormatarCampo(dtoRequisicao.DsSetor.Value, 24) + Utilitario.FormatarCampo(dtoRequisicao.DataRequisicao.Value.ToString(), 0) + "\n\r");
            if (origemDispensacao)
            {
                Linha.Imprimir("-----------------------------------------------\n\r");
                Linha.Imprimir(Utilitario.chr(14) + "ITENS ENTREGUES\n\r" + Utilitario.chr(20));
            }            
            Linha.Imprimir("-----------------------------------------------\n\r");

            long qtd;
            long cont = 0;
            string linhaUniVenda;
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
                    if (abreNegrito == string.Empty)
                    {
                        abreNegrito = Utilitario.chr(27) + Utilitario.chr(69);
                        fechaNegrito = Utilitario.chr(27) + Utilitario.chr(70);
                    }
                    else
                    {
                        abreNegrito = string.Empty;
                        fechaNegrito = string.Empty;
                    }                    
                    linhaUniVenda = null;
                    //Linha.Imprimir(Utilitario.chr(27) + Utilitario.chr(97) + "0" + abreNegrito + Utilitario.FormatarCampo(Utilitario.TruncarCampo(dtoRequisicaoItem.DsProduto.Value, 33), 34) + Utilitario.FormatarCampo(qtd.ToString(), 5) + Utilitario.FormatarCampo(dtoRequisicaoItem.DsUnidadeVenda.Value, 0) + fechaNegrito + "\n\r");
                    Linha.Imprimir(Utilitario.chr(27) + Utilitario.chr(97) + "0" + abreNegrito + ObterLinhaProdutoQtd(qtd, ref linhaUniVenda) + fechaNegrito + "\n\r");

                    if (!string.IsNullOrEmpty(linhaUniVenda))
                        Linha.Imprimir(Utilitario.chr(27) + Utilitario.chr(97) + "0" + abreNegrito + linhaUniVenda + fechaNegrito + "\n\r");
                }                
            }

            // salta uma linha
            Linha.Imprimir(Utilitario.chr(10));

            #region Define se imprime cabeçalho do código de barras
            // 0 = não imprime
            // 1 = No topo do código de barras (padrão)
            // 2 = Embaixo do código de barras
            // 3 = No topo e embaixo do código de barras
            Linha.Imprimir(Utilitario.chr(29) + Utilitario.chr(72) + "0");
            #endregion

            // define altura do código de barras PADRAO 162
            Linha.Imprimir(Utilitario.chr(29) + Utilitario.chr(104) + "50");            
            // define código barras EAN13   
            Linha.Imprimir(Utilitario.chr(29) + Utilitario.chr(107) + Utilitario.chr(68) + Utilitario.chr(12) + dtoRequisicao.Idt.Value.ToString().PadLeft(12, '0') + Utilitario.chr(0));
            // salta uma linha
            Linha.Imprimir(Utilitario.chr(10));
            Linha.Imprimir("S - " + dtoRequisicao.DsUsuarioRequisicao.Value + "\n\r");
            Linha.Imprimir(Utilitario.chr(10));
            Linha.Imprimir(UtilitarioServico.ObterDataHoraServidor().ToShortDateString() + " " + UtilitarioServico.ObterDataHoraServidor().ToLongTimeString() + " - Total de Itens: " + cont.ToString() + "\n\r");
            // ejeta uma página            
            //Linha.Imprimir(chr(12));
            Linha.Imprimir(Utilitario.chr(10));
            Linha.CortarPapel(true);
        }

        private void ImprimirReqPersonalizada(RequisicaoDTO dtoRequisicao, bool origemDispensacao)
        {
            ImpressoraNaoFiscal Linha = new ImpressoraNaoFiscal(Bematech.ModeloImpressoraNaoFiscal.MP2100TH, Utilitario.PortaComunicacao.Paralela1);
            //Bematech.CodigosDeBarras.EAN13 CdBar = new Bematech.CodigosDeBarras.EAN13();            
            string dsHospitalAmbulatorio = null;
            string dsHospitalPlanoSaude = null;
            string abreNegrito = string.Empty;
            string fechaNegrito = string.Empty;
                        
            //Obtém Dados do Atendimento
            // dtoAtendimento = new PacienteDTO();

            if (dtoRequisicao.IdtTipoRequisicao.Value != (decimal)RequisicaoDTO.TipoRequisicao.INTERNACAO_DOMICILIAR)
            {
                //Obtém Dados do Atendimento
                // dtoAtendimento = new PacienteDTO();
                dtoAtendimento = new  PacienteDTO();

                dtoAtendimento.Idt.Value = dtoRequisicao.IdtAtendimento.Value;
                dtoAtendimento.TpAtendimento.Value = dtoRequisicao.TpAtendimento.Value;
                dtoAtendimento.IdtUnidade.Value = dtoRequisicao.IdtUnidade.Value;
                dtoAtendimento.IdtLocalAtendimento.Value = dtoRequisicao.IdtLocal.Value;
                dtoAtendimento.IdtSetor.Value = dtoRequisicao.IdtSetor.Value;

                // dtbAtendimento = this.Atendimento.SelChave(dtoAtendimento);
                dtoAtendimento = Atendimento.SelChave(dtoAtendimento);

            }
            else
            {
                // dtbAtendimento = new PacienteDataTable();
                dtoAtendimento = new PacienteDTO();
            }

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
                BenefHomeCareDTO dtoHomecare = new BenefHomeCareDTO();
                //Obtém os itens da requisição
                dtoRequisicaoItem = new RequisicaoItensDTO();

                dtoRequisicaoItem.Idt.Value = dtoRequisicao.Idt.Value;

                if (origemDispensacao)
                    dtbRequisicaoItem = RequisicaoItens.Sel(dtoRequisicaoItem);
                else
                    dtbRequisicaoItem = new Generico().PedidoOrdenadoKit(dtoRequisicaoItem);

                if (dtoRequisicao.IdtTipoRequisicao.Value != (decimal)RequisicaoDTO.TipoRequisicao.INTERNACAO_DOMICILIAR)
                {
                    // dtoAtendimento = dtbAtendimento.TypedRow(0);

                    dsHospitalAmbulatorio = (dtoRequisicao.TpAtendimento.Value == "I") ? "Hospital" : "Ambulatório";
                    dsHospitalPlanoSaude = (dtoRequisicao.IdtFilial.Value == (decimal)FilialMatMedDTO.Filial.HAC) ? "HOSPITAL ANA COSTA" : "PLANO DE SAÚDE";
                }
                else
                {
                    dtoHomecare.CodigoHomeCare.Value = dtoRequisicao.IdtAtendimento.Value;
                    dtoHomecare = BnfHomeCare.SelChave(dtoHomecare);

                    dsHospitalPlanoSaude = "INTERNAÇÃO DOMICILIAR";
                }

                Linha.Imprimir(Utilitario.chr(14) + "  " + dsHospitalPlanoSaude + "\n\r\n\r" + Utilitario.chr(20));

                if (dtoRequisicao.FlPendente.Value == (byte)RequisicaoDTO.Pendente.SIM)
                {
                    Linha.Imprimir("-----------------------------------------------\n\r");
                    Linha.Imprimir(Utilitario.chr(14) + "PEDIDO PENDENTE\n\r" + Utilitario.chr(20));
                    Linha.Imprimir("-----------------------------------------------\n\r");
                }

                #region DESCRIÇÃO COMANDOS
                // chr(27) + chr(97) + "1": Centraliza Linha
                // chr(27) + chr(97) + "0": Alinha a esquerda
                #endregion

                if (dtoRequisicao.IdtTipoRequisicao.Value != (decimal)RequisicaoDTO.TipoRequisicao.INTERNACAO_DOMICILIAR)
                {
                    Linha.Imprimir(Utilitario.chr(27) + Utilitario.chr(97) + "0" + Utilitario.FormatarCampo(dsHospitalAmbulatorio, 16) + "Quarto     Leito      Pedido\n\r");
                    Linha.Imprimir(Utilitario.chr(27) + Utilitario.chr(97) + "0" + Utilitario.FormatarCampo(dtoRequisicao.DsUnidade.Value, 16) + Utilitario.FormatarCampo(dtoAtendimento.CdQuarto.Value, 11) + Utilitario.FormatarCampo(dtoAtendimento.CdLeito.Value, 11) + Utilitario.FormatarCampo(dtoRequisicao.Idt.Value, 0) + "\n\r");

                    string dtNasc = string.Empty;
                    if (!dtoAtendimento.DtNascimento.Value.IsNull)
                        dtNasc = DateTime.Parse(dtoAtendimento.DtNascimento.Value.ToString()).ToString("dd/MM/yy");

                    Linha.Imprimir(Utilitario.chr(27) + Utilitario.chr(97) + "0" + "Internação      Dt.Nasc.   Convênio   C.C.   \n\r");
                    Linha.Imprimir(Utilitario.chr(27) + Utilitario.chr(97) + "0" + Utilitario.FormatarCampo(dtoAtendimento.Idt.Value, 16) + Utilitario.FormatarCampo(dtNasc, 11) + Utilitario.FormatarCampo(dtoAtendimento.CdPlano.Value, 11) + Utilitario.FormatarCampo("", 0) + "\n\r");
                    Linha.Imprimir(Utilitario.chr(27) + Utilitario.chr(97) + "0" + "Setor\n\r");
                    Linha.Imprimir(Utilitario.chr(27) + Utilitario.chr(97) + "0" + Utilitario.FormatarCampo(dtoRequisicao.DsSetor.Value, 0) + "\n\r");
                    Linha.Imprimir("Paciente                      Dt. Pedido       \n\r");
                    Linha.Imprimir(Utilitario.chr(27) + Utilitario.chr(97) + "0" + Utilitario.FormatarCampo(dtoAtendimento.NmPaciente.Value, 30) + Utilitario.FormatarCampo(dtoRequisicao.DataRequisicao.Value.ToString(), 0) + "\n\r");
                }
                else
                {
                    Linha.Imprimir(Utilitario.chr(27) + Utilitario.chr(97) + "0" + Utilitario.FormatarCampo("Pedido N° " + dtoRequisicao.Idt.Value, 0) + "\n\r");
                    Linha.Imprimir(Utilitario.chr(27) + Utilitario.chr(97) + "0" + "Matrícula      Convênio      \n\r");
                    Linha.Imprimir(Utilitario.chr(27) + Utilitario.chr(97) + "0" + Utilitario.FormatarCampo(Utilitario.FormatarMatricula(dtoHomecare.CodigoMatriculaBenef.Value, dtoHomecare.CodigoSeqMatriculaBenef.Value), 15) + Utilitario.FormatarCampo(dtoHomecare.CodigoPlano.Value, 0) + "\n\r");
                    Linha.Imprimir(Utilitario.chr(27) + Utilitario.chr(97) + "0" + "Endereço\n\r");
                    Linha.Imprimir(Utilitario.chr(27) + Utilitario.chr(97) + "0" + Utilitario.FormatarCampo(Utilitario.RetornarEndereco(dtoHomecare), 0) + "\n\r");
                    Linha.Imprimir("Paciente                      Dt. Pedido       \n\r");
                    Linha.Imprimir(Utilitario.chr(27) + Utilitario.chr(97) + "0" + Utilitario.FormatarCampo(dtoHomecare.NomeBeneficiario.Value, 30) + Utilitario.FormatarCampo(dtoRequisicao.DataAtualizacao.Value.ToString(), 0) + "\n\r");
                }
                
                if (origemDispensacao)
                {
                    Linha.Imprimir("-----------------------------------------------\n\r");
                    Linha.Imprimir(Utilitario.chr(14) + "ITENS ENTREGUES\n\r" + Utilitario.chr(20));
                }
                Linha.Imprimir("-----------------------------------------------\n\r");

                long qtd;
                long cont = 0;
                string linhaUniVenda;
                //Imprime os ítens da requisição
                for (int indice = 0; indice < dtbRequisicaoItem.Rows.Count; ++indice)
                {
                    dtoRequisicaoItem = this.dtbRequisicaoItem.TypedRow(indice);

                    if (origemDispensacao)
                    {
                        qtd = (long)dtoRequisicaoItem.QtdFornecida.Value;
                    }
                    else
                    {
                        qtd = (long)dtoRequisicaoItem.QtdSolicitada.Value;
                    }

                    if (qtd > 0)
                    {
                        cont += 1;
                        if (abreNegrito == string.Empty)
                        {
                            abreNegrito = Utilitario.chr(27) + Utilitario.chr(69);
                            fechaNegrito = Utilitario.chr(27) + Utilitario.chr(70);
                        }
                        else
                        {
                            abreNegrito = string.Empty;
                            fechaNegrito = string.Empty;
                        }
                        linhaUniVenda = null;
                        //Linha.Imprimir(Utilitario.chr(27) + Utilitario.chr(97) + "0" + abreNegrito + Utilitario.FormatarCampo(Utilitario.TruncarCampo(dtoRequisicaoItem.DsProduto.Value, 42), 43) + Utilitario.FormatarCampo(qtd.ToString(), 0).PadLeft(3, ' ') + fechaNegrito + "\n\r");
                        Linha.Imprimir(Utilitario.chr(27) + Utilitario.chr(97) + "0" + abreNegrito + ObterLinhaProdutoQtd(qtd, ref linhaUniVenda) + fechaNegrito + "\n\r");

                        if (!string.IsNullOrEmpty(linhaUniVenda))
                            Linha.Imprimir(Utilitario.chr(27) + Utilitario.chr(97) + "0" + abreNegrito + linhaUniVenda + fechaNegrito + "\n\r");
                    }
                }

                // salta uma linha
                Linha.Imprimir(Utilitario.chr(10));

                #region Define se imprime cabeçalho do código de barras
                // 0 = não imprime
                // 1 = No topo do código de barras (padrão)
                // 2 = Embaixo do código de barras
                // 3 = No topo e embaixo do código de barras
                Linha.Imprimir(Utilitario.chr(29) + Utilitario.chr(72) + "0");
                #endregion

                // define altura do código de barras PADRAO 162
                Linha.Imprimir(Utilitario.chr(29) + Utilitario.chr(104) + "50");
                // define código barras EAN13   
                Linha.Imprimir(Utilitario.chr(29) + Utilitario.chr(107) + Utilitario.chr(68) + Utilitario.chr(12) + dtoRequisicao.Idt.Value.ToString().PadLeft(12, '0') + Utilitario.chr(0));
                // salta uma linha
                Linha.Imprimir(Utilitario.chr(10));
                Linha.Imprimir("S - " + dtoRequisicao.DsUsuarioRequisicao.Value + "\n\r");
                Linha.Imprimir(Utilitario.chr(10));
                Linha.Imprimir(UtilitarioServico.ObterDataHoraServidor().ToShortDateString() + " " + UtilitarioServico.ObterDataHoraServidor().ToLongTimeString() + " - Total de Itens: " + cont.ToString() + "\n\r");
                // ejeta uma página
                //Linha.Imprimir(chr(12));            
                Linha.Imprimir(Utilitario.chr(10));
                Linha.CortarPapel(true);
            }
        }

        private string ObterLinhaProdutoQtd(long qtd, ref string linha2)
        {
            string produto = dtoRequisicaoItem.DsProduto.Value;
            string retorno;

            if (produto.Length >= 42)
                produto = Utilitario.TruncarCampo(produto, 42);

            retorno = Utilitario.FormatarCampo(produto, 43) + Utilitario.FormatarCampo(qtd.ToString(), 4);

            if (dtoRequisicaoItem.DsProduto.Value.ToString().Length > 42)
            {
                linha2 = Utilitario.TruncarCampo(dtoRequisicaoItem.DsProduto.Value.ToString().Substring(42), 43);
                if (dtoRequisicaoItem.DsProduto.Value.ToString().Length > 83) linha2 += "..";
            }

            return retorno;
        }
    }
}