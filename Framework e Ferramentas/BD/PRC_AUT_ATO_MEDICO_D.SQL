

  --PRC_AUT_ATO_MEDICO_D
  create or replace procedure PRC_AUT_ATO_MEDICO_D 
  (
     pCODATOMED IN TB_AUT_ATO_MEDICO.CODATOMED%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUT_ATO_MEDICO_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AUT_ATO_MEDICO
    WHERE  
        CODATOMED = pCODATOMED;	   
  end PRC_AUT_ATO_MEDICO_D;
