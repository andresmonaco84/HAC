-- Create table
create table TB_BNF_HOMECARE
(
  BNF_HOMECARE_ID     NUMBER(10) not null,
  BNF_COD_PLANO       VARCHAR2(4) not null,
  BNF_LOJA_ID         NUMBER(3) not null,
  BNF_BEN_ID          NUMBER(7) not null,
  BNF_COD_SEQ         NUMBER(2) not null,
  BNF_COD_NUM_PLANO   NUMBER(5) not null,
  BNF_PLA_ID_PLANO    INTEGER not null,
  BNF_FL_ATIVO        NUMBER(1) not null,
  BNF_ENDERECO        VARCHAR2(80) not null,
  BNF_BAIRRO          VARCHAR2(30) not null,
  BNF_UF              VARCHAR2(2) not null,
  BNF_NUMERO          VARCHAR2(20),
  BNF_CEP             NUMBER(8),
  BNF_DDD             VARCHAR2(4),
  BNF_TELEFONE        VARCHAR2(20),
  BNF_DDD2            VARCHAR2(4),
  BNF_TELEFONE2       VARCHAR2(20),
  BNF_DDD3            VARCHAR2(4),
  BNF_TELEFONE3       VARCHAR2(20),
  BNF_COMP            VARCHAR2(20),
  BNF_TIPO_LOGRADOURO VARCHAR2(20),
  BNF_OBS             VARCHAR2(30),
  BNF_EMAIL           VARCHAR2(50)
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
comment on table TB_BNF_HOMECARE
  is 'BenefHomeCare';
-- Add comments to the columns 
comment on column TB_BNF_HOMECARE.BNF_HOMECARE_ID
  is 'CodigoHomeCare';
comment on column TB_BNF_HOMECARE.BNF_COD_PLANO
  is 'CodigoPlano';
comment on column TB_BNF_HOMECARE.BNF_LOJA_ID
  is 'CodigoLoja';
comment on column TB_BNF_HOMECARE.BNF_BEN_ID
  is 'CodigoMatriculaBenef';
comment on column TB_BNF_HOMECARE.BNF_COD_SEQ
  is 'CodigoSeqMatriculaBenef';
comment on column TB_BNF_HOMECARE.BNF_COD_NUM_PLANO
  is 'CodigoNumericoPlano';
comment on column TB_BNF_HOMECARE.BNF_PLA_ID_PLANO
  is 'IdtPlanoSGS';
comment on column TB_BNF_HOMECARE.BNF_FL_ATIVO
  is 'FlAtivo';
comment on column TB_BNF_HOMECARE.BNF_ENDERECO
  is 'Endereco';
comment on column TB_BNF_HOMECARE.BNF_BAIRRO
  is 'Bairro';
comment on column TB_BNF_HOMECARE.BNF_UF
  is 'UF';
comment on column TB_BNF_HOMECARE.BNF_NUMERO
  is 'NumeroEndereco';
comment on column TB_BNF_HOMECARE.BNF_CEP
  is 'CEP';
comment on column TB_BNF_HOMECARE.BNF_DDD
  is 'DDD';
comment on column TB_BNF_HOMECARE.BNF_TELEFONE
  is 'Telefone';
comment on column TB_BNF_HOMECARE.BNF_DDD2
  is 'DDD2';
comment on column TB_BNF_HOMECARE.BNF_TELEFONE2
  is 'Telefone2';
comment on column TB_BNF_HOMECARE.BNF_DDD3
  is 'DDD3';
comment on column TB_BNF_HOMECARE.BNF_TELEFONE3
  is 'Telefone3';
comment on column TB_BNF_HOMECARE.BNF_COMP
  is 'Complemento';
comment on column TB_BNF_HOMECARE.BNF_TIPO_LOGRADOURO
  is 'TipoLogradouro';
comment on column TB_BNF_HOMECARE.BNF_OBS
  is 'Observacao';
comment on column TB_BNF_HOMECARE.BNF_EMAIL
  is 'Email';
-- Create/Recreate primary, unique and foreign key constraints 
alter table TB_BNF_HOMECARE
  add constraint BNF_HC_CHAVE primary key (BNF_HOMECARE_ID)
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
alter table TB_BNF_HOMECARE
  add constraint CHAVE_UNICA_BENEF unique (BNF_COD_PLANO, BNF_LOJA_ID, BNF_BEN_ID, BNF_COD_SEQ, BNF_COD_NUM_PLANO)
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

CREATE SEQUENCE SEQ_BNF_HOMECARE; 