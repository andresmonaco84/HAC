CREATE OR REPLACE PROCEDURE PRC_INT_REL_PAC_ACS
  (
pATD_ATE_DT_ATENDIMENTO_INI IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
pATD_ATE_DT_ATENDIMENTO_FIM IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE DEFAULT NULL,
pATD_ATE_HR_ATENDIMENTO_INI IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_HR_ATENDIMENTO%TYPE DEFAULT NULL,
pATD_ATE_HR_ATENDIMENTO_FIM IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_HR_ATENDIMENTO%TYPE DEFAULT NULL,
pATD_ATE_FL_CARATER_SOLIC_U IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_FL_CARATER_SOLIC%TYPE DEFAULT NULL,
pATD_ATE_FL_CARATER_SOLIC_E IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_FL_CARATER_SOLIC%TYPE DEFAULT NULL,
pFAIXA_ETARIA_INI           varchar2 default null,
pFAIXA_ETARIA_FIM           varchar2 default null,
pCAD_UNI_ID_UNIDADE         IN TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
pCAD_SET_ID                   IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
pCAD_SET_NR_ANDAR             IN TB_CAD_SET_SETOR.CAD_SET_NR_ANDAR%TYPE DEFAULT NULL,
pATD_AIC_TP_SITUACAO_PAC      IN TB_ATD_AIC_ATE_INT_COMPL.ATD_AIC_TP_SITUACAO_PAC%TYPE DEFAULT NULL,
pATD_ATE_TP_PACIENTE_I        IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_TP_PACIENTE%TYPE DEFAULT NULL,
pATD_ATE_TP_PACIENTE_E        IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_TP_PACIENTE%TYPE DEFAULT NULL,
pCAD_QLE_TP_QUARTO_LEITO      IN TB_CAD_QLE_QUARTO_LEITO.CAD_QLE_TP_QUARTO_LEITO%TYPE DEFAULT NULL,
pTIS_TIN_CD_INTER             IN TB_ATD_AIC_ATE_INT_COMPL.TIS_TIN_CD_INTERNACAO%TYPE DEFAULT NULL,
pTIS_TRI_CD_TP_REGINT         IN TB_ATD_AIC_ATE_INT_COMPL.TIS_TRI_CD_REGINTENNACAO%TYPE DEFAULT NULL,
pCAD_PLA_CD_TIPOPLANO_GB      IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL, --ACS
pCAD_PLA_CD_TIPOPLANO_PL      IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL, --ACS
pCAD_PRD_ID                   IN TB_CAD_PRD_PRODUTO.CAD_PRD_ID%TYPE DEFAULT NULL,
pTIS_TAC_CD_TIPO_ACOMODACAO   IN TB_TIS_TAC_TIPO_ACOMODACAO.TIS_TAC_CD_TIPO_ACOMODACAO%TYPE DEFAULT NULL,
pTIS_CBO_CD_CBOS              IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%TYPE DEFAULT NULL,
pCAD_PRO_ID_PROF_EXEC         IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%TYPE DEFAULT NULL,
pCAD_PES_TP_SEXO              IN TB_CAD_PES_PESSOA.CAD_PES_TP_SEXO%TYPE DEFAULT NULL,
pCAD_CNV_ID_CONVENIO          IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
pCAD_PLA_ID_PLANO             IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE DEFAULT NULL,
pCAD_UNI_ID_UNID_PROC         IN TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNID_PROC%TYPE DEFAULT NULL,
pRELATORIO_INSTGERIATRIA      varchar2 default null,
pID_PLANOS     varchar2 default null,
    -- teste OUT LONG,
   io_cursor              OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_INT_REL_PAC_ACS -  INT_30_PAC_ACS
  *
  *    Data Criacao:  8/07/2011      Por: Pedro
  *    Data Alteracao:           Por:
  *
  *    Funcao: Popula o Relatorio de Pacientes Internados ACS, parecido com o PRC_INT_REL_PAC - INT_04_PAC
  *
  *******************************************************************/
 v_cursor PKG_CURSOR.t_cursor;
  V_WHERE  varchar2(3000);
    V_WHERESUB  varchar2(3000);
  V_SELECT  varchar2(15000);
  begin
    V_WHERE := NULL;
IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN  V_WHERE := V_WHERE || ' AND ATD.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE; END IF;
IF pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO = ' || pCAD_LAT_ID_LOCAL_ATENDIMENTO; END IF;
IF pCAD_SET_ID IS NOT NULL THEN V_WHERE := V_WHERE || ' AND IML_QLE.CAD_SET_ID = ' || pCAD_SET_ID; END IF;
IF pATD_AIC_TP_SITUACAO_PAC IS NOT NULL THEN V_WHERE := V_WHERE || ' AND AIC.ATD_AIC_TP_SITUACAO_PAC = ' ||CHR(39)|| pATD_AIC_TP_SITUACAO_PAC ||CHR(39); END IF;
IF pATD_AIC_TP_SITUACAO_PAC = 'A' THEN V_WHERE := V_WHERE || ' AND INA.ATD_ATE_ID IS NOT NULL '; END IF;
IF pATD_ATE_HR_ATENDIMENTO_INI IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATD.ATD_ATE_HR_ATENDIMENTO  BETWEEN ' || pATD_ATE_HR_ATENDIMENTO_INI || ' AND ' || pATD_ATE_HR_ATENDIMENTO_FIM  ; END IF;
IF pFAIXA_ETARIA_INI IS NOT NULL THEN V_WHERE := V_WHERE || ' AND (pFAIXA_ETARIA_INI IS NULL OR FLOOR(FLOOR(MONTHS_BETWEEN(DECODE(INA.ATD_INA_DT_ALTA_ADM,NULL,ATD.ATD_ATE_DT_ATENDIMENTO,INA.ATD_INA_DT_ALTA_ADM), PES.CAD_PES_DT_NASCIMENTO)) / 12) BETWEEN pFAIXA_ETARIA_INI AND pFAIXA_ETARIA_FIM) BETWEEN ' || pFAIXA_ETARIA_INI || ' AND ' || pFAIXA_ETARIA_FIM; END IF;
IF pTIS_CBO_CD_CBOS IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATD.TIS_CBO_CD_CBOS = ' ||CHR(39)|| pTIS_CBO_CD_CBOS ||CHR(39); END IF;
IF pCAD_PRO_ID_PROF_EXEC IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATD.CAD_PRO_ID_PROF_EXEC = ' || pCAD_PRO_ID_PROF_EXEC; END IF;
IF pCAD_UNI_ID_UNID_PROC  IS NOT NULL THEN V_WHERE := V_WHERE || ' AND ATD.CAD_UNI_ID_UNID_PROC = ' || pCAD_UNI_ID_UNID_PROC ; END IF;
IF pCAD_PLA_ID_PLANO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND PAC.CAD_PLA_ID_PLANO = ' || pCAD_PLA_ID_PLANO; END IF;
IF pCAD_PRD_ID IS NOT NULL THEN V_WHERE := V_WHERE || ' AND AIC.CAD_PRD_ID = ' || pCAD_PRD_ID; END IF;
IF pCAD_PES_TP_SEXO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND PES.CAD_PES_TP_SEXO = ' ||CHR(39)|| pCAD_PES_TP_SEXO ||CHR(39); END IF;
IF pTIS_TAC_CD_TIPO_ACOMODACAO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND TAC.TIS_TAC_CD_TIPO_ACOMODACAO = ' ||CHR(39)|| pTIS_TAC_CD_TIPO_ACOMODACAO ||CHR(39); END IF;
IF pCAD_QLE_TP_QUARTO_LEITO IS NOT NULL THEN V_WHERE := V_WHERE || ' AND IML_QLE.CAD_QLE_TP_QUARTO_LEITO = ' ||CHR(39)|| pCAD_QLE_TP_QUARTO_LEITO ||CHR(39); END IF;
IF pTIS_TIN_CD_INTER IS NOT NULL THEN V_WHERE := V_WHERE || ' AND TIN.TIS_TIN_CD_INTERNACAO = ' ||CHR(39)|| pTIS_TIN_CD_INTER ||CHR(39); END IF;
IF pTIS_TRI_CD_TP_REGINT IS NOT NULL THEN V_WHERE := V_WHERE || ' AND  TRI.TIS_TRI_CD_TP_REGINTERNACAO = ' ||CHR(39)|| pTIS_TRI_CD_TP_REGINT ||CHR(39); END IF;
IF pATD_ATE_DT_ATENDIMENTO_INI IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD.ATD_ATE_DT_ATENDIMENTO >= TO_DATE('||CHR(39)||TO_CHAR(pATD_ATE_DT_ATENDIMENTO_INI,'DDMMYYYY')||CHR(39)||','||CHR(39)||'DDMMYYYY'||CHR(39)|| ')' ; END IF;
IF pATD_ATE_DT_ATENDIMENTO_FIM IS NOT NULL THEN V_WHERE:= V_WHERE || ' AND ATD.ATD_ATE_DT_ATENDIMENTO <= TO_DATE('||CHR(39)||TO_CHAR(pATD_ATE_DT_ATENDIMENTO_FIM,'DDMMYYYY')||CHR(39)||','||CHR(39)||'DDMMYYYY'||CHR(39)|| ')' ; END IF;
IF pATD_ATE_DT_ATENDIMENTO_INI IS NULL AND pATD_ATE_DT_ATENDIMENTO_FIM IS NULL THEN
   V_WHERE := V_WHERE || ' AND AIC.ATD_AIC_TP_SITUACAO_PAC = '||CHR(39)||'I'||CHR(39); END IF;
IF pID_PLANOS IS NOT NULL THEN
   V_WHERE := V_WHERE || ' AND PLA.CAD_PLA_ID_PLANO IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || pID_PLANOS || ''' ))) ';
   END IF;
IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN  V_WHERESUB := V_WHERESUB || ' AND ATD2.CAD_UNI_ID_UNIDADE = ' || pCAD_UNI_ID_UNIDADE; END IF;
IF pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN V_WHERESUB := V_WHERESUB || ' AND ATD2.CAD_LAT_ID_LOCAL_ATENDIMENTO = ' || pCAD_LAT_ID_LOCAL_ATENDIMENTO; END IF;
IF pATD_AIC_TP_SITUACAO_PAC IS NOT NULL THEN V_WHERESUB := V_WHERESUB || ' AND AIC2.ATD_AIC_TP_SITUACAO_PAC = ' ||CHR(39)|| pATD_AIC_TP_SITUACAO_PAC ||CHR(39); END IF;
IF pCAD_UNI_ID_UNID_PROC  IS NOT NULL THEN V_WHERESUB := V_WHERESUB || ' AND ATD2.CAD_UNI_ID_UNID_PROC = ' || pCAD_UNI_ID_UNID_PROC ; END IF;
IF pATD_ATE_DT_ATENDIMENTO_INI IS NOT NULL THEN V_WHERESUB:= V_WHERESUB || ' AND ATD2.ATD_ATE_DT_ATENDIMENTO >= TO_DATE('||CHR(39)||TO_CHAR(pATD_ATE_DT_ATENDIMENTO_INI,'DDMMYYYY')||CHR(39)||','||CHR(39)||'DDMMYYYY'||CHR(39)|| ')' ; END IF;
IF pATD_ATE_DT_ATENDIMENTO_FIM IS NOT NULL THEN V_WHERESUB:= V_WHERESUB || ' AND ATD2.ATD_ATE_DT_ATENDIMENTO <= TO_DATE('||CHR(39)||TO_CHAR(pATD_ATE_DT_ATENDIMENTO_FIM,'DDMMYYYY')||CHR(39)||','||CHR(39)||'DDMMYYYY'||CHR(39)|| ')' ; END IF;
IF pATD_ATE_DT_ATENDIMENTO_INI IS NULL AND pATD_ATE_DT_ATENDIMENTO_FIM IS NULL THEN V_WHERESUB := V_WHERESUB || ' AND AIC2.ATD_AIC_TP_SITUACAO_PAC = '||CHR(39)||'I'||CHR(39); END IF;
--IF pATD_ATE_DT_ATENDIMENTO_INI IS NOT NULL AND pATD_ATE_DT_ATENDIMENTO_FIM IS NULL THEN
--  V_WHERE:= V_WHERE || ' AND ATD.ATD_ATE_DT_ATENDIMENTO = TO_DATE('||CHR(39)||TO_CHAR(pATD_ATE_DT_ATENDIMENTO_INI,'DDMMYYYY')||CHR(39)||','||CHR(39)||'DDMMYYYY'||CHR(39)|| ')' ; END IF;
V_SELECT :=
   '
SELECT DISTINCT
               IML_QLE.ATD_IML_DT_ENTRADA,
               IML_QLE.ATD_IML_HR_ENTRADA,
               DECODE(IML_QLE.CAD_QLE_TP_QUARTO_LEITO,''I'',''INTERNO'',''E'',''EXTRA'') CAD_QLE_TP_QUARTO_LEITO,
               IML_QLE.CAD_QLE_NR_QUARTO,
               IML_QLE.CAD_QLE_NR_LEITO,
               TAC.TIS_TAC_DS_TIPO_ACOMODACAO,
               TAC_AUT.TIS_TAC_DS_TIPO_ACOMODACAO TIS_TAC_DS_TIPO_ACOMODACAO_AUT,
               ATD.ATD_ATE_ID,
               DECODE(ATD.ATD_ATE_FL_CARATER_SOLIC,''U'',''URGENCIA'',''E'',''ELETIVA'') ATD_ATE_FL_CARATER_SOLIC,
               UNI.CAD_UNI_DS_UNIDADE UNIDADE,
               UNI.CAD_UNI_ID_UNIDADE,
               LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
               SETOR.CAD_SET_DS_SETOR,
               PAC.CAD_PAC_CD_CREDENCIAL,
               PAC.CAD_PAC_NR_PRONTUARIO,
               BNF_SIT.DESSITBEN,
               BNF.DATINGCONBEN,
               BNF.DATSITBEN,
               BNF.DATALTBEN,
               PES.CAD_PES_NM_PESSOA PACIENTE,
               PES.CAD_PES_DT_NASCIMENTO,
               PES.CAD_PES_TP_SEXO,
               MUN.AUX_MUN_NM_MUNICIPIO,
               CBOS.TIS_CBO_DS_CBOS_HAC,
               DECODE(AIC.ATD_AIC_TP_SITUACAO_PAC,''I'',''INTERNADO'',''A'',''ALTA'') ATD_AIC_TP_SITUACAO_PAC,
               DECODE(ATD_ATE_TP_PACIENTE,''I'',''INTERNO'',''E'',''EXTERNO'') ATD_ATE_TP_PACIENTE,
               INA.ATD_INA_DT_ALTA_ADM ATD_INA_DT_ALTA_CLINICA,
               CNV.CAD_CNV_CD_HAC_PRESTADOR,
               PLA.CAD_PLA_CD_TIPOPLANO,
               PLA.CAD_PLA_CD_PLANO_HAC,
               PLA.CAD_PLA_NM_NOME_PLANO,
               ATD.ATD_ATE_DT_ATENDIMENTO,
               ATD.ATD_ATE_HR_ATENDIMENTO,
               PRO.CAD_PRO_NM_NOME PROFISSIONAL,
               PRO.CAD_PRO_NR_CONSELHO,
               PRO.CAD_PRO_SG_UF_CONSELHO,
               FNC_INT_ULTIMO_CID(ATD.ATD_ATE_ID) CAD_CID_DS_CID10,
               FNC_INT_ULTIMO_CID(ATD.ATD_ATE_ID,''S'') CAD_CID_CD_CID10,
               TIN.TIS_TIN_DS_INTERNACAO,
               TRI.TIS_TRI_DS_TP_REGINTERNACAO,
               PRD.CAD_PRD_NM_MNEMONICO,
               PRD.CAD_PRD_DS_DESCRICAO,
               SETOR.CAD_SET_NR_ANDAR,
               FLOOR(FLOOR(MONTHS_BETWEEN(DECODE(INA.ATD_INA_DT_ALTA_ADM,NULL,ATD.ATD_ATE_DT_ATENDIMENTO,INA.ATD_INA_DT_ALTA_ADM), PES.CAD_PES_DT_NASCIMENTO)) / 12) idade,
               DECODE(FNC_VERIFICA_INSGER(BNF.CODCON, BNF.CODEST, BNF.CODBEN, BNF.CODSEQBEN),0,'''',1,''INST.GERIATRIA'',2,''INST.GERIATRIA'',4,''AMB. ALTA CRITICOS'') GER,
               ATD.ATD_ATE_FL_SUSPEITA_COVID19, FNC_BUSCAR_DT_INI_UTI(ATD.ATD_ATE_ID) PRIMEIRAENTRADAUTI,
               DECODE(PES.CAD_PES_FL_CUIDADOINTEGRAL,1,''SAVE1'',2,''SAVE2'',3,''SAVE3'') CAD_PES_FL_CUIDADOINTEGRAL,
               CASE WHEN PES.CAD_PES_FL_ISOLAMENTO = ''S'' THEN ''ISOLAMENTO'' ELSE NULL END CAD_PES_FL_ISOLAMENTO

  FROM
                TB_ATD_ATE_ATENDIMENTO    ATD
  JOIN          TB_ASS_PAT_PACIEATEND     PAT  ON PAT.ATD_ATE_ID          = ATD.ATD_ATE_ID
  JOIN          TB_CAD_PAC_PACIENTE       PAC  ON PAC.CAD_PAC_ID_PACIENTE = fnc_buscar_paciente_atual(pat.atd_ate_id)
  JOIN          TB_CAD_PES_PESSOA         PES  ON PES.CAD_PES_ID_PESSOA   = PAC.CAD_PES_ID_PESSOA
  JOIN          TB_CAD_CNV_CONVENIO       CNV  ON CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
  JOIN          TB_CAD_PLA_PLANO          PLA  ON PLA.CAD_PLA_ID_PLANO    = PAC.CAD_PLA_ID_PLANO
   JOIN          BNF_BENEFICIARIO          BNF  ON   TO_CHAR(BNF.CODCON)     = DECODE(PLA.CAD_CNV_ID_CONVENIO,281,TO_CHAR(PLA.CAD_PLA_CD_PLANO_HAC),NULL)
                      AND  BNF.CODEST              = DECODE(PLA.CAD_CNV_ID_CONVENIO,281,TO_CHAR(TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,0,3))),NULL)
                      AND  BNF.CODBEN              = DECODE(PLA.CAD_CNV_ID_CONVENIO,281,TO_CHAR(TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,4,7))),NULL)
                      AND  BNF.CODSEQBEN           = DECODE(PLA.CAD_CNV_ID_CONVENIO,281,TO_CHAR(TO_NUMBER(SUBSTR(PAC.CAD_PAC_CD_CREDENCIAL,11,2))),NULL)
  LEFT JOIN     BNF_SITUACAO_BENEF BNF_SIT     ON BNF_SIT.CODSITBEN       = BNF.CODSITBEN
  JOIN          TB_ATD_AIC_ATE_INT_COMPL  AIC  ON AIC.ATD_ATE_ID          = ATD.ATD_ATE_ID
  LEFT JOIN  (  SELECT     QLE.CAD_QLE_ID, QLE.CAD_SET_ID , QLE.CAD_QLE_NR_QUARTO, QLE.CAD_QLE_NR_LEITO,
                          IML.ATD_ATE_ID, IML.TIS_TAC_CD_TIPO_ACOMODACAO, IML.TIS_TAC_CD_TIPO_ACOMOD_AUT,
                          QLE.CAD_QLE_TP_QUARTO_LEITO , IML.ATD_IML_DT_ENTRADA, IML.ATD_IML_HR_ENTRADA
                 FROM      TB_ATD_IML_INT_MOV_LEITO IML
                 LEFT JOIN TB_CAD_QLE_QUARTO_LEITO QLE ON QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
                 JOIN      TB_ATD_ATE_ATENDIMENTO ATD2 ON ATD2.ATD_ATE_ID = IML.ATD_ATE_ID
                 JOIN      TB_ATD_AIC_ATE_INT_COMPL AIC2 ON AIC2.ATD_ATE_ID = IML.ATD_ATE_ID
                 WHERE     IML.ATD_IML_DT_SAIDA IS NULL AND IML.ATD_ATE_ID = ATD2.ATD_ATE_ID AND IML.ATD_IML_FL_STATUS = ''A''
                  ' || V_WHERESUB || '
                 UNION
                 SELECT NULL CAD_QLE_ID, IMS.CAD_SET_ID_SETOR, NULL CAD_QLE_NR_QUARTO, NULL CAD_QLE_NR_LEITO,
                        IMS.ATD_ATE_ID, nULL TIS_TAC_CD_TIPO_ACOMODACAO, IMS.TIS_TAC_CD_TIPO_ACOMOD_AUT,
                        NULL CAD_QLE_TP_QUARTO_LEITO, IMS.ATD_IMS_DT_ENTRADA ATD_IML_DT_ENTRADA,
                        IMS.ATD_IMS_HR_ENTRADA ATD_IML_HR_ENTRADA
                 FROM   TB_ATD_IMS_INT_MOV_SETOR IMS
                 JOIN   TB_ATD_ATE_ATENDIMENTO ATD2 ON ATD2.ATD_ATE_ID = IMS.ATD_ATE_ID
                 JOIN   TB_ATD_AIC_ATE_INT_COMPL AIC2 ON AIC2.ATD_ATE_ID = IMS.ATD_ATE_ID
                 WHERE IMS.ATD_ATE_ID = ATD2.ATD_ATE_ID AND IMS.ATD_IMS_DT_SAIDA IS NULL AND IMS.ATD_ATE_ID = ATD2.ATD_ATE_ID AND IMS.ATD_IMS_FL_STATUS = ''A''
                  ' || V_WHERESUB || '
                 AND NOT IMS.ATD_ATE_ID IN (SELECT IML.ATD_ATE_ID
                                               FROM      TB_ATD_IML_INT_MOV_LEITO IML
                                               LEFT JOIN TB_CAD_QLE_QUARTO_LEITO QLE
                                               ON        QLE.CAD_QLE_ID = IML.CAD_CAD_QLE_ID
                                               JOIN      TB_ATD_ATE_ATENDIMENTO ATD2
                                               ON        ATD2.ATD_ATE_ID = IML.ATD_ATE_ID
                                               WHERE     IML.ATD_IML_DT_SAIDA IS NULL AND IML.ATD_ATE_ID = ATD2.ATD_ATE_ID AND IML.ATD_IML_FL_STATUS = ''A'')
              )  IML_QLE
  ON IML_QLE.ATD_ATE_ID = ATD.ATD_ATE_ID
  LEFT JOIN     TB_ATD_INA_INT_ALTA         INA  ON INA.ATD_ATE_ID            = ATD.ATD_ATE_ID
  JOIN          TB_TIS_CBO_CBOS             CBOS ON CBOS.TIS_CBO_CD_CBOS      = ATD.TIS_CBO_CD_CBOS
  LEFT JOIN     TB_TIS_TAC_TIPO_ACOMODACAO  TAC  ON TAC.TIS_TAC_CD_TIPO_ACOMODACAO = IML_QLE.TIS_TAC_CD_TIPO_ACOMODACAO
  LEFT JOIN     TB_TIS_TAC_TIPO_ACOMODACAO  TAC_AUT ON TAC_AUT.TIS_TAC_CD_TIPO_ACOMODACAO = IML_QLE.TIS_TAC_CD_TIPO_ACOMOD_AUT
  JOIN          TB_CAD_UNI_UNIDADE          UNI  ON UNI.CAD_UNI_ID_UNIDADE    = ATD.CAD_UNI_ID_UNIDADE
  JOIN          TB_CAD_LAT_LOCAL_ATENDIMENTO LAT ON LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO
  LEFT JOIN     TB_CAD_SET_SETOR            SETOR ON SETOR.CAD_SET_ID          = IML_QLE.CAD_SET_ID
  JOIN          TB_CAD_PRO_PROFISSIONAL     PRO  ON PRO.CAD_PRO_ID_PROFISSIONAL = ATD.CAD_PRO_ID_PROF_EXEC
  LEFT JOIN     TB_TIS_TIN_TP_INTERNACAO    TIN  ON TIN.TIS_TIN_CD_INTERNACAO = AIC.TIS_TIN_CD_INTERNACAO
  LEFT JOIN     TB_TIS_TRI_TP_REGINTERNACAO TRI  ON TRI.TIS_TRI_CD_TP_REGINTERNACAO = AIC.TIS_TRI_CD_REGINTENNACAO
  LEFT JOIN     TB_CAD_PRD_PRODUTO          PRD  ON PRD.CAD_PRD_ID            = AIC.CAD_PRD_ID
 -- LEFT JOIN     TB_ASS_PEE_PESSOA_ENDERECO  PEE ON PEE.CAD_PES_ID_PESSOA     = PES.CAD_PES_ID_PESSOA
  LEFT JOIN     TB_CAD_END_ENDERECO         END  ON END.CAD_PES_ID_PESSOA   = PES.CAD_PES_ID_PESSOA
  LEFT JOIN     TB_AUX_MUN_MUNICIPIO        MUN  ON MUN.AUX_MUN_CD_IBGE       = END.AUX_MUN_CD_IBGE
   WHERE
       (ATD.ATD_ATE_FL_STATUS = ''A'')
   AND (ATD.ATD_ATE_TP_PACIENTE = ''I'')
   AND (PAT.CAD_CNV_ID_CONVENIO = 281)
   ' || V_WHERE || '
   AND ('||CHR(39)|| pCAD_PLA_CD_TIPOPLANO_GB ||CHR(39)|| ' IS not NULL and PLA.CAD_PLA_CD_TIPOPLANO = ''GB''
     OR '||CHR(39)|| pCAD_PLA_CD_TIPOPLANO_PL ||CHR(39)|| ' IS NOT NULL AND PLA.CAD_PLA_CD_TIPOPLANO = ''PL'')
   AND ('||CHR(39)|| pATD_ATE_FL_CARATER_SOLIC_U ||CHR(39)|| ' IS NOT NULL AND ATD.ATD_ATE_FL_CARATER_SOLIC = ''U''
      OR '||CHR(39)|| pATD_ATE_FL_CARATER_SOLIC_E ||CHR(39)|| ' IS NOT NULL AND ATD.ATD_ATE_FL_CARATER_SOLIC = ''E'')
   AND ('||CHR(39)|| pRELATORIO_INSTGERIATRIA ||CHR(39)|| ' IS NULL OR
       FNC_VERIFICA_INSGER(BNF.CODCON, BNF.CODEST, BNF.CODBEN, BNF.CODSEQBEN) in (1,2)   )
   order by PLA.CAD_PLA_CD_TIPOPLANO,PLA.CAD_PLA_CD_PLANO_HAC,BNF_SIT.DESSITBEN';
    --  TESTE :=  V_SELECT ;
OPEN v_cursor FOR
       V_SELECT ;
     -- SELECT 1 FROM DUAL;
  io_cursor := v_cursor;
end PRC_INT_REL_PAC_ACS;