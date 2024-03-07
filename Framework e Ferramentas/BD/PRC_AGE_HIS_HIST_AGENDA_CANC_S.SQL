create or replace procedure PRC_AGE_HIS_HIST_AGENDA_CANC_S
  (
     pCAD_PAC_NR_PRONTUARIO IN TB_CAD_PAC_PACIENTE.CAD_PAC_NR_PRONTUARIO%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_HIS_HIST_AGENDA_CANC_S
  *    Função:         Lista historico de atendimentos Cancelados
  *                    do paciente
  *
  *    Data Criacao:   17/12/2007           Por: Guilherme Holdack
  *
  *    Data Alteracao: 18/12/2007           Por: Guilherme Holdack
  *    Alteração: Trazendo os últimos 10
  *    Data Alteração: 15/12/2008 Por: Silmara
  *   Alteração: não é mais obrigatório o relacionamento da tb_age_agg_agenda_gerada.
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
      OPEN v_cursor FOR
        SELECT * FROM
    (
    SELECT
      cnv.cad_cnv_cd_hac_prestador codcon,
      pes.cad_pes_nm_pessoa medico,
      agc.age_agd_cd_intamb codaten,
      agc.age_agd_dt_atendimento dataaten,
      agc.age_agd_hr_atendimento horaaten,
      agc.age_agc_tp_cancelamento tpcanc,
      agc.age_agc_tp_forma_cancela tpformacanc,
      agc.age_agc_nm_solicitante soliccanc,
      agc.age_agc_dt_cancelamento datacanc,
      (
       CASE
            WHEN agg.age_esf_id IS NULL THEN 'NÃO'
            ELSE 'SIM'
       END

      ) faltamedica,

      agc.age_agc_ds_observacao observacao,
      usu.seg_usu_ds_nome usuario
    FROM
      tb_cad_cnv_convenio cnv,      
      tb_cad_pac_paciente pac,
      tb_age_agc_agenda_cancelada agc,
      tb_seg_usu_usuario usu,
      tb_age_agg_agenda_gerada agg,
      tb_cad_pro_profissional pro,
      tb_cad_pes_pessoa pes
    WHERE
      pac.cad_cnv_id_convenio = cnv.cad_cnv_id_convenio
      AND agc.cad_pac_id_paciente = pac.cad_pac_id_paciente
      AND agc.seg_usu_id_usuario = usu.seg_usu_id_usuario
      AND pac.cad_pac_nr_prontuario = pCAD_PAC_NR_PRONTUARIO
      AND agc.age_agg_id = agg.age_agg_id(+)
      AND agc.cad_pro_id_profissionalexec = pro.cad_pro_id_profissional
      AND pro.cad_pes_id_pessoa = pes.cad_pes_id_pessoa
      ORDER BY agc.age_agd_dt_atendimento DESC
       )
    WHERE ROWNUM <= 10;
  io_cursor := v_cursor;

end PRC_AGE_HIS_HIST_AGENDA_CANC_S;
