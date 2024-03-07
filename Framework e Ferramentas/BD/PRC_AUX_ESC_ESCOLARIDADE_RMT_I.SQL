
---fim


  --PRC_AUX_ESC_ESCOLARIDADE_I
  create or replace procedure PRC_AUX_ESC_ESCOLARIDADE_RMT_I
  (
     pAUX_ESC_CD_CODIGO IN TB_AUX_ESC_ESCOLARIDADE.AUX_ESC_CD_CODIGO%type,
     pAUX_ESC_NM_NOME IN TB_AUX_ESC_ESCOLARIDADE.AUX_ESC_NM_NOME%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUX_ESC_ESCOLARIDADE_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_AUX_ESC_ESCOLARIDADE
    (
       AUX_ESC_CD_CODIGO,
       AUX_ESC_NM_NOME
    )
    VALUES
    (
	     pAUX_ESC_CD_CODIGO,
	     pAUX_ESC_NM_NOME
    );
	
  end PRC_AUX_ESC_ESCOLARIDADE_RMT_I;

