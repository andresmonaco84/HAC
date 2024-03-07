create or replace procedure PRC_AUT_EMP_VALIDAR_PLANO_S 
(
   pCODCON IN EMPRESA.CODCON%type,
   io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_AUT_EMP_VALIDAR_PLANO_S
* 
*    Data Criacao:   13/07/2010   Por: Davi Silvestre M. dos Reis
*    Data Alteracao:  data da alteração  Por: Nome do Analista
*
*    Funcao: Retornar o status do plano, para o autorizador ACS
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
    SELECT e.codsitcon as CODSITCON
      FROM EMPRESA e
     WHERE
      (e.codcon = pCODCON);
  io_cursor := v_cursor;
end PRC_AUT_EMP_VALIDAR_PLANO_S;
