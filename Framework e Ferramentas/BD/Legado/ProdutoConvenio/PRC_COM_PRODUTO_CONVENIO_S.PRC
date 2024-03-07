create or replace procedure PRC_COM_PRODUTO_CONVENIO_S
  (
     pCODCON IN COM_PRODUTO_CONVENIO.CODCON%type DEFAULT NULL,
     pPRODUTO IN COM_PRODUTO_CONVENIO.PRODUTO%type DEFAULT NULL,
     pDESCRICAO IN COM_PRODUTO_CONVENIO.DESCRICAO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_COM_PRODUTO_CONVENIO_S
  *
  *    Data Criacao:  01/02/2008         Por: Andrea Cazuca
  *    Data Alteracao: 08/07/2008       Por: Fabiola Lopes
  *
  *    Data Alteracao: 20/05/2009       Por: Pedro
  *    Alteração: nao estava mostrando subplanos com descricao em branco
  *    Funcao: Lista/Obtem o Sub Plano
  *
  *    Alterac?o: Incluido os upper
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
        CODCON,
        PRODUTO,
        DIGITO_INI,
        QTD_DIGITO,
        DESCRICAO
    FROM   COM_PRODUTO_CONVENIO
    WHERE  (pCODCON is null or upper(CODCON) = UPPER(pCODCON))
    AND    (pPRODUTO IS NULL OR upper(PRODUTO) = UPPER(pPRODUTO))
    AND    (pDESCRICAO IS NULL OR upper(DESCRICAO) like UPPER(pDESCRICAO))
    
Union 

SELECT
        CODCON,
        PRODUTO,
        DIGITO_INI,
        QTD_DIGITO,
        DESCRICAO
    FROM   COM_PRODUTO_CONVENIO
    WHERE  (pCODCON is null or upper(CODCON) = UPPER(pCODCON))
    AND    (pPRODUTO IS NULL OR upper(PRODUTO) = UPPER(pPRODUTO))
    AND    (DESCRICAO is null)
    ;
    io_cursor := v_cursor;

  end PRC_COM_PRODUTO_CONVENIO_S;

/
