create or replace FUNCTION timespan_semanas
(
       p_DataHoraInicio in Date,
       p_DataHoraFim    in Date
)
  RETURN NUMBER
 IS
  semanas number;
BEGIN
  select round(trunc(to_date(p_DataHoraFim,'dd/mm/yyyy hh24:mi:ss') - To_Date(p_DataHoraInicio,'dd/mm/yyyy hh24:mi:ss'))/7,0)
  into semanas
  from dual;
 RETURN semanas;
END;
