

  --PRC_AUT_EXC_PROCED_D
  create or replace procedure PRC_AUT_EXC_PROCED_D 
  (
     pCODATOMED IN TB_AUT_EXC_PROCED.CODATOMED%type,
     pCODTIPEMP IN TB_AUT_EXC_PROCED.CODTIPEMP%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUT_EXC_PROCED_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AUT_EXC_PROCED
    WHERE  
        CODATOMED = pCODATOMED
    AND CODTIPEMP = pCODTIPEMP;	   
  end PRC_AUT_EXC_PROCED_D;
