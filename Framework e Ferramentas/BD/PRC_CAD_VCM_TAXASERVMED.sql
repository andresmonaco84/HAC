CREATE OR REPLACE PROCEDURE "PRC_CAD_VCM_TAXASERVMED" (pCAD_PRD_ID          IN TB_CAD_PRD_PRODUTO.CAD_PRD_ID%TYPE,
                                                    pCAD_PLA_ID_PLANO    IN TB_CAD_PLA_PLANO.CAD_PLA_ID_PLANO%TYPE,
                                                    pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE,
                                                    pDATACONSUMO        IN DATE,
                                                    io_cursor            OUT PKG_CURSOR.t_cursor) is
  v_cursor PKG_CURSOR.t_cursor;
  USO_RESTRITO varchar2(1) := 'N';
begin
begin
 select 'S'
  into USO_RESTRITO
 from Tb_Cad_Prd_Produto prd
 where prd.cad_prd_id = pCAD_PRD_ID
 and prd.cad_prd_fl_usorestritomed = 'S';
exception when others then
  USO_RESTRITO := 'N';
end;
if(USO_RESTRITO = 'S') then
    OPEN v_cursor FOR
   select vcm.cad_prd_id_taxaservmed, vcm.cad_vcm_pc_taxaservmed
     from tb_cad_vcm_val_cobr_mat_med vcm
    where vcm.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
      and (vcm.cad_pla_id_plano = pCAD_PLA_ID_PLANO or vcm.cad_pla_id_plano is null)
      and vcm.cad_vcm_fl_usorestritomed = 'S'
      and (vcm.cad_prd_id = pCAD_PRD_ID or vcm.cad_prd_id is null)
      and vcm.cad_vcm_fl_status = 'A'
      and fnc_validar_vigencia_data(vcm.cad_vcm_dt_inicio_vigencia,
                                     vcm.cad_vcm_dt_fim_vigencia,
                                     pDATACONSUMO) = 1
    order by vcm.cad_pla_id_plano;
   else
    OPEN v_cursor FOR
    select null, null from dual;
end if;
io_cursor := v_cursor;
end PRC_CAD_VCM_TAXASERVMED;