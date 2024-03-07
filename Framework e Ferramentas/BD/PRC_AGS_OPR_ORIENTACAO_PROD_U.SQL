create or replace procedure PRC_AGS_OPR_ORIENTACAO_PROD_U
  (
     pAGS_OPR_ID IN TB_AGS_OPR_ORIENTACAO_PROD.AGS_OPR_ID%type,
     pAGS_ORS_ID IN TB_AGS_OPR_ORIENTACAO_PROD.AGS_ORS_ID%type default NULL,
     pAGS_OPR_DT_ULTIMA_ATUALIZACAO IN TB_AGS_OPR_ORIENTACAO_PROD.AGS_OPR_DT_ULTIMA_ATUALIZACAO%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_AGS_OPR_ORIENTACAO_PROD.SEG_USU_ID_USUARIO%type default NULL,
     pCAD_PRD_ID IN TB_AGS_OPR_ORIENTACAO_PROD.CAD_PRD_ID%type default NULL,
     pAGS_OPR_FL_STATUS IN TB_AGS_OPR_ORIENTACAO_PROD.AGS_OPR_FL_STATUS%type default NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGS_OPR_ORIENTACAO_PROD_U
  *
  *    Data Criacao:   29/09/2008   Por: Pedro Henrique A. de Carvalho
  *    Data Alteracao:  data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  begin
    UPDATE TB_AGS_OPR_ORIENTACAO_PROD
    SET
        AGS_ORS_ID = pAGS_ORS_ID,
        AGS_OPR_DT_ULTIMA_ATUALIZACAO = pAGS_OPR_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        CAD_PRD_ID = pCAD_PRD_ID,
        AGS_OPR_FL_STATUS = pAGS_OPR_FL_STATUS
    WHERE
        AGS_OPR_ID = pAGS_OPR_ID;
  end PRC_AGS_OPR_ORIENTACAO_PROD_U;
