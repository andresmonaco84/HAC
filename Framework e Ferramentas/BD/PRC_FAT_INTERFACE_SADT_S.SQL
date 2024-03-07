create or replace procedure PRC_FAT_INTERFACE_SADT_S
(
     pATS_ATE_CD_INTLIB IN TB_ATS_ATE_ATENDIMENTO_SADT.ATS_ATE_CD_INTLIB%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_FAT_INTERFACE_SADT_S
* 
*    Data Criacao:   data da  criação   Por: Nome do Analista
*    Data Alteracao:  data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
    select  ats.ats_ate_cd_intlib,
            ats.ats_ate_id,    
            ats.ats_ate_dt_realiz_proced,
            ats.ats_ate_hr_realiz_proced,
            pro.cad_pro_id_profissional,
            ats.cad_prd_id,
            ats.cad_pac_id_paciente_int cad_pac_id_paciente,
            setor.cad_set_id,
            lat.cad_lat_id_local_atendimento,
            uni.cad_uni_id_unidade,
            ats.seg_usu_id_usuario       
    from    tb_ats_ate_atendimento_sadt ats
    join    tb_ats_apl_aten_proced_laudo apl
    on      ats.ats_ate_id = apl.ats_ate_id
    and     ats.aux_epp_cd_especproc = apl.aux_epp_cd_especproc
    and     ats.ats_ate_in_intlib = apl.ats_ate_in_intlib
    and     ats.ats_ate_cd_intlib = apl.ats_ate_cd_intlib
    and     ats.cad_prd_id = apl.cad_prd_id 
    and     ats.tis_med_cd_tabelamedica = apl.tis_med_cd_tabelamedica
    join    tb_atd_ate_atendimento atd
    on      atd.atd_ate_id = ats.ats_ate_cd_intlib
    join    tb_ass_pat_pacieatend pat
    on      atd.atd_ate_id = pat.atd_ate_id    
    join    tb_cad_prd_produto prd
    on      prd.cad_prd_id = ats.cad_prd_id
    join    tb_cad_pro_profissional pro
    on      apl.cad_pro_id_prof = pro.cad_pro_id_profissional
    join    tb_cad_pac_paciente pac   
    on      ats.cad_pac_id_paciente_int = pac.cad_pac_id_paciente    
    join    tb_cad_set_setor setor
    on      ats.cad_set_id_aten = setor.cad_set_id
    join    tb_cad_lat_local_atendimento lat
    on      atd.cad_lat_id_local_atendimento = lat.cad_lat_id_local_atendimento
    join    tb_cad_uni_unidade uni
    on      atd.cad_uni_id_unidade = uni.cad_uni_id_unidade
    where   ats.ats_ate_fl_status ='A' 
    and     atd.atd_ate_fl_status = 'A' 
    and     ats.ats_ate_cd_intlib = pATS_ATE_CD_INTLIB;
io_cursor := v_cursor;
end PRC_FAT_INTERFACE_SADT_S;
/
