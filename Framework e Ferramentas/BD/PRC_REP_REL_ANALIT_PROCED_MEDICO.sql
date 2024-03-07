CREATE OR REPLACE PROCEDURE "PRC_REP_REL_ANALIT_PROCED_MED" (
    pCAD_CLC_ID            IN TB_CAD_CLC_CLINICA_CREDENCIADA.CAD_CLC_ID%TYPE DEFAULT NULL,
    pREP_PGM_MES_PAGTO_INI IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE DEFAULT NULL,
    pREP_PGM_ANO_PAGTO_INI IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE DEFAULT NULL,
    pREP_PGM_MES_PAGTO_FIM IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE DEFAULT NULL,
    pREP_PGM_ANO_PAGTO_FIM IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE DEFAULT NULL,
    pREP_PGM_TP_CREDENCIA_PROF IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_TP_CREDENCIA_PROF%TYPE DEFAULT NULL,
    pSEMCONSULTA IN String,
    IO_CURSOR                OUT PKG_CURSOR.T_CURSOR
)
IS
/********************************************************************
*
*    PROCEDURE: PRC_REP_REL_ANALIT_PROCED_MED
*    DATA:17/04/2012       POR:Leonardo Espuri
*
*********************************************************************/
V_CURSOR PKG_CURSOR.T_CURSOR;
V_WHERE_CONSULTA  integer;
BEGIN
    IF pSEMCONSULTA = 'S' THEN
      V_WHERE_CONSULTA := 101;
    END IF;

  OPEN V_CURSOR FOR
      SELECT DISTINCT
           CLC.CAD_CLC_DS_DESCRICAO,
           PGM.CAD_CEC_ID_CCUSTO,
           CC.CAD_CEC_DS_CCUSTO,
           UNI.CAD_UNI_DS_UNIDADE,
           LAT.CAD_LAT_CD_LOCAL_ATENDIMENTO,
           PGM.ATD_ATE_ID,
           TPP.CAD_TAP_DS_ATRIBUTO,
           PGM.REP_PGM_DT_INICIO_REALIZACAO,
           PGM.REP_PGM_QT_CONSUMO,
           PGM.REP_PGM_VL_FATURADO,
           PGM.REP_PGM_VL_CALCULADO,
           PGM.REP_PGM_VL_PAGO
      FROM TB_REP_PGM_PAGTO_MEDICO PGM
      INNER JOIN TB_CAD_CLC_CLINICA_CREDENCIADA CLC ON CLC.CAD_CLC_ID = PGM.CAD_CLC_ID
      INNER JOIN TB_CAD_UNI_UNIDADE UNI ON UNI.CAD_UNI_ID_UNIDADE = PGM.CAD_UNI_ID_UNIDADE
      INNER JOIN TB_CAD_CEC_CENTRO_CUSTO CC ON CC.CAD_CEC_ID_CCUSTO = PGM.CAD_CEC_ID_CCUSTO
      INNER JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO LAT ON LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = PGM.CAD_LAT_ID_LOCAL_ATENDIMENTO
      INNER JOIN TB_CAD_PRD_PRODUTO PRD ON PRD.CAD_PRD_ID = PGM.CAD_PRD_ID
      INNER JOIN TB_CAD_CNV_CONVENIO CNV ON CNV.CAD_CNV_ID_CONVENIO = PGM.CAD_CNV_ID_CONVENIO
      INNER JOIN TB_CAD_TAP_TP_ATRIB_PRODUTO TPP ON PRD.CAD_TAP_TP_ATRIBUTO = TPP.CAD_TAP_TP_ATRIBUTO
      WHERE pCAD_CLC_ID = CLC.CAD_CLC_ID
            AND (PGM.REP_PGM_MES_PAGTO IS NULL OR TO_DATE('01-' || TO_CHAR(PGM.REP_PGM_MES_PAGTO) || '-' || TO_CHAR(PGM.REP_PGM_ANO_PAGTO), 'DD-MM-YYYY') >= TO_DATE('01-' || pREP_PGM_MES_PAGTO_INI || '-' || pREP_PGM_ANO_PAGTO_INI, 'DD-MM-YYYY'))
            AND (PGM.REP_PGM_MES_PAGTO IS NULL OR pREP_PGM_MES_PAGTO_FIM IS NULL OR TO_DATE('01-' || TO_CHAR(PGM.REP_PGM_MES_PAGTO) || '-' || TO_CHAR(PGM.REP_PGM_ANO_PAGTO), 'DD-MM-YYYY') < TO_DATE('01-' || pREP_PGM_MES_PAGTO_FIM || '-' || pREP_PGM_ANO_PAGTO_FIM, 'DD-MM-YYYY'))
            AND pREP_PGM_TP_CREDENCIA_PROF IS NULL OR PGM.REP_PGM_TP_CREDENCIA_PROF IN (pREP_PGM_TP_CREDENCIA_PROF)
            AND PGM.AUX_EPP_CD_ESPECPROC NOT IN (V_WHERE_CONSULTA)
            AND TPP.CAD_TAP_TP_ATRIBUTO IN ('EXA','HM','TAX');

  IO_CURSOR := V_CURSOR;
END PRC_REP_REL_ANALIT_PROCED_MED;
 
/
