

  --PRC_AUT_PROCED_CARENCIA_D
  create or replace procedure PRC_AUT_PROCED_CARENCIA_D 
  (
     pCODATOMED IN TB_AUT_PROCED_CARENCIA.CODATOMED%type,
     pCODSER IN TB_AUT_PROCED_CARENCIA.CODSER%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUT_PROCED_CARENCIA_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AUT_PROCED_CARENCIA
    WHERE  
        CODATOMED = pCODATOMED
    AND CODSER = pCODSER;	   
  end PRC_AUT_PROCED_CARENCIA_D;
