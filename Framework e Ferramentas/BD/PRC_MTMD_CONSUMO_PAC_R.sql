CREATE OR REPLACE PROCEDURE PRC_MTMD_CONSUMO_PAC_R
  (
     pCAD_MTMD_FILIAL_ID IN TB_MTMD_MOV_MOVIMENTACAO.CAD_MTMD_FILIAL_ID%type DEFAULT NULL,
     pCAD_MTMD_ID IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_ID%type DEFAULT NULL,
     pMTMD_MOV_DATA IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_DATA%type DEFAULT NULL,
     pMTMD_MOV_DATA_FIM IN TB_MTMD_MOV_MOVIMENTACAO.MTMD_MOV_DATA%type DEFAULT NULL,
     pATD_ATE_ID IN TB_MTMD_MOV_MOVIMENTACAO.ATD_ATE_ID%type DEFAULT NULL,
     pCOM_PEDIDO IN NUMBER DEFAULT NULL, -- 0 ou 1
     pTIRAR_DATA IN NUMBER DEFAULT NULL, -- 0 ou 1 (Se = 1, traz Cod. Produto no lugar da Data)
     pCAD_SET_ID IN TB_MTMD_MOV_MOVIMENTACAO.CAD_SET_ID%type DEFAULT NULL,
     pSOMENTECOVID IN NUMBER DEFAULT NULL, -- 0 ou 1
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_MTMD_CONSUMO_PAC_R
  *
  *    Data Criacao:   23/08/2013        Por: Andre
  *    Data Alterac?o: 10/09/2014        Por: Andre
  *         Alterac?o: Adic?o de busca com pedido (pCOM_PEDIDO)
  *    Data Alterac?o: 25/06/2015        Por: Andre
  *         Alterac?o: Adicao do param. pCAD_SET_ID
  *    Data Alterac?o: 26/06/2015        Por: Andre
  *         Alterac?o: Adicao do param. pTIRAR_DATA
  *
  *    Funcao: Relatorios de consumos de produto por paciente
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  V_WHERE       varchar2(5000);
  V_SELECT      varchar2(5000);
  V_SELECT2     varchar2(5000);
  V_DATA_SELECT varchar2(100);
  V_DATA_GROUP  varchar2(100);
  V_DATA_ORDER  varchar2(100);
  begin
  IF pCAD_MTMD_FILIAL_ID IS NOT NULL THEN
       IF pCAD_MTMD_FILIAL_ID = 1 THEN --Para HAC traz tambem CE
          V_WHERE := V_WHERE || ' AND MOVIMENTACAO.CAD_MTMD_FILIAL_ID IN (1, 4) ';
       ELSE
          V_WHERE := V_WHERE || ' AND MOVIMENTACAO.CAD_MTMD_FILIAL_ID = ' || pCAD_MTMD_FILIAL_ID;
       END IF;
  END IF;
  IF pCAD_MTMD_ID IS NOT NULL THEN V_WHERE := V_WHERE || ' AND MOVIMENTACAO.CAD_MTMD_ID = ' || pCAD_MTMD_ID; END IF;
  IF NVL(PSOMENTECOVID,0) = 1 THEN V_WHERE := V_WHERE || ' AND (PRODUTO.CAD_MTMD_ID in (162250,4488,162233,10514,158075,162204,6306,159811,
    147847,161399,162251,162290,20242,1903,65893,160205,13652,152435,151797,151798,151645,155357,3259,2531,162203,9971,156199,144767,518,
512,7467,161053,46235,53893,4276,18500,151025,87933,17301,93913,87806,7623,1718,145530,1644,162266,162267,102793,2403,40893,3397,862,6301
     )  or produto.CAD_MTMD_PRIATI_ID in (select produto.CAD_MTMD_PRIATI_ID from TB_CAD_MTMD_MAT_MED produto where produto.CAD_MTMD_ID in (162250,4488,162233,10514,158075,162204,6306,159811,
    147847,161399,162251,162290,20242,1903,65893,160205,13652,152435,151797,151798,151645,155357,3259,2531,162203,9971,156199,144767,518,
512,7467,161053,46235,53893,4276,18500,151025,87933,17301,93913,87806,7623,1718,145530,1644,162266,162267,102793,2403,40893,3397,862,6301) and
  produto.CAD_MTMD_PRIATI_ID !=0 )
  )'; END IF;

  IF (pMTMD_MOV_DATA IS NOT NULL AND pMTMD_MOV_DATA_FIM IS NOT NULL) THEN
    V_WHERE := V_WHERE || ' AND TRUNC(MOVIMENTACAO.MTMD_MOV_DATA) BETWEEN '
                       ||       CHR(39) || pMTMD_MOV_DATA || CHR(39) || ' AND '
                       ||       CHR(39) || pMTMD_MOV_DATA_FIM || CHR(39);
  END IF;
  IF pATD_ATE_ID IS NOT NULL THEN V_WHERE := V_WHERE || ' AND MOVIMENTACAO.ATD_ATE_ID = ' || pATD_ATE_ID; END IF;
  IF pCAD_SET_ID IS NOT NULL THEN V_WHERE := V_WHERE || ' AND MOVIMENTACAO.CAD_SET_ID = ' || pCAD_SET_ID; END IF;
  IF NVL(pTIRAR_DATA, 0) = 0 THEN
     V_DATA_SELECT := 'TO_CHAR(MOVIMENTACAO.MTMD_MOV_DATA,''dd/MM/yyyy'') DATA_CONSUMO,';
     V_DATA_GROUP  := 'TO_DATE(MOVIMENTACAO.MTMD_MOV_DATA,''dd/MM/yyyy''),TO_CHAR(MOVIMENTACAO.MTMD_MOV_DATA,''dd/MM/yyyy''),';
     V_DATA_ORDER  := 'TO_DATE(MOVIMENTACAO.MTMD_MOV_DATA,''dd/MM/yyyy''),';
  ELSE
     V_DATA_SELECT := 'PRODUTO.CAD_MTMD_CODMNE DATA_CONSUMO,';
     V_DATA_GROUP  := 'PRODUTO.CAD_MTMD_CODMNE,';
  END IF;
  V_SELECT := 'SELECT ' || V_DATA_SELECT || '
                       MOVIMENTACAO.ATD_ATE_ID || ''-'' || MOVIMENTACAO.ATD_ATE_TP_PACIENTE ATENDIMENTO_TIPO,
                       PESSOA.CAD_PES_NM_PESSOA NOME_PACIENTE,
                       CONV.CAD_CNV_CD_HAC_PRESTADOR CONVENIO,
                       UNIDADE.CAD_UNI_DS_UNIDADE || '' / '' || SETOR.CAD_SET_DS_SETOR UNIDADE_SETOR,
                       SUM(MOVIMENTACAO.MTMD_MOV_QTDE) QTD_CONSUMO,
                       DECODE(MOVIMENTACAO.CAD_MTMD_SUBTP_ID, 14, PRODUTO.CAD_MTMD_NOMEFANTASIA || '' *'', PRODUTO.CAD_MTMD_NOMEFANTASIA) PRODUTO,
                       GRUPO.CAD_MTMD_GRUPO_ID,
                       GRUPO.CAD_MTMD_GRUPO_DESCRICAO,
                       DECODE(GRUPO.CAD_MTMD_GRUPO_ID,1,LOTE.MTMD_NUM_LOTE,NULL) MTMD_NUM_LOTE,
                       DECODE(GRUPO.CAD_MTMD_GRUPO_ID,1,LOTE.MTMD_DT_VALIDADE,NULL) MTMD_DT_VALIDADE
                  FROM TB_MTMD_MOV_MOVIMENTACAO MOVIMENTACAO,
                       TB_CAD_MTMD_MAT_MED      PRODUTO,
                       TB_CAD_UNI_UNIDADE       UNIDADE,
                       TB_CAD_SET_SETOR         SETOR,
                       TB_ASS_PAT_PACIEATEND    PAC_ATE,
                       TB_CAD_PAC_PACIENTE      PACIENTE,
                       TB_CAD_PES_PESSOA        PESSOA,
                       TB_CAD_CNV_CONVENIO      CONV,
                       TB_CAD_MTMD_GRUPO        GRUPO,
                       TB_MTMD_LOTEST_LOTE_ESTOQUE LOTE
                WHERE MOVIMENTACAO.ATD_ATE_ID IS NOT NULL
                  AND MOVIMENTACAO.CAD_MTMD_TPMOV_ID = 2
                  AND MOVIMENTACAO.CAD_MTMD_SUBTP_ID IN (11, 14, 18, 24, 25, 26, 35, 36, 60)
                  AND MOVIMENTACAO.MTMD_MOV_FL_ESTORNO = 0
                  AND MOVIMENTACAO.CAD_MTMD_ID = PRODUTO.CAD_MTMD_ID
                  AND MOVIMENTACAO.MTMD_LOTEST_ID = LOTE.MTMD_LOTEST_ID(+)
                  AND UNIDADE.CAD_UNI_ID_UNIDADE = MOVIMENTACAO.CAD_UNI_ID_UNIDADE
                  AND SETOR.CAD_SET_ID = MOVIMENTACAO.CAD_SET_ID
                  AND GRUPO.CAD_MTMD_GRUPO_ID = PRODUTO.CAD_MTMD_GRUPO_ID
                  AND (PAC_ATE.ATD_ATE_ID = MOVIMENTACAO.ATD_ATE_ID 
                       AND (PAC_ATE.ASS_PAT_DT_SAIDA IS NULL OR
                            (FNC_JUNTAR_DATA_HORA(NVL(PAC_ATE.ASS_PAT_DT_SAIDA,TRUNC(SYSDATE)),PAC_ATE.ASS_PAT_HR_SAIDA) = (SELECT MAX(FNC_JUNTAR_DATA_HORA(ASS_PAT_DT_SAIDA,ASS_PAT_HR_SAIDA))
                                                                                                                              FROM TB_ASS_PAT_PACIEATEND
                                                                                                                             WHERE ATD_ATE_ID = MOVIMENTACAO.ATD_ATE_ID AND ASS_PAT_DT_SAIDA IS NOT NULL AND
                                                                                                                                   (SELECT COUNT(*) FROM TB_ASS_PAT_PACIEATEND 
                                                                                                                                     WHERE ATD_ATE_ID = MOVIMENTACAO.ATD_ATE_ID AND
                                                                                                                                           ASS_PAT_DT_SAIDA IS NULL) = 0))))
                  AND PACIENTE.CAD_PAC_ID_PACIENTE = PAC_ATE.CAD_PAC_ID_PACIENTE
                  AND PESSOA.CAD_PES_ID_PESSOA = PACIENTE.CAD_PES_ID_PESSOA
                  AND CONV.CAD_CNV_ID_CONVENIO = PACIENTE.CAD_CNV_ID_CONVENIO ';
  V_SELECT2 := ' GROUP BY ' || V_DATA_GROUP || '
                         MOVIMENTACAO.ATD_ATE_ID,
                         MOVIMENTACAO.ATD_ATE_TP_PACIENTE,
                         UNIDADE.CAD_UNI_DS_UNIDADE,
                         SETOR.CAD_SET_DS_SETOR,
                         PESSOA.CAD_PES_NM_PESSOA,
                         CONV.CAD_CNV_CD_HAC_PRESTADOR,
                         PRODUTO.CAD_MTMD_NOMEFANTASIA,
                         MOVIMENTACAO.CAD_MTMD_ID,
                         MOVIMENTACAO.CAD_MTMD_SUBTP_ID,
                         GRUPO.CAD_MTMD_GRUPO_ID,
                         GRUPO.CAD_MTMD_GRUPO_DESCRICAO,
                         DECODE(GRUPO.CAD_MTMD_GRUPO_ID,1,LOTE.MTMD_NUM_LOTE,NULL),
                         DECODE(GRUPO.CAD_MTMD_GRUPO_ID,1,LOTE.MTMD_DT_VALIDADE,NULL)
                 ORDER BY ' || V_DATA_ORDER || '
                          PESSOA.CAD_PES_NM_PESSOA,
                          PRODUTO.CAD_MTMD_NOMEFANTASIA ';
  IF (NVL(pCOM_PEDIDO,0) = 1) THEN
     V_SELECT := Replace(V_SELECT,
                         'PRODUTO.CAD_MTMD_NOMEFANTASIA) PRODUTO',
                         'PRODUTO.CAD_MTMD_NOMEFANTASIA) PRODUTO,
                         CASE WHEN (MOVIMENTACAO.MTMD_REQ_ID IS NULL) THEN
                           (SELECT MAX(R.MTMD_REQ_ID)
                              FROM TB_MTMD_REQUISICAO_ITEM I JOIN
                                   TB_MTMD_REQ_REQUISICAO R ON R.MTMD_REQ_ID = I.MTMD_REQ_ID
                             WHERE R.ATD_ATE_ID  = MOVIMENTACAO.ATD_ATE_ID AND I.CAD_MTMD_ID = MOVIMENTACAO.CAD_MTMD_ID)
                         ELSE MTMD_REQ_ID END MTMD_REQ_ID ');
     V_SELECT2 := Replace(V_SELECT2,
                          'PRODUTO.CAD_MTMD_NOMEFANTASIA',
                          'PRODUTO.CAD_MTMD_NOMEFANTASIA, MOVIMENTACAO.MTMD_REQ_ID ');
  END IF;
  OPEN v_cursor FOR
  V_SELECT || V_WHERE || V_SELECT2;
  io_cursor := v_cursor;
end PRC_MTMD_CONSUMO_PAC_R;