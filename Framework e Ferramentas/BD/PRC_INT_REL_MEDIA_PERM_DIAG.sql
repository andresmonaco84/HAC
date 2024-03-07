create or replace procedure PRC_INT_REL_MEDIA_PERM_DIAG
  (
pATD_ATE_DT_ATENDIMENTO_INI IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
pATD_ATE_DT_ATENDIMENTO_FIM IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
pATD_ATE_HR_ATENDIMENTO_INI IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_HR_ATENDIMENTO%TYPE DEFAULT NULL,
pATD_ATE_HR_ATENDIMENTO_FIM IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_HR_ATENDIMENTO%TYPE DEFAULT NULL,
pATD_ATE_FL_CARATER_SOLIC_U IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_FL_CARATER_SOLIC%TYPE DEFAULT NULL,
pATD_ATE_FL_CARATER_SOLIC_E IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_FL_CARATER_SOLIC%TYPE DEFAULT NULL,
pFAIXA_ETARIA_INI varchar2 default null,
pFAIXA_ETARIA_FIM varchar2 default null,
pPERMANENCIA_INI varchar2 default null,
pPERMANENCIA_FIM varchar2 default null,
pCAD_UNI_ID_UNIDADE IN TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
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
pTIS_TAC_CD_TIPO_ACOMODACAO IN TB_TIS_TAC_TIPO_ACOMODACAO.TIS_TAC_CD_TIPO_ACOMODACAO%TYPE DEFAULT NULL,
pTIS_CBO_CD_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%TYPE DEFAULT NULL,
pCAD_PRO_ID_PROF_EXEC IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%TYPE DEFAULT NULL,
pCAD_PES_TP_SEXO IN TB_CAD_PES_PESSOA.CAD_PES_TP_SEXO%TYPE DEFAULT NULL,
pCAD_UNI_ID_UNID_PROC    IN TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNID_PROC%TYPE DEFAULT NULL,
pCAD_CID_CD_CID10 IN TB_CAD_CID_CID10.CAD_CID_CD_CID10%TYPE DEFAULT NULL,
pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
pCAD_PLA_ID_PLANO IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE DEFAULT NULL,
pCAD_CGC_ID_G IN TB_CAD_CNV_CONVENIO.CAD_CGC_ID%TYPE DEFAULT NULL,
pCAD_CGC_ID_E IN TB_CAD_CNV_CONVENIO.CAD_CGC_ID%TYPE DEFAULT NULL,
   io_cursor              OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_INT_REL_MEDIA_PERM_DIAG
  *
  *    Data Criacao:  11/08/2009   Por: pedro
  *    Funcao: Popula o Relatorio de Pacientes Internados com varias possibilidades de filtro
  *    Data Alteracao:03/11/2011   Por:Eduardo Hyppolito
  *
  *    Alterai??i??o: Campo Instituto Geriatria (LEFT JOIN BENEFICIARIO)
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
 SELECT DISTINCT
     ATD.ATD_ATE_ID,
     DECODE(AIC.ATD_AIC_TP_SITUACAO_PAC,'I','INTERNADO','A','ALTA') ATD_AIC_TP_SITUACAO_PAC,
     CASE WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'A' AND INA.ATD_INA_DT_ALTA_ADM IS NOT NULL THEN
               nvl(Round(TO_DATE(TO_CHAR(INA.ATD_INA_DT_ALTA_ADM,'dd-MM-yyyy')||TO_CHAR(INA.ATD_INA_HR_ALTA_ADM ,'0000'),'dd-MM-yyyy HH24MI')
                - TO_DATE(TO_CHAR(ATD.ATD_ATE_DT_ATENDIMENTO,'dd-MM-yyyy')||TO_CHAR(ATD.ATD_ATE_HR_ATENDIMENTO ,'0000'),'dd-MM-yyyy HH24MI')
                 + 1),0)
          WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'I' THEN
               nvl(Round(sysdate- TO_DATE(TO_CHAR(ATD.ATD_ATE_DT_ATENDIMENTO,'dd-MM-yyyy')||TO_CHAR(ATD.ATD_ATE_HR_ATENDIMENTO ,'0000'),'dd-MM-yyyy HH24MI')),0)
               ELSE  0
      END PERMANENCIA,
     ATD.ATD_ATE_DT_ATENDIMENTO,
     DECODE(ATD_ATE_TP_PACIENTE,'I','INTERNO','E','EXTERNO') ATD_ATE_TP_PACIENTE,
     ATD.ATD_ATE_HR_ATENDIMENTO,
     INA.ATD_INA_DT_ALTA_ADM,
     INA.TIS_MSI_CD_MOTIVOSAIDAINT,
     ATD.ATD_ATE_FL_CARATER_SOLIC,
     PES_UNI.CAD_PES_NM_PESSOA UNIDADE,
     LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
     SETOR.CAD_SET_DS_SETOR,
     SETOR.CAD_SET_NR_ANDAR,
     PAC.CAD_PAC_CD_CREDENCIAL,
     PAC.CAD_PAC_NR_PRONTUARIO,
     PES.CAD_PES_NM_PESSOA PACIENTE,
     PES.CAD_PES_TP_SEXO,
     CBOS.TIS_CBO_CD_CBOS_HAC,
     CNV.CAD_CNV_CD_HAC_PRESTADOR,
     PLA.CAD_PLA_CD_TIPOPLANO,
     PLA.CAD_PLA_CD_PLANO_HAC,
     PES_PRO.CAD_PES_NM_PESSOA PROFISSIONAL,
     PRO.CAD_PRO_NR_CONSELHO,
     PRO_ALTA.CAD_PRO_NR_CONSELHO CAD_PRO_NR_CONSELHO_ALTA,
     CID_IDG.CAD_CID_DS_CID10,
     IDG.ATD_IDG_CD_CIDPRINCIPAL,
     TIN.TIS_TIN_DS_INTERNACAO,
     TRI.TIS_TRI_DS_TP_REGINTERNACAO,
     PES.CAD_PES_DT_NASCIMENTO,
     IGE_BNF.GER,
    TRUNC( AVG(CASE WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'A' AND INA.ATD_INA_DT_ALTA_ADM IS NOT NULL THEN
               nvl(Round(TO_DATE(TO_CHAR(INA.ATD_INA_DT_ALTA_ADM,'dd-MM-yyyy')||TO_CHAR(INA.ATD_INA_HR_ALTA_ADM ,'0000'),'dd-MM-yyyy HH24MI')
                - TO_DATE(TO_CHAR(ATD.ATD_ATE_DT_ATENDIMENTO,'dd-MM-yyyy')||TO_CHAR(ATD.ATD_ATE_HR_ATENDIMENTO ,'0000'),'dd-MM-yyyy HH24MI')
                 + 1),0)
          WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'I' THEN
               nvl(Round(sysdate- TO_DATE(TO_CHAR(ATD.ATD_ATE_DT_ATENDIMENTO,'dd-MM-yyyy')||TO_CHAR(ATD.ATD_ATE_HR_ATENDIMENTO ,'0000'),'dd-MM-yyyy HH24MI')),0)
               ELSE  0
      END) OVER (PARTITION BY SETOR.CAD_SET_DS_SETOR || IDG.ATD_IDG_CD_CIDPRINCIPAL),2) MEDIA_SETOR,
     TRUNC( AVG(CASE WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'A' AND INA.ATD_INA_DT_ALTA_ADM IS NOT NULL THEN
               nvl(Round(TO_DATE(TO_CHAR(INA.ATD_INA_DT_ALTA_ADM,'dd-MM-yyyy')||TO_CHAR(INA.ATD_INA_HR_ALTA_ADM ,'0000'),'dd-MM-yyyy HH24MI')
                - TO_DATE(TO_CHAR(ATD.ATD_ATE_DT_ATENDIMENTO,'dd-MM-yyyy')||TO_CHAR(ATD.ATD_ATE_HR_ATENDIMENTO ,'0000'),'dd-MM-yyyy HH24MI')
                 + 1),0)
          WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'I' THEN
               nvl(Round(sysdate- TO_DATE(TO_CHAR(ATD.ATD_ATE_DT_ATENDIMENTO,'dd-MM-yyyy')||TO_CHAR(ATD.ATD_ATE_HR_ATENDIMENTO ,'0000'),'dd-MM-yyyy HH24MI')),0)
               ELSE  0
      END) OVER (),2) MEDIA_GERAL,
      FLOOR(FLOOR(MONTHS_BETWEEN(DECODE(INA.ATD_INA_DT_ALTA_ADM,NULL,ATD.ATD_ATE_DT_ATENDIMENTO,INA.ATD_INA_DT_ALTA_ADM), PES.CAD_PES_DT_NASCIMENTO)) / 12) IDADE
  FROM
                TB_ATD_ATE_ATENDIMENTO    ATD
  JOIN          TB_ATD_AIC_ATE_INT_COMPL  AIC
  ON            AIC.ATD_ATE_ID          = ATD.ATD_ATE_ID
  JOIN          TB_ASS_PAT_PACIEATEND     PAT
  ON            PAT.ATD_ATE_ID          = ATD.ATD_ATE_ID
  join          TB_CAD_PAC_PACIENTE       PAC
  ON            PAC.CAD_PAC_ID_PACIENTE = fnc_buscar_paciente_atual(PAT.ATD_ATE_ID)
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
  ON            UNI.CAD_UNI_ID_UNIDADE  = ATD.CAD_UNI_ID_UNIDADE
  JOIN          TB_CAD_LAT_LOCAL_ATENDIMENTO LAT
  ON            LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO
  JOIN          TB_CAD_PES_PESSOA           PES_UNI
  ON            PES_UNI.CAD_PES_ID_PESSOA = UNI.CAD_PES_ID_PESSOA
  JOIN          TB_CAD_PRO_PROFISSIONAL     PRO
  ON            PRO.CAD_PRO_ID_PROFISSIONAL = ATD.CAD_PRO_ID_PROF_EXEC
  JOIN          TB_CAD_PES_PESSOA           PES_PRO
  ON            PES_PRO.CAD_PES_ID_PESSOA = PRO.CAD_PES_ID_PESSOA
  JOIN          TB_TIS_TIN_TP_INTERNACAO    TIN
  ON            TIN.TIS_TIN_CD_INTERNACAO = AIC.TIS_TIN_CD_INTERNACAO
  JOIN          TB_TIS_TRI_TP_REGINTERNACAO TRI
  ON            TRI.TIS_TRI_CD_TP_REGINTERNACAO = AIC.TIS_TRI_CD_REGINTENNACAO
  JOIN          TB_ATD_IDG_INT_DIAGNOSTICO  IDG
  ON            IDG.ATD_ATE_ID            = ATD.ATD_ATE_ID
  JOIN          TB_CAD_CID_CID10            CID_IDG
  ON            CID_IDG.CAD_CID_CD_CID10  = IDG.ATD_IDG_CD_CIDPRINCIPAL
  LEFT JOIN    (SELECT BNF_SIT.DESSITBEN, BNF.DATINGCONBEN, BNF.DATSITBEN, BNF.DATALTBEN,PAC.CAD_PAC_ID_PACIENTE,
DECODE       (FNC_VERIFICA_INSGER(BNF.CODCON, BNF.CODEST, BNF.CODBEN, BNF.CODSEQBEN),0,'',1,'I.GER',2,'I.GER',4,'A.ALTA') GER
FROM          TB_CAD_PAC_PACIENTE       PAC
JOIN          TB_CAD_PLA_PLANO          PLA
ON            PAC.CAD_PLA_ID_PLANO    = PLA.CAD_PLA_ID_PLANO
JOIN          BNF_BENEFICIARIO          BNF
ON            TO_CHAR(BNF.CODCON)     = TO_CHAR(PLA.CAD_PLA_CD_PLANO_HAC)
AND           BNF.CODEST              = TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,0,3))
AND           BNF.CODBEN              = TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,4,7))
AND           BNF.CODSEQBEN           = TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,11,2))
JOIN          BNF_SITUACAO_BENEF        BNF_SIT
ON            BNF_SIT.CODSITBEN       = BNF.CODSITBEN

WHERE         pac.CAD_CNV_ID_CONVENIO = 281

) IGE_BNF
ON           IGE_BNF.CAD_PAC_ID_PACIENTE = PAC.CAD_PAC_ID_PACIENTE
  LEFT JOIN  (    SELECT QLE.CAD_QLE_NR_QUARTO,CAD_QLE_NR_LEITO,
                       DECODE(QLE.CAD_QLE_TP_QUARTO_LEITO,'I','INTERNO','E','EXTRA') CAD_QLE_TP_QUARTO_LEITO,
                       IML.ATD_ATE_ID, IML.ATD_IML_FL_CORTESIA,IML.ATD_IML_FL_DIF_CLASSE, QLE.CAD_SET_ID, QLE.TIS_TAC_CD_TIPO_ACOMODACAO
                 FROM      TB_ATD_IML_INT_MOV_LEITO IML
                 LEFT JOIN TB_CAD_QLE_QUARTO_LEITO QLE
                 ON        QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
                 JOIN      TB_ATD_ATE_ATENDIMENTO ATD2
                 ON        ATD2.ATD_ATE_ID = IML.ATD_ATE_ID
                  WHERE       FNC_JUNTAR_DATA_HORA(IML.ATD_IML_DT_ENTRADA,IML.ATD_IML_HR_ENTRADA) =
                                         (SELECT MAX(FNC_JUNTAR_DATA_HORA(IML3.ATD_IML_DT_ENTRADA,IML3.ATD_IML_HR_ENTRADA)) FROM TB_ATD_IML_INT_MOV_LEITO IML3
                                                       WHERE IML3.ATD_ATE_ID = ATD2.ATD_ATE_ID AND IML3.ATD_IML_FL_STATUS = 'A')
              )                                    IML_QLE
  ON            IML_QLE.ATD_ATE_ID               = ATD.ATD_ATE_ID
  LEFT JOIN     TB_CAD_SET_SETOR                   SETOR
  ON            IML_QLE.CAD_SET_ID               = SETOR.CAD_SET_ID
  LEFT JOIN     TB_CAD_PRO_PROFISSIONAL            PRO_ALTA
  ON            PRO_ALTA.CAD_PRO_ID_PROFISSIONAL = INA.CAD_PRO_ID_PROFISSIONAL
   WHERE
          (pCAD_UNI_ID_UNIDADE IS NULL OR ATD.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
   AND (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
   AND (pCAD_SET_ID IS NULL OR SETOR.CAD_SET_ID = pCAD_SET_ID)
   AND (ATD.ATD_ATE_TP_PACIENTE = 'I')
   AND (ATD.ATD_ATE_FL_STATUS = 'A')
   AND (pCAD_SET_NR_ANDAR IS NULL OR SETOR.CAD_SET_NR_ANDAR = pCAD_SET_NR_ANDAR)
   AND (pATD_AIC_TP_SITUACAO_PAC IS NULL OR AIC.ATD_AIC_TP_SITUACAO_PAC = pATD_AIC_TP_SITUACAO_PAC)
   AND (pATD_ATE_HR_ATENDIMENTO_INI IS NULL OR ATD.ATD_ATE_HR_ATENDIMENTO >= pATD_ATE_HR_ATENDIMENTO_INI)
   AND (pATD_ATE_HR_ATENDIMENTO_FIM IS NULL OR ATD.ATD_ATE_HR_ATENDIMENTO <= pATD_ATE_HR_ATENDIMENTO_FIM)
   AND (pFAIXA_ETARIA_INI IS NULL OR FLOOR(FLOOR(MONTHS_BETWEEN(DECODE(INA.ATD_INA_DT_ALTA_ADM,NULL,ATD.ATD_ATE_DT_ATENDIMENTO,INA.ATD_INA_DT_ALTA_ADM), PES.CAD_PES_DT_NASCIMENTO)) / 12) BETWEEN pFAIXA_ETARIA_INI AND pFAIXA_ETARIA_FIM)
   AND (pTIS_CBO_CD_CBOS IS NULL OR ATD.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS)
   AND (pCAD_PRO_ID_PROF_EXEC IS NULL OR ATD.CAD_PRO_ID_PROF_EXEC = pCAD_PRO_ID_PROF_EXEC)
  -- AND (pATD_ATE_TP_PACIENTE IS NULL OR ATD.ATD_ATE_TP_PACIENTE = pATD_ATE_TP_PACIENTE)
   AND (pCAD_PRD_ID IS NULL OR AIC.CAD_PRD_ID = pCAD_PRD_ID)
   AND (pCAD_PES_TP_SEXO IS NULL OR PES.CAD_PES_TP_SEXO = pCAD_PES_TP_SEXO)
   AND (pTIS_TAC_CD_TIPO_ACOMODACAO IS NULL OR IML_QLE.TIS_TAC_CD_TIPO_ACOMODACAO = pTIS_TAC_CD_TIPO_ACOMODACAO)
   AND (pCAD_CNV_ID_CONVENIO IS NULL OR CNV.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO)
   AND (pCAD_PLA_ID_PLANO IS NULL OR PLA.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO)
   AND (pCAD_QLE_TP_QUARTO_LEITO IS NULL OR IML_QLE.CAD_QLE_TP_QUARTO_LEITO = pCAD_QLE_TP_QUARTO_LEITO)
   AND (pTIS_TIN_CD_INTER IS NULL OR TIN.TIS_TIN_CD_INTERNACAO = pTIS_TIN_CD_INTER)
   AND (pTIS_TRI_CD_TP_REGINT IS NULL OR TRI.TIS_TRI_CD_TP_REGINTERNACAO = pTIS_TRI_CD_TP_REGINT)
   AND (pCAD_UNI_ID_UNID_PROC IS NULL OR ATD.CAD_UNI_ID_UNID_PROC = pCAD_UNI_ID_UNID_PROC)
   AND (pCAD_CID_CD_CID10 IS NULL OR IDG.ATD_IDG_CD_CIDPRINCIPAL = pCAD_CID_CD_CID10)
   AND (pCAD_CGC_ID_G IS NOT NULL AND CNV.CAD_CGC_ID = 1 OR pCAD_CGC_ID_E IS NOT NULL AND CNV.CAD_CGC_ID = 2)
   AND (pCAD_PLA_CD_TIPOPLANO_GB IS not NULL and PLA.CAD_PLA_CD_TIPOPLANO = 'GB'
   OR pCAD_PLA_CD_TIPOPLANO_PL IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'PL'
   OR pCAD_PLA_CD_TIPOPLANO_PA IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'PA'
   OR pCAD_PLA_CD_TIPOPLANO_SP IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'SP'
   OR pCAD_PLA_CD_TIPOPLANO_FU IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = 'FU'
  -- OR pCAD_PLA_CD_TIPOPLANO_NP IS NOT NULL AND PLA.pCAD_PLA_CD_TIPOPLANO_NP = 'NP'
   )
   AND (PLA.CAD_PLA_CD_TIPOPLANO != 'NP')
     AND (pATD_ATE_FL_CARATER_SOLIC_U IS NOT NULL AND ATD.ATD_ATE_FL_CARATER_SOLIC = 'U'
   OR pATD_ATE_FL_CARATER_SOLIC_E IS NOT NULL AND ATD.ATD_ATE_FL_CARATER_SOLIC = 'E')
   AND (ATD.ATD_ATE_DT_ATENDIMENTO BETWEEN pATD_ATE_DT_ATENDIMENTO_INI AND pATD_ATE_DT_ATENDIMENTO_FIM)
   AND  (pPERMANENCIA_INI IS NULL OR
               ((CASE WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'A' THEN
                          nvl(Round(INA.ATD_INA_DT_ALTA_ADM - ATD.ATD_ATE_DT_ATENDIMENTO),0)
                          WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'I' THEN
                          nvl(Round(sysdate-ATD.ATD_ATE_DT_ATENDIMENTO),0)
                          ELSE  0
               END) >=  pPERMANENCIA_INI)
               )
    AND  (pPERMANENCIA_FIM IS NULL OR
               ((CASE WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'A' THEN
                         nvl(Round(INA.ATD_INA_DT_ALTA_ADM - ATD.ATD_ATE_DT_ATENDIMENTO),0)
                         WHEN AIC.ATD_AIC_TP_SITUACAO_PAC = 'I' THEN
                         nvl(Round(sysdate-ATD.ATD_ATE_DT_ATENDIMENTO),0)
                         ELSE  0
              END) <= pPERMANENCIA_FIM)
              )
  ORDER BY SETOR.CAD_SET_DS_SETOR, IDG.ATD_IDG_CD_CIDPRINCIPAL, PES.CAD_PES_NM_PESSOA
  ;
  io_cursor := v_cursor;
end PRC_INT_REL_MEDIA_PERM_DIAG;