create or replace procedure PRC_FAT_REL_GUIA_DESP
  (
    pLOTE IN TB_FAT_FCL_CONTR_EMI_LOTE.FAT_FCL_NR_SEQ_LOTE%TYPE DEFAULT NULL,
    pATD_ATE_ID IN TSS_OUTRASDESP.NR_ATENDIMENTO%TYPE DEFAULT NULL,
    pFAT_CCP_ID IN TSS_OUTRASDESP.CD_PARCELA%TYPE DEFAULT NULL,
    pCAD_PAC_ID_PACIENTE IN TSS_OUTRASDESP.IDT_PACIENTE%TYPE DEFAULT NULL,
    pFAT_COC_ID IN TSS_OUTRASDESP.NR_CONTA%TYPE DEFAULT NULL,
    io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_FAT_REL_GUIA_DESP
  *
  *    Data Criacao: 18/05/2010  Por: Pedro
  *    Alteração:
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR

select   
  S.CD_CONVENIO,
  S.DS_CONVENIO,
  S.NR_ATENDIMENTO,
  S.CD_PARCELA,
  S.IDT_PACIENTE,
  S.NR_CONTA,
  S.CD_REGISTRO_ANS registroans,
  S.NR_GUIA_REF guiareferenciada,
  S.CD_OPER_CNPJ_CPF_CONT codigooperadora,
  S.NM_CONT nomecontratado,
  S.CD_CNES_CONT codigocnes,
  P.CD_TABELAS tabela,
  P.CD_PROC_REAL codigodoitem,
  P.DS_DESPESA descricao,
  REPLACE(TO_CHAR(SUM( P.QT_PROC_REAL)),'.', ',')qtde,
  DECODE( CD_TP_DESPESA, 2, null, 3, null, P.DT_REAL) Data,
  DECODE(P.HR_INI_PROC,NULL,'', SUBSTR(LPAD(TO_CHAR(P.HR_INI_PROC),4,'0'),1,2) || ':' || SUBSTR(LPAD(TO_CHAR(P.HR_INI_PROC),4,'0'),3,2)) horaINIcial,
  DECODE(P.HR_FIM_PROC,NULL,'', SUBSTR(LPAD(TO_CHAR(P.HR_FIM_PROC),4,'0'),1,2) || ':' || SUBSTR(LPAD(TO_CHAR(P.HR_FIM_PROC),4,'0'),3,2)) horaFInal,
  P.NR_RED_ACR  percentualredacre,
  P.VL_UNIT_PROC valorunitario,
  SUM(P.VL_TOTAL_PROC) valortotal,
  P.CD_TP_DESPESA codigodespesarealizada,
  decode( p.cd_tp_despesa, 2, P.DS_DESPESA, 3, DS_DESPESA, P.CD_PROC_REAL) ordem,
  s.vl_total_gases totalgasesmedicinais,
  s.vl_total_med  totalmedicamento,
  s.vl_total_mat totalmateriais,
  s.vl_total_tx totaltaxasdiversas,
  s.vl_total_di totaldiarias,
  s.vl_total_alugueis totalalugueis,
  s.vl_total_geral totalgeral

from TSS_OUTRASDESP S, TSS_OUTRASDESP_PROC P, TB_FAT_FCL_CONTR_EMI_LOTE FCL
where -
-- S.CD_PARCELA = 'N' --- PARAMETROPARCELA
    S.CD_PARCELA               = P.CD_PARCELA
and S.NR_ATENDIMENTO           = P.NR_ATENDIMENTO
AND S.NR_CONTA                 = P.NR_CONTA
AND S.IDT_PACIENTE             = P.IDT_PACIENTE
and S.CD_REGISTRO_ANS          = P.CD_REGISTRO_ANS
and S.NR_GUIA_REF              = P.NR_GUIA_REF

AND FCL.FAT_COC_ID            = S.NR_CONTA
AND FCL.FAT_CCP_ID            = S.CD_PARCELA
AND FCL.ATD_ATE_ID            = S.NR_ATENDIMENTO
AND FCL.CAD_PAC_ID_PACIENTE   = S.IDT_PACIENTE

and (FCL.FAT_FCL_NR_SEQ_LOTE  = pLOTE)
AND (pATD_ATE_ID IS NULL OR FCL.ATD_ATE_ID = pATD_ATE_ID)
AND (pFAT_CCP_ID IS NULL OR FCL.FAT_CCP_ID = pFAT_CCP_ID)
AND (pCAD_PAC_ID_PACIENTE IS NULL OR FCL.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE)
AND (pFAT_COC_ID IS NULL OR FCL.FAT_COC_ID = pFAT_COC_ID)

GROUP BY S.CD_CONVENIO,
      S.DS_CONVENIO,
       S.NR_ATENDIMENTO,
          S.CD_PARCELA,
          S.IDT_PACIENTE,
          S.NR_CONTA,
          S.CD_REGISTRO_ANS,
         S.NR_GUIA_REF,
         S.CD_OPER_CNPJ_CPF_CONT,
         S.NM_CONT,
         S.CD_CNES_CONT,
         P.CD_TABELAS,
         P.CD_PROC_REAL,
         P.DS_DESPESA,
         DECODE( CD_TP_DESPESA, 2, null, 3, null, P.DT_REAL),
         P.HR_INI_PROC,  P.HR_FIM_PROC, P.NR_RED_ACR, P.CD_TP_DESPESA,
         P.VL_UNIT_PROC,
         s.vl_total_gases,
         s.vl_total_med  ,
         s.vl_total_mat ,
         s.vl_total_tx ,
         s.vl_total_di ,
         s.vl_total_alugueis ,
         s.vl_total_geral
order by P.CD_TP_DESPESA, data, horaINIcial, horafinal, ORDEM
  ;
             io_cursor := v_cursor;
  end PRC_FAT_REL_GUIA_DESP;
/
