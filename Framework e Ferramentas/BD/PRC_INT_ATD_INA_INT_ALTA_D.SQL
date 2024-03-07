  --PRC_INT_ATD_INA_INT_ALTA_D
  create or replace procedure PRC_INT_ATD_INA_INT_ALTA_D
  (
     pATD_ATE_ID IN TB_ATD_INA_INT_ALTA.ATD_ATE_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_INT_ATD_INA_INT_ALTA_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ATD_INA_INT_ALTA
    WHERE  
        ATD_ATE_ID = pATD_ATE_ID;	   
  end PRC_INT_ATD_INA_INT_ALTA_D;