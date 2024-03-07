  --PRC_ATS_APS_ATEN_PROC_SEG_D
  create or replace procedure PRC_ATS_APS_ATEN_PROC_SEG_D
  (
     pATS_APS_ID IN TB_ATS_APS_ATEN_PROC_SEGMENTO.ATS_APS_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATS_APS_ATEN_PROC_SEG_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ATS_APS_ATEN_PROC_SEGMENTO
    WHERE  
        ATS_APS_ID = pATS_APS_ID;	   
  end PRC_ATS_APS_ATEN_PROC_SEG_D;