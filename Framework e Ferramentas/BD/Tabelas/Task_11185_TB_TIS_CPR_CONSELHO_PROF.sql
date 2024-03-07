-- Add/modify columns 
alter table TB_TIS_CPR_CONSELHO_PROF add tis_cpr_cd_conselhoprof_v3 VARCHAR2(2);
-- Add comments to the columns 
comment on column TB_TIS_CPR_CONSELHO_PROF.tis_cpr_cd_conselhoprof_v3
  is 'ConselhoProfissionalVersao3';
-- Add/modify columns 
alter table TB_TIS_CPR_CONSELHO_PROF add tis_cpr_fl_status char(1) default 'A';
-- Add comments to the columns 
comment on column TB_TIS_CPR_CONSELHO_PROF.tis_cpr_fl_status
  is 'Status';
-- Create/Recreate check constraints 
alter table TB_TIS_CPR_CONSELHO_PROF
  add constraint CK_TIS_CPR_FL_STATUS
  check (TIS_CPR_FL_STATUS IN ('A','I'));
