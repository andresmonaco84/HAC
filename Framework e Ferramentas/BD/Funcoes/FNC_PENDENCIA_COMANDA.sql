 create or replace function FNC_PENDENCIA_COMANDA(pFAT_MCC_ID in number)
/*
  Retorna Maior Pendencia
*/
 return CHAR is
  retorno CHAR;
begin

  select to_char(max(mpf.cad_mpf_fl_motivo))
    into retorno
    from tb_fat_cci_conta_consu_item cci, tb_cad_mpf_moti_pend_faturar mpf
   where cci.fat_mcc_id = pFAT_MCC_ID
     and cci.cad_mpf_id = mpf.cad_mpf_id
     and cci.fat_cci_fl_status = 'A'
     and cci.cad_mpf_id is not null;

  return(retorno);
end FNC_PENDENCIA_COMANDA;