create or replace procedure PRC_FAT_REL_SUB_PER_INT
  (
     pLOTE IN TB_FAT_FCL_CONTR_EMI_LOTE.FAT_FCL_NR_SEQ_LOTE%TYPE DEFAULT NULL,
     pATD_ATE_ID IN TSS_OUTRASDESP_SGS.NR_ATENDIMENTO%TYPE DEFAULT NULL,
     pFAT_CCP_ID IN TSS_OUTRASDESP_SGS.CD_PARCELA%TYPE DEFAULT NULL,
     pCAD_PAC_ID_PACIENTE IN TSS_OUTRASDESP_SGS.IDT_PACIENTE%TYPE DEFAULT NULL,
     pFAT_COC_ID IN TSS_OUTRASDESP_SGS.NR_CONTA%TYPE DEFAULT NULL,    
     pPRIMEIROS int default null,
     pMAIOR_QUE int default null,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_FAT_REL_SUB_PER_INT
  *
  *    Data Criacao: 17/05/2010  Por: Pedro
  *    Alteração:
  *    Data Criacao: 10/01/2011  Por: André
  *    Alteração: Mudança dos parametros pPRIMEIROS_10 e pMAIOR_QUE_10 para
  *               pPRIMEIROS e pMAIOR_QUE e de varchar para int (pois será a qtd vinda
  *               via param. a ser utilizada) "comentado provisoriamente"
  *
  *    Atendimento Amb. e Internação Externo( não interna, utiliza sala de cirurg.)
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR

select
      S.NR_ATENDIMENTO,
      S.CD_PARCELA,
      S.IDT_PACIENTE,
      S.NR_CONTA,
      S.CD_REGISTRO_ANS ,
      S.NR_GUIA,

      P.NR_SEQ SEQUENCIAPROCEDIMENTO,
      P.DT_PROC_REAL DATA,
      DECODE(P.HR_INI_PROC,NULL,'', SUBSTR(LPAD(TO_CHAR(P.HR_INI_PROC),4,'0'),1,2) || ':' || SUBSTR(LPAD(TO_CHAR(P.HR_INI_PROC),4,'0'),3,2)) HORAINICIAL,
      DECODE(P.HR_FIM_PROC,NULL,'', SUBSTR(LPAD(TO_CHAR(P.HR_FIM_PROC),4,'0'),1,2) || ':' || SUBSTR(LPAD(TO_CHAR(P.HR_FIM_PROC),4,'0'),3,2)) HORAFINAL,
      P.CD_TABELAS TABELA,
      P.CD_PROC_REAL CODIGOPROCEDIMENTO,
      P.DS_PROC_REAL DESCRICAO,
      REPLACE(TO_CHAR(P.QT_PROC_REAL),'.', ',') QUANTIDADE,
      P.CD_VIA_ACESSO VIA ,
      P.CD_TECNICA_UTILIZADA TECNICA,
      P.NR_RED_ACR PERCENTUALREDUCAOACRESCIMO,
      P.VL_UNIT_PROC VALORUNITARIO,
      P.VL_TOTAL_PROC VALORTOTAL

    from     TSS_RESUMO_INT_SGS S,
             TSS_RESUMO_INT_PROC_SGS P,
             TB_FAT_FCL_CONTR_EMI_LOTE FCL

    where
         S.NR_ATENDIMENTO              = P.NR_ATENDIMENTO
    and  S.CD_PARCELA                  = P.CD_PARCELA
    and  S.CD_REGISTRO_ANS             = P.CD_REGISTRO_ANS
    and  S.NR_GUIA                     = P.NR_GUIA
    AND  S.IDT_PACIENTE                = P.IDT_PACIENTE
    AND  S.NR_CONTA                    = P.NR_CONTA

    AND  FCL.FAT_COC_ID                = S.NR_CONTA
    AND  FCL.FAT_CCP_ID                = S.CD_PARCELA
    AND  FCL.ATD_ATE_ID                = S.NR_ATENDIMENTO
    AND  FCL.CAD_PAC_ID_PACIENTE       = S.IDT_PACIENTE

    and (pLOTE is null or FCL.FAT_FCL_NR_SEQ_LOTE = pLOTE)
    AND (pATD_ATE_ID IS NULL OR FCL.ATD_ATE_ID = pATD_ATE_ID)
    AND (pFAT_CCP_ID IS NULL OR FCL.FAT_CCP_ID = pFAT_CCP_ID)
    AND (pCAD_PAC_ID_PACIENTE IS NULL OR FCL.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE)
    AND (pFAT_COC_ID IS NULL OR FCL.FAT_COC_ID = pFAT_COC_ID)
    
    AND (pPRIMEIROS IS NULL OR P.NR_SEQ <= pPRIMEIROS)
    AND (pMAIOR_QUE IS NULL OR P.NR_SEQ > pMAIOR_QUE)

    order by P.NR_SEQ, P.CD_PROC_REAL

  ;
    io_cursor := v_cursor;
  end PRC_FAT_REL_SUB_PER_INT;
/
