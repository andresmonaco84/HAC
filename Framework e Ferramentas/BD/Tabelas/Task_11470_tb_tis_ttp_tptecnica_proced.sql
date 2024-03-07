-- Add/modify columns 
alter table TB_TIS_TTP_TPTECNICA_PROCED add tis_ttp_cd_tptecnica_v3 CHAR(1);
alter table TB_TIS_TTP_TPTECNICA_PROCED add tis_ttp_ds_observacao VARCHAR2(50);
-- Add comments to the columns 
comment on column TB_TIS_TTP_TPTECNICA_PROCED.tis_ttp_cd_tptecnica_v3
  is 'TecnicaUtilizadaVersao3';
comment on column TB_TIS_TTP_TPTECNICA_PROCED.tis_ttp_ds_observacao
  is 'Observacao';
-- Add/modify columns 
alter table TB_TIS_TTP_TPTECNICA_PROCED add tis_ttp_fl_status char(1) default 'A';
-- Add comments to the columns 
comment on column TB_TIS_TTP_TPTECNICA_PROCED.tis_ttp_fl_status
  is 'Status';
-- Create/Recreate check constraints 
alter table TB_TIS_TTP_TPTECNICA_PROCED
  add constraint CK_TIS_TTP_FL_STATUS
  check (TIS_TTP_FL_STATUS IN ('A','I'));
