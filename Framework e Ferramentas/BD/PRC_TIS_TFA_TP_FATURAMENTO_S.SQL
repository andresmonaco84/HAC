CREATE OR REPLACE PROCEDURE "PRC_TIS_TFA_TP_FATURAMENTO_S"
  (
     pTIS_TFA_CD_TPFATURAMENTO IN TB_TIS_TFA_TP_FATURAMENTO.TIS_TFA_CD_TPFATURAMENTO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_TFA_TP_FATURAMENTO_S
  *
  *    Data Criacao:  12/04/2007       Por: Fabiola R. Lopes
  *    Funcao: Listar os Tipos de Faturamentos
  *
  *    Data Alteracao: 31/03/2014  Por: Andréa Cazuca
  *    Alteracao:  Inclusão dos campos TIS_TFA_CD_TPFATURAMENTO_V3 e TIS_TFA_OBSERVACAO
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       TIS_TFA_CD_TPFATURAMENTO,
       TIS_TFA_DS_TPFATURAMENTO,
       TIS_TFA_CD_TPFATURAMENTO_V3,
       TIS_TFA_OBSERVACAO
    FROM TB_TIS_TFA_TP_FATURAMENTO
    WHERE
        (pTIS_TFA_CD_TPFATURAMENTO is null OR TIS_TFA_CD_TPFATURAMENTO = pTIS_TFA_CD_TPFATURAMENTO)
    ORDER BY TIS_TFA_CD_TPFATURAMENTO;
    io_cursor := v_cursor;
  end PRC_TIS_TFA_TP_FATURAMENTO_S;
 