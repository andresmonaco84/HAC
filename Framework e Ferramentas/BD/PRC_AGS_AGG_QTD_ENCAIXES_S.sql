create or replace procedure PRC_AGS_AGG_QTD_ENCAIXES_S
  (
     pAGS_ESM_ID IN TB_AGS_AGG_AGE_GERADA_SADT.AGS_ESM_ID%type,
     pAGS_AGG_TP_HORARIO IN TB_AGS_AGG_AGE_GERADA_SADT.AGS_AGG_TP_HORARIO%type,
     pNewIdt OUT number
  )
  is
  /*********************************************************************
  *    Procedure: PRC_AGS_AGG_QTD_ENCAIXES_S
  *
  *    Data Criacao:  07/05/2009   Por: pEDRO
  *    Data Alteracao: data da alterac?o  Por: Nome do Analista
  *
  *    Funcao: RETORNA A QTD DE ENCAIXES AGENDADOS A PARTIR DO DIA ATUAL.
  *
  **********************************************************************/

  begin

    SELECT COUNT(*) into pNewIdt FROM TB_AGS_AGE_AGENDA_SADT AGS
        INNER JOIN TB_AGS_ESM_ESCALA_SADT AGS_ESM
        ON AGS_ESM.AGS_ESM_ID = AGS.AGS_ESM_ID
        INNER JOIN TB_AGS_AGG_AGE_GERADA_SADT AGG
        ON AGG.AGS_AGG_ID = AGS.AGS_AGG_ID

    WHERE
        (AGG.AGS_ESM_ID = pAGS_ESM_ID) AND
        (AGG.AGS_AGG_TP_HORARIO = pAGS_AGG_TP_HORARIO) AND
        (AGG.AGS_AGG_DT_AGENDA_GERADA >= SYSDATE)
          ;
  end PRC_AGS_AGG_QTD_ENCAIXES_S;
 
/
