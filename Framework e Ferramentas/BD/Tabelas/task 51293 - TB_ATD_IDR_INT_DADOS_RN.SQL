-- Add/modify columns 
alter table TB_ATD_IDR_INT_DADOS_RN add atd_idr_hr_nascimento number(4);
-- Add comments to the columns 
comment on column TB_ATD_IDR_INT_DADOS_RN.atd_idr_hr_nascimento
  is 'HoraNascimento';
