CREATE OR REPLACE PROCEDURE "PRC_REP_CAL_REINICIAR"(PREP_PGM_MES_PAGTO IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE,
                                                    PREP_PGM_ANO_PAGTO IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE,
                                                    PCLINICAS          IN STRING,
                                                    PBASECALCULO       IN STRING) IS
  /********************************************************************
  *    PROCEDURE: PRC_REP_IMP_REPASSE_FATURADO
  *
  *    DATA CRIACAO:   01/05/2012   POR:
  *    DATA ALTERACAO:  DATA DA ALTERAÇÃO  POR: NOME DO ANALISTA
  *
  *    FUNCAO: REINICIAR O PROCESSAMENTO POR BASE DE CALCULO
  *
  *******************************************************************/
  --LIDTRETORNO NUMBER;
  V_WHERE VARCHAR2(5000);
BEGIN
  IF (PCLINICAS IS NOT NULL) THEN
    V_WHERE := 'AND PGM.CAD_CLC_CD_CLINICA IN ( SELECT * FROM TABLE(FNC_SPLIT( ''' ||
               PCLINICAS || ''' )))';
  END IF;

  IF (PBASECALCULO IS NOT NULL) THEN
    V_WHERE := 'AND REP.CAD_REP_TP_BASE_CALCULO IN ( SELECT * FROM TABLE(FNC_SPLIT( ''' ||
               PBASECALCULO || ''' )))';
  END IF;

  BEGIN
    UPDATE (SELECT PGM.*
              FROM TB_REP_PGM_PAGTO_MEDICO PGM
             INNER JOIN TB_ASS_RPG_REGRA_PAGTO RPG
                ON PGM.ASS_RPG_ID = RPG.ASS_RPG_ID
             INNER JOIN TB_CAD_REP_REGRA_PAGAMENTO REP
                ON RPG.CAD_REP_ID = REP.CAD_REP_ID
             WHERE PGM.REP_PGM_FL_PAGO = 'P' 
             AND PGM.ASS_RPG_ID IS NOT NULL
       AND PGM.REP_PGM_MES_PAGTO = PREP_PGM_MES_PAGTO
       AND PGM.REP_PGM_ANO_PAGTO = PREP_PGM_ANO_PAGTO || V_WHERE) PGM
       SET PGM.ASS_RPG_ID             = NULL,
           PGM.REP_PGM_FL_PAGO        = NULL,
           PGM.REP_PGM_MES_PAGTO      = NULL,
           PGM.REP_PGM_ANO_PAGTO      = NULL,
           PGM.REP_PGM_VL_PAGO        = NULL,
           PGM.CAD_REP_VL_PAGTO_EXTRA = NULL;
  
  END;
END PRC_REP_CAL_REINICIAR;
/
