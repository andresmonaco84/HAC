-- Add/modify columns 
alter table TB_ATD_IEP_INT_EVOL_PACIENTE add cad_pro_id_profissional NUMBER;
alter table TB_ATD_IEP_INT_EVOL_PACIENTE add tis_cbo_cd_cbos char(5);
-- Add comments to the columns 
comment on column TB_ATD_IEP_INT_EVOL_PACIENTE.cad_pro_id_profissional
  is 'IdtProfissionalResponsavelEvolucao';
comment on column TB_ATD_IEP_INT_EVOL_PACIENTE.tis_cbo_cd_cbos
  is 'EspecialidadeProfissionalResponsavelEvolucao';
-- Create/Recreate primary, unique and foreign key constraints 
alter table TB_ATD_IEP_INT_EVOL_PACIENTE
  add constraint FK_PRO_IEP foreign key (CAD_PRO_ID_PROFISSIONAL)
  references tb_cad_pro_profissional (CAD_PRO_ID_PROFISSIONAL);
alter table TB_ATD_IEP_INT_EVOL_PACIENTE
  add constraint FK_CBO_IEP foreign key (TIS_CBO_CD_CBOS)
  references tb_tis_cbo_cbos (TIS_CBO_CD_CBOS);
