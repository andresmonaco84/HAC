CREATE OR REPLACE PROCEDURE "PRC_FAT_REL_RESUM_GUIA_INT" (
    pLOTE IN TB_FAT_FCL_CONTR_EMI_LOTE.FAT_FCL_NR_SEQ_LOTE%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_FAT_REL_RESUM_GUIA_INT
  *
  *    Data Alteracao: 08/02/2010  Por: Pedro  
  *    Alteração:
  *    Data Alteracao: 10/01/2011  Por: André S. MonACO
  *    Alteração: Adição dos campos CD_CONVENIO e DS_CONVENIO
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    select   S.NR_CONTA,
             S.CD_PARCELA,
             S.NR_ATENDIMENTO,
             S.IDT_PACIENTE,
             S.CD_REGISTRO_ANS registroans,
             S.NR_GUIA numero,
             S.NR_GUIA_SOLICITACAO nguiasolicitacao,
             S.DT_AUTORIZACAO datadaautorizacao,
             S.CD_SENHA senha,
             S.DT_VAL_SENHA datavalidadesenha,
             S.DT_EMI_GUIA datadeemissaodaguia,
             S.NR_CARTEIRA_BENEF numerodacarteira,
             S.NM_PLANO_BENEF plano,
             S.DT_VAL_CARTEIRA_BENEF validadecarteira,
             S.NM_BENEF nome,
             S.NR_CNS_BENEF cartanacionalsaude,
             S.CD_OPER_CNPJ_CPF_SOL codigooepradora,
             S.NM_CONT_EXEC nomecontratado,
             S.CD_CNES_EXEC codigocnes,
             S.TP_LOGRA_CONT TL,
             S.NM_LOGRA_CONT LOGRADOURO,
             S.NR_LOGRA_CONT NUMEROLOGRADOURO,
             S.DS_COMPL_LOGRA_CONT COMPLEMENTOLOGRADOURO,
             S.NM_MUNIC_CONT MUNICIPIO,
             S.CD_UF_CONT UFLOGRADOURO,
             S.CD_IBGE_MUNIC_CONT CODIBGE,
             S.NR_CEP_CONT CEP,
             S.CD_TP_CARAT_ATEND CARATERINTERNACAO,
             S.CD_TP_ACOMODACAO TIPOACOMODACAO,
             S.DT_INI_INT DATAHORAINTERNACAO,
             S.DT_FIM_INT DATAHORASAIDAINTERNACAO,
             S.CD_TP_INTERNACAO TIPOINTERNACAO,
             S.CD_REGIME_INTERNACAO REGIMEINTERNACAO,
             --- INTERNACAO OBSTETRICA
             S.ID_GESTACAO EMGESTACAO,
             S.ID_ABORTO ABORTO,
             S.ID_TRANS_GRAVIDEZ TRANSTORNOMATRELGRAVIDEZ,
             S.ID_COMPL_PUERPERIO COMPLICACAOPUERPERIO,
             S.ID_ATENDIMENTO_RN ATENDAORNSALAPARTO,
             S.ID_COMP_NEONATAL COMPLICACAONEONATAL,
             S.ID_BAIXO_PESO BXPESO,
             S.ID_PARTO_CESAREO PARTOCESARIO,
             S.ID_PARTO_NORMAL PARTONORMAL,
             S.CD_OBITO_MULHER OBITOEMMULHER,
             S.QT_OBITOS_PRECOCES QTDOBITOPRECOCE,
             S.QT_OBITOS_TARDIOS QTDOBITOTARDIO,
             S.CD_DECLARACAO_NASC_VIVOS NDECLNASCVIVOS,
             S.QT_NASC_VIVOS QTDNASCVIVOSTERMO,
             S.QT_NASC_MORTOS QTDNASCMORTOS,
             S.QT_NASC_PREMATUROS QTDNASCVIVOSPREMATURO,
             S.CD_CID10_PRINC CID10PRINCIPAL,
             S.CD_CID10_2 CID10_2,
             S.CD_CID10_3 CID10_3,
             S.CD_CID10_4 CID10_4,
             S.CD_ID_ACIDENTE INDICACAODEACIDENTE,
             S.CD_MOT_SAI_INT MOTIVOSAIDA,
             S.CD_CID10_OBITO CID10_OBITO,
             S.CD_DECLARACAO_OBITO NDECLARACAOOBITO,
             S.CD_TP_FATURAMENTO TIPOFATURAMENTO,
             S.DS_OBSERVACAO OBSERVACAO,
             S.VL_TOTAL_PROC TOTALPROCEDIMENTO,
             S.VL_TOTAL_TX_ALUGUEIS TOTALTAXASALUGUEIS,
             S.VL_TOTAL_MAT TOTALMATERIAIS,
             S.VL_TOTAL_MED TOTALMEDICAMENTOS,
             S.VL_TOTAL_DI TOTALDIARIAS,
             S.VL_TOTAL_GASES TOTALGASES,
             S.VL_TOTAL_GERAL TOTALGERAL,
             S.VL_TOTAL_OPM TOTALGERALOPM,
             S.CD_CONVENIO,
             S.DS_CONVENIO
    from     TSS_RESUMO_INT_SGS S,
             TB_FAT_FCL_CONTR_EMI_LOTE FCL
    where
        FCL.FAT_COC_ID            = S.NR_CONTA
    AND FCL.FAT_CCP_ID            = S.CD_PARCELA
    AND FCL.ATD_ATE_ID            = S.NR_ATENDIMENTO
    AND FCL.CAD_PAC_ID_PACIENTE   = S.IDT_PACIENTE
    AND (FCL.FAT_FCL_NR_SEQ_LOTE = pLOTE)
  ;
             io_cursor := v_cursor;
  end PRC_FAT_REL_RESUM_GUIA_INT;
