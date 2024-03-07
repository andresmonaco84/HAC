CREATE OR REPLACE PROCEDURE SGS."PRC_ASS_CVP_OBTER_UCO"
(
     pCAD_CNV_ID_CONVENIO IN TB_ASS_CVP_CONV_VLR_PRODUTO.CAD_CNV_ID_CONVENIO%type,
     pCAD_PLA_ID_PLANO IN TB_ASS_CVP_CONV_VLR_PRODUTO.CAD_PLA_ID_PLANO%type,
     pCAD_PRD_ID IN TB_ASS_CVP_CONV_VLR_PRODUTO.CAD_PRD_ID%type,
     pDATACONSUMO IN DATE,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/* Obter valor da taxa UCO */
v_cursor PKG_CURSOR.t_cursor;
v_cobrataxa_uco number := 0;
TABELA_CBHPM  constant varchar2(2) := '6';
TABELA_CBHPM3 constant varchar2(2) := '63';
TABELA_CBHPM4 constant varchar2(2) := '64';
TABELA_CBHPM5 constant varchar2(2) := '65';
TABELA_CBHPM6 constant varchar2(2) := '66';
v_AUX_EPP_CD_ESPECPROC TB_ASS_CVP_CONV_VLR_PRODUTO.AUX_EPP_CD_ESPECPROC%type;
v_AUX_GPC_CD_GRUPOPROC TB_ASS_CVP_CONV_VLR_PRODUTO.AUX_GPC_CD_GRUPOPROC%type;
v_CAD_PRD_QT_CUSTO_OPER TB_CAD_PRD_PRODUTO.CAD_PRD_QT_CUSTO_OPER%type;
begin
select count(1), prd.aux_epp_cd_especproc, prd.aux_gpc_cd_grupoproc, prd.cad_prd_qt_custo_oper
into v_cobrataxa_uco, v_AUX_EPP_CD_ESPECPROC, v_AUX_GPC_CD_GRUPOPROC, v_CAD_PRD_QT_CUSTO_OPER
from tb_cad_prd_produto prd
where prd.cad_prd_id = pCAD_PRD_ID
and prd.cad_prd_qt_custo_oper is not null
and prd.tis_med_cd_tabelamedica in (TABELA_CBHPM,TABELA_CBHPM3,TABELA_CBHPM4, TABELA_CBHPM5, TABELA_CBHPM6)
group by prd.aux_epp_cd_especproc, prd.aux_gpc_cd_grupoproc, prd.cad_prd_qt_custo_oper;
if(v_cobrataxa_uco > 0) then
OPEN v_cursor FOR
   select round((cvp.ass_cvp_vl_indice_hosp - ((nvl(cvp.ass_cvp_pc_desconto,0)/100) * cvp.ass_cvp_vl_indice_hosp) + ((nvl(cvp.ass_cvp_pc_acrescimo,0)/100) * cvp.ass_cvp_vl_indice_hosp)),2) as ass_cvp_vl_indice_hosp,
          cvp.aux_epp_cd_especproc,
          cvp.aux_gpc_cd_grupoproc,
          v_CAD_PRD_QT_CUSTO_OPER as cad_prd_qt_custo_oper
   from tb_ass_cvp_conv_vlr_produto cvp
  join tb_ass_ctu_cnv_tab_utiliza ctu on cvp.tis_med_cd_tabelamedica = ctu.tis_med_cd_tabelamedica_cobra
         and                               ctu.cad_tap_tp_atributo = cvp.cad_tap_tp_atributo
         and                               ctu.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
   where cvp.cad_tih_tp_indice_hosp = 'UCO'
   and   (cvp.aux_epp_cd_especproc is null or cvp.aux_epp_cd_especproc = v_AUX_EPP_CD_ESPECPROC)
   and   (cvp.aux_gpc_cd_grupoproc is null or cvp.aux_gpc_cd_grupoproc = v_AUX_GPC_CD_GRUPOPROC)
   and   cvp.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
   and   (cvp.cad_pla_id_plano   = pCAD_PLA_ID_PLANO or cvp.cad_pla_id_plano is null)
   and   fnc_validar_vigencia_data(ass_cvp_dt_inicio_vigencia, ass_cvp_dt_fim_vigencia, pDATACONSUMO) = 1
   and   cvp.ass_cvp_fl_status = 'A';   
io_cursor := v_cursor;
end if;
end PRC_ASS_CVP_OBTER_UCO;
