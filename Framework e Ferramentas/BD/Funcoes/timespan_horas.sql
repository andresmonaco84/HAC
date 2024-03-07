create or replace FUNCTION timespan_horas
(
       p_DataHoraInicio in Date,
       p_DataHoraFim    in Date
)
  RETURN NUMBER
 IS
  horas number;
BEGIN
  select trunc (to_date(p_DataHoraFim,'dd/mm/yyyy hh24:mi:ss') - to_date(p_DataHoraInicio,'dd/mm/yyyy hh24:mi:ss'))*24 +
         trunc((to_date(p_DataHoraFim,'dd/mm/yyyy hh24:mi:ss') - to_date(p_DataHoraInicio,'dd/mm/yyyy hh24:mi:ss') - 
         trunc(to_date(p_DataHoraFim,'dd/mm/yyyy hh24:mi:ss') - to_date(p_DataHoraInicio,'dd/mm/yyyy hh24:mi:ss')))*24)
  into horas
  from dual;
 RETURN horas;
END;
