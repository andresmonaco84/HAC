create or replace function FNC_JUNTAR_DATA_HORA(pData in DATE,
                                           pHora in varchar)
/*
Concatena Data e Hora e retorna a Data
*/
 return DATE is
  Result DATE;
begin

if (pData is not null AND pHora is not null) THEN
  SELECT to_date(to_char(pData) || ' ' || to_char(lpad(pHora, 4, 0)),
                 'DD/MM/YY HH24MI')
    INTO RESULT
    FROM dual;
END if;

  return(Result);
end FNC_JUNTAR_DATA_HORA;
