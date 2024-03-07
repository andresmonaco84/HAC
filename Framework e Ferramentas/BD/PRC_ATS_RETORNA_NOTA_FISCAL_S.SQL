CREATE OR REPLACE PROCEDURE PRC_ATS_RETORNA_NOTA_FISCAL_S
(
   pCODATEAMB IN TB_NOTA_FISCAL.CODATEAMB%TYPE,
   pNRONF OUT NUMERIC
)
IS
  /********************************************************************
  *    Procedure: PRC_ATS_RETORNA_NOTA_FISCAL_S
  *
  *    Data Criacao:   07/10/2008      Por: Fabiola Lopes
  *    Data Alteracao:  data da alteragco  Por: Nome do Analista
  *
  *    Funcao: Retorna o Numero da Nota Fiscal conforme a Liberacao
  *
  *******************************************************************/
BEGIN

   SELECT TNF.NRONF
     INTO pNRONF
     FROM TB_NOTA_FISCAL TNF
    WHERE TNF.CODATEAMB  = pCODATEAMB
      AND TNF.SITNF <> 'C';
   
    EXCEPTION
      when NO_DATA_FOUND then
           pNRONF := 0;
   
END PRC_ATS_RETORNA_NOTA_FISCAL_S;
