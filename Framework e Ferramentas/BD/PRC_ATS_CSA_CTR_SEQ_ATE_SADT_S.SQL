  --PRC_ATS_CSA_CTR_SEQ_ATE_SADT_S
  create or replace procedure PRC_ATS_CSA_CTR_SEQ_ATE_SADT_S
  (
     pAUX_EPP_CD_ESPECPROC IN TB_ATS_CSA_CTRL_SEQ_ATEND_SADT.AUX_EPP_CD_ESPECPROC%type DEFAULT NULL,
     pATS_CSA_NR_ULTIMA_SEQUENCIA IN TB_ATS_CSA_CTRL_SEQ_ATEND_SADT.ATS_CSA_NR_ULTIMA_SEQUENCIA%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ATS_CSA_CTR_SEQ_ATE_SADT_S
  * 
  *    Data Criacao: 	01/10/2008         Por: Fabíola Lopes   
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       AUX_EPP_CD_ESPECPROC,
       ATS_CSA_NR_ULTIMA_SEQUENCIA
    FROM TB_ATS_CSA_CTRL_SEQ_ATEND_SADT
    WHERE
        (pAUX_EPP_CD_ESPECPROC is null OR AUX_EPP_CD_ESPECPROC = pAUX_EPP_CD_ESPECPROC) AND 
        (pATS_CSA_NR_ULTIMA_SEQUENCIA is null OR ATS_CSA_NR_ULTIMA_SEQUENCIA = pATS_CSA_NR_ULTIMA_SEQUENCIA);          
    io_cursor := v_cursor;
  end PRC_ATS_CSA_CTR_SEQ_ATE_SADT_S;