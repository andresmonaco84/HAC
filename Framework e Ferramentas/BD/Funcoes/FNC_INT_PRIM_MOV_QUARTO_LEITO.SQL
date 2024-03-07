CREATE OR REPLACE FUNCTION "FNC_INT_PRIM_MOV_QUARTO_LEITO"(pATD_ATE_ID IN TB_ATD_IML_INT_MOV_LEITO.ATD_ATE_ID%TYPE)
  return NUMBER is
  sResultado NUMBER;
begin
  sResultado := 0;
  for i in (select iml.atd_ate_id,
                   min(iml.atd_iml_dt_entrada || iml.atd_iml_hr_entrada ||
                       iml.atd_iml_dt_saida || iml.atd_iml_hr_saida),
                   iml.atd_iml_id
              from tb_atd_iml_int_mov_leito iml,
              tb_cad_qle_quarto_leito qle,
              tb_cad_set_setor setor
             where iml.atd_ate_id = pATD_ATE_ID
             and iml.CAD_CAD_QLE_ID = qle.cad_qle_id
             and qle.cad_set_id = setor.cad_set_id
           --  and setor.CAD_SET_ID NOT IN (2072,2312,5)
             group by iml.atd_ate_id,
                      iml.atd_iml_dt_entrada,
                      iml.atd_iml_hr_entrada,
                      iml.atd_iml_dt_saida,
                      iml.atd_iml_hr_saida,
                      iml.atd_iml_id
             order by iml.atd_ate_id,
                      iml.atd_iml_dt_entrada,
                      iml.atd_iml_hr_entrada,
                      iml.atd_iml_dt_saida,
                      iml.atd_iml_hr_saida,
                      iml.atd_iml_id) loop
    sResultado := i.atd_iml_id;
    exit when sResultado > 0;
  end loop;
  return(sResultado);
end FNC_INT_PRIM_MOV_QUARTO_LEITO;
