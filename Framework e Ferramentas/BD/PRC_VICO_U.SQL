

  --PRC_VICO_U
  create or replace procedure PRC_VICO_U
  (
     pCODSER IN SERVICO.CODSER%type,
     pNOMSER IN SERVICO.NOMSER%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_VICO_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE SERVICO
    SET	   
        NOMSER = pNOMSER 
    WHERE
        CODSER = pCODSER;	
  end PRC_VICO_U;

