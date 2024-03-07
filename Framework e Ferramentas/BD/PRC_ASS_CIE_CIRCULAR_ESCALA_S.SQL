create or replace procedure PRC_ASS_CIE_CIRCULAR_ESCALA_S
  (
     pAGE_ESM_ID IN TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_ID%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CIE_CIRCULAR_ESCALA_S
  *
  *    Data Criacao: 	06/08/2007         Por: Guilherme Holdack
  *    Data Alteracao:	data da alteraÃ§Ã£o  Por: Nome do Analista
  *
  *    Data Alteração: 30/10/2007        Por: Guilherme Holdack
  *    Alteração: Listando os campos sem *
  *    Funcao: Listar circulares de uma determinada escala
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
      ecc.age_ecc_id,
      ecc.age_ecc_nr_circular,
      ecc.age_ecc_dt_circular,
      ecc.age_ecc_ds_obs_circular,
      ecc.age_ecc_tp_circular,
      ecc.age_ecc_dt_ultima_atualizacao,
      ecc.cad_uni_id_unidade,
      ecc.age_ecc_cd_fisico,
      cie.seg_usu_id_usuario,
      cie.ass_cie_dt_ultima_atualizacao,
      esm.AGE_ESM_ID,
       esm.AGE_SAU_ID,
       esm.AGE_ESM_DT_INI_ESCALA,
       esm.AGE_ESM_HR_INI_ESCALA,
       esm.AGE_ESM_DT_FIM_ESCALA,
       esm.AGE_ESM_HR_FIM_ESCALA,
       esm.AGE_ESM_NR_DIA_SEMANA,
       esm.AGE_ESM_FL_SITUACAO,
       esm.AGE_ESM_QT_DIAS_CRIACAO,
       esm.AGE_ESM_QT_AGE_PERM_PHORA,
       esm.AGE_ESM_FL_PERM_ENCAIXE,
       esm.AGE_ESM_FL_PERM_ENCAIXE_ESP,
       esm.AGE_ESM_FL_PERM_RETORNO,
       esm.AGE_ESM_DT_CRIACAO_ESCALA,
       esm.AGE_ESM_QT_ENCAIXE,
       esm.AGE_ESM_QT_ENCAIXE_PHORA,
       esm.AGE_ESM_QT_ENCAIXE_ESP,
       esm.AGE_ESM_QT_ENCAIXE_ESP_PHORA,
       esm.AGE_ESM_DS_OBS,
       esm.AGE_ESM_FL_TRANSF,
       esm.TIS_CBO_CD_CBOS,
       esm.CAD_PRO_ID_PROFISSIONAL,
       esm.CAD_LAT_ID_LOCAL_ATENDIMENTO,
       esm.AGE_PEE_ID,
       esm.AGE_ESM_QT_RET_PERM_PHORA,
       esm.AGE_ESM_FL_PERM_AGENDA_SP,
       esm.AGE_ESM_QT_AGE_PERM_PHORA_SP,
       esm.AGE_ESM_QT_DIAS_INTERVALO,
       esm.AGE_ESM_FL_AGENDAGERADA_OK
    FROM
    TB_AGE_ECC_ESCALA_CTRL_CIRC ecc,
    TB_ASS_CIE_CIRCULAR_ESCALA cie,
    TB_AGE_ESM_ESCALA_MEDICA esm
    WHERE
     cie.AGE_ESM_id = pAGE_ESM_ID
     and cie.AGE_ESM_id = esm.AGE_ESM_id
     and cie.age_ecc_id = ecc.age_ecc_id;
     io_cursor := v_cursor;

end PRC_ASS_CIE_CIRCULAR_ESCALA_S;
/
