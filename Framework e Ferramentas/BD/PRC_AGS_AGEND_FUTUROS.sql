CREATE OR REPLACE PROCEDURE PRC_AGS_AGEND_FUTUROS
(
    pCAD_PAC_ID_PACIENTE IN TB_AGS_AGE_AGENDA_SADT.CAD_PAC_ID_PACIENTE%TYPE DEFAULT NULL,
    pCAD_PRD_ID IN TB_CAD_PRD_PRODUTO.CAD_PRD_ID%TYPE DEFAULT NULL,
    pCAD_PES_NM_PESSOA IN TB_CAD_PES_PESSOA.CAD_PES_NM_PESSOA%TYPE DEFAULT NULL,
    io_cursor OUT PKG_CURSOR.t_cursor
)
IS
 v_cursor PKG_CURSOR.t_cursor;
/*************************************************************
*  Data Alteracao: 26/04/2010     por: Pedro
*  Alteracao: add AND EPP.TIS_MED_CD_TABELAMEDICA = PRD.TIS_MED_CD_TABELAMEDICA
* 
***************************************************************/
BEGIN
OPEN v_cursor FOR
SELECT
  UNI.CAD_UNI_ID_UNIDADE,
  PES_UNI.CAD_PES_NM_PESSOA AS UNIDADE,
  LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
  PRO.CAD_PRO_ID_PROFISSIONAL,
  PES_PRO.CAD_PES_NM_PESSOA AS PROFISSIONAL,
  SAU.AGE_SAU_NR_SALA || ' / ' || SAU.AGE_SAU_CD_ANDAR AS SALA_ANDAR,
  PRD.CAD_PRD_DS_DESCRICAO,
  EPP.AUX_EPP_DS_DESCRICAO,
  AGE.AGS_AGE_DT_ATENDIMENTO,
  AGE.AGS_AGE_HR_ATENDIMENTO,
  PES_PAC.CAD_PES_NM_PESSOA AS NOMEBENEF
FROM TB_AGS_AGE_AGENDA_SADT AGE
 INNER JOIN TB_AGS_ESM_ESCALA_SADT ESM
  ON ESM.AGS_ESM_ID = AGE.AGS_ESM_ID
 INNER JOIN TB_CAD_UNI_UNIDADE UNI
  ON UNI.CAD_UNI_ID_UNIDADE = ESM.CAD_UNI_ID_UNIDADE
 INNER JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO LAT
  ON LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO
 INNER JOIN TB_CAD_PES_PESSOA PES_UNI
  ON PES_UNI.CAD_PES_ID_PESSOA = UNI.CAD_PES_ID_PESSOA
 LEFT JOIN TB_CAD_PRO_PROFISSIONAL PRO
  ON PRO.CAD_PRO_ID_PROFISSIONAL = ESM.CAD_PRO_ID_PROFISSIONAL
 LEFT JOIN TB_CAD_PES_PESSOA PES_PRO
  ON PES_PRO.CAD_PES_ID_PESSOA = PRO.CAD_PES_ID_PESSOA
 INNER JOIN TB_AGE_SAU_SALA_UNID_AND SAU
  ON SAU.AGE_SAU_ID = ESM.AGE_SAU_ID
 INNER JOIN TB_CAD_PRD_PRODUTO PRD
  ON PRD.CAD_PRD_ID = AGE.CAD_PRD_ID
 INNER JOIN TB_AUX_EPP_ESPECPROC EPP
  ON EPP.AUX_EPP_CD_ESPECPROC = PRD.AUX_EPP_CD_ESPECPROC
  AND EPP.TIS_MED_CD_TABELAMEDICA = PRD.TIS_MED_CD_TABELAMEDICA
 INNER JOIN TB_CAD_PAC_PACIENTE PAC_PAC
  ON PAC_PAC.CAD_PAC_ID_PACIENTE = AGE.CAD_PAC_ID_PACIENTE
 INNER JOIN TB_CAD_PES_PESSOA PES_PAC
  ON PES_PAC.CAD_PES_ID_PESSOA = PAC_PAC.CAD_PES_ID_PESSOA
  AND (pCAD_PES_NM_PESSOA IS NULL OR PES_PAC.CAD_PES_NM_PESSOA LIKE pCAD_PES_NM_PESSOA)
 WHERE
     AGE.AGS_AGE_DT_ATENDIMENTO >= TRUNC(SYSDATE)
 AND (pCAD_PAC_ID_PACIENTE IS NULL OR AGE.CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE)
 AND (pCAD_PRD_ID IS NULL OR AGE.CAD_PRD_ID = pCAD_PRD_ID);


 io_cursor := v_cursor;

END PRC_AGS_AGEND_FUTUROS;