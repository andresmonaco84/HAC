-- Add/modify columns 
alter table TB_REP_RPA_RESUMO_PAGTO add rep_rpa_fl_antecipacao CHAR(1) default 'N';
-- Add comments to the columns 
comment on column TB_REP_RPA_RESUMO_PAGTO.rep_rpa_fl_antecipacao
  is 'FlagAntecipacao';