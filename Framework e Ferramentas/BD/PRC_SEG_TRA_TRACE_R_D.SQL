
--PRC_SEG_TRA_TRACE_R_D
create or replace procedure PRC_SEG_TRA_TRACE_R_D 
(
     pSEG_TRA_ID_TRACE IN TB_SEG_TRA_TRACE.SEG_TRA_ID_TRACE%type	
)
is
/********************************************************************
*    Procedure: PRC_SEG_TRA_TRACE_R_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_SEG_TRA_TRACE
WHERE  
        SEG_TRA_ID_TRACE = pSEG_TRA_ID_TRACE;	   
end PRC_SEG_TRA_TRACE_R_D;
