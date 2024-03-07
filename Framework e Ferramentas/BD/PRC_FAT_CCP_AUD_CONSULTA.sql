CREATE OR REPLACE PROCEDURE PRC_FAT_CCP_AUD_CONSULTA
(
    pSPLIT_TIPOPACIENTE         IN VARCHAR2 DEFAULT NULL,
    pATD_ATE_ID                 IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%TYPE DEFAULT NULL,
    pCAD_CNV_ID_CONVENIO        IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE DEFAULT NULL,  
    io_cursor OUT PKG_CURSOR.t_cursor
)
IS

/* Marcus Relva - Consultar Auditoria - 03/05/2011 */
v_cursor PKG_CURSOR.t_cursor;

begin
OPEN v_cursor FOR
select ccp.atd_ate_id,
       ccp.fat_ccp_id,
       cnv.cad_cnv_cd_hac_prestador,
       pla.cad_pla_cd_plano_hac,
       pes.cad_pes_nm_pessoa,
       ccp.fat_ccp_dt_envio_audit,
       ccp.fat_ccp_fl_status_audit,
       decode(ccp.fat_ccp_fl_status_audit, 'A', 'AUDITADA', 'E', 'EM AUDITORIA', 'NÃO AUDITADA') AS statusauditoria,       
       pac.cad_pac_id_paciente,
       ccp.fat_ccp_mes_fat || '/' || ccp.fat_ccp_ano_fat as mesanofat
  from tb_fat_ccp_conta_cons_parc ccp,
       tb_cad_pac_paciente        pac,
       tb_cad_cnv_convenio        cnv,
       tb_cad_pla_plano           pla,
       tb_cad_pes_pessoa          pes,
       tb_atd_ate_atendimento     ate
 where ccp.atd_ate_id = ate.atd_ate_id
   and ccp.cad_pac_id_paciente = pac.cad_pac_id_paciente
   and pac.cad_cnv_id_convenio = cnv.cad_cnv_id_convenio
   and pac.cad_pla_id_plano = pla.cad_pla_id_plano
   and pac.cad_pes_id_pessoa = pes.cad_pes_id_pessoa
   and (pATD_ATE_ID is null or ccp.atd_ate_id = pATD_ATE_ID)
   and (pCAD_CNV_ID_CONVENIO is null or pac.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO)
   and (pSPLIT_TIPOPACIENTE is null or ate.atd_ate_tp_paciente in (select column_value from table(fnc_split(pSPLIT_TIPOPACIENTE))))
   and ccp.fat_nof_id is null
   and ccp.fat_ccp_fl_faturada = 'N'
   and ccp.fat_ccp_fl_status   = 'A'
   and ate.atd_ate_fl_status   = 'A'
   order by ccp.atd_ate_id, ccp.fat_ccp_id;
   
io_cursor := v_cursor;

END PRC_FAT_CCP_AUD_CONSULTA;
