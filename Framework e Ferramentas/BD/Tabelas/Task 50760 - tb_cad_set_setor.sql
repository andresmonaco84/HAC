-- Add/modify columns 
alter table TB_CAD_SET_SETOR add cad_cse_id number;
-- Add comments to the columns 
comment on column TB_CAD_SET_SETOR.cad_cse_id
  is 'IdtCategoria';
