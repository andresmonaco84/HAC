-- select * from TB_CAD_CCR_CCONTA_RM

-- Create table
create table TB_CAD_CCR_CCONTA_RM
(
  CAD_CCR_ID                   NUMBER not null,
  CAD_CCR_CD_COLIGADA          NUMBER(5) not null,
  CAD_CCR_CD_CONTA             VARCHAR2(40) not null,
  CAD_CCR_CD_REDUZIDO          VARCHAR2(20), 
  CAD_CCR_DS_DESCRICAO         VARCHAR2(40),
  CAD_CCR_FL_ANALIT_SINT       NUMBER(1),
  CAD_CCR_FL_RATEIO            NUMBER(1),
  CAD_CCR_FL_NATUREZA          NUMBER(1),
  CAD_CCR_FL_STATUS            CHAR(1),
  SEG_USU_ID_INCLUSAO          NUMBER,
  CAD_CCR_DT_INCLUSAO          DATE,
  SEG_USU_ID_ALTERACAO         NUMBER,
  CAD_CCR_DT_ALTERACAO         DATE

--  codcoligada             NUMBER(5) not null,
--  codconta                VARCHAR2(40) not null,
--  reduzido                VARCHAR2(20),
--  descricao               VARCHAR2(40),
--  analitica               NUMBER(5),
--  rateio                  NUMBER(5),
--  natureza                NUMBER(5),
--  tipocorrecao            NUMBER(5),
--  tipoconta               NUMBER(5),
/*  conta8200               VARCHAR2(40),
  bitmap                  NUMBER(5),
  histlctativo            VARCHAR2(40),
  opcional                NUMBER(5),
  codhistp                VARCHAR2(10),
  codcolhistp             NUMBER(5),
  moedavenda              VARCHAR2(10),
  moedacompra             VARCHAR2(10),
  inativa                 NUMBER(5),
  datainativa             DATE,
  usuarioinclu            VARCHAR2(20),
  datainclu               DATE,
  usuarioalter            VARCHAR2(20),
  dataalter               DATE,
  codcolcontaestorno      NUMBER(5),
  contaestorno            VARCHAR2(40),
  natsped                 VARCHAR2(3)
*/
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
  
-- PK_CAD_CCR

grant select, insert, update, delete on TB_CAD_CCR_CCONTA_RM to SGS_FULL;

comment on column TB_CAD_CCR_CCONTA_RM.CAD_CCR_ID IS 'Idt';
comment on column TB_CAD_CCR_CCONTA_RM.CAD_CCR_CD_COLIGADA IS 'CodigoColigada';
comment on column TB_CAD_CCR_CCONTA_RM.CAD_CCR_CD_CONTA IS 'CodigoConta';
comment on column TB_CAD_CCR_CCONTA_RM.CAD_CCR_CD_REDUZIDO IS 'CodigoReduzido';
comment on column TB_CAD_CCR_CCONTA_RM.CAD_CCR_DS_DESCRICAO IS 'Descricao';
comment on column TB_CAD_CCR_CCONTA_RM.CAD_CCR_FL_ANALIT_SINT IS 'FlagAnaliticoSintetico';
comment on column TB_CAD_CCR_CCONTA_RM.CAD_CCR_FL_RATEIO IS 'FlagRateio';
comment on column TB_CAD_CCR_CCONTA_RM.CAD_CCR_FL_NATUREZA IS 'FlagNaturezaCredoraDevedora';
comment on column TB_CAD_CCR_CCONTA_RM.CAD_CCR_FL_STATUS IS 'FlagStatus';
comment on column TB_CAD_CCR_CCONTA_RM.SEG_USU_ID_INCLUSAO IS 'IdtUsuarioInclusao';
comment on column TB_CAD_CCR_CCONTA_RM.CAD_CCR_DT_INCLUSAO IS 'DataInclusao';
comment on column TB_CAD_CCR_CCONTA_RM.SEG_USU_ID_ALTERACAO IS 'IdtUsuarioAlteracao';
comment on column TB_CAD_CCR_CCONTA_RM.CAD_CCR_DT_ALTERACAO IS 'DataUltimaAtualizacao';

