create or replace function FNC_VALIDAR_VIGENCIA(pDATA_INICIO in DATE,
                                                pDATA_FIM    in DATE DEFAULT NULL)
/*
  VALIDAR VIGENCIA ATUAL
  */
 return NUMBER is
  Result NUMBER;
begin

  Result := FNC_VALIDAR_VIGENCIA_DATA(pDATA_INICIO, pDATA_FIM, SYSDATE);

  return(Result);

end FNC_VALIDAR_VIGENCIA;
