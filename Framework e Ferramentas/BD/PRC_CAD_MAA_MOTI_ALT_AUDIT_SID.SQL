  --PRC_CAD_MAA_MOTI_ALT_AUDIT_SID
  create or replace procedure PRC_CAD_MAA_MOTI_ALT_AUDIT_SID 
  (
     pCAD_MAA_ID IN TB_CAD_MAA_MOTI_ALTERA_AUDIT.CAD_MAA_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_MAA_MOTI_ALT_AUDIT_SID
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
       CAD_MAA_ID,
       CAD_MAA_DS_DESCRICAO,
       CAD_MAA_FL_STATUS,
       CAD_MAA_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    FROM TB_CAD_MAA_MOTI_ALTERA_AUDIT
    WHERE
        CAD_MAA_ID = pCAD_MAA_ID;          
    io_cursor := v_cursor;
  end PRC_CAD_MAA_MOTI_ALT_AUDIT_SID;