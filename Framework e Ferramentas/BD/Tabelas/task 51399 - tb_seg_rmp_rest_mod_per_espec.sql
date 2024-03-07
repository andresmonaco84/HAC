-- Create table
create table TB_SEG_RMP_REST_MOD_PER_ESPEC
(
  seg_per_id_perfil          number,
  seg_mod_id_modulo          number,
  tis_cbo_cd_cbos            char(5),
  seg_rmp_dt_ult_atualizacao date,
  seg_usu_id_usuario         number
)
;
-- Add comments to the columns 
comment on column TB_SEG_RMP_REST_MOD_PER_ESPEC.seg_per_id_perfil
  is 'IdPerfil';
comment on column TB_SEG_RMP_REST_MOD_PER_ESPEC.seg_mod_id_modulo
  is 'IdtModulo';
comment on column TB_SEG_RMP_REST_MOD_PER_ESPEC.tis_cbo_cd_cbos
  is 'CódigoEspecialidade';
comment on column TB_SEG_RMP_REST_MOD_PER_ESPEC.seg_rmp_dt_ult_atualizacao
  is 'DataUltimaAtualizacao';
comment on column TB_SEG_RMP_REST_MOD_PER_ESPEC.seg_usu_id_usuario
  is 'IdtUsuarioRegistrante';
-- Create/Recreate primary, unique and foreign key constraints 
alter table TB_SEG_RMP_REST_MOD_PER_ESPEC
  add constraint PK_SEG_RMP primary key (SEG_PER_ID_PERFIL, SEG_MOD_ID_MODULO, TIS_CBO_CD_CBOS);
alter table TB_SEG_RMP_REST_MOD_PER_ESPEC
  add constraint FK_RMP_MPF_01 foreign key (SEG_PER_ID_PERFIL, SEG_MOD_ID_MODULO)
  references tb_seg_mpf_modulo_perfil (SEG_PER_ID_PERFIL, SEG_MOD_ID_MODULO);
alter table TB_SEG_RMP_REST_MOD_PER_ESPEC
  add constraint FK_RMP_CBO_02 foreign key (TIS_CBO_CD_CBOS)
  references tb_tis_cbo_cbos (TIS_CBO_CD_CBOS);
alter table TB_SEG_RMP_REST_MOD_PER_ESPEC
  add constraint FK_RMP_USU_03 foreign key (SEG_USU_ID_USUARIO)
  references tb_seg_usu_usuario (SEG_USU_ID_USUARIO);
