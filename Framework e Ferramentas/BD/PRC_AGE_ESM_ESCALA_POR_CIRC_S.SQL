create or replace procedure PRC_AGE_ESM_ESCALA_POR_CIRC_S
  (
     pAGE_ECC_ID IN TB_ASS_CIE_CIRCULAR_ESCALA.AGE_ECC_ID%type DEFAULT NULL,

     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_ESM_ESCALA_POR_CIRC_S
  *
  *    Data Criacao: 	28/08/2007         Por: Guilherme holdack
  *    Data Alteracao:	                   Por:
  *
  *    Funcao: Lista todas as escalas relacionadas com uma dada circular
  *
  *    Data Alteracao: 23/01/2009        	  Por: Davi Silvestre M. dos Reis
  *    Alteracao: Inclusão do campo AGE_ESM_ENDER_ATEND_ESCALA.
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       CIE.AGE_ECC_ID,
       CIE.AGE_ESM_ID,
       CIE.SEG_USU_ID_USUARIO,
       CIE.ASS_CIE_DT_ULTIMA_ATUALIZACAO,
       ESM.AGE_ESM_ID,
       ESM.AGE_SAU_ID,
       ESM.AGE_ESM_DT_INI_ESCALA,
       ESM.AGE_ESM_HR_INI_ESCALA,
       ESM.AGE_ESM_DT_FIM_ESCALA,
       ESM.AGE_ESM_HR_FIM_ESCALA,
       ESM.AGE_ESM_NR_DIA_SEMANA,
       ESM.AGE_ESM_FL_SITUACAO,
       ESM.AGE_ESM_QT_DIAS_CRIACAO,
       ESM.AGE_ESM_QT_AGE_PERM_PHORA,
       ESM.AGE_ESM_FL_PERM_ENCAIXE,
       ESM.AGE_ESM_FL_PERM_ENCAIXE_ESP,
       ESM.AGE_ESM_FL_PERM_RETORNO,
       ESM.AGE_ESM_DT_CRIACAO_ESCALA,
       ESM.AGE_ESM_QT_ENCAIXE,
       ESM.AGE_ESM_QT_ENCAIXE_PHORA,
       ESM.AGE_ESM_QT_ENCAIXE_ESP,
       ESM.AGE_ESM_QT_ENCAIXE_ESP_PHORA,
       ESM.AGE_ESM_DS_OBS,
       ESM.SEG_USU_ID_USUARIO,
       ESM.AGE_ESM_DT_ULTIMA_ATUALIZACAO,
       ESM.AGE_ESM_FL_TRANSF,
       ESM.TIS_CBO_CD_CBOS,
       ESM.CAD_PRO_ID_PROFISSIONAL,
       ESM.CAD_UNI_ID_UNIDADE,
       ESM.CAD_LAT_ID_LOCAL_ATENDIMENTO,
       ESM.AGE_PEE_ID,
       ESM.AGE_ESM_QT_RET_PERM_PHORA,
       ESM.AGE_ESM_FL_PERM_AGENDA_SP,
       ESM.AGE_ESM_QT_AGE_PERM_PHORA_SP,
       ESM.AGE_ESM_QT_DIAS_INTERVALO,
       ESM.AGE_ESM_FL_AGENDAGERADA_OK,
       ESM.AGE_ESM_ENDER_ATEND_ESCALA
    FROM TB_ASS_CIE_CIRCULAR_ESCALA CIE,
    TB_AGE_ESM_ESCALA_MEDICA ESM,
    TB_AGE_ECC_ESCALA_CTRL_CIRC ECC
    WHERE
        (pAGE_ECC_ID is null OR ECC.AGE_ECC_ID = pAGE_ECC_ID) AND
        (CIE.AGE_ESM_ID = ESM.AGE_ESM_ID) AND
        (CIE.AGE_ECC_ID = ECC.AGE_ECC_ID);
    io_cursor := v_cursor;
  end PRC_AGE_ESM_ESCALA_POR_CIRC_S;
/
