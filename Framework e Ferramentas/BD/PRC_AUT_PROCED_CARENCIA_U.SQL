

  --PRC_AUT_PROCED_CARENCIA_U
  create or replace procedure PRC_AUT_PROCED_CARENCIA_U
  (
     pCODATOMED IN TB_AUT_PROCED_CARENCIA.CODATOMED%type,
     pCODSER IN TB_AUT_PROCED_CARENCIA.CODSER%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_PROCED_CARENCIA_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_AUT_PROCED_CARENCIA
    SET	   
 
    WHERE
        CODATOMED = pCODATOMED
    AND CODSER = pCODSER;	
  end PRC_AUT_PROCED_CARENCIA_U;

