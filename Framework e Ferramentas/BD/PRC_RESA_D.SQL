

  --PRC_RESA_D
  create or replace procedure PRC_RESA_D 
  (
     pCODCON IN EMPRESA.CODCON%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_RESA_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE EMPRESA
    WHERE  
        CODCON = pCODCON;	   
  end PRC_RESA_D;
