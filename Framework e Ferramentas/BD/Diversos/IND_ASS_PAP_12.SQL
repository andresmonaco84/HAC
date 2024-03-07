create index IND_ASS_PAP_12 on TB_ASS_PAP_PAC_ATEN_PROC (ASS_PAP_FL_STATUS_AUTOR, ASS_PAP_DT_SOLIC, CAD_PAC_ID_PACIENTE, CAD_UNI_ID_UNIDADE, CAD_LAT_ID_LOCAL_ATENDIMENTO)
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