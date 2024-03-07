-- Add/modify columns 
alter table TB_TIS_TAC_TIPO_ACOMODACAO add tis_tac_fl_status char(1) default 'A';
-- Add comments to the columns 
comment on column TB_TIS_TAC_TIPO_ACOMODACAO.tis_tac_fl_status
  is 'Status';
-- Create/Recreate check constraints 
alter table TB_TIS_TAC_TIPO_ACOMODACAO
  add constraint CK_TIS_TAC_FL_STATUS
  check (TIS_TAC_FL_STATUS IN ('A','I'));
-- INATIVAR TIPOS NÃO UTILIZADOS NO REPASSE
UPDATE TB_TIS_TAC_TIPO_ACOMODACAO
SET TIS_TAC_FL_STATUS = 'I'
WHERE TIS_TAC_FL_UTILIZA_REPASSE = 'N';
COMMIT;
