create or replace procedure PRC_AGE_REL_PRAZO_ATEND
  (
  pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE,
  pCAD_LAT_ID_LOCAL_ATENDIMENTO IN tb_cad_lat_local_atendimento.cad_lat_id_local_atendimento%TYPE,
  pCOD_TIPO_HORARIO IN TB_AGE_AGG_AGENDA_GERADA.AGE_AGG_TP_HORARIO%TYPE DEFAULT NULL,
  io_cursor OUT PKG_CURSOR.t_cursor
) is
  /********************************************************************
  *    Procedure: PRC_AGE_REL_PRAZO_ATEND
  *    Fun??o:    Alimenta o relat?rio de prazo de atendimento
  *
  *    Data Criacao:             08/11/2007           Por: Guilherme Holdack
  *
  *    Data Altera??o: 26/11/2007           Por: Guilherme Holdack
  *    Altera??o: pegando o pr?ximo hor rio dispon!vel do profissional,
  *               mas agora de acordo com a unidade e local
  *    Data Alteracao: 12/03/2008   Por: Bruno Costa
  *    Alteracao: Adicao da verificacao de escala expirada
  *    AND sysdate between esm.age_esm_dt_ini_escala and esm.age_esm_dt_fim_escala
 *
  *    Data Alteracao:12/05/2008  Por Silmara
  *    Alteracao: verificar fim de vig?ncia da escala
  *
  *    Data Altera??o:12/05/2008 Por Silmara
  *    Altera??o: tirado a linha  AND sysdate between esm.age_esm_dt_ini_escala and esm.age_esm_dt_fim_escala
  *
  *    Data Alteracao:06/01/2009  Por Pedro
  *    Alteracao: inclus?o do parametro PCOD_TIPO_HORARIO
  *
  *    Data Altera??o: 23/01/2009  Por: Pedro
  *    Altera??o: enviando parametro pCOD_TIPO_HORARIO para a FNC_age_agg_prox_agd_livre
  *
 *  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
		SELECT DISTINCT
				cbo.tis_cbo_ds_cbos_hac especialidade,
				(DECODE(pro.cad_pro_cd_codcoomed,3,'****', 4, '****') || pes_pro.cad_pes_nm_pessoa) nome_medico,
				FNC_AGE_AGG_PRX_AGD_LVR_NOCUP( pro.cad_pro_id_profissional,
										       pee.age_pee_cd_periodo_escala,
										       pCAD_UNI_ID_UNIDADE,
										       pCAD_LAT_ID_LOCAL_ATENDIMENTO,
										       esm.age_esm_id,
										       esm.tis_cbo_cd_cbos,
											   pCOD_TIPO_HORARIO ) proxima_agenda,
				pee.age_pee_cd_periodo_escala periodo
		FROM tb_tis_cbo_cbos              cbo,
			 tb_cad_pro_profissional      pro,
			 tb_cad_pes_pessoa            pes_pro,
			 tb_age_esm_escala_medica     esm,
			 tb_ass_pcb_profissional_cbos pcb,
			 tb_age_pee_periodo_escala    pee
		WHERE  pro.cad_pes_id_pessoa                = pes_pro.cad_pes_id_pessoa
			   AND esm.cad_uni_id_unidade           = pCAD_UNI_ID_UNIDADE
			   AND esm.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO
			   AND esm.tis_cbo_cd_cbos              = cbo.tis_cbo_cd_cbos
			   AND esm.cad_pro_id_profissional      = pcb.cad_pro_id_profissional
			   AND pcb.tis_cbo_cd_cbos              = cbo.tis_cbo_cd_cbos
			   AND pcb.cad_pro_id_profissional      = pro.cad_pro_id_profissional
			   AND pee.age_pee_id                   = esm.age_pee_id
			   AND esm.age_esm_fl_situacao          = 'A' -- escalas ativas
			   AND (esm.age_esm_dt_fim_escala is null or trunc(esm.age_esm_dt_fim_escala) >= trunc(sysdate))
			   AND EXISTS ( SELECT  agg.age_agg_id
							FROM tb_age_agg_agenda_gerada agg
							WHERE agg.age_esm_id             = esm.age_esm_id
							AND esm.age_esm_fl_situacao      = 'A'
							AND agg.age_agg_tp_horario       = pCOD_TIPO_HORARIO
              AND agg.age_agg_fl_status_horario = 1
  --          AND ((pCOD_TIPO_HORARIO = '1' AND AGG.AGE_AGG_FL_STATUS_HORARIO != 4 AND AGG.SEG_USU_ID_USUARIO !=1) or 
    --        (pCOD_TIPO_HORARIO != '1' and AGG.AGE_AGG_TP_HORARIO = pCOD_TIPO_HORARIO))
            
							AND trunc(agg.age_agg_dt_agenda) >= trunc(SYSDATE)
							AND ROWNUM                       = 1 )
		ORDER BY cbo.tis_cbo_ds_cbos_hac, nome_medico;

io_cursor := v_cursor;
end PRC_AGE_REL_PRAZO_ATEND;
