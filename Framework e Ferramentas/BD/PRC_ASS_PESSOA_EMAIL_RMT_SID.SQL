  --PRC_ASS_PESSOA_EMAIL_RMT_SID
  create or replace procedure PRC_ASS_PESSOA_EMAIL_RMT_SID 
  (
     pASS_PEM_ID_PESSOA_EMAIL IN TB_ASS_PEM_PESSOA_EMAIL.ASS_PEM_ID_PESSOA_EMAIL%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PESSOA_EMAIL_RMT_SID
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
       ASS_PEM_ID_PESSOA_EMAIL,
       ASS_PEM_NM_FUNCAO,
       ASS_PEM_NM_EMAIL,
       ASS_PEM_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_PES_ID_PESSOA
    FROM TB_ASS_PEM_PESSOA_EMAIL
    WHERE
        ASS_PEM_ID_PESSOA_EMAIL = pASS_PEM_ID_PESSOA_EMAIL;          
    io_cursor := v_cursor;
  end PRC_ASS_PESSOA_EMAIL_RMT_SID;
