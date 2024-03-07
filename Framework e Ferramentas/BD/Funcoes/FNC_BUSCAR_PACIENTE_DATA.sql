create or replace function FNC_BUSCAR_PACIENTE_DATA(pATD_ATE_ID in tb_ass_pat_pacieatend.atd_ate_id%type,
                                                    pDATA_ATENDIMENTO DATE)
/*
Buscar o paciente por atendimento/data
*/
 return NUMBER is
 result NUMBER; 
 
begin
  
begin
  select pat.cad_pac_id_paciente
    INTO result
    from tb_ass_pat_pacieatend pat
   where pat.atd_ate_id = pATD_ATE_ID
     and (
            (fnc_juntar_data_hora(pat.ass_pat_dt_entrada, pat.ass_pat_hr_entrada) <= pDATA_ATENDIMENTO and 
             pat.ass_pat_dt_saida is null) 
         or
            (fnc_juntar_data_hora(pat.ass_pat_dt_entrada, pat.ass_pat_hr_entrada) <= pDATA_ATENDIMENTO and
             fnc_juntar_data_hora(pat.ass_pat_dt_saida, pat.ass_pat_hr_saida)>= pDATA_ATENDIMENTO)
         );  
exception
  when others then
  result := 0;
end;      
        
  return(result);
end FNC_BUSCAR_PACIENTE_DATA;
