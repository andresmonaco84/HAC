  --PRC_ATD_ATENDIMENTO_R_D
  create or replace procedure PRC_ATD_ATENDIMENTO_R_D 
  (
     pATD_ATE_ID IN TB_ATD_ATE_ATENDIMENTO.ATD_ATE_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATD_ATENDIMENTO_R_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ATD_ATE_ATENDIMENTO
    WHERE  
        ATD_ATE_ID = pATD_ATE_ID;	   
  end PRC_ATD_ATENDIMENTO_R_D;
