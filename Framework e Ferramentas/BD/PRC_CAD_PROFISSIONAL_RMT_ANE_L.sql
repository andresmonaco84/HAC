create or replace procedure PRC_CAD_PROFISSIONAL_RMT_ANE_L
(
    io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_CAD_PROFISSIONAL_RMT_ANE_L
*
*    Data Criacao: 12/08/2010   Por: Marcus Relva
*
*    Funcao: Obtem anestesistas - 06115
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
select pro.cad_pro_cd_codcoomed,
       pro.cad_pro_cd_cod_pro,
       pro.cad_pro_nr_conselho,
       pro.cad_pro_sg_uf_conselho,
       pro.cad_pro_fl_ativo_ok,
       pro.cad_pro_nm_apelido,
       pro.cad_pro_ds_bip_pager,
       pro.cad_pro_fl_impr_recibo_ok,
       pro.cad_pro_fl_staff_ok,
       pro.cad_pro_cd_banco,
       pro.cad_pro_cd_agencia,
       pro.cad_pro_cd_conta,
       pro.cad_pro_fl_perm_intern_ok,
       pro.cad_pro_fl_perm_ass_laudo_ok,
       pro.cad_pro_cd_matricula,
       pro.cad_pro_dt_ultima_atualizacao,
       pro.cad_pes_id_pessoa,
       pro.tis_cpr_cd_conselhoprof,
       pro.cad_pro_fl_residente_ok,
       pro.cad_pro_nr_ano_ini_residencia,
       pro.cad_pro_dt_ini_residencia,
       pro.cad_pro_dt_fim_residencia,
       pro.cad_pro_fl_perm_exame_ok,
       pro.cad_pro_nm_nome,
       pro.cad_pro_nm_sociedade_medica,
       pro.cad_pro_nm_hosp_internato,
       pro.cad_pro_nr_ano_internato,
       pro.cad_pro_nm_hosp_residencia,
       pro.cad_pro_nr_ano_residencia,
       pro.cad_pro_fl_reconhecida_mec,
       pro.cad_pro_nm_entidade_cred,
       pro.cad_pro_nm_cargo_ensino,
       pro.cad_pro_ds_trab_publicado,
       pro.cad_pro_nm_med_referencia,
       pro.cad_pro_fl_tipo_vinculo,
       pro.cad_pro_fl_status_solic,
       pro.cad_pro_ds_observacao,
       pro.cad_pro_dt_solicitacao,
       pro.cad_pro_dt_cadastro,
       pro.cad_pro_dt_aprovacao,
       pro.cad_pro_nm_respons_aprov,
       pro.cad_pro_dt_ingr_corpo_clin,
       pro.cad_pro_fl_cred_direto_conv,
       pro.cad_pro_id_profissional
  from tb_ass_pcb_profissional_cbos pcb,
       tb_cad_pro_profissional pro
 where pcb.tis_cbo_cd_cbos = 06115 
       and pcb.ass_pcb_fl_status = 'A'
       and pro.cad_pro_fl_ativo_ok = 'S'
       and pcb.cad_pro_id_profissional = pro.cad_pro_id_profissional;
   
io_cursor := v_cursor;
end PRC_CAD_PROFISSIONAL_RMT_ANE_L;