  --PRC_ASS_CNV_UNI_LOCATE_RMT_D
  create or replace procedure PRC_ASS_CNV_UNI_LOCATE_RMT_D 
  (
     pASS_CUL_ID IN TB_ASS_CUL_CONV_UNI_LOCATEND.ASS_CUL_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CNV_UNI_LOCATE_RMT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_CUL_CONV_UNI_LOCATEND
    WHERE  
        ASS_CUL_ID = pASS_CUL_ID;	   
  end PRC_ASS_CNV_UNI_LOCATE_RMT_D;
