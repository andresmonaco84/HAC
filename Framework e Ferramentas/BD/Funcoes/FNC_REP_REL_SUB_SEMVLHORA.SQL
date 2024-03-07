CREATE OR REPLACE FUNCTION "FNC_REP_REL_SUB_SEMVLHORA"
  (
     pREP_PGM_MES_PAGTO_INI IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE,
     pREP_PGM_ANO_PAGTO_INI IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE,
     pCAD_CLC_ID IN TB_CAD_CLC_CLINICA_CREDENCIADA.CAD_CLC_ID%TYPE,
     pREP_PGM_TP_CREDENCIA_PROF IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_TP_CREDENCIA_PROF%TYPE DEFAULT NULL
  )
return number is
  SEMVLHORA number(12, 2);
/********************************************************************
*    Procedure: FNC_REP_REL_SUB_SEMVLHORA
*
*    Data Criacao:    06/08/2012           Por: Davi S. M. dos Reis
*    Data Alteracao:  data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Function
*
*
*******************************************************************/

BEGIN

  BEGIN
    SELECT NVL(DECODE(pREP_PGM_TP_CREDENCIA_PROF,
                      'MF', SUM(PPC.REP_PPC_VL_PAGO_HAC),
                      'MC', SUM(PPC.REP_PPC_VL_PAGO_ACS),
                      SUM(PPC.REP_PPC_VL_PAGO_HAC + PPC.REP_PPC_VL_PAGO_ACS)), 0)
      INTO SEMVLHORA
      FROM TB_REP_PPC_PAG_PROF_CLI PPC
     INNER JOIN TB_CAD_REP_BCP_BASE_CALCULO BCP
        ON BCP.CAD_REP_TP_BASE_CALCULO = PPC.CAD_REP_TP_BASE_CALCULO
     WHERE BCP.REP_BCP_DS_CAMPO = 'TIPO PAGAMENTO'
       AND PPC.REP_PPC_FL_PAGTO IN ('P', 'F')
       AND PPC.REP_PPC_MES_PAGTO = pREP_PGM_MES_PAGTO_INI
       AND PPC.REP_PPC_ANO_PAGTO = pREP_PGM_ANO_PAGTO_INI
       AND PPC.CAD_CLC_ID = pCAD_CLC_ID
       AND BCP.CAD_REP_TP_BASE_CALCULO != 'VLHORA'
     GROUP BY PPC.CAD_CLC_ID;

     EXCEPTION
       WHEN no_data_found THEN
         SEMVLHORA := 0;
     END;

   RETURN (SEMVLHORA);

end FNC_REP_REL_SUB_SEMVLHORA;
/
