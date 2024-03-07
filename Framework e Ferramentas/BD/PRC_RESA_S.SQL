 
  --PRC_RESA_S
  create or replace procedure PRC_RESA_S 
  (
     pCODCON IN EMPRESA.CODCON%type DEFAULT NULL,
     pCODTIPEMP IN EMPRESA.CODTIPEMP%type DEFAULT NULL,
     pDATCON IN EMPRESA.DATCON%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_RESA_S
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       CODCON,
       CODTIPEMP,
       DATCON
    FROM EMPRESA
    WHERE
        (pCODCON is null OR CODCON = pCODCON) AND 
        (pCODTIPEMP is null OR CODTIPEMP = pCODTIPEMP) AND 
        (pDATCON is null OR DATCON = pDATCON);          
    io_cursor := v_cursor;
  end PRC_RESA_S;
