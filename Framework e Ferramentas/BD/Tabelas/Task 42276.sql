-- Create/Recreate check constraints 
alter table TB_ATD_ATE_ATENDIMENTO
  drop constraint CK_ATD_ATE_FL_STATUS;
alter table TB_ATD_ATE_ATENDIMENTO
  add constraint CK_ATD_ATE_FL_STATUS
  check (ATD_ATE_FL_STATUS IN ('A','C','D','F'));
