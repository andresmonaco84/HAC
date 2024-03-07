

  --PRC_VICO_D
  create or replace procedure PRC_VICO_D 
  (
     pCODSER IN SERVICO.CODSER%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_VICO_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE SERVICO
    WHERE  
        CODSER = pCODSER;	   
  end PRC_VICO_D;
