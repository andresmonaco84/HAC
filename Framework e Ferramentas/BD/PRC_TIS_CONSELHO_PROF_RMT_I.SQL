  --PRC_TIS_CONSELHO_PROF_RMT_I
  create or replace procedure PRC_TIS_CONSELHO_PROF_RMT_I
  (
     pTIS_CPR_CD_CONSELHOPROF IN TB_TIS_CPR_CONSELHO_PROF.TIS_CPR_CD_CONSELHOPROF%type,
     pTIS_CPR_DS_CONSELHOPROF IN TB_TIS_CPR_CONSELHO_PROF.TIS_CPR_DS_CONSELHOPROF%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_TIS_CONSELHO_PROF_RMT_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_TIS_CPR_CONSELHO_PROF
    (
       TIS_CPR_CD_CONSELHOPROF,
       TIS_CPR_DS_CONSELHOPROF
    )
    VALUES
    (
	     pTIS_CPR_CD_CONSELHOPROF,
	     pTIS_CPR_DS_CONSELHOPROF
    );
	
  end PRC_TIS_CONSELHO_PROF_RMT_I;

