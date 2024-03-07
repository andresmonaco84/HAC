create or replace FUNCTION timespan_dias
(
       p_DataHoraInicio in Date,
       p_DataHoraFim    in Date
)
  RETURN NUMBER
 IS
  dias number;
BEGIN
  select  trunc(to_date(p_DataHoraFim,'dd/mm/yyyy hh24:mi:ss') - to_date(p_DataHoraInicio,'dd/mm/yyyy hh24:mi:ss'))
  into dias
  from dual;
 RETURN dias;
END;
