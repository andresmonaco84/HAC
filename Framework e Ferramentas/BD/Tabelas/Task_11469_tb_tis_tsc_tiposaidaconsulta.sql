-- Add/modify columns 
alter table TB_TIS_TSC_TIPOSAIDACONSULTA add tis_tsc_fl_status char(1) default 'A';
-- Add comments to the columns 
comment on column TB_TIS_TSC_TIPOSAIDACONSULTA.tis_tsc_fl_status
  is 'Status';
-- Create/Recreate check constraints 
alter table TB_TIS_TSC_TIPOSAIDACONSULTA
  add constraint CK_TIS_TSC_FL_STATUS
  check (TIS_TSC_FL_STATUS IN ('A','I'));
