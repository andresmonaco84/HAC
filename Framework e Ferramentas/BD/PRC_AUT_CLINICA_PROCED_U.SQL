

  --PRC_AUT_CLINICA_PROCED_U
  create or replace procedure PRC_AUT_CLINICA_PROCED_U
  (
     pCODCLI IN TB_AUT_CLINICA_PROCED.CODCLI%type,
     pCODUNI IN TB_AUT_CLINICA_PROCED.CODUNI%type,
     pCODATOMED IN TB_AUT_CLINICA_PROCED.CODATOMED%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_CLINICA_PROCED_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_AUT_CLINICA_PROCED
    SET	   
 
    WHERE
        CODATOMED = pCODATOMED
    AND CODCLI = pCODCLI
    AND CODUNI = pCODUNI;	
  end PRC_AUT_CLINICA_PROCED_U;

