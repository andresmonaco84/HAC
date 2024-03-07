create or replace procedure PRC_INT_REL_EVOLUCAO
  (
pATD_ATE_DT_ATENDIMENTO_INI IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE,
pATD_ATE_DT_ATENDIMENTO_FIM IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE,
pATD_ATE_HR_ATENDIMENTO_INI IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_HR_ATENDIMENTO%TYPE DEFAULT NULL,
pATD_ATE_HR_ATENDIMENTO_FIM IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_HR_ATENDIMENTO%TYPE DEFAULT NULL,
pATD_ATE_FL_CARATER_SOLIC_U IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_FL_CARATER_SOLIC%TYPE DEFAULT NULL,
pATD_ATE_FL_CARATER_SOLIC_E IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_FL_CARATER_SOLIC%TYPE DEFAULT NULL,
pFAIXA_ETARIA_INI varchar2 default null,
pFAIXA_ETARIA_FIM varchar2 default null,
pPERMANENCIA_INI varchar2 default null,
pPERMANENCIA_FIM varchar2 default null,
pEVOLUCAO varchar2 default null,
pCAD_UNI_ID_UNIDADE IN TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%TYPE,
pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
pCAD_SET_NR_ANDAR IN TB_CAD_SET_SETOR.CAD_SET_NR_ANDAR%TYPE DEFAULT NULL,
pATD_AIC_TP_SITUACAO_PAC IN TB_ATD_AIC_ATE_INT_COMPL.ATD_AIC_TP_SITUACAO_PAC%TYPE DEFAULT NULL,
pATD_ATE_TP_PACIENTE_I IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_TP_PACIENTE%TYPE DEFAULT NULL,
pATD_ATE_TP_PACIENTE_E IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_TP_PACIENTE%TYPE DEFAULT NULL,
pCAD_QLE_TP_QUARTO_LEITO IN TB_CAD_QLE_QUARTO_LEITO.CAD_QLE_TP_QUARTO_LEITO%TYPE DEFAULT NULL,
pTIS_TIN_CD_INTER IN TB_ATD_AIC_ATE_INT_COMPL.TIS_TIN_CD_INTERNACAO%TYPE DEFAULT NULL,
pTIS_TRI_CD_TP_REGINT IN TB_ATD_AIC_ATE_INT_COMPL.TIS_TRI_CD_REGINTENNACAO%TYPE DEFAULT NULL,
pCAD_PLA_CD_TIPOPLANO_GB IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL, --ACS
pCAD_PLA_CD_TIPOPLANO_PL IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL, --ACS
pCAD_PLA_CD_TIPOPLANO_FU IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
pCAD_PLA_CD_TIPOPLANO_NP IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
pCAD_PLA_CD_TIPOPLANO_PA IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
pCAD_PLA_CD_TIPOPLANO_SP IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
pCAD_PRD_ID IN TB_CAD_PRD_PRODUTO.CAD_PRD_ID%TYPE DEFAULT NULL,
pCAD_CID_CD_CID10 IN TB_CAD_CID_CID10.CAD_CID_CD_CID10%TYPE DEFAULT NULL,
pTIS_TAC_CD_TIPO_ACOMODACAO IN TB_TIS_TAC_TIPO_ACOMODACAO.TIS_TAC_CD_TIPO_ACOMODACAO%TYPE DEFAULT NULL,
pTIS_CBO_CD_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%TYPE DEFAULT NULL,
pCAD_PRO_ID_PROF_EXEC IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%TYPE DEFAULT NULL,
pCAD_PES_TP_SEXO IN TB_CAD_PES_PESSOA.CAD_PES_TP_SEXO%TYPE DEFAULT NULL,
pCAD_CNV_ID_CONVENIO     IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
pCAD_PLA_ID_PLANO        IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE DEFAULT NULL,
pCAD_CGC_ID_G IN TB_CAD_CNV_CONVENIO.CAD_CGC_ID%TYPE DEFAULT NULL,
pCAD_CGC_ID_E IN TB_CAD_CNV_CONVENIO.CAD_CGC_ID%TYPE DEFAULT NULL,
io_cursor              OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_INT_REL_EVOLUCAO
  *
  *    Data Criacao:  09/09/2009   Por: pedro
  *    Funcao: Popula o Relatorio de Evolucao dos Pacientes Internados
  *
  *    Data Alteracao:  25/09/2014 Por: Cristiane
  *    Alteracao: Desconsiderar repeticao de internacao por registro de
  *               multipla evolucao
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
  SELECT
               ATD.ATD_ATE_ID,
               COUNT(distinct ATD.ATD_ATE_ID) over() TOTAL,
               DECODE(AIC.ATD_AIC_TP_SITUACAO_PAC,'I','INTERNADO','A','ALTA') ATD_AIC_TP_SITUACAO_PAC,
               CASE WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'A' AND INA.ATD_INA_DT_ALTA_ADM IS NOT NULL THEN
                         nvl(Round(INA.ATD_INA_DT_ALTA_ADM - ATD.ATD_ATE_DT_ATENDIMENTO),0)
                    WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'I' THEN
                         nvl(Round(sysdate-ATD.ATD_ATE_DT_ATENDIMENTO),0)
                         ELSE  0
                END PERMANENCIA,
                CASE WHEN (CASE WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'A' THEN
                        nvl(Round(INA.ATD_INA_DT_ALTA_ADM - ATD.ATD_ATE_DT_ATENDIMENTO),0)
                        WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'I' THEN
                        nvl(Round(sysdate-ATD.ATD_ATE_DT_ATENDIMENTO),0)
                        ELSE  0
                        END) > 10 THEN 10
                     WHEN (CASE WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'A' THEN
                        nvl(Round(INA.ATD_INA_DT_ALTA_ADM - ATD.ATD_ATE_DT_ATENDIMENTO),0)
                        WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'I' THEN
                        nvl(Round(sysdate-ATD.ATD_ATE_DT_ATENDIMENTO),0)
                        ELSE  0
                        END) >= 8 THEN 8
                     WHEN (CASE WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'A' THEN
                        nvl(Round(INA.ATD_INA_DT_ALTA_ADM - ATD.ATD_ATE_DT_ATENDIMENTO),0)
                        WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'I' THEN
                        nvl(Round(sysdate-ATD.ATD_ATE_DT_ATENDIMENTO),0)
                        ELSE  0
                        END) >= 4 THEN 4
                     WHEN (CASE WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'A' THEN
                        nvl(Round(INA.ATD_INA_DT_ALTA_ADM - ATD.ATD_ATE_DT_ATENDIMENTO),0)
                        WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'I' THEN
                        nvl(Round(sysdate-ATD.ATD_ATE_DT_ATENDIMENTO),0)
                        ELSE  0
                        END) >= 0 THEN 0
                END     QUEBRA_PERMANENCIA,
               ATD.ATD_ATE_DT_ATENDIMENTO,
               DECODE(ATD_ATE_TP_PACIENTE,'I','INTERNO','E','EXTERNO') ATD_ATE_TP_PACIENTE,
               ATD.ATD_ATE_HR_ATENDIMENTO,
               INA.ATD_INA_DT_ALTA_ADM,
               INA.TIS_MSI_CD_MOTIVOSAIDAINT,
               ATD.ATD_ATE_FL_CARATER_SOLIC,
               UNI.CAD_UNI_DS_UNIDADE UNIDADE,
               LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
               CASE WHEN IMS_SETOR.CAD_SET_ID_SETOR IS NOT NULL AND IML_QLE.CAD_SET_ID IS NULL THEN IMS_SETOR.CAD_SET_DS_SETOR
               ELSE IML_QLE.CAD_SET_DS_SETOR END CAD_SET_DS_SETOR,
               CASE WHEN IMS_SETOR.CAD_SET_ID_SETOR IS NOT NULL AND IML_QLE.CAD_SET_ID IS NULL THEN IMS_SETOR.CAD_SET_NR_ANDAR
               ELSE IML_QLE.CAD_SET_NR_ANDAR END CAD_SET_NR_ANDAR,
               PAC.CAD_PAC_CD_CREDENCIAL,
               PAC.CAD_PAC_NR_PRONTUARIO,
               PES.CAD_PES_NM_PESSOA PACIENTE,
               PES.CAD_PES_TP_SEXO,
               CBOS.TIS_CBO_CD_CBOS_HAC,
               CNV.CAD_CNV_CD_HAC_PRESTADOR,
               PLA.CAD_PLA_CD_TIPOPLANO,
               PLA.CAD_PLA_CD_PLANO_HAC,
               PRO.CAD_PRO_NM_NOME CAD_PRO_NM_NOME_ATD,
               PRO_IEP.CAD_PRO_NM_NOME CAD_PRO_NM_NOME_IEP,
               PRO.CAD_PRO_NR_CONSELHO CAD_PRO_NR_CONSELHO_ATD,
               PRO_IEP.CAD_PRO_NR_CONSELHO CAD_PRO_NR_CONSELHO_IEP,
               PRO_ALTA.CAD_PRO_NR_CONSELHO CAD_PRO_NR_CONSELHO_ALTA,
               IDG.ATD_IDG_CD_CIDPRINCIPAL,
               TIN.TIS_TIN_DS_INTERNACAO,
               TRI.TIS_TRI_DS_TP_REGINTERNACAO,
               FLOOR(FLOOR(MONTHS_BETWEEN(DECODE(INA.ATD_INA_DT_ALTA_ADM,NULL,ATD.ATD_ATE_DT_ATENDIMENTO,INA.ATD_INA_DT_ALTA_ADM), PES.CAD_PES_DT_NASCIMENTO)) / 12) idade,
               Floor(SYSDATE - IEP.ATD_IEP_DT_EVOLUCAO) EVOLUCAO_A_PARTIR_DE,
               IEP.ATD_IEP_DT_EVOLUCAO,
               IEP.ATD_IEP_HR_EVOLUCAO,
               IEP.ATD_IEP_DS_EVOLUCAO,
               case WHEN CID_IEP.CAD_CID_DS_CID10 IS NOT NULL THEN
                         CID_IEP.CAD_CID_CD_CID10 || ' - ' || CID_IEP.CAD_CID_DS_CID10
                    ELSE ''
               END  CID_EVOLUCAO,
               ATD.CAD_CID_CD_CID10 CID_CD_ATD,
               CID_ATD.CAD_CID_DS_CID10 CID_DS_ATD,
               TO_CHAR(pes.cad_pes_dt_nascimento,'dd/MM/yyyy') cad_pes_dt_nascimento,
               CASE WHEN IMS_SETOR.CAD_SET_ID_SETOR IS NOT NULL AND IML_QLE.CAD_SET_ID IS NULL THEN IMS_SETOR.ATD_IMS_DT_ENTRADA
                    ELSE IML_QLE.ATD_IML_DT_ENTRADA
               END ATD_IML_DT_ENTRADA,
               CASE WHEN IMS_SETOR.CAD_SET_ID_SETOR IS NOT NULL AND IML_QLE.CAD_SET_ID IS NULL THEN IMS_SETOR.ATD_IMS_HR_ENTRADA
                    ELSE IML_QLE.ATD_IML_HR_ENTRADA
               END ATD_IML_HR_ENTRADA,
               CASE WHEN IMS_SETOR.CAD_SET_ID_SETOR IS NOT NULL AND IML_QLE.CAD_SET_ID IS NULL THEN NULL
                    ELSE DECODE(IML_QLE.CAD_QLE_TP_QUARTO_LEITO,'I','INTERNO','E','EXTRA')
               END CAD_QLE_TP_QUARTO_LEITO ,
               CASE WHEN IMS_SETOR.CAD_SET_ID_SETOR IS NOT NULL AND IML_QLE.CAD_SET_ID IS NULL THEN IMS_SETOR.DS_SETOR
                    ELSE TO_CHAR(IML_QLE.CAD_QLE_NR_QUARTO)
               END CAD_QLE_NR_QUARTO,
               CASE WHEN IMS_SETOR.CAD_SET_ID_SETOR IS NOT NULL AND IML_QLE.CAD_SET_ID IS NULL THEN NULL
                    ELSE IML_QLE.CAD_QLE_NR_LEITO
               END CAD_QLE_NR_LEITO,
               CASE WHEN CNV.CAD_CNV_CD_HAC_PRESTADOR = 'SD01' THEN
                DECODE(FNC_VERIFICA_INSGER( TO_CHAR(PLA.CAD_PLA_CD_PLANO_HAC),
                                            TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,0,3)) ,
                                            TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,4,7)),
                                            TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,11,2))),0,'',1,'INST.GERIATRIA',2,'INST.GERIATRIA',4,'AMB. ALTA CRITICOS')
               ELSE '' END GER
   FROM
                TB_ATD_ATE_ATENDIMENTO    ATD
  JOIN          TB_ATD_AIC_ATE_INT_COMPL  AIC
  ON            AIC.ATD_ATE_ID          = ATD.ATD_ATE_ID
  JOIN          TB_CAD_PAC_PACIENTE       PAC
  ON            PAC.CAD_PAC_ID_PACIENTE = fnc_buscar_paciente_atual(ATD.ATD_ATE_ID)
  JOIN          TB_CAD_PES_PESSOA         PES
  ON            PES.CAD_PES_ID_PESSOA   = PAC.CAD_PES_ID_PESSOA
  JOIN          TB_CAD_CNV_CONVENIO       CNV
  ON            CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
  JOIN          TB_CAD_PLA_PLANO          PLA
  ON            PLA.CAD_PLA_ID_PLANO    = PAC.CAD_PLA_ID_PLANO
  LEFT JOIN     TB_ATD_INA_INT_ALTA       INA
  ON            INA.ATD_ATE_ID          = ATD.ATD_ATE_ID
  JOIN          TB_TIS_CBO_CBOS           CBOS
  ON            CBOS.TIS_CBO_CD_CBOS    = ATD.TIS_CBO_CD_CBOS
  JOIN          TB_CAD_UNI_UNIDADE         UNI
  ON            UNI.CAD_UNI_ID_UNIDADE   = ATD.CAD_UNI_ID_UNIDADE
  JOIN          TB_CAD_LAT_LOCAL_ATENDIMENTO LAT
  ON            LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO

  JOIN          TB_CAD_PRO_PROFISSIONAL     PRO
  ON            PRO.CAD_PRO_ID_PROFISSIONAL = ATD.CAD_PRO_ID_PROF_EXEC

  JOIN          TB_TIS_TIN_TP_INTERNACAO    TIN
  ON            TIN.TIS_TIN_CD_INTERNACAO = AIC.TIS_TIN_CD_INTERNACAO
  JOIN          TB_TIS_TRI_TP_REGINTERNACAO TRI
  ON            TRI.TIS_TRI_CD_TP_REGINTERNACAO = AIC.TIS_TRI_CD_REGINTENNACAO
  LEFT JOIN     TB_ATD_IDG_INT_DIAGNOSTICO  IDG
  ON            IDG.ATD_ATE_ID            = ATD.ATD_ATE_ID
  LEFT JOIN     TB_CAD_PRO_PROFISSIONAL     PRO_ALTA
  ON            PRO_ALTA.CAD_PRO_ID_PROFISSIONAL = INA.CAD_PRO_ID_PROFISSIONAL
  LEFT JOIN     TB_ATD_IEP_INT_EVOL_PACIENTE IEP
  ON            IEP.ATD_ATE_ID            = ATD.ATD_ATE_ID
  LEFT JOIN     TB_CAD_PRO_PROFISSIONAL     PRO_IEP
  ON            PRO_IEP.CAD_PRO_ID_PROFISSIONAL = IEP.CAD_PRO_ID_PROFISSIONAL
  LEFT JOIN     TB_CAD_CID_CID10            CID_IEP
  ON            CID_IEP.CAD_CID_CD_CID10  = IEP.CAD_CID_CD_CID10
  LEFT JOIN     TB_CAD_CID_CID10            CID_ATD
  ON            CID_ATD.CAD_CID_CD_CID10  = ATD.CAD_CID_CD_CID10
  LEFT JOIN  ( SELECT     QLE.CAD_QLE_ID, QLE.CAD_SET_ID, SETOR.CAD_SET_DS_SETOR, SETOR.CAD_SET_NR_ANDAR, QLE.CAD_QLE_NR_QUARTO, QLE.CAD_QLE_NR_LEITO,
                          IML.ATD_ATE_ID, QLE.TIS_TAC_CD_TIPO_ACOMODACAO, QLE.CAD_QLE_TP_QUARTO_LEITO ,
                          IML.ATD_IML_DT_ENTRADA, IML.ATD_IML_HR_ENTRADA
                 FROM      TB_ATD_IML_INT_MOV_LEITO IML
                 LEFT JOIN TB_CAD_QLE_QUARTO_LEITO QLE
                 ON        QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
                 JOIN      TB_ATD_ATE_ATENDIMENTO ATD2
                 ON        ATD2.ATD_ATE_ID = IML.ATD_ATE_ID
                 JOIN          TB_CAD_SET_SETOR            SETOR
                 ON            SETOR.CAD_SET_ID            = QLE.CAD_SET_ID
               WHERE    IML.ATD_IML_FL_STATUS = 'A' AND  FNC_JUNTAR_DATA_HORA(IML.ATD_IML_DT_ENTRADA,IML.ATD_IML_HR_ENTRADA) =
                                         (SELECT MAX(FNC_JUNTAR_DATA_HORA(IML3.ATD_IML_DT_ENTRADA,IML3.ATD_IML_HR_ENTRADA)) FROM TB_ATD_IML_INT_MOV_LEITO IML3
                            WHERE IML3.ATD_ATE_ID = ATD2.ATD_ATE_ID AND IML3.ATD_IML_FL_STATUS = 'A')
                           AND  SETOR.CAD_SET_ID NOT IN (2072,2312,5,140,2472)
                 aND SETOR.CAD_SET_FL_PERMITEINTERN_OK = 'S'
                 AND SETOR.CAD_SET_FL_ATIVO_OK = 'S'
              )  IML_QLE
  ON IML_QLE.ATD_ATE_ID = ATD.ATD_ATE_ID
  LEFT JOIN (SELECT IMS.ATD_ATE_ID, IMS.CAD_SET_ID_SETOR CAD_SET_ID_SETOR, SETOR.CAD_SET_DS_SETOR, SETOR.CAD_SET_NR_ANDAR, IMS.ATD_IMS_DT_ENTRADA ATD_IMS_DT_ENTRADA,
             IMS.ATD_IMS_HR_ENTRADA ATD_IMS_HR_ENTRADA,
             CASE WHEN SETOR.CAD_SET_DS_SETOR LIKE 'CENTRO CIRURGICO' THEN 'C.CIRURGICO'
             ELSE 'ADMISSAO'
             END DS_SETOR
             FROM TB_ATD_IMS_INT_MOV_SETOR IMS
             INNER JOIN TB_CAD_SET_SETOR SETOR
             ON SETOR.CAD_SET_ID = IMS.CAD_SET_ID_SETOR
             INNER JOIN TB_ATD_ATE_ATENDIMENTO ATE
             ON IMS.ATD_ATE_ID = ATE.ATD_ATE_ID
             WHERE IMS.ATD_IMS_DT_ENTRADA = ATE.ATD_ATE_DT_ATENDIMENTO
             AND IMS.ATD_IMS_HR_ENTRADA = ATE.ATD_ATE_HR_ATENDIMENTO
             AND IMS.ATD_IMS_FL_STATUS = 'A'
             AND IMS.ATD_IMS_DT_SAIDA IS NULL
              aND SETOR.CAD_SET_FL_PERMITEINTERN_OK = 'S'
              AND SETOR.CAD_SET_FL_ATIVO_OK = 'S'
             AND NOT EXISTS
             (SELECT IML.ATD_ATE_ID
             FROM TB_ATD_IML_INT_MOV_LEITO IML
             WHERE IML.ATD_ATE_ID = ATE.ATD_ATE_ID)
             AND NOT EXISTS
             (SELECT IMC.ATD_ATE_ID
             FROM TB_ATD_IMC_INT_MOV_CLINICA IMC
             WHERE IMC.ATD_ATE_ID = ATE.ATD_ATE_ID)) IMS_SETOR
  ON IMS_SETOR.ATD_ATE_ID = ATD.ATD_ATE_ID
  WHERE
       (pCAD_UNI_ID_UNIDADE IS NULL OR ATD.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
   AND (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
   AND ((pCAD_SET_ID IS NULL OR IML_QLE.CAD_SET_ID = pCAD_SET_ID)
   or (pCAD_SET_ID IS NULL OR IMS_SETOR.CAD_SET_ID_SETOR = pCAD_SET_ID))
   AND (ATD.ATD_ATE_FL_STATUS = 'A') AND (IMS_SETOR.CAD_SET_ID_SETOR IS NOT NULL OR IML_QLE.CAD_SET_ID IS NOT NULL)
   AND ((pCAD_SET_NR_ANDAR IS NULL OR IML_QLE.CAD_SET_NR_ANDAR = pCAD_SET_NR_ANDAR)
   or (pCAD_SET_NR_ANDAR IS NULL OR IML_QLE.CAD_SET_NR_ANDAR = pCAD_SET_NR_ANDAR))
   AND (pATD_AIC_TP_SITUACAO_PAC IS NULL OR AIC.ATD_AIC_TP_SITUACAO_PAC = pATD_AIC_TP_SITUACAO_PAC)
   AND (pATD_ATE_HR_ATENDIMENTO_INI IS NULL OR ATD.ATD_ATE_HR_ATENDIMENTO >= pATD_ATE_HR_ATENDIMENTO_INI )
   AND (pATD_ATE_HR_ATENDIMENTO_FIM IS NULL OR INA.ATD_INA_HR_ALTA_ADM <= pATD_ATE_HR_ATENDIMENTO_FIM)
   AND (pTIS_CBO_CD_CBOS IS NULL OR ATD.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS)
   AND (pCAD_PRO_ID_PROF_EXEC IS NULL OR ATD.CAD_PRO_ID_PROF_EXEC = pCAD_PRO_ID_PROF_EXEC)
   AND (pCAD_CNV_ID_CONVENIO IS NULL OR PAC.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
   AND (pCAD_PLA_ID_PLANO IS NULL OR PAC.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
   AND (pATD_ATE_TP_PACIENTE_I IS NOT NULL AND ATD.ATD_ATE_TP_PACIENTE = 'I'
    OR pATD_ATE_TP_PACIENTE_E IS NOT NULL AND ATD.ATD_ATE_TP_PACIENTE = 'E')
   AND (pCAD_PRD_ID IS NULL OR AIC.CAD_PRD_ID = pCAD_PRD_ID)
   AND (pCAD_CID_CD_CID10 IS NULL OR CID_IEP.CAD_CID_CD_CID10 = pCAD_CID_CD_CID10)
   AND (pCAD_PES_TP_SEXO IS NULL OR PES.CAD_PES_TP_SEXO = pCAD_PES_TP_SEXO)
   AND (pTIS_TAC_CD_TIPO_ACOMODACAO IS NULL OR IML_QLE.TIS_TAC_CD_TIPO_ACOMODACAO = pTIS_TAC_CD_TIPO_ACOMODACAO)
   AND (pCAD_QLE_TP_QUARTO_LEITO IS NULL OR IML_QLE.CAD_QLE_TP_QUARTO_LEITO = pCAD_QLE_TP_QUARTO_LEITO)
   AND (pTIS_TIN_CD_INTER IS NULL OR TIN.TIS_TIN_CD_INTERNACAO = pTIS_TIN_CD_INTER)
   AND (pTIS_TRI_CD_TP_REGINT IS NULL OR TRI.TIS_TRI_CD_TP_REGINTERNACAO = pTIS_TRI_CD_TP_REGINT)
   AND (pCAD_CGC_ID_G IS NOT NULL AND CNV.CAD_CGC_ID = 1 OR pCAD_CGC_ID_E IS NOT NULL AND CNV.CAD_CGC_ID = 2)
    AND (pCAD_PLA_CD_TIPOPLANO_GB IS not NULL and PLA.CAD_PLA_CD_TIPOPLANO = 'GB'
   OR pCAD_PLA_CD_TIPOPLANO_PL IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'PL'
   OR pCAD_PLA_CD_TIPOPLANO_PA IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'PA'
   OR pCAD_PLA_CD_TIPOPLANO_SP IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'SP'
   OR pCAD_PLA_CD_TIPOPLANO_FU IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'FU'
   OR pCAD_PLA_CD_TIPOPLANO_NP IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'NP')
   AND (pATD_ATE_FL_CARATER_SOLIC_U IS NOT NULL AND ATD.ATD_ATE_FL_CARATER_SOLIC = 'U'
   OR pATD_ATE_FL_CARATER_SOLIC_E IS NOT NULL AND ATD.ATD_ATE_FL_CARATER_SOLIC = 'E')
   AND (pATD_ATE_DT_ATENDIMENTO_INI IS NULL OR ATD.ATD_ATE_DT_ATENDIMENTO >= pATD_ATE_DT_ATENDIMENTO_INI)
   AND (pATD_ATE_DT_ATENDIMENTO_FIM IS NULL OR ATD.ATD_ATE_DT_ATENDIMENTO <= pATD_ATE_DT_ATENDIMENTO_FIM)
   AND (pEVOLUCAO IS NULL OR Floor(SYSDATE - IEP.ATD_IEP_DT_EVOLUCAO) >= pEVOLUCAO)
   AND (pFAIXA_ETARIA_INI IS NULL OR (FLOOR(FLOOR(MONTHS_BETWEEN(DECODE(INA.ATD_INA_DT_ALTA_ADM,NULL,ATD.ATD_ATE_DT_ATENDIMENTO,INA.ATD_INA_DT_ALTA_ADM), PES.CAD_PES_DT_NASCIMENTO)) / 12) >= pFAIXA_ETARIA_INI))
   and (pFAIXA_ETARIA_FIM IS NULL OR (FLOOR(FLOOR(MONTHS_BETWEEN(DECODE(INA.ATD_INA_DT_ALTA_ADM,NULL,ATD.ATD_ATE_DT_ATENDIMENTO,INA.ATD_INA_DT_ALTA_ADM), PES.CAD_PES_DT_NASCIMENTO)) / 12) <= pFAIXA_ETARIA_FIM))
   AND  (pPERMANENCIA_INI IS NULL OR
         (CASE WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'A' THEN
                    nvl(Round(INA.ATD_INA_DT_ALTA_ADM - ATD.ATD_ATE_DT_ATENDIMENTO),0)
                    WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'I' THEN
                    nvl(Round(sysdate-ATD.ATD_ATE_DT_ATENDIMENTO),0)
                    ELSE  0
         END >=  pPERMANENCIA_INI)
         )
   AND  (pPERMANENCIA_FIM IS NULL OR
         (CASE WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'A' THEN
                   nvl(Round(INA.ATD_INA_DT_ALTA_ADM - ATD.ATD_ATE_DT_ATENDIMENTO),0)
                   WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'I' THEN
                   nvl(Round(sysdate-ATD.ATD_ATE_DT_ATENDIMENTO),0)
                   ELSE  0
        END <= pPERMANENCIA_FIM)
        )
        group by
               ATD.ATD_ATE_ID,
               DECODE(AIC.ATD_AIC_TP_SITUACAO_PAC,'I','INTERNADO','A','ALTA') ,
               CASE WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'A' AND INA.ATD_INA_DT_ALTA_ADM IS NOT NULL THEN
                         nvl(Round(INA.ATD_INA_DT_ALTA_ADM - ATD.ATD_ATE_DT_ATENDIMENTO),0)
                    WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'I' THEN
                         nvl(Round(sysdate-ATD.ATD_ATE_DT_ATENDIMENTO),0)
                         ELSE  0
                END ,
                CASE WHEN (CASE WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'A' THEN
                        nvl(Round(INA.ATD_INA_DT_ALTA_ADM - ATD.ATD_ATE_DT_ATENDIMENTO),0)
                        WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'I' THEN
                        nvl(Round(sysdate-ATD.ATD_ATE_DT_ATENDIMENTO),0)
                        ELSE  0
                        END) > 10 THEN 10
                     WHEN (CASE WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'A' THEN
                        nvl(Round(INA.ATD_INA_DT_ALTA_ADM - ATD.ATD_ATE_DT_ATENDIMENTO),0)
                        WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'I' THEN
                        nvl(Round(sysdate-ATD.ATD_ATE_DT_ATENDIMENTO),0)
                        ELSE  0
                        END) >= 8 THEN 8
                     WHEN (CASE WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'A' THEN
                        nvl(Round(INA.ATD_INA_DT_ALTA_ADM - ATD.ATD_ATE_DT_ATENDIMENTO),0)
                        WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'I' THEN
                        nvl(Round(sysdate-ATD.ATD_ATE_DT_ATENDIMENTO),0)
                        ELSE  0
                        END) >= 4 THEN 4
                     WHEN (CASE WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'A' THEN
                        nvl(Round(INA.ATD_INA_DT_ALTA_ADM - ATD.ATD_ATE_DT_ATENDIMENTO),0)
                        WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'I' THEN
                        nvl(Round(sysdate-ATD.ATD_ATE_DT_ATENDIMENTO),0)
                        ELSE  0
                        END) >= 0 THEN 0
                END     ,
               ATD.ATD_ATE_DT_ATENDIMENTO,
               DECODE(ATD_ATE_TP_PACIENTE,'I','INTERNO','E','EXTERNO') ,
               ATD.ATD_ATE_HR_ATENDIMENTO,
               INA.ATD_INA_DT_ALTA_ADM,
               INA.TIS_MSI_CD_MOTIVOSAIDAINT,
               ATD.ATD_ATE_FL_CARATER_SOLIC,
               UNI.CAD_UNI_DS_UNIDADE,
               LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
               CASE WHEN IMS_SETOR.CAD_SET_ID_SETOR IS NOT NULL AND IML_QLE.CAD_SET_ID IS NULL THEN IMS_SETOR.CAD_SET_DS_SETOR
               ELSE IML_QLE.CAD_SET_DS_SETOR END,
               CASE WHEN IMS_SETOR.CAD_SET_ID_SETOR IS NOT NULL AND IML_QLE.CAD_SET_ID IS NULL THEN IMS_SETOR.CAD_SET_NR_ANDAR
               ELSE IML_QLE.CAD_SET_NR_ANDAR END,
               PAC.CAD_PAC_CD_CREDENCIAL,
               PAC.CAD_PAC_NR_PRONTUARIO,
               PES.CAD_PES_NM_PESSOA ,
               PES.CAD_PES_TP_SEXO,
               CBOS.TIS_CBO_CD_CBOS_HAC,
               CNV.CAD_CNV_CD_HAC_PRESTADOR,
               PLA.CAD_PLA_CD_TIPOPLANO,
               PLA.CAD_PLA_CD_PLANO_HAC,
               PRO.CAD_PRO_NM_NOME,
               PRO_IEP.CAD_PRO_NM_NOME,
               PRO.CAD_PRO_NR_CONSELHO,
               PRO_IEP.CAD_PRO_NR_CONSELHO,

               PRO_ALTA.CAD_PRO_NR_CONSELHO ,
               IDG.ATD_IDG_CD_CIDPRINCIPAL,
               TIN.TIS_TIN_DS_INTERNACAO,
               TRI.TIS_TRI_DS_TP_REGINTERNACAO,
               FLOOR(FLOOR(MONTHS_BETWEEN(DECODE(INA.ATD_INA_DT_ALTA_ADM,NULL,ATD.ATD_ATE_DT_ATENDIMENTO,INA.ATD_INA_DT_ALTA_ADM), PES.CAD_PES_DT_NASCIMENTO)) / 12),
               Floor(SYSDATE - IEP.ATD_IEP_DT_EVOLUCAO) ,
               IEP.ATD_IEP_DT_EVOLUCAO,
               IEP.ATD_IEP_HR_EVOLUCAO,
               IEP.ATD_IEP_DS_EVOLUCAO,
               case WHEN CID_IEP.CAD_CID_DS_CID10 IS NOT NULL THEN
                         CID_IEP.CAD_CID_CD_CID10 || ' - ' || CID_IEP.CAD_CID_DS_CID10
                    ELSE ''
               END ,
               ATD.CAD_CID_CD_CID10,
               CID_ATD.CAD_CID_DS_CID10,
               TO_CHAR(pes.cad_pes_dt_nascimento,'dd/MM/yyyy'),
               CASE WHEN IMS_SETOR.CAD_SET_ID_SETOR IS NOT NULL AND IML_QLE.CAD_SET_ID IS NULL THEN IMS_SETOR.ATD_IMS_DT_ENTRADA
               ELSE IML_QLE.ATD_IML_DT_ENTRADA END ,
               CASE WHEN IMS_SETOR.CAD_SET_ID_SETOR IS NOT NULL AND IML_QLE.CAD_SET_ID IS NULL THEN IMS_SETOR.ATD_IMS_HR_ENTRADA
               ELSE IML_QLE.ATD_IML_HR_ENTRADA END ,
               CASE WHEN IMS_SETOR.CAD_SET_ID_SETOR IS NOT NULL AND IML_QLE.CAD_SET_ID IS NULL THEN NULL
               ELSE DECODE(IML_QLE.CAD_QLE_TP_QUARTO_LEITO,'I','INTERNO','E','EXTRA') END  ,
               CASE WHEN IMS_SETOR.CAD_SET_ID_SETOR IS NOT NULL AND IML_QLE.CAD_SET_ID IS NULL THEN IMS_SETOR.DS_SETOR
               ELSE TO_CHAR(IML_QLE.CAD_QLE_NR_QUARTO) END ,
               CASE WHEN IMS_SETOR.CAD_SET_ID_SETOR IS NOT NULL AND IML_QLE.CAD_SET_ID IS NULL THEN NULL
               ELSE IML_QLE.CAD_QLE_NR_LEITO END ,
               CASE WHEN CNV.CAD_CNV_CD_HAC_PRESTADOR = 'SD01' THEN
                DECODE(FNC_VERIFICA_INSGER( TO_CHAR(PLA.CAD_PLA_CD_PLANO_HAC),
                                            TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,0,3)) ,
                                            TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,4,7)),
                                            TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,11,2))),0,'',1,'INST.GERIATRIA',2,'INST.GERIATRIA',4,'AMB. ALTA CRITICOS')
               ELSE '' END
      ORDER BY CAD_SET_DS_SETOR,
               PES.CAD_PES_NM_PESSOA,
               fnc_juntar_data_hora(IEP.ATD_IEP_DT_EVOLUCAO,IEP.ATD_IEP_HR_EVOLUCAO)
  ;
  io_cursor := v_cursor;
end PRC_INT_REL_EVOLUCAO;