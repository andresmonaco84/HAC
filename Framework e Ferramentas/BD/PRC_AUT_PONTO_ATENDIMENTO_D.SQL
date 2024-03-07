

  --PRC_AUT_PONTO_ATENDIMENTO_D
  create or replace procedure PRC_AUT_PONTO_ATENDIMENTO_D 
  (
     pCODCLI IN TB_AUT_PONTO_ATENDIMENTO.CODCLI%type,
     pCODUNI IN TB_AUT_PONTO_ATENDIMENTO.CODUNI%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUT_PONTO_ATENDIMENTO_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AUT_PONTO_ATENDIMENTO
    WHERE  
        CODCLI = pCODCLI
    AND CODUNI = pCODUNI;	   
  end PRC_AUT_PONTO_ATENDIMENTO_D;
