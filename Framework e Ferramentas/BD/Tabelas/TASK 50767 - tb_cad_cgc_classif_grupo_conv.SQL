-- Create table
create table TB_CAD_CGC_CLASSIF_GRUPO_CONV
(
  cad_cgc_id                 number,
  cad_cgc_ds_descricao       varchar2(50),
  cad_cgc_dt_ult_atualizacao date,
  seg_usu_id_usuario         number
)
;
-- Add comments to the columns 
comment on column TB_CAD_CGC_CLASSIF_GRUPO_CONV.cad_cgc_id
  is 'Idt';
comment on column TB_CAD_CGC_CLASSIF_GRUPO_CONV.cad_cgc_ds_descricao
  is 'Descricao';
comment on column TB_CAD_CGC_CLASSIF_GRUPO_CONV.cad_cgc_dt_ult_atualizacao
  is 'DataUltimaAtualizacao';
comment on column TB_CAD_CGC_CLASSIF_GRUPO_CONV.seg_usu_id_usuario
  is 'IdtUsuarioRegistrante';
-- Create/Recreate primary, unique and foreign key constraints 
alter table TB_CAD_CGC_CLASSIF_GRUPO_CONV
  add constraint PK_CAD_CGC primary key (CAD_CGC_ID);
alter table TB_CAD_CGC_CLASSIF_GRUPO_CONV
  add constraint FK_SEG_USU_CAD_CGC foreign key (SEG_USU_ID_USUARIO)
  references tb_seg_usu_usuario (SEG_USU_ID_USUARIO);
