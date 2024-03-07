CREATE OR REPLACE PROCEDURE "PRC_CRIA_ESCALA_PAGTO"
 (pDATA_INI                             IN DATE DEFAULT NULL,
  pDATA_FIM                             IN DATE DEFAULT NULL,
  pSEG_USU_ID_USUARIO                   IN TB_SEG_USU_USUARIO.SEG_USU_ID_USUARIO%TYPE,
  pCAD_UNI_ID_UNIDADE                   IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
  pCAD_PRO_ID_PROFISSIONAL              IN TB_CAD_PRO_PROFISSIONAL.CAD_PRO_ID_PROFISSIONAL%TYPE DEFAULT NULL,
  pMES_PAGTO                           IN NUMBER DEFAULT NULL,
  pANO_PAGTO                           IN NUMBER DEFAULT NULL,
  pCAD_CLC_ID                          in TB_CAD_CLC_CLINICA_CREDENCIADA.CAD_CLC_ID%TYPE DEFAULT NULL
) IS
  /********************************************************************
  *    PROCEDURE: PRC_CRIA_ESCALA_PAGTO
  *
  *    DATA CRIACAO:    30/12/2015         POR:
  *    DATA ALTERACAO:  DATA DA ALTERAC?O  POR: NOME DO ANALISTA
  *
  *    FUNCAO:
  *
  *******************************************************************/
hora_esm_pagto           number (10,4 );
hora_esm_escala          number;
hora_esf_pagto            number (10,4);
hora_esf_escala           number;

BEGIN

BEGIN


delete from  TB_REP_HEP_HORAS_ESCALA_PAGTO  hep
where hep.hep_mes_pagamento = pmes_pagto
and hep.Hep_ano_pagamento   = pano_pagto
and hep.hep_fl_status_pago= 'N' 
and hep.cad_pro_id_profissional = decode( pcad_pro_id_profissional , null, hep.cad_pro_id_profissional, pcad_pro_id_profissional )
and hep.cad_clc_id = pcad_clc_id 
and hep.cad_uni_id_unidade = decode( pcad_uni_id_unidade , null, hep.cad_uni_id_unidade, pcad_uni_id_unidade );

-----
-----

 FOR t  IN
(SELECT   
  DISTINCT
  'ESM' Tabela,
   ESM.AGE_ESM_ID,
   0   age_esf_id,
   decode (ESM.AGE_ESM_TP_ESCALA , 1 , 'NORMAL' ,
                                    2 , 'REPOSICAO',
                                    3 , 'EXTRA' , ESM.AGE_ESM_TP_ESCALA ) TIPO_ESCALA ,
  ESM.AGE_ESM_FL_SITUACAO,
  ESM.CAD_UNI_ID_UNIDADE,
  ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO,
  ESM.CAD_PRO_ID_PROFISSIONAL,
  ESM.TIS_CBO_CD_CBOS,
  DECODE(ESM.AGE_ESM_NR_DIA_SEMANA,1,'SEGUNDA',
                                  2,'TERÇA',3,'QUARTA',4,'QUINTA',
                                  5,'SEXTA',6,'SABADO',7,'DOMINGO') DIA_SEMANA,
 AGG.AGE_AGG_DT_AGENDA,
 ESM.AGE_ESM_HR_INI_ESCALA,
 ESM.AGE_ESM_HR_FIM_ESCALA,
 null age_esf_dt_ini_falta,
 null age_esf_dt_fim_falta,
 null AGE_ESF_HR_INI_FALTA  ,
 null AGE_ESF_HR_FIM_FALTA  ,
 null cad_pro_id_profissional_subst
FROM SGS.TB_AGE_ESM_ESCALA_MEDICA ESM,
     TB_CAD_PRO_PROFISSIONAL PRO,
     SGS.TB_AGE_AGG_AGENDA_GERADA AGG
where   ESM.AGE_ESM_FL_SITUACAO IN (   'A',    'I' )
  AND   ESM.AGE_ESM_FL_AGENDAGERADA_OK = 'S'
  AND   ESM.AGE_ESM_DT_INI_ESCALA <=pDATA_FIM  --PARAMETRO DATA FIM,
and esm.cad_pro_id_profissional =  decode( pcad_pro_id_profissional , null, esm.cad_pro_id_profissional,
                                                              pcad_pro_id_profissional )    
and esm.cad_uni_id_unidade = decode( pcad_uni_id_unidade , null, esm.cad_uni_id_unidade,
                                                                 pcad_uni_id_unidade )                                                               
 AND ESM.CAD_PRO_ID_PROFISSIONAL = PRO.CAD_PRO_ID_PROFISSIONAL
   -------***********************************************
  -------   SGS.FNC_AGE_ESM_DIAS_DISPONIVEIS
  AND AGG.AGE_ESM_ID = ESM.AGE_ESM_ID
  AND (AGG.AGE_AGG_DT_AGENDA <= ESM.AGE_ESM_DT_FIM_ESCALA 
                                           OR ESM.AGE_ESM_DT_FIM_ESCALA IS NULL)
  AND AGG.AGE_AGG_DT_AGENDA BETWEEN pDATA_INI AND pDATA_FIM 
  AND fnc_verifica_feriado_sgs(AGG.AGE_AGG_DT_AGENDA,esm.cad_uni_id_unidade,NULL) = 0
  AND EXISTS (  SELECT CPR.CAD_PRO_ID_PROFISSIONAL  
                          FROM TB_ASS_CPR_CLINICA_PROF CPR,
                                   TB_CAD_CLC_CLINICA_CREDENCIADA CLC ,
                                   TB_ASS_RPG_REGRA_PAGTO RPG,
                                   TB_CAD_REP_REGRA_PAGAMENTO REP
                          WHERE  CPR.CAD_CLC_ID=CLC.CAD_CLC_ID
                          AND CPR.CAD_PRO_ID_PROFISSIONAL= ESM.CAD_PRO_ID_PROFISSIONAL
                          AND CLC.CAD_CLC_ID =  PCAD_CLC_ID
                          AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                          AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                          AND CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                          AND RPG.CAD_REP_ID=REP.CAD_REP_ID
                          AND REP.CAD_REP_TP_BASE_CALCULO='VLHORA'
                          AND CPR.CAD_UNI_ID_UNIDADE=ESM.CAD_UNI_ID_UNIDADE
                          AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO = ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO)
-------------------------
union all    ----- juntar registro das faltas
 SELECT  --- buscar faltas
   DISTINCT 'ESF' TB,
   ESM.AGE_ESM_ID,
   esf.age_esf_id,
   decode (ESM.AGE_ESM_TP_ESCALA , 1 , 'NORMAL' ,
                                   2 , 'REPOSICAO',
                                   3 , 'EXTRA' , ESM.AGE_ESM_TP_ESCALA ) TIPO_ESCALA ,
   ESM.AGE_ESM_FL_SITUACAO,
   ESM.CAD_UNI_ID_UNIDADE,
   ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO,
   ESM.CAD_PRO_ID_PROFISSIONAL,
   ESM.TIS_CBO_CD_CBOS,
   DECODE(ESM.AGE_ESM_NR_DIA_SEMANA,1,'SEGUNDA',
                                2,'TERÇA',3,'QUARTA',4,'QUINTA',5,'SEXTA',6,'SABADO',7,'DOMINGO') DIA_SEMANA,
   AGG.AGE_AGG_DT_AGENDA,
   ESM.AGE_ESM_HR_INI_ESCALA ,
   ESM.AGE_ESM_HR_FIM_ESCALA,
   esf.age_esf_dt_ini_falta,
   esf.age_esf_dt_fim_falta,
   DECODE ( ESF.AGE_ESF_HR_INI_FALTA, NULL, ESM.AGE_ESM_HR_INI_ESCALA, ESF.AGE_ESF_HR_INI_FALTA)  AGE_ESF_HR_INI_FALTA ,
   DECODE ( ESF.AGE_ESF_HR_FIM_FALTA, NULL, ESM.AGE_ESM_HR_FIM_ESCALA, ESF.AGE_ESF_HR_FIM_FALTA)  AGE_ESF_HR_FIM_FALTA ,
   esf.cad_pro_id_profissional_subst
  FROM SGS.TB_AGE_ESM_ESCALA_MEDICA ESM,
       TB_CAD_PRO_PROFISSIONAL PRO,
       TB_AGE_AGG_AGENDA_GERADA AGG,
       TB_AGE_ESF_ESCALA_FALTAS ESF  ---- BUSCA FALTA
  WHERE
    ESM.AGE_ESM_FL_SITUACAO IN ('A', 'I' )   
    AND ESM.AGE_ESM_FL_AGENDAGERADA_OK = 'S'
    AND ESM.AGE_ESM_DT_INI_ESCALA <=pDATA_FIM  --PARAMETRO DATA FIM,
    AND fnc_verifica_feriado_sgs(AGG.AGE_AGG_DT_AGENDA,esm.cad_uni_id_unidade,NULL) = 0
    and esm.cad_pro_id_profissional = decode( pcad_pro_id_profissional , null, esm.cad_pro_id_profissional,
                                                                 pcad_pro_id_profissional )  
    and esm.cad_uni_id_unidade = decode( pcad_uni_id_unidade , null, esm.cad_uni_id_unidade,
                                                                 pcad_uni_id_unidade )                                                               
    AND ESM.CAD_PRO_ID_PROFISSIONAL = PRO.CAD_PRO_ID_PROFISSIONAL  
    AND AGG.AGE_ESM_ID = ESM.AGE_ESM_ID
    AND (AGG.AGE_AGG_DT_AGENDA <= ESM.AGE_ESM_DT_FIM_ESCALA OR ESM.AGE_ESM_DT_FIM_ESCALA IS NULL)
 --- agenda do dia da falta
    and  AGG.AGE_AGG_DT_AGENDA   BETWEEN   ESF.AGE_ESF_DT_INI_FALTA AND ESF.AGE_ESF_DT_FIM_FALTA
    and  AGG.AGE_AGG_DT_AGENDA   BETWEEN   pDATA_INI   AND   pDATA_FIM
    and agg.age_esm_id = ESF.AGE_ESM_ID
    and agg.age_esf_id = esf.age_esf_id
    AND EXISTS (  SELECT CPR.CAD_PRO_ID_PROFISSIONAL 
                          FROM TB_ASS_CPR_CLINICA_PROF CPR,
                                   TB_CAD_CLC_CLINICA_CREDENCIADA CLC ,
                                   TB_ASS_RPG_REGRA_PAGTO RPG,
                                   TB_CAD_REP_REGRA_PAGAMENTO REP
                          WHERE  CPR.CAD_CLC_ID=CLC.CAD_CLC_ID
                          AND CPR.CAD_PRO_ID_PROFISSIONAL= ESM.CAD_PRO_ID_PROFISSIONAL
                          AND CLC.CAD_CLC_ID = PCAD_CLC_ID
                          AND CPR.ASS_CPR_DT_FIM_VIGENCIA IS NULL
                          AND RPG.CAD_REP_DT_FIM_VIGENCIA IS NULL
                          AND CPR.ASS_CPR_ID = RPG.ASS_CPR_ID
                          AND RPG.CAD_REP_ID=REP.CAD_REP_ID
                          AND REP.CAD_REP_TP_BASE_CALCULO='VLHORA'
                          AND CPR.CAD_UNI_ID_UNIDADE=ESM.CAD_UNI_ID_UNIDADE
                          AND CPR.CAD_LAT_ID_LOCAL_ATENDIMENTO = ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO)
    )
    ---
    loop
begin
  ---- calculo de horas e conversao

hora_esm_pagto   :=0;
hora_esm_escala  :=0;
hora_esf_pagto    :=0;
hora_esf_escala   :=0;


   if t.tabela = 'ESM'  then 
         ---- 
         ---- calcula hora esm pagto com 4 decimais
         select    sgs.fnc_rep_horas_escala_pagto  (
                           fnc_juntar_data_hora (trunc(SYSDATE) ,  t.AGE_ESM_HR_INI_ESCALA) ,
                           fnc_juntar_data_hora (trunc(SYSDATE) ,  t.AGE_ESM_HR_fim_ESCALA) , 1 , 00 ) 
         into  hora_esm_pagto  from dual;
         ----       
         ---- converte hora esm escala
        select  sgs.fnc_rep_horas_escala_pagto  (
                       SYSDATE  ,  SYSDATE ,  3 ,  hora_esm_pagto ) 
           into hora_esm_escala  from dual;
  else
         ---- 
         ---- calcula hora esm pagto com 4 decimais
         select    sgs.fnc_rep_horas_escala_pagto  (
                           fnc_juntar_data_hora (trunc(SYSDATE) ,  t.AGE_ESF_HR_INI_FALTA) ,
                           fnc_juntar_data_hora (trunc(SYSDATE) ,  t.AGE_ESF_HR_fim_FALTA) , 1 , 00 ) 
         into  hora_esf_pagto     from dual;
         -----
         ---- converte hora esm escala
         select  sgs.fnc_rep_horas_escala_pagto  (
                     SYSDATE , SYSDATE, 3 , hora_esf_pagto ) 
         into hora_esf_escala  from dual;
 end if;
  


  ----

insert into TB_REP_HEP_HORAS_ESCALA_PAGTO

  (hep_TABELA_movimento                        ,
  AGE_ESM_ID               ,
  AGE_ESF_ID                ,
  hep_TIPO_ESCALA              ,
  AGE_ESM_FL_SITUACAO,
  CAD_UNI_ID_UNIDADE  ,
  CAD_LAT_ID_LOCAL_ATENDIMENTO,
  CAD_PRO_ID_PROFISSIONAL ,
  TIS_CBO_CD_CBOS,
  hep_DIA_SEMANA                   ,
  AGE_AGG_DT_AGENDA      ,
  AGE_ESM_HR_INI_ESCALA ,
  AGE_ESM_HR_FIM_ESCALA ,
  AGE_ESF_DT_INI_FALTA    ,
  AGE_ESF_DT_FIM_FALTA   ,
  AGE_ESF_HR_INI_FALTA   ,
  AGE_ESF_HR_FIM_FALTA  ,
  CAD_PRO_ID_PROFISSIONAL_SUBST ,
  hep_HORA_ESM_PAGTO                ,
  hep_HORA_ESM_ESCALA               ,
  hep_HORA_ESF_PAGTO                 ,
  hep_HORA_ESF_ESCALA                ,
  hep_MES_PAGAMENTO                  ,
  hep_ANO_PAGAMENTO                  ,
  hep_FL_STATUS_PAGO           ,
  CAD_CLC_ID , 
  hep_DT_CRIACAO ,
  SEG_USU_ID_USUARIO_CRIACAO  
 )
  values
  (t.TABELA                        ,
  t.AGE_ESM_ID               ,
  t.AGE_ESF_ID                ,
  t.TIPO_ESCALA              ,
  t.AGE_ESM_FL_SITUACAO,
  t.CAD_UNI_ID_UNIDADE  ,
  t.CAD_LAT_ID_LOCAL_ATENDIMENTO,
  t.CAD_PRO_ID_PROFISSIONAL ,
  t.TIS_CBO_CD_CBOS,
  t.DIA_SEMANA                   ,
  t.AGE_AGG_DT_AGENDA      ,
  t.AGE_ESM_HR_INI_ESCALA ,
  t.AGE_ESM_HR_FIM_ESCALA ,
  t.AGE_ESF_DT_INI_FALTA    ,
  t.AGE_ESF_DT_FIM_FALTA   ,
  t.AGE_ESF_HR_INI_FALTA   ,
  t.AGE_ESF_HR_FIM_FALTA  ,
  t.CAD_PRO_ID_PROFISSIONAL_SUBST ,
     HORA_ESM_PAGTO  ,
     HORA_ESM_ESCALA ,
     HORA_ESF_PAGTO   ,
     HORA_ESF_ESCALA  ,
  PMES_PAGTO                  ,
  PANO_PAGTO                  ,
  'N',       --- REP_FL_STATUS_PAGO           ,
  PCAD_CLC_ID ,
  SYSDATE,
  pSEG_USU_ID_USUARIO);
end;
end loop;
commit; 
end;
PRC_REP_IMP_CLI_PRODUCAO(pDATA_INI, pDATA_FIM, pSEG_USU_ID_USUARIO, pCAD_UNI_ID_UNIDADE, pCAD_PRO_ID_PROFISSIONAL, pMES_PAGTO, pANO_PAGTO, pCAD_CLC_ID );
END PRC_CRIA_ESCALA_PAGTO;
