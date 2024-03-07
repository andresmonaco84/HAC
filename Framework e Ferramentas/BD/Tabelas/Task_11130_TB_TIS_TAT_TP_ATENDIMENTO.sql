-- Add/modify columns 
alter table TB_TIS_TAT_TP_ATENDIMENTO add tis_tat_fl_status char(1) default 'A';
-- Add comments to the columns 
comment on column TB_TIS_TAT_TP_ATENDIMENTO.tis_tat_fl_status
  is 'Status';
-- Create/Recreate check constraints 
alter table TB_TIS_TAT_TP_ATENDIMENTO
  add constraint CK_TIS_TAT_FL_STATUS
  check (TIS_TAT_FL_STATUS IN ('A','I'));
