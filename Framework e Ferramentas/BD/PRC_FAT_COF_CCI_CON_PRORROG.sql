CREATE OR REPLACE PROCEDURE "PRC_FAT_COF_CCI_CON_PRORROG"
(
    pSPLIT_TIPOPACIENTE         IN VARCHAR2 DEFAULT NULL,
    pATD_ATE_ID                 IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE DEFAULT NULL,
    pCAD_CNV_ID_CONVENIO        IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,  
    io_cursor     OUT PKG_CURSOR.t_cursor
)
IS
/* Marcus Relva - Consulta Fechamento Prorrogacao - 15/04/2011 */
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
select distinct
       ccp.atd_ate_id,
       pes.cad_pes_nm_pessoa,
       ccp.cad_pac_id_paciente,
       ccp.fat_ccp_id,
       cnv.cad_cnv_cd_hac_prestador,
       pla.cad_pla_cd_plano_hac,
       cof.fat_cof_nr_mes_faturamento,
       cof.fat_cof_nr_ano_faturamento,
       to_char(add_months(to_date('01/' || cof.fat_cof_nr_mes_faturamento || '/' || cof.fat_cof_nr_ano_faturamento,'dd/MM/yyyy'),1),'MM') mes,
       to_char(add_months(to_date('01/' || cof.fat_cof_nr_mes_faturamento || '/' || cof.fat_cof_nr_ano_faturamento,'dd/MM/yyyy'),1),'yyyy') ano,
       ccp.fat_ccp_ano_fat,
       ccp.fat_ccp_mes_fat,
       ccp.fat_ccp_vl_tot_conta
         from 
              tb_fat_ccp_conta_cons_parc  ccp,
              tb_cad_pac_paciente         pac,            
              tb_cad_pes_pessoa           pes,
              tb_cad_cnv_convenio         cnv,
              tb_fat_cof_controle_fecha   cof,
              tb_cad_pla_plano            pla
where ccp.cad_pac_id_paciente     = pac.cad_pac_id_paciente
and   ccp.atd_ate_id              = ccp.atd_ate_id
and   pac.cad_pes_id_pessoa       = pes.cad_pes_id_pessoa
and   pac.cad_cnv_id_convenio     = cnv.cad_cnv_id_convenio
and   pac.cad_pla_id_plano        = pla.cad_pla_id_plano
and   ccp.fat_ccp_fl_status       = 'A'
and   cof.atd_ate_tp_paciente     = ccp.atd_ate_tp_paciente
and   cof.cad_cnv_id_convenio     = cnv.cad_cnv_id_convenio
and   cof.cad_uni_id_unidade      = ccp.cad_uni_id_unidade
and   ccp.fat_nof_id is null
and   (pATD_ATE_ID is null or ccp.atd_ate_id = pATD_ATE_ID)
and   (pCAD_CNV_ID_CONVENIO is null or pac.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO)
and   (pSPLIT_TIPOPACIENTE is null or ccp.atd_ate_tp_paciente in (select column_value from table(fnc_split(pSPLIT_TIPOPACIENTE))))
and   (cof.fat_cof_nr_mes_faturamento, cof.fat_cof_nr_ano_faturamento, pac.cad_pac_id_paciente, ccp.atd_ate_id) in
    (select to_char(max(to_date('01/' || cof.fat_cof_nr_mes_faturamento || '/' || cof.fat_cof_nr_ano_faturamento,'dd/MM/yyyy')),'MM') mes,
            to_char(max(to_date('01/' || cof.fat_cof_nr_mes_faturamento || '/' || cof.fat_cof_nr_ano_faturamento,'dd/MM/yyyy')),'yyyy') ano,
            pac.cad_pac_id_paciente,
            ccp.atd_ate_id
    from   tb_fat_cof_controle_fecha  cof,         
           tb_ass_pat_pacieatend      pat,
           tb_cad_pac_paciente        pac,
           tb_fat_ccp_conta_cons_parc ccp
    where  cof.atd_ate_tp_paciente = ccp.atd_ate_tp_paciente
    and    cof.cad_cnv_id_convenio = pac.cad_cnv_id_convenio 
    and    cof.cad_uni_id_unidade  = ccp.cad_uni_id_unidade
    and    pat.atd_ate_id          = ccp.atd_ate_id
    and    pat.cad_pac_id_paciente = pac.cad_pac_id_paciente
    and    ccp.cad_pac_id_paciente = pac.cad_pac_id_paciente
    and    ccp.fat_nof_id is null
    and    ccp.fat_ccp_fl_status  = 'A'
    and   (pATD_ATE_ID is null or ccp.atd_ate_id = pATD_ATE_ID)
    and   (pCAD_CNV_ID_CONVENIO is null or pac.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO)
    and   (pSPLIT_TIPOPACIENTE is null or ccp.atd_ate_tp_paciente in (select column_value from table(fnc_split(pSPLIT_TIPOPACIENTE))))
    group by pac.cad_pac_id_paciente,
             ccp.atd_ate_id);
io_cursor := v_cursor;
END PRC_FAT_COF_CCI_CON_PRORROG;
 