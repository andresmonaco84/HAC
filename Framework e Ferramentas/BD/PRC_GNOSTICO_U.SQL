

  --PRC_GNOSTICO_U
  create or replace procedure PRC_GNOSTICO_U
  (
     pCID IN DIAGNOSTICO.CID%type,
     pDESCID IN DIAGNOSTICO.DESCID%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_GNOSTICO_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE DIAGNOSTICO
    SET	   
        DESCID = pDESCID 
    WHERE
        CID = pCID;	
  end PRC_GNOSTICO_U;

