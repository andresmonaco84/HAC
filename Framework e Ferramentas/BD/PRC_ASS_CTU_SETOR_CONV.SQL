CREATE OR REPLACE PROCEDURE prc_ass_ctu_setor_conv
(
  pCAD_SET_ID                   TB_ATD_ATE_ATENDIMENTO.CAD_SET_ID%TYPE,
  pCAD_CNV_ID_CONVENIO          TB_CAD_PAC_PACIENTE.CAD_CNV_ID_CONVENIO%TYPE,
  pCAD_PRD_DS_DESCRICAO         TB_CAD_PRD_PRODUTO.CAD_PRD_DS_DESCRICAO%TYPE DEFAULT NULL,
  pCAD_PRD_CD_CODIGO			TB_CAD_PRD_PRODUTO.cad_prd_cd_codigo%TYPE DEFAULT NULL,
  IO_CURSOR                     OUT PKG_CURSOR.T_CURSOR
)
  IS
  
  /* Retornar Todos os Produtos do Setor/Convenio */
  
  V_CURSOR PKG_CURSOR.T_CURSOR;
  TIPO_COMANDA_MAT_MED CONSTANT NUMBER := 1;
BEGIN
  OPEN V_CURSOR FOR
  
   select prd.cad_prd_id,
          prd.cad_prd_cd_codigo,
          prd.cad_prd_ds_descricao,
          prd.cad_tap_tp_atributo,
          max(fat_tco_id) as fat_tco_id
     from tb_ass_ctu_cnv_tab_utiliza ctu,
          tb_cad_prd_produto         prd,
          tb_fat_tcp_tp_comanda_prod tcp,
          tb_tis_med_tabelamedica    med
    where ctu.tis_med_cd_tabelamedica = prd.tis_med_cd_tabelamedica
      and prd.cad_tap_tp_atributo = ctu.cad_tap_tp_atributo
      and prd.cad_prd_id = tcp.cad_prd_id
      and med.tis_med_cd_tabelamedica = prd.tis_med_cd_tabelamedica
      and fnc_validar_vigencia(ctu.ass_ctu_dt_inicio_vigencia, ctu.ass_ctu_dt_fim_vigencia) = 1
      and tcp.fat_tcp_fl_status = 'A'
      and prd.cad_prd_fl_status = 'A'
      and ctu.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
      and tcp.fat_tco_id <> TIPO_COMANDA_MAT_MED 
      and tcp.fat_tco_id in (select tcs.fat_tco_id from tb_fat_tcs_comanda_set_cc tcs where tcs.cad_set_id = pCAD_SET_ID)
      and (pCAD_PRD_DS_DESCRICAO is null or upper(prd.cad_prd_ds_descricao) like upper(pCAD_PRD_DS_DESCRICAO))
      and (pCAD_PRD_CD_CODIGO is null or prd.cad_prd_cd_codigo = pCAD_PRD_CD_CODIGO)
      group by prd.cad_prd_id,
          prd.cad_prd_cd_codigo,
          prd.cad_prd_ds_descricao,
          prd.cad_tap_tp_atributo;   
                 
IO_CURSOR := V_CURSOR;

END prc_ass_ctu_setor_conv;          
