  create or replace procedure PRC_SEG_ERR_ERROS_LOG_D 
  (
     pSEG_ERR_ID_ERRO IN TB_SEG_ERR_ERROS_LOG.SEG_ERR_ID_ERRO%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_SEG_ERR_ERROS_LOG_D
  * 
  *    Data Criacao: 	03/03/2007             Por: Carlos Eduardo
  *    Data Alteracao:                       Por: 
  *
  *    Funcao: Exclui um Log de erro do sistema
  *
  *******************************************************************/                       
  begin
    DELETE TB_SEG_ERR_ERROS_LOG
    WHERE  
        SEG_ERR_ID_ERRO = pSEG_ERR_ID_ERRO;	   
  end PRC_SEG_ERR_ERROS_LOG_D;
/
