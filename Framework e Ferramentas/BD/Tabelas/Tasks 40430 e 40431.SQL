-- Add/modify columns 
alter table SGS.TB_AGE_AGD_AGENDA add cad_uni_id_unid_login_usu number;
-- Create/Recreate primary, unique and foreign key constraints 
alter table SGS.TB_AGE_AGD_AGENDA
  add constraint FK_UNI_AGD foreign key (CAD_UNI_ID_UNID_LOGIN_USU)
  references SGS.tb_cad_uni_unidade (CAD_UNI_ID_UNIDADE);

-- Add/modify columns 
alter table TB_AGE_AGC_AGENDA_CANCELADA add cad_uni_id_unid_login_usu number;
-- Create/Recreate primary, unique and foreign key constraints 
alter table TB_AGE_AGC_AGENDA_CANCELADA
  add constraint FK_UNI_AGC foreign key (CAD_UNI_ID_UNID_LOGIN_USU)
  references tb_cad_uni_unidade (CAD_UNI_ID_UNIDADE);
