-- Create table
create table TB_FAT_COC_CONTA_CONSUMO
(
  FAT_COC_ID                    NUMBER(10) not null,
  FAT_COC_TP_DESTINO_CONTA      VARCHAR2(2),
  ATD_ATE_ID                    NUMBER not null,
  CAD_PAC_ID_PACIENTE           NUMBER(10) not null,
  FAT_COC_VL_TOTAL_ORIGINAL     NUMBER(15,2),
  FAT_COC_PC_DESCONTO           NUMBER(15,2),
  FAT_COC_VL_DESCONTO           NUMBER(15,2),
  FAT_COC_VL_TOTAL_CONTA        NUMBER(15,2),
  ATD_GUI_CD_CODIGO             VARCHAR2(30),
  FAT_COC_DT_INI_CONSUMO        DATE not null,
  FAT_COC_HR_INI_CONSUMO        NUMBER(4) not null,
  FAT_COC_DT_FIM_CONSUMO        DATE,
  FAT_COC_HR_FIM_CONSUMO        NUMBER(4),
  FAT_COC_DT_ULTIMA_ATUALIZACAO DATE not null,
  SEG_USU_ID_USUARIO            NUMBER(10) not null,
  FAT_COC_FL_STATUS             CHAR(1) default 'A' not null
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
comment on table TB_FAT_COC_CONTA_CONSUMO
  is 'ContaConsumo';
-- Add comments to the columns 
comment on column TB_FAT_COC_CONTA_CONSUMO.FAT_COC_ID
  is 'IdtContaConsumo';
comment on column TB_FAT_COC_CONTA_CONSUMO.FAT_COC_TP_DESTINO_CONTA
  is 'DestinoConta';
comment on column TB_FAT_COC_CONTA_CONSUMO.ATD_ATE_ID
  is 'IdtAtendimento';
comment on column TB_FAT_COC_CONTA_CONSUMO.CAD_PAC_ID_PACIENTE
  is 'IdtPaciente';
comment on column TB_FAT_COC_CONTA_CONSUMO.FAT_COC_VL_TOTAL_ORIGINAL
  is 'ValorTotalOriginal';
comment on column TB_FAT_COC_CONTA_CONSUMO.FAT_COC_PC_DESCONTO
  is 'PercentualDescontoConta';
comment on column TB_FAT_COC_CONTA_CONSUMO.FAT_COC_VL_DESCONTO
  is 'ValorTotalDesconto';
comment on column TB_FAT_COC_CONTA_CONSUMO.FAT_COC_VL_TOTAL_CONTA
  is 'ValorTotalConta';
comment on column TB_FAT_COC_CONTA_CONSUMO.ATD_GUI_CD_CODIGO
  is 'CodigoGuiaPrincipal';
comment on column TB_FAT_COC_CONTA_CONSUMO.FAT_COC_DT_INI_CONSUMO
  is 'DataInicioConsumo';
comment on column TB_FAT_COC_CONTA_CONSUMO.FAT_COC_HR_INI_CONSUMO
  is 'HoraInicioConsumo';
comment on column TB_FAT_COC_CONTA_CONSUMO.FAT_COC_DT_FIM_CONSUMO
  is 'DataFimConsumo';
comment on column TB_FAT_COC_CONTA_CONSUMO.FAT_COC_HR_FIM_CONSUMO
  is 'HoraFimConsumo';
comment on column TB_FAT_COC_CONTA_CONSUMO.FAT_COC_DT_ULTIMA_ATUALIZACAO
  is 'DataUltimaAtualizacao';
comment on column TB_FAT_COC_CONTA_CONSUMO.SEG_USU_ID_USUARIO
  is 'IdtUsuario';
comment on column TB_FAT_COC_CONTA_CONSUMO.FAT_COC_FL_STATUS
  is 'FlagStatus';
-- Create/Recreate primary, unique and foreign key constraints 
alter table TB_FAT_COC_CONTA_CONSUMO
  add constraint PK_FAT_COC primary key (FAT_COC_ID)
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
alter table TB_FAT_COC_CONTA_CONSUMO
  add constraint FK_ATD_ATE_COC foreign key (ATD_ATE_ID)
  references TB_ATD_ATE_ATENDIMENTO (ATD_ATE_ID);
alter table TB_FAT_COC_CONTA_CONSUMO
  add constraint FK_CAD_PAC_COC foreign key (CAD_PAC_ID_PACIENTE)
  references TB_CAD_PAC_PACIENTE (CAD_PAC_ID_PACIENTE);
-- Create/Recreate check constraints 
alter table TB_FAT_COC_CONTA_CONSUMO
  add constraint CK_FAT_COC_FL_STATUS
  check (FAT_COC_FL_STATUS IN ('A','C'));
alter table TB_FAT_COC_CONTA_CONSUMO
  add constraint CK_FAT_COC_TP_DESTINO_CONTA
  check (FAT_COC_TP_DESTINO_CONTA IN ('P','C','H'));
