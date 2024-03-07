 create or replace function FNC_INT_PAC_BAIXA_HR_PERMITIR
(
--  pATD_ATE_ID         IN TB_ATD_INA_INT_ALTA.ATD_ATE_ID%type,
  pATD_IML_DT_SAIDA   IN TB_ATD_IML_INT_MOV_LEITO.ATD_IML_DT_SAIDA%type,
  pATD_IML_HR_SAIDA   IN TB_ATD_IML_INT_MOV_LEITO.ATD_IML_HR_SAIDA%type,
  pMTMD_IGNORA_ALTA_HORAS_ATE IN TB_MTMD_MATMED_SETOR.MTMD_IGNORA_ALTA_HORAS_ATE%TYPE
)
/********************************************************************
*    Procedure: FNC_INT_PAC_BAIXA_HR_PERMITIR
*
*    Data Criacao:  06/05/2011   Por: André Souza Monaco
*
*    Funcao: Retorna (0 ou 1) para permissão de consumo, de acordo
*            se a hora da alta ultrapassou a qtd. de horas permitidas
*******************************************************************/
RETURN  NUMBER IS
retorno NUMBER;
begin
   -- TO_DATE(TO_CHAR(TO_DATE('6/5/2011'),'DD/MM/YYYY') || ' ' || TO_CHAR(LPAD(1517, 4, 0)), 'DD/MM/YY HH24MI')+24/24
   
   IF (pATD_IML_DT_SAIDA IS NOT NULL AND pATD_IML_HR_SAIDA IS NOT NULL AND NVL(pMTMD_IGNORA_ALTA_HORAS_ATE,0) > 0) THEN
     IF (SYSDATE <= TO_DATE(TO_CHAR(TO_DATE(pATD_IML_DT_SAIDA),'DD/MM/YYYY') || ' ' || TO_CHAR(LPAD(pATD_IML_HR_SAIDA, 4, 0)), 'DD/MM/YY HH24MI')+pMTMD_IGNORA_ALTA_HORAS_ATE/24) THEN
         retorno := 1;
     ELSE
         retorno := 0;
     END IF;
   ELSE
     retorno := 0; 
   END IF;

return(retorno);
end FNC_INT_PAC_BAIXA_HR_PERMITIR;
