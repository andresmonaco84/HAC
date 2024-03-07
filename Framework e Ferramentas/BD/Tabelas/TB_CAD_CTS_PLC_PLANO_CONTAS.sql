create table SGS.TB_CAD_CTS_PLC_PLANO_CONTAS
(
  CAD_CTS_PLC_ID               NUMBER,
  CAD_CTS_CD_COLIGADA          NUMBER,
  CAD_CTS_CD_CONTA             VARCHAR2(40),
  CAD_CTS_CD_NIVEL             NUMBER,
  CAD_CTS_DS_DESCRICAO         VARCHAR2(60),
  CAD_CTS_CD_NATUREZA          NUMBER,
  CAD_CTS_CD_MASCARA           VARCHAR2(13),
  CAD_CTS_PLC_REFER_ID         NUMBER,
  CAD_CTS_FL_STATUS            CHAR(1),
  CAD_CTS_DT_INATIVACAO        DATE,
  SEG_USU_ID_INCLUSAO          NUMBER,
  CAD_CTS_DT_INCLUSAO          DATE,
  SEG_USU_ID_ALTERACAO         NUMBER,
  CAD_CTS_DT_ALTERACAO         DATE
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

grant select, insert, update, delete on SGS.TB_CAD_CTS_PLC_PLANO_CONTAS to SGS_FULL;

comment on column SGS.TB_CAD_CTS_PLC_PLANO_CONTAS.CAD_CTS_PLC_ID IS 'Idt';
comment on column SGS.TB_CAD_CTS_PLC_PLANO_CONTAS.CAD_CTS_CD_COLIGADA IS 'CodigoColigada';
comment on column SGS.TB_CAD_CTS_PLC_PLANO_CONTAS.CAD_CTS_CD_CONTA IS 'CodigoConta';
comment on column SGS.TB_CAD_CTS_PLC_PLANO_CONTAS.CAD_CTS_CD_NIVEL IS 'CodigoNivel';
comment on column SGS.TB_CAD_CTS_PLC_PLANO_CONTAS.CAD_CTS_DS_DESCRICAO IS 'Descricao';
comment on column SGS.TB_CAD_CTS_PLC_PLANO_CONTAS.CAD_CTS_CD_NATUREZA IS 'CodigoNatureza';
comment on column SGS.TB_CAD_CTS_PLC_PLANO_CONTAS.CAD_CTS_CD_MASCARA IS 'Mascara';
comment on column SGS.TB_CAD_CTS_PLC_PLANO_CONTAS.CAD_CTS_PLC_REFER_ID IS 'IdtPlanoContasPai';
comment on column SGS.TB_CAD_CTS_PLC_PLANO_CONTAS.CAD_CTS_FL_STATUS IS 'FlagStatus';
comment on column SGS.TB_CAD_CTS_PLC_PLANO_CONTAS.CAD_CTS_DT_INATIVACAO IS 'DataInativacao';
comment on column SGS.TB_CAD_CTS_PLC_PLANO_CONTAS.SEG_USU_ID_INCLUSAO IS 'IdtUsuarioInclusao';
comment on column SGS.TB_CAD_CTS_PLC_PLANO_CONTAS.CAD_CTS_DT_INCLUSAO IS 'DataInclusao';
comment on column SGS.TB_CAD_CTS_PLC_PLANO_CONTAS.SEG_USU_ID_ALTERACAO IS 'IdtUsuarioAlteracao';
comment on column SGS.TB_CAD_CTS_PLC_PLANO_CONTAS.CAD_CTS_DT_ALTERACAO IS 'DataAlteracao';
