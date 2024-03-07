create or replace procedure PRC_AGE_ESM_DESFAZ_TRANSF_UNID(pAGE_ESM_ID_ORIGEM       IN TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_ID%type,
                                                           pAGE_ESM_ID_DESTINO      IN TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_ID%type,                            
                                                           pAGE_ESM_DT_INI_ESCALA   IN TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_DT_INI_ESCALA%TYPE) is
  /********************************************************************
  *    Procedure: PRC_AGE_ESM_DESFAZ_TRANSF_UNID
  *
  *    Data Criacao:  06/04/2009   Por: Cristiane Gomes da Silva
  *    Data Alteracao:             Por:
  *
  *    Funcao: Desfaz transferencia de escalas e agendas de uma unidade
  *            para outra
  *
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
     WHERE ESM.AGE_ESM_ID = pAGE_ESM_ID_ORIGEM);
  v_totfaltas  NUMBER;
begin
  FOR ESM IN ESCALA_ANTIGA LOOP
    -- alterando ID escala na agenda gerada
    UPDATE TB_AGE_AGG_AGENDA_GERADA AGG
       SET AGG.AGE_ESM_ID = pAGE_ESM_ID_DESTINO
     WHERE AGG.AGE_ESM_ID = pAGE_ESM_ID_ORIGEM
       AND AGG.AGE_AGG_DT_AGENDA >= pAGE_ESM_DT_INI_ESCALA;
    -- alterando ID escala na agenda marcada
    UPDATE TB_AGE_AGD_AGENDA AGD
       SET AGD.AGE_ESM_ID = pAGE_ESM_ID_DESTINO
     WHERE AGD.AGE_ESM_ID = pAGE_ESM_ID_ORIGEM
       AND AGD.AGE_AGD_DT_ATENDIMENTO >= pAGE_ESM_DT_INI_ESCALA;
    -- alterando ID escala na agenda cancelada
    UPDATE TB_AGE_AGC_AGENDA_CANCELADA AGC
       SET AGC.AGE_ESM_ID = pAGE_ESM_ID_DESTINO
     WHERE AGC.AGE_ESM_ID = pAGE_ESM_ID_ORIGEM
       AND AGC.AGE_AGD_DT_ATENDIMENTO >= pAGE_ESM_DT_INI_ESCALA;
    -- finalizando a escala antiga
    UPDATE TB_AGE_ESM_ESCALA_MEDICA 
       SET AGE_ESM_DT_FIM_ESCALA = ESM.AGE_ESM_DT_FIM_ESCALA,
           AGE_ESM_FL_SITUACAO = 'A'
     WHERE AGE_ESM_ID = pAGE_ESM_ID_DESTINO;
    -- verificando faltas
    SELECT COUNT(*)
      INTO v_totfaltas
      FROM TB_AGE_ESF_ESCALA_FALTAS ESF
     WHERE ((ESF.AGE_ESF_DT_INI_FALTA >= pAGE_ESM_DT_INI_ESCALA
        OR ESF.AGE_ESF_DT_INI_FALTA <= pAGE_ESM_DT_INI_ESCALA) 
       AND ESF.AGE_ESF_DT_FIM_FALTA >= pAGE_ESM_DT_INI_ESCALA) 
       AND ESF.AGE_ESM_ID = pAGE_ESM_ID_ORIGEM;
    -- se existir faltas para a escala antiga no período gerado         
       IF v_totfaltas > 0 THEN
          FOR I IN 
            (SELECT ESF.AGE_ESF_ID,AGE_ESF_DT_INI_FALTA,AGE_ESF_DT_FIM_FALTA
            FROM TB_AGE_ESF_ESCALA_FALTAS ESF
            WHERE ((ESF.AGE_ESF_DT_INI_FALTA >= pAGE_ESM_DT_INI_ESCALA
            OR ESF.AGE_ESF_DT_INI_FALTA <= pAGE_ESM_DT_INI_ESCALA) 
            AND ESF.AGE_ESF_DT_FIM_FALTA >= pAGE_ESM_DT_INI_ESCALA) 
            AND ESF.AGE_ESM_ID = pAGE_ESM_ID_DESTINO) LOOP
            BEGIN
              UPDATE TB_AGE_AGG_AGENDA_GERADA
              SET AGE_ESF_ID = I.AGE_ESF_ID
              WHERE AGE_ESM_ID = pAGE_ESM_ID_DESTINO
              AND AGE_AGG_DT_AGENDA BETWEEN I.AGE_ESF_DT_INI_FALTA 
              AND I.AGE_ESF_DT_FIM_FALTA;
            END;      
          END LOOP;
          DELETE FROM TB_AGE_ESF_ESCALA_FALTAS ESF
          WHERE ((ESF.AGE_ESF_DT_INI_FALTA >= pAGE_ESM_DT_INI_ESCALA
          OR ESF.AGE_ESF_DT_INI_FALTA <= pAGE_ESM_DT_INI_ESCALA) 
          AND ESF.AGE_ESF_DT_FIM_FALTA >= pAGE_ESM_DT_INI_ESCALA) 
          AND ESF.AGE_ESM_ID = pAGE_ESM_ID_ORIGEM;    
       END IF;
       DELETE FROM TB_AGE_ESM_ESCALA_MEDICA ESM
       WHERE ESM.AGE_ESM_ID = pAGE_ESM_ID_ORIGEM;
  END LOOP;
  COMMIT;
end PRC_AGE_ESM_DESFAZ_TRANSF_UNID;
/