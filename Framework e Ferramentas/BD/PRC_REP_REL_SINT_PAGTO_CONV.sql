CREATE OR REPLACE PROCEDURE "PRC_REP_REL_SINT_PAGTO_CONV" (PREP_PGM_MES_PAGTO_INI        IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE,
                                                          PREP_PGM_ANO_PAGTO_INI        IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE,
                                                          PREP_PGM_MES_PAGTO_FIM        IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE DEFAULT NULL,
                                                          PREP_PGM_ANO_PAGTO_FIM        IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE DEFAULT NULL,
                                                          PCAD_CLC_ID                   IN TB_REP_PGM_PAGTO_MEDICO.CAD_CLC_ID%TYPE DEFAULT NULL,
                                                          PCAD_UNI_ID_UNIDADE           IN TB_REP_PGM_PAGTO_MEDICO.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
                                                          PCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_REP_PGM_PAGTO_MEDICO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
                                                          PCAD_SET_ID                   IN TB_REP_PGM_PAGTO_MEDICO.CAD_SET_ID_REALIZACAO%TYPE DEFAULT NULL,
                                                          PREP_PGM_TP_CREDENCIA_PROF    IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_TP_CREDENCIA_PROF%TYPE,
                                                          PCAD_TPE_CD_CODIGO            IN TB_REP_PGM_PAGTO_MEDICO.CAD_TPE_CD_CODIGO%TYPE DEFAULT NULL,
                                                          PTIS_MED_CD_TABELAMEDICA      IN STRING DEFAULT NULL,
                                                          PAUX_EPP_CD_ESPECPROC         IN STRING DEFAULT NULL,
                                                          PAUX_GPC_CD_GRUPOPROC         IN STRING DEFAULT NULL,
                                                          PCAD_PRD_ID                   IN STRING,
                                                          PCAD_TAP_TP_ATRIBUTO          IN STRING DEFAULT NULL,
                                                          PSEMCONSULTA                  IN STRING DEFAULT NULL,
                                                          IO_CURSOR                     OUT PKG_CURSOR.T_CURSOR) IS
  /********************************************************************
  *
  *    PROCEDURE: PRC_REP_REL_SINT_PAGTO_CONV
  *    DATA 23/02/2012   POR: DAVI S. M. DOS REIS
  *
  *********************************************************************/
  V_CURSOR PKG_CURSOR.T_CURSOR;
  V_SELECT VARCHAR2(30000);
  V_WHERE  VARCHAR2(15000);
  V_REP_PGM_TP_CREDENCIA_PROF VARCHAR2(15000);
BEGIN
  IF (PREP_PGM_TP_CREDENCIA_PROF IS NULL) THEN
    V_REP_PGM_TP_CREDENCIA_PROF := 'NULL';
  ELSE
    V_REP_PGM_TP_CREDENCIA_PROF := CHR(39) || PREP_PGM_TP_CREDENCIA_PROF || CHR(39);
  END IF;
  V_WHERE := ' WHERE PGM.REP_PGM_FL_STATUS <> ''I'' ';
  V_WHERE := V_WHERE || ' AND ((PGM.REP_PGM_MES_PAGTO + PGM.REP_PGM_ANO_PAGTO * 100) >=
                               (' || TO_CHAR(PREP_PGM_MES_PAGTO_INI + PREP_PGM_ANO_PAGTO_INI * 100) || '))';
  IF PREP_PGM_MES_PAGTO_FIM IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND ((PGM.REP_PGM_MES_PAGTO + PGM.REP_PGM_ANO_PAGTO * 100) <=
                                 (' || TO_CHAR(PREP_PGM_MES_PAGTO_FIM + PREP_PGM_ANO_PAGTO_FIM * 100) || '))';
  ELSE
    V_WHERE := V_WHERE || ' AND ((PGM.REP_PGM_MES_PAGTO + PGM.REP_PGM_ANO_PAGTO * 100) <=
                                 (' || TO_CHAR(PREP_PGM_MES_PAGTO_INI + PREP_PGM_ANO_PAGTO_INI * 100) || '))';
  END IF;
  IF PCAD_UNI_ID_UNIDADE IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_UNI_ID_UNIDADE = ' || PCAD_UNI_ID_UNIDADE;
  END IF;
  IF PCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO = ' || PCAD_LAT_ID_LOCAL_ATENDIMENTO;
  END IF;
  IF PCAD_CLC_ID IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_CLC_ID = ' || PCAD_CLC_ID;
  END IF;
  IF PREP_PGM_TP_CREDENCIA_PROF IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.REP_PGM_TP_CREDENCIA_PROF = ' || CHR(39) || PREP_PGM_TP_CREDENCIA_PROF || CHR(39);
  END IF;
  IF PCAD_SET_ID IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_SET_ID_REALIZACAO = ' || PCAD_SET_ID;
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
  IF PCAD_PRD_ID IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_PRD_ID IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PCAD_PRD_ID || ''' ))) ';
  END IF;
  IF PCAD_TAP_TP_ATRIBUTO IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_TAP_TP_ATRIBUTO IN (' || PCAD_TAP_TP_ATRIBUTO || ')';
  END IF;
  IF PCAD_TPE_CD_CODIGO IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_TPE_CD_CODIGO = ' || CHR(39) || PCAD_TPE_CD_CODIGO || CHR(39);
  END IF;
  IF PSEMCONSULTA IS NOT NULL AND PSEMCONSULTA = 'S' THEN
    V_WHERE := V_WHERE || ' AND PGM.AUX_EPP_CD_ESPECPROC != 101 ';
  END IF;
  V_SELECT := 'SELECT CLC.CAD_CLC_DS_DESCRICAO,
           CLC.CAD_CLC_CD_CLINICA,
           PRO.TIS_CPR_CD_CONSELHOPROF,
           PRO.CAD_PRO_NR_CONSELHO,
           PRO.CAD_PRO_NM_NOME,
           PGM.CAD_TAP_TP_ATRIBUTO,
           UNI.CAD_UNI_DS_UNIDADE,
           LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
           CNV.CAD_CNV_CD_HAC_PRESTADOR,
           CNV.CAD_CNV_NM_FANTASIA,
           TPE.CAD_TPE_DS_DESCRICAO,
           PRD.CAD_PRD_CD_CODIGO,
           PRD.CAD_PRD_DS_DESCRICAO,
           PGM.CAD_CLC_ID,
           PGM.REP_PGM_TP_CREDENCIA_PROF,

           FNC_REP_REL_SUB_VLHR_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                       ' || PREP_PGM_ANO_PAGTO_INI || ',
                                            PGM.CAD_CLC_ID,
                                       PGM.REP_PGM_TP_CREDENCIA_PROF,
                                       ' || PREP_PGM_MES_PAGTO_FIM || ',
                                       ' || PREP_PGM_ANO_PAGTO_FIM || ') SEMVLHORA,

           FNC_REP_REL_SUB_VLHREX_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                         ' || PREP_PGM_ANO_PAGTO_INI || ',
                                              PGM.CAD_CLC_ID,
                                         PGM.REP_PGM_TP_CREDENCIA_PROF,
                                         ' || PREP_PGM_MES_PAGTO_FIM || ',
                                         ' || PREP_PGM_ANO_PAGTO_FIM || ') SEMVLHORAEXTRA,


           FNC_REP_REL_SUB_VLHR_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                       ' || PREP_PGM_ANO_PAGTO_INI || ',
                                            PGM.CAD_CLC_ID,
                                       PGM.REP_PGM_TP_CREDENCIA_PROF,
                                       ' || PREP_PGM_MES_PAGTO_FIM || ',
                                       ' || PREP_PGM_ANO_PAGTO_FIM || ') VLHORA,

           FNC_REP_REL_SUB_VLHREX_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                         ' || PREP_PGM_ANO_PAGTO_INI || ',
                                              PGM.CAD_CLC_ID,
                                         PGM.REP_PGM_TP_CREDENCIA_PROF,
                                         ' || PREP_PGM_MES_PAGTO_FIM || ',
                                         ' || PREP_PGM_ANO_PAGTO_FIM || ') VLHORAEXTRA,


           FNC_REP_REL_SUB_VLACRES_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                          ' || PREP_PGM_ANO_PAGTO_INI || ',
                                               PGM.CAD_CLC_ID,
                                          PGM.REP_PGM_TP_CREDENCIA_PROF,
                                          ' || PREP_PGM_MES_PAGTO_FIM || ',
                                          ' || PREP_PGM_ANO_PAGTO_FIM || ') VLACRESCIMO_SANTEC,

           FNC_REP_REL_SUB_VLDESC_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                         ' || PREP_PGM_ANO_PAGTO_INI || ',
                                              PGM.CAD_CLC_ID,
                                         PGM.REP_PGM_TP_CREDENCIA_PROF,
                                         ' || PREP_PGM_MES_PAGTO_FIM || ',
                                         ' || PREP_PGM_ANO_PAGTO_FIM || ') VLDESCONTO_SANTEC,


           FNC_REP_REL_SUB_VLACRES_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                          ' || PREP_PGM_ANO_PAGTO_INI || ',
                                               PGM.CAD_CLC_ID,
                                          PGM.REP_PGM_TP_CREDENCIA_PROF,
                                          ' || PREP_PGM_MES_PAGTO_FIM || ',
                                          ' || PREP_PGM_ANO_PAGTO_FIM || ') VLACRESCIMO_CANTEC,

           FNC_REP_REL_SUB_VLDESC_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                         ' || PREP_PGM_ANO_PAGTO_INI || ',
                                              PGM.CAD_CLC_ID,
                                         PGM.REP_PGM_TP_CREDENCIA_PROF,
                                         ' || PREP_PGM_MES_PAGTO_FIM || ',
                                         ' || PREP_PGM_ANO_PAGTO_FIM || ') VLDESCONTO_CANTEC,


           FNC_REP_REL_SUB_VLHR_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                       ' || PREP_PGM_ANO_PAGTO_INI || ',
                                            PGM.CAD_CLC_ID,
                                       PGM.REP_PGM_TP_CREDENCIA_PROF,
                                       ' || PREP_PGM_MES_PAGTO_FIM || ',
                                       ' || PREP_PGM_ANO_PAGTO_FIM || ') +
           FNC_REP_REL_SUB_VLACRES_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                          ' || PREP_PGM_ANO_PAGTO_INI || ',
                                               PGM.CAD_CLC_ID,
                                          PGM.REP_PGM_TP_CREDENCIA_PROF,
                                          ' || PREP_PGM_MES_PAGTO_FIM || ',
                                          ' || PREP_PGM_ANO_PAGTO_FIM || ') -
           FNC_REP_REL_SUB_VLDESC_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                         ' || PREP_PGM_ANO_PAGTO_INI || ',
                                              PGM.CAD_CLC_ID,
                                         PGM.REP_PGM_TP_CREDENCIA_PROF,
                                         ' || PREP_PGM_MES_PAGTO_FIM || ',
                                         ' || PREP_PGM_ANO_PAGTO_FIM || ') VLPARCIAL_SANTEC,


           FNC_REP_REL_SUB_VLHR_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                       ' || PREP_PGM_ANO_PAGTO_INI || ',
                                            PGM.CAD_CLC_ID,
                                       PGM.REP_PGM_TP_CREDENCIA_PROF,
                                       ' || PREP_PGM_MES_PAGTO_FIM || ',
                                       ' || PREP_PGM_ANO_PAGTO_FIM || ') +

           FNC_REP_REL_SUB_VLACRES_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                          ' || PREP_PGM_ANO_PAGTO_INI || ',
                                               PGM.CAD_CLC_ID,
                                          PGM.REP_PGM_TP_CREDENCIA_PROF,
                                          ' || PREP_PGM_MES_PAGTO_FIM || ',
                                          ' || PREP_PGM_ANO_PAGTO_FIM || ') -

           FNC_REP_REL_SUB_VLDESC_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                         ' || PREP_PGM_ANO_PAGTO_INI || ',
                                              PGM.CAD_CLC_ID,
                                         PGM.REP_PGM_TP_CREDENCIA_PROF,
                                         ' || PREP_PGM_MES_PAGTO_FIM || ',
                                         ' || PREP_PGM_ANO_PAGTO_FIM || ') VLPARCIAL_CANTEC,
           NVL(SUM(PGM.REP_PGM_QT_CONSUMO), 0) REP_PGM_QT_CONSUMO,
           NVL(SUM(PGM.REP_PGM_VL_FATURADO), 0) REP_PGM_VL_FATURADO,
           NVL(SUM(PGM.REP_PGM_VL_CALCULADO), 0) REP_PGM_VL_CALCULADO,
           NVL(SUM(PGM.REP_PGM_VL_PAGO), 0) REP_PGM_VL_PAGO
      FROM TB_REP_PGM_PAGTO_MEDICO PGM
     INNER JOIN TB_CAD_CNV_CONVENIO CNV
        ON CNV.CAD_CNV_ID_CONVENIO = PGM.CAD_CNV_ID_CONVENIO
     INNER JOIN TB_CAD_TPE_TIPOEMPRESA TPE
        ON TPE.CAD_TPE_CD_CODIGO = CNV.CAD_TPE_CD_CODIGO
     INNER JOIN TB_CAD_UNI_UNIDADE UNI
        ON UNI.CAD_UNI_ID_UNIDADE = PGM.CAD_UNI_ID_UNIDADE
     INNER JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO LAT
        ON LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO
     INNER JOIN TB_CAD_PRD_PRODUTO PRD
        ON PRD.CAD_PRD_ID = PGM.CAD_PRD_ID
     INNER JOIN TB_CAD_CLC_CLINICA_CREDENCIADA CLC
        ON CLC.CAD_CLC_ID = PGM.CAD_CLC_ID

     INNER JOIN TB_CAD_PRO_PROFISSIONAL PRO
        ON PRO.CAD_PRO_ID_PROFISSIONAL = PGM.CAD_PRO_ID_PROFISSIONAL
      LEFT JOIN TB_TIS_CBO_CBOS CBO
        ON PGM.TIS_CBO_CD_CBOS = CBO.TIS_CBO_CD_CBOS ';

  V_SELECT := V_SELECT || V_WHERE;
--  DBMS_OUTPUT.PUT_LINE(V_SELECT);

  V_SELECT := V_SELECT || ' GROUP BY
           CLC.CAD_CLC_DS_DESCRICAO,
           CLC.CAD_CLC_CD_CLINICA,
           PRO.TIS_CPR_CD_CONSELHOPROF,
           PRO.CAD_PRO_NR_CONSELHO,
           PRO.CAD_PRO_NM_NOME,
           PGM.CAD_TAP_TP_ATRIBUTO,
           UNI.CAD_UNI_DS_UNIDADE,
           LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
           CNV.CAD_CNV_CD_HAC_PRESTADOR,
           CNV.CAD_CNV_NM_FANTASIA,
           TPE.CAD_TPE_DS_DESCRICAO,
           PRD.CAD_PRD_CD_CODIGO,
           PRD.CAD_PRD_DS_DESCRICAO,
           PGM.CAD_CLC_ID,
           PGM.REP_PGM_ANO_PAGTO,
           PGM.REP_PGM_TP_CREDENCIA_PROF,
           FNC_REP_REL_SUB_VLHR_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                       ' || PREP_PGM_ANO_PAGTO_INI || ',
                                            PGM.CAD_CLC_ID,
                                       PGM.REP_PGM_TP_CREDENCIA_PROF,
                                       ' || PREP_PGM_MES_PAGTO_FIM || ',
                                       ' || PREP_PGM_ANO_PAGTO_FIM || '),
           FNC_REP_REL_SUB_VLHREX_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                         ' || PREP_PGM_ANO_PAGTO_INI || ',
                                              PGM.CAD_CLC_ID,
                                         PGM.REP_PGM_TP_CREDENCIA_PROF,
                                         ' || PREP_PGM_MES_PAGTO_FIM || ',
                                         ' || PREP_PGM_ANO_PAGTO_FIM || '),


           FNC_REP_REL_SUB_VLHR_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                       ' || PREP_PGM_ANO_PAGTO_INI || ',
                                            PGM.CAD_CLC_ID,
                                       PGM.REP_PGM_TP_CREDENCIA_PROF,
                                       ' || PREP_PGM_MES_PAGTO_FIM || ',
                                       ' || PREP_PGM_ANO_PAGTO_FIM || '),

           FNC_REP_REL_SUB_VLHREX_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                         ' || PREP_PGM_ANO_PAGTO_INI || ',
                                              PGM.CAD_CLC_ID,
                                         PGM.REP_PGM_TP_CREDENCIA_PROF,
                                         ' || PREP_PGM_MES_PAGTO_FIM || ',
                                         ' || PREP_PGM_ANO_PAGTO_FIM || '),


           FNC_REP_REL_SUB_VLACRES_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                          ' || PREP_PGM_ANO_PAGTO_INI || ',
                                               PGM.CAD_CLC_ID,
                                          PGM.REP_PGM_TP_CREDENCIA_PROF,
                                          ' || PREP_PGM_MES_PAGTO_FIM || ',
                                          ' || PREP_PGM_ANO_PAGTO_FIM || '),

           FNC_REP_REL_SUB_VLDESC_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                         ' || PREP_PGM_ANO_PAGTO_INI || ',
                                              PGM.CAD_CLC_ID,
                                         PGM.REP_PGM_TP_CREDENCIA_PROF,
                                         ' || PREP_PGM_MES_PAGTO_FIM || ',
                                         ' || PREP_PGM_ANO_PAGTO_FIM || '),


           FNC_REP_REL_SUB_VLACRES_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                          ' || PREP_PGM_ANO_PAGTO_INI || ',
                                               PGM.CAD_CLC_ID,
                                          PGM.REP_PGM_TP_CREDENCIA_PROF,
                                          ' || PREP_PGM_MES_PAGTO_FIM || ',
                                          ' || PREP_PGM_ANO_PAGTO_FIM || '),

           FNC_REP_REL_SUB_VLDESC_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                         ' || PREP_PGM_ANO_PAGTO_INI || ',
                                              PGM.CAD_CLC_ID,
                                         PGM.REP_PGM_TP_CREDENCIA_PROF,
                                         ' || PREP_PGM_MES_PAGTO_FIM || ',
                                         ' || PREP_PGM_ANO_PAGTO_FIM || '),


           FNC_REP_REL_SUB_VLHR_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                       ' || PREP_PGM_ANO_PAGTO_INI || ',
                                            PGM.CAD_CLC_ID,
                                       PGM.REP_PGM_TP_CREDENCIA_PROF,
                                       ' || PREP_PGM_MES_PAGTO_FIM || ',
                                       ' || PREP_PGM_ANO_PAGTO_FIM || ') +
           FNC_REP_REL_SUB_VLACRES_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                          ' || PREP_PGM_ANO_PAGTO_INI || ',
                                               PGM.CAD_CLC_ID,
                                          PGM.REP_PGM_TP_CREDENCIA_PROF,
                                          ' || PREP_PGM_MES_PAGTO_FIM || ',
                                          ' || PREP_PGM_ANO_PAGTO_FIM || ') -
           FNC_REP_REL_SUB_VLDESC_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                         ' || PREP_PGM_ANO_PAGTO_INI || ',
                                              PGM.CAD_CLC_ID,
                                         PGM.REP_PGM_TP_CREDENCIA_PROF,
                                         ' || PREP_PGM_MES_PAGTO_FIM || ',
                                         ' || PREP_PGM_ANO_PAGTO_FIM || '),


           FNC_REP_REL_SUB_VLHR_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                       ' || PREP_PGM_ANO_PAGTO_INI || ',
                                            PGM.CAD_CLC_ID,
                                       PGM.REP_PGM_TP_CREDENCIA_PROF,
                                       ' || PREP_PGM_MES_PAGTO_FIM || ',
                                       ' || PREP_PGM_ANO_PAGTO_FIM || ') +
           FNC_REP_REL_SUB_VLACRES_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                          ' || PREP_PGM_ANO_PAGTO_INI || ',
                                               PGM.CAD_CLC_ID,
                                          PGM.REP_PGM_TP_CREDENCIA_PROF,
                                          ' || PREP_PGM_MES_PAGTO_FIM || ',
                                          ' || PREP_PGM_ANO_PAGTO_FIM || ') -
           FNC_REP_REL_SUB_VLDESC_CANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
                                         ' || PREP_PGM_ANO_PAGTO_INI || ',
                                              PGM.CAD_CLC_ID,
                                         PGM.REP_PGM_TP_CREDENCIA_PROF,
                                         ' || PREP_PGM_MES_PAGTO_FIM || ',
                                         ' || PREP_PGM_ANO_PAGTO_FIM || ')';
  DBMS_OUTPUT.PUT_LINE(V_SELECT);
  OPEN V_CURSOR FOR V_SELECT;
  IO_CURSOR := V_CURSOR;
END PRC_REP_REL_SINT_PAGTO_CONV;