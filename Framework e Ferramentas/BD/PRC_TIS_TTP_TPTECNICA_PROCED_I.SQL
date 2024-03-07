create or replace procedure PRC_TIS_TTP_TPTECNICA_PROCED_I
  (
     pTIS_TTP_CD_TPTECNICA    IN TB_TIS_TTP_TPTECNICA_PROCED.TIS_TTP_CD_TPTECNICA%type,
     pTIS_TTP_DS_TPTECNICA    IN TB_TIS_TTP_TPTECNICA_PROCED.TIS_TTP_DS_TPTECNICA%type,
    pTIS_TTP_FL_STATUS       IN TB_TIS_TTP_TPTECNICA_PROCED.TIS_TTP_FL_STATUS%type,
     pTIS_TTP_CD_TPTECNICA_V3 IN TB_TIS_TTP_TPTECNICA_PROCED.TIS_TTP_CD_TPTECNICA_V3%type default null,
     pTIS_TTP_DS_OBSERVACAO   IN TB_TIS_TTP_TPTECNICA_PROCED.TIS_TTP_DS_OBSERVACAO%type default null,
     pSEG_USU_ID_USUARIO      IN TB_TIS_TTP_TPTECNICA_PROCED.SEG_USU_ID_USUARIO_CRIACAO%type DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_TTP_TPTECNICA_PROCED_I
  *
  *    Data Criacao:  12/03/2007   Por: Andréa
  *    Data Alteracao:  28/05/2007   Por: Silmara
  *    Alteração:Foi alterado os parâmetros para gravar em maiúsculo
  *    Funcao: Inclui Técnica Utilizada no Procedimento
  *
  *    Data Alteração:  20/03/2014  Por:  Andréa Cazuca
  *    Alteração:  Inclusão dos campos TIS_TTP_CD_TPTENICA_V3 e TIS_TTP_DS_OBSERVACAO
  *
  *******************************************************************/

  begin

    INSERT INTO TB_TIS_TTP_TPTECNICA_PROCED
    (
       TIS_TTP_CD_TPTECNICA,
       TIS_TTP_DS_TPTECNICA,
      TIS_TTP_FL_STATUS,
       TIS_TTP_CD_TPTECNICA_V3,
       TIS_TTP_DS_OBSERVACAO,
       TIS_TTP_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       TIS_TTP_DT_ULT_ATUALIZACAO,
       SEG_USU_ID_USU_ULT_ATUALIZ
    )
    VALUES
    (
      pTIS_TTP_CD_TPTECNICA,
      UPPER(pTIS_TTP_DS_TPTECNICA),
     pTIS_TTP_FL_STATUS,
       UPPER(pTIS_TTP_CD_TPTECNICA_V3),
       UPPER(pTIS_TTP_DS_OBSERVACAO),
      SYSDATE,
      pSEG_USU_ID_USUARIO,
      SYSDATE,
      pSEG_USU_ID_USUARIO 
    );

  end PRC_TIS_TTP_TPTECNICA_PROCED_I;
 