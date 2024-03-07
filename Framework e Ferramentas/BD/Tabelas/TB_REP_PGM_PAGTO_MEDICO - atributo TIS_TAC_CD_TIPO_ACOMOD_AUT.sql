
-- Add/modify columns 
alter table TB_REP_PGM_PAGTO_MEDICO add TIS_TAC_CD_TIPO_ACOMOD_AUT CHAR(2);

-- Add comments to the columns 
comment on column TB_REP_PGM_PAGTO_MEDICO.TIS_TAC_CD_TIPO_ACOMOD_AUT is 'CodigoSubGrupoProduto';
