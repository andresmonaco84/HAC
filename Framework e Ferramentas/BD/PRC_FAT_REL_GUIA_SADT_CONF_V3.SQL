CREATE OR REPLACE PROCEDURE "PRC_FAT_REL_GUIA_SADT_CONF_V3" (
    pLOTE IN TB_FAT_FCL_CONTR_EMI_LOTE.FAT_FCL_NR_SEQ_LOTE%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_FAT_REL_GUIA_SADT_CONF
  *
  *    Data Criacao: 24/05/2014  Por: Pedro
  *    Alterac?o:
  *
  *    Atendimento Amb. e Internac?o Externo( n?o interna, utiliza sala de cirurg.)
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR

SELECT DISTINCT FCL.FAT_FCL_NR_SEQ_LOTE,      FCL.FAT_FCL_NR_SEQ_IMPRIME,
      S.AA_RECEITA,
      S.CD_CONVENIO,
      S.DS_CONVENIO,
      S.NR_ATENDIMENTO,
      S.CD_PARCELA,
      S.IDT_PACIENTE,
      S.NR_CONTA,
      S.CD_REGISTRO_ANS ,
      S.NR_GUIA_PRINCIPAL,
      S.DT_AUTORIZACAO,
      S.CD_SENHA,
      S.DT_VAL_SENHA,
      S.NR_GUIA_OPERADORA,
--DADOS DO BENEFICI?RIO
      S.NR_CARTEIRA_BENEF,
      S.DT_VAL_CARTEIRA_BENEF,
      S.NM_BENEF,
      S.NR_CNS_BENEF,
      S.ID_ATENDIMENTO_RN,

--DADOS DO SOLICITANTE
      S.CD_OPER_CNPJ_CPF_SOL,
      S.NM_CONT_SOL,
      S.NM_PROF_SOL,
      S.CONS_PROF_SOL,
      S.NR_CONS_PROF_SOL,
      S.SG_UF_PROF_SOL ,
      S.CD_ESPEC_SOL,
      NULL ASSINATURA_SOL,

--DADOS DA SOLICITA??O / PROCEDIMENTOS OU ITENS ASSISTENCIAIS SOLICITADOS
      S.CD_TP_CARAT_ATEND,
      S.DT_SOL,
      S.DS_IND_CLINICA,
      NULL TABELA_ITEM,
      NULL COD_PROCEDIMENTO_ASSISTENCIAL,
      NULL DESCRICAO_ITEM,
      NULL QTD_SOLIC_ITEM,
      NULL QTD_AUT_ITEM,

--DADOS DO CONTRATADO EXECUTANTE
      S.CD_OPER_CNPJ_CPF_EXEC,
      S.NM_CONT_EXEC,
      S.CD_CNES_EXEC,
--DADOS DO ATENDIMENTO
      S.CD_TP_ATENDIMENTO,
      S.CD_ID_ACIDENTE,
      S.CD_TIPO_CONSULTA,--S.CD_TP_SAIDA ,
      NULL MOTIVO_ENCERRAMENTO,


--DADOS DA EXECU??O / PROCEDIMENTOS E EXAMES REALIZADOS
      TO_NUMBER(P.NR_SEQ) NR_SEQ_PROC,
      P.DT_PROC_REAL,
      DECODE(P.HR_INI_PROC,NULL,'', SUBSTR(LPAD(TO_CHAR(P.HR_INI_PROC),4,'0'),1,2) || ':' || SUBSTR(LPAD(TO_CHAR(P.HR_INI_PROC),4,'0'),3,2)) HR_INI_PROC,
      DECODE(P.HR_FIM_PROC,NULL,'', SUBSTR(LPAD(TO_CHAR(P.HR_FIM_PROC),4,'0'),1,2) || ':' || SUBSTR(LPAD(TO_CHAR(P.HR_FIM_PROC),4,'0'),3,2)) HR_FIM_PROC,
      P.CD_TABELAS,
      P.CD_PROC_REAL,
      P.DS_PROC_REAL,
      REPLACE(TO_CHAR(P.QT_PROC_REAL),'.', ',') QT_PROC_REAL,
      P.CD_VIA_ACESSO ,
      P.CD_TECNICA_UTILIZADA,
      P.NR_RED_ACR ,
      P.VL_UNIT_PROC,
      P.VL_TOTAL_PROC VL_TOTAL_PROC_PROC ,

--IDENTIFICA??O DOS PROFISSIONAIS EXECUTANTES
      --E.AA_RECEITA,
      TO_NUMBER(E.NR_SEQ) NR_SEQ_PROF,
      E.CD_POS_PROF_EQUIPE,
      E.CD_OPER_CNPJ_CPF_EXEC CD_OPER_CNPJ_CPF_EXEC_E,
      E.NM_PROF_EXEC,
      E.SG_CONS_PROF_EXEC,
      E.NR_CONS_PROF_EXEC,
      E.SG_UF_PROF_EXEC,
      E.CD_ESPEC_EXEC,

--OBS E TOTAIS
      S.DS_OBSERVACAO,
      S.VL_TOTAL_PROC ,
      S.VL_TOTAL_TX_ALUGUEIS ,
      S.VL_TOTAL_MAT,
      S.VL_TOTAL_OPM,
      S.VL_TOTAL_MED,
      S.VL_TOTAL_GASES,
      S.VL_TOTAL_GERAL,

      TO_NUMBER(DP.NR_SEQ) NR_SEQ_DP,
      DP.CD_TABELAS CD_TABELAS_DP,
      DP.CD_PROC_REAL CD_PROC_REAL_DP,
      DP.DS_DESPESA DS_DESPESA_DP,
      REPLACE(TO_CHAR( DP.QT_PROC_REAL),'.', ',') QT_PROC_REAL_DP,

      CASE WHEN DP.NR_SEQ IS NOT NULL THEN DECODE(CCP.FAT_CCP_DT_PARCELA_INI,NULL,CCP.FAT_CCP_DT_PARCELA,CCP.FAT_CCP_DT_PARCELA_INI)
           ELSE NULL END  CCP_DATA,
      DECODE(DP.HR_INI_PROC,NULL,'', SUBSTR(LPAD(TO_CHAR(DP.HR_INI_PROC),4,'0'),1,2) || ':' || SUBSTR(LPAD(TO_CHAR(DP.HR_INI_PROC),4,'0'),3,2)) HR_INI_PROC_DP,
      DECODE(DP.HR_FIM_PROC,NULL,'', SUBSTR(LPAD(TO_CHAR(DP.HR_FIM_PROC),4,'0'),1,2) || ':' || SUBSTR(LPAD(TO_CHAR(DP.HR_FIM_PROC),4,'0'),3,2)) HR_FIM_PROC_DP,
      DP.NR_RED_ACR  NR_RED_ACR_DP,
      DP.VL_UNIT_PROC VL_UNIT_PROC_DP,
      DP.VL_TOTAL_PROC VL_TOTAL_PROC_DP,
      DP.CD_TP_DESPESA CD_TP_DESPESA_DP,
    --  DECODE( DP.CD_TP_DESPESA, 2, DP.DS_DESPESA, 3, DS_DESPESA, DP.CD_PROC_REAL) ORDEM,
      D.VL_TOTAL_GASES  VL_TOTAL_GASES_DP,
      D.VL_TOTAL_MED    VL_TOTAL_MED_DP,
      D.VL_TOTAL_MAT   VL_TOTAL_MAT_DP,
      D.VL_TOTAL_TX   VL_TOTAL_TX_DP,
      D.VL_TOTAL_DI   VL_TOTAL_DI_DP,
      D.VL_TOTAL_ALUGUEIS   VL_TOTAL_ALUGUEIS_DP,
      D.VL_TOTAL_GERAL VL_TOTAL_GERAL_DP,
      UNI.CAD_UNI_DS_UNIDADE,
      LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
      SETOR.CAD_SET_DS_SETOR

FROM TB_FAT_FCL_CONTR_EMI_LOTE      FCL
     JOIN TSS_SPSADT_SGS_V3              S    ON S.NR_CONTA           = FCL.FAT_COC_ID
                                             AND S.CD_PARCELA         = FCL.FAT_CCP_ID
                                             AND S.NR_ATENDIMENTO     = FCL.ATD_ATE_ID
                                             AND S.IDT_PACIENTE       = FCL.CAD_PAC_ID_PACIENTE

LEFT JOIN TSS_SPSADT_PROC_REAL_SGS_V3     P    ON P.NR_CONTA           = FCL.FAT_COC_ID
                                             AND P.CD_PARCELA         = FCL.FAT_CCP_ID
                                             AND P.NR_ATENDIMENTO     = FCL.ATD_ATE_ID
                                             AND P.IDT_PACIENTE       = FCL.CAD_PAC_ID_PACIENTE

LEFT JOIN TSS_SPSADT_PROC_EQUIPE_SGS_V3   E    ON E.NR_CONTA           = FCL.FAT_COC_ID
                                             AND E.CD_PARCELA         = FCL.FAT_CCP_ID
                                             AND E.NR_ATENDIMENTO     = FCL.ATD_ATE_ID
                                             AND E.IDT_PACIENTE       = FCL.CAD_PAC_ID_PACIENTE

LEFT JOIN TSS_OUTRASDESP_SGS              D    ON D.NR_CONTA           = FCL.FAT_COC_ID
                                             AND D.CD_PARCELA         = FCL.FAT_CCP_ID
                                             AND D.NR_ATENDIMENTO     = FCL.ATD_ATE_ID
                                             AND D.IDT_PACIENTE       = FCL.CAD_PAC_ID_PACIENTE

LEFT JOIN TSS_OUTRASDESP_PROC_SGS         DP   ON DP.NR_CONTA           = FCL.FAT_COC_ID
                                             AND DP.CD_PARCELA         = FCL.FAT_CCP_ID
                                             AND DP.NR_ATENDIMENTO     = FCL.ATD_ATE_ID
                                             AND DP.IDT_PACIENTE       = FCL.CAD_PAC_ID_PACIENTE

     JOIN TB_FAT_CCP_CONTA_CONS_PARC      CCP ON CCP.FAT_COC_ID            = FCL.FAT_COC_ID
                                              AND CCP.FAT_CCP_ID            = FCL.FAT_CCP_ID
                                              AND CCP.ATD_ATE_ID            = FCL.ATD_ATE_ID
                                              AND CCP.CAD_PAC_ID_PACIENTE   = FCL.CAD_PAC_ID_PACIENTE

     JOIN TB_ATD_ATE_ATENDIMENTO          ATD ON ATD.ATD_ATE_ID        = FCL.ATD_ATE_ID
     JOIN TB_CAD_UNI_UNIDADE              UNI ON UNI.CAD_UNI_ID_UNIDADE = ATD.CAD_UNI_ID_UNIDADE
     JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO    LAT ON LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO
     JOIN TB_CAD_SET_SETOR                SETOR ON SETOR.CAD_SET_ID = ATD.CAD_SET_ID

    WHERE (FCL.FAT_FCL_NR_SEQ_LOTE = pLOTE)
    AND (DP.NR_SEQ is not null OR P.NR_SEQ IS NOT NULL )
    order by  fcl.fat_fcl_nr_seq_imprime, TO_NUMBER(p.nr_seq), TO_NUMBER(DP.NR_SEQ)

  ;
             io_cursor := v_cursor;
  end PRC_FAT_REL_GUIA_SADT_CONF_V3;
