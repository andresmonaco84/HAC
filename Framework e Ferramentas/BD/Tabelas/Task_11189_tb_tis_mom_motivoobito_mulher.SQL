-- Add/modify columns 
alter table TB_TIS_MOM_MOTIVOOBITO_MULHER add tis_mom_fl_status char(1) default 'A';
-- Add comments to the columns 
comment on column TB_TIS_MOM_MOTIVOOBITO_MULHER.tis_mom_fl_status
  is 'Status';
-- Create/Recreate check constraints 
alter table TB_TIS_MOM_MOTIVOOBITO_MULHER
  add constraint CK_TIS_MOM_FL_STATUS
  check (TIS_MOM_FL_STATUS IN ('A','I'));
