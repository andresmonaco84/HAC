 --PRC_CAD_PSU_PLANO_SENHA_UTIL_S
  create or replace procedure PRC_CAD_PSU_PLANO_SENHA_S 
  (
     pCAD_PSU_NR_SENHA_UTILIZADA IN TB_CAD_PSU_PLANO_SENHA_UTIL.CAD_PSU_NR_SENHA_UTILIZADA%type DEFAULT NULL,
     pAGE_AGD_ID IN TB_CAD_PSU_PLANO_SENHA_UTIL.AGE_AGD_ID%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_PSU_PLANO_SENHA_UTIL_S
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
       CAD_PSU_ID,
       CAD_PSU_NR_SENHA_UTILIZADA,
       CAD_PSU_FL_STATUS,
       CAD_PSU_DT_ULTIMA_ATUALIZACAO,
       CAD_PLA_CD_PLANO,
       AGE_AGD_ID,
       SEG_USU_ID_USUARIO
    FROM TB_CAD_PSU_PLANO_SENHA_UTIL
    WHERE
        (pCAD_PSU_NR_SENHA_UTILIZADA is null OR CAD_PSU_NR_SENHA_UTILIZADA = pCAD_PSU_NR_SENHA_UTILIZADA)
    AND
        (pAGE_AGD_ID IS NULL OR AGE_AGD_ID = pAGE_AGD_ID);
    io_cursor := v_cursor;
  end PRC_CAD_PSU_PLANO_SENHA_S;
/
