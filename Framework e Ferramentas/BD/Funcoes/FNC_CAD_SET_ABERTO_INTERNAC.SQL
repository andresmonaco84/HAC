create or replace function FNC_CAD_SET_ABERTO_INTERNAC(pCAD_SET_ID in TB_CAD_SET_SETOR.CAD_SET_ID%type)
/*

*/
 
 
 return NUMBER IS Result NUMBER;
 todos integer;
 fechados integer;
 
begin

select COUNT(QLE.CAD_QLE_ID)    INTO fechados
  from TB_CAD_QLE_QUARTO_LEITO QLE
 where QLE.CAD_SET_id = pCAD_SET_ID
   and QLE.CAD_QLE_TP_QUARTO_LEITO = 'I' AND QLE.CAD_SQL_CD_SIT_QUARTO_LEITO = 5   ;
   
   select COUNT(QLE.CAD_QLE_ID)    INTO todos
  from TB_CAD_QLE_QUARTO_LEITO QLE
 where QLE.CAD_SET_id = pCAD_SET_ID 
 and QLE.CAD_QLE_TP_QUARTO_LEITO = 'I'  ;

IF (todos != fechados) 
          THEN RESULT:=1; --ABERTO          
          ELSE RESULT:=0; --FECHADO
END IF;

  return(RESULT);
end FNC_CAD_SET_ABERTO_INTERNAC;
