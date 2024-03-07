CREATE OR REPLACE PROCEDURE "PRC_AGE_AGG_AGENDA_GERADA_G_S"
(
 pAGE_AGG_ID IN TB_AGE_AGG_AGENDA_GERADA.AGE_AGG_ID%type,
 pAGE_AGG_DT_INI_AGENDA IN TB_AGE_AGG_AGENDA_GERADA.AGE_AGG_DT_AGENDA%TYPE,
 pAGE_AGG_DT_FIM_AGENDA IN TB_AGE_AGG_AGENDA_GERADA.AGE_AGG_DT_AGENDA%TYPE,
 io_cursor OUT PKG_CURSOR.t_cursor
)
is
  /********************************************************************
  *    Procedure: PRC_AGE_AGG_AGENDA_GERADA_G_S
  *
  *    Data Criacao:  09/08/2007            Por: Bruno Costa
  *    Data Alteracao:                     Por:
  *
  *    Data Alteracao:  04/05/2009          Por: Davi Silvestre M. dos Reis
  *       Alteracao: Limitacao da exibicao da agenda gerada em 90 dias
  *
  *    Data Alteracao:  18/11/2009          Por: Davi Silvestre M. dos Reis
  *       Alteracao: Melhoria na exibicao de agenda para 90 dias: apenas se 
  *					 o inicio da escala for maior que a data corrente (junto com a Cris)
  *
  *    Funcao: Recupera a agenda de acordo com a escala informada
  *            nao retirando as faltas
  *
  ********************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
BEGIN

OPEN v_cursor FOR

SELECT
     GERADA.AGE_AGG_ID,
     GERADA.AGE_ESF_ID,
     GERADA.AGE_AGG_FL_STATUS_HORARIO,
     GERADA.AGE_AGG_TP_HORARIO,
     GERADA.AGE_AGG_DT_AGENDA,
     GERADA.AGE_AGG_HR_AGENDA,
     GERADA.AGE_AGG_DS_BLOQUEIO
 FROM
     TB_AGE_AGG_AGENDA_GERADA GERADA 
INNER JOIN TB_AGE_ESM_ESCALA_MEDICA ESM
   ON GERADA.AGE_ESM_ID = ESM.AGE_ESM_ID
WHERE
     GERADA.Age_Esm_Id = pAGE_AGG_ID
 AND GERADA.AGE_AGG_DT_AGENDA BETWEEN pAGE_AGG_DT_INI_AGENDA AND pAGE_AGG_DT_FIM_AGENDA
 AND((TRUNC(ESM.AGE_ESM_DT_INI_ESCALA) < TRUNC(SYSDATE) AND GERADA.AGE_AGG_DT_AGENDA >= TRUNC(SYSDATE))
  OR (TRUNC(ESM.AGE_ESM_DT_INI_ESCALA) >= TRUNC(SYSDATE) AND GERADA.AGE_AGG_DT_AGENDA BETWEEN TRUNC(SYSDATE)
       AND ADD_MONTHS(TRUNC(SYSDATE), 3)));

  io_cursor := v_cursor;
END PRC_AGE_AGG_AGENDA_GERADA_G_S;

 