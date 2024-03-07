-- Create table
create table TB_CAD_IPA_ITEM_PACOTE
(
  CAD_IPA_ID                    NUMBER(10) not null,
  CAD_PRD_ID_PACOTE             NUMBER(10) not null,
  CAD_IPA_VL_ITEM_PACOTE        NUMBER(15,5) not null,
  CAD_IPA_PC_RATEIO             NUMBER(15,5),
  CAD_IPA_DT_INICIO_VIGENCIA    DATE not null,
  CAD_IPA_DT_FIM_VIGENCIA       DATE,
  SEG_USU_ID_USUARIO            NUMBER(10) not null,
  CAD_IPA_FL_STATUS             CHAR(1) default 'A' not null,
  CAD_IPA_PC_DESCONTO           NUMBER(15,5),
  CAD_IPA_PC_ACRESCIMO          NUMBER(15,5),
  CAD_IPA_DS_OBSERVACAO         VARCHAR2(100),
  CAD_IPA_DT_ULTIMA_ATUALIZACAO DATE not null,
  CAD_PRD_ID_ITEM_PACOTE        NUMBER(10) not null,
  CAD_IPA_VL_ORIG_ITEM_PRODUTO  NUMBER(15,5) not null,
  CAD_IPA_VL_ACRESCIMO          NUMBER(15,5),
  CAD_IPA_VL_DESCONTO           NUMBER(15,5),
  CAD_IPA_VL_FINAL_PACOTE       NUMBER(15,5) not null,
  CAD_IPA_QT_ITEM_PACOTE        NUMBER(7,3) not null
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
comment on table TB_CAD_IPA_ITEM_PACOTE
  is 'CadastroItemPacote';
-- Add comments to the columns 
comment on column TB_CAD_IPA_ITEM_PACOTE.CAD_IPA_ID
  is 'IdtItem';
comment on column TB_CAD_IPA_ITEM_PACOTE.CAD_PRD_ID_PACOTE
  is 'IdtProdutoPacote';
comment on column TB_CAD_IPA_ITEM_PACOTE.CAD_IPA_VL_ITEM_PACOTE
  is 'ValorItemPacote';
comment on column TB_CAD_IPA_ITEM_PACOTE.CAD_IPA_PC_RATEIO
  is 'PercentualRateio';
comment on column TB_CAD_IPA_ITEM_PACOTE.CAD_IPA_DT_INICIO_VIGENCIA
  is 'DataInicioVigencia';
comment on column TB_CAD_IPA_ITEM_PACOTE.CAD_IPA_DT_FIM_VIGENCIA
  is 'DataFimVigencia';
comment on column TB_CAD_IPA_ITEM_PACOTE.SEG_USU_ID_USUARIO
  is 'IdtUsuario';
comment on column TB_CAD_IPA_ITEM_PACOTE.CAD_IPA_FL_STATUS
  is 'FlStatus';
comment on column TB_CAD_IPA_ITEM_PACOTE.CAD_IPA_PC_DESCONTO
  is 'PercentualDescontoItem';
comment on column TB_CAD_IPA_ITEM_PACOTE.CAD_IPA_PC_ACRESCIMO
  is 'PercentualAcrescimoItem';
comment on column TB_CAD_IPA_ITEM_PACOTE.CAD_IPA_DS_OBSERVACAO
  is 'Observacao';
comment on column TB_CAD_IPA_ITEM_PACOTE.CAD_IPA_DT_ULTIMA_ATUALIZACAO
  is 'DataUltimaAtualizacao';
comment on column TB_CAD_IPA_ITEM_PACOTE.CAD_PRD_ID_ITEM_PACOTE
  is 'IdtProdutoItemPacote';
comment on column TB_CAD_IPA_ITEM_PACOTE.CAD_IPA_VL_ORIG_ITEM_PRODUTO
  is 'ValorOrigenalItemProduto';
comment on column TB_CAD_IPA_ITEM_PACOTE.CAD_IPA_VL_ACRESCIMO
  is 'ValorAcrescimoItem';
comment on column TB_CAD_IPA_ITEM_PACOTE.CAD_IPA_VL_DESCONTO
  is 'ValorDescontoItem';
comment on column TB_CAD_IPA_ITEM_PACOTE.CAD_IPA_VL_FINAL_PACOTE
  is 'ValorFinalPacote';
comment on column TB_CAD_IPA_ITEM_PACOTE.CAD_IPA_QT_ITEM_PACOTE
  is 'QuantidadeItemPacote';
-- Create/Recreate primary, unique and foreign key constraints 
alter table TB_CAD_IPA_ITEM_PACOTE
  add constraint PK_CAD_IPA primary key (CAD_IPA_ID)
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
alter table TB_CAD_IPA_ITEM_PACOTE
  add constraint FK_CAD_PRD_IPA foreign key (CAD_PRD_ID_PACOTE)
  references TB_CAD_PRD_PRODUTO (CAD_PRD_ID);
alter table TB_CAD_IPA_ITEM_PACOTE
  add constraint FK_CAD_PRD_ITEM_IPA foreign key (CAD_PRD_ID_ITEM_PACOTE)
  references TB_CAD_PRD_PRODUTO (CAD_PRD_ID);
-- Create/Recreate check constraints 
alter table TB_CAD_IPA_ITEM_PACOTE
  add constraint CK_CAD_IPA_FL_STATUS
  check (CAD_IPA_FL_STATUS IN ('A','I'));
-- Create/Recreate indexes 
create index CAD_IPA_IND_01 on TB_CAD_IPA_ITEM_PACOTE (CAD_PRD_ID_PACOTE)
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
create index CAD_IPA_IND_02 on TB_CAD_IPA_ITEM_PACOTE (CAD_IPA_VL_ORIG_ITEM_PRODUTO)
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
create index CAD_IPA_IND_03 on TB_CAD_IPA_ITEM_PACOTE (CAD_PRD_ID_ITEM_PACOTE)
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
create index CAD_IPA_IND_04 on TB_CAD_IPA_ITEM_PACOTE (CAD_IPA_FL_STATUS)
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
