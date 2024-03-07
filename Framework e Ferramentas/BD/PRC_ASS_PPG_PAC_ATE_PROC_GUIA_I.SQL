  create or replace procedure PRC_ASS_PPG_PAC_ATE_PRO_GUIA_I
  (
     pSEG_USU_ID_USUARIO IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.SEG_USU_ID_USUARIO%type,
     pATE_GUI_CD_CODIGO IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.ATE_GUI_CD_CODIGO%type,
     pATE_GUI_DT_VALIDADE IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.ATE_GUI_DT_VALIDADE%type,
     pATD_ATE_ID IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.ATD_ATE_ID%type,
     pCAD_PRD_ID IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.CAD_PRD_ID%type default null,
     pCAD_PAC_ID_PACIENTE IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.CAD_PAC_ID_PACIENTE%type,
     pASS_PPG_CD_SENHA IN TB_ASS_PPG_PAC_ATE_PROC_GUIA.ASS_PPG_CD_SENHA%type default null,
     pASS_PPG_CD_SENHA_AUTORIZADOR in tb_ass_ppg_pac_ate_proc_guia.ASS_PPG_CD_SENHA_AUTORIZADOR%type default null   
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_PPG_PAC_ATE_PRO_GUIA_I
  * 
  *    Data Criacao: 	24/03/2008   Por: Andrea Cazuca
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Incluir Guia Procedimento
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_ASS_PPG_PAC_ATE_PROC_GUIA
    (
       SEG_USU_ID_USUARIO,
       ASS_PPG_DT_ULTIMA_ATUALIZACAO,
       ATE_GUI_CD_CODIGO,
       ATE_GUI_DT_VALIDADE,
       ATD_ATE_ID,
       CAD_PRD_ID,
       CAD_PAC_ID_PACIENTE,
       ASS_PPG_CD_SENHA,
       ASS_PPG_CD_SENHA_AUTORIZADOR
    )
    VALUES
    (
	     pSEG_USU_ID_USUARIO,
	     sysdate,
	     pATE_GUI_CD_CODIGO,
	     pATE_GUI_DT_VALIDADE,
	     pATD_ATE_ID,
	     pCAD_PRD_ID,
	     pCAD_PAC_ID_PACIENTE,
       pASS_PPG_CD_SENHA,
       ASS_PPG_CD_SENHA_AUTORIZADOR
    );
	
  end PRC_ASS_PPG_PAC_ATE_PRO_GUIA_I;
/
