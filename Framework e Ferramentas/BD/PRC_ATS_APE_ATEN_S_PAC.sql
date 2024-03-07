CREATE OR REPLACE PROCEDURE PRC_ATS_APE_ATEN_S_PAC
(
     pATS_ATE_CD_INTLIB IN TB_ATS_APE_ATEN_PROCED_ECOCAR.ATS_ATE_CD_INTLIB%type,
     pATS_ATE_IN_INTLIB IN TB_ATS_APE_ATEN_PROCED_ECOCAR.ATS_ATE_IN_INTLIB%type,
     pAUX_EPP_CDESPECPROC IN TB_ATS_APE_ATEN_PROCED_ECOCAR.AUX_EPP_CDESPECPROC%type,
     pATS_ATE_ID IN TB_ATS_APE_ATEN_PROCED_ECOCAR.ATS_ATE_ID%type,
     pCAD_PRD_ID IN TB_ATS_APE_ATEN_PROCED_ECOCAR.CAD_PRD_ID%type,
     pTIS_MED_CD_TABELAMEDICA IN TB_ATS_APE_ATEN_PROCED_ECOCAR.TIS_MED_CD_TABELAMEDICA%type	,
     io_cursor OUT PKG_CURSOR.t_cursor
)
IS
/********************************************************************
  *    Procedure: PRC_ATS_APE_ATEN_S_PAC
  * 
  *    Data Criacao: 			   Por: 
  *    Data Alteracao:	27/03/2010  Por: Pedro
  *    Altera��o: pTIS_MED_CD_TABELAMEDICA
  *
  *    Funcao: 
  *
  *******************************************************************/  
  v_cursor PKG_CURSOR.t_cursor;

BEGIN

OPEN v_cursor FOR
SELECT
CNV.CAD_CNV_CD_HAC_PRESTADOR,
PES_CNV.CAD_PES_NM_PESSOA AS CONVENIO,
PLA.CAD_PLA_CD_PLANO_HAC,
PLA.CAD_PLA_NM_NOME_PLANO,
PES.CAD_PES_NM_PESSOA AS NOMEPACIENTE,
Floor(Months_Between(SYSDATE, PES.CAD_PES_DT_NASCIMENTO) / 12) IDADE,
PAC.CAD_PAC_NR_PRONTUARIO,
PES_PRO.CAD_PES_NM_PESSOA AS NOME_PROFISSIONAL,
PRO.CAD_PRO_NR_CONSELHO,
TLG.TIS_TLG_DS_TPLOGRADOURO || ' ' || ENDERECO.CAD_END_NM_LOGRADOURO || ' ' || ENDERECO.CAD_END_DS_NUMERO || ' ' || ENDERECO.CAD_END_DS_COMPLEMENTO AS ENDERECO
FROM TB_ATS_ATE_ATENDIMENTO_SADT ATS
 INNER JOIN TB_CAD_PAC_PACIENTE PAC
  ON ATS.CAD_PAC_ID_PACIENTE_INT = PAC.CAD_PAC_ID_PACIENTE
 INNER JOIN TB_CAD_PLA_PLANO PLA
  ON PLA.CAD_PLA_ID_PLANO = PAC.CAD_PLA_ID_PLANO
 INNER JOIN TB_CAD_PES_PESSOA PES
  ON PES.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA
 INNER JOIN TB_CAD_CNV_CONVENIO CNV
  ON CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
 INNER JOIN TB_CAD_PES_PESSOA PES_CNV
  ON PES_CNV.CAD_PES_ID_PESSOA = CNV.CAD_PES_ID_PESSOA
 INNER JOIN TB_ATS_APL_ATEN_PROCED_LAUDO APL
  ON  APL.CAD_PRD_ID = ATS.CAD_PRD_ID
  AND APL.ATS_ATE_CD_INTLIB = ATS.ATS_ATE_CD_INTLIB
  AND APL.ATS_ATE_IN_INTLIB = ATS.ATS_ATE_IN_INTLIB
  AND APL.AUX_EPP_CD_ESPECPROC = ATS.AUX_EPP_CD_ESPECPROC
  AND APL.ATS_ATE_ID = ATS.ATS_ATE_ID
  AND APL.TIS_MED_CD_TABELAMEDICA = ATS.TIS_MED_CD_TABELAMEDICA
 INNER JOIN TB_CAD_PRO_PROFISSIONAL PRO
  ON PRO.CAD_PRO_ID_PROFISSIONAL = APL.CAD_PRO_ID_PROF
 INNER JOIN TB_CAD_PES_PESSOA PES_PRO
  ON PES_PRO.CAD_PES_ID_PESSOA = PRO.CAD_PES_ID_PESSOA
 INNER JOIN TB_ATS_ARP_ATEN_RESULT_PROCED RES_PROCED
  ON  RES_PROCED.CAD_PRD_ID = ATS.CAD_PRD_ID
  AND RES_PROCED.ATS_ATE_CD_INTLIB = ATS.ATS_ATE_CD_INTLIB
  AND RES_PROCED.ATS_ATE_IN_INTLIB = ATS.ATS_ATE_IN_INTLIB
  AND RES_PROCED.ATS_EPP_CD_ESPECPROC = ATS.AUX_EPP_CD_ESPECPROC
  AND RES_PROCED.ATS_ATE_ID = ATS.ATS_ATE_ID
  AND RES_PROCED.TIS_MED_CD_TABELAMEDICA = ATS.TIS_MED_CD_TABELAMEDICA
 INNER JOIN TB_CAD_UNI_UNIDADE UNI
  ON UNI.CAD_UNI_ID_UNIDADE = RES_PROCED.CAD_UNI_ID_UNIDADE
-- INNER JOIN TB_ASS_PEE_PESSOA_ENDERECO PEE
--  ON PEE.CAD_PES_ID_PESSOA = UNI.CAD_PES_ID_PESSOA
 INNER JOIN TB_CAD_END_ENDERECO ENDERECO
  ON ENDERECO.CAD_PES_ID_PESSOA = UNI.CAD_PES_ID_PESSOA
  AND ENDERECO.AUX_TTE_CD_TP_TEL_END = 12
 INNER JOIN TB_TIS_TLG_TP_LOGRADOURO TLG
  ON TLG.TIS_TLG_CD_TPLOGRADOURO = ENDERECO.TIS_TLG_CD_TPLOGRADOURO
WHERE
    ATS.ATS_ATE_CD_INTLIB = pATS_ATE_CD_INTLIB
AND ATS.ATS_ATE_IN_INTLIB = pATS_ATE_IN_INTLIB
AND ATS.CAD_PRD_ID = pCAD_PRD_ID
AND ATS.AUX_EPP_CD_ESPECPROC = pAUX_EPP_CDESPECPROC
AND ATS.ATS_ATE_ID = pATS_ATE_ID
AND ATS.TIS_MED_CD_TABELAMEDICA = pTIS_MED_CD_TABELAMEDICA;

  io_cursor := v_cursor;

END PRC_ATS_APE_ATEN_S_PAC;
