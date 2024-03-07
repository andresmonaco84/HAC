  --PRC_ASS_CNV_DOC_LOCATE_RMT_D
  create or replace procedure PRC_ASS_CNV_DOC_LOCATE_RMT_D 
  (
     pASS_CDL_ID IN TB_ASS_CDL_CONV_DOC_LOCATEND.ASS_CDL_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CNV_DOC_LOCATE_RMT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_CDL_CONV_DOC_LOCATEND
    WHERE  
        ASS_CDL_ID = pASS_CDL_ID;	   
  end PRC_ASS_CNV_DOC_LOCATE_RMT_D;
