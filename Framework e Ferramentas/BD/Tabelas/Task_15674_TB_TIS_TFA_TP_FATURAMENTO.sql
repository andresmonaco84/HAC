-- Add/modify columns 
alter table TB_TIS_TFA_TP_FATURAMENTO add tis_tfa_cd_tpfaturamento_v3 CHAR(1);
alter table TB_TIS_TFA_TP_FATURAMENTO add tis_tfa_observacao VARCHAR2(50);
-- Add comments to the columns 
comment on column TB_TIS_TFA_TP_FATURAMENTO.tis_tfa_cd_tpfaturamento_v3
  is 'TipoFaturamentoVersao3 ';
comment on column TB_TIS_TFA_TP_FATURAMENTO.tis_tfa_observacao
  is 'Observacao';