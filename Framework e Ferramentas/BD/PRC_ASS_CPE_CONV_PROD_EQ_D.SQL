  --PRC_ASS_CPE_CONV_PROD_EQUIVALE_D
  create or replace procedure PRC_ASS_CPE_CONV_PROD_EQ_D 
  (
     pASS_CPE_ID IN TB_ASS_CPE_CONV_PROD_EQUIVALE.ASS_CPE_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CPE_CONV_PROD_EQ_D
  * 
  *    Data Criacao: 	04/12/2009   Por: PEDRO
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_CPE_CONV_PROD_EQUIVALE
    WHERE  
        ASS_CPE_ID = pASS_CPE_ID;	   
  end PRC_ASS_CPE_CONV_PROD_EQ_D;

