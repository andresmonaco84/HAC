CREATE OR REPLACE FUNCTION "FNC_VALIDAR_PERIODO" (pDATA_INICIO in DATE,
                                                pDATA_FIM in DATE DEFAULT NULL,
                                                pDATA_VALIDAR in DATE)
/*
VALIDAR VIGENCIA POR DATA
*/
 return NUMBER is
 Result NUMBER;
begin

Result := 0;

if(pDATA_INICIO > SYSDATE) THEN
   Result := 0;
else
   if (pDATA_INICIO  <= pDATA_VALIDAR AND pDATA_FIM IS NULL) THEN
      Result := 1;
   else
      if(pDATA_INICIO  <= pDATA_VALIDAR AND pDATA_FIM >= pDATA_VALIDAR) THEN
         Result := 1;
      else
         Result := 0;
      END IF;
    END IF;
END if;

  return(Result);

end FNC_VALIDAR_PERIODO;
 
/
