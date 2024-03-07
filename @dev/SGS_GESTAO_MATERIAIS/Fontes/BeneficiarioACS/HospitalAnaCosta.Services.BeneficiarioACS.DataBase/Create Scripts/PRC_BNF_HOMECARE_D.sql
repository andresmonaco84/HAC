create or replace procedure PRC_BNF_HOMECARE_D
  (
     pBNF_HOMECARE_ID IN TB_BNF_HOMECARE.BNF_HOMECARE_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_BNF_HOMECARE_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_BNF_HOMECARE
    WHERE  
        BNF_HOMECARE_ID = pBNF_HOMECARE_ID;	   
  end PRC_BNF_HOMECARE_D;
 