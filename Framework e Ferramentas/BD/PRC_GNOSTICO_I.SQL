

  --PRC_GNOSTICO_I
  create or replace procedure PRC_GNOSTICO_I
  (
     pCID IN DIAGNOSTICO.CID%type,
     pDESCID IN DIAGNOSTICO.DESCID%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_GNOSTICO_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO DIAGNOSTICO
    (
       CID,
       DESCID
    )
    VALUES
    (
	     pCID,
	     pDESCID
    );
	
  end PRC_GNOSTICO_I;

