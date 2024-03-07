

  --PRC_ASS_CTA_CONV_TPATEND_RMT_D
  create or replace procedure PRC_ASS_CTA_CONV_TPATEND_RMT_D 
  (
     pASS_CTA_ID IN TB_ASS_CTA_CONV_TPATEND.ASS_CTA_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CTA_CONV_TPATEND_RMT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_CTA_CONV_TPATEND
    WHERE  
        ASS_CTA_ID = pASS_CTA_ID;	   
  end PRC_ASS_CTA_CONV_TPATEND_RMT_D;
