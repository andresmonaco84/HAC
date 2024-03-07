
--PRC_SEG_ERR_ERROS_LOG_R_D
create or replace procedure PRC_SEG_ERR_ERROS_LOG_R_D 
(
     pSEG_ERR_ID_ERRO IN TB_SEG_ERR_ERROS_LOG.SEG_ERR_ID_ERRO%type	
)
is
/********************************************************************
*    Procedure: PRC_SEG_ERR_ERROS_LOG_R_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_SEG_ERR_ERROS_LOG
WHERE  
        SEG_ERR_ID_ERRO = pSEG_ERR_ID_ERRO;	   
end PRC_SEG_ERR_ERROS_LOG_R_D;
