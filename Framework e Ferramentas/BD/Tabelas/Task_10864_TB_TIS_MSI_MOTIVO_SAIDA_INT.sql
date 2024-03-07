-- Add/modify columns 
alter table TB_TIS_MSI_MOTIVO_SAIDA_INT add tis_msi_fl_status char(1) default 'A';
-- Add comments to the columns 
comment on column TB_TIS_MSI_MOTIVO_SAIDA_INT.tis_msi_fl_status
  is 'Status';
-- Create/Recreate check constraints 
alter table TB_TIS_MSI_MOTIVO_SAIDA_INT
  add constraint CK_TIS_MSI_FL_STATUS
  check (TIS_MSI_FL_STATUS IN ('A','I'));
-- INATIVAR MOTIVOS COM A DESCRIÇÃO NAO UTILIZAR
update tb_tis_msi_motivo_saida_int
set tis_msi_fl_status = 'I'
where tis_msi_ds_motivosaidaint like 'NÃO UTILIZAR%';
COMMIT;