  --PRC_SEG_TRA_TRACE_S
  create or replace procedure PRC_SEG_TRA_TRACE_S 
  (
     pSEG_USU_ID_USUARIO IN TB_SEG_TRA_TRACE.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     pSEG_TRA_DT_TRACE IN TB_SEG_TRA_TRACE.SEG_TRA_DT_TRACE%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_TRA_TRACE_S
  * 
  *    Data Criacao: 	03/05/2007   Por: Cristiane Gomes da Silva
  *    Data Alteracao: 04/05/2007   Por: Cristiane Gomes da Silva
  *
  *    Funcao: Obtém Log de Acesso de Usuário(s) nas Rotinas do SGS
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       SEG_TRA_ID_TRACE,
       SEG_TRA_DT_TRACE,
       SEG_TRA_NR_IP,
       SEG_TRA_DS_URL,
       SEG_USU_ID_USUARIO
    FROM TB_SEG_TRA_TRACE
    WHERE
        ((pSEG_USU_ID_USUARIO is null OR SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO)
    AND (pSEG_TRA_DT_TRACE is null OR TRUNC(SEG_TRA_DT_TRACE) = TRUNC(pSEG_TRA_DT_TRACE)))
    ORDER BY SEG_TRA_DT_TRACE;          
    io_cursor := v_cursor;
  end PRC_SEG_TRA_TRACE_S;
/
