CREATE OR REPLACE PROCEDURE PRC_CAD_MTMD_OBSOLETOS_R
  (
     pCAD_MTMD_FILIAL_ID IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_FILIAL_ID%type DEFAULT NULL,
     pMTMD_MOV_DATA_DE   IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_MOV_DATA%type DEFAULT NULL,
     pMTMD_MOV_DATA_ATE  IN TB_MTMD_MOV_ESTOQUE_DIA.MTMD_MOV_DATA%type DEFAULT NULL,
     pCAD_MTMD_GRUPO_ID  IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_GRUPO_ID%type DEFAULT NULL,
     pCAD_MTMD_FL_FATURADO IN TB_CAD_MTMD_MAT_MED.CAD_MTMD_FL_FATURADO%type DEFAULT NULL,
     pSEM_ESTOQUE        IN NUMBER, --0 ou 1
     io_cursor           OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************************
  *    Procedure: PRC_CAD_MTMD_OBSOLETOS_R
  *
  *    Data Criacao: 	 17/10/2013   Por: André Souza Monaco
  *    Data Alteracao: --           Por: --
  *
  *    Funcao: Query p/ Relatório de produtos obsoletos
  *
  *********************************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  dataRef DATE;
  begin
    IF (NVL(pSEM_ESTOQUE,0) = 0) THEN
        dataRef := TO_DATE(TO_CHAR('01/' || TO_CHAR(pMTMD_MOV_DATA_ATE, 'MM') || '/' || TO_CHAR(pMTMD_MOV_DATA_ATE, 'YYYY') ), 'DD/MM/YYYY');
        OPEN v_cursor FOR
        SELECT T.CAD_MTMD_ID, M.CAD_MTMD_CODMNE,
               M.CAD_MTMD_NOMEFANTASIA,
               T.MTMD_CUSTO_MEDIO_ATUAL,
               T.MTMD_SALDO_ATUAL,
               T.MTMD_VALOR_ATUAL
        FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA T JOIN
             TB_CAD_MTMD_MAT_MED M ON M.CAD_MTMD_ID = T.CAD_MTMD_ID
        WHERE T.MTMD_MOV_DATA = dataRef
        AND (T.CAD_MTMD_TPMOV_ID = 0 AND T.CAD_MTMD_SUBTP_ID = 0)
        AND T.MTMD_VALOR_ATUAL > 0
        AND T.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
        AND T.CAD_MTMD_GRUPO_ID = pCAD_MTMD_GRUPO_ID
        AND (T.CAD_MTMD_ID NOT IN (SELECT CAD_MTMD_ID
                                        FROM SGS.TB_MTMD_MOV_ESTOQUE_DIA
                                       WHERE MTMD_MOV_DATA >= pMTMD_MOV_DATA_DE
                                         AND MTMD_MOV_DATA <= pMTMD_MOV_DATA_ATE
                                         AND (CAD_MTMD_TPMOV_ID = 2 AND CAD_MTMD_SUBTP_ID NOT IN (6)) --Não inserir Perdas/Quebras
                                         AND CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
                                         AND CAD_MTMD_GRUPO_ID = pCAD_MTMD_GRUPO_ID
                                         AND CAD_MTMD_ID = T.CAD_MTMD_ID
                                         AND MTMD_VALOR_SAIDA > 0))
        ORDER BY M.CAD_MTMD_NOMEFANTASIA;
    ELSE
        OPEN v_cursor FOR
        SELECT M.CAD_MTMD_ID, M.CAD_MTMD_CODMNE,
               M.CAD_MTMD_NOMEFANTASIA,
               DECODE(FNC_MTMD_PRECO_UNITARIO(M.CAD_MTMD_ID, 1), 0,
                      FNC_MTMD_PRECO_UNITARIO(M.CAD_MTMD_ID, 2)) MTMD_CUSTO_MEDIO_ATUAL,
               0 MTMD_SALDO_ATUAL,
               0 MTMD_VALOR_ATUAL
         FROM TB_CAD_MTMD_MAT_MED M
        WHERE M.CAD_MTMD_GRUPO_ID = pCAD_MTMD_GRUPO_ID AND
              M.CAD_MTMD_FL_ATIVO = 1 AND
              (pCAD_MTMD_FL_FATURADO IS NULL OR NVL(M.CAD_MTMD_FL_FATURADO, 0) = pCAD_MTMD_FL_FATURADO) AND
              --FNC_MTMD_ESTOQUE_CONTABIL(M.CAD_MTMD_ID, pCAD_MTMD_FILIAL_ID) = 0 AND
              (FNC_MTMD_ESTOQUE_CONTABIL(M.CAD_MTMD_ID, 1) +
               FNC_MTMD_ESTOQUE_CONTABIL(M.CAD_MTMD_ID, 2)) = 0 AND
              (SELECT NVL(SUM(H.MTMD_PRECO_UNITARIO), 0)
                 FROM TB_MTMD_HISTORICO_NOTA_FISCAL H
                WHERE H.CAD_MTMD_ID = M.CAD_MTMD_ID AND
                      --H.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID AND
                      H.MTMD_DATA_PRC_MEDIO >= SYSDATE-183) = 0
        ORDER BY M.CAD_MTMD_NOMEFANTASIA;
    END IF;
    io_cursor := v_cursor;
  end PRC_CAD_MTMD_OBSOLETOS_R;