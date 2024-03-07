create or replace procedure PRC_TIS_CPR_CONSELHO_PROF_I
  (
     pTIS_CPR_CD_CONSELHOPROF    IN TB_TIS_CPR_CONSELHO_PROF.TIS_CPR_CD_CONSELHOPROF%type,
     pTIS_CPR_DS_CONSELHOPROF    IN TB_TIS_CPR_CONSELHO_PROF.TIS_CPR_DS_CONSELHOPROF%type,
     pTIS_CPR_FL_STATUS          IN TB_TIS_CPR_CONSELHO_PROF.TIS_CPR_FL_STATUS%type,
     pTIS_CPR_CD_CONSELHOPROF_V3 IN TB_TIS_CPR_CONSELHO_PROF.TIS_CPR_CD_CONSELHOPROF_V3%type default null,
     pSEG_USU_ID_USUARIO         IN TB_TIS_CPR_CONSELHO_PROF.SEG_USU_ID_USUARIO_CRIACAO%type DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: {PRC_TIS_CPR_CONSELHO_PROF_I}
  *
  *    Data Criacao:   07/03/2007   Por: Silmara
  *    Data Alteracao:  25/05/2007  Por: Silmara
  *    Alteração:Foi alterado os parâmetros para gravar em maiúsculo
  *    Funcao: Inclui Conselho(s) Profissional(is) - TISS
  *
  *    Data Alteração:  20/03/2014  Por: Andréa Cazuca
  *    Alteração:  Inclusão do campo TIS_CPR_CD_CONSELHOPROF_V3
  *
  *******************************************************************/

  begin

    INSERT INTO TB_TIS_CPR_CONSELHO_PROF
    (
       TIS_CPR_CD_CONSELHOPROF,
       TIS_CPR_DS_CONSELHOPROF,
       TIS_CPR_FL_STATUS,
       TIS_CPR_CD_CONSELHOPROF_V3,
       TIS_CPR_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       TIS_CPR_DT_ULT_ATUALIZACAO,
       SEG_USU_ID_USU_ULT_ATUALIZ
    )
    VALUES
    (
       UPPER(pTIS_CPR_CD_CONSELHOPROF),
       UPPER(pTIS_CPR_DS_CONSELHOPROF),
       pTIS_CPR_FL_STATUS,
       UPPER(pTIS_CPR_CD_CONSELHOPROF_V3),
       SYSDATE,
       pSEG_USU_ID_USUARIO,
       SYSDATE,
       pSEG_USU_ID_USUARIO 
    );

  end PRC_TIS_CPR_CONSELHO_PROF_I;
 