  --PRC_CAD_MAA_MOTI_ALT_AUDIT_S
  create or replace procedure PRC_CAD_MAA_MOTI_ALT_AUDIT_S 
  (
     pCAD_MAA_ID IN TB_CAD_MAA_MOTI_ALTERA_AUDIT.CAD_MAA_ID%type DEFAULT NULL,
     pCAD_MAA_DS_DESCRICAO IN TB_CAD_MAA_MOTI_ALTERA_AUDIT.CAD_MAA_DS_DESCRICAO%type DEFAULT NULL,
     pCAD_MAA_FL_STATUS IN TB_CAD_MAA_MOTI_ALTERA_AUDIT.CAD_MAA_FL_STATUS%type DEFAULT NULL,
     pCAD_MAA_DT_ULTIMA_ATUALIZACAO IN TB_CAD_MAA_MOTI_ALTERA_AUDIT.CAD_MAA_DT_ULTIMA_ATUALIZACAO%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_CAD_MAA_MOTI_ALTERA_AUDIT.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_MAA_MOTI_ALT_AUDIT_S
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
        (pCAD_MAA_ID is null OR CAD_MAA_ID = pCAD_MAA_ID) AND 
        (pCAD_MAA_DS_DESCRICAO is null OR CAD_MAA_DS_DESCRICAO = pCAD_MAA_DS_DESCRICAO) AND 
        (pCAD_MAA_FL_STATUS is null OR CAD_MAA_FL_STATUS = pCAD_MAA_FL_STATUS) AND 
        (pCAD_MAA_DT_ULTIMA_ATUALIZACAO is null OR CAD_MAA_DT_ULTIMA_ATUALIZACAO = pCAD_MAA_DT_ULTIMA_ATUALIZACAO) AND 
        (pSEG_USU_ID_USUARIO is null OR SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO);          
    io_cursor := v_cursor;
  end PRC_CAD_MAA_MOTI_ALT_AUDIT_S;