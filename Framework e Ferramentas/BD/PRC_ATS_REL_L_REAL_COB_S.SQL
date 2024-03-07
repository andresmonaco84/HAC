CREATE OR REPLACE PROCEDURE "PRC_ATS_REL_L_REAL_COB_S"(pMES      IN Tb_Fat_Cci_Conta_Consu_Item.Fat_Cci_Mes_Fechamento%type,
                                                           pANO      IN Tb_Fat_Cci_Conta_Consu_Item.Fat_Cci_Ano_Fechamento%type,
                                                           io_cursor OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_ATS_REL_L_REAL_COB_S
  *
  *    Data Criacao:  15/07/2015   Por: Pedro H.A.C.
  *
  *    Funcao: Relatorio de Conferencia de Exames SADT Realizados X Lancados para Faturamento - Sintetico
  *
  *    Data Alteracao: 10/03/2016 Por Cristiane Gomes
  *
  *    Alteracao: Considerar lancamento para faturamento
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
    SELECT EPP_REALIZADO.AUX_EPP_CD_ESPECPROC CD_ESPECIALIDADE,
           EPP_REALIZADO.AUX_EPP_DS_DESCRICAO DS_ESPECIALIDADE,
           TO_CHAR(ATS.ATS_ATE_DT_REALIZ_PROCED, 'MM') MES,
           TO_CHAR(ATS.ATS_ATE_DT_REALIZ_PROCED, 'YYYY') ANO,
           COUNT(ATS.ATS_ATE_CD_INTLIB) QTD_REALIZADA,
           --COUNT(CCI.ATS_APL_ID)  QTD_COBRADA
           --NVL(COUNT(LANCADO.ATS_APL_ID), 0) QTD_COBRADA
            NVL(COUNT(LANCADO.QTD), 0) QTD_COBRADA
      FROM --TB_ATS_ATE_ATENDIMENTO_SADT ATS  
            TB_ATD_ATE_ATENDIMENTO ATE
      JOIN tb_ats_ate_atendimento_sadt ats
        ON ATS.ATS_ATE_CD_INTLIB = ATE.ATD_ATE_ID
      LEFT JOIN TB_ATS_APL_ATEN_PROCED_LAUDO APL
        ON APL.ATS_ATE_CD_INTLIB = ATS.ATS_ATE_CD_INTLIB
       AND APL.ATS_ATE_ID = ATS.ATS_ATE_ID
       AND APL.CAD_PRD_ID = ATS.CAD_PRD_ID
       AND APL.TIS_MED_CD_TABELAMEDICA = ATS.TIS_MED_CD_TABELAMEDICA
       AND APL.AUX_EPP_CD_ESPECPROC = ATS.AUX_EPP_CD_ESPECPROC
       AND APL.ATS_APL_STATUS_LAUDO IN ('L', 'P')
       /*LEFT JOIN TB_FAT_CCI_CONTA_CONSU_ITEM CCI
      ON CCI.ATD_ATE_ID = ATS.ATS_ATE_CD_INTLIB
      AND CCI.ATS_APL_ID = APL.ATS_APL_ID
      AND CCI.FAT_CCI_FL_STATUS = 'A'
      AND CCI.CAD_TAP_TP_ATRIBUTO = 'EXA'*/
     /*LEFT JOIN(SELECT distinct CCI.ATD_ATE_ID , CCI.ATS_APL_ID
               FROM TB_FAT_CCI_CONTA_CONSU_ITEM CCI
               JOIN TB_ATS_ATE_ATENDIMENTO_SADT ATS ON ATS.ATS_ATE_CD_INTLIB = CCI.ATD_ATE_ID
               WHERE CCI.FAT_CCI_FL_STATUS = 'A'
                AND CCI.ATS_APL_ID IS NOT NULL
                AND CCI.CAD_TAP_TP_ATRIBUTO = 'EXA'                 
                AND TO_CHAR(CCI.FAT_CCI_DT_INICIO_CONSUMO, 'YYYY') = pANO
                AND TO_CHAR(CCI.FAT_CCI_DT_INICIO_CONSUMO, 'MM') BETWEEN 1 AND pMES
                AND ATS.ATS_ATE_FL_STATUS = 'A'
                AND TO_CHAR(ATS.ATS_ATE_DT_REALIZ_PROCED, 'YYYY') = pANO
               AND TO_CHAR(ATS.ATS_ATE_DT_REALIZ_PROCED, 'MM') BETWEEN 1 AND pMES
    ) LANCADO ON LANCADO.ATD_ATE_ID = ATS.ATS_ATE_CD_INTLIB
    AND LANCADO.ATS_APL_ID = APL.ATS_APL_ID   */
      LEFT JOIN (SELECT DISTINCT CCI.ATD_ATE_ID ATENDIMENTO, 1 QTD
                   FROM TB_ATD_ATE_ATENDIMENTO ATE
                   JOIN TB_FAT_CCI_CONTA_CONSU_ITEM CCI
                     ON CCI.ATD_ATE_ID = ATE.ATD_ATE_ID
                    AND CCI.CAD_TAP_TP_ATRIBUTO = 'EXA'
                    AND to_char(CCI.FAT_CCI_DT_INICIO_CONSUMO, 'YYYY') = pANO
                    AND to_char(CCI.FAT_CCI_DT_INICIO_CONSUMO, 'MM') BETWEEN 1 AND pMES
                    and ate.atd_ate_fl_status = 'A'
                 --and ate.atd_ate_tp_paciente in ('I','E')
                 ) LANCADO
        ON LANCADO.ATENDIMENTO = ATE.ATD_ATE_ID
      JOIN TB_CAD_PRD_PRODUTO PRD_REALIZADO ON PRD_REALIZADO.CAD_PRD_ID = ATS.CAD_PRD_ID
       AND PRD_REALIZADO.TIS_MED_CD_TABELAMEDICA = ATS.TIS_MED_CD_TABELAMEDICA
       AND PRD_REALIZADO.AUX_EPP_CD_ESPECPROC = ATS.AUX_EPP_CD_ESPECPROC
      JOIN TB_AUX_EPP_ESPECPROC EPP_REALIZADO
        ON PRD_REALIZADO.TIS_MED_CD_TABELAMEDICA = EPP_REALIZADO.TIS_MED_CD_TABELAMEDICA
       AND PRD_REALIZADO.AUX_EPP_CD_ESPECPROC = EPP_REALIZADO.AUX_EPP_CD_ESPECPROC
     WHERE ATS.ATS_ATE_FL_STATUS = 'A'
       --AND ATS.CAD_SET_ID_ATEN != 113
       AND ATS_ATE_FL_REPETICAO = 'N'
       AND EPP_REALIZADO.AUX_EPP_CD_ESPECPROC NOT IN ('23','30','39','40')
       AND TO_CHAR(ATS.ATS_ATE_DT_REALIZ_PROCED, 'YYYY') = pANO
       AND TO_CHAR(ATS.ATS_ATE_DT_REALIZ_PROCED, 'MM') BETWEEN 1 AND pMES
     GROUP BY EPP_REALIZADO.AUX_EPP_DS_DESCRICAO,
              EPP_REALIZADO.AUX_EPP_CD_ESPECPROC,
              TO_CHAR(ATS.ATS_ATE_DT_REALIZ_PROCED, 'MM'),
              TO_CHAR(ATS.ATS_ATE_DT_REALIZ_PROCED, 'YYYY')
     ORDER BY EPP_REALIZADO.AUX_EPP_DS_DESCRICAO,
              EPP_REALIZADO.AUX_EPP_CD_ESPECPROC,
              to_number(TO_CHAR(ATS.ATS_ATE_DT_REALIZ_PROCED, 'MM')),
              TO_CHAR(ATS.ATS_ATE_DT_REALIZ_PROCED, 'YYYY');
  io_cursor := v_cursor;
end PRC_ATS_REL_L_REAL_COB_S;
