create or replace procedure PRC_ASS_PEM_PESSOA_EMAIL_I
  (
     pNewIdt OUT integer,
     pASS_PEM_ID_PESSOA_EMAIL IN TB_ASS_PEM_PESSOA_EMAIL.ASS_PEM_ID_PESSOA_EMAIL%type default NULL,
     pASS_PEM_NM_FUNCAO IN TB_ASS_PEM_PESSOA_EMAIL.ASS_PEM_NM_FUNCAO%type,
     pASS_PEM_NM_EMAIL IN TB_ASS_PEM_PESSOA_EMAIL.ASS_PEM_NM_EMAIL%type,
     pASS_PEM_DT_ULTIMA_ATUALIZACAO IN TB_ASS_PEM_PESSOA_EMAIL.ASS_PEM_DT_ULTIMA_ATUALIZACAO%type DEFAULT SYSDATE,
     pSEG_USU_ID_USUARIO IN TB_ASS_PEM_PESSOA_EMAIL.SEG_USU_ID_USUARIO%type,
     pCAD_PES_ID_PESSOA IN TB_ASS_PEM_PESSOA_EMAIL.CAD_PES_ID_PESSOA%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PEM_PESSOA_EMAIL_I
  *
  *    Data Criacao:  11/06/2007   Por: Ricardo Costa
  *    Data Alteracao: data da alteração  Por: Nome do Analista
  *
  *    Funcao: Insere registro na tabela de associação de E-Mail: TB_ASS_PEM_PESSOA_EMAIL
  *
  *******************************************************************/

      lIdtRetorno integer;

  begin

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
      UPPER( pASS_PEM_NM_FUNCAO ),
      LOWER( pASS_PEM_NM_EMAIL ),
      pASS_PEM_DT_ULTIMA_ATUALIZACAO,
      pSEG_USU_ID_USUARIO,
      pCAD_PES_ID_PESSOA
    );

    pNewIdt := lIdtRetorno;

  end PRC_ASS_PEM_PESSOA_EMAIL_I;
/
