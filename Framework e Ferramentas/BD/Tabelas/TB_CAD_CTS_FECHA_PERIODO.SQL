-- Create table
create table TB_CAD_CTS_FECHA_PERIODO
(
  cad_cts_mes_fechamento        NUMBER(2) not null,
  cad_cts_ano_fechamento        NUMBER(4) not null,
  cad_cts_status                CHAR(1) not null,
  cad_cts_dt_ultima_atualizacao DATE,
  seg_usu_id_usuario            NUMBER(10)
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
comment on table TB_CAD_CTS_FECHA_PERIODO
  is 'CustoFechaPeriodo';
-- Add comments to the columns 
comment on column TB_CAD_CTS_FECHA_PERIODO.cad_cts_mes_fechamento
  is 'MesFechamento';
comment on column TB_CAD_CTS_FECHA_PERIODO.cad_cts_ano_fechamento
  is 'AnoFechamento';
comment on column TB_CAD_CTS_FECHA_PERIODO.cad_cts_status
  is 'Status';
comment on column TB_CAD_CTS_FECHA_PERIODO.cad_cts_dt_ultima_atualizacao
  is 'DataUltimaAtualizacao';
comment on column TB_CAD_CTS_FECHA_PERIODO.seg_usu_id_usuario
  is 'IdtUsuario';
-- Create/Recreate primary, unique and foreign key constraints 
alter table TB_CAD_CTS_FECHA_PERIODO
  add constraint PK_CAD_CTS primary key (CAD_CTS_MES_FECHAMENTO, CAD_CTS_ANO_FECHAMENTO, CAD_CTS_STATUS)
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
alter table TB_CAD_CTS_FECHA_PERIODO
  add constraint FK1_CAD_CTS foreign key (SEG_USU_ID_USUARIO)
  references TB_SEG_USU_USUARIO (SEG_USU_ID_USUARIO);
-- Create/Recreate check constraints 
alter table TB_CAD_CTS_FECHA_PERIODO
  add constraint CK_CAD_CTS_STATUS
  check (CAD_CTS_STATUS IN ('S', 'N'));