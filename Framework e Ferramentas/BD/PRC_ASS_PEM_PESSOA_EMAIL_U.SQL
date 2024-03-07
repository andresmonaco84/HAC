create or replace procedure PRC_ASS_PEM_PESSOA_EMAIL_U
  (
     pASS_PEM_ID_PESSOA_EMAIL IN TB_ASS_PEM_PESSOA_EMAIL.ASS_PEM_ID_PESSOA_EMAIL%type,
     pASS_PEM_NM_FUNCAO IN TB_ASS_PEM_PESSOA_EMAIL.ASS_PEM_NM_FUNCAO%type,
     pASS_PEM_NM_EMAIL IN TB_ASS_PEM_PESSOA_EMAIL.ASS_PEM_NM_EMAIL%type,
     pASS_PEM_DT_ULTIMA_ATUALIZACAO IN TB_ASS_PEM_PESSOA_EMAIL.ASS_PEM_DT_ULTIMA_ATUALIZACAO%type DEFAULT SYSDATE,
     pSEG_USU_ID_USUARIO IN TB_ASS_PEM_PESSOA_EMAIL.SEG_USU_ID_USUARIO%type,
     pCAD_PES_ID_PESSOA IN TB_ASS_PEM_PESSOA_EMAIL.CAD_PES_ID_PESSOA%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PEM_PESSOA_EMAIL_U
  *
  *    Data Criacao:  11/06/2007   Por: Ricardo Costa
  *    Data Alteracao: data da alteração  Por: Nome do Analista
  *
  *    Funcao: atualiza E-Mail associado a pessoa
  *
  *******************************************************************/
  begin
    UPDATE TB_ASS_PEM_PESSOA_EMAIL
    SET
        ASS_PEM_NM_FUNCAO = UPPER( pASS_PEM_NM_FUNCAO ),
        ASS_PEM_NM_EMAIL = LOWER( pASS_PEM_NM_EMAIL ),
        ASS_PEM_DT_ULTIMA_ATUALIZACAO = pASS_PEM_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        CAD_PES_ID_PESSOA = pCAD_PES_ID_PESSOA
    WHERE
        ASS_PEM_ID_PESSOA_EMAIL = pASS_PEM_ID_PESSOA_EMAIL;

  end PRC_ASS_PEM_PESSOA_EMAIL_U;
/
