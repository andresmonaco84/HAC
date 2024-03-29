create or replace function FNC_FAT_TOTAL_SADT_POR_MEDICO
(
pFAT_COC_ID IN TB_FAT_COC_CONTA_CONSUMO.FAT_COC_ID%TYPE DEFAULT NULL,
pFAT_CCP_ID IN TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ID%TYPE DEFAULT NULL,

pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE DEFAULT NULL,
pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
pCAD_PLA_CD_TIPOPLANO IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
pCAD_PRO_ID_PROFISSIONAL IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%TYPE DEFAULT NULL,
pCAD_PAC_ID_PACIENTE IN TB_CAD_PAC_PACIENTE.CAD_PAC_ID_PACIENTE%TYPE DEFAULT NULL
)
---RETORNA A QTD. TOTAL R$ DO ATENDIMENTO OU INTERNAÇÃO
return NUMBER is Result NUMBER;
begin

SELECT          SUM(CCI.FAT_CCI_VL_FATURADO)  INTO RESULT

  FROM
                TB_FAT_COC_CONTA_CONSUMO    COC
  JOIN          TB_ATD_ATE_ATENDIMENTO      ATD
  ON            ATD.ATD_ATE_ID            = COC.ATD_ATE_ID
  JOIN          TB_FAT_CCP_CONTA_CONS_PARC  CCP
  ON            CCP.FAT_COC_ID            = COC.FAT_COC_ID
  AND           CCP.ATD_ATE_ID            = ATD.ATD_ATE_ID

  JOIN          TB_FAT_CCI_CONTA_CONSU_ITEM CCI
    ON            CCI.FAT_CCP_ID            = CCP.FAT_CCP_ID
  AND           CCI.FAT_COC_ID            = COC.FAT_COC_ID
  AND           CCI.ATD_ATE_ID            = ATD.ATD_ATE_ID
  AND           CCI.CAD_PAC_ID_PACIENTE = CCP.CAD_PAC_ID_PACIENTE

  JOIN          TB_CAD_PRD_PRODUTO          PRD
  ON            PRD.CAD_PRD_ID            = CCI.CAD_PRD_ID
  JOIN          TB_CAD_PRO_PROFISSIONAL     PRO
  ON            PRO.CAD_PRO_ID_PROFISSIONAL = CCI.CAD_PRO_ID_PROFISSIONAL
  JOIN          TB_CAD_PAC_PACIENTE         PAC
  ON            PAC.CAD_PAC_ID_PACIENTE   = COC.CAD_PAC_ID_PACIENTE
  JOIN          TB_CAD_PLA_PLANO            PLA
  ON            PLA.CAD_PLA_ID_PLANO      = PAC.CAD_PLA_ID_PLANO

  WHERE        (pFAT_COC_ID IS NULL OR COC.FAT_COC_ID = pFAT_COC_ID)
  AND          (PRD.CAD_TAP_TP_ATRIBUTO   = 'EXA')
  AND          (pFAT_CCP_ID IS NULL OR CCP.FAT_CCP_ID = pFAT_CCP_ID)
  AND          (pATD_ATE_ID IS NULL OR ATD.ATD_ATE_ID = pATD_ATE_ID)
  AND          (pCAD_UNI_ID_UNIDADE IS NULL OR ATD.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
  AND          (pCAD_PRO_ID_PROFISSIONAL IS NULL OR PRO.CAD_PRO_ID_PROFISSIONAL = pCAD_PRO_ID_PROFISSIONAL)
  AND          (pCAD_PLA_CD_TIPOPLANO IS NULL OR PLA.CAD_PLA_CD_TIPOPLANO = pCAD_PLA_CD_TIPOPLANO)
  AND          (pCAD_PAC_ID_PACIENTE IS NULL OR PAC.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE)
;

return(Result);
end FNC_FAT_TOTAL_SADT_POR_MEDICO;
