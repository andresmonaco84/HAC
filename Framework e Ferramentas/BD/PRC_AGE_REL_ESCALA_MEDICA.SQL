create or replace procedure PRC_AGE_REL_ESCALA_MEDICA
  (
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO in TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pTIS_CBO_CD_CBOS IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%type default null,
     pAGE_ESM_FL_SITUACAO IN TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_FL_SITUACAO%TYPE,
         io_cursor OUT PKG_CURSOR.t_cursor
  )
  IS
  /********************************************************************
  *    Procedure: PRC_AGE_REL_ESCALA_MEDICA
  *
  *    Data Criacao:  31/10/2007   Por: Guilherme
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: Alimentar relatorio de Escalas Médicas
  *
  *     Data Alteração: 31/10/2007      Por: Guilherme
  *     Alteraçao: Ordenação adicional por data inicial de escala.
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR

         SELECT
      ( cbo.tis_cbo_cd_cbos_hac || ' - ' || cbo.tis_cbo_ds_cbos_hac) especialidade,
      pes.cad_pes_nm_pessoa,
      pro.cad_pro_nr_conselho,
     
       TO_CHAR(esm.AGE_ESM_DT_INI_ESCALA,'dd/MM/yyyy') data_inicial,
       (substr(lpad(esm.AGE_ESM_HR_INI_ESCALA,4,'0'),1,2)||':'||substr(lpad(esm.AGE_ESM_HR_INI_ESCALA,4,'0'),3,2))hora_inicial,
       decode(TO_CHAR(esm.AGE_ESM_DT_FIM_ESCALA,'dd/MM/yyyy'),'','-',TO_CHAR(esm.AGE_ESM_DT_FIM_ESCALA,'dd/MM/yyyy')) data_final,
       (substr(lpad(esm.AGE_ESM_HR_FIM_ESCALA,4,'0'),1,2)||':'||substr(lpad(esm.AGE_ESM_HR_FIM_ESCALA,4,'0'),3,2))hora_final,
       
       decode(esm.AGE_ESM_NR_DIA_SEMANA,
       1,'SEG',
       2,'TER',
       3,'QUA',
       4,'QUI',
       5,'SEX',
       6,'SAB')dia_semana,
       pee.age_pee_cd_periodo_escala,
       esm.AGE_ESM_QT_DIAS_CRIACAO,
       esm.AGE_ESM_QT_DIAS_INTERVALO,
       decode(esm.AGE_ESM_QT_AGE_PERM_PHORA,0,'-',esm.AGE_ESM_QT_AGE_PERM_PHORA)Agenda_hora,
       
       decode(Upper(esm.AGE_ESM_FL_PERM_ENCAIXE), 'S','Sim',
                                            'N','Não')permite_encaixe,
       decode(esm.AGE_ESM_QT_ENCAIXE,0,'-',esm.AGE_ESM_QT_ENCAIXE)qtd_encaixe,
       decode(esm.AGE_ESM_QT_ENCAIXE_PHORA,0,'-',esm.AGE_ESM_QT_ENCAIXE_PHORA)quantidade_encaixe_hora,
       decode(Upper(esm.AGE_ESM_FL_PERM_ENCAIXE_ESP), 'S','Sim',
                                            'N','Não') permite_encaixe_especial,
       decode(esm.AGE_ESM_QT_ENCAIXE_ESP,0,'-',esm.AGE_ESM_QT_ENCAIXE_ESP)quantidade_encaixe_especial,
       decode(esm.AGE_ESM_QT_ENCAIXE_ESP_PHORA,0,'-',esm.AGE_ESM_QT_ENCAIXE_ESP_PHORA)qtd_encaixe_especial_hora,
       decode(Upper(esm.AGE_ESM_FL_PERM_RETORNO), 'S','Sim',
                                            'N','Não') permite_retorno,
       decode(esm.AGE_ESM_QT_RET_PERM_PHORA,0,'-',esm.AGE_ESM_QT_RET_PERM_PHORA) retorno_hora,
              decode(Upper(esm.AGE_ESM_FL_PERM_AGENDA_SP), 'S','Sim',
                                            'N','Não') permite_agenda_sprestado,
       decode(esm.AGE_ESM_QT_AGE_PERM_PHORA_SP,0,'-',esm.AGE_ESM_QT_AGE_PERM_PHORA_SP) sp_hora,

       decode(Upper(esm.AGE_ESM_FL_TRANSF), 'S','Sim',
                                            'N','Não')permite_transferencia,

       TO_CHAR(esm.AGE_ESM_DT_CRIACAO_ESCALA,'dd/MM/yyyy') data_criacao,
      decode(Upper(esm.AGE_ESM_FL_SITUACAO),'A', 'Ativa',
                                                         'S', 'Suspensa',
                                                         'I', 'Inativa') status_escala


    FROM
    tb_age_esm_escala_medica esm,
    tb_cad_pro_profissional pro,
    tb_cad_pes_pessoa pes,
    tb_tis_cbo_cbos cbo,
    tb_age_pee_periodo_escala pee
    WHERE 
    esm.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE
    AND esm.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO
    AND (pTIS_CBO_CD_CBOS IS NULL OR esm.tis_cbo_cd_cbos = pTIS_CBO_CD_CBOS)
    AND     esm.cad_pro_id_profissional = pro.cad_pro_id_profissional
    AND pro.cad_pes_id_pessoa = pes.cad_pes_id_pessoa
    AND cbo.tis_cbo_cd_cbos = esm.tis_cbo_cd_cbos
    AND pee.age_pee_id = esm.age_pee_id
    AND esm.age_esm_fl_situacao = pAGE_ESM_FL_SITUACAO

ORDER BY cbo.tis_cbo_ds_cbos_hac,
         pes.cad_pes_nm_pessoa,
         esm.age_esm_dt_ini_escala
         ;
    io_cursor := v_cursor;

  end PRC_AGE_REL_ESCALA_MEDICA;

    
    
/
