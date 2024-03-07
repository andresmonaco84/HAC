CREATE OR REPLACE PROCEDURE PRC_AGE_REL_PROD_MEDICA( pCAD_UNI_ID_UNIDADE           IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE,
                                                     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE,
                                                     pTIS_CBO_CD_CBOS              IN TB_TIS_CBO_CBOS.TIS_CBO_CD_CBOS%TYPE,
                                                     pDATA_INI                     IN TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_DT_INI_ESCALA%TYPE,
                                                     pDATA_FIM                     IN TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_DT_FIM_ESCALA%TYPE,
                                                     io_cursor                     OUT PKG_CURSOR.t_cursor) IS
v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
    SELECT RESULTADO.CAD_PRO_ID_PROFISSIONAL,
           TRUNC(RESULTADO.HORAS_DISPONIVEIS) || ':' ||  to_char(extract (minute from numtodsinterval(RESULTADO.HORAS_DISPONIVEIS, 'HOUR' )),'00') HORAS_DISPONIVEIS,
           RESULTADO.HORAS_DISPONIVEIS  HORAS_DISPONIVEIS_DECIMAL,
           RESULTADO.CAD_PRO_NR_CONSELHO,
           RESULTADO.CAD_PRO_NM_NOME CAD_PES_NM_PESSOA,
           TOTAL_RETORNO,
           TOTAL_NORMAL,
           TOTAL_ENCAIXE_ESPECIAL,
           TOTAL_SERVICO_PRESTADO,
           TOTAL_ENCAIXE,
            Round(((CAPACIDADE + CAPACIDADE_RETORNO) - (NVL(((CAPACIDADE + CAPACIDADE_RETORNO) / RESULTADO.HORAS_DISPONIVEIS),0) * HORAS_FALTA)),2) CAPACIDADE_ATE_REAL,
           Round(NVL(((CAPACIDADE + CAPACIDADE_RETORNO) / RESULTADO.HORAS_DISPONIVEIS),0),2) ATDHORA,
           TRUNC(HORAS_TRABALHADAS) || ':' ||  to_char(extract (minute from numtodsinterval(HORAS_TRABALHADAS, 'HOUR' )),'00') HORAS_TRABALHADAS,
           HORAS_TRABALHADAS HORAS_TRABALHADAS_DECIMAL,
           TRUNC(HORAS_FALTA) || ':' ||  to_char(extract (minute from numtodsinterval(HORAS_FALTA, 'HOUR' )),'00') HORAS_FALTA,
           HORAS_FALTA HORAS_FALTA_DECIMAL,
           TOTAL_FALTA_PAC,
           RESULTADO.ESPECIALIDADE,
           TO_CHAR(DECODE((TOTAL_RETORNO + TOTAL_NORMAL +
                          TOTAL_ENCAIXE_ESPECIAL + TOTAL_SERVICO_PRESTADO +
                          TOTAL_ENCAIXE + TOTAL_TELEMEDICINA),
                          0,
                          0,
                          ALTA / (TOTAL_RETORNO + TOTAL_NORMAL +
                          TOTAL_ENCAIXE_ESPECIAL +
                          TOTAL_SERVICO_PRESTADO + TOTAL_ENCAIXE + TOTAL_TELEMEDICINA) * 100),
                   '00.00') ALTA,
           TO_CHAR(DECODE((TOTAL_RETORNO + TOTAL_NORMAL +
                          TOTAL_ENCAIXE_ESPECIAL + TOTAL_SERVICO_PRESTADO +
                          TOTAL_ENCAIXE + TOTAL_TELEMEDICINA),
                          0,
                          0,
                          INTERNACAO /
                          (TOTAL_RETORNO + TOTAL_NORMAL +
                          TOTAL_ENCAIXE_ESPECIAL + TOTAL_SERVICO_PRESTADO +
                          TOTAL_ENCAIXE + TOTAL_TELEMEDICINA) * 100),
                   '00.00') INTERNACAO,
           TO_CHAR(DECODE((TOTAL_RETORNO + TOTAL_NORMAL +
                          TOTAL_ENCAIXE_ESPECIAL + TOTAL_SERVICO_PRESTADO +
                          TOTAL_ENCAIXE + TOTAL_TELEMEDICINA),
                          0,
                          0,
                          RETORNO / (TOTAL_RETORNO + TOTAL_NORMAL +
                          TOTAL_ENCAIXE_ESPECIAL +
                          TOTAL_SERVICO_PRESTADO + TOTAL_ENCAIXE + TOTAL_TELEMEDICINA) * 100),
                   '00.00') RETORNO,
           TO_CHAR(DECODE((TOTAL_RETORNO + TOTAL_NORMAL +
                          TOTAL_ENCAIXE_ESPECIAL + TOTAL_SERVICO_PRESTADO +
                          TOTAL_ENCAIXE + TOTAL_TELEMEDICINA),
                          0,
                          0,
                          RETORNO_SADT /
                          (TOTAL_RETORNO + TOTAL_NORMAL +
                          TOTAL_ENCAIXE_ESPECIAL + TOTAL_SERVICO_PRESTADO +
                          TOTAL_ENCAIXE + TOTAL_TELEMEDICINA) * 100),
                   '00.00') RETORNO_SADT,
           TO_CHAR(DECODE((TOTAL_RETORNO + TOTAL_NORMAL +
                          TOTAL_ENCAIXE_ESPECIAL + TOTAL_SERVICO_PRESTADO +
                          TOTAL_ENCAIXE + TOTAL_TELEMEDICINA),
                          0,
                          0,
                          CRONICO / (TOTAL_RETORNO + TOTAL_NORMAL +
                          TOTAL_ENCAIXE_ESPECIAL +
                          TOTAL_SERVICO_PRESTADO + TOTAL_ENCAIXE + TOTAL_TELEMEDICINA) * 100),
                   '00.00') CRONICO,
           TO_CHAR(DECODE((TOTAL_RETORNO + TOTAL_NORMAL +
                          TOTAL_ENCAIXE_ESPECIAL + TOTAL_SERVICO_PRESTADO +
                          TOTAL_ENCAIXE + TOTAL_TELEMEDICINA),
                          0,
                          0,
                          ESPECIALISTA /
                          (TOTAL_RETORNO + TOTAL_NORMAL +
                          TOTAL_ENCAIXE_ESPECIAL + TOTAL_SERVICO_PRESTADO +
                          TOTAL_ENCAIXE + TOTAL_TELEMEDICINA) * 100),
                   '00.00') ESPECIALISTA,
           ROUND(CAPACIDADE + CAPACIDADE_RETORNO) CAPACIDADE_ATENDIMENTOS,
           ROUND(NAOREMARCADOS) NAOREMARCADOS,
                      ROUND(CANCELADOS) CANCELADOS,
                   ROUND(HORA_LIVRE) HORA_LIVRE,
           ROUND(NVL(ATEND_DESISTENTE,0)) ATEND_DESISTENTE,
           ROUND(NVL(ATEND_NAOAGE,0)) ATEND_NAOAGE  ,
           TOTAL_TELEMEDICINA
           ,AGE_ESM_FL_AGEND_GRUPO

      FROM (SELECT TMP.CAD_PRO_ID_PROFISSIONAL,
                   NVL(ROUND(SUM(HOAS_DISPONIVEIS),2),0) HORAS_DISPONIVEIS,
                   PRO.CAD_PRO_NR_CONSELHO,
                   PRO.CAD_PRO_NM_NOME,
                   SUM(TOTAL_RETORNO) TOTAL_RETORNO,
                   SUM(TOTAL_NORMAL) TOTAL_NORMAL,
                   SUM(TOTAL_ENCAIXE_ESPECIAL) TOTAL_ENCAIXE_ESPECIAL,
                   SUM(TOTAL_SERVICO_PRESTADO) TOTAL_SERVICO_PRESTADO,
                   SUM(TOTAL_ENCAIXE) TOTAL_ENCAIXE,
                   NVL(ROUND(SUM(HORAS_TRABALHADAS),2)-ROUND(SUM(HORAS_FALTA_PARCIAL),2),0) HORAS_TRABALHADAS,
                   NVL(ROUND(SUM(HORAS_FALTA),2),0) HORAS_FALTA,
                   NVL(ROUND(SUM(HORAS_FALTA_PARCIAL),2),0) HORAS_FALTA_PARCIAL,
                   ROUND(SUM(HORAS_FALTA_PAC)) TOTAL_FALTA_PAC,
                   SUM(CAPACIDADE) CAPACIDADE,
                   SUM(ALTA) ALTA,
                   SUM(INTERNACAO) INTERNACAO,
                   SUM(RETORNO) RETORNO,
                   SUM(RETORNOSADT) RETORNO_SADT,
                   SUM(CRONICO) CRONICO,
                   SUM(ESPECIALISTA) ESPECIALISTA,
                   SUM(CAPACIDADE_RETORNO) CAPACIDADE_RETORNO,
                   SUM(NAOREMARCADOS) NAOREMARCADOS,
                   SUM(CANCELADOS) CANCELADOS,
                   SUM(HORA_LIVRE) HORA_LIVRE,
                   SUM(TOTAL_TELEMEDICINA) TOTAL_TELEMEDICINA,
                          (SGS.FNC_AGE_ATEND_STATUS(TMP.TIS_CBO_CD_CBOS,TMP.CAD_UNI_ID_UNIDADE,TMP.CAD_LAT_ID_LOCAL_ATENDIMENTO,TMP.CAD_PRO_ID_PROFISSIONAL,pDATA_INI, pDATA_FIM,NULL,'D',tmp.age_esm_fl_agend_grupo )) ATEND_DESISTENTE,
                   (SGS.FNC_AGE_ATEND_FORA_DA_ESCALA(TMP.TIS_CBO_CD_CBOS, TMP.CAD_UNI_ID_UNIDADE, TMP.CAD_LAT_ID_LOCAL_ATENDIMENTO, TMP.CAD_PRO_ID_PROFISSIONAL, pDATA_INI, pDATA_FIM, NULL,tmp.age_esm_fl_agend_grupo)) ATEND_NAOAGE,
                   CBO.TIS_CBO_DS_CBOS_hac ESPECIALIDADE
                   ,tmp.age_esm_fl_agend_grupo

              FROM ( SELECT ESM.CAD_PRO_ID_PROFISSIONAL,
                            CBO.TIS_CBO_CD_CBOS,
                            ESM.CAD_UNI_ID_UNIDADE,ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                            decode(esm.age_esm_fl_agend_grupo,null,'N',esm.age_esm_fl_agend_grupo) age_esm_fl_agend_grupo,
                           (SGS.FNC_AGE_ESM_DIAS_DISPONIVEIS(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM) * (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA)) / 100 HOAS_DISPONIVEIS,
                           (SGS.FNC_AGE_ESM_TIPO_RETORNO(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) TOTAL_RETORNO,
                           (SGS.FNC_AGE_ESM_TIPO_NORMAL(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) TOTAL_NORMAL,
                           (SGS.FNC_AGE_ESM_TIPO_EE(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) TOTAL_ENCAIXE_ESPECIAL,
                           (SGS.FNC_AGE_ESM_TIPO_SP(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) TOTAL_SERVICO_PRESTADO,
                           (SGS.FNC_AGE_ESM_TIPO_ENCAIXE(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) TOTAL_ENCAIXE,
                           (SGS.FNC_AGE_ESM_DIAS_ATENDIDOS(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM) * (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA)) / 100 HORAS_TRABALHADAS,
                           NVL((SGS.FNC_AGE_ESM_TOTAL_FALTAS(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM) * (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA)) / 100, 0) HORAS_FALTA,
                           NVL((SGS.FNC_AGE_ESM_TOTAL_FALTAS2(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM) ) , 0) HORAS_FALTA_PARCIAL,
                           (SGS.FNC_AGE_ESM_TOTAL_FALTA_PAC(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) HORAS_FALTA_PAC,
                           (SGS.FNC_AGE_ESM_DEST_ALTA(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ALTA,
                           (SGS.FNC_AGE_ESM_DEST_INTERNACAO(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) INTERNACAO,
                           (SGS.FNC_AGE_ESM_DEST_RETORNO(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) RETORNO,
                           (SGS.FNC_AGE_ESM_DEST_RETORNOSADT(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) RETORNOSADT,
                           (SGS.FNC_AGE_ESM_DEST_CRONICO(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) CRONICO,
                           (SGS.FNC_AGE_ESM_DEST_ESPEC(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ESPECIALISTA,
                           (SGS.FNC_AGE_ESM_CAPAC_NORMAL_SP(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) CAPACIDADE,
                           (SGS.FNC_AGE_ESM_CAPAC_RETORNO(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) CAPACIDADE_RETORNO,
                           (SGS.FNC_AGE_HORA_LIVRE(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) HORA_LIVRE,
                           (SGS.FNC_ESM_CANCELADOS(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) NAOREMARCADOS,
                           (SGS.FNC_ESM_CANCELADOS2(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) CANCELADOS,
                           (SGS.FNC_AGE_ESM_TIPO_TELEMEDICINA(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) TOTAL_TELEMEDICINA

                      FROM TB_AGE_ESM_ESCALA_MEDICA ESM,
                           TB_ASS_PCB_PROFISSIONAL_CBOS PCB,
                           TB_TIS_CBO_CBOS CBO
                     WHERE ESM.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
                       AND ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
                       AND (pTIS_CBO_CD_CBOS IS NULL OR ESM.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS)
                       AND ESM.AGE_ESM_FL_SITUACAO IN ('A', 'S')
                       AND ESM.AGE_ESM_FL_AGENDAGERADA_OK = 'S'
                       AND ESM.AGE_ESM_DT_INI_ESCALA <= pDATA_FIM
                       AND ESM.CAD_PRO_ID_PROFISSIONAL = PCB.CAD_PRO_ID_PROFISSIONAL
                       AND PCB.TIS_CBO_CD_CBOS = CBO.TIS_CBO_CD_CBOS
                       AND CBO.TIS_CBO_CD_CBOS = ESM.TIS_CBO_CD_CBOS
                       group by ESM.CAD_PRO_ID_PROFISSIONAL,
                            CBO.TIS_CBO_CD_CBOS,
                            ESM.CAD_UNI_ID_UNIDADE,ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                            decode(esm.age_esm_fl_agend_grupo,null,'N',esm.age_esm_fl_agend_grupo) ,
                           (SGS.FNC_AGE_ESM_DIAS_DISPONIVEIS(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM) * (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA)) / 100 ,
                           (SGS.FNC_AGE_ESM_TIPO_RETORNO(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_TIPO_NORMAL(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_TIPO_EE(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_TIPO_SP(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_TIPO_ENCAIXE(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_DIAS_ATENDIDOS(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM) * (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA)) / 100 ,
                           NVL((SGS.FNC_AGE_ESM_TOTAL_FALTAS(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM) * (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA)) / 100, 0) ,
                        NVL((SGS.FNC_AGE_ESM_TOTAL_FALTAS2(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM) ) , 0) ,
                           (SGS.FNC_AGE_ESM_TOTAL_FALTA_PAC(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_DEST_ALTA(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_DEST_INTERNACAO(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_DEST_RETORNO(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_DEST_RETORNOSADT(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_DEST_CRONICO(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_DEST_ESPEC(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_CAPAC_NORMAL_SP(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_CAPAC_RETORNO(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_HORA_LIVRE(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_ESM_CANCELADOS(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_ESM_CANCELADOS2(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_TIPO_TELEMEDICINA(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM))
                    UNION ALL
                    SELECT ESM.CAD_PRO_ID_PROFISSIONAL,
                           CBO.TIS_CBO_CD_CBOS,
                           ESM.CAD_UNI_ID_UNIDADE,ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                           decode(esm.age_esm_fl_agend_grupo,null,'N',esm.age_esm_fl_agend_grupo) age_esm_fl_agend_grupo,
                           (SGS.FNC_AGE_ESM_DIAS_DISPONIVEIS(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM) * (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA)) / 100 HOAS_DISPONIVEIS,
                           (SGS.FNC_AGE_ESM_TIPO_RETORNO(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) TOTAL_RETORNO,
                           (SGS.FNC_AGE_ESM_TIPO_NORMAL(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) TOTAL_NORMAL,
                           (SGS.FNC_AGE_ESM_TIPO_EE(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) TOTAL_ENCAIXE_ESPECIAL,
                           (SGS.FNC_AGE_ESM_TIPO_SP(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) TOTAL_SERVICO_PRESTADO,
                           (SGS.FNC_AGE_ESM_TIPO_ENCAIXE(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) TOTAL_ENCAIXE,
                           (SGS.FNC_AGE_ESM_DIAS_ATENDIDOS(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM) * (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA)) / 100 HORAS_TRABALHADAS,
                           (SGS.FNC_AGE_ESM_TOTAL_FALTAS(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM) * (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA)) / 100 HORAS_FALTA,
                          NVL((SGS.FNC_AGE_ESM_TOTAL_FALTAS2(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM) ) , 0) HORAS_FALTA_PARCIAL,
                           (SGS.FNC_AGE_ESM_TOTAL_FALTA_PAC(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) HORAS_FALTA_PAC,
                           (SGS.FNC_AGE_ESM_DEST_ALTA(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ALTA,
                           (SGS.FNC_AGE_ESM_DEST_INTERNACAO(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) INTERNACAO,
                           (SGS.FNC_AGE_ESM_DEST_RETORNO(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) RETORNO,
                           (SGS.FNC_AGE_ESM_DEST_RETORNOSADT(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) RETORNOSADT,
                           (SGS.FNC_AGE_ESM_DEST_CRONICO(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) CRONICO,
                           (SGS.FNC_AGE_ESM_DEST_ESPEC(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ESPECIALISTA,
                           (SGS.FNC_AGE_ESM_CAPAC_NORMAL_SP(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) CAPACIDADE,
                           (SGS.FNC_AGE_ESM_CAPAC_RETORNO(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) CAPACIDADE_RETORNO,
                           (SGS.FNC_AGE_HORA_LIVRE(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) HORA_LIVRE,
                           (SGS.FNC_ESM_CANCELADOS(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) NAOREMARCADOS,
                           (SGS.FNC_ESM_CANCELADOS2(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) CANCELADOS,
                           (SGS.FNC_AGE_ESM_TIPO_TELEMEDICINA(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) TELEMEDICINA
                      FROM TB_AGE_ESM_ESCALA_MEDICA ESM,
                           TB_ASS_PCB_PROFISSIONAL_CBOS PCB,
                           TB_TIS_CBO_CBOS CBO
                     WHERE ESM.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
                       AND ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
                       AND (pTIS_CBO_CD_CBOS IS NULL OR ESM.TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS)
                       AND ESM.AGE_ESM_FL_SITUACAO = 'I'
                       AND ESM.AGE_ESM_FL_AGENDAGERADA_OK = 'S'
                       AND ESM.AGE_ESM_DT_INI_ESCALA <= pDATA_FIM
                       AND ESM.CAD_PRO_ID_PROFISSIONAL = PCB.CAD_PRO_ID_PROFISSIONAL
                       AND PCB.TIS_CBO_CD_CBOS = CBO.TIS_CBO_CD_CBOS
                       AND CBO.TIS_CBO_CD_CBOS = ESM.TIS_CBO_CD_CBOS
                       group by  ESM.CAD_PRO_ID_PROFISSIONAL,
                           CBO.TIS_CBO_CD_CBOS,
                           ESM.CAD_UNI_ID_UNIDADE,ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO,
                           decode(esm.age_esm_fl_agend_grupo,null,'N',esm.age_esm_fl_agend_grupo) ,
                           (SGS.FNC_AGE_ESM_DIAS_DISPONIVEIS(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM) * (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA)) / 100 ,
                           (SGS.FNC_AGE_ESM_TIPO_RETORNO(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_TIPO_NORMAL(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_TIPO_EE(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_TIPO_SP(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_TIPO_ENCAIXE(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_DIAS_ATENDIDOS(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM) * (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA)) / 100 ,
                           (SGS.FNC_AGE_ESM_TOTAL_FALTAS(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM) * (ESM.AGE_ESM_HR_FIM_ESCALA - ESM.AGE_ESM_HR_INI_ESCALA)) / 100 ,
                         NVL((SGS.FNC_AGE_ESM_TOTAL_FALTAS2(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM) ) , 0),
                           (SGS.FNC_AGE_ESM_TOTAL_FALTA_PAC(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_DEST_ALTA(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_DEST_INTERNACAO(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_DEST_RETORNO(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_DEST_RETORNOSADT(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_DEST_CRONICO(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_DEST_ESPEC(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_CAPAC_NORMAL_SP(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_CAPAC_RETORNO(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_HORA_LIVRE(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_ESM_CANCELADOS(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_ESM_CANCELADOS2(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM)) ,
                           (SGS.FNC_AGE_ESM_TIPO_TELEMEDICINA(ESM.AGE_ESM_ID, pDATA_INI, pDATA_FIM))
                       ) TMP
             INNER JOIN TB_CAD_PRO_PROFISSIONAL PRO
                     ON PRO.CAD_PRO_ID_PROFISSIONAL = TMP.CAD_PRO_ID_PROFISSIONAL

                   JOIN TB_ASS_PCB_PROFISSIONAL_CBOS PCB
                     ON PCB.CAD_PRO_ID_PROFISSIONAL = PRO.CAD_PRO_ID_PROFISSIONAL
                    AND PCB.CAD_PRO_ID_PROFISSIONAL = TMP.CAD_PRO_ID_PROFISSIONAL
                   JOIN TB_TIS_CBO_CBOS CBO
                     ON PCB.TIS_CBO_CD_CBOS = CBO.TIS_CBO_CD_CBOS
                    AND PCB.TIS_CBO_CD_CBOS = TMP.TIS_CBO_CD_CBOS
AND HOAS_DISPONIVEIS > 0
                   left join (select 'N' age_esm_fl_agend_grupo from dual
                        union select 'S' age_esm_fl_agend_grupo from dual) grupo
                        on grupo.age_esm_fl_agend_grupo = tmp.age_esm_fl_agend_grupo
               GROUP BY TMP.CAD_PRO_ID_PROFISSIONAL,
                        PRO.CAD_PRO_NR_CONSELHO,
                        PRO.CAD_PRO_NM_NOME,
                        CBO.TIS_CBO_DS_CBOS_hac, TMP.TIS_CBO_CD_CBOS, TMP.CAD_UNI_ID_UNIDADE, TMP.CAD_LAT_ID_LOCAL_ATENDIMENTO, TMP.CAD_PRO_ID_PROFISSIONAL
                        ,tmp.age_esm_fl_agend_grupo
               ORDER BY PRO.CAD_PRO_NM_NOME
             ) RESULTADO
  ORDER BY RESULTADO.ESPECIALIDADE, RESULTADO.CAD_PRO_NM_NOME;
  io_cursor := v_cursor;
END PRC_AGE_REL_PROD_MEDICA;
