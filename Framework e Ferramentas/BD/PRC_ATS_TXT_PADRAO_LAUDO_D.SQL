create or replace procedure PRC_ATS_TXT_PADRAO_LAUDO_D
  (
     pATS_TPL_ID IN TB_ATS_TPL_TEXTO_PADRAO_LAUDO.ATS_TPL_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATS_TPL_TXT_PADRAO_LAUDO_D
  * 
  *    Data Criacao: 	04/11/2008		   Por: Fabiola Lopes
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Exclui os dados do Textò Padrao do Laudo
  *
  *******************************************************************/    
  begin
    DELETE TB_ATS_TPL_TEXTO_PADRAO_LAUDO
    WHERE  
        ATS_TPL_ID = pATS_TPL_ID;	   
  end PRC_ATS_TXT_PADRAO_LAUDO_D;