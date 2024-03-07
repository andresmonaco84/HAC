create or replace procedure PRC_AUT_BNF_VALIDAR_CREDENC_S 
(
   pCODCON IN EMPRESA.CODCON%type,
   pCODEST IN BNF_BENEFICIARIO.CODEST%type,
   pCODBEN IN BNF_BENEFICIARIO.CODBEN%type,
   pCODSEQBEN IN BNF_BENEFICIARIO.CODSEQBEN%type,
   io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_AUT_BNF_VALIDAR_CREDENC_S
* 
*    Data Criacao:   13/07/2010   Por: Davi Silvestre M. dos Reis
*    Data Alteracao:  data da alteração  Por: Nome do Analista
*
*    Funcao: Validar existencia da credencial informada
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
    SELECT 
           b.codsitben as CODSITBEN,
           b.sitati as SITATI
      FROM BNF_BENEFICIARIO b
     WHERE
      (b.codcon = pCODCON) AND
      (b.codest = pCODEST) AND
      (b.codben = pCODBEN) AND
      (b.codseqben = pCODSEQBEN);
  io_cursor := v_cursor;
end PRC_AUT_BNF_VALIDAR_CREDENC_S;
