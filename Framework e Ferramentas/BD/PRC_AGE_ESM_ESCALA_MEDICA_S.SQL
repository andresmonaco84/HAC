CREATE OR REPLACE PROCEDURE "PRC_AGE_ESM_ESCALA_MEDICA_S"
  (
     pAGE_ESM_ID IN TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_ID%type DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE IN TB_AGE_ESM_ESCALA_MEDICA.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_AGE_ESM_ESCALA_MEDICA.CAD_LAT_ID_LOCAL_ATENDIMENTO%type DEFAULT NULL,
     pTIS_CBO_CD_CBOS IN TB_AGE_ESM_ESCALA_MEDICA.TIS_CBO_CD_CBOS%type DEFAULT NULL,
     pCAD_PRO_ID_PROFISSIONAL IN TB_AGE_ESM_ESCALA_MEDICA.CAD_PRO_ID_PROFISSIONAL%type DEFAULT NULL,
     pAGE_ESM_FL_SITUACAO IN TB_AGE_ESM_ESCALA_MEDICA.AGE_ESM_FL_SITUACAO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_ESM_ESCALA_MEDICA_S
  *
  *    Data Criacao:  16/07/2007           Por: Guilherme Holdack
  *    Funcao: Listar / obter registros de TB_AGE_ESM_ESCALA_MEDICA
  *
  *    Alterac?o: 02/08/2007              Por: Guilherme Holdack
  *    Motivo: Inclus?o de novos campos na tabela TB_AGE_ESM_ESCALA_MEDICA
  *
  *    Alterac?o: 07/08/2007              Por: Guilherme Holdack
  *    Motivo: Possibilidade de listar escalas medicas a partir de seu status
  *
  *    Alterac?o: 05/09/2007              Por: Carlos Araujo
  *    Motivo: Inclus?o de novo campo age_esm_fl_agendagerada_ok
  *
  *    Data Alteracao: 23/01/2009           Por: Davi Silvestre M. dos Reis
  *    Alteracao: Inclus?o do campo AGE_ESM_ENDER_ATEND_ESCALA.
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       AGE_ESM_ID,
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
       AGE_ESM_QT_RET_PERM_PHORA,
       AGE_ESM_FL_PERM_AGENDA_SP,
       AGE_ESM_QT_AGE_PERM_PHORA_SP,
       AGE_ESM_QT_DIAS_INTERVALO,
       AGE_ESM_FL_AGENDAGERADA_OK,
       AGE_ESM_DT_PROXIMA_DATA,
       AGE_ESM_ENDER_ATEND_ESCALA,
       AGE_ESM_TP_ESCALA,
       AGE_ESM_FL_PERM_TELEMEDICINA,
       AGE_ESM_QT_TELEMEDICINA_PHORA,
       AGE_ESM_QT_BLOQUEIO_PHORA,
       AGE_ESM_FL_AGEND_GRUPO

    FROM TB_AGE_ESM_ESCALA_MEDICA
    WHERE
        (pAGE_ESM_ID is null OR AGE_ESM_ID = pAGE_ESM_ID)
        AND (pCAD_UNI_ID_UNIDADE is null OR CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
        AND (pCAD_LAT_ID_LOCAL_ATENDIMENTO is null OR CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
        AND (pCAD_PRO_ID_PROFISSIONAL is null OR CAD_PRO_ID_PROFISSIONAL = pCAD_PRO_ID_PROFISSIONAL)
        AND (pTIS_CBO_CD_CBOS is null OR TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS)
        AND (pAGE_ESM_FL_SITUACAO is null or AGE_ESM_FL_SITUACAO = pAGE_ESM_FL_SITUACAO)
        ORDER BY AGE_ESM_FL_SITUACAO, AGE_ESM_NR_DIA_SEMANA, AGE_ESM_DT_INI_ESCALA, AGE_ESM_DT_FIM_ESCALA, AGE_ESM_HR_INI_ESCALA, AGE_ESM_HR_FIM_ESCALA
        ;
    io_cursor := v_cursor;
  end PRC_AGE_ESM_ESCALA_MEDICA_S;
