  create or replace procedure PRC_CAD_PVE_PER_VALID_EXAME_S 
  (
     pCAD_PVE_ID IN TB_CAD_PVE_PER_VALID_EXAME.CAD_PVE_ID%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_PVE_PER_VALID_EXAME_S
  * 
  *    Data Criacao: 	26/02/2008   Por: Andrea Cazuca
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Lista as Validade de Exames
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       CAD_PVE_ID,
       CAD_PVE_DS_EXAME,
       CAD_PVE_QT_VALIDADE,
       CAD_PVE_UN_TEMPO,
       CAD_PVE_FL_STATUS
    FROM TB_CAD_PVE_PER_VALID_EXAME
    WHERE
        (pCAD_PVE_ID is null OR CAD_PVE_ID = pCAD_PVE_ID);          
    io_cursor := v_cursor;
  end PRC_CAD_PVE_PER_VALID_EXAME_S;
/
