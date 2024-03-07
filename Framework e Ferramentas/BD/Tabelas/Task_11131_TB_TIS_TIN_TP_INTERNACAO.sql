-- Add/modify columns 
alter table TB_TIS_TIN_TP_INTERNACAO add tis_tin_fl_status char(1) default 'A';
-- Add comments to the columns 
comment on column TB_TIS_TIN_TP_INTERNACAO.tis_tin_fl_status
  is 'Status';
-- Create/Recreate check constraints 
alter table TB_TIS_TIN_TP_INTERNACAO
  add constraint CK_TIS_TIN_FL_STATUS
  check (TIS_TIN_FL_STATUS in ('A','I'));
-- INATIVAR TIPO DE INTERNACAO NAO DEFINIDO
UPDATE TB_TIS_TIN_TP_INTERNACAO
SET TIS_TIN_FL_STATUS = 'I'
WHERE TIS_TIN_CD_INTERNACAO = 0;
COMMIT;
