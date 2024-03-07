

  --PRC_CAD_CEC_CENTRO_CUSTO_S
  create or replace procedure PRC_CAD_CEC_CENTRO_CUSTO_S 
  (
     pCAD_CEC_ID_CCUSTO IN TB_CAD_CEC_CENTRO_CUSTO.CAD_CEC_ID_CCUSTO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_CEC_CENTRO_CUSTO_S
  * 
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT  
       CAD_CEC_ID_CCUSTO,
       CAD_CEC_CD_CCUSTO,
       CAD_CEC_DS_CCUSTO,
       CAD_CEC_FL_CCUSTO,
       CAD_CEC_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    FROM TB_CAD_CEC_CENTRO_CUSTO
    WHERE
        CAD_CEC_ID_CCUSTO = pCAD_CEC_ID_CCUSTO;          
    io_cursor := v_cursor;
  end PRC_CAD_CEC_CENTRO_CUSTO_S;

