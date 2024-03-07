create or replace function FNC_BUSCAR_PACIENTE_ATUAL(pATD_ATE_ID in tb_ass_pat_pacieatend.atd_ate_id%type)
/*
Buscar o paciente atual (com alta ou nao) de uma internacao
*/
 return NUMBER is
 Result NUMBER;
begin

if (pATD_ATE_ID is not null) THEN      
    select pat.cad_pac_id_paciente
    INTO RESULT
  from tb_ass_pat_pacieatend pat
 where pat.atd_ate_id = pATD_ATE_ID
   and fnc_juntar_data_hora(pat.ass_pat_dt_entrada, pat.ass_pat_hr_entrada) =
       (select max(fnc_juntar_data_hora(pat.ass_pat_dt_entrada,
                                        pat.ass_pat_hr_entrada))
          from tb_atd_ate_atendimento ate, tb_ass_pat_pacieatend pat
         where ate.atd_ate_id = pATD_ATE_ID
           and pat.atd_ate_id = ate.atd_ate_id);
END if;

  return(Result);
end FNC_BUSCAR_PACIENTE_ATUAL;
