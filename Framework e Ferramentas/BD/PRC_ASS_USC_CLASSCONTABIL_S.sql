create or replace procedure PRC_ASS_USC_CLASSCONTABIL_S(pCAD_SET_ID in TB_ASS_USC_UNI_SET_CCUS_CLA.CAD_SET_ID%type,
                                                   pCAD_TAP_TP_ATRIBUTO in TB_ASS_USC_UNI_SET_CCUS_CLA.CAD_TAP_TP_ATRIBUTO%type,
                                                   pTIS_MED_CD_TABELAMEDICA in TB_ASS_USC_UNI_SET_CCUS_CLA.TIS_MED_CD_TABELAMEDICA%type,
                                                   pAUX_EPP_CD_ESPECPROC in TB_ASS_USC_UNI_SET_CCUS_CLA.AUX_EPP_CD_ESPECPROC%type,
                                                   pCAD_PRD_ID in TB_ASS_USC_UNI_SET_CCUS_CLA.CAD_PRD_ID%type,
                                                   pFAT_TCO_ID in TB_ASS_USC_UNI_SET_CCUS_CLA.FAT_TCO_ID%type,
                                                   pDATACONSUMO in Date,
                                                   io_cursor OUT PKG_CURSOR.t_cursor) 
is                                                  
/*
  Obter Classificacao Contábil
  Marcus Relva - 23/09/2010  
*/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
 
 select cac.cad_cac_id_classcontabil,
        cac.cad_cac_ds_classcontabil,
        cac.cad_cac_cd_classcontabil,
        cac.cad_cac_fl_classcontabil,
        cac.cad_cac_dt_ultima_atualizacao,
        cac.seg_usu_id_usuario,
        cac.cad_cac_cd_rm_nucleus,
        cac.cad_cac_ds_rm_nucleus
   from tb_cad_cac_classif_contab cac
  where cac.cad_cac_id_classcontabil =
        fnc_obter_classcontabil(pCAD_SET_ID,
                                pCAD_TAP_TP_ATRIBUTO,
                                pTIS_MED_CD_TABELAMEDICA,
                                pAUX_EPP_CD_ESPECPROC,
                                pCAD_PRD_ID,
                                pFAT_TCO_ID,
                                pDATACONSUMO);
                                     
io_cursor := v_cursor;                                     

end PRC_ASS_USC_CLASSCONTABIL_S;
