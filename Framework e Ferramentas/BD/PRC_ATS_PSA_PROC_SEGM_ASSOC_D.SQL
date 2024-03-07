

  --PRC_ATS_PSA_PROC_SEGM_ASSOC_D
  create or replace procedure PRC_ATS_PSA_PROC_SEGM_ASSOC_D 
  (
     pATS_CPS_CD_SEGMENTO IN TB_ATS_PSA_PROC_SEGM_ASSOC.ATS_CPS_CD_SEGMENTO%type,
     pATS_PSA_QT_FIM_SEG IN TB_ATS_PSA_PROC_SEGM_ASSOC.ATS_PSA_QT_FIM_SEG%type,
     pATS_PSA_QT_INI_SEG IN TB_ATS_PSA_PROC_SEGM_ASSOC.ATS_PSA_QT_INI_SEG%type,
     pATS_PSA_QT_VEZES_PROC IN TB_ATS_PSA_PROC_SEGM_ASSOC.ATS_PSA_QT_VEZES_PROC%type,
     pCAD_PRD_ID IN TB_ATS_PSA_PROC_SEGM_ASSOC.CAD_PRD_ID%type,
     pCAD_PRD_ID_PSA IN TB_ATS_PSA_PROC_SEGM_ASSOC.CAD_PRD_ID_PSA%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_ATS_PSA_PROC_SEGM_ASSOC_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_ATS_PSA_PROC_SEGM_ASSOC
    WHERE  
        ATS_CPS_CD_SEGMENTO = pATS_CPS_CD_SEGMENTO
    AND ATS_PSA_QT_FIM_SEG = pATS_PSA_QT_FIM_SEG
    AND ATS_PSA_QT_INI_SEG = pATS_PSA_QT_INI_SEG
    AND ATS_PSA_QT_VEZES_PROC = pATS_PSA_QT_VEZES_PROC
    AND CAD_PRD_ID = pCAD_PRD_ID
    AND CAD_PRD_ID_PSA = pCAD_PRD_ID_PSA;	   
  end PRC_ATS_PSA_PROC_SEGM_ASSOC_D;
