create or replace procedure PRC_AGS_AGE_AGENDA_PROX_D
  (
     pAGS_AGG_DT_AGENDA_GERADA IN TB_AGS_AGG_AGE_GERADA_SADT.AGS_AGG_DT_AGENDA_GERADA%type DEFAULT NULL,
     pAGS_ESM_ID IN TB_AGS_AGG_AGE_GERADA_SADT.AGS_ESM_ID%type DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGS_AGE_AGENDA_SADT_S
  *
  *    Data Criacao:   data da  criação   Por: Nome do Analista
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: EXCLUI AGENDAMENTOS POSTERIORES A DATA PASSADA
  *
  *******************************************************************/

  begin
       DELETE
       FROM TB_AGS_AGG_AGE_GERADA_SADT AGG
       WHERE AGG.AGS_ESM_ID = pAGS_ESM_ID
       AND AGG.AGS_AGG_DT_AGENDA_GERADA > pAGS_AGG_DT_AGENDA_GERADA;

  end PRC_AGS_AGE_AGENDA_PROX_D;
