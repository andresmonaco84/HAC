CREATE OR REPLACE PROCEDURE PRC_FAT_COF_CCI_MESABERTO
(
    pATD_ATE_TP_PACIENTE   IN VARCHAR2,
    pCAD_CNV_ID_CONVENIO   IN NUMBER,
    pCAD_UNI_ID_UNIDADE    IN NUMBER,
    io_cursor OUT PKG_CURSOR.t_cursor
)
IS

/* Marcus Relva - Fechamento - 13/04/2011 */
v_cursor PKG_CURSOR.t_cursor;
CONVENIO_PARTICULAR constant number := 282;
BEGIN
  

if(pCAD_CNV_ID_CONVENIO = CONVENIO_PARTICULAR) then
  /*Se PA - fechamento = mes ano atual*/
  OPEN v_cursor FOR
  select to_char(sysdate,'MM')  mes,
         to_char(sysdate,'yyyy') ano
  from dual;
else
  OPEN v_cursor FOR
  /* Retorna ultimo mes de fechamento + 1 */
  select to_char(add_months(max(to_date('01/' || cof.fat_cof_nr_mes_faturamento || '/' || cof.fat_cof_nr_ano_faturamento,'dd/MM/yyyy')),1),'MM') mes,
         to_char(add_months(max(to_date('01/' || cof.fat_cof_nr_mes_faturamento || '/' || cof.fat_cof_nr_ano_faturamento,'dd/MM/yyyy')),1),'yyyy') ano
  from   tb_fat_cof_controle_fecha cof
  where  cof.atd_ate_tp_paciente = pATD_ATE_TP_PACIENTE
  and    cof.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
  and    cof.cad_uni_id_unidade  = pCAD_UNI_ID_UNIDADE;
end if;

io_cursor := v_cursor;

END PRC_FAT_COF_CCI_MESABERTO;
