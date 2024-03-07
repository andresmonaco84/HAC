

  --PRC_AGS_ORS_ORIENTACAO_SADT_U
  create or replace procedure PRC_AGS_ORS_ORIENTACAO_SADT_U
  (
     pAGS_ORS_ID IN TB_AGS_ORS_ORIENTACAO_SADT.AGS_ORS_ID%type,
     pAGS_ORS_DS_ORIENTACAO_SADT IN TB_AGS_ORS_ORIENTACAO_SADT.AGS_ORS_DS_ORIENTACAO_SADT%type default NULL,
     pAGS_ORS_TP_FINALIDADE IN TB_AGS_ORS_ORIENTACAO_SADT.AGS_ORS_TP_FINALIDADE%type default NULL,
     pAGS_ORS_DT_ULTIMA_ATUALIZACAO IN TB_AGS_ORS_ORIENTACAO_SADT.AGS_ORS_DT_ULTIMA_ATUALIZACAO%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_AGS_ORS_ORIENTACAO_SADT.SEG_USU_ID_USUARIO%type default NULL
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AGS_ORS_ORIENTACAO_SADT_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_AGS_ORS_ORIENTACAO_SADT
    SET	   
        AGS_ORS_DS_ORIENTACAO_SADT = pAGS_ORS_DS_ORIENTACAO_SADT,
        AGS_ORS_TP_FINALIDADE = pAGS_ORS_TP_FINALIDADE,
        AGS_ORS_DT_ULTIMA_ATUALIZACAO = pAGS_ORS_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO 
    WHERE
        AGS_ORS_ID = pAGS_ORS_ID;	
  end PRC_AGS_ORS_ORIENTACAO_SADT_U;

