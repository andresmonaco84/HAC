

  --PRC_ATS_PSA_PROC_SEGM_ASSOC_I
  create or replace procedure PRC_ATS_PSA_PROC_SEGM_ASSOC_I
  (
     pCAD_PRD_ID IN TB_ATS_PSA_PROC_SEGM_ASSOC.CAD_PRD_ID%type,
     pATS_PSA_QT_INI_SEG IN TB_ATS_PSA_PROC_SEGM_ASSOC.ATS_PSA_QT_INI_SEG%type,
     pATS_PSA_QT_FIM_SEG IN TB_ATS_PSA_PROC_SEGM_ASSOC.ATS_PSA_QT_FIM_SEG%type,
     pCAD_PRD_ID_PSA IN TB_ATS_PSA_PROC_SEGM_ASSOC.CAD_PRD_ID_PSA%type,
     pATS_CPS_CD_SEGMENTO IN TB_ATS_PSA_PROC_SEGM_ASSOC.ATS_CPS_CD_SEGMENTO%type,
     pATS_PSA_QT_VEZES_PROC IN TB_ATS_PSA_PROC_SEGM_ASSOC.ATS_PSA_QT_VEZES_PROC%type,
     pATS_PSA_DT_ULTIMA_ATUALIZACAO IN TB_ATS_PSA_PROC_SEGM_ASSOC.ATS_PSA_DT_ULTIMA_ATUALIZACAO%type,
     pCAD_SEG_ID_USUARIO IN TB_ATS_PSA_PROC_SEGM_ASSOC.CAD_SEG_ID_USUARIO%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ATS_PSA_PROC_SEGM_ASSOC_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_ATS_PSA_PROC_SEGM_ASSOC
    (
       CAD_PRD_ID,
       ATS_PSA_QT_INI_SEG,
       ATS_PSA_QT_FIM_SEG,
       CAD_PRD_ID_PSA,
       ATS_CPS_CD_SEGMENTO,
       ATS_PSA_QT_VEZES_PROC,
       ATS_PSA_DT_ULTIMA_ATUALIZACAO,
       CAD_SEG_ID_USUARIO
    )
    VALUES
    (
	     pCAD_PRD_ID,
	     pATS_PSA_QT_INI_SEG,
	     pATS_PSA_QT_FIM_SEG,
	     pCAD_PRD_ID_PSA,
	     pATS_CPS_CD_SEGMENTO,
	     pATS_PSA_QT_VEZES_PROC,
	     pATS_PSA_DT_ULTIMA_ATUALIZACAO,
	     pCAD_SEG_ID_USUARIO
    );
	
  end PRC_ATS_PSA_PROC_SEGM_ASSOC_I;

