 
  --PRC_GNOSTICO_S
  create or replace procedure PRC_GNOSTICO_S 
  (
     pCID IN BENEFICIARIO.DIAGNOSTICO.CID%type DEFAULT NULL,
     pDESCID IN BENEFICIARIO.DIAGNOSTICO.DESCID%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_GNOSTICO_S
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
       CID,
       DESCID
    FROM BENEFICIARIO.DIAGNOSTICO
    WHERE
        (pCID is null OR CID = pCID) AND 
        (pDESCID is null OR DESCID = pDESCID);          
    io_cursor := v_cursor;
  end PRC_GNOSTICO_S;
