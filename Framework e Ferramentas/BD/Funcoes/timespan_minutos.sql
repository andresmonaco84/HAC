CREATE OR REPLACE FUNCTION timespan_minutos
(
       p_DataHoraInicio in Date,
       p_DataHoraFim    in Date
)
  RETURN NUMBER
 IS
  horas number;
BEGIN
  select trunc(((to_date(p_DataHoraFim, 'dd/MM/yyyy hh24:mi:ss') - to_date(p_DataHoraInicio, 'dd/MM/yyyy hh24:mi:ss')) * 24) * 60)  minutos 
  into horas
  from dual;
 RETURN horas;
END;