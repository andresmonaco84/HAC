CREATE OR REPLACE FUNCTION "FNC_OBTER_CLASSCONTABIL" (pCAD_SET_ID in TB_ASS_USC_UNI_SET_CCUS_CLA.CAD_SET_ID%type,
                                                   pCAD_TAP_TP_ATRIBUTO in TB_ASS_USC_UNI_SET_CCUS_CLA.CAD_TAP_TP_ATRIBUTO%type,
                                                   pTIS_MED_CD_TABELAMEDICA in TB_ASS_USC_UNI_SET_CCUS_CLA.TIS_MED_CD_TABELAMEDICA%type,
                                                   pAUX_EPP_CD_ESPECPROC in TB_ASS_USC_UNI_SET_CCUS_CLA.AUX_EPP_CD_ESPECPROC%type,
                                                   pCAD_PRD_ID in TB_ASS_USC_UNI_SET_CCUS_CLA.CAD_PRD_ID%type,
                                                   pFAT_TCO_ID in TB_ASS_USC_UNI_SET_CCUS_CLA.FAT_TCO_ID%type,
                                                   pDATACONSUMO in Date)                                                   
/*
  Obter Classificacao Contabil
  Marcus Relva - 23/09/2010  
*/
return NUMBER is Result NUMBER;
v_cad_cac_id_classcontabil                         number := 0;
v_cad_uni_id_unidade                               number;
v_cad_lat_id_local_atendimento                     number;
begin
  begin  
    select str.cad_uni_id_unidade,
           str.cad_lat_id_local_atendimento
    into   v_cad_uni_id_unidade,
           v_cad_lat_id_local_atendimento
    from tb_cad_set_setor str
    where str.cad_set_id = pCAD_SET_ID;
  exception when others then
    v_cad_cac_id_classcontabil := 0;
  end;
  begin  
  --#1
    select usc.cad_cac_id_classcontabil
      into v_cad_cac_id_classcontabil
      from tb_ass_usc_uni_set_ccus_cla usc
     where
    /* Filtros */
     usc.cad_set_id = pCAD_SET_ID
     and usc.cad_tap_tp_atributo = pCAD_TAP_TP_ATRIBUTO
     and usc.tis_med_cd_tabelamedica = pTIS_MED_CD_TABELAMEDICA     
     and usc.aux_epp_cd_especproc = pAUX_EPP_CD_ESPECPROC     
     and usc.cad_prd_id = pCAD_PRD_ID    
    /* Somente Ativos */
     and usc.cad_cac_id_classcontabil is not null
     and usc.cad_cec_id_ccusto is null
     and fnc_validar_vigencia_data(usc.ass_usc_dt_inicio_vigencia, usc.ass_usc_dt_fim_vigencia, pDATACONSUMO) = 1
     and usc.ass_usc_fl_status = 'A';  
  exception when others then
    v_cad_cac_id_classcontabil := 0;
  end;
  if v_cad_cac_id_classcontabil = 0 then
   begin  
   --#2
    select usc.cad_cac_id_classcontabil
      into v_cad_cac_id_classcontabil
      from tb_ass_usc_uni_set_ccus_cla usc
     where
    /* Filtros */
     usc.cad_set_id = pCAD_SET_ID
     and usc.cad_tap_tp_atributo = pCAD_TAP_TP_ATRIBUTO
     and usc.tis_med_cd_tabelamedica = pTIS_MED_CD_TABELAMEDICA     
     and usc.aux_epp_cd_especproc = pAUX_EPP_CD_ESPECPROC   
     and usc.fat_tco_id = pFAT_TCO_ID
    /* Devem ser Nulos */      
     and usc.cad_prd_id is null     
    /* Somente Ativos */
     and usc.cad_cac_id_classcontabil is not null
     and usc.cad_cec_id_ccusto is null
     and fnc_validar_vigencia_data(usc.ass_usc_dt_inicio_vigencia, usc.ass_usc_dt_fim_vigencia, pDATACONSUMO) = 1
     and usc.ass_usc_fl_status = 'A';  
    exception when others then
      v_cad_cac_id_classcontabil := 0;
    end;
  end if;
  if v_cad_cac_id_classcontabil = 0 then
   begin  
   --#3
    select usc.cad_cac_id_classcontabil
      into v_cad_cac_id_classcontabil
      from tb_ass_usc_uni_set_ccus_cla usc
     where
    /* Filtros */
     usc.cad_set_id = pCAD_SET_ID
     and usc.cad_tap_tp_atributo = pCAD_TAP_TP_ATRIBUTO
     and usc.tis_med_cd_tabelamedica = pTIS_MED_CD_TABELAMEDICA
     and usc.aux_epp_cd_especproc = pAUX_EPP_CD_ESPECPROC   
    /* Devem ser Nulos */      
     and usc.cad_prd_id is null
     and usc.fat_tco_id is null
    /* Somente Ativos */
     and usc.cad_cac_id_classcontabil is not null
     and usc.cad_cec_id_ccusto is null
     and fnc_validar_vigencia_data(usc.ass_usc_dt_inicio_vigencia, usc.ass_usc_dt_fim_vigencia, pDATACONSUMO) = 1
     and usc.ass_usc_fl_status = 'A';  
    exception when others then
      v_cad_cac_id_classcontabil := 0;
    end;
  end if;
   if v_cad_cac_id_classcontabil = 0 then
   begin  
   --#4
    select usc.cad_cac_id_classcontabil
      into v_cad_cac_id_classcontabil
      from tb_ass_usc_uni_set_ccus_cla usc
     where
    /* Filtros */
     usc.cad_set_id = pCAD_SET_ID
     and usc.cad_tap_tp_atributo = pCAD_TAP_TP_ATRIBUTO
     and usc.fat_tco_id = pFAT_TCO_ID
    /* Devem ser Nulos */      
     and usc.cad_prd_id is null
     and usc.tis_med_cd_tabelamedica is null
     and usc.aux_epp_cd_especproc is null     
    /* Somente Ativos */
     and usc.cad_cac_id_classcontabil is not null
     and usc.cad_cec_id_ccusto is null
     and fnc_validar_vigencia_data(usc.ass_usc_dt_inicio_vigencia, usc.ass_usc_dt_fim_vigencia, pDATACONSUMO) = 1
     and usc.ass_usc_fl_status = 'A';  
    exception when others then
      v_cad_cac_id_classcontabil := 0;
    end;
  end if;
   if v_cad_cac_id_classcontabil = 0 then
   begin  
   --#5
    select usc.cad_cac_id_classcontabil
      into v_cad_cac_id_classcontabil
      from tb_ass_usc_uni_set_ccus_cla usc
     where
    /* Filtros */
     usc.cad_set_id = pCAD_SET_ID
     and usc.cad_tap_tp_atributo = pCAD_TAP_TP_ATRIBUTO
    /* Devem ser Nulos */      
     and usc.tis_med_cd_tabelamedica is null     
     and usc.aux_epp_cd_especproc is null     
     and usc.cad_prd_id is null
     and usc.fat_tco_id is null     
    /* Somente Ativos */
     and usc.cad_cac_id_classcontabil is not null
     and usc.cad_cec_id_ccusto is null
     and fnc_validar_vigencia_data(usc.ass_usc_dt_inicio_vigencia, usc.ass_usc_dt_fim_vigencia, pDATACONSUMO) = 1
     and usc.ass_usc_fl_status = 'A';  
    exception when others then
      v_cad_cac_id_classcontabil := 0;
    end;
  end if;  
  if v_cad_cac_id_classcontabil = 0 then
    /*Obter Unidade e Local*/
    begin  
      select str.cad_uni_id_unidade,
             str.cad_lat_id_local_atendimento
      into   v_cad_uni_id_unidade,
             v_cad_lat_id_local_atendimento
      from tb_cad_set_setor str
      where str.cad_set_id = pCAD_SET_ID;
    exception when others then
      v_cad_uni_id_unidade := 0;
      v_cad_lat_id_local_atendimento := 0;
    end;    
    if(v_cad_lat_id_local_atendimento <> 0 AND v_cad_uni_id_unidade <> 0) then
        begin  
          --#6
          select usc.cad_cac_id_classcontabil
            into v_cad_cac_id_classcontabil
            from tb_ass_usc_uni_set_ccus_cla usc
           where
          /* Filtros */
           usc.cad_lat_id_local_atendimento = v_cad_lat_id_local_atendimento
           and usc.cad_uni_id_unidade = v_cad_uni_id_unidade
           and usc.cad_tap_tp_atributo = pCAD_TAP_TP_ATRIBUTO
           and usc.tis_med_cd_tabelamedica = pTIS_MED_CD_TABELAMEDICA     
           and usc.aux_epp_cd_especproc = pAUX_EPP_CD_ESPECPROC     
           and usc.cad_prd_id = pCAD_PRD_ID    
          /* Somente Ativos */
           and fnc_validar_vigencia_data(usc.ass_usc_dt_inicio_vigencia, usc.ass_usc_dt_fim_vigencia, pDATACONSUMO) = 1
           and usc.ass_usc_fl_status = 'A'
           and usc.cad_cac_id_classcontabil is not null
           and usc.cad_cec_id_ccusto is null
           and usc.cad_set_id is null;                       
        exception when others then
         v_cad_cac_id_classcontabil := 0;
        end;
        if v_cad_cac_id_classcontabil = 0 then
           begin 
            --#7
            select usc.cad_cac_id_classcontabil
              into v_cad_cac_id_classcontabil
              from tb_ass_usc_uni_set_ccus_cla usc
             where
            /* Filtros */
             usc.cad_lat_id_local_atendimento = v_cad_lat_id_local_atendimento
             and usc.cad_uni_id_unidade = v_cad_uni_id_unidade
             and usc.cad_tap_tp_atributo = pCAD_TAP_TP_ATRIBUTO
             and usc.tis_med_cd_tabelamedica = pTIS_MED_CD_TABELAMEDICA     
             and usc.aux_epp_cd_especproc = pAUX_EPP_CD_ESPECPROC   
             and usc.fat_tco_id = pFAT_TCO_ID
            /* Devem ser Nulos */      
             and usc.cad_prd_id is null     
            /* Somente Ativos */
             and fnc_validar_vigencia_data(usc.ass_usc_dt_inicio_vigencia, usc.ass_usc_dt_fim_vigencia, pDATACONSUMO) = 1
             and usc.ass_usc_fl_status = 'A'
             and usc.cad_cac_id_classcontabil is not null
             and usc.cad_cec_id_ccusto is null             
             and usc.cad_set_id is null;  
             
          exception when others then
            v_cad_cac_id_classcontabil := 0;
          end;
       end if;
       if v_cad_cac_id_classcontabil = 0 then
         begin  
           --#8
            select usc.cad_cac_id_classcontabil
              into v_cad_cac_id_classcontabil
              from tb_ass_usc_uni_set_ccus_cla usc
             where
            /* Filtros */
             usc.cad_lat_id_local_atendimento = v_cad_lat_id_local_atendimento
             and usc.cad_uni_id_unidade = v_cad_uni_id_unidade
             and usc.cad_tap_tp_atributo = pCAD_TAP_TP_ATRIBUTO
             and usc.tis_med_cd_tabelamedica = pTIS_MED_CD_TABELAMEDICA
             and usc.aux_epp_cd_especproc = pAUX_EPP_CD_ESPECPROC   
            /* Devem ser Nulos */      
             and usc.cad_prd_id is null
             and usc.fat_tco_id is null
            /* Somente Ativos */
             and fnc_validar_vigencia_data(usc.ass_usc_dt_inicio_vigencia, usc.ass_usc_dt_fim_vigencia, pDATACONSUMO) = 1
             and usc.ass_usc_fl_status = 'A'
             and usc.cad_cac_id_classcontabil is not null
             and usc.cad_cec_id_ccusto is null
             and usc.cad_set_id is null;  
          exception when others then
            v_cad_cac_id_classcontabil := 0;
          end;
       end if;
       if v_cad_cac_id_classcontabil = 0 then
         begin  
         --#9
            select usc.cad_cac_id_classcontabil
              into v_cad_cac_id_classcontabil
              from tb_ass_usc_uni_set_ccus_cla usc
             where
            /* Filtros */
             usc.cad_lat_id_local_atendimento = v_cad_lat_id_local_atendimento
             and usc.cad_uni_id_unidade = v_cad_uni_id_unidade
             and usc.cad_tap_tp_atributo = pCAD_TAP_TP_ATRIBUTO
             and usc.fat_tco_id = pFAT_TCO_ID
            /* Devem ser Nulos */      
             and usc.cad_prd_id is null
             and usc.tis_med_cd_tabelamedica is null
             and usc.aux_epp_cd_especproc is null     
            /* Somente Ativos */
             and fnc_validar_vigencia_data(usc.ass_usc_dt_inicio_vigencia, usc.ass_usc_dt_fim_vigencia, pDATACONSUMO) = 1
             and usc.ass_usc_fl_status = 'A'             
             and usc.cad_cac_id_classcontabil is not null
             and usc.cad_cec_id_ccusto is null
             and usc.cad_set_id is null;  
          exception when others then
            v_cad_cac_id_classcontabil := 0;
          end;
      end if;
      if v_cad_cac_id_classcontabil = 0 then
       begin  
       --#10
          select usc.cad_cac_id_classcontabil
            into v_cad_cac_id_classcontabil
            from tb_ass_usc_uni_set_ccus_cla usc
           where
          /* Filtros */
           usc.cad_lat_id_local_atendimento = v_cad_lat_id_local_atendimento
           and usc.cad_uni_id_unidade = v_cad_uni_id_unidade
           and usc.cad_tap_tp_atributo = pCAD_TAP_TP_ATRIBUTO
          /* Devem ser Nulos */      
           and usc.tis_med_cd_tabelamedica is null     
           and usc.aux_epp_cd_especproc is null     
           and usc.cad_prd_id is null
           and usc.fat_tco_id is null     
          /* Somente Ativos */
           and usc.cad_cac_id_classcontabil is not null
           and usc.cad_cec_id_ccusto is null
           and fnc_validar_vigencia_data(usc.ass_usc_dt_inicio_vigencia, usc.ass_usc_dt_fim_vigencia, pDATACONSUMO) = 1
           and usc.ass_usc_fl_status = 'A'          
           and usc.cad_set_id is null;  
        exception when others then
          v_cad_cac_id_classcontabil := 0;
        end;
      end if;           
    end if;    
  end if;  
  if v_cad_cac_id_classcontabil is not null and v_cad_cac_id_classcontabil > 0 then
     Result := v_cad_cac_id_classcontabil;
  end if;      
return(Result);
end FNC_OBTER_CLASSCONTABIL;
 