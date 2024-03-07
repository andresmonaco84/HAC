create or replace procedure PRC_AGE_ESM_TRANSF_ESMAGE_UNID(pAGE_ESM_ID_ANTIGA       IN TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_ID%type DEFAULT NULL,
                                                           pAGE_SAU_ID_NOVA         IN TB_AGE_SAU_SALA_UNID_AND.AGE_SAU_ID%type DEFAULT NULL,
                                                           pCAD_UNI_ID_UNIDADE_NOVA IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
                                                           pAGE_ESM_DT_INI_ESCALA   IN TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_DT_INI_ESCALA%TYPE DEFAULT NULL) is
  /********************************************************************
  *    Procedure: PRC_AGE_ESM_TRANSF_ESMAGE_UNID
  *
  *    Data Criacao:  30/03/2009   Por: Cristiane Gomes da Silva
  *    Data Alteracao: 02/06/2009  Por: Cristiane Gomes da Silva
  *
  *    Funcao: Transferir escalas e agendas para outra unidade
  *
  *    Alteracao: 1) Alterar o codigo da unidade origem para a unidade destino
  *               na tabela PACIENTE_ATENDIMENTO_AMB
  *               2) Obter o andar da sala
  *******************************************************************/
  CURSOR ESCALA_ANTIGA IS(
    SELECT ESM.AGE_ESM_HR_INI_ESCALA,
           ESM.AGE_ESM_DT_FIM_ESCALA,
           ESM.AGE_ESM_HR_FIM_ESCALA,
           ESM.AGE_ESM_NR_DIA_SEMANA,
           ESM.AGE_ESM_QT_DIAS_CRIACAO,
           ESM.AGE_ESM_QT_AGE_PERM_PHORA,
           ESM.AGE_ESM_FL_PERM_ENCAIXE,
           ESM.AGE_ESM_FL_PERM_ENCAIXE_ESP,
           ESM.AGE_ESM_FL_PERM_RETORNO,
           ESM.AGE_ESM_QT_ENCAIXE,
           ESM.AGE_ESM_QT_ENCAIXE_PHORA,
           ESM.AGE_ESM_QT_ENCAIXE_ESP,
           ESM.AGE_ESM_QT_ENCAIXE_ESP_PHORA,
           ESM.AGE_ESM_DS_OBS,
           ESM.SEG_USU_ID_USUARIO,
           ESM.AGE_ESM_FL_TRANSF,
           ESM.TIS_CBO_CD_CBOS,
           ESM.CAD_PRO_ID_PROFISSIONAL,
           ESM.CAD_UNI_ID_UNIDADE,
           ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO,
           ESM.AGE_PEE_ID,
           ESM.AGE_ESM_QT_DIAS_INTERVALO,
           ESM.AGE_ESM_QT_RET_PERM_PHORA,
           ESM.AGE_ESM_FL_PERM_AGENDA_SP,
           ESM.AGE_ESM_QT_AGE_PERM_PHORA_SP,
           ESM.AGE_ESM_DT_PROXIMA_DATA,
           ESM.AGE_ESM_ENDER_ATEND_ESCALA
      FROM TB_AGE_ESM_ESCALA_MEDICA ESM
     WHERE ESM.AGE_ESM_ID = pAGE_ESM_ID_ANTIGA);
  v_age_esm_id NUMBER;
  v_totfaltas  NUMBER;
  v_age_esf_id NUMBER;
  v_cd_unid_hospitalar NUMBER;
  v_cd_andar NUMBER;
begin
  FOR ESM IN ESCALA_ANTIGA LOOP
    SELECT SEQ_AGE_ESM_01.NEXTVAL INTO v_age_esm_id FROM DUAL;
    -- INSERINDO COPIA DA ESCALA ANTIGA NA NOVA UNIDADE 
    INSERT INTO TB_AGE_ESM_ESCALA_MEDICA
      (AGE_ESM_ID,
       AGE_SAU_ID,
       AGE_ESM_DT_INI_ESCALA,
       AGE_ESM_HR_INI_ESCALA,
       AGE_ESM_DT_FIM_ESCALA,
       AGE_ESM_HR_FIM_ESCALA,
       AGE_ESM_NR_DIA_SEMANA,
       AGE_ESM_FL_SITUACAO,
       AGE_ESM_QT_DIAS_CRIACAO,
       AGE_ESM_QT_AGE_PERM_PHORA,
       AGE_ESM_FL_PERM_ENCAIXE,
       AGE_ESM_FL_PERM_ENCAIXE_ESP,
       AGE_ESM_FL_PERM_RETORNO,
       AGE_ESM_DT_CRIACAO_ESCALA,
       AGE_ESM_QT_ENCAIXE,
       AGE_ESM_QT_ENCAIXE_PHORA,
       AGE_ESM_QT_ENCAIXE_ESP,
       AGE_ESM_QT_ENCAIXE_ESP_PHORA,
       AGE_ESM_DS_OBS,
       SEG_USU_ID_USUARIO,
       AGE_ESM_DT_ULTIMA_ATUALIZACAO,
       AGE_ESM_FL_TRANSF,
       TIS_CBO_CD_CBOS,
       CAD_PRO_ID_PROFISSIONAL,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       AGE_PEE_ID,
       AGE_ESM_QT_DIAS_INTERVALO,
       AGE_ESM_QT_RET_PERM_PHORA,
       AGE_ESM_FL_PERM_AGENDA_SP,
       AGE_ESM_QT_AGE_PERM_PHORA_SP,
       AGE_ESM_FL_AGENDAGERADA_OK,
       AGE_ESM_DT_PROXIMA_DATA,
       AGE_ESM_ENDER_ATEND_ESCALA)
    VALUES
      (v_age_esm_id,
       pAGE_SAU_ID_NOVA,
       pAGE_ESM_DT_INI_ESCALA,
       ESM.AGE_ESM_HR_INI_ESCALA,
       ESM.AGE_ESM_DT_FIM_ESCALA,
       ESM.AGE_ESM_HR_FIM_ESCALA,
       ESM.AGE_ESM_NR_DIA_SEMANA,
       'A',
       ESM.AGE_ESM_QT_DIAS_CRIACAO,
       ESM.AGE_ESM_QT_AGE_PERM_PHORA,
       ESM.AGE_ESM_FL_PERM_ENCAIXE,
       ESM.AGE_ESM_FL_PERM_ENCAIXE_ESP,
       ESM.AGE_ESM_FL_PERM_RETORNO,
       SYSDATE,
       ESM.AGE_ESM_QT_ENCAIXE,
       ESM.AGE_ESM_QT_ENCAIXE_PHORA,
       ESM.AGE_ESM_QT_ENCAIXE_ESP,
       ESM.AGE_ESM_QT_ENCAIXE_ESP_PHORA,
       ESM.AGE_ESM_DS_OBS,
       ESM.SEG_USU_ID_USUARIO,
       SYSDATE,
       ESM.AGE_ESM_FL_TRANSF,
       ESM.TIS_CBO_CD_CBOS,
       ESM.CAD_PRO_ID_PROFISSIONAL,
       pCAD_UNI_ID_UNIDADE_NOVA,
       ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO,
       ESM.AGE_PEE_ID,
       ESM.AGE_ESM_QT_DIAS_INTERVALO,
       ESM.AGE_ESM_QT_RET_PERM_PHORA,
       ESM.AGE_ESM_FL_PERM_AGENDA_SP,
       ESM.AGE_ESM_QT_AGE_PERM_PHORA_SP,
       'S',
       ESM.AGE_ESM_DT_PROXIMA_DATA,
       ESM.AGE_ESM_ENDER_ATEND_ESCALA);
    -- alterando ID escala na agenda gerada
    UPDATE TB_AGE_AGG_AGENDA_GERADA AGG
       SET AGG.AGE_ESM_ID = v_age_esm_id
     WHERE AGG.AGE_ESM_ID = pAGE_ESM_ID_ANTIGA
       AND AGG.AGE_AGG_DT_AGENDA >= pAGE_ESM_DT_INI_ESCALA;
    -- alterando ID escala na agenda marcada
    UPDATE TB_AGE_AGD_AGENDA AGD
       SET AGD.AGE_ESM_ID = v_age_esm_id
     WHERE AGD.AGE_ESM_ID = pAGE_ESM_ID_ANTIGA
       AND AGD.AGE_AGD_DT_ATENDIMENTO >= pAGE_ESM_DT_INI_ESCALA;
    -- buscar o codigo da unidade destino
    SELECT UNI.CAD_UNI_CD_UNID_HOSPITALAR
    INTO v_cd_unid_hospitalar
    FROM TB_CAD_UNI_UNIDADE UNI
    WHERE UNI.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE_NOVA; 
    -- obter o andar da sala
    SELECT SAU.AGE_SAU_CD_ANDAR
    INTO v_cd_andar
    FROM TB_AGE_SAU_SALA_UNID_AND SAU
    WHERE SAU.AGE_SAU_ID = pAGE_SAU_ID_NOVA;       
    -- alterando o codigo da unidade na tabela do legado
    FOR AGD IN
        (SELECT AGD.AGE_AGD_CD_INTAMB 
        FROM TB_AGE_AGD_AGENDA AGD
        WHERE AGD.AGE_ESM_ID = v_age_esm_id
        AND AGD.AGE_AGD_DT_ATENDIMENTO >= pAGE_ESM_DT_INI_ESCALA) LOOP
        BEGIN
          UPDATE PACIENTE_ATENDIMENTO_AMB 
          SET CODUNIHOS = v_cd_unid_hospitalar,
          CODAND = v_cd_andar
          WHERE CODATEAMB = AGD.AGE_AGD_CD_INTAMB;
        EXCEPTION WHEN NO_DATA_FOUND THEN
                  NULL;
        END;
    END LOOP;
    -- alterando ID escala na agenda cancelada
    UPDATE TB_AGE_AGC_AGENDA_CANCELADA AGC
       SET AGC.AGE_ESM_ID = v_age_esm_id
     WHERE AGC.AGE_ESM_ID = pAGE_ESM_ID_ANTIGA
       AND AGC.AGE_AGD_DT_ATENDIMENTO >= pAGE_ESM_DT_INI_ESCALA;
    -- finalizando a escala antiga
    UPDATE TB_AGE_ESM_ESCALA_MEDICA ESM
       SET ESM.AGE_ESM_DT_FIM_ESCALA = pAGE_ESM_DT_INI_ESCALA - 7
     WHERE ESM.AGE_ESM_ID = pAGE_ESM_ID_ANTIGA;
    -- verificando faltas
    SELECT COUNT(*)
      INTO v_totfaltas
      FROM TB_AGE_ESF_ESCALA_FALTAS ESF
     WHERE ((ESF.AGE_ESF_DT_INI_FALTA >= pAGE_ESM_DT_INI_ESCALA
        OR ESF.AGE_ESF_DT_INI_FALTA <= pAGE_ESM_DT_INI_ESCALA) 
       AND ESF.AGE_ESF_DT_FIM_FALTA >= pAGE_ESM_DT_INI_ESCALA) 
       AND ESF.AGE_ESM_ID = pAGE_ESM_ID_ANTIGA;
    -- se existir faltas para a escala antiga no período gerado         
       IF v_totfaltas > 0 THEN
          FOR I IN 
          (SELECT ESF.AGE_ESF_DT_INI_FALTA, ESF.AGE_ESF_DS_OBSERVACAO,
           ESF.AGE_ESF_DT_ULTIMA_ATUALIZACAO, ESF.SEG_USU_ID_USUARIO,
           ESF.AGE_ESF_DT_FIM_FALTA, ESF.AGE_ESF_FL_SUBSTITUTO_OK,
           ESF.TIS_CBO_CD_CBOS_SUBST, ESF.AGE_ESF_ID, 
           ESF.CAD_PRO_ID_PROFISSIONAL_SUBST
           FROM TB_AGE_ESF_ESCALA_FALTAS ESF
           WHERE ((ESF.AGE_ESF_DT_INI_FALTA >= pAGE_ESM_DT_INI_ESCALA
           OR ESF.AGE_ESF_DT_INI_FALTA <= pAGE_ESM_DT_INI_ESCALA) 
           AND ESF.AGE_ESF_DT_FIM_FALTA >= pAGE_ESM_DT_INI_ESCALA)
           AND ESF.AGE_ESM_ID = pAGE_ESM_ID_ANTIGA) LOOP
 
             SELECT SEQ_AGE_ESF_01.NEXTVAL 
             INTO v_age_esf_id
             FROM DUAL;
         
             INSERT INTO TB_AGE_ESF_ESCALA_FALTAS
             (AGE_ESM_ID, AGE_ESF_DT_INI_FALTA, AGE_ESF_DS_OBSERVACAO,
             AGE_ESF_DT_ULTIMA_ATUALIZACAO, SEG_USU_ID_USUARIO,
             AGE_ESF_DT_FIM_FALTA, AGE_ESF_FL_SUBSTITUTO_OK,
             TIS_CBO_CD_CBOS_SUBST, AGE_ESF_ID, 
             CAD_PRO_ID_PROFISSIONAL_SUBST)
             VALUES
             (v_age_esm_id,I.AGE_ESF_DT_INI_FALTA, I.AGE_ESF_DS_OBSERVACAO,
             I.AGE_ESF_DT_ULTIMA_ATUALIZACAO, I.SEG_USU_ID_USUARIO,
             I.AGE_ESF_DT_FIM_FALTA, I.AGE_ESF_FL_SUBSTITUTO_OK,
             I.TIS_CBO_CD_CBOS_SUBST, v_age_esf_id, 
             I.CAD_PRO_ID_PROFISSIONAL_SUBST);
         
             UPDATE TB_AGE_AGG_AGENDA_GERADA
             SET AGE_ESF_ID = v_age_esf_id
             WHERE AGE_ESM_ID = v_age_esm_id
             AND AGE_AGG_DT_AGENDA BETWEEN I.AGE_ESF_DT_INI_FALTA 
             AND I.AGE_ESF_DT_FIM_FALTA;
           END LOOP;
        END IF;
  END LOOP;
  COMMIT;
end PRC_AGE_ESM_TRANSF_ESMAGE_UNID;
/
