create or replace procedure PRC_AGS_HIST_AGENDA_ANT_S
  (
     pCAD_PAC_NR_PRONTUARIO IN tb_cad_pac_paciente.cad_pac_nr_prontuario%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /**************************************************************************
  *    Procedure: PRC_AGS_HIST_AGENDA_ANT_S
  *
  *    Data Criacao:  11/05/2009   Por: Caio H. B. Chagas
  *    Data Alteracao: data da alteracao  Por: Nome do Analista
  *
  *    Data Alteracao: 26/04/2010    Por: Pedro
  *    Alteracao:  distinct
  *
  *    Funcao: Listar os 10 primeiros historicos de cancelamento de exame
  *
  **************************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT distinct
      CD_CONVENIO,
      ID_LIBERACAO,
      DT_AGENDAMENTO,
      HR_AGENDAMENTO,
      DS_OBSERVACAO,
      DS_USUARIO_CANC,
      DT_CANCELAMENTO,
      NM_MEDICO,
      NM_PACIENTE,
      NR_PRONTUARIO
     FROM
    (
      select
        cnv.cad_cnv_cd_hac_prestador                      CD_CONVENIO,
        agc.lib_lpr_id                                    ID_LIBERACAO,
        to_char(agc.ags_age_dt_atendimento, 'dd/MM/yyyy') DT_AGENDAMENTO,
        agc.ags_age_hr_atendimento                        HR_AGENDAMENTO,
        agc.ags_age_ds_observacao                         DS_OBSERVACAO,
        usu.seg_usu_ds_nome                               DS_USUARIO_CANC,
        agc.ags_agc_dt_cancelamento                       DT_CANCELAMENTO,
        pes.cad_pes_nm_pessoa                             NM_MEDICO,
        pespac.cad_pes_nm_pessoa                          NM_PACIENTE,
        pac.cad_pac_nr_prontuario                         NR_PRONTUARIO
      from
        tb_ags_agc_agenda_canc_sadt agc
      inner join tb_cad_pac_paciente pac
        on pac.cad_pac_id_paciente = agc.cad_pac_id_paciente
      inner join tb_cad_cnv_convenio cnv
        on cnv.cad_cnv_id_convenio = pac.cad_cnv_id_convenio
      inner join tb_seg_usu_usuario usu
        on agc.seg_usu_id_usuario_canc = usu.seg_usu_id_usuario
      inner join tb_ags_esm_escala_sadt esm
        on agc.ags_esm_id = esm.ags_esm_id
      left join tb_cad_pro_profissional pro
        on pro.cad_pro_id_profissional = esm.cad_pro_id_profissional
      left join tb_cad_pes_pessoa pes
        on pro.cad_pes_id_pessoa = pes.cad_pes_id_pessoa
      left join tb_cad_pes_pessoa pespac
        on pac.cad_pes_id_pessoa = pespac.cad_pes_id_pessoa
      where
        pac.cad_pac_nr_prontuario  = pCAD_PAC_NR_PRONTUARIO
      order by
        agc.ags_age_dt_atendimento desc, agc.ags_age_hr_atendimento desc
    )
    WHERE ROWNUM <= 10;
  io_cursor := v_cursor;
end PRC_AGS_HIST_AGENDA_ANT_S;
