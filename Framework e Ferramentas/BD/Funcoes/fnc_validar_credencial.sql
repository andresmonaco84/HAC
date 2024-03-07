create or replace function fnc_validar_credencial(pCAD_CNV_ID_CONVENIO in number,
                                                  pCREDENCIAL          in varchar2)
  return NUMBER is
  retorno NUMBER;
  mascara varchar2(70);
  modulo  number;
  digitos number;
  ini     number;
  fim     number;
  crd     varchar2(70);
  unica   varchar2(70);
  cnvhac  varchar2(10);
  function fnc_is_number(p_string in varchar2) return int is
    v_new_num number;
  begin
    v_new_num := to_number(p_string);
    return 1;
  exception
    when value_error then
      return 0;
  end fnc_is_number;
begin

  crd := pCREDENCIAL;

  select cnv.cad_cnv_cd_modvalidador,
         cnv.cad_cnv_ds_masc_mascaramatri,
         cnv.cad_cnv_qt_digcredvalidador,
         cnv.cad_cnv_nr_inicredvalidador,
         cnv.cad_cnv_nr_fimcredvalidador,
         cnv.cad_cnv_cd_hac_prestador
    into modulo, mascara, digitos, ini, fim, cnvhac
    from tb_cad_cnv_convenio cnv
   where cnv.cad_cnv_id_convenio = pCAD_CNV_ID_CONVENIO;

  if (digitos > 0 and crd is null) then
    return 0;
  end if;

  if (cnvhac in ('PA__', 'NP01', 'NR14')) then
    return 1;
  end if;

  if (crd is not null) then
  
    if (modulo is not null and modulo > 0) then
    
      if (modulo = 1) then
        unica := replace(replace(crd, '-', ''), '/', '');
      
        if (length(unica) < digitos) then
          return 0;
        end if;
      
        if (length(unica) < (ini + fim)) then
          return 0;
        end if;
      
        begin
          retorno := fnc_modulo_10(unica, 2);
        exception
          when others then
            --      dbms_output.put_line(SQLCODE||' - ERROR - '||SQLERRM);
            return 0;
        end;
      
        if (retorno = 0) then
          return 0;
        end if;
      
      end if;
    
      if (modulo = 2) then
        unica := replace(replace(crd, '-', ''), '/', '');
      
        if (length(unica) < 15) then
          return 0;
        end if;
      
        if (length(unica) > 0) then
        
          begin
            retorno := fnc_modulo_10_brad(unica);
          exception
            when others then
              --    dbms_output.put_line(SQLCODE||' - ERROR - '||SQLERRM);
              return 0;
          end;
        
          if (substr(unica, 15, 1) <> to_char(retorno)) then
            return 0;
          end if;
        
        end if;
      
      end if;
    
      if (modulo = 3) then
        unica := replace(replace(crd, '-', ''), '/', '');
      
        if (length(unica) < digitos) then
          return 0;
        end if;
      
        if (length(unica) < (ini + fim)) then
          return 0;
        end if;
      
        if (cnvhac = 'SW32') then
          unica := substr(unica, ini + 1);
        else
          unica := substr(unica, ini + 1, fim);
        end if;
      
        begin
          -- retorno := fnc_modulo_11(unica, digitos);
          retorno := fnc_sgs_mod11(unica);
        exception
          when others then
          --  dbms_output.put_line(SQLCODE || ' - ERROR - ' || SQLERRM);
            return 0;
        end;
      
        if (retorno <> 0) then
          return 0;
        end if;
      
      end if;
    
    end if;
  
  end if;

  if (mascara is not null and length(mascara) > 0) then
  
    if (length(mascara) <> length(crd)) then
      return 0;
    else
    
      for i in 1 .. length(crd) Loop
        if (fnc_is_number(substr(mascara, i, 1)) = 1 and
           fnc_is_number(substr(crd, i, 1)) = 0) then
          return 0;
        end if;
      
        if (length(trim(translate(substr(mascara, i, 1),
                                  'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ',
                                  ' '))) is null and
           length(trim(translate(substr(crd, i, 1),
                                  'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ',
                                  ' '))) is not null) then
          return 0;
        end if;
      
      end loop;
    
    end if;
  
  end if;

  return 1;

end fnc_validar_credencial;
/
