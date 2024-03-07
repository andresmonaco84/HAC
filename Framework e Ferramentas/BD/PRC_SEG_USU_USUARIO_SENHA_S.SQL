  create or replace procedure PRC_SEG_USU_USUARIO_SENHA_S
  (
     pSEG_USU_ID_USUARIO IN TB_SEG_USU_USUARIO.SEG_USU_ID_USUARIO%type,     
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_USU_USUARIO_SENHA_S
  * 
  *    Data Criacao: 	03/03/2007             Por: Carlos Eduardo
  *    Data Alteracao:	                     Por: 
  *
  *    Funcao: Obtém a senha do usuário logado
  *
  *******************************************************************/    
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       SEG_USU_CD_PASSWORD
    FROM TB_SEG_USU_USUARIO
    WHERE
        (SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO);
    io_cursor := v_cursor;
  end PRC_SEG_USU_USUARIO_SENHA_S;
/
