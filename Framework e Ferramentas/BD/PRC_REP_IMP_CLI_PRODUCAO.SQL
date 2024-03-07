CREATE OR REPLACE PROCEDURE "PRC_REP_IMP_CLI_PRODUCAO"
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
  *    PROCEDURE: PRC_REP_IMP_SANTOS_CLINICA
  *
  *    DATA CRIACAO:    20/02/2013         POR:
  *    DATA ALTERACAO:  DATA DA ALTERAC?O  POR: NOME DO ANALISTA
  *
  *    FUNCAO:
  *
  *******************************************************************/
BEGIN
 BEGIN
  FOR TEMP IN (select clc.cad_clc_id, 
clc.cad_clc_ds_descricao,
uni.cad_uni_id_unidade unid ,
uni.cad_uni_ds_unidade,
lat.cad_lat_id_local_atendimento loc,  
lat.cad_lat_cd_local_atendimento,
pro.tis_cpr_cd_conselhoprof,
pro.cad_pro_id_profissional, 
pro.cad_pro_nr_conselho,
 pro.cad_pro_nm_nome, 
 cbos.tis_cbo_cd_cbos,
 cbos.tis_cbo_cd_cbos_hac,
  cbos.tis_cbo_ds_cbos_hac, 
  sgs.fnc_rep_horas_escala_pagto (
  SYSDATE  ,  SYSDATE ,  3 ,  sum(round(hep.hep_hora_esm_pagto,2)) ) HORAS_DISPONIVEIS,
  sum(round(hep.hep_hora_esm_pagto,2)) HORAS_DISP_PAGTO,
  sgs.fnc_rep_horas_escala_pagto  (
  SYSDATE  ,  SYSDATE ,  3 ,  sum(round(hepFALTA.hep_hora_esf_pagto,2)) ) HORAS_FALTA,
 sum(round(hepFALTA.hep_hora_esf_pagto,2)) HORAS_FALTA_PAGTO,
sgs.fnc_rep_horas_escala_pagto (
                       SYSDATE  ,  SYSDATE ,  3 , (sum(round(hep.hep_hora_esm_pagto,2)) -  nvl(sum(round(hepFALTA.hep_hora_esf_pagto,2)),0)) ) HORAS_AGENDA,
  (sum(round(hep.hep_hora_esm_pagto,2)) -  nvl(sum(round(hepFALTA.hep_hora_esf_pagto,2)),0)) HORAS_PAGTO          
 FROM
  TB_REP_HEP_HORAS_ESCALA_PAGTO hep,
  TB_REP_HEP_HORAS_ESCALA_PAGTO  hepfalta,
 tb_cad_pro_profissional pro, tb_tis_cbo_cbos cbos,
  tb_cad_uni_unidade uni,
  tb_cad_lat_local_atendimento lat,
  tb_cad_clc_clinica_credenciada clc
  where hep.cad_uni_id_unidade = uni.cad_uni_id_unidade
  and hep.cad_lat_id_local_atendimento = lat.cad_lat_id_local_atendimento
  and hep.cad_pro_id_profissional = pro.cad_pro_id_profissional
  and hep.tis_cbo_cd_cbos = cbos.tis_cbo_cd_cbos
  and clc.cad_clc_id= HEP.cad_clc_id
  and clc.cad_clc_id = pCAD_CLC_ID 
  and hep.hep_ano_pagamento = pANO_PAGTO 
  and hep.hep_mes_pagamento = pMES_PAGTO
  and hep.HEP_TABELA_MOVIMENTO = 'ESM'
  and (pCAD_UNI_ID_UNIDADE IS NULL OR hep.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE)
                                  AND hep.cad_lat_id_local_atendimento = 27
                                  AND (pCAD_PRO_ID_PROFISSIONAL IS NULL OR hep.cad_pro_id_profissional = pCAD_PRO_ID_PROFISSIONAL)
  and hep.age_esm_id = hepfalta.age_esm_id(+)
  and hep.age_agg_dt_agenda = hepfalta.age_agg_dt_agenda(+)
  and hepfalta.HEP_TABELA_MOVIMENTO(+)='ESF'
    group by 
     clc.cad_clc_id, clc.cad_clc_ds_descricao,
uni.cad_uni_id_unidade, uni.cad_uni_ds_unidade,
lat.cad_lat_id_local_atendimento,  lat.cad_lat_cd_local_atendimento,
   pro.tis_cpr_cd_conselhoprof,
   pro.cad_pro_id_profissional, 
   pro.cad_pro_nr_conselho,
 pro.cad_pro_nm_nome, 
 cbos.tis_cbo_cd_cbos,
 cbos.tis_cbo_cd_cbos_hac,
  cbos.tis_cbo_ds_cbos_hac   
  order by                                                                          
  uni.cad_uni_ds_unidade,
lat.cad_lat_id_local_atendimento,  cbos.tis_cbo_cd_cbos,   pro.cad_pro_nr_conselho      
               ) LOOP
    BEGIN
      INSERT INTO TB_CAD_HTR_HORA_TRAB
        (CAD_HTR_ID,
         CAD_UNI_ID_UNIDADE,
         CAD_LAT_ID_LOCAL_ATENDIMENTO,
         CAD_PRO_ID_PROFISSIONAL,
         TIS_CBO_CD_CBOS,
         CAD_HTR_DT_INICIO_VIGENCIA,
         CAD_HTR_DT_FIM_VIGENCIA,
         CAD_HTR_QT_HORA_SEMANA,
         CAD_HTR_VL_FATOR_MULTI_SEMANA,
         CAD_HTR_DT_ULTIMA_ATUALIZACAO,
         SEG_USU_ID_USUARIO)
      VALUES
        (SEQ_CAD_HTR_01.NEXTVAL,
         TEMP.UNID,
         TEMP.LOC,
         TEMP.CAD_PRO_ID_PROFISSIONAL,
         TEMP.TIS_CBO_CD_CBOS,
         pDATA_INI,
         pDATA_FIM,
         TEMP.HORAS_PAGTO,
         1.00,
         SYSDATE,
         PSEG_USU_ID_USUARIO);
    EXCEPTION
      WHEN DUP_VAL_ON_INDEX THEN
        NULL;
    END;
  END LOOP;
  COMMIT;
  END;
END PRC_REP_IMP_CLI_PRODUCAO;
 
/
