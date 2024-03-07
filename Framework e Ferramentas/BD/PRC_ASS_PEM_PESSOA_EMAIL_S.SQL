create or replace procedure PRC_ASS_PEM_PESSOA_EMAIL_S
  (
     pCAD_PES_ID_PESSOA IN TB_ASS_PEM_PESSOA_EMAIL.CAD_PES_ID_PESSOA%type DEFAULT NULL,
     pASS_PEM_ID_PESSOA_EMAIL IN TB_ASS_PEM_PESSOA_EMAIL.ASS_PEM_ID_PESSOA_EMAIL%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PEM_PESSOA_EMAIL_S
  *
  *    Data Criacao:  11/06/2007  Por: Ricardo Costa
  *    Data Alteracao: data da alteração  Por: Nome do Analista
  *
  *    Funcao: Lista registros dos E-Mails Associados, Lista Por Pessoa ( Todos Associados ) ou Obtem 1 único resgistro da pessoa
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    IF pASS_PEM_ID_PESSOA_EMAIL IS NULL THEN
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
        (pCAD_PES_ID_PESSOA is null OR CAD_PES_ID_PESSOA = pCAD_PES_ID_PESSOA);
    ELSE
        OPEN v_cursor FOR
        SELECT
          ASS_PEM_ID_PESSOA_EMAIL,
          ASS_PEM_NM_FUNCAO,
          ASS_PEM_NM_EMAIL,
          ASS_PEM_DT_ULTIMA_ATUALIZACAO,
          SEG_USU_ID_USUARIO,
          CAD_PES_ID_PESSOA
       FROM TB_ASS_PEM_PESSOA_EMAIL
       WHERE ASS_PEM_ID_PESSOA_EMAIL = pASS_PEM_ID_PESSOA_EMAIL;    
    END IF;
    io_cursor := v_cursor;
  end PRC_ASS_PEM_PESSOA_EMAIL_S;
/
