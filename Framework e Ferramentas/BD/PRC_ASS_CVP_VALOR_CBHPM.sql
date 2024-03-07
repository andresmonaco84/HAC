CREATE OR REPLACE PROCEDURE SGS."PRC_ASS_CVP_VALOR_CBHPM"
(
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CVP_CONV_VLR_PRODUTO.CAD_CNV_ID_CONVENIO%type,
     pCAD_PLA_ID_PLANO IN TB_ASS_CVP_CONV_VLR_PRODUTO.CAD_PLA_ID_PLANO%type,
     pCAD_PRD_ID IN TB_ASS_CVP_CONV_VLR_PRODUTO.CAD_PRD_ID%type,
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pDATACONSUMO IN DATE,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
     /* Obter valores CBHPM */
v_cursor PKG_CURSOR.t_cursor;
TABELA_CBHPM  constant varchar2(2) := '6';
TABELA_CBHPM3 constant varchar2(2) := '63';
TABELA_CBHPM4 constant varchar2(2) := '64';
TABELA_CBHPM5 constant varchar2(2) := '65';
TABELA_CBHPM6 constant varchar2(2) := '66';
begin
OPEN v_cursor FOR
select nvl(round((cvp.ass_cvp_vl_indice_hosp  + ((nvl(cvp.ass_cvp_pc_acrescimo,0)/100) * cvp.ass_cvp_vl_indice_hosp)),2),cvp.ass_cvp_vl_produto) as ass_cvp_vl_indice_hosp,
       cvp.ass_cvp_pc_desconto,
       cvp.aux_epp_cd_especproc,
       cvp.aux_gpc_cd_grupoproc,
       cvp.cad_prd_id,
       cvp.cad_lat_id_local_atendimento,
       cvp.cad_uni_id_unidade,
			 cvp.cad_tih_tp_indice_hosp,
			 cvp.ass_cvp_id
  from tb_cad_prd_produto          prd,
       tb_ass_cvp_conv_vlr_produto cvp
 where prd.cad_prd_tp_porte_cbhpm is not null
   and ((cvp.cad_prd_id is not null and cvp.cad_tih_tp_indice_hosp = 'R$')
       or prd.cad_tih_tp_indice_hosp = cvp.cad_tih_tp_indice_hosp)
   and (cvp.cad_prd_id = prd.cad_prd_id or cvp.cad_prd_id is null) 
   and cvp.tis_med_cd_tabelamedica = prd.tis_med_cd_tabelamedica
   and cvp.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
   and (cvp.cad_pla_id_plano = pCAD_PLA_ID_PLANO or cvp.cad_pla_id_plano is null)
   and (cvp.aux_epp_cd_especproc is null or cvp.aux_epp_cd_especproc = prd.aux_epp_cd_especproc)
   and (cvp.aux_gpc_cd_grupoproc is null or cvp.aux_gpc_cd_grupoproc = prd.aux_gpc_cd_grupoproc)
   and (cvp.cad_uni_id_unidade is null or cvp.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE)
   and (cvp.cad_lat_id_local_atendimento is null or cvp.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
   and cvp.cad_tap_tp_atributo = prd.cad_tap_tp_atributo
   and prd.cad_prd_id = pCAD_PRD_ID
   and fnc_validar_vigencia_data(ass_cvp_dt_inicio_vigencia, ass_cvp_dt_fim_vigencia, pDATACONSUMO) = 1
   and prd.tis_med_cd_tabelamedica in (TABELA_CBHPM, TABELA_CBHPM3, TABELA_CBHPM4, TABELA_CBHPM5, TABELA_CBHPM6)
   and cvp.ass_cvp_fl_status = 'A';
io_cursor := v_cursor;
end PRC_ASS_CVP_VALOR_CBHPM;
