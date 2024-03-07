CREATE OR REPLACE PROCEDURE "PRC_REP_REL_ANALIT_PROCEDREAL"(
PREP_PGM_MES_PAGTO_INI        IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE DEFAULT NULL,
PREP_PGM_ANO_PAGTO_INI        IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE DEFAULT NULL,
PREP_PGM_MES_PAGTO_FIM        IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE DEFAULT NULL,
PREP_PGM_ANO_PAGTO_FIM        IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE DEFAULT NULL,
PCAD_CLC_ID                   IN TB_CAD_CLC_CLINICA_CREDENCIADA.CAD_CLC_ID%TYPE DEFAULT NULL,
PCAD_UNI_ID_UNIDADE           IN STRING DEFAULT NULL,
PCAD_LAT_ID_LOCAL_ATENDIMENTO IN STRING DEFAULT NULL,
PCAD_SET_ID                   IN STRING DEFAULT NULL,
PREP_PGM_TP_CREDENCIA_PROF    IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_TP_CREDENCIA_PROF%TYPE DEFAULT NULL,
PCAD_CNV_ID_CONVENIO          IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
PCAD_TPE_CD_CODIGO            IN STRING DEFAULT NULL,
PTIS_MED_CD_TABELAMEDICA      IN STRING DEFAULT NULL,
PAUX_EPP_CD_ESPECPROC         IN STRING DEFAULT NULL,
PAUX_GPC_CD_GRUPOPROC         IN STRING DEFAULT NULL,
PCAD_PRD_ID                   IN STRING DEFAULT NULL,
PCAD_TAP_TP_ATRIBUTO          IN STRING DEFAULT NULL,
PSEMCONSULTA                  IN STRING DEFAULT NULL,
PCAD_PRO_ID_PROFISSIONAL      IN STRING DEFAULT NULL,
PVALORPAGOZERADO              IN STRING DEFAULT NULL,
PTIPOVISUALIZACAO             IN STRING DEFAULT NULL,
PORDENACAO                    IN STRING DEFAULT 'A',
PSEMCRM                       IN STRING DEFAULT NULL,
PSEMVALORPAGO                 IN STRING DEFAULT NULL,
PTIS_CBO_CD_CBOS              IN STRING DEFAULT NULL,
PREP_PGM_DT_INICIO_REALIZACAO IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_DT_INICIO_REALIZACAO%TYPE DEFAULT NULL,
PREP_PGM_DT_FIM_REALIZACAO    IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_DT_INICIO_REALIZACAO%TYPE DEFAULT NULL,
IO_CURSOR                     OUT PKG_CURSOR.T_CURSOR) IS
  /********************************************************************
  *    Procedure: PRC_REP_REL_ANALIT_PROCEDREAL
  *
  *    Data Criacao:    06/02/2012           Por: Fabiola Lopes
  *    Data Alteracao:  data da alteracao  Por: Nome do Analista
  *
  *    Funcao: Descricao da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  V_CURSOR          PKG_CURSOR.T_CURSOR;
  V_WHERE           VARCHAR2(6000);
  V_SELECT          VARCHAR2(8000);
  V_ORDER           VARCHAR2(1000);
  V_ORDENAR_COM_CRM VARCHAR2(100);
  V_REP_PGM_TP_CREDENCIA_PROF VARCHAR2(100);
BEGIN
  IF (PREP_PGM_TP_CREDENCIA_PROF IS NULL) THEN
    V_REP_PGM_TP_CREDENCIA_PROF := 'NULL';
  ELSE
    V_REP_PGM_TP_CREDENCIA_PROF := CHR(39) || PREP_PGM_TP_CREDENCIA_PROF || CHR(39);
  END IF;
  V_WHERE := ' WHERE PGM.REP_PGM_FL_STATUS <> ''I'' ';
  V_WHERE := V_WHERE || ' AND ((PGM.REP_PGM_MES_PAGTO + PGM.REP_PGM_ANO_PAGTO * 100) >= (' || TO_CHAR(PREP_PGM_MES_PAGTO_INI + PREP_PGM_ANO_PAGTO_INI * 100) || '))';
  IF PREP_PGM_MES_PAGTO_FIM IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND ((PGM.REP_PGM_MES_PAGTO + PGM.REP_PGM_ANO_PAGTO * 100) <= (' || TO_CHAR(PREP_PGM_MES_PAGTO_FIM + PREP_PGM_ANO_PAGTO_FIM * 100) || '))';
  ELSE
    V_WHERE := V_WHERE || ' AND ((PGM.REP_PGM_MES_PAGTO + PGM.REP_PGM_ANO_PAGTO * 100) <= (' || TO_CHAR(PREP_PGM_MES_PAGTO_INI + PREP_PGM_ANO_PAGTO_INI * 100) || '))';
  END IF;
  IF PCAD_CLC_ID IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_CLC_ID = ' || PCAD_CLC_ID;
  END IF;
  IF PCAD_UNI_ID_UNIDADE IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_UNI_ID_UNIDADE IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PCAD_UNI_ID_UNIDADE || ''' ))) ';
  END IF;
  IF PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PCAD_LAT_ID_LOCAL_ATENDIMENTO || ''' ))) ';
  END IF;
  IF PCAD_SET_ID IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_SET_ID_REALIZACAO IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PCAD_SET_ID || ''' ))) ';
  END IF;
  IF PREP_PGM_TP_CREDENCIA_PROF IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.REP_PGM_TP_CREDENCIA_PROF = ' || CHR(39) || PREP_PGM_TP_CREDENCIA_PROF || CHR(39);
  END IF;
  IF PTIS_MED_CD_TABELAMEDICA IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.TIS_MED_CD_TABELAMEDICA IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PTIS_MED_CD_TABELAMEDICA || ''' ))) ';
  END IF;
  IF PAUX_EPP_CD_ESPECPROC IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.AUX_EPP_CD_ESPECPROC IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PAUX_EPP_CD_ESPECPROC || ''' ))) ';
  END IF;
  IF PAUX_GPC_CD_GRUPOPROC IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.AUX_GPC_CD_GRUPOPROC IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PAUX_GPC_CD_GRUPOPROC || ''' ))) ';
  END IF;
  IF PCAD_TPE_CD_CODIGO IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_TPE_CD_CODIGO IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PCAD_TPE_CD_CODIGO || ''' ))) ';
  END IF;
  IF PCAD_TAP_TP_ATRIBUTO IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_TAP_TP_ATRIBUTO IN ( ' || PCAD_TAP_TP_ATRIBUTO || ')';
  END IF;
  IF PCAD_CNV_ID_CONVENIO IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_CNV_ID_CONVENIO = ' || PCAD_CNV_ID_CONVENIO;
  END IF;
  IF PCAD_PRD_ID IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_PRD_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PCAD_PRD_ID || ''' ))) ';
  END IF;
  IF PSEMCONSULTA = 'S' THEN
    V_WHERE := V_WHERE || ' AND PGM.AUX_EPP_CD_ESPECPROC != 101 ';
  END IF;
  IF PCAD_PRO_ID_PROFISSIONAL IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PRO.CAD_PRO_ID_PROFISSIONAL IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PCAD_PRO_ID_PROFISSIONAL || ''' ))) ';
  END IF;
  IF PVALORPAGOZERADO = 'S' THEN
    V_WHERE := V_WHERE || ' AND (PGM.REP_PGM_VL_PAGO = 0 OR PGM.REP_PGM_VL_PAGO IS NULL) AND PGM.REP_PGM_FL_PAGO IS NOT NULL ';
  ELSE
    V_WHERE := V_WHERE || ' AND PGM.REP_PGM_FL_PAGO IN (''P'', ''F'') ';
  END IF;
  IF PSEMVALORPAGO = 'S' THEN
    V_WHERE := V_WHERE || ' AND (PGM.REP_PGM_VL_PAGO > 0 AND PGM.REP_PGM_VL_PAGO IS NOT NULL) ';
  END IF;
  IF PTIS_CBO_CD_CBOS IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.TIS_CBO_CD_CBOS IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PTIS_CBO_CD_CBOS || ''' ))) ';
  END IF;
  IF PREP_PGM_DT_INICIO_REALIZACAO IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.REP_PGM_DT_INICIO_REALIZACAO BETWEEN
                                TO_DATE(''' || PREP_PGM_DT_INICIO_REALIZACAO || ''',''DD/MM/YYY'' )
                            AND TO_DATE(''' || PREP_PGM_DT_FIM_REALIZACAO || ''',''DD/MM/YYY'' )';
  END IF;

  V_SELECT := 'SELECT
       PGM.ATD_ATE_FL_CARATER_SOLIC || ''-'' || PGM.ATD_ATE_ID ATD_ATE_ID,
       FNC_REP_REL_SUB_VLHR_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                   ' || PREP_PGM_ANO_PAGTO_INI || ',
                                        PGM.CAD_CLC_ID,
                                        PGM.REP_PGM_TP_CREDENCIA_PROF,
                                   ' || PREP_PGM_MES_PAGTO_FIM || ',
                                   ' || PREP_PGM_ANO_PAGTO_FIM || ')                           SEMVLHORA,

       FNC_REP_REL_SUB_VLHREX_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                     ' || PREP_PGM_ANO_PAGTO_INI || ',
                                          PGM.CAD_CLC_ID,
                                          PGM.REP_PGM_TP_CREDENCIA_PROF,
                                     ' || PREP_PGM_MES_PAGTO_FIM || ',
                                     ' || PREP_PGM_ANO_PAGTO_FIM || ')                         SEMVLHORAEXTRA,



       FNC_REP_REL_SUB_VLHR_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                   ' || PREP_PGM_ANO_PAGTO_INI || ',
                                        PGM.CAD_CLC_ID,
                                        PGM.REP_PGM_TP_CREDENCIA_PROF,
                                   ' || PREP_PGM_MES_PAGTO_FIM || ',
                                   ' || PREP_PGM_ANO_PAGTO_FIM || ')                           VLHORA,

       FNC_REP_REL_SUB_VLHREX_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                     ' || PREP_PGM_ANO_PAGTO_INI || ',
                                          PGM.CAD_CLC_ID,
                                          PGM.REP_PGM_TP_CREDENCIA_PROF,
                                     ' || PREP_PGM_MES_PAGTO_FIM || ',
                                     ' || PREP_PGM_ANO_PAGTO_FIM || ')                         VLHORAEXTRA,


       FNC_REP_REL_SUB_VLACRES_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                      ' || PREP_PGM_ANO_PAGTO_INI || ',
                                           PGM.CAD_CLC_ID,
                                           PGM.REP_PGM_TP_CREDENCIA_PROF,
                                      ' || PREP_PGM_MES_PAGTO_FIM || ',
                                      ' || PREP_PGM_ANO_PAGTO_FIM || ')                       VLACRESCIMO_SANTEC,

       FNC_REP_REL_SUB_VLDESC_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                     ' || PREP_PGM_ANO_PAGTO_INI || ',
                                          PGM.CAD_CLC_ID,
                                          PGM.REP_PGM_TP_CREDENCIA_PROF,
                                     ' || PREP_PGM_MES_PAGTO_FIM || ',
                                     ' || PREP_PGM_ANO_PAGTO_FIM || ')                        VLDESCONTO_SANTEC,


       FNC_REP_REL_SUB_VLACRES_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                      ' || PREP_PGM_ANO_PAGTO_INI || ',
                                           PGM.CAD_CLC_ID,
                                           PGM.REP_PGM_TP_CREDENCIA_PROF,
                                      ' || PREP_PGM_MES_PAGTO_FIM || ',
                                      ' || PREP_PGM_ANO_PAGTO_FIM || ')                       VLACRESCIMO_CANTEC,

       FNC_REP_REL_SUB_VLDESC_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                     ' || PREP_PGM_ANO_PAGTO_INI || ',
                                          PGM.CAD_CLC_ID,
                                          PGM.REP_PGM_TP_CREDENCIA_PROF,
                                     ' || PREP_PGM_MES_PAGTO_FIM || ',
                                     ' || PREP_PGM_ANO_PAGTO_FIM || ')                        VLDESCONTO_CANTEC,



       FNC_REP_REL_SUB_VLHR_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                   ' || PREP_PGM_ANO_PAGTO_INI || ',
                                        PGM.CAD_CLC_ID,
                                        PGM.REP_PGM_TP_CREDENCIA_PROF,
                                   ' || PREP_PGM_MES_PAGTO_FIM || ',
                                   ' || PREP_PGM_ANO_PAGTO_FIM || ')  +

       FNC_REP_REL_SUB_VLACRES_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                      ' || PREP_PGM_ANO_PAGTO_INI || ',
                                           PGM.CAD_CLC_ID,
                                           PGM.REP_PGM_TP_CREDENCIA_PROF,
                                      ' || PREP_PGM_MES_PAGTO_FIM || ',
                                      ' || PREP_PGM_ANO_PAGTO_FIM || ')  -

       FNC_REP_REL_SUB_VLDESC_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                     ' || PREP_PGM_ANO_PAGTO_INI || ',
                                          PGM.CAD_CLC_ID,
                                          PGM.REP_PGM_TP_CREDENCIA_PROF,
                                     ' || PREP_PGM_MES_PAGTO_FIM || ',
                                     ' || PREP_PGM_ANO_PAGTO_FIM || ')                     VLPARCIAL_SANTEC,



       FNC_REP_REL_SUB_VLHR_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                   ' || PREP_PGM_ANO_PAGTO_INI || ',
                                        PGM.CAD_CLC_ID,
                                        PGM.REP_PGM_TP_CREDENCIA_PROF,
                                   ' || PREP_PGM_MES_PAGTO_FIM || ',
                                   ' || PREP_PGM_ANO_PAGTO_FIM || ')  +

       FNC_REP_REL_SUB_VLACRES_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                      ' || PREP_PGM_ANO_PAGTO_INI || ',
                                           PGM.CAD_CLC_ID,
                                           PGM.REP_PGM_TP_CREDENCIA_PROF,
                                      ' || PREP_PGM_MES_PAGTO_FIM || ',
                                      ' || PREP_PGM_ANO_PAGTO_FIM || ')  -

       FNC_REP_REL_SUB_VLDESC_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                     ' || PREP_PGM_ANO_PAGTO_INI || ',
                                          PGM.CAD_CLC_ID,
                                          PGM.REP_PGM_TP_CREDENCIA_PROF,
                                      ' || PREP_PGM_MES_PAGTO_FIM || ',
                                      ' || PREP_PGM_ANO_PAGTO_FIM || ')                     VLPARCIAL_CANTEC,

       PGM.FAT_CCP_ID,
       CNV.CAD_CNV_CD_HAC_PRESTADOR,
       TPE.CAD_TPE_DS_DESCRICAO,
       PES.CAD_PES_NM_PESSOA,
       PRD.CAD_PRD_CD_CODIGO,
       PRD.CAD_PRD_DS_DESCRICAO,
       TO_CHAR(TRUNC(PGM.REP_PGM_DT_INICIO_REALIZACAO),'||CHR(39)||'DD/MM/YYYY'||CHR(39)||') || '||CHR(39)||' '||CHR(39)||' || 
               SUBSTR(LPAD(TO_CHAR(PGM.REP_PGM_HR_INICIO_REALIZACAO),4,'||CHR(39)||'0'||CHR(39)||'),0,2) || '||CHR(39)||':'||CHR(39)||' || 
               SUBSTR(LPAD(TO_CHAR(PGM.REP_PGM_HR_INICIO_REALIZACAO),4,'||CHR(39)||'0'||CHR(39)||'),3,2) REP_PGM_DT_INICIO_REALIZACAO,
       PGM.CAD_CLC_ID,
       PGM.CAD_UNI_ID_UNIDADE,
       PGM.REP_PGM_TP_CREDENCIA_PROF,
       NVL(PGM.REP_PGM_QT_CONSUMO,0) QTD_CONSUMO,
       NVL(PGM.REP_PGM_VL_FATURADO,0) VL_FATURADO,
       NVL(PGM.REP_PGM_VL_CALCULADO,0) VL_CALCULADO,
       NVL(PGM.REP_PGM_VL_PAGO,0) VL_PAGO,
       UNI.CAD_UNI_CD_UNID_HOSPITALAR,
       UNI.CAD_UNI_DS_UNIDADE,
       LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
       CLC.CAD_CLC_CD_CLINICA,
       CLC.CAD_CLC_DS_DESCRICAO,
       PRO.CAD_PRO_NR_CONSELHO,
       PRO.CAD_PRO_NM_NOME,
       PGM.CAD_PLA_CD_TIPOPLANO,
       PGM.TIS_TAC_CD_TIPO_ACOMOD_AUT,
       TIS.TIS_TAC_DS_TIPO_ACOMODACAO,
       EPP.AUX_EPP_CD_ESPECPROC,
       EPP.AUX_EPP_DS_DESCRICAO,
       PRD.CAD_PRD_CD_CODIGO || ' || CHR(39) || ' - ' || CHR(39) || ' || PRD.CAD_PRD_DS_DESCRICAO PROCEDIMENTO,
       DECODE(PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO, 29, CEC.CAD_CEC_DS_CCUSTO, NULL) CAD_CEC_DS_CCUSTO,
       CBO.TIS_CBO_DS_CBOS
    FROM TB_REP_PGM_PAGTO_MEDICO PGM
    LEFT JOIN TB_CAD_CEC_CENTRO_CUSTO CCUSTO
      ON PGM.CAD_CEC_ID_CCUSTO = CCUSTO.CAD_CEC_ID_CCUSTO
    LEFT JOIN TB_CAD_CEC_CENTRO_CUSTO CEC
      ON CCUSTO.CAD_CEC_CD_GRUPOCCUSTO = CEC.CAD_CEC_CD_CCUSTO
   INNER JOIN TB_CAD_CNV_CONVENIO CNV
      ON CNV.CAD_CNV_ID_CONVENIO = PGM.CAD_CNV_ID_CONVENIO
   INNER JOIN TB_CAD_TPE_TIPOEMPRESA TPE
      ON TPE.CAD_TPE_CD_CODIGO = CNV.CAD_TPE_CD_CODIGO
   INNER JOIN TB_CAD_PAC_PACIENTE PAC
      ON PAC.CAD_PAC_ID_PACIENTE = PGM.CAD_PAC_ID_PACIENTE
   INNER JOIN TB_CAD_PES_PESSOA PES
      ON PES.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA
   INNER JOIN TB_CAD_UNI_UNIDADE UNI
      ON UNI.CAD_UNI_ID_UNIDADE = PGM.CAD_UNI_ID_UNIDADE
   INNER JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO LAT
      ON LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO
   INNER JOIN TB_CAD_SET_SETOR SETOR
      ON SETOR.CAD_SET_ID = PGM.CAD_SET_ID_REALIZACAO
   INNER JOIN TB_CAD_PRD_PRODUTO PRD
      ON PRD.CAD_PRD_ID = PGM.CAD_PRD_ID
   INNER JOIN TB_CAD_CLC_CLINICA_CREDENCIADA CLC
      ON CLC.CAD_CLC_ID = PGM.CAD_CLC_ID
    LEFT JOIN TB_TIS_TAC_TIPO_ACOMODACAO TIS
      ON TIS.TIS_TAC_CD_TIPO_ACOMODACAO = PGM.TIS_TAC_CD_TIPO_ACOMOD_AUT
    LEFT JOIN TB_AUX_EPP_ESPECPROC EPP
      ON EPP.AUX_EPP_CD_ESPECPROC = PGM.AUX_EPP_CD_ESPECPROC
     AND EPP.TIS_MED_CD_TABELAMEDICA = PGM.TIS_MED_CD_TABELAMEDICA

   INNER JOIN TB_CAD_PRO_PROFISSIONAL PRO
      ON PRO.CAD_PRO_ID_PROFISSIONAL = PGM.CAD_PRO_ID_PROFISSIONAL
    LEFT JOIN TB_TIS_CBO_CBOS CBO
      ON PGM.TIS_CBO_CD_CBOS = CBO.TIS_CBO_CD_CBOS ' ;

  -- SE TIVER CRM, COLOCA O NOME DO MEDICO NO ORDER BY
  IF (PSEMCRM IS NULL OR PSEMCRM = 'N') THEN
    V_ORDENAR_COM_CRM := ' PRO.CAD_PRO_NM_NOME, ';
  ELSE
    V_ORDENAR_COM_CRM := ' ';
  END IF;
  -- ORDENACAO PADRAO (DAS QUEBRAS/AGRUPAMENTOS)
  V_ORDER := ' ORDER BY CLC.CAD_CLC_DS_DESCRICAO,
                        EPP.AUX_EPP_DS_DESCRICAO,
                        LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
                        TPE.CAD_TPE_DS_DESCRICAO, ';
  IF PORDENACAO = 'A' THEN
    -- ORDENACAO (A)LFABETICA (DEFAULT)
    V_ORDER := V_ORDER || V_ORDENAR_COM_CRM || ' UNI.CAD_UNI_CD_UNID_HOSPITALAR,
                                                 PES.CAD_PES_NM_PESSOA';
  ELSIF PORDENACAO = 'C' THEN
    -- ORDENACAO POR (C)ONVENIO
    V_ORDER := V_ORDER || V_ORDENAR_COM_CRM || ' UNI.CAD_UNI_CD_UNID_HOSPITALAR,
                                                 CNV.CAD_CNV_CD_HAC_PRESTADOR,
                                                 PES.CAD_PES_NM_PESSOA';
  ELSE
    -- ORDENACAO POR (T)EMPO
    V_ORDER := V_ORDER || V_ORDENAR_COM_CRM || ' UNI.CAD_UNI_CD_UNID_HOSPITALAR,
                                                 TO_CHAR(TRUNC(PGM.REP_PGM_DT_INICIO_REALIZACAO),'||CHR(39)||'DD/MM/YYYY'||CHR(39)||') || '||CHR(39)||' '||CHR(39)||' || 
                                                         SUBSTR(LPAD(TO_CHAR(PGM.REP_PGM_HR_INICIO_REALIZACAO),4,'||CHR(39)||'0'||CHR(39)||'),0,2) || '||CHR(39)||':'||CHR(39)||' || 
                                                         SUBSTR(LPAD(TO_CHAR(PGM.REP_PGM_HR_INICIO_REALIZACAO),4,'||CHR(39)||'0'||CHR(39)||'),3,2),
                                                 PES.CAD_PES_NM_PESSOA';
  END IF;
  OPEN V_CURSOR FOR V_SELECT || V_WHERE || V_ORDER;
       IO_CURSOR := V_CURSOR;
       DBMS_OUTPUT.PUT_LINE(V_SELECT || V_WHERE || V_ORDER);
END PRC_REP_REL_ANALIT_PROCEDREAL;