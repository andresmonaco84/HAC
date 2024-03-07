-- Add/modify columns 
alter table TB_ATS_ATE_ATENDIMENTO_SADT add ats_ate_fl_exame_com_biopsia CHAR(1) default 'N';
-- Add comments to the columns 
comment on column TB_ATS_ATE_ATENDIMENTO_SADT.ats_ate_fl_exame_com_biopsia
  is 'FlagExameComBiopsia';
