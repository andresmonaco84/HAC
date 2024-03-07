CREATE OR REPLACE FUNCTION FNC_REP_REL_SUB_VLACRESCIMO
  (
     pREP_PGM_MES_PAGTO_INI IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE,
     pREP_PGM_ANO_PAGTO_INI IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE,
     pCAD_CLC_ID IN TB_CAD_CLC_CLINICA_CREDENCIADA.CAD_CLC_ID%TYPE,
     pREP_PGM_TP_CREDENCIA_PROF IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_TP_CREDENCIA_PROF%TYPE DEFAULT NULL
  )
return number is
  VLACRESCIMO number(12, 2);
/********************************************************************
*    Procedure: FNC_REP_REL_SUB_VLACRESCIMO
*
*    Data Criacao:    06/08/2012           Por: Davi S. M. dos Reis
*    Data Alteracao:  data da altera??o  Por: Nome do Analista
*
*    Funcao: Descri??o da funcionalidade da Function
*
*    OBS.: Esses valores dever?o compor o total geral da cl?nica.
*          Os valores de acr?scimo e desconto est?o na tabela: tb_rep_rpa_resumo_pagto
*          Os valores s?o: rep_rpa_vl_acrescimo e rep_rpa_vl_desconto.
*          Considerar: REP_RPA_TP_CREDENCIA_PROF, REP_RPA_MES_PAGTO, REP_RPA_ANO_PAGTO, rep_rpa_fl_status e justificativa;
*          Os valores de Horas e horas extras est?o na tabela: tb_rep_ppc_pag_prof_cli
*          Os valores s?o: rep_ppc_vl_he_pago_hac, rep_ppc_vl_pago_hac, rep_ppc_vl_he_pago_acs, pgprof.rep_ppc_vl_pago_acs
*          Considerar: rep_ppc_mes_pagto, rep_ppc_ano_pagto, rep_ppc_fl_pagto, separar as informa??es HE e horas trabalhadas;
*
*******************************************************************/

BEGIN

  BEGIN

    SELECT NVL(SUM(REP_RPA_VL_ACRESCIMO), 0)
      INTO VLACRESCIMO
      FROM TB_REP_RPA_RESUMO_PAGTO RPA 
     WHERE RPA.REP_RPA_FL_STATUS = 'A'
       AND RPA.REP_RPA_MES_PAGTO = pREP_PGM_MES_PAGTO_INI
       AND RPA.REP_RPA_ANO_PAGTO = pREP_PGM_ANO_PAGTO_INI
       AND RPA.CAD_CLC_ID = pCAD_CLC_ID 
       AND (pREP_PGM_TP_CREDENCIA_PROF IS NULL OR RPA.REP_RPA_TP_CREDENCIA_PROF = pREP_PGM_TP_CREDENCIA_PROF)

     GROUP BY RPA.CAD_CLC_ID;

    EXCEPTION
       WHEN no_data_found THEN
         VLACRESCIMO := 0;
     END;

   RETURN (VLACRESCIMO);

end FNC_REP_REL_SUB_VLACRESCIMO;