CREATE OR REPLACE FUNCTION FNC_EXECUTESCALAR(query in varchar2)
/*
Executa uma query e retorna o primeiro resultado 
*/
 return number is
  Result number;  
v_cursor PKG_CURSOR.t_cursor;
begin
	


BEGIN

		
    OPEN v_cursor FOR query;
    LOOP
        FETCH v_cursor INTO RESULT;
        EXIT WHEN v_cursor%NOTFOUND;
        -- process row here
    END LOOP;
    CLOSE v_cursor;
END;




  return(Result);
end FNC_EXECUTESCALAR;
 