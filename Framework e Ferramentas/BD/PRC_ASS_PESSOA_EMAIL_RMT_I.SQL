create or replace procedure PRC_ASS_PESSOA_EMAIL_RMT_I
  (
     pASS_PEM_ID_PESSOA_EMAIL IN TB_ASS_PEM_PESSOA_EMAIL.ASS_PEM_ID_PESSOA_EMAIL%type,
     pASS_PEM_NM_FUNCAO IN TB_ASS_PEM_PESSOA_EMAIL.ASS_PEM_NM_FUNCAO%type default NULL,
     pASS_PEM_NM_EMAIL IN TB_ASS_PEM_PESSOA_EMAIL.ASS_PEM_NM_EMAIL%type,
     pASS_PEM_DT_ULTIMA_ATUALIZACAO IN TB_ASS_PEM_PESSOA_EMAIL.ASS_PEM_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_PEM_PESSOA_EMAIL.SEG_USU_ID_USUARIO%type,
     pCAD_PES_ID_PESSOA IN TB_ASS_PEM_PESSOA_EMAIL.CAD_PES_ID_PESSOA%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PESSOA_EMAIL_RMT_I
  *
  *    Data Criacao:  data da  criac?o   Por: Nome do Analista
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: Descric?o da funcionalidade da Stored Procedure
  *
  *******************************************************************/
lIdtRetorno integer;


  BEGIN

  SELECT SEQ_ASS_PEM_01.NextVal INTO lIdtRetorno FROM DUAL;
  
    INSERT INTO TB_ASS_PEM_PESSOA_EMAIL
    (
       ASS_PEM_ID_PESSOA_EMAIL,
       ASS_PEM_NM_FUNCAO,
       ASS_PEM_NM_EMAIL,
       ASS_PEM_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_PES_ID_PESSOA
    )
    VALUES
    (
      lIdtRetorno,
      pASS_PEM_NM_FUNCAO,
      pASS_PEM_NM_EMAIL,
      pASS_PEM_DT_ULTIMA_ATUALIZACAO,
      pSEG_USU_ID_USUARIO,
      pCAD_PES_ID_PESSOA
    );

  end PRC_ASS_PESSOA_EMAIL_RMT_I;
 