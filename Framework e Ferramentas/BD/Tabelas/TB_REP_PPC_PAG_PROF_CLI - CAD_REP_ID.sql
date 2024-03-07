-- Add/modify columns 
alter table TB_REP_PPC_PAG_PROF_CLI add cad_rep_id NUMBER null;
-- Add comments to the columns 
comment on column TB_REP_PPC_PAG_PROF_CLI.cad_rep_id
  is 'IdtRegraPagamento';
