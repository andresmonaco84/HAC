-- Add/modify columns 
alter table TB_TIS_CBO_CBOS add tis_cbo_cd_cbos_v3 VARCHAR2(6);
-- Add comments to the columns 
comment on column TB_TIS_CBO_CBOS.tis_cbo_cd_cbos_v3
  is 'CodigoCboVersao3';
-- Add/modify columns 
alter table TB_TIS_CBO_CBOS add tis_cbo_fl_status char(1) default 'A';
-- Add comments to the columns 
comment on column TB_TIS_CBO_CBOS.tis_cbo_fl_status
  is 'Status';
-- Create/Recreate check constraints 
alter table TB_TIS_CBO_CBOS
  add constraint CK_TIS_CBO_FL_STATUS
  check (TIS_CBO_FL_STATUS IN ('A','I'));
