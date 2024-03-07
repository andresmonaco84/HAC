-- Create table
create table TB_ATD_IFV_INT_FALTA_VAGA
(
  ATD_IFV_ID                    number(10),
  ATD_ATE_ID                    number(10),
  ATD_IML_ID                    number(10),
  ATD_IFV_DS_JUSTIFICATIVA      varchar2(200),
  SEG_USU_ID_USUARIO_DESB       number(10),
  ATD_IFV_DT_FALTA_VAGA         date,
  SEG_USU_ID_USUARIO_REG        number(10),
  ATD_IFV_DT_ULTIMA_ATUALIZACAO date
)
;
-- Add comments to the table 
comment on table TB_ATD_IFV_INT_FALTA_VAGA
  is 'InternadoFaltaVagaTipoAcomodacao';
-- Add comments to the columns 
comment on column TB_ATD_IFV_INT_FALTA_VAGA.ATD_IFV_ID
  is 'IdtFaltaVagaTipoAcomodacao';
comment on column TB_ATD_IFV_INT_FALTA_VAGA.ATD_ATE_ID
  is 'IdtAtendimento';
comment on column TB_ATD_IFV_INT_FALTA_VAGA.ATD_IML_ID
  is 'IdtMovimentacaoQuartoLeito';
comment on column TB_ATD_IFV_INT_FALTA_VAGA.ATD_IFV_DS_JUSTIFICATIVA
  is 'DescricaoJustificativa';
comment on column TB_ATD_IFV_INT_FALTA_VAGA.SEG_USU_ID_USUARIO_DESB
  is 'IdtUsuarioDesbloqueioRegistro';
comment on column TB_ATD_IFV_INT_FALTA_VAGA.ATD_IFV_DT_FALTA_VAGA
  is 'DataRegistroFaltaVaga';
comment on column TB_ATD_IFV_INT_FALTA_VAGA.SEG_USU_ID_USUARIO_REG
  is 'IdtUsuarioRegistrante';
comment on column TB_ATD_IFV_INT_FALTA_VAGA.ATD_IFV_DT_ULTIMA_ATUALIZACAO
  is 'DataUltimaAtualizacao';
-- Create/Recreate primary, unique and foreign key constraints 
alter table TB_ATD_IFV_INT_FALTA_VAGA
  add constraint PK_ATD_IFV_ID primary key (ATD_IFV_ID);
alter table TB_ATD_IFV_INT_FALTA_VAGA
  add constraint FK_IML_IFV_01 foreign key (ATD_IML_ID)
  references tb_atd_iml_int_mov_leito (ATD_IML_ID);
alter table TB_ATD_IFV_INT_FALTA_VAGA
  add constraint FK_USU_IFV_01 foreign key (SEG_USU_ID_USUARIO_DESB)
  references tb_seg_usu_usuario (SEG_USU_ID_USUARIO);
alter table TB_ATD_IFV_INT_FALTA_VAGA
  add constraint FK_USU_IFV_02 foreign key (SEG_USU_ID_USUARIO_REG)
  references tb_seg_usu_usuario (SEG_USU_ID_USUARIO);
-- Create/Recreate indexes 
create index ATD_IFV_IND_01 on TB_ATD_IFV_INT_FALTA_VAGA (atd_ate_id);
create index ATD_IFV_IND_02 on TB_ATD_IFV_INT_FALTA_VAGA (atd_ifv_ds_justificativa);
create index ATD_IFV_IND_03 on TB_ATD_IFV_INT_FALTA_VAGA (atd_iml_id);
create index ATD_IFV_IND_04 on TB_ATD_IFV_INT_FALTA_VAGA (atd_ifv_dt_falta_vaga);