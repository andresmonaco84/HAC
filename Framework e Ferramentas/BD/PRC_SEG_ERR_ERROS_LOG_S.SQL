  create or replace procedure PRC_SEG_ERR_ERROS_LOG_S 
  (
     pSEG_ERR_ID_ERRO IN TB_SEG_ERR_ERROS_LOG.SEG_ERR_ID_ERRO%type DEFAULT NULL,
     pSEG_ERR_DT_ERRO_INICIO IN TB_SEG_ERR_ERROS_LOG.SEG_ERR_DT_ERRO%type DEFAULT NULL,
     pSEG_ERR_DT_ERRO_TERMINO IN TB_SEG_ERR_ERROS_LOG.SEG_ERR_DT_ERRO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_ERR_ERROS_LOG_S
  * 
  *    Data Criacao: 	03/03/2007             Por: Carlos Eduardo
  *    Data Alteracao:                       Por: 
  *
  *    Funcao: Obtém o Log de Erros do sistema a partir de um período
  *
  *******************************************************************/                       
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       SEG_ERR_ID_ERRO,
       SEG_ERR_DT_ERRO,
       SEG_USU_ID_USUARIO,
       SEG_ERR_DS_URL_ERRO,
       SEG_ERR_CD_CODIGO,
       SEG_ERR_DS_ERRO,
       SEG_ERR_DS_STACK_TRACE
    FROM TB_SEG_ERR_ERROS_LOG
    WHERE
         (pSEG_ERR_ID_ERRO is null OR SEG_ERR_ID_ERRO = pSEG_ERR_ID_ERRO)
    AND  (pSEG_ERR_DT_ERRO_INICIO is null OR SEG_ERR_DT_ERRO >= pSEG_ERR_DT_ERRO_INICIO)
    AND  (pSEG_ERR_DT_ERRO_TERMINO is null OR SEG_ERR_DT_ERRO <= pSEG_ERR_DT_ERRO_TERMINO)
    ORDER BY SEG_ERR_DT_ERRO DESC;
    io_cursor := v_cursor;
  end PRC_SEG_ERR_ERROS_LOG_S;
/
