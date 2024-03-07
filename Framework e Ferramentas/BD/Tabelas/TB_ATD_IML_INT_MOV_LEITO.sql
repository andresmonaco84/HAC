-- Create table
create table TB_ATD_IML_INT_MOV_LEITO
(
  atd_ate_id                    NUMBER(10) not null,
  atd_iml_dt_entrada            DATE not null,
  atd_iml_hr_entrada            NUMBER(4) not null,
  atd_iml_dt_saida              DATE,
  atd_iml_hr_saida              NUMBER(4),
  cad_cad_qle_id                NUMBER(10) not null,
  atd_iml_dt_ultima_atualizacao DATE not null,
  seg_usu_id_usuario            NUMBER(10) not null,
  cad_pac_id_paciente           NUMBER not null,
  tis_tac_cd_tipo_acomodacao    CHAR(2),
  atd_iml_fl_status             CHAR(1) default 'A' not null,
  atd_iml_fl_cortesia           CHAR(1) default 'N' not null,
  atd_iml_fl_dif_classe         CHAR(1) default 'N' not null,
  atd_iml_id                    NUMBER(10) not null,
  atd_iml_fl_falta_vaga         CHAR(1) default 'N',
  tis_tac_cd_tipo_acomod_aut    CHAR(2),
  atd_iml_dt_ini_acomod_aut     DATE,
  atd_iml_hr_ini_acomod_aut     NUMBER(4)
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
comment on table TB_ATD_IML_INT_MOV_LEITO
  is 'MovimentacaoPacienteLeito';
-- Add comments to the columns 
comment on column TB_ATD_IML_INT_MOV_LEITO.atd_ate_id
  is 'IdtAtendimento';
comment on column TB_ATD_IML_INT_MOV_LEITO.atd_iml_dt_entrada
  is 'DataEntrada';
comment on column TB_ATD_IML_INT_MOV_LEITO.atd_iml_hr_entrada
  is 'HoraEntrada';
comment on column TB_ATD_IML_INT_MOV_LEITO.atd_iml_dt_saida
  is 'DataSaida';
comment on column TB_ATD_IML_INT_MOV_LEITO.atd_iml_hr_saida
  is 'HoraSaida';
comment on column TB_ATD_IML_INT_MOV_LEITO.cad_cad_qle_id
  is 'IdtQuarto';
comment on column TB_ATD_IML_INT_MOV_LEITO.atd_iml_dt_ultima_atualizacao
  is 'DataUltimaAtualizacao';
comment on column TB_ATD_IML_INT_MOV_LEITO.seg_usu_id_usuario
  is 'IdtUsuario';
comment on column TB_ATD_IML_INT_MOV_LEITO.cad_pac_id_paciente
  is 'IdtPaciente';
comment on column TB_ATD_IML_INT_MOV_LEITO.tis_tac_cd_tipo_acomodacao
  is 'TipoAcomodacao';
comment on column TB_ATD_IML_INT_MOV_LEITO.atd_iml_fl_status
  is 'StatusTransferencia';
comment on column TB_ATD_IML_INT_MOV_LEITO.atd_iml_fl_cortesia
  is 'StatusCortesia';
comment on column TB_ATD_IML_INT_MOV_LEITO.atd_iml_fl_dif_classe
  is 'StatusDiferencaClasse';
comment on column TB_ATD_IML_INT_MOV_LEITO.atd_iml_id
  is 'IdtMovimentacao';
comment on column TB_ATD_IML_INT_MOV_LEITO.atd_iml_fl_falta_vaga
  is 'StatusFaltaVagaAcomodacaoPermitida';
comment on column TB_ATD_IML_INT_MOV_LEITO.tis_tac_cd_tipo_acomod_aut
  is 'TipoAcomodacaoAutorizada';
comment on column TB_ATD_IML_INT_MOV_LEITO.atd_iml_dt_ini_acomod_aut
  is 'DataInicioAcomodacaoAutorizada';
comment on column TB_ATD_IML_INT_MOV_LEITO.atd_iml_hr_ini_acomod_aut
  is 'HoraInicioAcomodacaoAutorizada';
-- Create/Recreate indexes 
create unique index ATD_IML_IND_01 on TB_ATD_IML_INT_MOV_LEITO (ATD_ATE_ID, ATD_IML_DT_ENTRADA, ATD_IML_HR_ENTRADA, CAD_CAD_QLE_ID, CAD_PAC_ID_PACIENTE)
  tablespace SGS_INDICE
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
create index ATD_IML_IND_02 on TB_ATD_IML_INT_MOV_LEITO (ATD_IML_DT_ENTRADA)
  tablespace SGS_INDICE
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
create index ATD_IML_IND_03 on TB_ATD_IML_INT_MOV_LEITO (ATD_IML_HR_ENTRADA)
  tablespace SGS_INDICE
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
create index ATD_IML_IND_04 on TB_ATD_IML_INT_MOV_LEITO (ATD_IML_DT_SAIDA)
  tablespace SGS_INDICE
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
create index ATD_IML_IND_05 on TB_ATD_IML_INT_MOV_LEITO (ATD_IML_HR_SAIDA)
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
create index ATD_IML_IND_06 on TB_ATD_IML_INT_MOV_LEITO (CAD_CAD_QLE_ID)
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
create index ATD_IML_IND_07 on TB_ATD_IML_INT_MOV_LEITO (CAD_PAC_ID_PACIENTE)
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
create index ATD_IML_IND_08 on TB_ATD_IML_INT_MOV_LEITO (TIS_TAC_CD_TIPO_ACOMODACAO)
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
create index ATD_IML_IND_09 on TB_ATD_IML_INT_MOV_LEITO (ATD_IML_FL_STATUS)
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
create index ATD_IML_IND_10 on TB_ATD_IML_INT_MOV_LEITO (ATD_IML_FL_CORTESIA)
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
create index ATD_IML_IND_11 on TB_ATD_IML_INT_MOV_LEITO (ATD_IML_FL_DIF_CLASSE)
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
create index ATD_IML_IND_12 on TB_ATD_IML_INT_MOV_LEITO (ATD_ATE_ID)
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
create index ATD_IML_IND_13 on TB_ATD_IML_INT_MOV_LEITO (CAD_CAD_QLE_ID, ATD_ATE_ID, ATD_IML_FL_STATUS)
  tablespace SGS_INDICE
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
create index ATD_IML_IND_14 on TB_ATD_IML_INT_MOV_LEITO (ATD_ATE_ID, ATD_IML_DT_ENTRADA, ATD_IML_HR_ENTRADA, CAD_CAD_QLE_ID, ATD_IML_FL_STATUS)
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
-- Create/Recreate primary, unique and foreign key constraints 
alter table TB_ATD_IML_INT_MOV_LEITO
  add constraint PK_ATD_IML primary key (ATD_IML_ID)
  using index 
  tablespace SGS_INDICE
  pctfree 10
  initrans 2
  maxtrans 255
  storage
  (
    initial 64K
    minextents 1
    maxextents unlimited
  );
alter table TB_ATD_IML_INT_MOV_LEITO
  add constraint FK_ATE_ATD_IML foreign key (ATD_ATE_ID)
  references TB_ATD_ATE_ATENDIMENTO (ATD_ATE_ID);
alter table TB_ATD_IML_INT_MOV_LEITO
  add constraint FK_CAD_PAC_IML foreign key (CAD_PAC_ID_PACIENTE)
  references TB_CAD_PAC_PACIENTE (CAD_PAC_ID_PACIENTE);
alter table TB_ATD_IML_INT_MOV_LEITO
  add constraint FK_CAD_QLE_IML foreign key (CAD_CAD_QLE_ID)
  references TB_CAD_QLE_QUARTO_LEITO (CAD_QLE_ID);
alter table TB_ATD_IML_INT_MOV_LEITO
  add constraint FK_TAC_IML foreign key (TIS_TAC_CD_TIPO_ACOMOD_AUT)
  references TB_TIS_TAC_TIPO_ACOMODACAO (TIS_TAC_CD_TIPO_ACOMODACAO);
alter table TB_ATD_IML_INT_MOV_LEITO
  add constraint FK_TIS_TAC_IML foreign key (TIS_TAC_CD_TIPO_ACOMODACAO)
  references TB_TIS_TAC_TIPO_ACOMODACAO (TIS_TAC_CD_TIPO_ACOMODACAO);
-- Create/Recreate check constraints 
alter table TB_ATD_IML_INT_MOV_LEITO
  add constraint CK_ATD_IML_FL_CORTESIA
  check (ATD_IML_FL_CORTESIA IN ('S','N'));
alter table TB_ATD_IML_INT_MOV_LEITO
  add constraint CK_ATD_IML_FL_DIF_CLASSE
  check (ATD_IML_FL_DIF_CLASSE IN('S','N'));
alter table TB_ATD_IML_INT_MOV_LEITO
  add constraint CK_ATD_IML_FL_STATUS
  check (ATD_IML_FL_STATUS IN('A','C'));
-- Grant/Revoke object privileges 
grant select, insert, update, delete on TB_ATD_IML_INT_MOV_LEITO to SGS2;
grant select on TB_ATD_IML_INT_MOV_LEITO to SGS_CONSULTA;
grant select, insert, update, delete on TB_ATD_IML_INT_MOV_LEITO to SGS_FULL;
grant select, references on TB_ATD_IML_INT_MOV_LEITO to TISS;
