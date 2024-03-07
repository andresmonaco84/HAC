CREATE OR REPLACE PROCEDURE SGS.PRC_FAT_COF_CCI_CONSULTA
(
    pSPLIT_TIPOPACIENTE         IN VARCHAR2,
    pSPLIT_CONVENIO             IN VARCHAR2,
    pSPLIT_UNIDADE              IN VARCHAR2,
    pFAT_COF_NR_ANO_FATURAMENTO IN NUMBER DEFAULT NULL,
    pFAT_COF_NR_MES_FATURAMENTO IN NUMBER DEFAULT NULL,
    io_cursor OUT PKG_CURSOR.t_cursor
)
IS

/* Marcus Relva - Consulta Fechamento - 11/04/2011 */
v_cursor PKG_CURSOR.t_cursor;
begin

OPEN v_cursor FOR
select cnv.cad_cnv_cd_hac_prestador || ' - ' || cnv.cad_cnv_nm_fantasia cad_cnv_cd_hac_prestador,
       uni.cad_uni_ds_unidade,
       decode(cof.atd_ate_tp_paciente, 'I', 'INTERNADO', 'E', 'EXTERNO', 'U', 'PRONTO SOCORRO', 'A', 'AMBULATORIO', cof.atd_ate_tp_paciente) DESCRICAO_PACIENTE,
       cof.fat_cof_nr_ano_faturamento,
       cof.fat_cof_nr_mes_faturamento,
       usu.seg_usu_ds_nome,
       cof.fat_cof_dt_ultima_atualizacao,
       cof.fat_cof_fl_situacao_fecha,
       decode(cof.fat_cof_fl_situacao_fecha, 'B', 'BLOQUEADO', 'F', 'FECHADO', cof.fat_cof_fl_situacao_fecha) status_fechamento,
       cof.atd_ate_tp_paciente,
       cof.cad_cnv_id_convenio,
       cof.cad_uni_id_unidade
         from tb_cad_uni_unidade          uni,
              tb_cad_cnv_convenio         cnv,
              tb_fat_cof_controle_fecha   cof,
              tb_seg_usu_usuario          usu
where cof.cad_uni_id_unidade  = uni.cad_uni_id_unidade
and   cof.cad_cnv_id_convenio = cnv.cad_cnv_id_convenio
and   cof.seg_usu_id_usuario  = usu.seg_usu_id_usuario
and   (pFAT_COF_NR_ANO_FATURAMENTO is null or cof.fat_cof_nr_ano_faturamento = pFAT_COF_NR_ANO_FATURAMENTO)
and   (pFAT_COF_NR_MES_FATURAMENTO is null or cof.fat_cof_nr_mes_faturamento = pFAT_COF_NR_MES_FATURAMENTO)
and   cof.cad_cnv_id_convenio in (select column_value from table(fnc_split(pSPLIT_CONVENIO)))
and   cof.cad_uni_id_unidade  in (select column_value from table(fnc_split(pSPLIT_UNIDADE)))
and   cof.atd_ate_tp_paciente in (select column_value from table(fnc_split(pSPLIT_TIPOPACIENTE)));
io_cursor := v_cursor;

END PRC_FAT_COF_CCI_CONSULTA;
