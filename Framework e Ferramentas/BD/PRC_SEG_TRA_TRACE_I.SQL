  create or replace procedure PRC_SEG_TRA_TRACE_I
  (
     pNewIdt OUT integer,
     pSEG_TRA_NR_IP IN TB_SEG_TRA_TRACE.SEG_TRA_NR_IP%type,
     pSEG_TRA_DS_URL IN TB_SEG_TRA_TRACE.SEG_TRA_DS_URL%type,
     pSEG_USU_ID_USUARIO IN TB_SEG_TRA_TRACE.SEG_USU_ID_USUARIO%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_TRA_TRACE_I
  * 
  *    Data Criacao: 	03/05/2007   Por: Cristiane Gomes da Silva
  *    Data Alteracao:	            Por: 
  *
  *    Funcao: Inclui Log de Acesso de Usuário(s) nas Rotinas do SGS
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
	     SYSDATE,
	     pSEG_TRA_NR_IP,
	     pSEG_TRA_DS_URL,
	     pSEG_USU_ID_USUARIO
    );
    pNewIdt := lIdtRetorno;	
  end PRC_SEG_TRA_TRACE_I;
/
