CREATE OR REPLACE PROCEDURE PRC_ASS_USC_CCUSTO_CCONT_L
(
    pCAD_SET_ID IN TB_ASS_USC_UNI_SET_CCUS_CLA.CAD_SET_ID%TYPE,    
    pAUX_EPP_CD_ESPECPROC IN TB_ASS_USC_UNI_SET_CCUS_CLA.AUX_EPP_CD_ESPECPROC%TYPE DEFAULT NULL,
    pDATACONSUMO IN DATE,
    IO_CURSOR OUT PKG_CURSOR.T_CURSOR
)
IS
/********************************************************************
*    PROCEDURE: PRC_ASS_USC_CCUSTO_CCONT_L
*    criatura: 04/08/2010  POR: MARCUS RELVA
*******************************************************************/
V_CURSOR PKG_CURSOR.T_CURSOR;
v_countusc           NUMBER;
BEGIN

  if pAUX_EPP_CD_ESPECPROC is null then
    OPEN V_CURSOR FOR
    select usc.ass_usc_id,
           usc.cad_set_id,
           usc.cad_cec_id_ccusto,
           usc.cad_cac_id_classcontabil,
           usc.tis_cbo_cd_cbos,
           cec.cad_cec_ds_ccusto,
           cac.cad_cac_ds_classcontabil
      from tb_ass_usc_uni_set_ccus_cla usc,
           tb_cad_cec_centro_custo     cec,
           tb_cad_cac_classif_contab   cac
     where usc.cad_cac_id_classcontabil = cac.cad_cac_id_classcontabil
       and usc.cad_cec_id_ccusto = cec.cad_cec_id_ccusto
       and usc.ass_usc_fl_status = 'A'
       and fnc_validar_vigencia_data(usc.ass_usc_dt_inicio_vigencia, usc.ass_usc_dt_fim_vigencia, pDATACONSUMO) = 1
       and usc.cad_set_id = pCAD_SET_ID
       and usc.aux_epp_cd_especproc is null;
  else      
      select count(1)
      into v_countusc
      from tb_ass_usc_uni_set_ccus_cla usc,
           tb_cad_cec_centro_custo     cec,
           tb_cad_cac_classif_contab   cac
     where usc.cad_cac_id_classcontabil = cac.cad_cac_id_classcontabil
       and usc.cad_cec_id_ccusto = cec.cad_cec_id_ccusto
       and usc.ass_usc_fl_status = 'A'
       and fnc_validar_vigencia_data(usc.ass_usc_dt_inicio_vigencia, usc.ass_usc_dt_fim_vigencia, pDATACONSUMO) = 1
       and usc.cad_set_id = pCAD_SET_ID
       and usc.aux_epp_cd_especproc = pAUX_EPP_CD_ESPECPROC;
       

       if(v_countusc > 0) then
         OPEN V_CURSOR FOR
             select usc.ass_usc_id,
               usc.cad_set_id,
               usc.cad_cec_id_ccusto,
               usc.cad_cac_id_classcontabil,
               usc.tis_cbo_cd_cbos,
               cec.cad_cec_ds_ccusto,
               cac.cad_cac_ds_classcontabil
          from tb_ass_usc_uni_set_ccus_cla usc,
               tb_cad_cec_centro_custo     cec,
               tb_cad_cac_classif_contab   cac
         where usc.cad_cac_id_classcontabil = cac.cad_cac_id_classcontabil
           and usc.cad_cec_id_ccusto = cec.cad_cec_id_ccusto
           and usc.ass_usc_fl_status = 'A'
           and fnc_validar_vigencia_data(usc.ass_usc_dt_inicio_vigencia, usc.ass_usc_dt_fim_vigencia, pDATACONSUMO) = 1
           and usc.cad_set_id = pCAD_SET_ID
           and usc.aux_epp_cd_especproc = pAUX_EPP_CD_ESPECPROC;     
       else
       OPEN V_CURSOR FOR
             select usc.ass_usc_id,
               usc.cad_set_id,
               usc.cad_cec_id_ccusto,
               usc.cad_cac_id_classcontabil,
               usc.tis_cbo_cd_cbos,
               cec.cad_cec_ds_ccusto,
               cac.cad_cac_ds_classcontabil
          from tb_ass_usc_uni_set_ccus_cla usc,
               tb_cad_cec_centro_custo     cec,
               tb_cad_cac_classif_contab   cac
         where usc.cad_cac_id_classcontabil = cac.cad_cac_id_classcontabil
           and usc.cad_cec_id_ccusto = cec.cad_cec_id_ccusto
           and usc.ass_usc_fl_status = 'A'
           and fnc_validar_vigencia_data(usc.ass_usc_dt_inicio_vigencia, usc.ass_usc_dt_fim_vigencia, pDATACONSUMO) = 1
           and usc.cad_set_id = pCAD_SET_ID
           and usc.aux_epp_cd_especproc is null;
       end if; 
  end if;
                   
  IO_CURSOR := V_CURSOR;
END PRC_ASS_USC_CCUSTO_CCONT_L;    
/
