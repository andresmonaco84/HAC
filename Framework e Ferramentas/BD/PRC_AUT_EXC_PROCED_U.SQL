

  --PRC_AUT_EXC_PROCED_U
  create or replace procedure PRC_AUT_EXC_PROCED_U
  (
     pCODTIPEMP IN TB_AUT_EXC_PROCED.CODTIPEMP%type,
     pCODATOMED IN TB_AUT_EXC_PROCED.CODATOMED%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUT_EXC_PROCED_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_AUT_EXC_PROCED
    SET	   
 
    WHERE
        CODATOMED = pCODATOMED
    AND CODTIPEMP = pCODTIPEMP;	
  end PRC_AUT_EXC_PROCED_U;

