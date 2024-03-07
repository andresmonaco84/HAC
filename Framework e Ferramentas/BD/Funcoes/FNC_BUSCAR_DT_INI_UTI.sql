create or replace function FNC_BUSCAR_DT_INI_UTI(pATD_ATE_ID in tb_ass_pat_pacieatend.atd_ate_id%type)
/*
Buscar a 1 data int na uti
*/
 return DATE is
 Result DATE;
begin

if (pATD_ATE_ID is not null) THEN
    select MIN(iml.atd_iml_dt_entrada)
    INTO RESULT
  from tb_atd_iml_int_mov_leito iml
  join tb_cad_qle_quarto_leito qle on qle.cad_qle_id = iml.cad_cad_qle_id
  join tb_cad_set_setor s on s.cad_set_id = qle.cad_set_id and S.CAD_CSE_ID=6
  WHERE IML.ATD_ATE_ID = pATD_ATE_ID
;
END if;
  return(Result);
end FNC_BUSCAR_DT_INI_UTI;
