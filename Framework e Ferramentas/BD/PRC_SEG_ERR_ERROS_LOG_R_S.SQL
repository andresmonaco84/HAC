
--PRC_SEG_ERR_ERROS_LOG_R_S
create or replace procedure PRC_SEG_ERR_ERROS_LOG_R_S 
(
     pSEG_ERR_ID_ERRO IN TB_SEG_ERR_ERROS_LOG.SEG_ERR_ID_ERRO%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_SEG_ERR_ERROS_LOG_R_S
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT	
       SEG_ERR_ID_ERRO,
       SEG_ERR_DT_ERRO,
       SEG_ERR_DS_URL_ERRO,
       SEG_ERR_CD_CODIGO,
       SEG_ERR_DS_ERRO,
       SEG_USU_ID_USUARIO,
       SEG_ERR_DS_STACK_TRACE
FROM TB_SEG_ERR_ERROS_LOG
WHERE
        SEG_ERR_ID_ERRO = pSEG_ERR_ID_ERRO;          
io_cursor := v_cursor;
end PRC_SEG_ERR_ERROS_LOG_R_S;
