CREATE OR REPLACE PROCEDURE "PRC_FAT_REL_SUB_IDENT_EQUIPE" (
    pFAT_CCP_ID IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ID%TYPE DEFAULT NULL,
    pFAT_COC_ID IN TB_FAT_COC_CONTA_CONSUMO.FAT_COC_ID%TYPE DEFAULT NULL,
     pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE DEFAULT NULL,
    pCAD_PAC_ID_PACIENTE IN TB_CAD_PAC_PACIENTE.CAD_PAC_ID_PACIENTE%TYPE DEFAULT NULL,
    pLOTE IN TB_FAT_FCL_CONTR_EMI_LOTE.FAT_FCL_NR_SEQ_LOTE%TYPE DEFAULT NULL,
     pIDENT_EQUIPE_PRIMEIROS int default null,
     pIDENT_EQUIPE_MAIOR_QUE int default null,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_FAT_SUB_IDENT_EQUIPE
  *
  *    Data Alteracao: 08/03/2010  Por: Pedro
  *    Alteração: pIDENT_EQUIPE_PRIMEIROS
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR

SELECT DISTINCT
             S.NR_ATENDIMENTO,
             S.CD_PARCELA,
             S.IDT_PACIENTE,
             S.NR_CONTA,
             S.CD_REGISTRO_ANS ,
             S.NR_GUIA,

             E.NR_SEQ SEQUENCIALEQUIPE,
             E.CD_POS_PROF_EQUIPE GRPARTICIPACAO,
             E.CD_OPER_CNPJ_CPF_EXEC CODIGOOPEREXEC,
             E.NM_PROF_EXEC NOMEEPROFISSIONAL,
             E.SG_CONS_PROF_EXEC CONSELHOPROF,
             E.NR_CONS_PROF_EXEC NUMEROCONSELHO,
             E.SG_UF_PROF_EXEC UFPROFEXEC,
             E.NR_CPF_PROF_EXEC CPF


              from     TSS_RESUMO_INT_SGS S,
                      TSS_RESUMO_INT_EQUIPE_SGS E,
                      TB_FAT_FCL_CONTR_EMI_LOTE FCL

    where

        S.NR_ATENDIMENTO          = E.NR_ATENDIMENTO(+)
    and S.CD_PARCELA              = E.CD_PARCELA(+)
    AND S.Idt_Paciente             = E.Idt_Paciente(+) -- PARAMETRO NOVO  PACIENTE
    AND S.NR_CONTA                = E.NR_CONTA(+)  -- PARAMETRO NOVO CONTA
    and S.CD_REGISTRO_ANS         = E.CD_REGISTRO_ANS(+)
    and S.NR_GUIA                 = E.NR_GUIA(+)

    AND FCL.FAT_COC_ID            = S.NR_CONTA
    AND FCL.FAT_CCP_ID            = S.CD_PARCELA
    AND FCL.ATD_ATE_ID            = S.NR_ATENDIMENTO
    AND FCL.CAD_PAC_ID_PACIENTE   = S.IDT_PACIENTE

    and (pLOTE is null or FCL.FAT_FCL_NR_SEQ_LOTE = pLOTE)
    AND (pATD_ATE_ID IS NULL OR FCL.ATD_ATE_ID = pATD_ATE_ID)
    AND (pFAT_CCP_ID IS NULL OR FCL.FAT_CCP_ID = pFAT_CCP_ID)
    AND (pCAD_PAC_ID_PACIENTE IS NULL OR FCL.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE)
    AND (pFAT_COC_ID IS NULL OR FCL.FAT_COC_ID = pFAT_COC_ID)
     AND (pIDENT_EQUIPE_PRIMEIROS IS NULL OR e.NR_SEQ <= pIDENT_EQUIPE_PRIMEIROS)
    AND (pIDENT_EQUIPE_MAIOR_QUE IS NULL OR e.NR_SEQ > pIDENT_EQUIPE_MAIOR_QUE)
  ;
             io_cursor := v_cursor;
  end PRC_FAT_REL_SUB_IDENT_EQUIPE;
/
