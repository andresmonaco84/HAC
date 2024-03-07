  --PRC_AGE_PEE_PERIODO_ESCALA_D
  create or replace procedure PRC_AGE_PEE_PERIODO_ESCALA_D 
  (
     pAGE_PEE_ID IN TB_AGE_PEE_PERIODO_ESCALA.AGE_PEE_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AGE_PEE_PERIODO_ESCALA_D
  * 
  *    Data Criacao: 	  10/07/2007           Por: Carlos Eduardo
  *    Data Alteracao:	                     Por: 
  *
  *    Funcao: Exclui um período de escala médica não utilizado
  *
  *******************************************************************/    
  begin
    DELETE TB_AGE_PEE_PERIODO_ESCALA
    WHERE  
        AGE_PEE_ID = pAGE_PEE_ID;	   
  end PRC_AGE_PEE_PERIODO_ESCALA_D;
/
