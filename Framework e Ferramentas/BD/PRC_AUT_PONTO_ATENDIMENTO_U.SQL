

  --PRC_AUT_PONTO_ATENDIMENTO_U
  create or replace procedure PRC_AUT_PONTO_ATENDIMENTO_U
  (
     pCODCLI IN TB_AUT_PONTO_ATENDIMENTO.CODCLI%type,
     pCODUNI IN TB_AUT_PONTO_ATENDIMENTO.CODUNI%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_PONTO_ATENDIMENTO_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_AUT_PONTO_ATENDIMENTO
    SET	   
 
    WHERE
        CODCLI = pCODCLI
    AND CODUNI = pCODUNI;	
  end PRC_AUT_PONTO_ATENDIMENTO_U;

