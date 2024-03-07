create or replace procedure PRC_AGS_ORS_ORIENTACAO_SADT_I
  (
     pNewIdt OUT integer,
    -- pAGS_ORS_ID IN TB_AGS_ORS_ORIENTACAO_SADT.AGS_ORS_ID%type default NULL,
     pAGS_ORS_DS_ORIENTACAO_SADT IN TB_AGS_ORS_ORIENTACAO_SADT.AGS_ORS_DS_ORIENTACAO_SADT%type default NULL,
     pAGS_ORS_TP_FINALIDADE IN TB_AGS_ORS_ORIENTACAO_SADT.AGS_ORS_TP_FINALIDADE%type default NULL,
     pAGS_ORS_DT_ULTIMA_ATUALIZACAO IN TB_AGS_ORS_ORIENTACAO_SADT.AGS_ORS_DT_ULTIMA_ATUALIZACAO%type default NULL,
     pSEG_USU_ID_USUARIO IN TB_AGS_ORS_ORIENTACAO_SADT.SEG_USU_ID_USUARIO%type default NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGS_ORS_ORIENTACAO_SADT_I
  *
  *    Data Criacao:   25/09/2008   Por: Pedro H. A. de Carvalho
  *    Data Alteracao:  08/01/2009  Por: PEDRO
  *    Alteração:   retirado UPPER da DS
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
    lIdtRetorno integer;

  begin
    SELECT SEQ_AGS_ORS_01.NextVal INTO lIdtRetorno FROM DUAL;

    INSERT INTO TB_AGS_ORS_ORIENTACAO_SADT
    (
       AGS_ORS_ID,
       AGS_ORS_DS_ORIENTACAO_SADT,
       AGS_ORS_TP_FINALIDADE,
       AGS_ORS_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO
    )
    VALUES
    (
       lIdtRetorno,
       pAGS_ORS_DS_ORIENTACAO_SADT,
       pAGS_ORS_TP_FINALIDADE,
       pAGS_ORS_DT_ULTIMA_ATUALIZACAO,
       pSEG_USU_ID_USUARIO
    );
    pNewIdt := lIdtRetorno;
  end PRC_AGS_ORS_ORIENTACAO_SADT_I;
