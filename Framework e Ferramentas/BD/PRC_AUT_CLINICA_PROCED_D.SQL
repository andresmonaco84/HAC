

  --PRC_AUT_CLINICA_PROCED_D
  create or replace procedure PRC_AUT_CLINICA_PROCED_D 
  (
     pCODATOMED IN TB_AUT_CLINICA_PROCED.CODATOMED%type,
     pCODCLI IN TB_AUT_CLINICA_PROCED.CODCLI%type,
     pCODUNI IN TB_AUT_CLINICA_PROCED.CODUNI%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUT_CLINICA_PROCED_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AUT_CLINICA_PROCED
    WHERE  
        CODATOMED = pCODATOMED
    AND CODCLI = pCODCLI
    AND CODUNI = pCODUNI;	   
  end PRC_AUT_CLINICA_PROCED_D;
