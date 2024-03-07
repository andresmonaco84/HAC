-- Add/modify columns 
alter table TB_TIS_IAC_INDACIDENTE add tis_iac_fl_status char(1) default 'A';
-- Add comments to the columns 
comment on column TB_TIS_IAC_INDACIDENTE.tis_iac_fl_status
  is 'Status';
-- Create/Recreate check constraints 
alter table TB_TIS_IAC_INDACIDENTE
  add constraint CK_TIS_IAC_FL_STATUS
  check (TIS_IAC_FL_STATUS IN ('A','I'));
