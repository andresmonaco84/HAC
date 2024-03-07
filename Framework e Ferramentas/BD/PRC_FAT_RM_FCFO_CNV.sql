CREATE OR REPLACE PROCEDURE PRC_FAT_RM_FCFO_CNV(pCAD_CNV_ID_CONVENIO in number,
                                                  io_cursor            out PKG_CURSOR.t_cursor) is

v_cursor PKG_CURSOR.t_cursor;
begin

  OPEN v_cursor FOR
    select pes.codcfo,
           f.codetd,
           f.codmunicipio,
           substr(cnv.cad_cnv_ds_razaosocial, 0, 60) as cad_cnv_ds_razaosocial,
           decode(cnv.aux_fpg_cd_formapagto, 'C', '007', 'B', '005', null) as aux_fpg_cd_formapagto,
           cnv.cad_cnv_cd_opcao_pagto
    
      from tb_cad_pes_pessoa   pes,
           tb_cad_cnv_convenio cnv,
           rm.fcfo--@rm
                       f
     where cnv.cad_pes_id_pessoa = pes.cad_pes_id_pessoa
       and pes.codcfo = f.codcfo
       and f.codcoligada = 1
       and cnv.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO;
  io_cursor := v_cursor;
end PRC_FAT_RM_FCFO_CNV;
