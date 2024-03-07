  create or replace procedure PRC_CONVENIO_PADRAO_S 
  (
     pCODCON IN BNF_CONVENIO_PADRAO.CODCON%type DEFAULT NULL,
     pCODTIPPAD IN BNF_CONVENIO_PADRAO.CODTIPPAD%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CONVENIO_PADRAO_S
  * 
  *    Data Criacao: 	22/01/2008   Por: Andrea Cazuca
  *    Funcao: Lista os Padrões do Plano 
  *
  *    Data Alteracao:  23/07/2008  Por: Andrea Cazuca
  *    Alteracao:  Foi retirado o campo CODTIPPAD e colocado o distinct
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT DISTINCT
       CODCON,
       CODPAD
    FROM BNF_CONVENIO_PADRAO
    WHERE
        (pCODCON is null OR CODCON = pCODCON) AND 
        (pCODTIPPAD is null OR CODTIPPAD = pCODTIPPAD);          
    io_cursor := v_cursor;
  end PRC_CONVENIO_PADRAO_S;
/
