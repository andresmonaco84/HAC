CREATE OR REPLACE PROCEDURE "PRC_FAT_REL_GUIA_SADT" (
    pLOTE IN TB_FAT_FCL_CONTR_EMI_LOTE.FAT_FCL_NR_SEQ_LOTE%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_FAT_REL_GUIA_SADT
  *
  *    Data Criacao: 17/05/2010  Por: Pedro
  *    Altera��o:
  *
  *    Atendimento Amb. e Interna��o Externo( n�o interna, utiliza sala de cirurg.)
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
      S.CD_REGISTRO_ANS REGISTROANS,
      S.NR_GUIA NUMERO,
      S.NR_GUIA_PRINCIPAL NUMEROGUIAPRINCIPAL,
      S.DT_AUTORIZACAO DATADAAUTORIZACAO,
      S.CD_SENHA SENHA,
      S.DT_VAL_SENHA DATAVALIDADESENHA,
      TRUNC(S.DT_EMI_GUIA) DATAEMISSAODAGUIA,
      S.NR_CARTEIRA_BENEF NUMERODACARTEIRA,
      S.NM_PLANO_BENEF PLANO,
      S.DT_VAL_CARTEIRA_BENEF VALIDADEDACARTEIRA,
      S.NM_BENEF NOME      ,
      S.NR_CNS_BENEF NUMERODOCARTAONACIONALDESAUDE,
      S.CD_OPER_CNPJ_CPF_SOL CODIGONAOPERADORACNPJCPFSOL,
      S.NM_CONT_SOL NOMEDOCONTRATADOSOL,
      S.CD_CNES_SOL CODIGOCNESSOL,
      S.NM_PROF_SOL NOMEDOPROFISSIONALSOLICITANTE,
      S.SG_CONS_PROF_SOL CONSELHOPROFISSIONALSOL,
      S.NR_CONS_PROF_SOL NUMERODOCONSELHOSOL,
      S.SG_UF_PROF_SOL UFSOL,
      S.CD_ESPEC_SOL CODIGOCBOSSOL,
      S.DT_SOL DATAHORASOLICITACAO,
      S.CD_TP_CARAT_ATEND CARATERDASOLICITACAO,
      S.CD_CID10_PRINC CID10,
      S.DS_IND_CLINICA INDICACAOCLINICA,
      S.CD_OPER_CNPJ_CPF_EXEC CODIGONAOPERADORAEXECUTANTE,
      S.NM_CONT_EXEC  NOMEDOCONTRATADOEXEC,
      S.TP_LOGRA_CONT TLEXEC,
      S.NM_LOGRA_CONT LOGRADOUROEXEC,
      S.NR_LOGRA_CONT NUMEROEXEC,
      S.DS_COMPL_LOGRA_CONT COMPLEMENTOEXEC,
      S.NM_MUNIC_CONT MUNICIPIOEXEC,
      S.CD_UF_CONT UFCONTRATADOEXEC,
      S.CD_IBGE_MUNIC_CONT CODIGOIBGEEXEC,
      S.NR_CEP_CONT CEPEXEC ,
      S.CD_CNES_EXEC CODIGOCNESEXECUTANTE ,
      S.CD_OPER_CNPJ_CPF_EXEC_COMP CODIGONAOPERADORAEXECCOMPLEM,
      S.NM_PROF_EXEC_COMP NOMEPROFCOMPLEM,
      S.SG_CONS_PROF_EXEC_COMP CONSELHOPROFEXECCOMPL,
      S.NR_CONS_PROF_EXEC_COMP NUMEROPROFEXECCOMPL,
      S.SG_UF_PROF_EXEC_COMP UFPROFEXECCOMPL,
      S.CD_ESPEC_EXEC_COMP  CBOSEXECCOMPL,
      S.CD_POS_PROF_EQUIPE GRAUDEPARTICIPACAOCOMPL,
      S.CD_TP_ATENDIMENTO TIPODEATENDIMENTO,
      S.CD_ID_ACIDENTE INDICACAODEACIDENTE,
      S.CD_TP_SAIDA TIPODESAIDA,
      S.CD_TP_DOENCA TIPODEDOENCA,
      S.NR_TMP_DOENCA_REF_PAC TEMPODEDOENCANUMERO,
      S.TMP_DOENCA_REF_PAC TEMPODEDOENCAANOSMESESDIAS,
      S.DS_OBSERVACAO OBSERVACAO,
      S.VL_TOTAL_PROC TOTALPROCEDIMENTOS,
      S.VL_TOTAL_TX_ALUGUEIS TOTALTAXASALUGUEIS,
      S.VL_TOTAL_MAT TOTALMATERIAIS,
      S.VL_TOTAL_MED TOTALMEDICAMENTOS,
      S.VL_TOTAL_DI TOTALDIARIAS,
      S.VL_TOTAL_GASES TOTALGASESMEDICINAIS,
      S.VL_TOTAL_GERAL TOTALGERALDAGUIA,
      S.VL_TOTAL_OPM NAOUSADO,
     
      to_number(P.NR_SEQ) SEQUENCIAPROCEDIMENTO,
      P.CD_TABELAS TABELA ,
      P.CD_PROC_REAL CODIGOPROCEDIMENTO,
      P.DS_PROC_REAL DESCRICAO,
      REPLACE(TO_CHAR(P.QT_PROC_REAL),'.', ',') QUANTIDADE,
      P.DT_PROC_REAL DATA,
      DECODE(P.HR_INI_PROC,NULL,'', SUBSTR(LPAD(TO_CHAR(P.HR_INI_PROC),4,'0'),1,2) || ':' || SUBSTR(LPAD(TO_CHAR(P.HR_INI_PROC),4,'0'),3,2)) HORAINICIAL,
      DECODE(P.HR_FIM_PROC,NULL,'', SUBSTR(LPAD(TO_CHAR(P.HR_FIM_PROC),4,'0'),1,2) || ':' || SUBSTR(LPAD(TO_CHAR(P.HR_FIM_PROC),4,'0'),3,2)) HORAFINAL,
      P.CD_VIA_ACESSO VIA ,
      P.CD_TECNICA_UTILIZADA TECNICA,
      P.NR_RED_ACR  PERCENTUALREDUCAOACRESCIMO,
      P.VL_UNIT_PROC VALORUNITARIO,
      P.VL_TOTAL_PROC  VALORTOTAL,

      nvl(O.NR_SEQ,1) SEQUENCIALOPM,
      O.CD_TABELA_OPM TABELAOPM,
      O.CD_OPM CODIGOOPM,
      O.DS_OPM DESCRICAOOPM,
      REPLACE(TO_CHAR(O.QT_OPM),'.', ',') QTDOPM,
      O.VL_UNIT_OPM VALORUNITOPM,
      O.VL_TOTAL_OPM VALORTOTALOPM,
      O.CD_BARRAS_OPM CODIGOBARRASOPM,

      FCL.FAT_FCL_NR_SEQ_IMPRIME


    from TSS_SPSADT_SGS S,
         TSS_SPSADT_PROC_REAL_SGS P,
         TSS_SPSADT_OPM_UTIL_SGS O,
         TB_FAT_FCL_CONTR_EMI_LOTE FCL

    where FCL.FAT_COC_ID            = S.NR_CONTA
    AND  FCL.FAT_CCP_ID            = S.CD_PARCELA
    AND  FCL.ATD_ATE_ID            = S.NR_ATENDIMENTO
    AND  FCL.CAD_PAC_ID_PACIENTE   = S.IDT_PACIENTE

    and S.CD_PARCELA               = P.CD_PARCELA (+)
    and S.NR_ATENDIMENTO           = P.NR_ATENDIMENTO (+)
    AND S.NR_CONTA                 = P.NR_CONTA (+)
    AND S.IDT_PACIENTE             = P.IDT_PACIENTE (+)
    and S.CD_REGISTRO_ANS          = P.CD_REGISTRO_ANS (+)

    and S.NR_CONTA                 = O.NR_CONTA (+)
    and S.CD_PARCELA               = O.CD_PARCELA (+)
    AND S.IDT_PACIENTE             = O.IDT_PACIENTE (+)
    and S.NR_ATENDIMENTO           = O.NR_ATENDIMENTO (+)
    and S.CD_REGISTRO_ANS          = O.CD_REGISTRO_ANS (+)

    AND (FCL.FAT_FCL_NR_SEQ_LOTE = pLOTE)
     order by  fcl.fat_fcl_nr_seq_imprime, to_number(p.nr_seq), to_number(o.nr_seq)
  ;
             io_cursor := v_cursor;
  end PRC_FAT_REL_GUIA_SADT;
/
