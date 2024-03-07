CREATE OR REPLACE PROCEDURE PRC_REP_REL_SUB_ACRESC_DESC
  (
     pREP_PGM_MES_PAGTO_INI IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_MES_PAGTO%TYPE,
     pREP_PGM_ANO_PAGTO_INI IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ANO_PAGTO%TYPE,
     pCAD_CLC_ID IN TB_CAD_CLC_CLINICA_CREDENCIADA.CAD_CLC_ID%TYPE DEFAULT NULL,
     pREP_PGM_TP_CREDENCIA_PROF IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_TP_CREDENCIA_PROF%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
/********************************************************************
*    Procedure: PRC_REP_REL_SUB_ACRESC_DESC
*
*    Data Criacao:    06/08/2012           Por: Davi S. M. dos Reis
*    Data Alteracao:  data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
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
v_cursor PKG_CURSOR.t_cursor;

BEGIN
  
  OPEN v_cursor FOR

    SELECT NVL(DECODE(pREP_PGM_TP_CREDENCIA_PROF, 
                      'MF', SUM(PPC.REP_PPC_VL_PAGO_HAC), 
                      'MC', SUM(PPC.REP_PPC_VL_PAGO_ACS),
                      SUM(PPC.REP_PPC_VL_PAGO_HAC + PPC.REP_PPC_VL_PAGO_ACS)), 0) VLHORA, 
           NVL(DECODE(pREP_PGM_TP_CREDENCIA_PROF,
                      'MF', SUM(PPC.REP_PPC_VL_HE_PAGO_HAC), 
                      'MC', SUM(PPC.REP_PPC_VL_HE_PAGO_ACS),
                      SUM(PPC.REP_PPC_VL_HE_PAGO_HAC + PPC.REP_PPC_VL_HE_PAGO_ACS)), 0) VLHORAEXTRA,
           0 VLACRESCIMO,
           0 VLDESCONTO,
           PPC.CAD_CLC_ID, 
           UPPER(BCP.REP_BCP_DS_BASE_CALCULO) BASECALCULO, 
           '' JUSTIFICATIVA,
           'BASECALCULO' TIPOACRESC
      FROM TB_REP_PPC_PAG_PROF_CLI PPC
     INNER JOIN TB_CAD_REP_BCP_BASE_CALCULO BCP
        ON BCP.CAD_REP_TP_BASE_CALCULO = PPC.CAD_REP_TP_BASE_CALCULO
     WHERE BCP.REP_BCP_DS_CAMPO = 'TIPO PAGAMENTO'
       AND PPC.REP_PPC_FL_PAGTO IN ('P', 'F')
       AND PPC.REP_PPC_MES_PAGTO = pREP_PGM_MES_PAGTO_INI
       AND PPC.REP_PPC_ANO_PAGTO = pREP_PGM_ANO_PAGTO_INI
       AND (pCAD_CLC_ID IS NULL OR PPC.CAD_CLC_ID = pCAD_CLC_ID)
     GROUP BY PPC.CAD_CLC_ID, BCP.REP_BCP_DS_BASE_CALCULO 
    UNION
    SELECT 0 VLHORA,
           0 VLHORAEXTRA,
           NVL(SUM(REP_RPA_VL_ACRESCIMO), 0) VLACRESCIMO, 
           NVL(SUM(REP_RPA_VL_DESCONTO), 0) VLDESCONTO, 
           RPA.CAD_CLC_ID, 
           '' BASECALCULO,
           UPPER(JPG.CAD_JPG_DS_JUSTIFICATIVA) JUSTIFICATIVA, 
           'JUSTIFICATIVA' TIPOACRESC
      FROM TB_REP_RPA_RESUMO_PAGTO RPA
     INNER JOIN TB_CAD_JPG_JUSTIFICA_PAGTO JPG
        ON JPG.ID_CAD_JPG = RPA.ID_CAD_JPG
     WHERE RPA.REP_RPA_FL_STATUS = 'A'
       AND RPA.REP_RPA_MES_PAGTO = pREP_PGM_MES_PAGTO_INI
       AND RPA.REP_RPA_ANO_PAGTO = pREP_PGM_ANO_PAGTO_INI
       AND (pCAD_CLC_ID IS NULL OR RPA.CAD_CLC_ID = pCAD_CLC_ID)
       AND (pREP_PGM_TP_CREDENCIA_PROF IS NULL OR RPA.REP_RPA_TP_CREDENCIA_PROF = pREP_PGM_TP_CREDENCIA_PROF)
     GROUP BY CAD_CLC_ID, JPG.CAD_JPG_DS_JUSTIFICATIVA;

--  DBMS_OUTPUT.PUT_LINE(V_SELECT);

  io_cursor := v_cursor;

end PRC_REP_REL_SUB_ACRESC_DESC;
