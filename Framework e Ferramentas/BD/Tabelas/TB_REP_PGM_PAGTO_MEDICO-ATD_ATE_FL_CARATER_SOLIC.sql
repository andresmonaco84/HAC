alter table TB_REP_PGM_PAGTO_MEDICO add atd_ate_fl_carater_solic CHAR(1);
-- Add comments to the columns 
comment on column TB_REP_PGM_PAGTO_MEDICO.atd_ate_fl_carater_solic
  is 'CaraterSolicitacao'