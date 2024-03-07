-- Add/modify columns 
alter table TB_AGE_ESF_ESCALA_FALTAS add age_esf_hr_ini_falta number(4);
alter table TB_AGE_ESF_ESCALA_FALTAS add age_esf_hr_fim_falta number(4);
-- Add comments to the columns 
comment on column TB_AGE_ESF_ESCALA_FALTAS.age_esf_hr_ini_falta
  is 'HoraInicioFalta';
comment on column TB_AGE_ESF_ESCALA_FALTAS.age_esf_hr_fim_falta
  is 'HoraFimFalta';
-- Create/Recreate check constraints 
alter table TB_AGE_ESF_ESCALA_FALTAS
  add constraint CK_AGE_ESF_HR_INI_FALTA
  check (AGE_ESF_HR_INI_FALTA BETWEEN 0 AND 2359);
alter table TB_AGE_ESF_ESCALA_FALTAS
  add constraint CK_AGE_ESF_HR_FIM_FALTA
  check (AGE_ESF_HR_FIM_FALTA BETWEEN 0 AND 2359);