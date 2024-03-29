CREATE OR REPLACE PROCEDURE PRC_ATE_REL_SERV_MULHER
(
  pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE,
  pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
  pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%TYPE DEFAULT NULL,
  pCAD_SET_NR_ANDAR IN TB_CAD_SET_SETOR.CAD_SET_NR_ANDAR%TYPE DEFAULT NULL,
  pATD_DT_INICIO IN TB_SEG_HIU_HISTORICO_USUARIO.SEG_HIU_DT_ATUALIZACAO%TYPE,
  pATD_DT_FIM IN TB_SEG_HIU_HISTORICO_USUARIO.SEG_HIU_DT_ATUALIZACAO%TYPE,
  pATD_HR_INICIO  IN TB_SEG_HIU_HISTORICO_USUARIO.SEG_HIU_HR_ATUALIZACAO%TYPE DEFAULT NULL,
  pATD_HR_FIM IN TB_SEG_HIU_HISTORICO_USUARIO.SEG_HIU_HR_ATUALIZACAO%TYPE DEFAULT NULL,
  pTIS_CBO_CD_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%TYPE DEFAULT NULL,
  pCAD_PRO_ID_PROFISSIONAL IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%TYPE DEFAULT NULL,
  pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,
  pCAD_PLA_ID_PLANO IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE DEFAULT NULL,
  pTIS_TAT_CD_TPATENDIMENTO IN TB_TIS_TAT_TP_ATENDIMENTO.TIS_TAT_CD_TPATENDIMENTO%TYPE DEFAULT NULL,
  pCAD_PLA_CD_TIPOPLANO IN TB_CAD_PLA_PLANO.CAD_PLA_CD_TIPOPLANO%TYPE DEFAULT NULL,
  io_cursor OUT PKG_CURSOR.t_cursor
)
IS

 v_cursor PKG_CURSOR.t_cursor;
   begin
    OPEN v_cursor FOR

SELECT
 PES_UNI.CAD_PES_NM_PESSOA AS NOME_UNIDADE,
 LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
 SETOR.CAD_SET_DS_SETOR,
 SETOR.CAD_SET_NR_ANDAR,
 PLA.CAD_PLA_CD_PLANO_HAC,
 PLA.CAD_PLA_CD_TIPOPLANO,
 CNV.CAD_CNV_CD_HAC_PRESTADOR,
 PES_PRO.CAD_PES_NM_PESSOA AS NOME_PROFISSIONAL,
 PRO.CAD_PRO_NR_CONSELHO,
 ATD.ATD_ATE_ID,
 PES_PAC.CAD_PES_NM_PESSOA AS NOME_PACIENTE,
 PRD.CAD_PRD_CD_CODIGO,
 PRD.CAD_PRD_DS_DESCRICAO,
 FNC_TOT_ATD_CNV_PLA(PLA.CAD_PLA_ID_PLANO, CNV.CAD_CNV_ID_CONVENIO) AS TOTAL
FROM TB_ATD_ATE_ATENDIMENTO ATD
INNER JOIN TB_ASS_PAP_PAC_ATEN_PROC PAP
 ON PAP.ATD_ATE_ID = ATD.ATD_ATE_ID
INNER JOIN TB_CAD_PRD_PRODUTO PRD
 ON PRD.CAD_PRD_ID = PAP.CAD_PRD_ID
INNER JOIN TB_CAD_UNI_UNIDADE UNI
 ON ATD.CAD_UNI_ID_UNIDADE = UNI.CAD_UNI_ID_UNIDADE
 AND UNI.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
INNER JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO LAT
 ON ATD.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
 AND (LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
 OR pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL)
INNER JOIN TB_CAD_SET_SETOR SETOR
 ON ATD.CAD_SET_ID = SETOR.CAD_SET_ID
 AND (SETOR.CAD_SET_ID = pCAD_SET_ID OR pCAD_SET_ID IS NULL)
 AND (SETOR.CAD_SET_NR_ANDAR = pCAD_SET_NR_ANDAR OR pCAD_SET_NR_ANDAR IS NULL)
INNER JOIN TB_ASS_PAT_PACIEATEND PAT
 ON PAT.ATD_ATE_ID = ATD.ATD_ATE_ID
INNER JOIN TB_CAD_PAC_PACIENTE PAC
 ON PAC.CAD_PAC_ID_PACIENTE = PAT.CAD_PAC_ID_PACIENTE
INNER JOIN TB_CAD_CNV_CONVENIO CNV
 ON CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
 AND (CNV.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO OR pCAD_CNV_ID_CONVENIO IS NULL)
INNER JOIN TB_CAD_PLA_PLANO PLA
 ON PLA.CAD_PLA_ID_PLANO = PAC.CAD_PLA_ID_PLANO
 AND (PLA.CAD_PLA_ID_PLANO = pCAD_PLA_ID_PLANO OR pCAD_PLA_ID_PLANO IS NULL)
 AND (PLA.CAD_PLA_CD_TIPOPLANO = pCAD_PLA_CD_TIPOPLANO OR pCAD_PLA_CD_TIPOPLANO IS NULL)
INNER JOIN TB_TIS_CBO_CBOS CBO
 ON CBO.TIS_CBO_CD_CBOS = ATD.TIS_CBO_CD_CBOS
 AND (CBO.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS OR pTIS_CBO_CD_CBOS IS NULL)
INNER JOIN TB_CAD_PRO_PROFISSIONAL PRO
 ON PRO.CAD_PRO_ID_PROFISSIONAL = ATD.CAD_PRO_ID_PROF_EXEC
 AND (PRO.CAD_PRO_ID_PROFISSIONAL = pCAD_PRO_ID_PROFISSIONAL OR pCAD_PRO_ID_PROFISSIONAL IS NULL)
INNER JOIN TB_TIS_TAT_TP_ATENDIMENTO TAT
 ON TAT.TIS_TAT_CD_TPATENDIMENTO = ATD.TIS_TAT_CD_TPATENDIMENTO
 AND (TAT.TIS_TAT_CD_TPATENDIMENTO = pTIS_TAT_CD_TPATENDIMENTO OR pTIS_TAT_CD_TPATENDIMENTO IS NULL)
INNER JOIN TB_CAD_PES_PESSOA PES_PAC
 ON PES_PAC.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA
INNER JOIN TB_CAD_PES_PESSOA PES_UNI
 ON PES_UNI.CAD_PES_ID_PESSOA = UNI.CAD_PES_ID_PESSOA
INNER JOIN TB_CAD_PES_PESSOA PES_PRO
 ON PES_PRO.CAD_PES_ID_PESSOA = PRO.CAD_PES_ID_PESSOA
WHERE
 ((ATD.ATD_ATE_DT_ATENDIMENTO BETWEEN pATD_DT_INICIO AND pATD_DT_FIM)
 OR pATD_DT_INICIO IS NULL)
 AND ((ATD.ATD_ATE_HR_ATENDIMENTO >= pATD_HR_INICIO  AND ATD.ATD_ATE_HR_ATENDIMENTO <= pATD_HR_FIM)
 OR pATD_HR_INICIO  IS NULL);

io_cursor := v_cursor;

END   PRC_ATE_REL_SERV_MULHER;
