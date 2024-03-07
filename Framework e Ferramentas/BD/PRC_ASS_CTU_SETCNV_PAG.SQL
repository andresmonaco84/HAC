CREATE OR REPLACE PROCEDURE "PRC_ASS_CTU_SETCNV_PAG"
(
  pCAD_SET_ID                   TB_ATD_ATE_ATENDIMENTO.CAD_SET_ID%TYPE DEFAULT NULL,
  pCAD_CNV_ID_CONVENIO          TB_CAD_PAC_PACIENTE.CAD_CNV_ID_CONVENIO%TYPE,
  pCAD_PRD_DS_DESCRICAO         TB_CAD_PRD_PRODUTO.CAD_PRD_DS_DESCRICAO%TYPE DEFAULT NULL,
  pCAD_PRD_CD_CODIGO            TB_CAD_PRD_PRODUTO.cad_prd_cd_codigo%TYPE DEFAULT NULL,
  pCAD_UNI_ID_UNIDADE           TB_ATD_ATE_ATENDIMENTO.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
  pCAD_LAT_ID_LOCAL_ATENDIMENTO TB_ATD_ATE_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,  
  pINICIO                       NUMBER,
  pESPECIALIDADE                varchar2,
  IO_CURSOR                     OUT PKG_CURSOR.T_CURSOR
)
  IS

  V_CURSOR PKG_CURSOR.T_CURSOR;
  TIPO_COMANDA_MAT_MED CONSTANT NUMBER := 1;
  TIPO_COMANDA_PACOTES constant number := 36;
  MAXROWS              constant number := 10000;
BEGIN
  OPEN V_CURSOR FOR

  SELECT * FROM (SELECT a.*, rownum rnum FROM (
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
      and tcp.fat_tco_id in ( select distinct tcs.fat_tco_id
                              from tb_fat_tcs_comanda_set_cc tcs
                              inner join tb_cad_set_setor str
                              on tcs.cad_set_id = str.cad_set_id
                              where (tcs.cad_set_id = pCAD_SET_ID or
                                    (pCAD_SET_ID is null 
                                     and str.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE 
                                     and str.cad_lat_id_local_atendimento = pCAD_LAT_ID_LOCAL_ATENDIMENTO))      
                             and   tcs.fat_tcs_fl_status = 'A')
      and (pCAD_PRD_DS_DESCRICAO is null or upper(prd.cad_prd_ds_descricao) like upper(pCAD_PRD_DS_DESCRICAO))
      and (pCAD_PRD_CD_CODIGO is null or prd.cad_prd_cd_codigo = upper(pCAD_PRD_CD_CODIGO))
      and (pESPECIALIDADE is null or prd.aux_epp_cd_especproc = pESPECIALIDADE)
      and rownum <= MAXROWS
      group by prd.cad_prd_id,
          prd.cad_prd_cd_codigo,
          prd.cad_prd_ds_descricao,
          prd.cad_tap_tp_atributo
          union
      select pac.cad_prd_id,
      pac.cad_prd_cd_codigo,
      pac.cad_prd_ds_descricao,
      pac.cad_tap_tp_atributo,
      TIPO_COMANDA_PACOTES as fat_tco_id
      from tb_ass_cpa_convenio_pacote cpa, tb_cad_prd_produto pac
      where cpa.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
      and cpa.cad_prd_id = pac.cad_prd_id
      and pac.cad_prd_fl_status = 'A'
      and (pCAD_PRD_DS_DESCRICAO is null or upper(pac.cad_prd_ds_descricao) like upper(pCAD_PRD_DS_DESCRICAO))
      and (pCAD_PRD_CD_CODIGO is null or pac.cad_prd_cd_codigo = upper(pCAD_PRD_CD_CODIGO))
      and cpa.ass_cpa_fl_status = 'A'
      and fnc_validar_vigencia(cpa.ass_cpa_dt_inicio_vigencia, cpa.ass_cpa_dt_fim_vigencia) = 1          
      and (pESPECIALIDADE is null)
      order by 3
          ) a
WHERE rownum <= (pINICIO+10)) WHERE rnum >= pINICIO +1;

IO_CURSOR := V_CURSOR;

END prc_ass_ctu_setcnv_pag;
 