create or replace function FNC_INT_PAC_OBITO
(
  pATD_ATE_ID IN TB_ATD_INA_INT_ALTA.ATD_ATE_ID%type
)
/********************************************************************
*    Procedure: FNC_INT_PAC_OBITO
*
*    Data Criacao:  14/10/2010   Por: André Souza Monaco
*
*    Funcao: Retorna (0 ou 1) se atendimento teve óbito
*******************************************************************/
RETURN  NUMBER IS
retorno NUMBER;
begin

     BEGIN

         SELECT 1
         INTO retorno
         FROM TB_ATD_INA_INT_ALTA INA, TB_TIS_MSI_MOTIVO_SAIDA_INT MSI
         WHERE INA.TIS_MSI_CD_MOTIVOSAIDAINT = MSI.TIS_MSI_CD_MOTIVOSAIDAINT AND
               INA.ATD_ATE_ID                = pATD_ATE_ID AND
               MSI.TIS_MSI_CD_TIPOALTA       = 4;

      EXCEPTION WHEN NO_DATA_FOUND THEN
         retorno := 0;
      END;

  return(retorno);
end FNC_INT_PAC_OBITO;
 