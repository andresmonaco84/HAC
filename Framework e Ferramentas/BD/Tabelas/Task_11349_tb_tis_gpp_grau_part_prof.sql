-- Add/modify columns 
alter table TB_TIS_GPP_GRAU_PART_PROF add tis_gpp_fl_status char(1) default 'A';
-- Add comments to the columns 
comment on column TB_TIS_GPP_GRAU_PART_PROF.tis_gpp_fl_status
  is 'Status';
-- Create/Recreate check constraints 
alter table TB_TIS_GPP_GRAU_PART_PROF
  add constraint CK_TIS_GPP_FL_STATUS
  check (TIS_GPP_FL_STATUS IN ('A','I'));
