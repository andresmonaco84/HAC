-- Create/Recreate check constraints 
alter table TB_ATD_CIR_CIRURGIA_REALIZADA
  drop constraint CK_ATD_CIR_01;
alter table TB_ATD_CIR_CIRURGIA_REALIZADA
  add constraint CK_ATD_CIR_01
  check (ATD_CIR_FL_SITUACAO IN ('A','I','E'));