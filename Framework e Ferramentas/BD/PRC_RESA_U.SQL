

  --PRC_RESA_U
  create or replace procedure PRC_RESA_U
  (
     pCODCON IN EMPRESA.CODCON%type,
     pCODTIPEMP IN EMPRESA.CODTIPEMP%type default NULL,
     pDATCON IN EMPRESA.DATCON%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_RESA_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE EMPRESA
    SET	   
        CODTIPEMP = pCODTIPEMP,
        DATCON = pDATCON 
    WHERE
        CODCON = pCODCON;	
  end PRC_RESA_U;

