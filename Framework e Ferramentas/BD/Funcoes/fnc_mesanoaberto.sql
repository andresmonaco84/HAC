CREATE OR REPLACE FUNCTION SGS."FNC_MESANOABERTO"
(
    pATD_ATE_TP_PACIENTE   IN VARCHAR2,
    pCAD_CNV_ID_CONVENIO   IN NUMBER,
    pCAD_UNI_ID_UNIDADE    IN NUMBER
)

return DATE is Result DATE;
/* Marcus Relva - Fechamento - 24/05/2012 */
CONVENIO_PARTICULAR constant number := 282;
BEGIN


if(pCAD_CNV_ID_CONVENIO = CONVENIO_PARTICULAR) then
  /*Se PA - fechamento = mes ano atual*/
  select TO_DATE('01' || '/' || to_char(sysdate,'MM') || '/' || to_char(sysdate,'yyyy'),'dd/MM/yyyy') INTO Result  from dual;

else
	begin
  /* Retorna ultimo mes de fechamento + 1 */
  select to_date('01' || '/' ||
         to_char(add_months(max(to_date('01/' || cof.fat_cof_nr_mes_faturamento || '/' || cof.fat_cof_nr_ano_faturamento,'dd/MM/yyyy')),1),'MM')
         || '/' ||
         to_char(add_months(max(to_date('01/' || cof.fat_cof_nr_mes_faturamento || '/' || cof.fat_cof_nr_ano_faturamento,'dd/MM/yyyy')),1),'yyyy'),'dd/MM/yyyy')
         INTO Result
  from   tb_fat_cof_controle_fecha cof
  where  cof.atd_ate_tp_paciente = pATD_ATE_TP_PACIENTE
  and    cof.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO
  and    cof.cad_uni_id_unidade  = pCAD_UNI_ID_UNIDADE;
	exception when others then
     select TO_DATE('01' || '/' || to_char(sysdate,'MM') || '/' || to_char(sysdate,'yyyy'),'dd/MM/yyyy') INTO Result  from dual;
  end;
end if;

return Result;

END FNC_MESANOABERTO;
