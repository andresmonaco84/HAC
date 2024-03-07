-- Add/modify columns 
alter table TB_CAD_CNV_CONVENIO add cad_cgc_id number;
-- Add comments to the columns 
comment on column TB_CAD_CNV_CONVENIO.cad_cgc_id
  is 'IdtClassificacaoGrupoConvenio';
-- Create/Recreate primary, unique and foreign key constraints 
alter table TB_CAD_CNV_CONVENIO
  add constraint FK_CGC_CNV foreign key (CAD_CGC_ID)
  references tb_cad_cgc_classif_grupo_conv (CAD_CGC_ID);
