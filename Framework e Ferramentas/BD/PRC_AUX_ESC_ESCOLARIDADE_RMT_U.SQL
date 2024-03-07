

  --PRC_AUX_ESC_ESCOLARIDADE_U
  create or replace procedure PRC_AUX_ESC_ESCOLARIDADE_RMT_U
  (
     pAUX_ESC_CD_CODIGO IN TB_AUX_ESC_ESCOLARIDADE.AUX_ESC_CD_CODIGO%type,
     pAUX_ESC_NM_NOME IN TB_AUX_ESC_ESCOLARIDADE.AUX_ESC_NM_NOME%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUX_ESC_ESCOLARIDADE_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_AUX_ESC_ESCOLARIDADE
    SET	   
        AUX_ESC_NM_NOME = pAUX_ESC_NM_NOME 
    WHERE
        AUX_ESC_CD_CODIGO = pAUX_ESC_CD_CODIGO;	
  end PRC_AUX_ESC_ESCOLARIDADE_RMT_U;

