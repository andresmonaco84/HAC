create or replace procedure PRC_FAT_REL_OPM_UTILIZ
  (
    pLOTE IN TB_FAT_FCL_CONTR_EMI_LOTE.FAT_FCL_NR_SEQ_LOTE%TYPE DEFAULT NULL,
    pATD_ATE_ID IN TSS_OUTRASDESP_SGS.NR_ATENDIMENTO%TYPE DEFAULT NULL,
     pFAT_CCP_ID IN TSS_OUTRASDESP_SGS.CD_PARCELA%TYPE DEFAULT NULL,
     pCAD_PAC_ID_PACIENTE IN TSS_OUTRASDESP_SGS.IDT_PACIENTE%TYPE DEFAULT NULL,
     pFAT_COC_ID IN TSS_OUTRASDESP_SGS.NR_CONTA%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_FAT_REL_OPM_UTILIZ
  *
  *    Data Criacao: 17/05/2010  Por: Pedro
  *    Alteração:
  *
  *    Atendimento Amb. e Internação Externo( não interna, utiliza sala de cirurg.)
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR

select  S.NR_ATENDIMENTO,
        S.CD_PARCELA,
        S.IDT_PACIENTE,
        S.NR_CONTA,

      S.VL_TOTAL_OPM NAOUSADO,   

      nvl(O.NR_SEQ,1) SEQUENCIALOPM,
      O.CD_TABELA_OPM TABELAOPM,
      O.CD_OPM CODIGOOPM,
      O.DS_OPM DESCRICAOOPM,
      REPLACE(TO_CHAR(O.QT_OPM),'.', ',') QTDOPM,
      O.VL_UNIT_OPM VALORUNITOPM,
      O.VL_TOTAL_OPM VALORTOTALOPM,
      O.CD_BARRAS_OPM CODIGOBARRASOPM
    from TSS_SPSADT_SGS S,         
         TSS_SPSADT_OPM_UTIL_SGS O,
         TB_FAT_FCL_CONTR_EMI_LOTE FCL
    where 
        S.NR_CONTA         = O.NR_CONTA 
    and S.CD_PARCELA       = O.CD_PARCELA
    AND S.IDT_PACIENTE     = O.IDT_PACIENTE
    and S.NR_ATENDIMENTO   = O.NR_ATENDIMENTO
    and S.CD_REGISTRO_ANS  = O.CD_REGISTRO_ANS        
    
  AND  FCL.FAT_COC_ID          = S.NR_CONTA
  AND  FCL.FAT_CCP_ID          = S.CD_PARCELA
  AND  FCL.ATD_ATE_ID          = S.NR_ATENDIMENTO
  AND  FCL.CAD_PAC_ID_PACIENTE = S.IDT_PACIENTE
 
  and (pLOTE is null or FCL.FAT_FCL_NR_SEQ_LOTE  = pLOTE)
  AND (pATD_ATE_ID IS NULL OR FCL.ATD_ATE_ID = pATD_ATE_ID)
  AND (pFAT_CCP_ID IS NULL OR FCL.FAT_CCP_ID = pFAT_CCP_ID)
  AND (pCAD_PAC_ID_PACIENTE IS NULL OR FCL.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE)
  AND (pFAT_COC_ID IS NULL OR FCL.FAT_COC_ID = pFAT_COC_ID)
   
  ;
             io_cursor := v_cursor;
  end PRC_FAT_REL_OPM_UTILIZ;
/
