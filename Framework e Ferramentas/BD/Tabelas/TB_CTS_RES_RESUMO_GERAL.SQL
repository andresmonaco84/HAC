-- Create table
create table TB_CTS_RES_RESUMO_GERAL
(
  seq_cts_res_resumo_01          NUMBER not null,
  cts_res_resu_tipo              VARCHAR2(1) not null,
  cts_res_resu_mes               NUMBER not null,
  cts_res_resu_ano               NUMBER not null,
  cts_res_resu_cad_cts_plc_id    NUMBER not null,
  cts_res_resu_cad_cts_cd_conta  VARCHAR2(40),
  cts_res_resu_cad_cts_cd_nivel  NUMBER,
  cts_res_resu_cad_cts_ds_descri VARCHAR2(60),
  cts_res_resu_vl_rec_direta     NUMBER(12,2) default 0,
  cts_res_resu_vl_rec_intermedi  NUMBER(12,2) default 0,
  cts_res_resu_vl_rec_indireta   NUMBER(12,2) default 0,
  cts_res_resu_vl_desp_direta    NUMBER(12,2) default 0,
  cts_res_resu_vl_desp_intermedi NUMBER(12,2) default 0,
  cts_res_resu_vl_desp_indireta  NUMBER(12,2) default 0,
  cts_res_resu_seg_usu_id_inclu  INTEGER not null,
  cts_res_resu_dt_criacao        DATE not null,
  cts_res_resu_pc_rateio_receita NUMBER(12,2),
  cts_res_resu_pc_rateio_despesa NUMBER(12,2),
  cts_res_resu_pc_direto         NUMBER(12,2),
  cts_res_resu_pc_total          NUMBER(12,2)
)
tablespace SGS_DADOS
  pctfree 10
  pctused 40
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
-- Add comments to the table 
comment on table TB_CTS_RES_RESUMO_GERAL
  is 'CustoResumoGeral';
-- Add comments to the columns 
comment on column TB_CTS_RES_RESUMO_GERAL.seq_cts_res_resumo_01
  is 'IdtResumo';
comment on column TB_CTS_RES_RESUMO_GERAL.cts_res_resu_tipo
  is 'TipoResumo';
comment on column TB_CTS_RES_RESUMO_GERAL.cts_res_resu_mes
  is 'MesFechamento';
comment on column TB_CTS_RES_RESUMO_GERAL.cts_res_resu_ano
  is 'AnoFechamento';
comment on column TB_CTS_RES_RESUMO_GERAL.cts_res_resu_cad_cts_plc_id
  is 'IdtPlanoContas';
comment on column TB_CTS_RES_RESUMO_GERAL.cts_res_resu_cad_cts_cd_conta
  is 'Codigo';
comment on column TB_CTS_RES_RESUMO_GERAL.cts_res_resu_cad_cts_cd_nivel
  is 'Nivel';
comment on column TB_CTS_RES_RESUMO_GERAL.cts_res_resu_cad_cts_ds_descri
  is 'Descricao';
comment on column TB_CTS_RES_RESUMO_GERAL.cts_res_resu_vl_rec_direta
  is 'ValorReceitaDireta';
comment on column TB_CTS_RES_RESUMO_GERAL.cts_res_resu_vl_rec_intermedi
  is 'ValorReceitaIntermediaria';
comment on column TB_CTS_RES_RESUMO_GERAL.cts_res_resu_vl_rec_indireta
  is 'ValorReceitaIndireta';
comment on column TB_CTS_RES_RESUMO_GERAL.cts_res_resu_vl_desp_direta
  is 'ValorDespesaDireta';
comment on column TB_CTS_RES_RESUMO_GERAL.cts_res_resu_vl_desp_intermedi
  is 'ValorDespesaIntermediaria';
comment on column TB_CTS_RES_RESUMO_GERAL.cts_res_resu_vl_desp_indireta
  is 'ValorDespesaIndireta';
comment on column TB_CTS_RES_RESUMO_GERAL.cts_res_resu_seg_usu_id_inclu
  is 'IdtUsuario';
comment on column TB_CTS_RES_RESUMO_GERAL.cts_res_resu_dt_criacao
  is 'DataCriacao';
comment on column TB_CTS_RES_RESUMO_GERAL.cts_res_resu_pc_rateio_receita
  is 'PercentualRateioReceita';
comment on column TB_CTS_RES_RESUMO_GERAL.cts_res_resu_pc_rateio_despesa
  is 'PercentualRateioDespesa';
comment on column TB_CTS_RES_RESUMO_GERAL.cts_res_resu_pc_direto
  is 'PercentualDireto';
comment on column TB_CTS_RES_RESUMO_GERAL.cts_res_resu_pc_total
  is 'PercentualTotal';
-- Create/Recreate primary, unique and foreign key constraints 
alter table TB_CTS_RES_RESUMO_GERAL
  add constraint PK_CTS_RES_RESUMO_GERAL primary key (SEQ_CTS_RES_RESUMO_01)
  using index 
  tablespace SGS_DADOS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
alter table TB_CTS_RES_RESUMO_GERAL
  add constraint AK_CTS_RES_RESUMO_GERAL unique (CTS_RES_RESU_TIPO, CTS_RES_RESU_MES, CTS_RES_RESU_ANO, CTS_RES_RESU_CAD_CTS_PLC_ID)
  using index 
  tablespace SGS_DADOS
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
alter table TB_CTS_RES_RESUMO_GERAL
  add constraint FK1_CTS_RES_RESUMO_GERAL foreign key (CTS_RES_RESU_CAD_CTS_PLC_ID)
  references TB_CAD_CTS_PLC_PLANO_CONTAS (CAD_CTS_PLC_ID);
alter table TB_CTS_RES_RESUMO_GERAL
  add constraint FK2_CTS_RES_RESUMO_GERAL foreign key (CTS_RES_RESU_SEG_USU_ID_INCLU)
  references TB_SEG_USU_USUARIO (SEG_USU_ID_USUARIO);
-- Create/Recreate check constraints 
alter table TB_CTS_RES_RESUMO_GERAL
  add constraint CK1_CTS_RES_RESUMO_GERAL
  check (CTS_RES_RESU_TIPO IN ('D','R'));

