  --PRC_ASS_CNV_DC_LOC_PLA_RMT_D
  create or replace procedure PRC_ASS_CNV_DC_LOC_PLA_RMT_D 
  (
     pASS_CDP_ID IN TB_ASS_CDP_CNV_DC_LOC_PLANO.ASS_CDP_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CNV_DC_LOC_PLA_RMT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_CDP_CNV_DC_LOC_PLANO
    WHERE  
        ASS_CDP_ID = pASS_CDP_ID;	   
  end PRC_ASS_CNV_DC_LOC_PLA_RMT_D;
