-- Create table
create table TB_FAT_CCP_CONTA_CONS_PARC
(
  FAT_CCP_ID                    NUMBER(10) not null,
  FAT_COC_ID                    NUMBER(10) not null,
  CAD_PAC_ID_PACIENTE           NUMBER(10) not null,
  FAT_CCP_DT_PARCELA            DATE not null,
  FAT_CCP_HR_PARCELA            NUMBER(4) not null,
  FAT_CCP_VL_TOT_ORIGINAL       NUMBER(15,2),
  FAT_CCP_VL_TOT_CONTA          NUMBER(15,2),
  FAT_CCP_VL_TOT_DESCONTO       NUMBER(15,2),
  FAT_CCP_PC_TOT_DESCONTO       NUMBER(7,2),
  ATD_GUI_CD_CODIGO             VARCHAR2(30),
  FAT_CCP_FL_EMITIDA            CHAR(1) default 'N',
  FAT_CCP_FL_FATURADA           CHAR(1) default 'N',
  FAT_CCP_MES_FAT               NUMBER(2),
  FAT_CCP_ANO_FAT               NUMBER(4),
  FAT_CCP_MES_COMPET            NUMBER(2),
  FAT_CCP_ANO_COMPET            NUMBER(4),
  FAT_CCP_FL_STATUS             CHAR(1) default 'A',
  FAT_CCP_DT_CANCELAMENTO       DATE,
  FAT_NOF_ID                    NUMBER(10) not null,
  FAT_CCP_FL_ENVIO_ONLINE       CHAR(1) default 'N' not null,
  FAT_CCP_NR_REMESSA            NUMBER(10),
  FAT_CCP_DT_FATURAMENTO        DATE,
  FAT_CCP_DT_ULTIMA_ATUALIZACAO DATE not null,
  SEG_USU_ID_USUARIO            NUMBER(10) not null
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
-- Add comments to the table 
comment on table TB_FAT_CCP_CONTA_CONS_PARC
  is 'ContaConsumoParcela';
-- Add comments to the columns 
comment on column TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ID
  is 'IdtContaParcela';
comment on column TB_FAT_CCP_CONTA_CONS_PARC.FAT_COC_ID
  is 'IdtContaConsumo';
comment on column TB_FAT_CCP_CONTA_CONS_PARC.CAD_PAC_ID_PACIENTE
  is 'IdtPaciente';
comment on column TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_DT_PARCELA
  is 'DataParcela';
comment on column TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_HR_PARCELA
  is 'HoraParcela';
comment on column TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_VL_TOT_ORIGINAL
  is 'ValorTotalOrigem';
comment on column TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_VL_TOT_CONTA
  is 'ValorTotalConta';
comment on column TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_VL_TOT_DESCONTO
  is 'ValorTotalDesconto';
comment on column TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_PC_TOT_DESCONTO
  is 'PercentualTotalDesconto';
comment on column TB_FAT_CCP_CONTA_CONS_PARC.ATD_GUI_CD_CODIGO
  is 'CodigoGuiaPrincipal';
comment on column TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_FL_EMITIDA
  is 'FlagEmitida';
comment on column TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_FL_FATURADA
  is 'FlagFaturada';
comment on column TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_MES_FAT
  is 'MesFaturamento';
comment on column TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ANO_FAT
  is 'AnoFaturamento';
comment on column TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_MES_COMPET
  is 'MesCompetencia';
comment on column TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_ANO_COMPET
  is 'AnoCompetencia';
comment on column TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_FL_STATUS
  is 'FlagStatus';
comment on column TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_DT_CANCELAMENTO
  is 'DataCancelamento';
comment on column TB_FAT_CCP_CONTA_CONS_PARC.FAT_NOF_ID
  is 'IdtNotaFiscal';
comment on column TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_FL_ENVIO_ONLINE
  is 'FlEnvioOnline';
comment on column TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_NR_REMESSA
  is 'NumeroRemessa';
comment on column TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_DT_FATURAMENTO
  is 'DataFaturamento';
comment on column TB_FAT_CCP_CONTA_CONS_PARC.FAT_CCP_DT_ULTIMA_ATUALIZACAO
  is 'DataUltimaAtualizacao';
comment on column TB_FAT_CCP_CONTA_CONS_PARC.SEG_USU_ID_USUARIO
  is 'IdtUsuario';
-- Create/Recreate primary, unique and foreign key constraints 
alter table TB_FAT_CCP_CONTA_CONS_PARC
  add constraint PK_FAT_CCP primary key (FAT_CCP_ID, FAT_COC_ID)
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
alter table TB_FAT_CCP_CONTA_CONS_PARC
  add constraint FK_CAD_PAC_CCP foreign key (CAD_PAC_ID_PACIENTE)
  references TB_CAD_PAC_PACIENTE (CAD_PAC_ID_PACIENTE);
alter table TB_FAT_CCP_CONTA_CONS_PARC
  add constraint FK_FAT_COC_CCP foreign key (FAT_COC_ID)
  references TB_FAT_COC_CONTA_CONSUMO (FAT_COC_ID);
alter table TB_FAT_CCP_CONTA_CONS_PARC
  add constraint FK_FAT_NOF_CCP foreign key (FAT_NOF_ID)
  references TB_FAT_NOF_NOTA_FISCAL (FAT_NOF_ID);
-- Create/Recreate check constraints 
alter table TB_FAT_CCP_CONTA_CONS_PARC
  add constraint CK_FAT_CCP_FL_EMITIDA
  check (FAT_CCP_FL_EMITIDA IN ('S','N'));
alter table TB_FAT_CCP_CONTA_CONS_PARC
  add constraint CK_FAT_CCP_FL_ENVIO_ONLINE
  check (FAT_CCP_FL_ENVIO_ONLINE IN ('S','N'));
alter table TB_FAT_CCP_CONTA_CONS_PARC
  add constraint CK_FAT_CCP_FL_FATURADA
  check (FAT_CCP_FL_FATURADA IN ('S','N'));
alter table TB_FAT_CCP_CONTA_CONS_PARC
  add constraint CK_FAT_CCP_FL_STATUS
  check (FAT_CCP_FL_STATUS IN ('A','C'));
