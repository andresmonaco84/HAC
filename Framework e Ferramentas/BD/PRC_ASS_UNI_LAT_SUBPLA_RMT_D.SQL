  --PRC_ASS_UNI_LAT_SUBPLA_RMT_D
  create or replace procedure PRC_ASS_UNI_LAT_SUBPLA_RMT_D 
  (
     pASS_USP_ID IN TB_ASS_USP_UNI_LAT_SUB_PLANO.ASS_USP_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_UNI_LAT_SUBPLA_RMT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_USP_UNI_LAT_SUB_PLANO
    WHERE  
        ASS_USP_ID = pASS_USP_ID;	   
  end PRC_ASS_UNI_LAT_SUBPLA_RMT_D;
