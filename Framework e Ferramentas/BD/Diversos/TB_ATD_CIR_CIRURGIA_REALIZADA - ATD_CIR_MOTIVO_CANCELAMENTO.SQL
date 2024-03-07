-- Add/modify columns 
alter table TB_ATD_CIR_CIRURGIA_REALIZADA add atd_cir_motivo_cancelamento varchar2(100);
-- Add comments to the columns 
comment on column TB_ATD_CIR_CIRURGIA_REALIZADA.atd_cir_motivo_cancelamento
  is 'MotivoCancelamento';