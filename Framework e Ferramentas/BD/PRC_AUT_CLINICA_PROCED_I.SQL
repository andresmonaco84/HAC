

  --PRC_AUT_CLINICA_PROCED_I
  create or replace procedure PRC_AUT_CLINICA_PROCED_I
  (
     pCODCLI IN TB_AUT_CLINICA_PROCED.CODCLI%type,
     pCODUNI IN TB_AUT_CLINICA_PROCED.CODUNI%type,
     pCODATOMED IN TB_AUT_CLINICA_PROCED.CODATOMED%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_CLINICA_PROCED_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_AUT_CLINICA_PROCED
    (
       CODCLI,
       CODUNI,
       CODATOMED
    )
    VALUES
    (
	     pCODCLI,
	     pCODUNI,
	     pCODATOMED
    );
	
  end PRC_AUT_CLINICA_PROCED_I;

