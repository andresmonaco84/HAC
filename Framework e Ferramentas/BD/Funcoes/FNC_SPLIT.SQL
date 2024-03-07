CREATE OR REPLACE TYPE type_split_table IS TABLE OF VARCHAR2(8000) NOT NULL;

CREATE OR REPLACE FUNCTION fnc_split ( p_string_in IN VARCHAR2) RETURN type_split_table IS
v_char type_split_table := type_split_table();
v_string_in VARCHAR2(8000);
x_string VARCHAR2(8000);
ix NUMBER;
i1 NUMBER;
i2 NUMBER;
/* Delimitador padrao virgula*/
delimiter VARCHAR2(1) := ',';
BEGIN    
    if(instr(v_string_in, delimiter) = 0) then
    /* Se existir so um parametro*/
      v_char.EXTEND;
      v_char(1) := p_string_in;                      
    else 
      IF(p_string_in IS NOT NULL) THEN
    /* Se existir delimitador faz o split*/
        v_string_in := delimiter || p_string_in;
        i1 := instr(v_string_in, delimiter);
        ix := 1;
        i2 := 1;
        LOOP   
        x_string := Substr(v_string_in, i1 + 1, LENGTH(v_string_in));
           
        if(instr(x_string, delimiter) > 0) then
           /* Procura posicao delimitador */      
           for i in 1..LENGTH(x_string)
           loop
             if(Substr(x_string,i,1) = delimiter) then
               i2 := i;
               exit;
             end if;
           end loop;
           x_string := Substr(v_string_in, i1 + 1, i2 - 1);
        end if;

        /* Nao permite inserir nulo */
        IF(x_string IS NOT NULL) THEN
          v_char.EXTEND;
          v_char(ix) := x_string;
          ix := ix + 1;
        END IF;
          
        i1 := instr(v_string_in, delimiter, i1 + 1);
        exit when i1 = 0;      
        END LOOP;
      END IF;
    end if;
    
RETURN v_CHAR;
END;