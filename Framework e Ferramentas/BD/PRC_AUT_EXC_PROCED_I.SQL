

  --PRC_AUT_EXC_PROCED_I
  create or replace procedure PRC_AUT_EXC_PROCED_I
  (
     pCODTIPEMP IN TB_AUT_EXC_PROCED.CODTIPEMP%type,
     pCODATOMED IN TB_AUT_EXC_PROCED.CODATOMED%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_EXC_PROCED_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_AUT_EXC_PROCED
    (
       CODTIPEMP,
       CODATOMED
    )
    VALUES
    (
	     pCODTIPEMP,
	     pCODATOMED
    );
	
  end PRC_AUT_EXC_PROCED_I;

