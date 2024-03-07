
--PRC_SEG_TRA_TRACE_R_U
create or replace procedure PRC_SEG_TRA_TRACE_R_U
(
     pSEG_TRA_ID_TRACE IN TB_SEG_TRA_TRACE.SEG_TRA_ID_TRACE%type,
     pSEG_TRA_DT_TRACE IN TB_SEG_TRA_TRACE.SEG_TRA_DT_TRACE%type,
     pSEG_TRA_NR_IP IN TB_SEG_TRA_TRACE.SEG_TRA_NR_IP%type,
     pSEG_TRA_DS_URL IN TB_SEG_TRA_TRACE.SEG_TRA_DS_URL%type,
     pSEG_USU_ID_USUARIO IN TB_SEG_TRA_TRACE.SEG_USU_ID_USUARIO%type
) 
is
/********************************************************************
*    Procedure: PRC_SEG_TRA_TRACE_R_U
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
begin
UPDATE TB_SEG_TRA_TRACE
SET	   
        SEG_TRA_DT_TRACE = pSEG_TRA_DT_TRACE,
        SEG_TRA_NR_IP = pSEG_TRA_NR_IP,
        SEG_TRA_DS_URL = pSEG_TRA_DS_URL,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO 
WHERE
        SEG_TRA_ID_TRACE = pSEG_TRA_ID_TRACE;	
end PRC_SEG_TRA_TRACE_R_U;

