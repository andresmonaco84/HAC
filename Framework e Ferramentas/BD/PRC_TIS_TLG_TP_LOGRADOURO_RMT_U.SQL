create or replace procedure PRC_TIS_TLG_TP_LOGR_RMT_U
  (
     pTIS_TLG_CD_TPLOGRADOURO IN TB_TIS_TLG_TP_LOGRADOURO.TIS_TLG_CD_TPLOGRADOURO%type,
     pTIS_TLG_DS_TPLOGRADOURO IN TB_TIS_TLG_TP_LOGRADOURO.TIS_TLG_DS_TPLOGRADOURO%type,
     pSEG_USU_ID_USUARIO      IN TB_TIS_TLG_TP_LOGRADOURO.SEG_USU_ID_USUARIO_CRIACAO%type DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_TLG_TP_LOGRADOURO_U
  *
  *    Data Criacao:  data da  criação   Por: Nome do Analista
  *    Data Alteracao: data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  begin
    UPDATE TB_TIS_TLG_TP_LOGRADOURO
    SET
        TIS_TLG_DS_TPLOGRADOURO = pTIS_TLG_DS_TPLOGRADOURO,
        TIS_TLG_DT_ULT_ATUALIZACAO = SYSDATE,
        SEG_USU_ID_USU_ULT_ATUALIZ = pSEG_USU_ID_USUARIO
    WHERE
        TIS_TLG_CD_TPLOGRADOURO = pTIS_TLG_CD_TPLOGRADOURO;
  end PRC_TIS_TLG_TP_LOGR_RMT_U;
 