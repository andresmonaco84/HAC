  --PRC_ATS_CPS_CAD_PROC_SEG_D
  create or replace procedure PRC_ATS_CPS_CAD_PROC_SEG_D
  (
     pATS_CPS_CD_SEGMENTO IN TB_ATS_CPS_CAD_PROC_SEGMENTO.ATS_CPS_CD_SEGMENTO%type,
     pCAD_PRD_ID IN TB_ATS_CPS_CAD_PROC_SEGMENTO.CAD_PRD_ID%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATS_CPS_CAD_PROC_SEG_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ATS_CPS_CAD_PROC_SEGMENTO
    WHERE  
        ATS_CPS_CD_SEGMENTO = pATS_CPS_CD_SEGMENTO
    AND CAD_PRD_ID = pCAD_PRD_ID;	   
  end PRC_ATS_CPS_CAD_PROC_SEG_D;