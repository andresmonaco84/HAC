  create or replace procedure PRC_ASS_PPG_PAC_ATE_PRO_GUIA_D 
  (
     pATD_ATE_ID IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.ATD_ATE_ID%type,
     pCAD_PAC_ID_PACIENTE IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.CAD_PAC_ID_PACIENTE%type,
     pCAD_PRD_ID IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.CAD_PRD_ID%type default null
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PPG_PAC_ATE_PRO_GUIA_D
  * 
  *    Data Criacao: 	24/03/2008   Por: Andrea Cazuca
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Exclui Guia por Procedimento
  *
  *******************************************************************/    
  begin
    DELETE TB_ASS_PPG_PAC_ATE_PROC_GUIA
    WHERE  
        ATD_ATE_ID = pATD_ATE_ID
    AND CAD_PAC_ID_PACIENTE = pCAD_PAC_ID_PACIENTE
    AND (pCAD_PRD_ID is null or CAD_PRD_ID = pCAD_PRD_ID);	   
  end PRC_ASS_PPG_PAC_ATE_PRO_GUIA_D;
/
