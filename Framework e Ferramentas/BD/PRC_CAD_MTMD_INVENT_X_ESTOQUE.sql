create or replace procedure PRC_CAD_MTMD_INVENT_X_ESTOQUE
  (
     pCAD_MTMD_DT_INVENTARIO IN TB_CAD_MTMD_INVENTARIO.CAD_MTMD_DT_INVENTARIO%type,
     pCAD_MTMD_FILIAL_ID IN TB_CAD_MTMD_INVENTARIO.CAD_MTMD_FILIAL_ID%type,
     pCAD_SET_ID IN TB_CAD_MTMD_INVENTARIO.CAD_SET_ID%type,
     pCAD_MTMD_GRUPO_ID IN TB_MTMD_MOV_ESTOQUE_DIA.CAD_MTMD_GRUPO_ID%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_MTMD_INVENT_X_ESTOQUE
  *
  *    Data Criacao: 	28/09/2011   Por: Andre Souza Monaco
  *
  *    Funcao: lista o que tinha no estoque com o que foi digitado
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT  PRODUTO.CAD_MTMD_ID,
            PRODUTO.CAD_MTMD_GRUPO_ID,
            PRODUTO.CAD_MTMD_NOMEFANTASIA DESCRICAO,               
            GRUPO.CAD_MTMD_GRUPO_DESCRICAO,
            MAX(FNC_MTMD_PRECO_PERIODO(INV.CAD_MTMD_ID, 
                                   INV.CAD_MTMD_FILIAL_ID, 
                                   INV.CAD_MTMD_DT_INVENTARIO-30, 
                                   INV.CAD_MTMD_DT_INVENTARIO)) MTMD_CUSTO_MEDIO,
            SUM(INV.CAD_MTMD_QTDE_ANTERIOR) MTMD_SALDO_ANTERIOR,
            SUM((FNC_MTMD_PRECO_PERIODO(INV.CAD_MTMD_ID, 
                                      INV.CAD_MTMD_FILIAL_ID, 
                                      INV.CAD_MTMD_DT_INVENTARIO-30, 
                                      INV.CAD_MTMD_DT_INVENTARIO) * INV.CAD_MTMD_QTDE_ANTERIOR)) MTMD_VALOR_ANTERIOR,
            SUM(INV.CAD_MTMD_QTDE_FINAL) MTMD_SALDO_INVENTARIO,
            SUM((FNC_MTMD_PRECO_PERIODO(INV.CAD_MTMD_ID, 
                                      INV.CAD_MTMD_FILIAL_ID, 
                                      INV.CAD_MTMD_DT_INVENTARIO-30, 
                                      INV.CAD_MTMD_DT_INVENTARIO) * INV.CAD_MTMD_QTDE_FINAL)) MTMD_VALOR_INVENTARIO
  FROM TB_CAD_MTMD_INVENTARIO INV,
       TB_CAD_MTMD_MAT_MED    PRODUTO,
       TB_CAD_MTMD_GRUPO      GRUPO
  WHERE   PRODUTO.CAD_MTMD_ID = INV.CAD_MTMD_ID
      AND GRUPO.CAD_MTMD_GRUPO_ID = PRODUTO.CAD_MTMD_GRUPO_ID
      AND INV.CAD_MTMD_DT_INVENTARIO = TRUNC(pCAD_MTMD_DT_INVENTARIO)
      AND INV.CAD_MTMD_FILIAL_ID = pCAD_MTMD_FILIAL_ID
      AND INV.CAD_SET_ID = pCAD_SET_ID
      AND ( pCAD_MTMD_GRUPO_ID IS NULL OR PRODUTO.CAD_MTMD_GRUPO_ID = pCAD_MTMD_GRUPO_ID )
      --AND PRODUTO.CAD_MTMD_GRUPO_ID != 4 -- N?o trazer SND
  GROUP BY PRODUTO.CAD_MTMD_ID,
           PRODUTO.CAD_MTMD_GRUPO_ID,
           PRODUTO.CAD_MTMD_NOMEFANTASIA,
           GRUPO.CAD_MTMD_GRUPO_DESCRICAO
  ORDER BY PRODUTO.CAD_MTMD_NOMEFANTASIA;
    io_cursor := v_cursor;
  end PRC_CAD_MTMD_INVENT_X_ESTOQUE;