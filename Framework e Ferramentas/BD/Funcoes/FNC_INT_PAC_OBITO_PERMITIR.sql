CREATE OR REPLACE FUNCTION FNC_INT_PAC_OBITO_PERMITIR 
(
  pATD_ATE_ID         IN TB_ATD_INA_INT_ALTA.ATD_ATE_ID%type,
  pATD_IML_DT_SAIDA   IN TB_ATD_IML_INT_MOV_LEITO.ATD_IML_DT_SAIDA%type,
  pATD_IML_HR_SAIDA   IN TB_ATD_IML_INT_MOV_LEITO.ATD_IML_HR_SAIDA%type
)
/********************************************************************
*    Procedure: FNC_INT_PAC_OBITO_PERMITIR
*
*    Data Criacao:   14/10/2010   Por: André Souza Monaco
*    Data Alteração: 14/02/2012   Por: André Souza Monaco
*         Alteração: Não verifica mais se é o dia atual, e sim apenas as horas
*
*    Funcao: Retorna (0 ou 1) se atendimento com óbito pode
*            consumir ainda, de acordo com as horas permitidas
*******************************************************************/
RETURN  NUMBER IS
retorno NUMBER;
dataLimite DATE := FNC_JUNTAR_DATA_HORA(TRUNC(FNC_JUNTAR_DATA_HORA(pATD_IML_DT_SAIDA,pATD_IML_HR_SAIDA)+3/24),TO_CHAR(FNC_JUNTAR_DATA_HORA(pATD_IML_DT_SAIDA,pATD_IML_HR_SAIDA)+3/24,'HH24MI'));
begin

     --Permite o consumo até 3 horas depois do óbito
     IF (FNC_INT_PAC_OBITO(pATD_ATE_ID)        = 1 AND
         --TRUNC(pATD_IML_DT_SAIDA)              = TRUNC(SYSDATE) AND
         --TO_NUMBER(TO_CHAR(SYSDATE, 'HH24MI'))<= TO_NUMBER(TO_CHAR(TO_DATE(LPAD(pATD_IML_HR_SAIDA,4,'0'),'HH24MI')+3/24,'HH24MI'))) THEN
         SYSDATE <= dataLimite) THEN
         retorno := 1;
     ELSE
         retorno := 0;
     END IF;

return(retorno);
end FNC_INT_PAC_OBITO_PERMITIR;
