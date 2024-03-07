

  --PRC_RESA_I
  create or replace procedure PRC_RESA_I
  (
     pCODCON IN EMPRESA.CODCON%type,
     pCODTIPEMP IN EMPRESA.CODTIPEMP%type default NULL,
     pDATCON IN EMPRESA.DATCON%type default NULL	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_RESA_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO EMPRESA
    (
       CODCON,
       CODTIPEMP,
       DATCON
    )
    VALUES
    (
	     pCODCON,
	     pCODTIPEMP,
	     pDATCON
    );
	
  end PRC_RESA_I;

