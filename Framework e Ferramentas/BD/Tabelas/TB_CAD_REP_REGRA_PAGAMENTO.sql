
/* 18/05/2012 */
alter table TB_CAD_REP_REGRA_PAGAMENTO modify (CAD_PRD_ID null);

/* 09/05/2012 
-- Add/modify columns 
alter table TB_CAD_REP_REGRA_PAGAMENTO add CAD_REP_VL_MINIMO NUMBER(12,2);

-- Add comments to the columns 
comment on column TB_CAD_REP_REGRA_PAGAMENTO.CAD_REP_VL_MINIMO is 'ValorMinimo';
*/