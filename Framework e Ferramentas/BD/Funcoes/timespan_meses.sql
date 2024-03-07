create or replace FUNCTION timespan_meses
(
       p_DataHoraInicio in Date,
       p_DataHoraFim    in Date
)
  RETURN NUMBER
 IS
  meses number;
BEGIN
  select round(months_between (to_date(p_DataHoraFim,'dd/mm/yyyy hh24:mi:ss'), to_date(p_DataHoraInicio,'dd/mm/yyyy hh24:mi:ss')))
  into meses
  from dual;
 RETURN meses;
END;
