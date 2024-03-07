-- Add/modify columns 
alter table TB_TIS_TVA_TP_VIA_ACESSO add tis_tva_cd_viaacesso_v3 CHAR(1);
-- Add comments to the columns 
comment on column TB_TIS_TVA_TP_VIA_ACESSO.tis_tva_cd_viaacesso_v3
  is 'ViaAcessoVersao3';
-- Add/modify columns 
alter table TB_TIS_TVA_TP_VIA_ACESSO add tis_tva_fl_status char(1) default 'A';
-- Add comments to the columns 
comment on column TB_TIS_TVA_TP_VIA_ACESSO.tis_tva_fl_status
  is 'Status';
-- Create/Recreate check constraints 
alter table TB_TIS_TVA_TP_VIA_ACESSO
  add constraint CK_TIS_TVA_FL_STATUS
  check (TIS_TVA_FL_STATUS IN ('A','I'));
