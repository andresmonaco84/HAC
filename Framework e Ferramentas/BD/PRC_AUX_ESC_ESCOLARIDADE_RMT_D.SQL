

  --PRC_AUX_ESC_ESCOLARIDADE_D
  create or replace procedure PRC_AUX_ESC_ESCOLARIDADE_RMT_D 
  (
     pAUX_ESC_CD_CODIGO IN TB_AUX_ESC_ESCOLARIDADE.AUX_ESC_CD_CODIGO%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUX_ESC_ESCOLARIDADE_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AUX_ESC_ESCOLARIDADE
    WHERE  
        AUX_ESC_CD_CODIGO = pAUX_ESC_CD_CODIGO;	   
  end PRC_AUX_ESC_ESCOLARIDADE_RMT_D;
