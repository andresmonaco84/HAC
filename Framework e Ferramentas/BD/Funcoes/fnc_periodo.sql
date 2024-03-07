CREATE OR REPLACE FUNCTION fnc_periodo (dataini in date, datafim in date) RETURN type_split_table IS
v_char type_split_table := type_split_table();
dia date;
--datas varchar2(4000);
c number;
begin
c := 1;  
--datas := '';
dia := dataini;

while(dia <= datafim)
loop  
--  datas := to_char(dia) || ',' || datas;
  v_char.EXTEND;
  v_char(c) := to_char(dia);
  dia := dia +1;
  c := c+1;
end loop;

--dbms_output.put_line(datas);  

return(v_char);

end fnc_periodo;
 