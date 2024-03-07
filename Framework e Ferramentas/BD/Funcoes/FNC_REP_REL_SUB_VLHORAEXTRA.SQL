CREATE OR REPLACE FUNCTION "FNC_REP_REL_SUB_VLHORAEXTRA"
  (
     pREP_PGM_MES_PAGTO_INI IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE,
     pREP_PGM_ANO_PAGTO_INI IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE,
     pCAD_CLC_ID IN TB_CAD_CLC_CLINICA_CREDENCIADA.CAD_CLC_ID%TYPE,
     pREP_PGM_TP_CREDENCIA_PROF IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_TP_CREDENCIA_PROF%TYPE DEFAULT NULL
  )
return number is
  VLHORAEXTRA number(12, 2);
/********************************************************************
*    Procedure: FNC_REP_REL_SUB_VLHORAEXTRA
*
*    Data Criacao:    06/08/2012           Por: Davi S. M. dos Reis
*    Data Alteracao:  data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Function
*
*    OBS.: Esses valores deverão compor o total geral da clínica.
*          Os valores de acréscimo e desconto estão na tabela: tb_rep_rpa_resumo_pagto
*          Os valores são: rep_rpa_vl_acrescimo e rep_rpa_vl_desconto.
*          Considerar: REP_RPA_TP_CREDENCIA_PROF, REP_RPA_MES_PAGTO, REP_RPA_ANO_PAGTO, rep_rpa_fl_status e justificativa;
*          Os valores de Horas e horas extras estão na tabela: tb_rep_ppc_pag_prof_cli
*          Os valores são: rep_ppc_vl_he_pago_hac, rep_ppc_vl_pago_hac, rep_ppc_vl_he_pago_acs, pgprof.rep_ppc_vl_pago_acs
*          Considerar: rep_ppc_mes_pagto, rep_ppc_ano_pagto, rep_ppc_fl_pagto, separar as informações HE e horas trabalhadas;
*
*******************************************************************/

BEGIN

  BEGIN
    SELECT NVL(DECODE(pREP_PGM_TP_CREDENCIA_PROF,
                      'MF', SUM(PPC.REP_PPC_VL_HE_PAGO_HAC),
                      'MC', SUM(PPC.REP_PPC_VL_HE_PAGO_ACS),
                      SUM(PPC.REP_PPC_VL_HE_PAGO_HAC + PPC.REP_PPC_VL_HE_PAGO_ACS)), 0)
      INTO VLHORAEXTRA
      FROM TB_REP_PPC_PAG_PROF_CLI PPC
     INNER JOIN TB_CAD_REP_BCP_BASE_CALCULO BCP
        ON BCP.CAD_REP_TP_BASE_CALCULO = PPC.CAD_REP_TP_BASE_CALCULO
     WHERE BCP.REP_BCP_DS_CAMPO = 'TIPO PAGAMENTO'
       AND PPC.REP_PPC_FL_PAGTO IN ('P', 'F')
       AND PPC.REP_PPC_MES_PAGTO = pREP_PGM_MES_PAGTO_INI
       AND PPC.REP_PPC_ANO_PAGTO = pREP_PGM_ANO_PAGTO_INI
       AND PPC.CAD_CLC_ID = pCAD_CLC_ID
       AND BCP.CAD_REP_TP_BASE_CALCULO = 'VLHORA'
     GROUP BY PPC.CAD_CLC_ID;

     EXCEPTION
       WHEN no_data_found THEN
         VLHORAEXTRA := 0;
     END;

   RETURN (VLHORAEXTRA);

end FNC_REP_REL_SUB_VLHORAEXTRA;