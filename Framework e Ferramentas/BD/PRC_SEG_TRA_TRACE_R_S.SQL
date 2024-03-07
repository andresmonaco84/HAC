
--PRC_SEG_TRA_TRACE_R_S
create or replace procedure PRC_SEG_TRA_TRACE_R_S 
(
     pSEG_TRA_ID_TRACE IN TB_SEG_TRA_TRACE.SEG_TRA_ID_TRACE%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_SEG_TRA_TRACE_R_S
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
       SEG_TRA_ID_TRACE,
       SEG_TRA_DT_TRACE,
       SEG_TRA_NR_IP,
       SEG_TRA_DS_URL,
       SEG_USU_ID_USUARIO
FROM TB_SEG_TRA_TRACE
WHERE
        SEG_TRA_ID_TRACE = pSEG_TRA_ID_TRACE;          
io_cursor := v_cursor;
end PRC_SEG_TRA_TRACE_R_S;
