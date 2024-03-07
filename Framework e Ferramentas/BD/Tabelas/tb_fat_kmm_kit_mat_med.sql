-- Create table
create table TB_FAT_KMM_KIT_MAT_MED
(
  FAT_KMM_ID                    NUMBER(10) not null,
  CAD_PRD_ID_KIT                NUMBER(10) not null,
  FAT_KMM_DT_INI_VIGENCIA       DATE not null,
  FAT_KMM_DT_FIM_VIGENCIA       DATE,
  FAT_KMM_FL_STATUS             CHAR(1) not null,
  CAD_PRD_ID_ITEM               NUMBER(10) not null,
  FAT_KMM_QT_ITEM               NUMBER(3) not null,
  FAT_KMM_DT_ULTIMA_ATUALIZACAO DATE not null,
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
comment on table TB_FAT_KMM_KIT_MAT_MED
  is 'KitMaterialMedicamento';
-- Add comments to the columns 
comment on column TB_FAT_KMM_KIT_MAT_MED.FAT_KMM_ID
  is 'Idt';
comment on column TB_FAT_KMM_KIT_MAT_MED.CAD_PRD_ID_KIT
  is 'IdtKit';
comment on column TB_FAT_KMM_KIT_MAT_MED.FAT_KMM_DT_INI_VIGENCIA
  is 'DataInicioVigencia';
comment on column TB_FAT_KMM_KIT_MAT_MED.FAT_KMM_DT_FIM_VIGENCIA
  is 'DataFimVigencia';
comment on column TB_FAT_KMM_KIT_MAT_MED.FAT_KMM_FL_STATUS
  is 'FlagStatus';
comment on column TB_FAT_KMM_KIT_MAT_MED.CAD_PRD_ID_ITEM
  is 'IdtItem';
comment on column TB_FAT_KMM_KIT_MAT_MED.FAT_KMM_QT_ITEM
  is 'QuantidadeItem';
comment on column TB_FAT_KMM_KIT_MAT_MED.FAT_KMM_DT_ULTIMA_ATUALIZACAO
  is 'DataUltimaAtualizacao';
comment on column TB_FAT_KMM_KIT_MAT_MED.SEG_USU_ID_USUARIO
  is 'IdtUsuarioAtualizacao';
-- Create/Recreate primary, unique and foreign key constraints 
alter table TB_FAT_KMM_KIT_MAT_MED
  add constraint PK_FAT_KMM primary key (FAT_KMM_ID)
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
alter table TB_FAT_KMM_KIT_MAT_MED
  add constraint FK_PRD_KMM_01 foreign key (CAD_PRD_ID_KIT)
  references TB_CAD_PRD_PRODUTO (CAD_PRD_ID);
alter table TB_FAT_KMM_KIT_MAT_MED
  add constraint FK_PRD_KMM_02 foreign key (CAD_PRD_ID_ITEM)
  references TB_CAD_PRD_PRODUTO (CAD_PRD_ID);
alter table TB_FAT_KMM_KIT_MAT_MED
  add constraint FK_USU_KMM_03 foreign key (SEG_USU_ID_USUARIO)
  references TB_SEG_USU_USUARIO (SEG_USU_ID_USUARIO);
-- Create/Recreate check constraints 
alter table TB_FAT_KMM_KIT_MAT_MED
  add constraint CK_FAT_KMM_FL_STATUS
  check (FAT_KMM_FL_STATUS IN ('A','I'));
-- Create/Recreate indexes 
create index FAT_KMM_IND_01 on TB_FAT_KMM_KIT_MAT_MED (CAD_PRD_ID_KIT)
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
create index FAT_KMM_IND_02 on TB_FAT_KMM_KIT_MAT_MED (FAT_KMM_DT_INI_VIGENCIA, FAT_KMM_DT_FIM_VIGENCIA)
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
create index FAT_KMM_IND_03 on TB_FAT_KMM_KIT_MAT_MED (FAT_KMM_FL_STATUS)
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
create index FAT_KMM_IND_04 on TB_FAT_KMM_KIT_MAT_MED (CAD_PRD_ID_ITEM)
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
