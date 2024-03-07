CREATE OR REPLACE PROCEDURE "PRC_TIS_TFA_TP_FATURAMENTO_U"
  (
     pTIS_TFA_CD_TPFATURAMENTO    IN TB_TIS_TFA_TP_FATURAMENTO.TIS_TFA_CD_TPFATURAMENTO%type,
     pTIS_TFA_DS_TPFATURAMENTO    IN TB_TIS_TFA_TP_FATURAMENTO.TIS_TFA_DS_TPFATURAMENTO%type,
     pTIS_TFA_CD_TPFATURAMENTO_V3 IN TB_TIS_TFA_TP_FATURAMENTO.TIS_TFA_CD_TPFATURAMENTO_V3%type default null,
     pTIS_TFA_OBSERVACAO          IN TB_TIS_TFA_TP_FATURAMENTO.TIS_TFA_OBSERVACAO%type default null,
     pSEG_USU_ID_USUARIO          IN TB_TIS_TFA_TP_FATURAMENTO.SEG_USU_ID_USUARIO_CRIACAO%type DEFAULT NULL
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_TFA_TP_FATURAMENTO_U
  *
  *    Data Criacao:  12/04/2007       Por: Fabiola R. Lopes
  *    Data Alteracao: 28/05/2007         Por: Silmara
  *    Alterac?o:Foi alterado os parametros para gravar em maiusculo
  *    Funcao: Alterar os Tipos de Faturamentos
  *
  *    Data Alteracao: 31/03/2014  Por: Andréa Cazuca
  *    Alteracao:  Inclusão dos campos TIS_TFA_CD_TPFATURAMENTO_V3 e TIS_TFA_OBSERVACAO
  *
  *******************************************************************/
  begin
    UPDATE TB_TIS_TFA_TP_FATURAMENTO
    SET
        TIS_TFA_DS_TPFATURAMENTO = UPPER(pTIS_TFA_DS_TPFATURAMENTO),
        TIS_TFA_CD_TPFATURAMENTO_V3 = UPPER(pTIS_TFA_CD_TPFATURAMENTO_V3),
        TIS_TFA_OBSERVACAO = UPPER(pTIS_TFA_OBSERVACAO),
        TIS_TFA_DT_ULT_ATUALIZACAO = SYSDATE,
        SEG_USU_ID_USU_ULT_ATUALIZ = pSEG_USU_ID_USUARIO
    WHERE
        TIS_TFA_CD_TPFATURAMENTO = UPPER(pTIS_TFA_CD_TPFATURAMENTO);
  end PRC_TIS_TFA_TP_FATURAMENTO_U;
 
