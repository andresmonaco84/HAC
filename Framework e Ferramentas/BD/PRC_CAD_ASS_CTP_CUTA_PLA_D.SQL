  --PRC_INT_ASS_CTP_CUTA_PLA_D
  create or replace procedure PRC_CAD_ASS_CTP_CUTA_PLA_D 
  (
     pASS_CTP_ID IN TB_ASS_CTP_CNV_UN_TPACOM_PLA.ASS_CTP_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_ASS_CTP_CUTA_PLA_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_CTP_CNV_UN_TPACOM_PLA
    WHERE  
        ASS_CTP_ID = pASS_CTP_ID;	   
  end PRC_CAD_ASS_CTP_CUTA_PLA_D;
