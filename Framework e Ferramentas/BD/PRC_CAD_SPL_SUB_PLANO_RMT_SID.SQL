  --PRC_CAD_SPL_SUB_PLANO_RMT_SID
  create or replace procedure PRC_CAD_SPL_SUB_PLANO_RMT_SID 
  (
     pCAD_SPL_ID IN TB_CAD_SPL_SUB_PLANO.CAD_SPL_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_SPL_SUB_PLANO_RMT_SID
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       CAD_SPL_ID,
       CAD_SPL_CD_SUB_PLANO,
       CAD_SPL_DS_SUB_PLANO,
       CAD_SPL_FL_STATUS,
       CAD_CNV_ID_CONVENIO
    FROM TB_CAD_SPL_SUB_PLANO
    WHERE
        CAD_SPL_ID = pCAD_SPL_ID;          
    io_cursor := v_cursor;
  end PRC_CAD_SPL_SUB_PLANO_RMT_SID;
