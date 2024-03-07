-- Create table
create table TB_CAD_CSE_CATEGORIA_SETOR
(
  cad_cse_id                 number,
  cad_cse_ds_categoria       varchar2(50),
  cad_cse_dt_ult_atualizacao date,
  seg_usu_id_usuario         number
)
;
-- Create/Recreate primary, unique and foreign key constraints 
alter table TB_CAD_CSE_CATEGORIA_SETOR
  add constraint PK_CAD_CSE primary key (CAD_CSE_ID);
alter table TB_CAD_CSE_CATEGORIA_SETOR
  add constraint FK_SEG_USU_CAD_CSE_01 foreign key (SEG_USU_ID_USUARIO)
  references tb_seg_usu_usuario (SEG_USU_ID_USUARIO);

-- Add comments to the columns 
comment on column TB_CAD_CSE_CATEGORIA_SETOR.cad_cse_id
  is 'Idt';
comment on column TB_CAD_CSE_CATEGORIA_SETOR.cad_cse_ds_categoria
  is 'Descricao';
comment on column TB_CAD_CSE_CATEGORIA_SETOR.cad_cse_dt_ult_atualizacao
  is 'DataUltimaAtualizacao';
comment on column TB_CAD_CSE_CATEGORIA_SETOR.seg_usu_id_usuario
  is 'IdtUsuario';