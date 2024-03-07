  --PRC_ATS_CSA_CTR_SEQ_ATE_SADT_D
  create or replace procedure PRC_ATS_CSA_CTR_SEQ_ATE_SADT_D
  (
     pAUX_EPP_CD_ESPECPROC IN TB_ATS_CSA_CTRL_SEQ_ATEND_SADT.AUX_EPP_CD_ESPECPROC%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATS_CSA_CTR_SEQ_ATE_SADT_D
  * 
  *    Data Criacao: 	01/10/2008         Por: Fabíola Lopes
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ATS_CSA_CTRL_SEQ_ATEND_SADT
    WHERE  
        AUX_EPP_CD_ESPECPROC = pAUX_EPP_CD_ESPECPROC;	   
  end PRC_ATS_CSA_CTR_SEQ_ATE_SADT_D;