  --PRC_ATS_ASR_ATEN_PRO_SEG_RET_D
  create or replace procedure PRC_ATS_ASR_ATEN_PRO_SEG_RET_D 
  (
     pATS_ASR_ID IN TB_ATS_ASR_ATEN_PRO_SEG_RETIF.ATS_ASR_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATS_ASR_ATEN_PRO_SEG_RET_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ATS_ASR_ATEN_PRO_SEG_RETIF
    WHERE  
        ATS_ASR_ID = pATS_ASR_ID;	   
  end PRC_ATS_ASR_ATEN_PRO_SEG_RET_D;