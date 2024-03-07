create or replace procedure PRC_AGS_REL_CIRURGIAS_CANC
  (
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type default null,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO in TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type default null,
     pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%type default null,
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%type default null,
     pCAD_PLA_ID_PLANO IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%type default null,
     pDT_INI_CONSULTA in TB_AGS_AGE_AGENDA_SADT.AGS_AGE_DT_ATENDIMENTO%type,
     pDT_FIM_CONSULTA in TB_AGS_AGE_AGENDA_SADT.AGS_AGE_DT_ATENDIMENTO%type,
     pHR_INI_CONSULTA in TB_AGS_AGE_AGENDA_SADT.AGS_AGE_HR_ATENDIMENTO%type default null,
     pHR_FIM_CONSULTA in TB_AGS_AGE_AGENDA_SADT.AGS_AGE_HR_ATENDIMENTO%type default null,
     pAGE_SAU_ID in tb_age_sau_sala_unid_and.age_sau_id%type default null,
     pAUX_EPP_CD_ESPECPROC in tb_aux_epp_especproc.aux_epp_cd_especproc%type default null,
     pCAD_PRD_ID  in tb_cad_prd_produto.cad_prd_id%type default null,
     pCAD_PRO_ID_PROFISSIONAL  IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%TYPE DEFAULT NULL,
     pAGS_AGE_CD_PROF_CIRURGIAO IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%TYPE DEFAULT NULL,
     pAGS_AGE_CD_PROF_ASSISTENTE IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%TYPE DEFAULT NULL,
     pAGS_AGE_CD_PROF_ANESTESIST IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGS_REL_CIRURGIAS_CANC
  *
  *    Data Criacao:  06/07/2010   Por: Pedro
  *    Data Alteracao: data da alteracao  Por: Nome do Analista
  *
  *    Funcao: Alimentar relatorio de Pacientes Agendados no SADT Centro Cirurgico
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin

OPEN v_cursor FOR
    SELECT DISTINCT
           PES_UNI.CAD_PES_NM_PESSOA NM_UNIDADE,
           LAT.CAD_LAT_DS_LOCAL_ATENDIMENTO ,
           EPP.AUX_EPP_DS_DESCRICAO ,
           SETOR.CAD_SET_DS_SETOR ,
           FNC_AGS_ULTIMO_SETOR_INT(AGS.LIB_LPR_ID) CAD_SET_CD_SETOR ,
           SAU.AGE_SAU_CD_ANDAR ,
           SAU.AGE_SAU_NR_SALA ,
           FNC_AGS_ULTIMO_LEITO(AGS.LIB_LPR_ID) ULTIMO_QLE,
           PRD.CAD_PRD_DS_DESCRICAO ,
           PRD.CAD_PRD_NM_MNEMONICO ,
           TO_CHAR(AGS.AGS_AGE_DT_ATENDIMENTO, 'DD/MM/YYYY') DT_AGENDAMENTO,
          -- AGS.AGS_AGE_HR_ATENDIMENTO HR_AGENDAMENTO,
           FNC_AGS_PRIMEIRO_HORARIO(AGS.LIB_LPR_ID,AGS.AGS_AGE_DT_ATENDIMENTO,AGS.CAD_PRD_ID,1) HR_AGENDAMENTO,
           PES_PAC.CAD_PES_NM_PESSOA NM_PACIENTE,
           FNC_RETORNA_TEL_PAC(PES_PAC.CAD_PES_ID_PESSOA) NR_TELEFONE,
           CNV.CAD_CNV_CD_HAC_PRESTADOR,
           PLA.CAD_PLA_CD_PLANO_HAC,
           AGS.AGS_AGE_CD_INTAMB,
           AGS.AGS_AGE_IN_ORIGEM_INTAMB,
           AGS.LIB_LPR_ID ID_LIBERACAO,
           PAC.CAD_PAC_NR_PRONTUARIO ,
           PES_PRO.CAD_PES_NM_PESSOA NM_PROFISSIONAL,

           AGS.AGS_AGE_DS_DUR_CIRURGIA,
           AGS.AGS_AGE_CD_PROF_CIRURGIAO,
           PES_PRO_CIRURGIAO.CAD_PES_NM_PESSOA CIRURGIAO,
           AGS.AGS_AGE_CD_PROF_ASSISTENTE,
           PES_PRO_ASSISTENTE.CAD_PES_NM_PESSOA ASSISTENTE,
           AGS.AGS_AGE_NM_INSTRUMENTADOR,
           AGS.AGS_AGE_CD_PROF_ANESTESIST,
           PES_PRO_ANESTESISTA.CAD_PES_NM_PESSOA ANESTESISTA,
           AGS.AGS_AGE_DS_INST_APAR_ESP,
           AGS.AGS_AGE_FL_ANESTESIA_OK,
           AGS.AGS_AGE_FL_TRANSFUSAO_OK,
           AGS.AGS_AGE_FL_CONGELACAO_OK,
           AGS.AGS_AGE_NM_CIRCULANTE,
           AGS.AGS_AGE_NM_ENFERM_CHEFE,
           AGS.CAD_TAN_TP_ANESTESIA,
           TAN.CAD_TAN_DS_ANESTESIA,
           AGS.AGS_AGE_FL_CIRUR_SUSP_OK,
           AGS.AGS_AGE_FL_CIRUR_ADIAD_OK

      FROM
           TB_AGS_AGC_AGENDA_CANC_SADT AGS
     INNER JOIN TB_AGS_ESM_ESCALA_SADT AGSESM
        ON AGSESM.AGS_ESM_ID = AGS.AGS_ESM_ID
     INNER JOIN TB_CAD_UNI_UNIDADE UNI
        ON UNI.CAD_UNI_ID_UNIDADE = AGSESM.CAD_UNI_ID_UNIDADE
     INNER JOIN TB_CAD_PES_PESSOA PES_UNI
        ON PES_UNI.CAD_PES_ID_PESSOA = UNI.CAD_PES_ID_PESSOA
     INNER JOIN TB_CAD_LAT_LOCAL_ATENDIMENTO LAT
        ON LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = AGSESM.CAD_LAT_ID_LOCAL_ATENDIMENTO
     INNER JOIN TB_CAD_SET_SETOR SETOR
        ON SETOR.CAD_SET_ID = AGSESM.CAD_SET_ID
     INNER JOIN TB_AGE_SAU_SALA_UNID_AND SAU
        ON SAU.AGE_SAU_ID = AGSESM.AGE_SAU_ID
     INNER JOIN TB_CAD_PRD_PRODUTO PRD
        ON PRD.CAD_PRD_ID = AGS.CAD_PRD_ID
     INNER JOIN TB_AUX_EPP_ESPECPROC EPP
        ON PRD.AUX_EPP_CD_ESPECPROC = EPP.AUX_EPP_CD_ESPECPROC
        AND PRD.TIS_MED_CD_TABELAMEDICA = EPP.TIS_MED_CD_TABELAMEDICA
        AND EPP.AUX_EPP_FL_AGENDA_CIRURG = 'S'
     INNER JOIN TB_CAD_PAC_PACIENTE PAC
        ON PAC.CAD_PAC_ID_PACIENTE = AGS.CAD_PAC_ID_PACIENTE
     INNER JOIN TB_CAD_PES_PESSOA PES_PAC
        ON PES_PAC.CAD_PES_ID_PESSOA = PAC.CAD_PES_ID_PESSOA
     INNER JOIN TB_CAD_CNV_CONVENIO CNV
        ON CNV.CAD_CNV_ID_CONVENIO = PAC.CAD_CNV_ID_CONVENIO
     INNER JOIN TB_CAD_PLA_PLANO PLA
        ON PLA.CAD_PLA_ID_PLANO = PAC.CAD_PLA_ID_PLANO
     LEFT JOIN TB_CAD_PRO_PROFISSIONAL PRO
        ON PRO.CAD_PRO_ID_PROFISSIONAL = AGSESM.CAD_PRO_ID_PROFISSIONAL
     LEFT JOIN TB_CAD_PES_PESSOA PES_PRO
        ON PES_PRO.CAD_PES_ID_PESSOA = PRO.CAD_PES_ID_PESSOA

     LEFT JOIN TB_CAD_PRO_PROFISSIONAL PRO_CIRURGIAO
        ON PRO_CIRURGIAO.CAD_PRO_ID_PROFISSIONAL = AGS.AGS_AGE_CD_PROF_CIRURGIAO
     LEFT JOIN TB_CAD_PES_PESSOA PES_PRO_CIRURGIAO
        ON PES_PRO_CIRURGIAO.CAD_PES_ID_PESSOA = PRO_CIRURGIAO.CAD_PES_ID_PESSOA

     LEFT JOIN TB_CAD_PRO_PROFISSIONAL PRO_ASSISTENTE
        ON PRO_ASSISTENTE.CAD_PRO_ID_PROFISSIONAL = AGS.AGS_AGE_CD_PROF_ASSISTENTE
     LEFT JOIN TB_CAD_PES_PESSOA PES_PRO_ASSISTENTE
        ON PES_PRO_ASSISTENTE.CAD_PES_ID_PESSOA = PRO_ASSISTENTE.CAD_PES_ID_PESSOA

     LEFT JOIN TB_CAD_PRO_PROFISSIONAL PRO_ANESTESISTA
        ON PRO_ANESTESISTA.CAD_PRO_ID_PROFISSIONAL = AGS.AGS_AGE_CD_PROF_ANESTESIST
     LEFT JOIN TB_CAD_PES_PESSOA PES_PRO_ANESTESISTA
        ON PES_PRO_ANESTESISTA.CAD_PES_ID_PESSOA = PRO_ANESTESISTA.CAD_PES_ID_PESSOA

     left JOIN TB_CAD_TAN_TIPO_ANESTESIA TAN
        ON TAN.CAD_TAN_TP_ANESTESIA = AGS.CAD_TAN_TP_ANESTESIA
    where
          (pCAD_UNI_ID_UNIDADE is null or agsesm.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE)
      and (pCAD_LAT_ID_LOCAL_ATENDIMENTO is null or agsesm.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
      and (pCAD_SET_ID is null or agsesm.cad_set_id = pCAD_SET_ID)
      and (pCAD_CNV_ID_CONVENIO is null or pac.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO)
      and (pCAD_PLA_ID_PLANO is null or pac.cad_pla_id_plano = pCAD_PLA_ID_PLANO)
      and (pAGE_SAU_ID is null or sau.age_sau_id = pAGE_SAU_ID)
      and (ags.ags_age_dt_atendimento between pDT_INI_CONSULTA and pDT_FIM_CONSULTA)
      and (pHR_INI_CONSULTA is null or ags.ags_age_hr_atendimento >= pHR_INI_CONSULTA)
      and (pHR_FIM_CONSULTA is null or ags.ags_age_hr_atendimento <= pHR_FIM_CONSULTA)
      and (pAUX_EPP_CD_ESPECPROC is null or epp.aux_epp_cd_especproc = pAUX_EPP_CD_ESPECPROC)
      and (pCAD_PRD_ID  is null or prd.cad_prd_id = pCAD_PRD_ID)
      and (pCAD_PRO_ID_PROFISSIONAL IS NULL OR PRO.CAD_PRO_ID_PROFISSIONAL = pCAD_PRO_ID_PROFISSIONAL)
      AND (pAGS_AGE_CD_PROF_CIRURGIAO IS NULL OR AGS.AGS_AGE_CD_PROF_CIRURGIAO = pAGS_AGE_CD_PROF_CIRURGIAO)
      AND (pAGS_AGE_CD_PROF_ASSISTENTE IS NULL OR AGS.AGS_AGE_CD_PROF_ASSISTENTE = pAGS_AGE_CD_PROF_ASSISTENTE)
      AND (pAGS_AGE_CD_PROF_ANESTESIST IS NULL OR AGS.AGS_AGE_CD_PROF_ANESTESIST = pAGS_AGE_CD_PROF_ANESTESIST)
    --  AND (AGS.AGS_AGE_FL_STATUS = 'C')
;
    io_cursor := v_cursor;

  end PRC_AGS_REL_CIRURGIAS_CANC;
/