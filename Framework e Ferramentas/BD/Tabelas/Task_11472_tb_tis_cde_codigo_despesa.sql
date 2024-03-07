-- Add/modify columns 
alter table TB_TIS_CDE_CODIGO_DESPESA add tis_cde_cd_codigo_despesa_v3 VARCHAR2(2);
alter table TB_TIS_CDE_CODIGO_DESPESA add tis_cde_ds_observacao VARCHAR2(50);
-- Add comments to the columns 
comment on column TB_TIS_CDE_CODIGO_DESPESA.tis_cde_cd_codigo_despesa_v3
  is 'CodigoDespesaVersao3';
comment on column TB_TIS_CDE_CODIGO_DESPESA.tis_cde_ds_observacao
  is 'Observacao';
