CREATE OR REPLACE PROCEDURE PRC_ATS_SEQUENCE_ATEND_S
(
   pAUX_EPP_CD_ESPECPROC IN TB_AUX_EPP_ESPECPROC.AUX_EPP_CD_ESPECPROC%TYPE,
   pSEQUENCE OUT NUMBER
)
is
BEGIN
-- especialidade 32-RADIODIAGNOSTICO
if (pAUX_EPP_CD_ESPECPROC = '32') then
   select SEQ_ATS_ESPEC32.NEXTVAL into pSEQUENCE from dual;
end if;
-- especialidade 20-CARDIOLOGIA
if (pAUX_EPP_CD_ESPECPROC = '20') then
   select SEQ_ATS_ESPEC20.NEXTVAL into pSEQUENCE from dual;
end if;
-- especialidade 33-ULTRASSONOGRAFIA
if (pAUX_EPP_CD_ESPECPROC = '33') then
   select SEQ_ATS_ESPEC33.NEXTVAL into pSEQUENCE from dual;
end if;
-- especialidade 34-TOMOGRAFIA COMPUTADORIZADA
if (pAUX_EPP_CD_ESPECPROC = '34') then
   select SEQ_ATS_ESPEC34.NEXTVAL into pSEQUENCE from dual;
end if;
-- especialidade 45-GINECOLOGIA E OBSTETRICIA
if (pAUX_EPP_CD_ESPECPROC = '45') then
   select SEQ_ATS_ESPEC45.NEXTVAL into pSEQUENCE from dual;
end if;
-- especialidade 56-UROLOGIA
if (pAUX_EPP_CD_ESPECPROC = '56') then
   select SEQ_ATS_ESPEC56.NEXTVAL into pSEQUENCE from dual;
end if;
-- especialidade 31-MEDICINA NUCLEAR
if (pAUX_EPP_CD_ESPECPROC = '31') then
   select SEQ_ATS_ESPEC31.NEXTVAL into pSEQUENCE from dual;
end if;
-- especialidade 36-RESSONANCIA MAGNETICA
if (pAUX_EPP_CD_ESPECPROC = '36') then
   select SEQ_ATS_ESPEC36.NEXTVAL into pSEQUENCE from dual;
end if;
-- especialidade 23-ENDOSCOPIA DIGESTIVA
if (pAUX_EPP_CD_ESPECPROC = '23') then
   select SEQ_ATS_ESPEC23.NEXTVAL into pSEQUENCE from dual;
end if;
-- especialidade 24-ENDOSCOPIA PERORAL
if (pAUX_EPP_CD_ESPECPROC = '24') then
   select SEQ_ATS_ESPEC24.NEXTVAL into pSEQUENCE from dual;
end if;
-- especialidade 21-ANATOMIA PATOLOGICA
if (pAUX_EPP_CD_ESPECPROC = '21') then
   select SEQ_ATS_ESPEC21.NEXTVAL into pSEQUENCE from dual;
end if;
-- especialidade 30-QUIMIOTERAPIA DO CANCER
if (pAUX_EPP_CD_ESPECPROC = '30') then
   select SEQ_ATS_ESPEC30.NEXTVAL into pSEQUENCE from dual;
end if;
-- especialidade 39-ANGIOLOGIA-CIRURGIA VASCULAR E LINFATICA
if (pAUX_EPP_CD_ESPECPROC = '39') then
   select SEQ_ATS_ESPEC39.NEXTVAL into pSEQUENCE from dual;
end if;
-- especialidade 40-CIRURGIA CARDIACA-HEMODINAMICA
if (pAUX_EPP_CD_ESPECPROC = '40') then
   select SEQ_ATS_ESPEC40.NEXTVAL into pSEQUENCE from dual;
end if;
-- especialidade 22-ELETROENCEFALOGRAFIA E NEUROFISIOLOGIA CLINICA
if (pAUX_EPP_CD_ESPECPROC = '22') then
   select SEQ_ATS_ESPEC22.NEXTVAL into pSEQUENCE from dual;
end if;
-- especialidade 29-TISIOPNEUMOLOGIA
if (pAUX_EPP_CD_ESPECPROC = '29') then
   select SEQ_ATS_ESPEC29.NEXTVAL into pSEQUENCE from dual;
end if;
END PRC_ATS_SEQUENCE_ATEND_S;
/
