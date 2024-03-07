  create or replace procedure PRC_SEG_ERR_ERROS_LOG_I 
  (
     pSEG_USU_ID_USUARIO IN TB_SEG_ERR_ERROS_LOG.SEG_USU_ID_USUARIO%type,
     pSEG_ERR_DS_URL_ERRO IN TB_SEG_ERR_ERROS_LOG.SEG_ERR_DS_URL_ERRO%type,
     pSEG_ERR_CD_CODIGO IN TB_SEG_ERR_ERROS_LOG.SEG_ERR_CD_CODIGO%type default NULL,
     pSEG_ERR_DS_ERRO IN TB_SEG_ERR_ERROS_LOG.SEG_ERR_DS_ERRO%type,
     pSEG_ERR_DS_STACK_TRACE IN TB_SEG_ERR_ERROS_LOG.SEG_ERR_DS_STACK_TRACE%type	
  ) 
  is	 
  /********************************************************************
  *    Procedure: PRC_SEG_ERR_ERROS_LOG_I
  * 
  *    Data Criacao: 	03/03/2007             Por: Carlos Eduardo
  *    Data Alteracao:                       Por: 
  *
  *    Funcao: Inclui um Log de erro do sistema
  *
  *******************************************************************/                     
  begin
	    
    INSERT INTO TB_SEG_ERR_ERROS_LOG
    (
       SEG_ERR_ID_ERRO,
       SEG_ERR_DT_ERRO,
       SEG_USU_ID_USUARIO,
       SEG_ERR_DS_URL_ERRO,
       SEG_ERR_CD_CODIGO,
       SEG_ERR_DS_ERRO,
       SEG_ERR_DS_STACK_TRACE
    )
    VALUES
    (
	     SEQ_SEG_ERR_01.NextVal,
	     SYSDATE(),
	     pSEG_USU_ID_USUARIO,
	     pSEG_ERR_DS_URL_ERRO,
	     pSEG_ERR_CD_CODIGO,
	     pSEG_ERR_DS_ERRO,
	     pSEG_ERR_DS_STACK_TRACE
    );    
  end PRC_SEG_ERR_ERROS_LOG_I;
/
