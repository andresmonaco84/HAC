using System.Data;
using System.Data.Common;
using HospitalAnaCosta.Services.BeneficiarioACS.DTO;
using System.Text;
using System;

namespace HospitalAnaCosta.Services.BeneficiarioACS.Model
{
    public partial class BeneficiarioACS : Entity
    {
        /// <summary>
        /// Listar todos os registros
        /// </summary>
        public BeneficiarioACSDataTable Listar(BeneficiarioACSDTO dto)
        {
            return Listar(dto, null, false, false);
        }

		/// <summary>
        /// Listar todos os registros
        /// Parametro situacao = "I", "A" ou NULL.
        /// </summary>
        public BeneficiarioACSDataTable Listar(BeneficiarioACSDTO dto, string situacao, bool incluirHomeCare, bool existeHomeCare)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

			//Parametro pCODCON
			param.Add(Connection.CreateParameter("pCODCON", dto.CodigoEmpresa.DBValue, ParameterDirection.Input, dto.CodigoEmpresa.DbType));

			//Parametro pCODEST
			param.Add(Connection.CreateParameter("pCODEST", dto.CodigoLoja.DBValue, ParameterDirection.Input, dto.CodigoLoja.DbType));

			//Parametro pCODBEN
			param.Add(Connection.CreateParameter("pCODBEN", dto.CodigoMatricula.DBValue, ParameterDirection.Input, dto.CodigoMatricula.DbType));

			//Parametro pCODSEQBEN
			param.Add(Connection.CreateParameter("pCODSEQBEN", dto.CodigoSeqMatricula.DBValue, ParameterDirection.Input, dto.CodigoSeqMatricula.DbType));

			//Parametro pNOMBEN
			param.Add(Connection.CreateParameter("pNOMBEN", dto.NomeBeneficiario.DBValue, ParameterDirection.Input, dto.NomeBeneficiario.DbType));

			//Parametro pCODPADATEBEN
			param.Add(Connection.CreateParameter("pCODPADATEBEN", dto.CdPadraoAtendimentoBeneficiario.DBValue, ParameterDirection.Input, dto.CdPadraoAtendimentoBeneficiario.DbType));

			//Parametro pCODPADCOBBEN
			param.Add(Connection.CreateParameter("pCODPADCOBBEN", dto.CdPadraoCobrancaBeneficiario.DBValue, ParameterDirection.Input, dto.CdPadraoCobrancaBeneficiario.DbType));

			//Parametro pCODINDBEN
			param.Add(Connection.CreateParameter("pCODINDBEN", dto.IndicacaoTitular.DBValue, ParameterDirection.Input, dto.IndicacaoTitular.DbType));

			//Parametro pSEXBEN
			param.Add(Connection.CreateParameter("pSEXBEN", dto.SexoBeneficiario.DBValue, ParameterDirection.Input, dto.SexoBeneficiario.DbType));

			//Parametro pCODGRAPAR
			param.Add(Connection.CreateParameter("pCODGRAPAR", dto.CdGrauParentesco.DBValue, ParameterDirection.Input, dto.CdGrauParentesco.DbType));

			//Parametro pESTCIVBEN
			param.Add(Connection.CreateParameter("pESTCIVBEN", dto.CdEstadoCivilBeneficiario.DBValue, ParameterDirection.Input, dto.CdEstadoCivilBeneficiario.DbType));

			//Parametro pDATNASBEN
			param.Add(Connection.CreateParameter("pDATNASBEN", dto.DtNascimentoBeneficiario.DBValue, ParameterDirection.Input, dto.DtNascimentoBeneficiario.DbType));

			//Parametro pDATINGCONBEN
			param.Add(Connection.CreateParameter("pDATINGCONBEN", dto.DtIngressoBeneficiario.DBValue, ParameterDirection.Input, dto.DtIngressoBeneficiario.DbType));

			//Parametro pDATADMEMP
			param.Add(Connection.CreateParameter("pDATADMEMP", dto.DtAdmissaoEmpresaBeneficiario.DBValue, ParameterDirection.Input, dto.DtAdmissaoEmpresaBeneficiario.DbType));

			//Parametro pDATSAICONBEN
			param.Add(Connection.CreateParameter("pDATSAICONBEN", dto.DtSaidaBeneficiario.DBValue, ParameterDirection.Input, dto.DtSaidaBeneficiario.DbType));

			//Parametro pOCUEMPBEN
			param.Add(Connection.CreateParameter("pOCUEMPBEN", dto.CdOcupacaoBeneficiario.DBValue, ParameterDirection.Input, dto.CdOcupacaoBeneficiario.DbType));

			//Parametro pCARPROBEN
			param.Add(Connection.CreateParameter("pCARPROBEN", dto.CdCargoBeneficiario.DBValue, ParameterDirection.Input, dto.CdCargoBeneficiario.DbType));

			//Parametro pCODSITBEN
			param.Add(Connection.CreateParameter("pCODSITBEN", dto.CdSituacaoBeneficiario.DBValue, ParameterDirection.Input, dto.CdSituacaoBeneficiario.DbType));

			//Parametro pDATLIMBEN
			param.Add(Connection.CreateParameter("pDATLIMBEN", dto.DtLimiteBeneficiario.DBValue, ParameterDirection.Input, dto.DtLimiteBeneficiario.DbType));

			//Parametro pDATSITBEN
			param.Add(Connection.CreateParameter("pDATSITBEN", dto.DtSituacaoBeneficiario.DBValue, ParameterDirection.Input, dto.DtSituacaoBeneficiario.DbType));

			//Parametro pCPFBEN
			param.Add(Connection.CreateParameter("pCPFBEN", dto.CdCpfBeneficiario.DBValue, ParameterDirection.Input, dto.CdCpfBeneficiario.DbType));

			//Parametro pRGBEN
			param.Add(Connection.CreateParameter("pRGBEN", dto.CdRgBeneficiario.DBValue, ParameterDirection.Input, dto.CdRgBeneficiario.DbType));

			//Parametro pCODACO
			param.Add(Connection.CreateParameter("pCODACO", dto.CdAcordoBeneficiario.DBValue, ParameterDirection.Input, dto.CdAcordoBeneficiario.DbType));

			//Parametro pCODPLA
			param.Add(Connection.CreateParameter("pCODPLA", dto.CdPlanoBeneficiario.DBValue, ParameterDirection.Input, dto.CdPlanoBeneficiario.DbType));

			//Parametro pVALCOB
			param.Add(Connection.CreateParameter("pVALCOB", dto.VlCobrancaBeneficiario.DBValue, ParameterDirection.Input, dto.VlCobrancaBeneficiario.DbType));

			//Parametro pCODTIPPAD
			param.Add(Connection.CreateParameter("pCODTIPPAD", dto.CodTipoPad.DBValue, ParameterDirection.Input, dto.CodTipoPad.DbType));

			//Parametro pDATEMIEXC
			param.Add(Connection.CreateParameter("pDATEMIEXC", dto.DataMIEXC.DBValue, ParameterDirection.Input, dto.DataMIEXC.DbType));

			//Parametro pSITATI
			param.Add(Connection.CreateParameter("pSITATI", dto.CdSituacaoABeneficiario.DBValue, ParameterDirection.Input, dto.CdSituacaoABeneficiario.DbType));

			//Parametro pCODTIPCARBEN
			param.Add(Connection.CreateParameter("pCODTIPCARBEN", dto.CdCarenciaBeneficiario.DBValue, ParameterDirection.Input, dto.CdCarenciaBeneficiario.DbType));

			//Parametro pINDPAG
			param.Add(Connection.CreateParameter("pINDPAG", dto.IndPag.DBValue, ParameterDirection.Input, dto.IndPag.DbType));

			//Parametro pDT_ATU_INDPAG
			param.Add(Connection.CreateParameter("pDT_ATU_INDPAG", dto.DtAtuIndPag.DBValue, ParameterDirection.Input, dto.DtAtuIndPag.DbType));

			//Parametro pIND_NEGOCIACAO
			param.Add(Connection.CreateParameter("pIND_NEGOCIACAO", dto.IndNegociacao.DBValue, ParameterDirection.Input, dto.IndNegociacao.DbType));

			//Parametro pDATFATOD
			param.Add(Connection.CreateParameter("pDATFATOD", dto.DataTod.DBValue, ParameterDirection.Input, dto.DataTod.DbType));

			//Parametro pIDADEBEN
			param.Add(Connection.CreateParameter("pIDADEBEN", dto.IdadeBen.DBValue, ParameterDirection.Input, dto.IdadeBen.DbType));

			//Parametro pMAEBEN
			param.Add(Connection.CreateParameter("pMAEBEN", dto.NmMaeBeneficiario.DBValue, ParameterDirection.Input, dto.NmMaeBeneficiario.DbType));

			//Parametro pCANC_ANS
			param.Add(Connection.CreateParameter("pCANC_ANS", dto.IdCancelamentoAns.DBValue, ParameterDirection.Input, dto.IdCancelamentoAns.DbType));

			//Parametro pID_AUTORIZACAO_ANS
			param.Add(Connection.CreateParameter("pID_AUTORIZACAO_ANS", dto.IdAutorizacaoANS.DBValue, ParameterDirection.Input, dto.IdAutorizacaoANS.DbType));

			//Parametro pVLPERC
			param.Add(Connection.CreateParameter("pVLPERC", dto.VlPerc.DBValue, ParameterDirection.Input, dto.VlPerc.DbType));

			//Parametro pCODPRO
			param.Add(Connection.CreateParameter("pCODPRO", dto.CdProfissionalBeneficiario.DBValue, ParameterDirection.Input, dto.CdProfissionalBeneficiario.DbType));

			//Parametro pDATALTBEN
			param.Add(Connection.CreateParameter("pDATALTBEN", dto.DtAlteracaoBeneficiario.DBValue, ParameterDirection.Input, dto.DtAlteracaoBeneficiario.DbType));

			//Parametro pCD_EMPRESA
			param.Add(Connection.CreateParameter("pCD_EMPRESA", dto.CdNumericoEmpresa.DBValue, ParameterDirection.Input, dto.CdNumericoEmpresa.DbType));

			//Parametro pID_COPART_EXAME
			param.Add(Connection.CreateParameter("pID_COPART_EXAME", dto.IdCopartExameBeneficiario.DBValue, ParameterDirection.Input, dto.IdCopartExameBeneficiario.DbType));

			//Parametro pID_COPART_CONSULTA
			param.Add(Connection.CreateParameter("pID_COPART_CONSULTA", dto.IdCopartConsultaBeneficiario.DBValue, ParameterDirection.Input, dto.IdCopartConsultaBeneficiario.DbType));

			//Parametro pID_CRONICO
			param.Add(Connection.CreateParameter("pID_CRONICO", dto.IdCronicoBeneficiario.DBValue, ParameterDirection.Input, dto.IdCronicoBeneficiario.DbType));

			//Parametro pCO_PART
			param.Add(Connection.CreateParameter("pCO_PART", dto.IdCopartBeneficiario.DBValue, ParameterDirection.Input, dto.IdCopartBeneficiario.DbType));

			//Parametro pID_EMISSAO_CARTEIRINHA
			param.Add(Connection.CreateParameter("pID_EMISSAO_CARTEIRINHA", dto.IdCredencialBeneficiario.DBValue, ParameterDirection.Input, dto.IdCredencialBeneficiario.DbType));

			//Parametro pVL_COBRANCA_ATUAL
			param.Add(Connection.CreateParameter("pVL_COBRANCA_ATUAL", dto.VlCobrancaAtual.DBValue, ParameterDirection.Input, dto.VlCobrancaAtual.DbType));

			//Parametro pDT_COBRANCA_ATUAL
			param.Add(Connection.CreateParameter("pDT_COBRANCA_ATUAL", dto.DataCobrancaAtual.DBValue, ParameterDirection.Input, dto.DataCobrancaAtual.DbType));

			//Parametro pDT_REF_COBRANCA_ATUAL
			param.Add(Connection.CreateParameter("pDT_REF_COBRANCA_ATUAL", dto.DataRefCobrancaAtual.DBValue, ParameterDirection.Input, dto.DataRefCobrancaAtual.DbType));

			//Parametro pDT_EMISSAO_CARTEIRINHA
			param.Add(Connection.CreateParameter("pDT_EMISSAO_CARTEIRINHA", dto.DtEmissaoCredencial.DBValue, ParameterDirection.Input, dto.DtEmissaoCredencial.DbType));

			//Parametro pID_CONTENCIOSO
			param.Add(Connection.CreateParameter("pID_CONTENCIOSO", dto.IdSituacaoJuridico.DBValue, ParameterDirection.Input, dto.IdSituacaoJuridico.DbType));

			//Parametro pDS_CONTENCIOSO
			param.Add(Connection.CreateParameter("pDS_CONTENCIOSO", dto.DsJuridicoBeneficiario.DBValue, ParameterDirection.Input, dto.DsJuridicoBeneficiario.DbType));

			//Parametro pID_SUSPENSAO_BOLETO
			param.Add(Connection.CreateParameter("pID_SUSPENSAO_BOLETO", dto.IdSuspensaoBoleto.DBValue, ParameterDirection.Input, dto.IdSuspensaoBoleto.DbType));

			//Parametro pID_DOENTE_CRONICO
			param.Add(Connection.CreateParameter("pID_DOENTE_CRONICO", dto.IdDoenteCronico.DBValue, ParameterDirection.Input, dto.IdDoenteCronico.DbType));

			//Parametro pCD_CID_CRONICO
			param.Add(Connection.CreateParameter("pCD_CID_CRONICO", dto.CdDiagnosticoCronico.DBValue, ParameterDirection.Input, dto.CdDiagnosticoCronico.DbType));

			//Parametro pID_REPASSE
			param.Add(Connection.CreateParameter("pID_REPASSE", dto.IdRepasseBeneficiario.DBValue, ParameterDirection.Input, dto.IdRepasseBeneficiario.DbType));

			//Parametro pDT_EXCLUSAO_FATURA
			param.Add(Connection.CreateParameter("pDT_EXCLUSAO_FATURA", dto.DtExclusaoFatura.DBValue, ParameterDirection.Input, dto.DtExclusaoFatura.DbType));

			//Parametro pCD_LOCAL_REPASSE
			param.Add(Connection.CreateParameter("pCD_LOCAL_REPASSE", dto.CdLocalRepasseBeneficiario.DBValue, ParameterDirection.Input, dto.CdLocalRepasseBeneficiario.DbType));

			//Parametro pID_PAC
			param.Add(Connection.CreateParameter("pID_PAC", dto.IdPiacBeneficiario.DBValue, ParameterDirection.Input, dto.IdPiacBeneficiario.DbType));

			//Parametro pID_CURATIVO
			param.Add(Connection.CreateParameter("pID_CURATIVO", dto.IdCurativoBeneficiario.DBValue, ParameterDirection.Input, dto.IdCurativoBeneficiario.DbType));

			//Parametro pDT_INI_CURATIVO
			param.Add(Connection.CreateParameter("pDT_INI_CURATIVO", dto.DtInicioCurativoBeneficiario.DBValue, ParameterDirection.Input, dto.DtInicioCurativoBeneficiario.DbType));

			//Parametro pID_HOMECARE
			param.Add(Connection.CreateParameter("pID_HOMECARE", dto.IdHomecareBeneficiario.DBValue, ParameterDirection.Input, dto.IdHomecareBeneficiario.DbType));

			//Parametro pDT_INI_HOMECARE
			param.Add(Connection.CreateParameter("pDT_INI_HOMECARE", dto.DtInicioHomecareBeneficiario.DBValue, ParameterDirection.Input, dto.DtInicioHomecareBeneficiario.DbType));

			//Parametro pID_MEDFAMILIA
			param.Add(Connection.CreateParameter("pID_MEDFAMILIA", dto.IdMedicoFamBeneficiario.DBValue, ParameterDirection.Input, dto.IdMedicoFamBeneficiario.DbType));

			//Parametro pDT_INI_MEDFAMILIA
			param.Add(Connection.CreateParameter("pDT_INI_MEDFAMILIA", dto.DtInicioMedicoFamBeneficiario.DBValue, ParameterDirection.Input, dto.DtInicioMedicoFamBeneficiario.DbType));

			//Parametro pID_SEGURO_REMISSAO
			param.Add(Connection.CreateParameter("pID_SEGURO_REMISSAO", dto.IdSegRemissaoBeneficiario.DBValue, ParameterDirection.Input, dto.IdSegRemissaoBeneficiario.DbType));

			//Parametro pID_PLANO_BEM
			param.Add(Connection.CreateParameter("pID_PLANO_BEM", dto.IdPlanoBemBeneficiario.DBValue, ParameterDirection.Input, dto.IdPlanoBemBeneficiario.DbType));

			//Parametro pDT_INI_CRONICO
			param.Add(Connection.CreateParameter("pDT_INI_CRONICO", dto.DtInicioCronicoBeneficiario.DBValue, ParameterDirection.Input, dto.DtInicioCronicoBeneficiario.DbType));

			//Parametro pDT_INI_PLANO_BEM
			param.Add(Connection.CreateParameter("pDT_INI_PLANO_BEM", dto.DtInicioPlanoBemBeneficiario.DBValue, ParameterDirection.Input, dto.DtInicioPlanoBemBeneficiario.DbType));

			//Parametro pDT_INICIO_REPASSE
			param.Add(Connection.CreateParameter("pDT_INICIO_REPASSE", dto.DtInicioRepasseBeneficiario.DBValue, ParameterDirection.Input, dto.DtInicioRepasseBeneficiario.DbType));

			//Parametro pDT_FINAL_REPASSE
			param.Add(Connection.CreateParameter("pDT_FINAL_REPASSE", dto.DtFinalRepasseBeneficiario.DBValue, ParameterDirection.Input, dto.DtFinalRepasseBeneficiario.DbType));

			//Parametro pCD_EMPRESA_REPASSE
			param.Add(Connection.CreateParameter("pCD_EMPRESA_REPASSE", dto.CdRepasseBeneficiario.DBValue, ParameterDirection.Input, dto.CdRepasseBeneficiario.DbType));

			//Parametro pDS_LOCALIDADE
			param.Add(Connection.CreateParameter("pDS_LOCALIDADE", dto.DsLocalRepasseBeneficiario.DBValue, ParameterDirection.Input, dto.DsLocalRepasseBeneficiario.DbType));

			//Parametro pID_EMPRESA_REPASSADA
			param.Add(Connection.CreateParameter("pID_EMPRESA_REPASSADA", dto.IdRepasseEmprBeneficiario.DBValue, ParameterDirection.Input, dto.IdRepasseEmprBeneficiario.DbType));

			//Parametro pDT_FIM_PLANO_BEM
			param.Add(Connection.CreateParameter("pDT_FIM_PLANO_BEM", dto.DtFimPlanoBemBeneficiario.DBValue, ParameterDirection.Input, dto.DtFimPlanoBemBeneficiario.DbType));

			//Parametro pCD_PLANO_BEM
			param.Add(Connection.CreateParameter("pCD_PLANO_BEM", dto.CdPlanoBemBeneficiario.DBValue, ParameterDirection.Input, dto.CdPlanoBemBeneficiario.DbType));

			//Parametro pID_ACESSORIO
			param.Add(Connection.CreateParameter("pID_ACESSORIO", dto.IdAcessorioBeneficiario.DBValue, ParameterDirection.Input, dto.IdAcessorioBeneficiario.DbType));

			//Parametro pCODNAC
			param.Add(Connection.CreateParameter("pCODNAC", dto.CdNacionalidadeBeneficiario.DBValue, ParameterDirection.Input, dto.CdNacionalidadeBeneficiario.DbType));

			//Parametro pCODPAIS
			param.Add(Connection.CreateParameter("pCODPAIS", dto.CdPaisBeneficiario.DBValue, ParameterDirection.Input, dto.CdPaisBeneficiario.DbType));

			//Parametro pORGAO_EMISSOR_RG
			param.Add(Connection.CreateParameter("pORGAO_EMISSOR_RG", dto.CdOrgaoEmissorBeneficiario.DBValue, ParameterDirection.Input, dto.CdOrgaoEmissorBeneficiario.DbType));

			//Parametro pPAIS_EMISSOR_RG
			param.Add(Connection.CreateParameter("pPAIS_EMISSOR_RG", dto.NmPaisEmissorBeneficiario.DBValue, ParameterDirection.Input, dto.NmPaisEmissorBeneficiario.DbType));

			//Parametro pPISPASEP
			param.Add(Connection.CreateParameter("pPISPASEP", dto.CdPisPasepBeneficiario.DBValue, ParameterDirection.Input, dto.CdPisPasepBeneficiario.DbType));

			//Parametro pIND_ACIDENTE_TRABALHO
			param.Add(Connection.CreateParameter("pIND_ACIDENTE_TRABALHO", dto.IdAcidenteTrabalhoBeneficiario.DBValue, ParameterDirection.Input, dto.IdAcidenteTrabalhoBeneficiario.DbType));

			//Parametro pCODPAC
			param.Add(Connection.CreateParameter("pCODPAC", dto.CdPiacBeneficiario.DBValue, ParameterDirection.Input, dto.CdPiacBeneficiario.DbType));

			//Parametro pDOCBEN
			param.Add(Connection.CreateParameter("pDOCBEN", dto.CdDocumentoBeneficiario.DBValue, ParameterDirection.Input, dto.CdDocumentoBeneficiario.DbType));

			//Parametro pCOD_NATDOC
			param.Add(Connection.CreateParameter("pCOD_NATDOC", dto.CdNaturezaDocBeneficiario.DBValue, ParameterDirection.Input, dto.CdNaturezaDocBeneficiario.DbType));

			//Parametro pDT_EXPEDOC
			param.Add(Connection.CreateParameter("pDT_EXPEDOC", dto.DtExpedDocBeneficiario.DBValue, ParameterDirection.Input, dto.DtExpedDocBeneficiario.DbType));

			//Parametro pCOD_ATIVPRINC
			param.Add(Connection.CreateParameter("pCOD_ATIVPRINC", dto.CdAtividadePrincipalBeneficiario.DBValue, ParameterDirection.Input, dto.CdAtividadePrincipalBeneficiario.DbType));

			//Parametro pIDOPER
			param.Add(Connection.CreateParameter("pIDOPER", dto.IdOperacao.DBValue, ParameterDirection.Input, dto.IdOperacao.DbType));

			//Parametro pID_CARTAO_AUTORIZADOR
			param.Add(Connection.CreateParameter("pID_CARTAO_AUTORIZADOR", dto.IdCartaoAutorizador.DBValue, ParameterDirection.Input, dto.IdCartaoAutorizador.DbType));

			//Parametro pDT_CARTAO_AUTORIZADOR
			param.Add(Connection.CreateParameter("pDT_CARTAO_AUTORIZADOR", dto.DataCartaoAutorizador.DBValue, ParameterDirection.Input, dto.DataCartaoAutorizador.DbType));

			//Parametro pNM_REDUZIDO
			param.Add(Connection.CreateParameter("pNM_REDUZIDO", dto.NomeReduzido.DBValue, ParameterDirection.Input, dto.NomeReduzido.DbType));

			//Parametro pDS_LOGIN
			param.Add(Connection.CreateParameter("pDS_LOGIN", dto.NmLogin.DBValue, ParameterDirection.Input, dto.NmLogin.DbType));

			//Parametro pCD_CCO
			param.Add(Connection.CreateParameter("pCD_CCO", dto.CdContrato.DBValue, ParameterDirection.Input, dto.CdContrato.DbType));

			//Parametro pDV_CCO
			param.Add(Connection.CreateParameter("pDV_CCO", dto.DgContrato.DBValue, ParameterDirection.Input, dto.DgContrato.DbType));

			//Parametro pCDPLANOANS_ORIGEM
			param.Add(Connection.CreateParameter("pCDPLANOANS_ORIGEM", dto.CodigoPlanoANSOrigem.DBValue, ParameterDirection.Input, dto.CodigoPlanoANSOrigem.DbType));

            //Parametro pSITUACAO
            if (!string.IsNullOrEmpty(situacao)) param.Add(Connection.CreateParameter("pSITUACAO", situacao));

            //Parametro pINCLUIR_HOMECARE
            if (incluirHomeCare) param.Add(Connection.CreateParameter("pINCLUIR_HOMECARE", 1));

            //Parametro pEXISTE_HOMECARE
            if (existeHomeCare) param.Add(Connection.CreateParameter("pEXISTE_HOMECARE", 1));
			#endregion	
			
			BeneficiarioACSDataTable result = new BeneficiarioACSDataTable();
            string query = "PRC_BENEF_ACS_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);
			
			return result;
		}

		/// <summary>
        /// Listar o registro utilizando PK
        /// </summary>
        public BeneficiarioACSDTO Pesquisar(BeneficiarioACSDTO dto)
        {            
			#region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();            
			
			//Parametro Cursor
            param.Add(Connection.CreateParameterCursor());		
			
			// Parametro pCODBEN
			param.Add(Connection.CreateParameter("pCODBEN", dto.CodigoMatricula.DBValue, ParameterDirection.Input, dto.CodigoMatricula.DbType));
			
			// Parametro pCODCON
			param.Add(Connection.CreateParameter("pCODCON", dto.CodigoEmpresa.DBValue, ParameterDirection.Input, dto.CodigoEmpresa.DbType));
			
			// Parametro pCODEST
			param.Add(Connection.CreateParameter("pCODEST", dto.CodigoLoja.DBValue, ParameterDirection.Input, dto.CodigoLoja.DbType));
			
			// Parametro pCODSEQBEN
			param.Add(Connection.CreateParameter("pCODSEQBEN", dto.CodigoSeqMatricula.DBValue, ParameterDirection.Input, dto.CodigoSeqMatricula.DbType));
			
			
			#endregion	
			
			BeneficiarioACSDataTable result = new BeneficiarioACSDataTable();
            string query = "PRC_BENEF_ACS_S";
			
			//Executa o procedimento
			Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            if (result.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return result.TypedRow(0);
            }
		}

        public BeneficiarioACSDTO PesquisarBenefTransferido(BeneficiarioACSDTO dto)
        {
            #region "Parametros"
            DbParameterCollection param = Connection.CreateDataParameterCollection();

            //Parametro Cursor
            param.Add(Connection.CreateParameterCursor());

            // Parametro pCODBEN
            param.Add(Connection.CreateParameter("pCODBEN", dto.CodigoMatricula.DBValue, ParameterDirection.Input, dto.CodigoMatricula.DbType));

            // Parametro pCODCON
            param.Add(Connection.CreateParameter("pCODCON", dto.CodigoEmpresa.DBValue, ParameterDirection.Input, dto.CodigoEmpresa.DbType));

            // Parametro pCODEST
            param.Add(Connection.CreateParameter("pCODEST", dto.CodigoLoja.DBValue, ParameterDirection.Input, dto.CodigoLoja.DbType));

            // Parametro pCODSEQBEN
            param.Add(Connection.CreateParameter("pCODSEQBEN", dto.CodigoSeqMatricula.DBValue, ParameterDirection.Input, dto.CodigoSeqMatricula.DbType));


            #endregion	
    
            string query = "PRC_BENEF_TRANSF_S";

            BeneficiarioACSDataTable result = new BeneficiarioACSDataTable();

            Connection.RecordSet(query, ref param, result, CommandType.StoredProcedure);

            if (result.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                return result.TypedRow(0);
            }
        }
		
		/// <summary>
        /// Exclui o registro
        /// </summary>        
		public void Excluir(BeneficiarioACSDTO dto)
		{
  		    #region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();            		
			
			// Parametro pCD_EMPRESA
			param.Add(Connection.CreateParameter("pCD_EMPRESA", dto.CdNumericoEmpresa.DBValue, ParameterDirection.Input, dto.CdNumericoEmpresa.DbType));
			
			// Parametro pCODBEN
			param.Add(Connection.CreateParameter("pCODBEN", dto.CodigoMatricula.DBValue, ParameterDirection.Input, dto.CodigoMatricula.DbType));
			
			// Parametro pCODCON
			param.Add(Connection.CreateParameter("pCODCON", dto.CodigoEmpresa.DBValue, ParameterDirection.Input, dto.CodigoEmpresa.DbType));
			
			// Parametro pCODEST
			param.Add(Connection.CreateParameter("pCODEST", dto.CodigoLoja.DBValue, ParameterDirection.Input, dto.CodigoLoja.DbType));
			
			// Parametro pCODSEQBEN
			param.Add(Connection.CreateParameter("pCODSEQBEN", dto.CodigoSeqMatricula.DBValue, ParameterDirection.Input, dto.CodigoSeqMatricula.DbType));
			
		
   	       #endregion				
			//Executa o procedimento
            
			string query = "PRC__BENEFICIARIO_D";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Altera o registro
        /// </summary>			
		public void Alterar(BeneficiarioACSDTO dto)
		{	
			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			//Parametro pCODCON
			param.Add(Connection.CreateParameter("pCODCON", dto.CodigoEmpresa.DBValue, ParameterDirection.Input, dto.CodigoEmpresa.DbType));
			
			//Parametro pCODEST
			param.Add(Connection.CreateParameter("pCODEST", dto.CodigoLoja.DBValue, ParameterDirection.Input, dto.CodigoLoja.DbType));
			
			//Parametro pCODBEN
			param.Add(Connection.CreateParameter("pCODBEN", dto.CodigoMatricula.DBValue, ParameterDirection.Input, dto.CodigoMatricula.DbType));
			
			//Parametro pCODSEQBEN
			param.Add(Connection.CreateParameter("pCODSEQBEN", dto.CodigoSeqMatricula.DBValue, ParameterDirection.Input, dto.CodigoSeqMatricula.DbType));
			
			//Parametro pNOMBEN
			param.Add(Connection.CreateParameter("pNOMBEN", dto.NomeBeneficiario.DBValue, ParameterDirection.Input, dto.NomeBeneficiario.DbType));
			
			//Parametro pCODPADATEBEN
			param.Add(Connection.CreateParameter("pCODPADATEBEN", dto.CdPadraoAtendimentoBeneficiario.DBValue, ParameterDirection.Input, dto.CdPadraoAtendimentoBeneficiario.DbType));
			
			//Parametro pCODPADCOBBEN
			param.Add(Connection.CreateParameter("pCODPADCOBBEN", dto.CdPadraoCobrancaBeneficiario.DBValue, ParameterDirection.Input, dto.CdPadraoCobrancaBeneficiario.DbType));
			
			//Parametro pCODINDBEN
			param.Add(Connection.CreateParameter("pCODINDBEN", dto.IndicacaoTitular.DBValue, ParameterDirection.Input, dto.IndicacaoTitular.DbType));
			
			//Parametro pSEXBEN
			param.Add(Connection.CreateParameter("pSEXBEN", dto.SexoBeneficiario.DBValue, ParameterDirection.Input, dto.SexoBeneficiario.DbType));
			
			//Parametro pCODGRAPAR
			param.Add(Connection.CreateParameter("pCODGRAPAR", dto.CdGrauParentesco.DBValue, ParameterDirection.Input, dto.CdGrauParentesco.DbType));
			
			//Parametro pESTCIVBEN
			param.Add(Connection.CreateParameter("pESTCIVBEN", dto.CdEstadoCivilBeneficiario.DBValue, ParameterDirection.Input, dto.CdEstadoCivilBeneficiario.DbType));
			
			//Parametro pDATNASBEN
			param.Add(Connection.CreateParameter("pDATNASBEN", dto.DtNascimentoBeneficiario.DBValue, ParameterDirection.Input, dto.DtNascimentoBeneficiario.DbType));
			
			//Parametro pDATINGCONBEN
			param.Add(Connection.CreateParameter("pDATINGCONBEN", dto.DtIngressoBeneficiario.DBValue, ParameterDirection.Input, dto.DtIngressoBeneficiario.DbType));
			
			//Parametro pDATADMEMP
			param.Add(Connection.CreateParameter("pDATADMEMP", dto.DtAdmissaoEmpresaBeneficiario.DBValue, ParameterDirection.Input, dto.DtAdmissaoEmpresaBeneficiario.DbType));
			
			//Parametro pDATSAICONBEN
			param.Add(Connection.CreateParameter("pDATSAICONBEN", dto.DtSaidaBeneficiario.DBValue, ParameterDirection.Input, dto.DtSaidaBeneficiario.DbType));
			
			//Parametro pOCUEMPBEN
			param.Add(Connection.CreateParameter("pOCUEMPBEN", dto.CdOcupacaoBeneficiario.DBValue, ParameterDirection.Input, dto.CdOcupacaoBeneficiario.DbType));
			
			//Parametro pCARPROBEN
			param.Add(Connection.CreateParameter("pCARPROBEN", dto.CdCargoBeneficiario.DBValue, ParameterDirection.Input, dto.CdCargoBeneficiario.DbType));
			
			//Parametro pCODSITBEN
			param.Add(Connection.CreateParameter("pCODSITBEN", dto.CdSituacaoBeneficiario.DBValue, ParameterDirection.Input, dto.CdSituacaoBeneficiario.DbType));
			
			//Parametro pDATLIMBEN
			param.Add(Connection.CreateParameter("pDATLIMBEN", dto.DtLimiteBeneficiario.DBValue, ParameterDirection.Input, dto.DtLimiteBeneficiario.DbType));
			
			//Parametro pDATSITBEN
			param.Add(Connection.CreateParameter("pDATSITBEN", dto.DtSituacaoBeneficiario.DBValue, ParameterDirection.Input, dto.DtSituacaoBeneficiario.DbType));
			
			//Parametro pCPFBEN
			param.Add(Connection.CreateParameter("pCPFBEN", dto.CdCpfBeneficiario.DBValue, ParameterDirection.Input, dto.CdCpfBeneficiario.DbType));
			
			//Parametro pRGBEN
			param.Add(Connection.CreateParameter("pRGBEN", dto.CdRgBeneficiario.DBValue, ParameterDirection.Input, dto.CdRgBeneficiario.DbType));
			
			//Parametro pCODACO
			param.Add(Connection.CreateParameter("pCODACO", dto.CdAcordoBeneficiario.DBValue, ParameterDirection.Input, dto.CdAcordoBeneficiario.DbType));
			
			//Parametro pCODPLA
			param.Add(Connection.CreateParameter("pCODPLA", dto.CdPlanoBeneficiario.DBValue, ParameterDirection.Input, dto.CdPlanoBeneficiario.DbType));
			
			//Parametro pVALCOB
			param.Add(Connection.CreateParameter("pVALCOB", dto.VlCobrancaBeneficiario.DBValue, ParameterDirection.Input, dto.VlCobrancaBeneficiario.DbType));
			
			//Parametro pCODTIPPAD
			param.Add(Connection.CreateParameter("pCODTIPPAD", dto.CodTipoPad.DBValue, ParameterDirection.Input, dto.CodTipoPad.DbType));
			
			//Parametro pDATEMIEXC
			param.Add(Connection.CreateParameter("pDATEMIEXC", dto.DataMIEXC.DBValue, ParameterDirection.Input, dto.DataMIEXC.DbType));
			
			//Parametro pSITATI
			param.Add(Connection.CreateParameter("pSITATI", dto.CdSituacaoABeneficiario.DBValue, ParameterDirection.Input, dto.CdSituacaoABeneficiario.DbType));
			
			//Parametro pCODTIPCARBEN
			param.Add(Connection.CreateParameter("pCODTIPCARBEN", dto.CdCarenciaBeneficiario.DBValue, ParameterDirection.Input, dto.CdCarenciaBeneficiario.DbType));
			
			//Parametro pINDPAG
			param.Add(Connection.CreateParameter("pINDPAG", dto.IndPag.DBValue, ParameterDirection.Input, dto.IndPag.DbType));
			
			//Parametro pDT_ATU_INDPAG
			param.Add(Connection.CreateParameter("pDT_ATU_INDPAG", dto.DtAtuIndPag.DBValue, ParameterDirection.Input, dto.DtAtuIndPag.DbType));
			
			//Parametro pIND_NEGOCIACAO
			param.Add(Connection.CreateParameter("pIND_NEGOCIACAO", dto.IndNegociacao.DBValue, ParameterDirection.Input, dto.IndNegociacao.DbType));
			
			//Parametro pDATFATOD
			param.Add(Connection.CreateParameter("pDATFATOD", dto.DataTod.DBValue, ParameterDirection.Input, dto.DataTod.DbType));
			
			//Parametro pIDADEBEN
			param.Add(Connection.CreateParameter("pIDADEBEN", dto.IdadeBen.DBValue, ParameterDirection.Input, dto.IdadeBen.DbType));
			
			//Parametro pMAEBEN
			param.Add(Connection.CreateParameter("pMAEBEN", dto.NmMaeBeneficiario.DBValue, ParameterDirection.Input, dto.NmMaeBeneficiario.DbType));
			
			//Parametro pCANC_ANS
			param.Add(Connection.CreateParameter("pCANC_ANS", dto.IdCancelamentoAns.DBValue, ParameterDirection.Input, dto.IdCancelamentoAns.DbType));
			
			//Parametro pID_AUTORIZACAO_ANS
			param.Add(Connection.CreateParameter("pID_AUTORIZACAO_ANS", dto.IdAutorizacaoANS.DBValue, ParameterDirection.Input, dto.IdAutorizacaoANS.DbType));
			
			//Parametro pVLPERC
			param.Add(Connection.CreateParameter("pVLPERC", dto.VlPerc.DBValue, ParameterDirection.Input, dto.VlPerc.DbType));
			
			//Parametro pCODPRO
			param.Add(Connection.CreateParameter("pCODPRO", dto.CdProfissionalBeneficiario.DBValue, ParameterDirection.Input, dto.CdProfissionalBeneficiario.DbType));
			
			//Parametro pDATALTBEN
			param.Add(Connection.CreateParameter("pDATALTBEN", dto.DtAlteracaoBeneficiario.DBValue, ParameterDirection.Input, dto.DtAlteracaoBeneficiario.DbType));
			
			//Parametro pCD_EMPRESA
			param.Add(Connection.CreateParameter("pCD_EMPRESA", dto.CdNumericoEmpresa.DBValue, ParameterDirection.Input, dto.CdNumericoEmpresa.DbType));
			
			//Parametro pID_COPART_EXAME
			param.Add(Connection.CreateParameter("pID_COPART_EXAME", dto.IdCopartExameBeneficiario.DBValue, ParameterDirection.Input, dto.IdCopartExameBeneficiario.DbType));
			
			//Parametro pID_COPART_CONSULTA
			param.Add(Connection.CreateParameter("pID_COPART_CONSULTA", dto.IdCopartConsultaBeneficiario.DBValue, ParameterDirection.Input, dto.IdCopartConsultaBeneficiario.DbType));
			
			//Parametro pID_CRONICO
			param.Add(Connection.CreateParameter("pID_CRONICO", dto.IdCronicoBeneficiario.DBValue, ParameterDirection.Input, dto.IdCronicoBeneficiario.DbType));
			
			//Parametro pCO_PART
			param.Add(Connection.CreateParameter("pCO_PART", dto.IdCopartBeneficiario.DBValue, ParameterDirection.Input, dto.IdCopartBeneficiario.DbType));
			
			//Parametro pID_EMISSAO_CARTEIRINHA
			param.Add(Connection.CreateParameter("pID_EMISSAO_CARTEIRINHA", dto.IdCredencialBeneficiario.DBValue, ParameterDirection.Input, dto.IdCredencialBeneficiario.DbType));
			
			//Parametro pVL_COBRANCA_ATUAL
			param.Add(Connection.CreateParameter("pVL_COBRANCA_ATUAL", dto.VlCobrancaAtual.DBValue, ParameterDirection.Input, dto.VlCobrancaAtual.DbType));
			
			//Parametro pDT_COBRANCA_ATUAL
			param.Add(Connection.CreateParameter("pDT_COBRANCA_ATUAL", dto.DataCobrancaAtual.DBValue, ParameterDirection.Input, dto.DataCobrancaAtual.DbType));
			
			//Parametro pDT_REF_COBRANCA_ATUAL
			param.Add(Connection.CreateParameter("pDT_REF_COBRANCA_ATUAL", dto.DataRefCobrancaAtual.DBValue, ParameterDirection.Input, dto.DataRefCobrancaAtual.DbType));
			
			//Parametro pDT_EMISSAO_CARTEIRINHA
			param.Add(Connection.CreateParameter("pDT_EMISSAO_CARTEIRINHA", dto.DtEmissaoCredencial.DBValue, ParameterDirection.Input, dto.DtEmissaoCredencial.DbType));
			
			//Parametro pID_CONTENCIOSO
			param.Add(Connection.CreateParameter("pID_CONTENCIOSO", dto.IdSituacaoJuridico.DBValue, ParameterDirection.Input, dto.IdSituacaoJuridico.DbType));
			
			//Parametro pDS_CONTENCIOSO
			param.Add(Connection.CreateParameter("pDS_CONTENCIOSO", dto.DsJuridicoBeneficiario.DBValue, ParameterDirection.Input, dto.DsJuridicoBeneficiario.DbType));
			
			//Parametro pID_SUSPENSAO_BOLETO
			param.Add(Connection.CreateParameter("pID_SUSPENSAO_BOLETO", dto.IdSuspensaoBoleto.DBValue, ParameterDirection.Input, dto.IdSuspensaoBoleto.DbType));
			
			//Parametro pID_DOENTE_CRONICO
			param.Add(Connection.CreateParameter("pID_DOENTE_CRONICO", dto.IdDoenteCronico.DBValue, ParameterDirection.Input, dto.IdDoenteCronico.DbType));
			
			//Parametro pCD_CID_CRONICO
			param.Add(Connection.CreateParameter("pCD_CID_CRONICO", dto.CdDiagnosticoCronico.DBValue, ParameterDirection.Input, dto.CdDiagnosticoCronico.DbType));
			
			//Parametro pID_REPASSE
			param.Add(Connection.CreateParameter("pID_REPASSE", dto.IdRepasseBeneficiario.DBValue, ParameterDirection.Input, dto.IdRepasseBeneficiario.DbType));
			
			//Parametro pDT_EXCLUSAO_FATURA
			param.Add(Connection.CreateParameter("pDT_EXCLUSAO_FATURA", dto.DtExclusaoFatura.DBValue, ParameterDirection.Input, dto.DtExclusaoFatura.DbType));
			
			//Parametro pCD_LOCAL_REPASSE
			param.Add(Connection.CreateParameter("pCD_LOCAL_REPASSE", dto.CdLocalRepasseBeneficiario.DBValue, ParameterDirection.Input, dto.CdLocalRepasseBeneficiario.DbType));
			
			//Parametro pID_PAC
			param.Add(Connection.CreateParameter("pID_PAC", dto.IdPiacBeneficiario.DBValue, ParameterDirection.Input, dto.IdPiacBeneficiario.DbType));
			
			//Parametro pID_CURATIVO
			param.Add(Connection.CreateParameter("pID_CURATIVO", dto.IdCurativoBeneficiario.DBValue, ParameterDirection.Input, dto.IdCurativoBeneficiario.DbType));
			
			//Parametro pDT_INI_CURATIVO
			param.Add(Connection.CreateParameter("pDT_INI_CURATIVO", dto.DtInicioCurativoBeneficiario.DBValue, ParameterDirection.Input, dto.DtInicioCurativoBeneficiario.DbType));
			
			//Parametro pID_HOMECARE
			param.Add(Connection.CreateParameter("pID_HOMECARE", dto.IdHomecareBeneficiario.DBValue, ParameterDirection.Input, dto.IdHomecareBeneficiario.DbType));
			
			//Parametro pDT_INI_HOMECARE
			param.Add(Connection.CreateParameter("pDT_INI_HOMECARE", dto.DtInicioHomecareBeneficiario.DBValue, ParameterDirection.Input, dto.DtInicioHomecareBeneficiario.DbType));
			
			//Parametro pID_MEDFAMILIA
			param.Add(Connection.CreateParameter("pID_MEDFAMILIA", dto.IdMedicoFamBeneficiario.DBValue, ParameterDirection.Input, dto.IdMedicoFamBeneficiario.DbType));
			
			//Parametro pDT_INI_MEDFAMILIA
			param.Add(Connection.CreateParameter("pDT_INI_MEDFAMILIA", dto.DtInicioMedicoFamBeneficiario.DBValue, ParameterDirection.Input, dto.DtInicioMedicoFamBeneficiario.DbType));
			
			//Parametro pID_SEGURO_REMISSAO
			param.Add(Connection.CreateParameter("pID_SEGURO_REMISSAO", dto.IdSegRemissaoBeneficiario.DBValue, ParameterDirection.Input, dto.IdSegRemissaoBeneficiario.DbType));
			
			//Parametro pID_PLANO_BEM
			param.Add(Connection.CreateParameter("pID_PLANO_BEM", dto.IdPlanoBemBeneficiario.DBValue, ParameterDirection.Input, dto.IdPlanoBemBeneficiario.DbType));
			
			//Parametro pDT_INI_CRONICO
			param.Add(Connection.CreateParameter("pDT_INI_CRONICO", dto.DtInicioCronicoBeneficiario.DBValue, ParameterDirection.Input, dto.DtInicioCronicoBeneficiario.DbType));
			
			//Parametro pDT_INI_PLANO_BEM
			param.Add(Connection.CreateParameter("pDT_INI_PLANO_BEM", dto.DtInicioPlanoBemBeneficiario.DBValue, ParameterDirection.Input, dto.DtInicioPlanoBemBeneficiario.DbType));
			
			//Parametro pDT_INICIO_REPASSE
			param.Add(Connection.CreateParameter("pDT_INICIO_REPASSE", dto.DtInicioRepasseBeneficiario.DBValue, ParameterDirection.Input, dto.DtInicioRepasseBeneficiario.DbType));
			
			//Parametro pDT_FINAL_REPASSE
			param.Add(Connection.CreateParameter("pDT_FINAL_REPASSE", dto.DtFinalRepasseBeneficiario.DBValue, ParameterDirection.Input, dto.DtFinalRepasseBeneficiario.DbType));
			
			//Parametro pCD_EMPRESA_REPASSE
			param.Add(Connection.CreateParameter("pCD_EMPRESA_REPASSE", dto.CdRepasseBeneficiario.DBValue, ParameterDirection.Input, dto.CdRepasseBeneficiario.DbType));
			
			//Parametro pDS_LOCALIDADE
			param.Add(Connection.CreateParameter("pDS_LOCALIDADE", dto.DsLocalRepasseBeneficiario.DBValue, ParameterDirection.Input, dto.DsLocalRepasseBeneficiario.DbType));
			
			//Parametro pID_EMPRESA_REPASSADA
			param.Add(Connection.CreateParameter("pID_EMPRESA_REPASSADA", dto.IdRepasseEmprBeneficiario.DBValue, ParameterDirection.Input, dto.IdRepasseEmprBeneficiario.DbType));
			
			//Parametro pDT_FIM_PLANO_BEM
			param.Add(Connection.CreateParameter("pDT_FIM_PLANO_BEM", dto.DtFimPlanoBemBeneficiario.DBValue, ParameterDirection.Input, dto.DtFimPlanoBemBeneficiario.DbType));
			
			//Parametro pCD_PLANO_BEM
			param.Add(Connection.CreateParameter("pCD_PLANO_BEM", dto.CdPlanoBemBeneficiario.DBValue, ParameterDirection.Input, dto.CdPlanoBemBeneficiario.DbType));
			
			//Parametro pID_ACESSORIO
			param.Add(Connection.CreateParameter("pID_ACESSORIO", dto.IdAcessorioBeneficiario.DBValue, ParameterDirection.Input, dto.IdAcessorioBeneficiario.DbType));
			
			//Parametro pCODNAC
			param.Add(Connection.CreateParameter("pCODNAC", dto.CdNacionalidadeBeneficiario.DBValue, ParameterDirection.Input, dto.CdNacionalidadeBeneficiario.DbType));
			
			//Parametro pCODPAIS
			param.Add(Connection.CreateParameter("pCODPAIS", dto.CdPaisBeneficiario.DBValue, ParameterDirection.Input, dto.CdPaisBeneficiario.DbType));
			
			//Parametro pORGAO_EMISSOR_RG
			param.Add(Connection.CreateParameter("pORGAO_EMISSOR_RG", dto.CdOrgaoEmissorBeneficiario.DBValue, ParameterDirection.Input, dto.CdOrgaoEmissorBeneficiario.DbType));
			
			//Parametro pPAIS_EMISSOR_RG
			param.Add(Connection.CreateParameter("pPAIS_EMISSOR_RG", dto.NmPaisEmissorBeneficiario.DBValue, ParameterDirection.Input, dto.NmPaisEmissorBeneficiario.DbType));
			
			//Parametro pPISPASEP
			param.Add(Connection.CreateParameter("pPISPASEP", dto.CdPisPasepBeneficiario.DBValue, ParameterDirection.Input, dto.CdPisPasepBeneficiario.DbType));
			
			//Parametro pIND_ACIDENTE_TRABALHO
			param.Add(Connection.CreateParameter("pIND_ACIDENTE_TRABALHO", dto.IdAcidenteTrabalhoBeneficiario.DBValue, ParameterDirection.Input, dto.IdAcidenteTrabalhoBeneficiario.DbType));
			
			//Parametro pCODPAC
			param.Add(Connection.CreateParameter("pCODPAC", dto.CdPiacBeneficiario.DBValue, ParameterDirection.Input, dto.CdPiacBeneficiario.DbType));
			
			//Parametro pDOCBEN
			param.Add(Connection.CreateParameter("pDOCBEN", dto.CdDocumentoBeneficiario.DBValue, ParameterDirection.Input, dto.CdDocumentoBeneficiario.DbType));
			
			//Parametro pCOD_NATDOC
			param.Add(Connection.CreateParameter("pCOD_NATDOC", dto.CdNaturezaDocBeneficiario.DBValue, ParameterDirection.Input, dto.CdNaturezaDocBeneficiario.DbType));
			
			//Parametro pDT_EXPEDOC
			param.Add(Connection.CreateParameter("pDT_EXPEDOC", dto.DtExpedDocBeneficiario.DBValue, ParameterDirection.Input, dto.DtExpedDocBeneficiario.DbType));
			
			//Parametro pCOD_ATIVPRINC
			param.Add(Connection.CreateParameter("pCOD_ATIVPRINC", dto.CdAtividadePrincipalBeneficiario.DBValue, ParameterDirection.Input, dto.CdAtividadePrincipalBeneficiario.DbType));
			
			//Parametro pIDOPER
			param.Add(Connection.CreateParameter("pIDOPER", dto.IdOperacao.DBValue, ParameterDirection.Input, dto.IdOperacao.DbType));
			
			//Parametro pID_CARTAO_AUTORIZADOR
			param.Add(Connection.CreateParameter("pID_CARTAO_AUTORIZADOR", dto.IdCartaoAutorizador.DBValue, ParameterDirection.Input, dto.IdCartaoAutorizador.DbType));
			
			//Parametro pDT_CARTAO_AUTORIZADOR
			param.Add(Connection.CreateParameter("pDT_CARTAO_AUTORIZADOR", dto.DataCartaoAutorizador.DBValue, ParameterDirection.Input, dto.DataCartaoAutorizador.DbType));
			
			//Parametro pNM_REDUZIDO
			param.Add(Connection.CreateParameter("pNM_REDUZIDO", dto.NomeReduzido.DBValue, ParameterDirection.Input, dto.NomeReduzido.DbType));
			
			//Parametro pDS_LOGIN
			param.Add(Connection.CreateParameter("pDS_LOGIN", dto.NmLogin.DBValue, ParameterDirection.Input, dto.NmLogin.DbType));
			
			//Parametro pCD_CCO
			param.Add(Connection.CreateParameter("pCD_CCO", dto.CdContrato.DBValue, ParameterDirection.Input, dto.CdContrato.DbType));
			
			//Parametro pDV_CCO
			param.Add(Connection.CreateParameter("pDV_CCO", dto.DgContrato.DBValue, ParameterDirection.Input, dto.DgContrato.DbType));
			
			//Parametro pCDPLANOANS_ORIGEM
			param.Add(Connection.CreateParameter("pCDPLANOANS_ORIGEM", dto.CodigoPlanoANSOrigem.DBValue, ParameterDirection.Input, dto.CodigoPlanoANSOrigem.DbType));
			
			#endregion	

			string query = "PRC__BENEFICIARIO_U";
			
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);
		}
		
		/// <summary>
        /// Inclui o registro
        /// </summary>			
		public void Incluir(BeneficiarioACSDTO dto)
		{			
			string query = "PRC__BENEFICIARIO_I";

			#region "Parametros"            
			DbParameterCollection param = Connection.CreateDataParameterCollection();			
			
			
			//Parametro pCODCON
			param.Add(Connection.CreateParameter("pCODCON", dto.CodigoEmpresa.DBValue, ParameterDirection.Input, dto.CodigoEmpresa.DbType));
			
			//Parametro pCODEST
			param.Add(Connection.CreateParameter("pCODEST", dto.CodigoLoja.DBValue, ParameterDirection.Input, dto.CodigoLoja.DbType));
			
			//Parametro pCODBEN
			param.Add(Connection.CreateParameter("pCODBEN", dto.CodigoMatricula.DBValue, ParameterDirection.Input, dto.CodigoMatricula.DbType));
			
			//Parametro pCODSEQBEN
			param.Add(Connection.CreateParameter("pCODSEQBEN", dto.CodigoSeqMatricula.DBValue, ParameterDirection.Input, dto.CodigoSeqMatricula.DbType));
			
			//Parametro pNOMBEN
			param.Add(Connection.CreateParameter("pNOMBEN", dto.NomeBeneficiario.DBValue, ParameterDirection.Input, dto.NomeBeneficiario.DbType));
			
			//Parametro pCODPADATEBEN
			param.Add(Connection.CreateParameter("pCODPADATEBEN", dto.CdPadraoAtendimentoBeneficiario.DBValue, ParameterDirection.Input, dto.CdPadraoAtendimentoBeneficiario.DbType));
			
			//Parametro pCODPADCOBBEN
			param.Add(Connection.CreateParameter("pCODPADCOBBEN", dto.CdPadraoCobrancaBeneficiario.DBValue, ParameterDirection.Input, dto.CdPadraoCobrancaBeneficiario.DbType));
			
			//Parametro pCODINDBEN
			param.Add(Connection.CreateParameter("pCODINDBEN", dto.IndicacaoTitular.DBValue, ParameterDirection.Input, dto.IndicacaoTitular.DbType));
			
			//Parametro pSEXBEN
			param.Add(Connection.CreateParameter("pSEXBEN", dto.SexoBeneficiario.DBValue, ParameterDirection.Input, dto.SexoBeneficiario.DbType));
			
			//Parametro pCODGRAPAR
			param.Add(Connection.CreateParameter("pCODGRAPAR", dto.CdGrauParentesco.DBValue, ParameterDirection.Input, dto.CdGrauParentesco.DbType));
			
			//Parametro pESTCIVBEN
			param.Add(Connection.CreateParameter("pESTCIVBEN", dto.CdEstadoCivilBeneficiario.DBValue, ParameterDirection.Input, dto.CdEstadoCivilBeneficiario.DbType));
			
			//Parametro pDATNASBEN
			param.Add(Connection.CreateParameter("pDATNASBEN", dto.DtNascimentoBeneficiario.DBValue, ParameterDirection.Input, dto.DtNascimentoBeneficiario.DbType));
			
			//Parametro pDATINGCONBEN
			param.Add(Connection.CreateParameter("pDATINGCONBEN", dto.DtIngressoBeneficiario.DBValue, ParameterDirection.Input, dto.DtIngressoBeneficiario.DbType));
			
			//Parametro pDATADMEMP
			param.Add(Connection.CreateParameter("pDATADMEMP", dto.DtAdmissaoEmpresaBeneficiario.DBValue, ParameterDirection.Input, dto.DtAdmissaoEmpresaBeneficiario.DbType));
			
			//Parametro pDATSAICONBEN
			param.Add(Connection.CreateParameter("pDATSAICONBEN", dto.DtSaidaBeneficiario.DBValue, ParameterDirection.Input, dto.DtSaidaBeneficiario.DbType));
			
			//Parametro pOCUEMPBEN
			param.Add(Connection.CreateParameter("pOCUEMPBEN", dto.CdOcupacaoBeneficiario.DBValue, ParameterDirection.Input, dto.CdOcupacaoBeneficiario.DbType));
			
			//Parametro pCARPROBEN
			param.Add(Connection.CreateParameter("pCARPROBEN", dto.CdCargoBeneficiario.DBValue, ParameterDirection.Input, dto.CdCargoBeneficiario.DbType));
			
			//Parametro pCODSITBEN
			param.Add(Connection.CreateParameter("pCODSITBEN", dto.CdSituacaoBeneficiario.DBValue, ParameterDirection.Input, dto.CdSituacaoBeneficiario.DbType));
			
			//Parametro pDATLIMBEN
			param.Add(Connection.CreateParameter("pDATLIMBEN", dto.DtLimiteBeneficiario.DBValue, ParameterDirection.Input, dto.DtLimiteBeneficiario.DbType));
			
			//Parametro pDATSITBEN
			param.Add(Connection.CreateParameter("pDATSITBEN", dto.DtSituacaoBeneficiario.DBValue, ParameterDirection.Input, dto.DtSituacaoBeneficiario.DbType));
			
			//Parametro pCPFBEN
			param.Add(Connection.CreateParameter("pCPFBEN", dto.CdCpfBeneficiario.DBValue, ParameterDirection.Input, dto.CdCpfBeneficiario.DbType));
			
			//Parametro pRGBEN
			param.Add(Connection.CreateParameter("pRGBEN", dto.CdRgBeneficiario.DBValue, ParameterDirection.Input, dto.CdRgBeneficiario.DbType));
			
			//Parametro pCODACO
			param.Add(Connection.CreateParameter("pCODACO", dto.CdAcordoBeneficiario.DBValue, ParameterDirection.Input, dto.CdAcordoBeneficiario.DbType));
			
			//Parametro pCODPLA
			param.Add(Connection.CreateParameter("pCODPLA", dto.CdPlanoBeneficiario.DBValue, ParameterDirection.Input, dto.CdPlanoBeneficiario.DbType));
			
			//Parametro pVALCOB
			param.Add(Connection.CreateParameter("pVALCOB", dto.VlCobrancaBeneficiario.DBValue, ParameterDirection.Input, dto.VlCobrancaBeneficiario.DbType));
			
			//Parametro pCODTIPPAD
			param.Add(Connection.CreateParameter("pCODTIPPAD", dto.CodTipoPad.DBValue, ParameterDirection.Input, dto.CodTipoPad.DbType));
			
			//Parametro pDATEMIEXC
			param.Add(Connection.CreateParameter("pDATEMIEXC", dto.DataMIEXC.DBValue, ParameterDirection.Input, dto.DataMIEXC.DbType));
			
			//Parametro pSITATI
			param.Add(Connection.CreateParameter("pSITATI", dto.CdSituacaoABeneficiario.DBValue, ParameterDirection.Input, dto.CdSituacaoABeneficiario.DbType));
			
			//Parametro pCODTIPCARBEN
			param.Add(Connection.CreateParameter("pCODTIPCARBEN", dto.CdCarenciaBeneficiario.DBValue, ParameterDirection.Input, dto.CdCarenciaBeneficiario.DbType));
			
			//Parametro pINDPAG
			param.Add(Connection.CreateParameter("pINDPAG", dto.IndPag.DBValue, ParameterDirection.Input, dto.IndPag.DbType));
			
			//Parametro pDT_ATU_INDPAG
			param.Add(Connection.CreateParameter("pDT_ATU_INDPAG", dto.DtAtuIndPag.DBValue, ParameterDirection.Input, dto.DtAtuIndPag.DbType));
			
			//Parametro pIND_NEGOCIACAO
			param.Add(Connection.CreateParameter("pIND_NEGOCIACAO", dto.IndNegociacao.DBValue, ParameterDirection.Input, dto.IndNegociacao.DbType));
			
			//Parametro pDATFATOD
			param.Add(Connection.CreateParameter("pDATFATOD", dto.DataTod.DBValue, ParameterDirection.Input, dto.DataTod.DbType));
			
			//Parametro pIDADEBEN
			param.Add(Connection.CreateParameter("pIDADEBEN", dto.IdadeBen.DBValue, ParameterDirection.Input, dto.IdadeBen.DbType));
			
			//Parametro pMAEBEN
			param.Add(Connection.CreateParameter("pMAEBEN", dto.NmMaeBeneficiario.DBValue, ParameterDirection.Input, dto.NmMaeBeneficiario.DbType));
			
			//Parametro pCANC_ANS
			param.Add(Connection.CreateParameter("pCANC_ANS", dto.IdCancelamentoAns.DBValue, ParameterDirection.Input, dto.IdCancelamentoAns.DbType));
			
			//Parametro pID_AUTORIZACAO_ANS
			param.Add(Connection.CreateParameter("pID_AUTORIZACAO_ANS", dto.IdAutorizacaoANS.DBValue, ParameterDirection.Input, dto.IdAutorizacaoANS.DbType));
			
			//Parametro pVLPERC
			param.Add(Connection.CreateParameter("pVLPERC", dto.VlPerc.DBValue, ParameterDirection.Input, dto.VlPerc.DbType));
			
			//Parametro pCODPRO
			param.Add(Connection.CreateParameter("pCODPRO", dto.CdProfissionalBeneficiario.DBValue, ParameterDirection.Input, dto.CdProfissionalBeneficiario.DbType));
			
			//Parametro pDATALTBEN
			param.Add(Connection.CreateParameter("pDATALTBEN", dto.DtAlteracaoBeneficiario.DBValue, ParameterDirection.Input, dto.DtAlteracaoBeneficiario.DbType));
			
			//Parametro pCD_EMPRESA
			param.Add(Connection.CreateParameter("pCD_EMPRESA", dto.CdNumericoEmpresa.DBValue, ParameterDirection.Input, dto.CdNumericoEmpresa.DbType));
			
			//Parametro pID_COPART_EXAME
			param.Add(Connection.CreateParameter("pID_COPART_EXAME", dto.IdCopartExameBeneficiario.DBValue, ParameterDirection.Input, dto.IdCopartExameBeneficiario.DbType));
			
			//Parametro pID_COPART_CONSULTA
			param.Add(Connection.CreateParameter("pID_COPART_CONSULTA", dto.IdCopartConsultaBeneficiario.DBValue, ParameterDirection.Input, dto.IdCopartConsultaBeneficiario.DbType));
			
			//Parametro pID_CRONICO
			param.Add(Connection.CreateParameter("pID_CRONICO", dto.IdCronicoBeneficiario.DBValue, ParameterDirection.Input, dto.IdCronicoBeneficiario.DbType));
			
			//Parametro pCO_PART
			param.Add(Connection.CreateParameter("pCO_PART", dto.IdCopartBeneficiario.DBValue, ParameterDirection.Input, dto.IdCopartBeneficiario.DbType));
			
			//Parametro pID_EMISSAO_CARTEIRINHA
			param.Add(Connection.CreateParameter("pID_EMISSAO_CARTEIRINHA", dto.IdCredencialBeneficiario.DBValue, ParameterDirection.Input, dto.IdCredencialBeneficiario.DbType));
			
			//Parametro pVL_COBRANCA_ATUAL
			param.Add(Connection.CreateParameter("pVL_COBRANCA_ATUAL", dto.VlCobrancaAtual.DBValue, ParameterDirection.Input, dto.VlCobrancaAtual.DbType));
			
			//Parametro pDT_COBRANCA_ATUAL
			param.Add(Connection.CreateParameter("pDT_COBRANCA_ATUAL", dto.DataCobrancaAtual.DBValue, ParameterDirection.Input, dto.DataCobrancaAtual.DbType));
			
			//Parametro pDT_REF_COBRANCA_ATUAL
			param.Add(Connection.CreateParameter("pDT_REF_COBRANCA_ATUAL", dto.DataRefCobrancaAtual.DBValue, ParameterDirection.Input, dto.DataRefCobrancaAtual.DbType));
			
			//Parametro pDT_EMISSAO_CARTEIRINHA
			param.Add(Connection.CreateParameter("pDT_EMISSAO_CARTEIRINHA", dto.DtEmissaoCredencial.DBValue, ParameterDirection.Input, dto.DtEmissaoCredencial.DbType));
			
			//Parametro pID_CONTENCIOSO
			param.Add(Connection.CreateParameter("pID_CONTENCIOSO", dto.IdSituacaoJuridico.DBValue, ParameterDirection.Input, dto.IdSituacaoJuridico.DbType));
			
			//Parametro pDS_CONTENCIOSO
			param.Add(Connection.CreateParameter("pDS_CONTENCIOSO", dto.DsJuridicoBeneficiario.DBValue, ParameterDirection.Input, dto.DsJuridicoBeneficiario.DbType));
			
			//Parametro pID_SUSPENSAO_BOLETO
			param.Add(Connection.CreateParameter("pID_SUSPENSAO_BOLETO", dto.IdSuspensaoBoleto.DBValue, ParameterDirection.Input, dto.IdSuspensaoBoleto.DbType));
			
			//Parametro pID_DOENTE_CRONICO
			param.Add(Connection.CreateParameter("pID_DOENTE_CRONICO", dto.IdDoenteCronico.DBValue, ParameterDirection.Input, dto.IdDoenteCronico.DbType));
			
			//Parametro pCD_CID_CRONICO
			param.Add(Connection.CreateParameter("pCD_CID_CRONICO", dto.CdDiagnosticoCronico.DBValue, ParameterDirection.Input, dto.CdDiagnosticoCronico.DbType));
			
			//Parametro pID_REPASSE
			param.Add(Connection.CreateParameter("pID_REPASSE", dto.IdRepasseBeneficiario.DBValue, ParameterDirection.Input, dto.IdRepasseBeneficiario.DbType));
			
			//Parametro pDT_EXCLUSAO_FATURA
			param.Add(Connection.CreateParameter("pDT_EXCLUSAO_FATURA", dto.DtExclusaoFatura.DBValue, ParameterDirection.Input, dto.DtExclusaoFatura.DbType));
			
			//Parametro pCD_LOCAL_REPASSE
			param.Add(Connection.CreateParameter("pCD_LOCAL_REPASSE", dto.CdLocalRepasseBeneficiario.DBValue, ParameterDirection.Input, dto.CdLocalRepasseBeneficiario.DbType));
			
			//Parametro pID_PAC
			param.Add(Connection.CreateParameter("pID_PAC", dto.IdPiacBeneficiario.DBValue, ParameterDirection.Input, dto.IdPiacBeneficiario.DbType));
			
			//Parametro pID_CURATIVO
			param.Add(Connection.CreateParameter("pID_CURATIVO", dto.IdCurativoBeneficiario.DBValue, ParameterDirection.Input, dto.IdCurativoBeneficiario.DbType));
			
			//Parametro pDT_INI_CURATIVO
			param.Add(Connection.CreateParameter("pDT_INI_CURATIVO", dto.DtInicioCurativoBeneficiario.DBValue, ParameterDirection.Input, dto.DtInicioCurativoBeneficiario.DbType));
			
			//Parametro pID_HOMECARE
			param.Add(Connection.CreateParameter("pID_HOMECARE", dto.IdHomecareBeneficiario.DBValue, ParameterDirection.Input, dto.IdHomecareBeneficiario.DbType));
			
			//Parametro pDT_INI_HOMECARE
			param.Add(Connection.CreateParameter("pDT_INI_HOMECARE", dto.DtInicioHomecareBeneficiario.DBValue, ParameterDirection.Input, dto.DtInicioHomecareBeneficiario.DbType));
			
			//Parametro pID_MEDFAMILIA
			param.Add(Connection.CreateParameter("pID_MEDFAMILIA", dto.IdMedicoFamBeneficiario.DBValue, ParameterDirection.Input, dto.IdMedicoFamBeneficiario.DbType));
			
			//Parametro pDT_INI_MEDFAMILIA
			param.Add(Connection.CreateParameter("pDT_INI_MEDFAMILIA", dto.DtInicioMedicoFamBeneficiario.DBValue, ParameterDirection.Input, dto.DtInicioMedicoFamBeneficiario.DbType));
			
			//Parametro pID_SEGURO_REMISSAO
			param.Add(Connection.CreateParameter("pID_SEGURO_REMISSAO", dto.IdSegRemissaoBeneficiario.DBValue, ParameterDirection.Input, dto.IdSegRemissaoBeneficiario.DbType));
			
			//Parametro pID_PLANO_BEM
			param.Add(Connection.CreateParameter("pID_PLANO_BEM", dto.IdPlanoBemBeneficiario.DBValue, ParameterDirection.Input, dto.IdPlanoBemBeneficiario.DbType));
			
			//Parametro pDT_INI_CRONICO
			param.Add(Connection.CreateParameter("pDT_INI_CRONICO", dto.DtInicioCronicoBeneficiario.DBValue, ParameterDirection.Input, dto.DtInicioCronicoBeneficiario.DbType));
			
			//Parametro pDT_INI_PLANO_BEM
			param.Add(Connection.CreateParameter("pDT_INI_PLANO_BEM", dto.DtInicioPlanoBemBeneficiario.DBValue, ParameterDirection.Input, dto.DtInicioPlanoBemBeneficiario.DbType));
			
			//Parametro pDT_INICIO_REPASSE
			param.Add(Connection.CreateParameter("pDT_INICIO_REPASSE", dto.DtInicioRepasseBeneficiario.DBValue, ParameterDirection.Input, dto.DtInicioRepasseBeneficiario.DbType));
			
			//Parametro pDT_FINAL_REPASSE
			param.Add(Connection.CreateParameter("pDT_FINAL_REPASSE", dto.DtFinalRepasseBeneficiario.DBValue, ParameterDirection.Input, dto.DtFinalRepasseBeneficiario.DbType));
			
			//Parametro pCD_EMPRESA_REPASSE
			param.Add(Connection.CreateParameter("pCD_EMPRESA_REPASSE", dto.CdRepasseBeneficiario.DBValue, ParameterDirection.Input, dto.CdRepasseBeneficiario.DbType));
			
			//Parametro pDS_LOCALIDADE
			param.Add(Connection.CreateParameter("pDS_LOCALIDADE", dto.DsLocalRepasseBeneficiario.DBValue, ParameterDirection.Input, dto.DsLocalRepasseBeneficiario.DbType));
			
			//Parametro pID_EMPRESA_REPASSADA
			param.Add(Connection.CreateParameter("pID_EMPRESA_REPASSADA", dto.IdRepasseEmprBeneficiario.DBValue, ParameterDirection.Input, dto.IdRepasseEmprBeneficiario.DbType));
			
			//Parametro pDT_FIM_PLANO_BEM
			param.Add(Connection.CreateParameter("pDT_FIM_PLANO_BEM", dto.DtFimPlanoBemBeneficiario.DBValue, ParameterDirection.Input, dto.DtFimPlanoBemBeneficiario.DbType));
			
			//Parametro pCD_PLANO_BEM
			param.Add(Connection.CreateParameter("pCD_PLANO_BEM", dto.CdPlanoBemBeneficiario.DBValue, ParameterDirection.Input, dto.CdPlanoBemBeneficiario.DbType));
			
			//Parametro pID_ACESSORIO
			param.Add(Connection.CreateParameter("pID_ACESSORIO", dto.IdAcessorioBeneficiario.DBValue, ParameterDirection.Input, dto.IdAcessorioBeneficiario.DbType));
			
			//Parametro pCODNAC
			param.Add(Connection.CreateParameter("pCODNAC", dto.CdNacionalidadeBeneficiario.DBValue, ParameterDirection.Input, dto.CdNacionalidadeBeneficiario.DbType));
			
			//Parametro pCODPAIS
			param.Add(Connection.CreateParameter("pCODPAIS", dto.CdPaisBeneficiario.DBValue, ParameterDirection.Input, dto.CdPaisBeneficiario.DbType));
			
			//Parametro pORGAO_EMISSOR_RG
			param.Add(Connection.CreateParameter("pORGAO_EMISSOR_RG", dto.CdOrgaoEmissorBeneficiario.DBValue, ParameterDirection.Input, dto.CdOrgaoEmissorBeneficiario.DbType));
			
			//Parametro pPAIS_EMISSOR_RG
			param.Add(Connection.CreateParameter("pPAIS_EMISSOR_RG", dto.NmPaisEmissorBeneficiario.DBValue, ParameterDirection.Input, dto.NmPaisEmissorBeneficiario.DbType));
			
			//Parametro pPISPASEP
			param.Add(Connection.CreateParameter("pPISPASEP", dto.CdPisPasepBeneficiario.DBValue, ParameterDirection.Input, dto.CdPisPasepBeneficiario.DbType));
			
			//Parametro pIND_ACIDENTE_TRABALHO
			param.Add(Connection.CreateParameter("pIND_ACIDENTE_TRABALHO", dto.IdAcidenteTrabalhoBeneficiario.DBValue, ParameterDirection.Input, dto.IdAcidenteTrabalhoBeneficiario.DbType));
			
			//Parametro pCODPAC
			param.Add(Connection.CreateParameter("pCODPAC", dto.CdPiacBeneficiario.DBValue, ParameterDirection.Input, dto.CdPiacBeneficiario.DbType));
			
			//Parametro pDOCBEN
			param.Add(Connection.CreateParameter("pDOCBEN", dto.CdDocumentoBeneficiario.DBValue, ParameterDirection.Input, dto.CdDocumentoBeneficiario.DbType));
			
			//Parametro pCOD_NATDOC
			param.Add(Connection.CreateParameter("pCOD_NATDOC", dto.CdNaturezaDocBeneficiario.DBValue, ParameterDirection.Input, dto.CdNaturezaDocBeneficiario.DbType));
			
			//Parametro pDT_EXPEDOC
			param.Add(Connection.CreateParameter("pDT_EXPEDOC", dto.DtExpedDocBeneficiario.DBValue, ParameterDirection.Input, dto.DtExpedDocBeneficiario.DbType));
			
			//Parametro pCOD_ATIVPRINC
			param.Add(Connection.CreateParameter("pCOD_ATIVPRINC", dto.CdAtividadePrincipalBeneficiario.DBValue, ParameterDirection.Input, dto.CdAtividadePrincipalBeneficiario.DbType));
			
			//Parametro pIDOPER
			param.Add(Connection.CreateParameter("pIDOPER", dto.IdOperacao.DBValue, ParameterDirection.Input, dto.IdOperacao.DbType));
			
			//Parametro pID_CARTAO_AUTORIZADOR
			param.Add(Connection.CreateParameter("pID_CARTAO_AUTORIZADOR", dto.IdCartaoAutorizador.DBValue, ParameterDirection.Input, dto.IdCartaoAutorizador.DbType));
			
			//Parametro pDT_CARTAO_AUTORIZADOR
			param.Add(Connection.CreateParameter("pDT_CARTAO_AUTORIZADOR", dto.DataCartaoAutorizador.DBValue, ParameterDirection.Input, dto.DataCartaoAutorizador.DbType));
			
			//Parametro pNM_REDUZIDO
			param.Add(Connection.CreateParameter("pNM_REDUZIDO", dto.NomeReduzido.DBValue, ParameterDirection.Input, dto.NomeReduzido.DbType));
			
			//Parametro pDS_LOGIN
			param.Add(Connection.CreateParameter("pDS_LOGIN", dto.NmLogin.DBValue, ParameterDirection.Input, dto.NmLogin.DbType));
			
			//Parametro pCD_CCO
			param.Add(Connection.CreateParameter("pCD_CCO", dto.CdContrato.DBValue, ParameterDirection.Input, dto.CdContrato.DbType));
			
			//Parametro pDV_CCO
			param.Add(Connection.CreateParameter("pDV_CCO", dto.DgContrato.DBValue, ParameterDirection.Input, dto.DgContrato.DbType));
			
			//Parametro pCDPLANOANS_ORIGEM
			param.Add(Connection.CreateParameter("pCDPLANOANS_ORIGEM", dto.CodigoPlanoANSOrigem.DBValue, ParameterDirection.Input, dto.CodigoPlanoANSOrigem.DbType));
			
			#endregion	

			// Executa o Procedimento
			Connection.ExecuteCommand(query, ref param, CommandType.StoredProcedure);						

		}	
	}
}