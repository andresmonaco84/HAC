create or replace procedure PRC_AGESADT_REL_ESCALAS
  (
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO in TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%type,
     pAGE_SAU_ID IN tb_age_sau_sala_unid_and.Age_Sau_Id%type default null,    
     pCAD_PRO_ID_PROFISSIONAL IN tb_cad_pro_profissional.cad_pro_id_profissional%type default null,
     pAGS_ESM_FL_STATUS IN tb_ags_esm_escala_sadt.Ags_Esm_Fl_Status%type default null,   
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGESADT_REL_AGENDADOS
  *
  *    Data Criacao:  29/10/2008   Por: Pedro H. A. de Carvalho
  *    Data Alteracao: data da alteracao  Por: Nome do Analista
  *
  *    Funcao: Alimentar relatorio de Escalas Medicas SADT
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    
select distinct pes_uni.cad_pes_nm_pessoa UNIDADE,
  lat.cad_lat_ds_local_atendimento LOCAL_ATENDIMENTO,
  setor.cad_set_ds_setor SETOR,
  sau.age_sau_nr_sala SALA,
  pes.cad_pes_nm_pessoa profissional,
      pro.cad_pro_nr_conselho nr_conselho,
  CASE WHEN ESM.AGS_ESM_NR_DIA_SEMANA = 1 THEN 'SEG'
  WHEN ESM.AGS_ESM_NR_DIA_SEMANA = 2 THEN 'TER'
  WHEN ESM.AGS_ESM_NR_DIA_SEMANA = 3 THEN 'QUA'
  WHEN ESM.AGS_ESM_NR_DIA_SEMANA = 4 THEN 'QUI'
  WHEN ESM.AGS_ESM_NR_DIA_SEMANA = 5 THEN 'SEX'
  WHEN ESM.AGS_ESM_NR_DIA_SEMANA = 6 THEN 'SAB'
  ELSE NULL
  END DIA_SEMANA,
  ESM.AGS_ESM_CD_PERIODO PERIODO,
  ESM.AGS_ESM_DT_INI_ESCALA DATA_INICIO,
  ESM.AGS_ESM_DT_FIM_ESCALA DATA_FIM,
  ESM.AGS_ESM_HR_INI_ESCALA HORA_INICIO,
  ESM.AGS_ESM_HR_FIM_ESCALA HORA_FIM,
  ESM.AGS_ESM_QT_SEMANAS_CRIACAO QTD_SEMANAS_CRIACAO,
  ESM.AGS_ESM_QT_DIAS_INTERVALO QTD_DIAS_INTERVALO,
  ESM.AGS_ESM_QT_AGE_PERM_HORA QTD_AGENDAMENTO_PERM_HORA,
  decode(Upper(ESM.AGS_ESM_FL_PERM_ENCAIXE_OK), 'S','Sim',
                                            'N','Não')PERMITE_ENCAIXE,
  ESM.AGS_ESM_QT_ENCAIXE_HORA QTD_ENCAIXE_PERM_HORA,
  ESM.AGS_ESM_QT_MAX_ENCAIXE QTD_MAX_ENCAIXE,
  decode(Upper(ESM.AGS_ESM_FL_PERM_SP_OK), 'S','Sim',
                                            'N','Não')PERMITE_SP,
  ESM.AGS_ESM_QT_SP_HORA QTD_SP_POR_HORA,
  decode(Upper(ESM.AGS_ESM_FL_AGENDAGERADA_OK), 'S','Sim',
                                            'N','Não')AGENDA_GERADA,
  
  decode(Upper(ESM.AGS_ESM_FL_STATUS),'A', 'Ativa', 'I', 'Inativa',
  'S', 'Suspensa','E', 'Excluida', 'P','Ativa')STATUS,
  ESM.AGS_ESM_DT_CRIACAO_ESCALA DATA_CRIACAO

    from tb_ags_esm_escala_sadt esm,
      tb_cad_uni_unidade uni,
      tb_cad_pes_pessoa pes_uni,
      tb_cad_lat_local_atendimento lat,
      tb_cad_set_setor setor,
      tb_age_sau_sala_unid_and sau,
      tb_cad_pes_pessoa pes,
      tb_cad_pro_profissional pro,
      tb_tis_cbo_cbos cbo

    WHERE UNI.CAD_UNI_ID_UNIDADE = ESM.CAD_UNI_ID_UNIDADE
    AND PES_UNI.CAD_PES_ID_PESSOA = UNI.CAD_PES_ID_PESSOA
    AND LAT.CAD_LAT_ID_LOCAL_ATENDIMENTO = ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO
    AND SETOR.CAD_SET_ID = ESM.CAD_SET_ID
    AND SAU.AGE_SAU_ID = ESM.AGE_SAU_ID
    AND PRO.CAD_PRO_ID_PROFISSIONAL = ESM.CAD_PRO_ID_PROFISSIONAL
     AND pro.cad_pes_id_pessoa = pes.cad_pes_id_pessoa  

    AND ESM.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
    and ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
    AND ESM.CAD_SET_ID = pCAD_SET_ID
    
    AND (pAGE_SAU_ID is null or ESM.AGE_SAU_ID = pAGE_SAU_ID)   
    AND (pCAD_PRO_ID_PROFISSIONAL is null or ESM.CAD_PRO_ID_PROFISSIONAL = pCAD_PRO_ID_PROFISSIONAL)
    AND (pAGS_ESM_FL_STATUS IS NULL OR ESM.AGS_ESM_FL_STATUS = pAGS_ESM_FL_STATUS);

 io_cursor := v_cursor;
  end PRC_AGESADT_REL_ESCALAS;
/
