
--PRC_SEG_TRA_TRACE_R_I
create or replace procedure PRC_SEG_TRA_TRACE_R_I
(
     pNewIdt OUT integer,
     pSEG_TRA_ID_TRACE IN TB_SEG_TRA_TRACE.SEG_TRA_ID_TRACE%type default NULL,
     pSEG_TRA_DT_TRACE IN TB_SEG_TRA_TRACE.SEG_TRA_DT_TRACE%type,
     pSEG_TRA_NR_IP IN TB_SEG_TRA_TRACE.SEG_TRA_NR_IP%type,
     pSEG_TRA_DS_URL IN TB_SEG_TRA_TRACE.SEG_TRA_DS_URL%type,
     pSEG_USU_ID_USUARIO IN TB_SEG_TRA_TRACE.SEG_USU_ID_USUARIO%type	
) 
is
/********************************************************************
*    Procedure: PRC_SEG_TRA_TRACE_R_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
    lIdtRetorno integer;
	  
begin
    SELECT SEQ_SEG_TRA_01.NextVal INTO lIdtRetorno FROM DUAL;
	    
INSERT INTO TB_SEG_TRA_TRACE
(
       SEG_TRA_ID_TRACE,
       SEG_TRA_DT_TRACE,
       SEG_TRA_NR_IP,
       SEG_TRA_DS_URL,
       SEG_USU_ID_USUARIO
)
VALUES
(
      lIdtRetorno,
	     pSEG_TRA_DT_TRACE,
	     pSEG_TRA_NR_IP,
	     pSEG_TRA_DS_URL,
	     pSEG_USU_ID_USUARIO
);
    pNewIdt := lIdtRetorno;	
end PRC_SEG_TRA_TRACE_R_I;

