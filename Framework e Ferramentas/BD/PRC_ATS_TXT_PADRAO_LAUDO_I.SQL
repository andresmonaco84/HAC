create or replace procedure PRC_ATS_TXT_PADRAO_LAUDO_I
  (
     pNewIdt OUT integer,
     pATS_TPL_ID IN TB_ATS_TPL_TEXTO_PADRAO_LAUDO.ATS_TPL_ID%type default NULL,
     pATS_TPL_CD_CODIGO IN TB_ATS_TPL_TEXTO_PADRAO_LAUDO.ATS_TPL_CD_CODIGO%type,
     pATS_TPL_DS_DESCRICAO IN TB_ATS_TPL_TEXTO_PADRAO_LAUDO.ATS_TPL_DS_DESCRICAO%type,
     pATS_TPL_FL_STATUS IN TB_ATS_TPL_TEXTO_PADRAO_LAUDO.ATS_TPL_FL_STATUS%type,
     pATS_TPL_DT_ULTIMA_ATUALIZACAO IN TB_ATS_TPL_TEXTO_PADRAO_LAUDO.ATS_TPL_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_ATS_TPL_TEXTO_PADRAO_LAUDO.SEG_USU_ID_USUARIO%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATS_TPL_TXT_PADRAO_LAUDO_I
  *
  *    Data Criacao: 	04/11/2008		   Por: Fabiola Lopes
  *    Data Alteracao:	21/02/2009  Por: pedro - upper no codigo
  *
  *    Funcao: Inclui os dados do Textò Padrao do Laudo
  *
  *******************************************************************/
    lIdtRetorno integer;

  begin
    SELECT SEQ_ATS_TPL_01.NextVal INTO lIdtRetorno FROM DUAL;

    INSERT INTO TB_ATS_TPL_TEXTO_PADRAO_LAUDO
    (
       ATS_TPL_ID,
       ATS_TPL_CD_CODIGO,
       ATS_TPL_DS_DESCRICAO,
       ATS_TPL_FL_STATUS,
       ATS_TPL_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    )
    VALUES
    (
      lIdtRetorno,
	     UPPER(pATS_TPL_CD_CODIGO),
	     pATS_TPL_DS_DESCRICAO,
	     pATS_TPL_FL_STATUS,
	     pATS_TPL_DT_ULTIMA_ATUALIZACAO,
	     pSEG_USU_ID_USUARIO
    );
    pNewIdt := lIdtRetorno;
  end PRC_ATS_TXT_PADRAO_LAUDO_I;