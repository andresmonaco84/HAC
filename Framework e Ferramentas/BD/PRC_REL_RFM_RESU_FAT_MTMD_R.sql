CREATE OR REPLACE PROCEDURE PRC_REL_RFM_RESU_FAT_MTMD_R
  (
     pREL_RFM_ANO_FECHAMENTO IN TB_REL_RFM_RESU_FAT_MTMD.REL_RFM_ANO_FECHAMENTO%type,
     pREL_RFM_MES_FECHAMENTO IN TB_REL_RFM_RESU_FAT_MTMD.REL_RFM_MES_FECHAMENTO%type,     
     io_cursor               OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************************
  *    Procedure: PRC_REL_RFM_RESU_FAT_MTMD_R
  *
  *    Data Criacao: 	 30/09/2013   Por: Andre Souza Monaco
  *    Data Alteracao: 28/03/2014   Por: Andre Souza Monaco
  *         Alteracao: Adic?o da func?o FNC_MTMD_REL_RFM_VAL_MES para retorno 
  *                    dos valores e campo TOTAL
  *    Data Alteracao: 14/04/2015   Por: Andre Souza Monaco
  *         Alteracao: Mudanca de parametros na chamada da FNC_MTMD_REL_RFM_VAL_MES 
  *    Data Alteracao: 28/04/2015   Por: Andre Souza Monaco
  *         Alteracao: Add. do campo TOTAL_PER_ANO_ANT   
  *
  *    Funcao: Query p/ Relatorio de resumo do fechamento de mat/med
  *
  *********************************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  dataRef DATE := TO_DATE(TO_CHAR('01/' || pREL_RFM_MES_FECHAMENTO || '/' || pREL_RFM_ANO_FECHAMENTO), 'DD/MM/YYYY');
  begin
    OPEN v_cursor FOR
    SELECT EST.REL_RFM_DS_ITEM,
           EST.REL_RFM_TP_ITEM,
           FNC_MTMD_REL_RFM_VAL_MES(TO_CHAR(ADD_MONTHS(dataRef,-11),'YYYY'),
                                    TO_CHAR(ADD_MONTHS(dataRef,-11),'MM'),                                         
                                    EST.REL_RFM_COD_ITEM,
                                    EST.REL_RMF_SEQ_ITEM,
                                    EST.REL_RFM_AGRUPAMENTO_ID,
                                    0, NULL, NULL) MES_1,
           FNC_MTMD_REL_RFM_VAL_MES(TO_CHAR(ADD_MONTHS(dataRef,-10),'YYYY'),
                                    TO_CHAR(ADD_MONTHS(dataRef,-10),'MM'),                                         
                                    EST.REL_RFM_COD_ITEM,
                                    EST.REL_RMF_SEQ_ITEM,
                                    EST.REL_RFM_AGRUPAMENTO_ID,
                                    0, NULL, NULL) MES_2,
           FNC_MTMD_REL_RFM_VAL_MES(TO_CHAR(ADD_MONTHS(dataRef,-9),'YYYY'),
                                    TO_CHAR(ADD_MONTHS(dataRef,-9),'MM'),                                         
                                    EST.REL_RFM_COD_ITEM,
                                    EST.REL_RMF_SEQ_ITEM,
                                    EST.REL_RFM_AGRUPAMENTO_ID,
                                    0, NULL, NULL) MES_3,
            FNC_MTMD_REL_RFM_VAL_MES(TO_CHAR(ADD_MONTHS(dataRef,-8),'YYYY'),
                                      TO_CHAR(ADD_MONTHS(dataRef,-8),'MM'),                                         
                                      EST.REL_RFM_COD_ITEM,
                                      EST.REL_RMF_SEQ_ITEM,
                                      EST.REL_RFM_AGRUPAMENTO_ID,
                                      0, NULL, NULL) MES_4,
            FNC_MTMD_REL_RFM_VAL_MES(TO_CHAR(ADD_MONTHS(dataRef,-7),'YYYY'),
                                      TO_CHAR(ADD_MONTHS(dataRef,-7),'MM'),                                         
                                      EST.REL_RFM_COD_ITEM,
                                      EST.REL_RMF_SEQ_ITEM,
                                      EST.REL_RFM_AGRUPAMENTO_ID,
                                      0, NULL, NULL) MES_5,
            FNC_MTMD_REL_RFM_VAL_MES(TO_CHAR(ADD_MONTHS(dataRef,-6),'YYYY'),
                                      TO_CHAR(ADD_MONTHS(dataRef,-6),'MM'),                                         
                                      EST.REL_RFM_COD_ITEM,
                                      EST.REL_RMF_SEQ_ITEM,
                                      EST.REL_RFM_AGRUPAMENTO_ID,
                                      0, NULL, NULL) MES_6,
            FNC_MTMD_REL_RFM_VAL_MES(TO_CHAR(ADD_MONTHS(dataRef,-5),'YYYY'),
                                      TO_CHAR(ADD_MONTHS(dataRef,-5),'MM'),                                         
                                      EST.REL_RFM_COD_ITEM,
                                      EST.REL_RMF_SEQ_ITEM,
                                      EST.REL_RFM_AGRUPAMENTO_ID,
                                      0, NULL, NULL) MES_7,
            FNC_MTMD_REL_RFM_VAL_MES(TO_CHAR(ADD_MONTHS(dataRef,-4),'YYYY'),
                                      TO_CHAR(ADD_MONTHS(dataRef,-4),'MM'),                                         
                                      EST.REL_RFM_COD_ITEM,
                                      EST.REL_RMF_SEQ_ITEM,
                                      EST.REL_RFM_AGRUPAMENTO_ID,
                                      0, NULL, NULL) MES_8,
            FNC_MTMD_REL_RFM_VAL_MES(TO_CHAR(ADD_MONTHS(dataRef,-3),'YYYY'),
                                      TO_CHAR(ADD_MONTHS(dataRef,-3),'MM'),                                         
                                      EST.REL_RFM_COD_ITEM,
                                      EST.REL_RMF_SEQ_ITEM,
                                      EST.REL_RFM_AGRUPAMENTO_ID,
                                      0, NULL, NULL) MES_9,
            FNC_MTMD_REL_RFM_VAL_MES(TO_CHAR(ADD_MONTHS(dataRef,-2),'YYYY'),
                                      TO_CHAR(ADD_MONTHS(dataRef,-2),'MM'),                                         
                                      EST.REL_RFM_COD_ITEM,
                                      EST.REL_RMF_SEQ_ITEM,
                                      EST.REL_RFM_AGRUPAMENTO_ID,
                                      0, NULL, NULL) MES_10,
            FNC_MTMD_REL_RFM_VAL_MES(TO_CHAR(ADD_MONTHS(dataRef,-1),'YYYY'),
                                      TO_CHAR(ADD_MONTHS(dataRef,-1),'MM'),                                         
                                      EST.REL_RFM_COD_ITEM,
                                      EST.REL_RMF_SEQ_ITEM,
                                      EST.REL_RFM_AGRUPAMENTO_ID,
                                      0, NULL, NULL) MES_11,
            FNC_MTMD_REL_RFM_VAL_MES(pREL_RFM_ANO_FECHAMENTO,
                                     pREL_RFM_MES_FECHAMENTO,
                                     EST.REL_RFM_COD_ITEM,
                                     EST.REL_RMF_SEQ_ITEM,
                                     EST.REL_RFM_AGRUPAMENTO_ID,
                                     0, NULL, NULL) MES_12,
           FNC_MTMD_REL_RFM_VAL_MES(pREL_RFM_ANO_FECHAMENTO,
                                     pREL_RFM_MES_FECHAMENTO,
                                     EST.REL_RFM_COD_ITEM,
                                     EST.REL_RMF_SEQ_ITEM,
                                     EST.REL_RFM_AGRUPAMENTO_ID,
                                     1,
                                     TO_DATE(TO_CHAR('01/01/' || TO_CHAR(pREL_RFM_ANO_FECHAMENTO-1)), 'DD/MM/YYYY'),
                                     ADD_MONTHS(dataRef,-(pREL_RFM_MES_FECHAMENTO))) TOTAL_ANO_ANTERIOR,
           FNC_MTMD_REL_RFM_VAL_MES(pREL_RFM_ANO_FECHAMENTO,
                                     pREL_RFM_MES_FECHAMENTO,
                                     EST.REL_RFM_COD_ITEM,
                                     EST.REL_RMF_SEQ_ITEM,
                                     EST.REL_RFM_AGRUPAMENTO_ID,
                                     1,
                                     TO_DATE(TO_CHAR('01/01/' || TO_CHAR(pREL_RFM_ANO_FECHAMENTO-1)), 'DD/MM/YYYY'),
                                     ADD_MONTHS(dataRef,-12)) TOTAL_PER_ANO_ANT,
                                     --TO_DATE(TO_CHAR('01/' || pREL_RFM_MES_FECHAMENTO || '/' || TO_CHAR(pREL_RFM_ANO_FECHAMENTO-1)), 'DD/MM/YYYY')) TOTAL_PER_ANO_ANT,
           FNC_MTMD_REL_RFM_VAL_MES(pREL_RFM_ANO_FECHAMENTO,
                                     pREL_RFM_MES_FECHAMENTO,
                                     EST.REL_RFM_COD_ITEM,
                                     EST.REL_RMF_SEQ_ITEM,
                                     EST.REL_RFM_AGRUPAMENTO_ID,
                                     1,
                                     ADD_MONTHS(dataRef,-(pREL_RFM_MES_FECHAMENTO-1)),
                                     dataRef) TOTAL_ANO_ATUAL,
           FNC_MTMD_REL_RFM_VAL_MES(pREL_RFM_ANO_FECHAMENTO,
                                     pREL_RFM_MES_FECHAMENTO,
                                     EST.REL_RFM_COD_ITEM,
                                     EST.REL_RMF_SEQ_ITEM,
                                     EST.REL_RFM_AGRUPAMENTO_ID,
                                     1,
                                     ADD_MONTHS(dataRef,-11),
                                     dataRef) TOTAL,
            EST.REL_RFM_AGRUPAMENTO_ID
    FROM TB_REL_RFM_MTMD_ESTRUTURA EST
    ORDER BY EST.REL_RFM_AGRUPAMENTO_ID, EST.REL_RMF_SEQ_ITEM;
    io_cursor := v_cursor;
  end PRC_REL_RFM_RESU_FAT_MTMD_R;
  /*CASE 
       WHEN EST.REL_RFM_COD_ITEM = 'IECS' THEN
         ROUND((SELECT R.REL_RMF_VL_ITEM
                  FROM TB_REL_RFM_RESU_FAT_MTMD R JOIN TB_REL_RFM_MTMD_ESTRUTURA E ON E.REL_RMF_SEQ_ITEM = R.REL_RMF_SEQ_ITEM
                 WHERE R.REL_RFM_ANO_FECHAMENTO = TO_CHAR(ADD_MONTHS(dataRef,-11),'YYYY') AND
                       R.REL_RFM_MES_FECHAMENTO = TO_CHAR(ADD_MONTHS(dataRef,-11),'MM') AND
                       E.REL_RFM_AGRUPAMENTO_ID = EST.REL_RFM_AGRUPAMENTO_ID AND
                       E.REL_RFM_COD_ITEM = 'ESTSP') /
                (SELECT R.REL_RMF_VL_ITEM
                  FROM TB_REL_RFM_RESU_FAT_MTMD R JOIN TB_REL_RFM_MTMD_ESTRUTURA E ON E.REL_RMF_SEQ_ITEM = R.REL_RMF_SEQ_ITEM
                 WHERE R.REL_RFM_ANO_FECHAMENTO = TO_CHAR(ADD_MONTHS(dataRef,-11),'YYYY') AND
                       R.REL_RFM_MES_FECHAMENTO = TO_CHAR(ADD_MONTHS(dataRef,-11),'MM') AND
                       E.REL_RFM_AGRUPAMENTO_ID = EST.REL_RFM_AGRUPAMENTO_ID AND
                       E.REL_RFM_COD_ITEM = 'CSSP'), 2)
       WHEN EST.REL_RFM_COD_ITEM = 'ICSCP' THEN
         ROUND((SELECT R.REL_RMF_VL_ITEM
                  FROM TB_REL_RFM_RESU_FAT_MTMD R JOIN TB_REL_RFM_MTMD_ESTRUTURA E ON E.REL_RMF_SEQ_ITEM = R.REL_RMF_SEQ_ITEM
                 WHERE R.REL_RFM_ANO_FECHAMENTO = TO_CHAR(ADD_MONTHS(dataRef,-11),'YYYY') AND
                       R.REL_RFM_MES_FECHAMENTO = TO_CHAR(ADD_MONTHS(dataRef,-11),'MM') AND
                       E.REL_RFM_AGRUPAMENTO_ID = EST.REL_RFM_AGRUPAMENTO_ID AND
                       E.REL_RFM_COD_ITEM = 'CSSP') /
                (SELECT R.REL_RMF_VL_ITEM
                  FROM TB_REL_RFM_RESU_FAT_MTMD R JOIN TB_REL_RFM_MTMD_ESTRUTURA E ON E.REL_RMF_SEQ_ITEM = R.REL_RMF_SEQ_ITEM
                 WHERE R.REL_RFM_ANO_FECHAMENTO = TO_CHAR(ADD_MONTHS(dataRef,-11),'YYYY') AND
                       R.REL_RFM_MES_FECHAMENTO = TO_CHAR(ADD_MONTHS(dataRef,-11),'MM') AND
                       E.REL_RFM_AGRUPAMENTO_ID = EST.REL_RFM_AGRUPAMENTO_ID AND
                       E.REL_RFM_COD_ITEM = 'CPSP'), 2)   
        WHEN EST.REL_RFM_COD_ITEM = 'IRTCS' THEN
         ROUND((SELECT R.REL_RMF_VL_ITEM
                  FROM TB_REL_RFM_RESU_FAT_MTMD R JOIN TB_REL_RFM_MTMD_ESTRUTURA E ON E.REL_RMF_SEQ_ITEM = R.REL_RMF_SEQ_ITEM
                 WHERE R.REL_RFM_ANO_FECHAMENTO = TO_CHAR(ADD_MONTHS(dataRef,-11),'YYYY') AND
                       R.REL_RFM_MES_FECHAMENTO = TO_CHAR(ADD_MONTHS(dataRef,-11),'MM') AND
                       E.REL_RFM_AGRUPAMENTO_ID = EST.REL_RFM_AGRUPAMENTO_ID AND
                       E.REL_RFM_COD_ITEM = 'RTOT') /
                (SELECT R.REL_RMF_VL_ITEM
                  FROM TB_REL_RFM_RESU_FAT_MTMD R JOIN TB_REL_RFM_MTMD_ESTRUTURA E ON E.REL_RMF_SEQ_ITEM = R.REL_RMF_SEQ_ITEM
                 WHERE R.REL_RFM_ANO_FECHAMENTO = TO_CHAR(ADD_MONTHS(dataRef,-11),'YYYY') AND
                       R.REL_RFM_MES_FECHAMENTO = TO_CHAR(ADD_MONTHS(dataRef,-11),'MM') AND
                       E.REL_RFM_AGRUPAMENTO_ID = EST.REL_RFM_AGRUPAMENTO_ID AND
                       E.REL_RFM_COD_ITEM = 'CSSP'), 2)                         
        ELSE    
          ROUND((SELECT R.REL_RMF_VL_ITEM
                   FROM TB_REL_RFM_RESU_FAT_MTMD R
                  WHERE R.REL_RFM_ANO_FECHAMENTO = TO_CHAR(ADD_MONTHS(dataRef,-11),'YYYY') AND
                        R.REL_RFM_MES_FECHAMENTO = TO_CHAR(ADD_MONTHS(dataRef,-11),'MM') AND
                        R.REL_RMF_SEQ_ITEM       = EST.REL_RMF_SEQ_ITEM))
  END MES_1*/
 