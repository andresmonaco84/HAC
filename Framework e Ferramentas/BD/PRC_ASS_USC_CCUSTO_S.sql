create or replace procedure PRC_ASS_USC_CCUSTO_S(pCAD_SET_ID in TB_ASS_USC_UNI_SET_CCUS_CLA.CAD_SET_ID%type,
                                                   pCAD_TAP_TP_ATRIBUTO in TB_ASS_USC_UNI_SET_CCUS_CLA.CAD_TAP_TP_ATRIBUTO%type,
                                                   pTIS_MED_CD_TABELAMEDICA in TB_ASS_USC_UNI_SET_CCUS_CLA.TIS_MED_CD_TABELAMEDICA%type,
                                                   pAUX_EPP_CD_ESPECPROC in TB_ASS_USC_UNI_SET_CCUS_CLA.AUX_EPP_CD_ESPECPROC%type,
                                                   pCAD_PRD_ID in TB_ASS_USC_UNI_SET_CCUS_CLA.CAD_PRD_ID%type,
                                                   pFAT_TCO_ID in TB_ASS_USC_UNI_SET_CCUS_CLA.FAT_TCO_ID%type,
                                                   pDATACONSUMO in Date,
                                                   io_cursor OUT PKG_CURSOR.t_cursor)
is
/*
  Obter Centro de Custo
  Marcus Relva - 11/01/2011
*/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
                                
select cec.cad_cec_id_ccusto,
       cec.cad_cec_cd_ccusto,
       cec.cad_cec_ds_ccusto,
       cec.cad_cec_fl_ccusto,
       cec.cad_cec_dt_ultima_atualizacao,
       cec.seg_usu_id_usuario,
       cec.cad_cec_cd_grupoccusto,
       cec.cad_cec_cd_subgrupoccusto
  from tb_cad_cec_centro_custo cec
 where cec.cad_cec_id_ccusto = fnc_obter_ccusto(pCAD_SET_ID,
                                                 pCAD_TAP_TP_ATRIBUTO,
                                                 pTIS_MED_CD_TABELAMEDICA,
                                                 pAUX_EPP_CD_ESPECPROC,
                                                 pCAD_PRD_ID,
                                                 pFAT_TCO_ID,
                                                 pDATACONSUMO);                                                             

io_cursor := v_cursor;
end PRC_ASS_USC_CCUSTO_S;
