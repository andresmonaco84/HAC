  create or replace procedure PRC_ATS_CSL_CTRL_SEQ_LOTE_S 
  (
     pATS_APR_NR_SEQ_LOTE IN TB_ATS_CSL_CTRL_SEQ_LOTE.ATS_APR_NR_SEQ_LOTE%type DEFAULT NULL,
     pATS_CSL_DT_LOTE IN TB_ATS_CSL_CTRL_SEQ_LOTE.ATS_CSL_DT_LOTE%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_ATS_CSL_CTRL_SEQ_LOTE.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     pATS_CSL_HR_LOTE IN TB_ATS_CSL_CTRL_SEQ_LOTE.ATS_CSL_HR_LOTE%type DEFAULT NULL,
     pDT_ULTIMA_ATUALIZACAO IN TB_ATS_CSL_CTRL_SEQ_LOTE.DT_ULTIMA_ATUALIZACAO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ATS_CSL_CTRL_SEQ_LOTE_S
  * 
  *    Data Criacao: 	20/02/2009   Por: Andrea Cazuca
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Seleciona o Lote de Exames Protocolados
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
       pDT_ULTIMA_ATUALIZACAO
    FROM TB_ATS_CSL_CTRL_SEQ_LOTE
    WHERE
        (pATS_APR_NR_SEQ_LOTE is null OR ATS_APR_NR_SEQ_LOTE = pATS_APR_NR_SEQ_LOTE) AND 
        (pATS_CSL_DT_LOTE is null OR ATS_CSL_DT_LOTE = pATS_CSL_DT_LOTE) AND 
        (pSEG_USU_ID_USUARIO is null OR SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO) AND 
        (pATS_CSL_HR_LOTE is null OR ATS_CSL_HR_LOTE = pATS_CSL_HR_LOTE) AND 
        (pDT_ULTIMA_ATUALIZACAO is null OR DT_ULTIMA_ATUALIZACAO = pDT_ULTIMA_ATUALIZACAO);          
    io_cursor := v_cursor;
  end PRC_ATS_CSL_CTRL_SEQ_LOTE_S;
/
