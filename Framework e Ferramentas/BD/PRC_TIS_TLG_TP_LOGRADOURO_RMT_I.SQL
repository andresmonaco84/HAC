create or replace procedure PRC_TIS_TLG_TP_LOGR_RMT_I
  (
     pTIS_TLG_CD_TPLOGRADOURO IN TB_TIS_TLG_TP_LOGRADOURO.TIS_TLG_CD_TPLOGRADOURO%type,
     pTIS_TLG_DS_TPLOGRADOURO IN TB_TIS_TLG_TP_LOGRADOURO.TIS_TLG_DS_TPLOGRADOURO%type,
     pSEG_USU_ID_USUARIO      IN TB_TIS_TLG_TP_LOGRADOURO.SEG_USU_ID_USUARIO_CRIACAO%type DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_TLG_TP_LOGRADOURO_I
  *
  *    Data Criacao:  data da  criação   Por: Nome do Analista
  *    Data Alteracao: data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/

  begin

    INSERT INTO TB_TIS_TLG_TP_LOGRADOURO
    (
       TIS_TLG_CD_TPLOGRADOURO,
       TIS_TLG_DS_TPLOGRADOURO,
       TIS_TLG_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       TIS_TLG_DT_ULT_ATUALIZACAO,
       SEG_USU_ID_USU_ULT_ATUALIZ
    )
    VALUES
    (
      pTIS_TLG_CD_TPLOGRADOURO,
      pTIS_TLG_DS_TPLOGRADOURO,
      SYSDATE,
      pSEG_USU_ID_USUARIO,
      SYSDATE,
      pSEG_USU_ID_USUARIO 
    );

  end PRC_TIS_TLG_TP_LOGR_RMT_I;
 