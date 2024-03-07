create or replace procedure PRC_ATS_TXT_PADRAO_LAUDO_U
  (
     pATS_TPL_ID IN TB_ATS_TPL_TEXTO_PADRAO_LAUDO.ATS_TPL_ID%type,
     pATS_TPL_CD_CODIGO IN TB_ATS_TPL_TEXTO_PADRAO_LAUDO.ATS_TPL_CD_CODIGO%type,
     pATS_TPL_DS_DESCRICAO IN TB_ATS_TPL_TEXTO_PADRAO_LAUDO.ATS_TPL_DS_DESCRICAO%type,
     pATS_TPL_FL_STATUS IN TB_ATS_TPL_TEXTO_PADRAO_LAUDO.ATS_TPL_FL_STATUS%type,
     pATS_TPL_DT_ULTIMA_ATUALIZACAO IN TB_ATS_TPL_TEXTO_PADRAO_LAUDO.ATS_TPL_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_ATS_TPL_TEXTO_PADRAO_LAUDO.SEG_USU_ID_USUARIO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ATS_TPL_TXT_PADRAO_LAUDO_U
  * 
  *    Data Criacao: 	04/11/2008		   Por: Fabiola Lopes
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Data Alteracao:	28/02/2009  Por: Pedro
  *
  *    Funcao: Altera os dados do Textò Padrao do Laudo
  *
  *******************************************************************/  
  begin
    UPDATE TB_ATS_TPL_TEXTO_PADRAO_LAUDO
    SET	   
        ATS_TPL_CD_CODIGO = Upper(pATS_TPL_CD_CODIGO),
        ATS_TPL_DS_DESCRICAO = pATS_TPL_DS_DESCRICAO,
        ATS_TPL_FL_STATUS = pATS_TPL_FL_STATUS,
        ATS_TPL_DT_ULTIMA_ATUALIZACAO = pATS_TPL_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO 
    WHERE
      ATS_TPL_ID = pATS_TPL_ID;	
  end PRC_ATS_TXT_PADRAO_LAUDO_U;
