create or replace function FNC_INT_TOTAL
(
 pATD_ATE_DT_ATENDIMENTO_INI in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE,
 pATD_ATE_DT_ATENDIMENTO_FIM in TB_ATD_ATE_ATENDIMENTO.ATD_ATE_DT_ATENDIMENTO%TYPE
)
--------------------------------------------------------------
-- DT. 18/11/09
-- RETORNA QTD TOTAL DE INT
--
--------------------------------------------------------------
return NUMBER is Result NUMBER;
begin


 SELECT  
         SUM(COUNT(DISTINCT ATD.ATD_ATE_ID)) OVER() INTO RESULT
  FROM
                TB_ATD_ATE_ATENDIMENTO    ATD
  JOIN          TB_ASS_PAT_PACIEATEND     PAT
  ON            PAT.ATD_ATE_ID          = ATD.ATD_ATE_ID
  JOIN          TB_CAD_PAC_PACIENTE       PAC
  ON            PAC.CAD_PAC_ID_PACIENTE = PAT.CAD_PAC_ID_PACIENTE
  JOIN          TB_CAD_CNV_CONVENIO       CNV
  ON            CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
  JOIN          TB_CAD_PLA_PLANO          PLA
  ON            PLA.CAD_PLA_ID_PLANO    = PAC.CAD_PLA_ID_PLANO
  JOIN          TB_ATD_AIC_ATE_INT_COMPL  AIC
  ON            AIC.ATD_ATE_ID          = ATD.ATD_ATE_ID
  WHERE
       (TRUNC(ATD.ATD_ATE_DT_ATENDIMENTO)  between pATD_ATE_DT_ATENDIMENTO_INI AND pATD_ATE_DT_ATENDIMENTO_FIM)
;

  return(Result);
end FNC_INT_TOTAL;
