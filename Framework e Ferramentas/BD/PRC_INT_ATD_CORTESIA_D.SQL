

  --PRC_INT_ATD_CORTESIA_D
  create or replace procedure PRC_INT_ATD_CORTESIA_D 
  (
     pATD_INC_ID IN TB_ATD_INC_INT_CORTESIA.ATD_INC_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_INT_ATD_CORTESIA_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ATD_INC_INT_CORTESIA
    WHERE  
        ATD_INC_ID = pATD_INC_ID;	   
  end PRC_INT_ATD_CORTESIA_D;
