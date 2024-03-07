create table TB_CTS_RES_RESULTADO_CUSTOS
(
  CTS_RES_ID                       INTEGER NOT NULL,
  CAD_CEC_ID_CCUSTO                INTEGER,
  CAD_CEC_CD_CCUSTO                VARCHAR2(25),
  CTS_RES_MES                      NUMBER,
  CTS_RES_ANO                      NUMBER,
  CAD_UNI_ID_UNIDADE               INTEGER,
  CAD_LAT_ID_LOCAL_ATENDIMENTO     INTEGER,
  ATD_ATE_TP_PACIENTE              VARCHAR2(1),
  CTS_RES_VL_RECEITA_DIRETA        NUMBER(12,2),
  CTS_RES_VL_RECEITA_INDIRETA      NUMBER(12,2),
  CTS_RES_VL_DESPESA_DIRETA        NUMBER(12,2),
  CTS_RES_VL_DESPESA_INDIRETA      NUMBER(12,2),
  CTS_RES_VL_DESPESA_INTERMEDIARIA NUMBER(12,2),
  CTS_RES_PC_RATEIO                NUMBER(3,6),
  SEG_USU_ID_INCLUSAO              INTEGER,
  CTS_RES_DT_INCLUSAO              DATE,
  SEG_USU_ID_ALTERACAO             INTEGER,
  CTS_RES_DT_ALTERACAO             DATE
)
tablespace SGS_DADOS
  pctfree 10
  initrans 1
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
  
grant select, insert, update, delete on TB_CTS_RES_RESULTADO_CUSTOS to SGS_FULL;
 
comment on table TB_CTS_RES_RESULTADO_CUSTOS is 'ResultadoCustos';

comment on column TB_CTS_RES_RESULTADO_CUSTOS.cts_res_id is 'Idt';
comment on column TB_CTS_RES_RESULTADO_CUSTOS.cad_cec_id_ccusto is 'IdtCentroCusto';
comment on column TB_CTS_RES_RESULTADO_CUSTOS.cad_cec_cd_ccusto is 'CodigoCentroCusto';
comment on column TB_CTS_RES_RESULTADO_CUSTOS.cts_res_mes is 'MesReferencia';
comment on column TB_CTS_RES_RESULTADO_CUSTOS.cts_res_ano is 'AnoReferencia';
comment on column TB_CTS_RES_RESULTADO_CUSTOS.cad_uni_id_unidade is 'IdtUnidade';
comment on column TB_CTS_RES_RESULTADO_CUSTOS.cad_lat_id_local_atendimento is 'IdtLocalAtendimento';
comment on column TB_CTS_RES_RESULTADO_CUSTOS.atd_ate_tp_paciente is 'TipoPaciente';
comment on column TB_CTS_RES_RESULTADO_CUSTOS.cts_res_vl_receita_direta is 'ValorReceitaDireta';
comment on column TB_CTS_RES_RESULTADO_CUSTOS.cts_res_vl_receita_indireta is 'ValorReceitaIndireta';
comment on column TB_CTS_RES_RESULTADO_CUSTOS.cts_res_vl_despesa_direta is 'ValorDespesaDireta';
comment on column TB_CTS_RES_RESULTADO_CUSTOS.cts_res_vl_despesa_indireta is 'ValorDespesaIndireta';
comment on column TB_CTS_RES_RESULTADO_CUSTOS.cts_res_vl_despesa_intermediaria is 'ValorDespesaIntermediaria';
comment on column TB_CTS_RES_RESULTADO_CUSTOS.cts_res_pc_rateio is 'PercentualRateio';
comment on column TB_CTS_RES_RESULTADO_CUSTOS.seg_usu_id_inclusao is 'IdtUsuarioInclusao';
comment on column TB_CTS_RES_RESULTADO_CUSTOS.cts_res_dt_inclusao is 'DataInclusao';
comment on column TB_CTS_RES_RESULTADO_CUSTOS.seg_usu_id_alteracao is 'IdtUsuarioAlteracao';
comment on column TB_CTS_RES_RESULTADO_CUSTOS.cts_res_dt_alteracao is 'DataAlteracao';


alter table TB_CTS_RES_RESULTADO_CUSTOS
  add constraint PK_CTS_RES_01 primary key (CTS_RES_ID);
alter table TB_CTS_RES_RESULTADO_CUSTOS
  add constraint FK_CTS_RES_CEC_01 foreign key (CAD_CEC_ID_CCUSTO)
  references tb_cad_cec_centro_custo (CAD_CEC_ID_CCUSTO);
alter table TB_CTS_RES_RESULTADO_CUSTOS
  add constraint FK_CTS_RES_CEC_02 foreign key (CAD_CEC_CD_CCUSTO)
  references tb_cad_cec_centro_custo (CAD_CEC_CD_CCUSTO);
alter table TB_CTS_RES_RESULTADO_CUSTOS
  add constraint FK_CTS_RES_UNI_01 foreign key (CAD_UNI_ID_UNIDADE)
  references tb_cad_uni_unidade (CAD_UNI_ID_UNIDADE);
alter table TB_CTS_RES_RESULTADO_CUSTOS
  add constraint FK_CTS_RES_LAT_01 foreign key (CAD_LAT_ID_LOCAL_ATENDIMENTO)
  references tb_cad_lat_local_atendimento (CAD_LAT_ID_LOCAL_ATENDIMENTO);