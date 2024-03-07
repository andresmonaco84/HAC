

  --PRC_AUT_PROCED_CARENCIA_I
  create or replace procedure PRC_AUT_PROCED_CARENCIA_I
  (
     pCODATOMED IN TB_AUT_PROCED_CARENCIA.CODATOMED%type,
     pCODSER IN TB_AUT_PROCED_CARENCIA.CODSER%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_PROCED_CARENCIA_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_AUT_PROCED_CARENCIA
    (
       CODATOMED,
       CODSER
    )
    VALUES
    (
	     pCODATOMED,
	     pCODSER
    );
	
  end PRC_AUT_PROCED_CARENCIA_I;

