CREATE OR REPLACE PROCEDURE "PRC_AGE_REL_PAL_CHAVE"
  (
     pDT_INICIO_CONSULTA in TB_AGE_AGD_AGENDA.AGE_AGD_DT_AGENDA%type,
     pDT_FIM_CONSULTA in TB_AGE_AGD_AGENDA.AGE_AGD_DT_AGENDA%type,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO in TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pTIS_CBO_CD_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%type default null,
     pCAD_PRO_ID_PROFISSIONAL in TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%type default null,
     pAGE_SAU_CD_ANDAR IN TB_AGE_SAU_SALA_UNID_AND.AGE_SAU_CD_ANDAR%type default null,
     pAGE_ESM_HR_INI_ESCALA in TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_HR_INI_ESCALA%type default null,
     pAGE_ESM_HR_FIM_ESCALA in TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_HR_FIM_ESCALA%type default null,
     pAGE_AGD_DS_OBSERVACAO in TB_AGE_AGD_AGENDA.AGE_AGD_DS_OBSERVACAO%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_REL_PAL_CHAVE
  *
  *    Data Criacao:  05/07/2013   Por: Pedro
  *    Funcao: Alimentar relatorio de Agendamentos por palavra-chave
  *
  *    Alteracao: Nao estava considerando a data de agendamento e 
  *    estava desconsiderando agendamentos cancelados e com registro 
  *    de falta do paciente.
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR

    SELECT
           UNI.CAD_UNI_DS_UNIDADE,
           LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO,
           AGD.AGE_AGD_HR_ATENDIMENTO,
           AGD.AGE_AGD_DT_ATENDIMENTO,
           AGD.AGE_AGD_CD_INTAMB,
           ESM.AGE_ESM_HR_INI_ESCALA,
           ESM.AGE_ESM_HR_FIM_ESCALA,
           SAU.AGE_SAU_CD_ANDAR,
           --FNC_SENHA_UTILIZADA(AGD.AGE_AGD_ID,NULL) SENHA,
           AGD.AGE_AGD_DS_OBSERVACAO,
           PES.CAD_PES_NM_PESSOA ,
           TO_CHAR(PES.CAD_PES_DT_NASCIMENTO,'dd/MM/yyyy') CAD_PES_DT_NASCIMENTO,
           PAC.CAD_PAC_NR_PRONTUARIO,
           CNV.CAD_CNV_CD_HAC_PRESTADOR,
           CNV.CAD_CNV_NM_FANTASIA,
           PLA.CAD_PLA_CD_PLANO_HAC,
           PAC.CAD_PAC_CD_CREDENCIAL,
           PAC.CAD_PAC_NM_TITULAR,
           --FNC_CAD_PES_TELEFONE_LISTA_S(PAC.CAD_PES_ID_PESSOA) TEL_PACIENTE,
           CBO.TIS_CBO_DS_CBOS_HAC,
           PRO.CAD_PRO_NR_CONSELHO,
           PRO.CAD_PRO_NM_NOME,
           
           PSO.CAD_PRO_NR_CONSELHO CAD_PRO_NR_CONSELHO_SOL,
           PSO.CAD_PRO_NM_NOME CAD_PRO_NM_NOME_SOL,
           USU.SEG_USU_DS_NOME
           

    FROM
           TB_CAD_PES_PESSOA PES,
           TB_CAD_PAC_PACIENTE PAC,
           TB_AGE_AGD_AGENDA AGD,
           TB_AGE_ESM_ESCALA_MEDICA ESM,
           TB_CAD_UNI_UNIDADE UNI,
           TB_CAD_LAT_LOCAL_ATENDIMENTO LAT,
           TB_AGE_SAU_SALA_UNID_AND SAU,
           TB_TIS_CBO_CBOS CBO,
           TB_CAD_PRO_PROFISSIONAL PRO,/*
           TB_AGE_PEE_PERIODO_ESCALA PEE,*/
           TB_AGE_AGG_AGENDA_GERADA AGG,
           TB_CAD_PLA_PLANO PLA,
           TB_CAD_CNV_CONVENIO CNV,
           TB_SEG_USU_USUARIO USU,
           TB_CAD_PRO_PROFISSIONAL PSO


    WHERE/*
           AGD.AGE_AGD_FL_STATUS <> 'C' AND AGD.AGE_AGD_FL_STATUS <> 'F'
    AND    */AGD.CAD_PAC_ID_PACIENTE         = PAC.CAD_PAC_ID_PACIENTE
    AND    AGD.CAD_PRO_ID_PROFISSIONALEXEC = PRO.CAD_PRO_ID_PROFISSIONAL
    AND    AGD.AGE_AGG_ID                  = AGG.AGE_AGG_ID
    AND    AGD.AGE_ESM_ID                  = ESM.AGE_ESM_ID
    AND    AGG.AGE_ESM_ID                  = ESM.AGE_ESM_ID

    AND    PAC.CAD_CNV_ID_CONVENIO         = CNV.CAD_CNV_ID_CONVENIO
    AND    PAC.CAD_PLA_ID_PLANO            = PLA.CAD_PLA_ID_PLANO

    AND    ESM.CAD_UNI_ID_UNIDADE           = UNI.CAD_UNI_ID_UNIDADE
    AND    ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO = LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO
    AND    ESM.TIS_CBO_CD_CBOS              = CBO.TIS_CBO_CD_CBOS
    AND    ESM.CAD_PRO_ID_PROFISSIONAL = PRO.CAD_PRO_ID_PROFISSIONAL
    AND    ESM.AGE_SAU_ID              = SAU.AGE_SAU_ID/*
    AND    ESM.AGE_PEE_ID              = PEE.AGE_PEE_ID*/

    AND    PES.CAD_PES_ID_PESSOA       = PAC.CAD_PES_ID_PESSOA

    AND    SAU.CAD_UNI_ID_UNIDADE      = UNI.CAD_UNI_ID_UNIDADE

    AND    USU.SEG_USU_ID_USUARIO      = AGG.SEG_USU_ID_USUARIO
    AND    AGD.CAD_PRO_ID_PROFISSIONALSOLIC =  PSO.CAD_PRO_ID_PROFISSIONAL(+)
--    AND AGD.AGE_AGD_DT_ATENDIMENTO BETWEEN PDT_INICIO_CONSULTA AND PDT_FIM_CONSULTA
    AND trunc(AGD.AGE_AGD_DT_AGENDA) BETWEEN pDT_INICIO_CONSULTA and pDT_FIM_CONSULTA
    AND upper(AGD.AGE_AGD_DS_OBSERVACAO) LIKE  '%' || upper(pAGE_AGD_DS_OBSERVACAO) || '%' 
--    and (pAGE_ESM_HR_INI_ESCALA is null or agd.age_agd_hr_atendimento between pAGE_ESM_HR_INI_ESCALA and pAGE_ESM_HR_FIM_ESCALA)
    and (pCAD_UNI_ID_UNIDADE IS NULL OR UNI.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE)
    and (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR lat.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
    and (pTIS_CBO_CD_CBOS is null or cbo.tis_cbo_cd_cbos = pTIS_CBO_CD_CBOS)
    and (pCAD_PRO_ID_PROFISSIONAL is null or agd.cad_pro_id_profissionalexec = pCAD_PRO_ID_PROFISSIONAL)
    and (pAGE_SAU_CD_ANDAR is null or sau.age_sau_cd_andar = pAGE_SAU_CD_ANDAR);
    io_cursor := v_cursor;
  end PRC_AGE_REL_PAL_CHAVE;
