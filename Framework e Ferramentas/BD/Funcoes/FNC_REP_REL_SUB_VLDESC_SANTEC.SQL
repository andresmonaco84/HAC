CREATE OR REPLACE FUNCTION "FNC_REP_REL_SUB_VLDESC_SANTEC"(pREP_PGM_MES_PAGTO_INI     IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE,
                                                           pREP_PGM_ANO_PAGTO_INI     IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE,
                                                           pCAD_CLC_ID                IN TB_CAD_CLC_CLINICA_CREDENCIADA.CAD_CLC_ID%TYPE,
                                                           pREP_PGM_TP_CREDENCIA_PROF IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_TP_CREDENCIA_PROF%TYPE DEFAULT NULL,
                                                           pREP_PGM_MES_PAGTO_FIM     IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE,
                                                           pREP_PGM_ANO_PAGTO_FIM     IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE)
  return number is
  VLDESCONTO number(12, 2);
  /********************************************************************
  *    Procedure: FNC_REP_REL_SUB_VLDESC_SANTEC
  *
  *    Data Criacao:    12/08/2014         Por: Fabï¿½ola R. Lopes
  *    Data Alteracao:  data da altera??o  Por: Nome do Analista
  *
  *    Funcao: Descricao da funcionalidade da Function
  *
  *******************************************************************/
BEGIN
  BEGIN
    SELECT NVL(SUM(REP_RPA_VL_DESCONTO), 0)
      INTO VLDESCONTO
      FROM TB_REP_RPA_RESUMO_PAGTO RPA
     WHERE RPA.REP_RPA_FL_STATUS = 'A'
       AND TO_DATE('01'||'/'||RPA.REP_RPA_MES_PAGTO||'/'||RPA.REP_RPA_ANO_PAGTO,'DD/MM/YYYY') >= TO_DATE('01'||'/'||LPAD(pREP_PGM_MES_PAGTO_INI,2,'0')||'/'||pREP_PGM_ANO_PAGTO_INI, 'DD/MM/YYYY')
       AND TO_DATE('01'||'/'||RPA.REP_RPA_MES_PAGTO||'/'||RPA.REP_RPA_ANO_PAGTO,'DD/MM/YYYY') <= TO_DATE(LPAD(LAST_DAY(TO_DATE('01'||LPAD(pREP_PGM_MES_PAGTO_FIM,2,'0')||pREP_PGM_ANO_PAGTO_FIM, 'DDMMYYYY')),2,0)||'/'||LPAD(pREP_PGM_MES_PAGTO_FIM,2,'0')||'/'||pREP_PGM_ANO_PAGTO_FIM, 'DD/MM/YYYY')          
       AND RPA.CAD_CLC_ID = pCAD_CLC_ID
       AND (pREP_PGM_TP_CREDENCIA_PROF IS NULL OR RPA.REP_RPA_TP_CREDENCIA_PROF = pREP_PGM_TP_CREDENCIA_PROF)
       AND (RPA.REP_RPA_FL_ANTECIPACAO = 'N' OR RPA.REP_RPA_FL_ANTECIPACAO IS NULL)
     GROUP BY RPA.CAD_CLC_ID;
  EXCEPTION
    WHEN no_data_found THEN
      VLDESCONTO := 0;
  END;
  RETURN(VLDESCONTO);
END FNC_REP_REL_SUB_VLDESC_SANTEC;