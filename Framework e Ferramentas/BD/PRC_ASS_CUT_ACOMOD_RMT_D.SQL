

  --PRC_ASS_CUT_ACOMOD_RMT_D
  create or replace procedure PRC_ASS_CUT_ACOMOD_RMT_D 
  (
     pASS_CUT_ID IN TB_ASS_CUT_CONV_UNI_TPACOMOD.ASS_CUT_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CUT_CONV_UNI_TPACOMOD_D
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
  end PRC_ASS_CUT_ACOMOD_RMT_D;
