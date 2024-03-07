
--PRC_SEG_ERR_ERROS_LOG_R_I
create or replace procedure PRC_SEG_ERR_ERROS_LOG_R_I
(
     pNewIdt OUT integer,
     pSEG_ERR_ID_ERRO IN TB_SEG_ERR_ERROS_LOG.SEG_ERR_ID_ERRO%type default NULL,
     pSEG_ERR_DT_ERRO IN TB_SEG_ERR_ERROS_LOG.SEG_ERR_DT_ERRO%type,
     pSEG_ERR_DS_URL_ERRO IN TB_SEG_ERR_ERROS_LOG.SEG_ERR_DS_URL_ERRO%type,
     pSEG_ERR_CD_CODIGO IN TB_SEG_ERR_ERROS_LOG.SEG_ERR_CD_CODIGO%type default NULL,
     pSEG_ERR_DS_ERRO IN TB_SEG_ERR_ERROS_LOG.SEG_ERR_DS_ERRO%type,
     pSEG_USU_ID_USUARIO IN TB_SEG_ERR_ERROS_LOG.SEG_USU_ID_USUARIO%type,
     pSEG_ERR_DS_STACK_TRACE IN TB_SEG_ERR_ERROS_LOG.SEG_ERR_DS_STACK_TRACE%type	
) 
is
/********************************************************************
*    Procedure: PRC_SEG_ERR_ERROS_LOG_R_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
    lIdtRetorno integer;
	  
begin
    SELECT SEQ_SEG_ERR_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
INSERT INTO TB_SEG_ERR_ERROS_LOG
(
       SEG_ERR_ID_ERRO,
       SEG_ERR_DT_ERRO,
       SEG_ERR_DS_URL_ERRO,
       SEG_ERR_CD_CODIGO,
       SEG_ERR_DS_ERRO,
       SEG_USU_ID_USUARIO,
       SEG_ERR_DS_STACK_TRACE
)
VALUES
(
      lIdtRetorno,
	     pSEG_ERR_DT_ERRO,
	     pSEG_ERR_DS_URL_ERRO,
	     pSEG_ERR_CD_CODIGO,
	     pSEG_ERR_DS_ERRO,
	     pSEG_USU_ID_USUARIO,
	     pSEG_ERR_DS_STACK_TRACE
);
    pNewIdt := lIdtRetorno;	
end PRC_SEG_ERR_ERROS_LOG_R_I;

