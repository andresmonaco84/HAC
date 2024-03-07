  --PRC_ATS_CSA_CTR_SEQ_ATE_SADT_I
  create or replace procedure PRC_ATS_CSA_CTR_SEQ_ATE_SADT_I
  (
     pAUX_EPP_CD_ESPECPROC IN TB_ATS_CSA_CTRL_SEQ_ATEND_SADT.AUX_EPP_CD_ESPECPROC%type,
     pATS_CSA_NR_ULTIMA_SEQUENCIA IN TB_ATS_CSA_CTRL_SEQ_ATEND_SADT.ATS_CSA_NR_ULTIMA_SEQUENCIA%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ATS_CSA_CTR_SEQ_ATE_SADT_I
  * 
  *    Data Criacao: 	01/10/2008         Por: Fabíola Lopes   
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_ATS_CSA_CTRL_SEQ_ATEND_SADT
    (
       AUX_EPP_CD_ESPECPROC,
       ATS_CSA_NR_ULTIMA_SEQUENCIA
    )
    VALUES
    (
	     pAUX_EPP_CD_ESPECPROC,
	     pATS_CSA_NR_ULTIMA_SEQUENCIA
    );
	
  end PRC_ATS_CSA_CTR_SEQ_ATE_SADT_I;