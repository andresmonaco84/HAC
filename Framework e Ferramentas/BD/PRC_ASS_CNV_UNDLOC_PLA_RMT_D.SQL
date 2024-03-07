  --PRC_ASS_CNV_UNDLOC_PLA_RMT_D
  create or replace procedure PRC_ASS_CNV_UNDLOC_PLA_RMT_D 
  (
     pASS_CLP_ID IN TB_ASS_CLP_CNV_UND_LOC_PLANO.ASS_CLP_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CNV_UNDLOC_PLA_RMT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_CLP_CNV_UND_LOC_PLANO
    WHERE  
        ASS_CLP_ID = pASS_CLP_ID;	   
  end PRC_ASS_CNV_UNDLOC_PLA_RMT_D;
