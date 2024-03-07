

  --PRC_AGS_EHR_ESCALA_HOR_RESERVA_U
  create or replace procedure PRC_AGS_EHR_ESM_HOR_RESERVA_U
  (
     pAGS_EHR_ID IN TB_AGS_EHR_ESCALA_HOR_RESERVA.AGS_EHR_ID%type,
     pAGS_ESM_ID IN TB_AGS_EHR_ESCALA_HOR_RESERVA.AGS_ESM_ID%type,
     pAGS_EHR_DT_ULTIMA_ATUALIZACAO IN TB_AGS_EHR_ESCALA_HOR_RESERVA.AGS_EHR_DT_ULTIMA_ATUALIZACAO%type,
     pSEG_USU_ID_USUARIO IN TB_AGS_EHR_ESCALA_HOR_RESERVA.SEG_USU_ID_USUARIO%type,
     pCAD_PRD_ID IN TB_AGS_EHR_ESCALA_HOR_RESERVA.CAD_PRD_ID%type,
     pAGS_EHR_HR_INICIAL IN TB_AGS_EHR_ESCALA_HOR_RESERVA.AGS_EHR_HR_INICIAL%type,
     pAGS_EHR_HR_FINAL IN TB_AGS_EHR_ESCALA_HOR_RESERVA.AGS_EHR_HR_FINAL%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AGS_EHR_ESCALA_HOR_RESERVA_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_AGS_EHR_ESCALA_HOR_RESERVA
    SET	   
        AGS_ESM_ID = pAGS_ESM_ID,
        AGS_EHR_DT_ULTIMA_ATUALIZACAO = pAGS_EHR_DT_ULTIMA_ATUALIZACAO,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        CAD_PRD_ID = pCAD_PRD_ID,
        AGS_EHR_HR_INICIAL = pAGS_EHR_HR_INICIAL,
        AGS_EHR_HR_FINAL = pAGS_EHR_HR_FINAL 
    WHERE
        AGS_EHR_ID = pAGS_EHR_ID;	
  end PRC_AGS_EHR_ESM_HOR_RESERVA_U;

