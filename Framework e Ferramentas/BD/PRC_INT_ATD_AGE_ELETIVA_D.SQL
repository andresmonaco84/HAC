  --PRC_INT_ATD_AGE_ELETIVA_D
  create or replace procedure PRC_INT_ATD_AGE_ELETIVA_D 
  (
     pATD_IAE_ID IN TB_ATD_IAE_INT_AGE_ELETIVA.ATD_IAE_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_INT_ATD_AGE_ELETIVA_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ATD_IAE_INT_AGE_ELETIVA
    WHERE  
        ATD_IAE_ID = pATD_IAE_ID;	   
  end PRC_INT_ATD_AGE_ELETIVA_D;
