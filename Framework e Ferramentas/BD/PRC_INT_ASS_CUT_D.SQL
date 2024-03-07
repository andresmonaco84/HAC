  --PRC_INT_ASS_CUT_D
  create or replace procedure PRC_INT_ASS_CUT_D 
  (
     pASS_CUT_ID IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_CUT_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_INT_ASS_CUT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_CUT_CONV_UNI_TPACOMOD
    WHERE  
        ASS_CUT_ID = pASS_CUT_ID;	   
  end PRC_INT_ASS_CUT_D;
