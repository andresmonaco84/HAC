-- Add/modify columns 
alter table TB_CAD_REP_REGRA_PAGAMENTO add cad_rep_ds_complementar varchar2(50);
-- Add comments to the columns 
comment on column TB_CAD_REP_REGRA_PAGAMENTO.cad_rep_ds_complementar
  is 'DescricaoComplementar';