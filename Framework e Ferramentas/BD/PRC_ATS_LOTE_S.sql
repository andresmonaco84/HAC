 create or replace procedure PRC_ATS_LOTE_S
  (
    
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATS_LOTE_S
  *
  *    Data Criacao:  20/02/2009   Por: Andrea Cazuca
  *    Data Alteracao: 04/08/2009  Por: Pedro
  *
  *    Funcao: Seleciona os Lotes de Exames Protocolados nos ultimos 3 meses para popular o combo
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       ATS_APR_NR_SEQ_LOTE,
       ATS_CSL_DT_LOTE,
       SEG_USU_ID_USUARIO,
       ATS_CSL_HR_LOTE,
       DT_ULTIMA_ATUALIZACAO
       
    FROM TB_ATS_CSL_CTRL_SEQ_LOTE A
    WHERE
         (ATS_CSL_DT_LOTE >= add_months(trunc(sysdate), -3))
         
        ;
    io_cursor := v_cursor;
  end PRC_ATS_LOTE_S;
