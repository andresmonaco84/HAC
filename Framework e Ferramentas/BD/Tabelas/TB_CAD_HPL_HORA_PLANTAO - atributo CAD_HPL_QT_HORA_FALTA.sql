
-- Add/modify columns 
alter table TB_CAD_HPL_HORA_PLANTAO add CAD_HPL_QT_HORA_FALTA number;
-- Add comments to the columns 
comment on column TB_CAD_HPL_HORA_PLANTAO.CAD_HPL_QT_HORA_FALTA
  is 'QuantidadeHoraFalta';
