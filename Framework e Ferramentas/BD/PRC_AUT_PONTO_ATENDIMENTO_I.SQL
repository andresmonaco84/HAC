

  --PRC_AUT_PONTO_ATENDIMENTO_I
  create or replace procedure PRC_AUT_PONTO_ATENDIMENTO_I
  (
     pCODCLI IN TB_AUT_PONTO_ATENDIMENTO.CODCLI%type,
     pCODUNI IN TB_AUT_PONTO_ATENDIMENTO.CODUNI%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_PONTO_ATENDIMENTO_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_AUT_PONTO_ATENDIMENTO
    (
       CODCLI,
       CODUNI
    )
    VALUES
    (
	     pCODCLI,
	     pCODUNI
    );
	
  end PRC_AUT_PONTO_ATENDIMENTO_I;

