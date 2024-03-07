CREATE OR REPLACE PROCEDURE PRC_FAT_COF_CCI_MAIOR_PRORROG
(
    pATD_ATE_TP_PACIENTE        IN VARCHAR2,
    pCAD_CNV_ID_CONVENIO        IN NUMBER,
    pCAD_UNI_ID_UNIDADE         IN NUMBER,
    io_cursor     OUT PKG_CURSOR.t_cursor
)
IS
/* Marcus Relva - Retorna maior ano/mes faturamento para saber se existe prorrogacao - 18/04/2011 */
v_cursor PKG_CURSOR.t_cursor;
begin

OPEN v_cursor FOR
select  add_months(max(to_date('01/' || ccp.fat_ccp_mes_fat || '/' || ccp.fat_ccp_ano_fat,'dd/MM/yyyy')),-1) mesAnoMaior
         from tb_fat_ccp_conta_cons_parc  ccp,
              tb_cad_pac_paciente         pac,
              tb_atd_ate_atendimento      ate
where ate.atd_ate_id              = ccp.atd_ate_id
and   ccp.cad_pac_id_paciente     = pac.cad_pac_id_paciente
and   ccp.fat_nof_id is null
and   ccp.fat_ccp_ano_fat is not null
and   ccp.fat_ccp_mes_fat is not null
and   pac.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
and   ate.cad_uni_id_unidade  = pCAD_UNI_ID_UNIDADE
and   ate.atd_ate_tp_paciente = pATD_ATE_TP_PACIENTE;
io_cursor := v_cursor;

END PRC_FAT_COF_CCI_MAIOR_PRORROG;
