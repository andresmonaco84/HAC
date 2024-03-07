CREATE OR REPLACE PROCEDURE "PRC_REP_REL_RESUMO_PROCED" (
    pREP_PGM_MES_PAGTO_INI                IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE,
    pREP_PGM_ANO_PAGTO_INI                IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE,
    pREP_PGM_MES_PAGTO_FIM                IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE DEFAULT NULL,
    pREP_PGM_ANO_PAGTO_FIM                IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE DEFAULT NULL,
    pCAD_CLC_ID                           IN TB_CAD_CLC_CLINICA_CREDENCIADA.CAD_CLC_ID%TYPE DEFAULT NULL,
    pCAD_UNI_ID_UNIDADE                   IN STRING DEFAULT NULL,
    pCAD_PRO_ID_PROFISSIONAL              IN STRING DEFAULT NULL,
    pCAD_LAT_ID_LOCAL_ATENDIMENTO         IN STRING DEFAULT NULL,
    pCAD_TPE_CD_CODIGO                    IN STRING DEFAULT NULL,
    pTIS_MED_CD_TABELAMEDICA              IN STRING DEFAULT NULL,
    pAUX_EPP_CD_ESPECPROC                 IN STRING DEFAULT NULL,
    pAUX_GPC_CD_GRUPOPROC                 IN STRING DEFAULT NULL,
    pCAD_PRD_ID                           IN STRING DEFAULT NULL,
    pCAD_TAP_TP_ATRIBUTO                  IN TB_REP_PGM_PAGTO_MEDICO.CAD_TAP_TP_ATRIBUTO%TYPE DEFAULT NULL,
    pREP_PGM_TP_CREDENCIA_PROF            IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_TP_CREDENCIA_PROF%TYPE DEFAULT NULL,
    pSEMCONSULTA                          IN STRING DEFAULT NULL,
    pSEMVALORPAGO                         IN STRING DEFAULT NULL,
    pSEMCRM                               IN STRING DEFAULT NULL,
    pTIS_CBO_CD_CBOS                      IN STRING DEFAULT NULL,
    IO_CURSOR                             OUT PKG_CURSOR.T_CURSOR
)
IS
/********************************************************************
*
*    PROCEDURE: PRC_REP_REL_RESUMO_PROCED
*    DATA CRIA??O:   18/01/2012   POR: DAVI S. M. DOS REIS
*    DATA ALTERA??O: 12/04/2013   POR: FABIOLA LOPES
*
*********************************************************************/
V_CURSOR PKG_CURSOR.T_CURSOR;
V_REP_PGM_TP_CREDENCIA_PROF VARCHAR2(100);
V_SELECT VARCHAR2(30000);
V_JOIN VARCHAR2(15000);
V_WHERE VARCHAR2(15000);
V_GROUP VARCHAR2(15000);
V_ORDER VARCHAR2(15000);
V_SELECT_COMPL VARCHAR2(15000);
V_JOIN_COMPL VARCHAR2(15000);
V_GROUP_COMPL VARCHAR2(15000);
BEGIN
  IF (PREP_PGM_TP_CREDENCIA_PROF IS NULL) THEN
    V_REP_PGM_TP_CREDENCIA_PROF := 'NULL';
  ELSE
    V_REP_PGM_TP_CREDENCIA_PROF := CHR(39) || PREP_PGM_TP_CREDENCIA_PROF || CHR(39);
  END IF;
  V_WHERE := '
               WHERE PGM.REP_PGM_FL_STATUS <> ''I'' ';
  V_WHERE := V_WHERE || ' AND ((PGM.REP_PGM_MES_PAGTO + PGM.REP_PGM_ANO_PAGTO * 100) >= ('|| TO_CHAR(pREP_PGM_MES_PAGTO_INI + pREP_PGM_ANO_PAGTO_INI * 100) || '))';
  IF pREP_PGM_MES_PAGTO_FIM IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND ((PGM.REP_PGM_MES_PAGTO + PGM.REP_PGM_ANO_PAGTO * 100) <= ('|| TO_CHAR(pREP_PGM_MES_PAGTO_FIM + pREP_PGM_ANO_PAGTO_FIM * 100) || '))';
  ELSE
    V_WHERE := V_WHERE || ' AND ((PGM.REP_PGM_MES_PAGTO + PGM.REP_PGM_ANO_PAGTO * 100) <= ('|| TO_CHAR(pREP_PGM_MES_PAGTO_INI + pREP_PGM_ANO_PAGTO_INI * 100) || '))';
  END IF;
  IF pCAD_CLC_ID IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_CLC_ID = ' || pCAD_CLC_ID;
  END IF;
  IF pCAD_UNI_ID_UNIDADE IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_UNI_ID_UNIDADE IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || pCAD_UNI_ID_UNIDADE || ''' ))) ';
  END IF;
  IF pCAD_PRO_ID_PROFISSIONAL IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_PRO_ID_PROFISSIONAL IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || pCAD_PRO_ID_PROFISSIONAL || ''' ))) ';
  END IF;
  IF PTIS_CBO_CD_CBOS IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.TIS_CBO_CD_CBOS IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || PTIS_CBO_CD_CBOS || ''' ))) ';
  END IF;
  IF pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || pCAD_LAT_ID_LOCAL_ATENDIMENTO || ''' ))) ';
  END IF;
  IF pCAD_TPE_CD_CODIGO IS NOT NULL THEN
     V_WHERE:= V_WHERE || ' AND PGM.CAD_TPE_CD_CODIGO IN ( SELECT * FROM TABLE(FNC_SPLIT(''' || pCAD_TPE_CD_CODIGO || ''' ))) ';
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
  IF pCAD_TAP_TP_ATRIBUTO IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.CAD_TAP_TP_ATRIBUTO IN (' || pCAD_TAP_TP_ATRIBUTO || ')';
  END IF;
  IF pREP_PGM_TP_CREDENCIA_PROF IS NOT NULL THEN
    V_WHERE := V_WHERE || ' AND PGM.REP_PGM_TP_CREDENCIA_PROF = ' || CHR(39) || pREP_PGM_TP_CREDENCIA_PROF || CHR(39);
  END IF;
  IF pSEMCONSULTA IS NOT NULL AND pSEMCONSULTA = 'S' THEN
     V_WHERE := V_WHERE || ' AND PGM.AUX_EPP_CD_ESPECPROC != 101 ';
  END IF;
  IF pSEMVALORPAGO = 'S' THEN
     V_WHERE := V_WHERE || ' AND (PGM.REP_PGM_VL_PAGO > 0 AND PGM.REP_PGM_VL_PAGO IS NOT NULL) ';
  END IF;
  IF pSEMCRM = 'N' THEN
    V_SELECT_COMPL := ' , PRO.CAD_PRO_NR_CONSELHO, PRO.CAD_PRO_NM_NOME ';
    V_JOIN_COMPL := ' INNER JOIN TB_CAD_PRO_PROFISSIONAL PRO
                         ON PRO.CAD_PRO_ID_PROFISSIONAL = PGM.CAD_PRO_ID_PROFISSIONAL
                       LEFT JOIN TB_TIS_CBO_CBOS CBO
                         ON PGM.TIS_CBO_CD_CBOS = CBO.TIS_CBO_CD_CBOS ' ;
    V_GROUP_COMPL := ' , PRO.CAD_PRO_NR_CONSELHO, PRO.CAD_PRO_NM_NOME ';
  END IF;
  V_SELECT := ' SELECT   FNC_REP_REL_SUB_VLHR_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
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
                         PGM.CAD_CLC_ID,
                         PGM.REP_PGM_TP_CREDENCIA_PROF,
                         CLC.CAD_CLC_CD_CLINICA,
                         CLC.CAD_CLC_DS_DESCRICAO,
                         PRD.CAD_PRD_CD_CODIGO,
                         PRD.CAD_PRD_DS_DESCRICAO,
                         LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
                         PGM.CAD_PLA_CD_TIPOPLANO,
                         UNI.CAD_UNI_CD_UNID_HOSPITALAR,
                         UNI.CAD_UNI_DS_UNIDADE,
                         SUM(PGM.REP_PGM_QT_CONSUMO) QTDE,
                         SUM(PGM.REP_PGM_VL_FATURADO) VL_FATURADO,
                         SUM(PGM.REP_PGM_VL_CALCULADO) VL_CALCULADO,
                         SUM(PGM.REP_PGM_VL_PAGO) VL_PAGO ';
V_JOIN := '
        FROM TB_REP_PGM_PAGTO_MEDICO PGM
       INNER JOIN TB_CAD_UNI_UNIDADE UNI
          ON UNI.CAD_UNI_ID_UNIDADE = PGM.CAD_UNI_ID_UNIDADE
       INNER JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO LAT
          ON LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO
       INNER JOIN TB_CAD_PRD_PRODUTO PRD
          ON PRD.CAD_PRD_ID = PGM.CAD_PRD_ID
       INNER JOIN TB_CAD_CLC_CLINICA_CREDENCIADA CLC
          ON CLC.CAD_CLC_ID = PGM.CAD_CLC_ID ';
V_GROUP := '
         GROUP BY FNC_REP_REL_SUB_VLHR_SANTEC(' || PREP_PGM_MES_PAGTO_INI || ',
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
                                                ' || PREP_PGM_ANO_PAGTO_FIM || '),
           PGM.CAD_CLC_ID,
           PGM.REP_PGM_TP_CREDENCIA_PROF,
           CLC.CAD_CLC_CD_CLINICA,
           CLC.CAD_CLC_DS_DESCRICAO,
           PRD.CAD_PRD_CD_CODIGO,
           PRD.CAD_PRD_DS_DESCRICAO,
           LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
           PGM.CAD_PLA_CD_TIPOPLANO,
           UNI.CAD_UNI_CD_UNID_HOSPITALAR,
           UNI.CAD_UNI_DS_UNIDADE ';
 V_ORDER := ' ORDER BY LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
                       UNI.CAD_UNI_DS_UNIDADE,
                       PGM.CAD_PLA_CD_TIPOPLANO';
  V_SELECT := V_SELECT || V_SELECT_COMPL || V_JOIN || V_JOIN_COMPL || V_WHERE || V_GROUP || V_GROUP_COMPL || V_ORDER;
  DBMS_OUTPUT.PUT_LINE(V_SELECT);
  OPEN V_CURSOR FOR
    V_SELECT;
  IO_CURSOR := V_CURSOR;
END PRC_REP_REL_RESUMO_PROCED;