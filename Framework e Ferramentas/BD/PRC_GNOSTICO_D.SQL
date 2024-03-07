

  --PRC_GNOSTICO_D
  create or replace procedure PRC_GNOSTICO_D 
  (
     pCID IN DIAGNOSTICO.CID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_GNOSTICO_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE DIAGNOSTICO
    WHERE  
        CID = pCID;	   
  end PRC_GNOSTICO_D;
