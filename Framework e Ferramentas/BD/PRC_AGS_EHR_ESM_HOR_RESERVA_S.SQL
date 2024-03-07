 
  --PRC_AGS_EHR_ESCALA_HOR_RESERVA_S
  create or replace procedure PRC_AGS_EHR_ESM_HOR_RESERVA_S 
  (
     pAGS_EHR_ID IN TB_AGS_EHR_ESCALA_HOR_RESERVA.AGS_EHR_ID%type DEFAULT NULL,
     pAGS_ESM_ID IN TB_AGS_EHR_ESCALA_HOR_RESERVA.AGS_ESM_ID%type DEFAULT NULL,
     pAGS_EHR_DT_ULTIMA_ATUALIZACAO IN TB_AGS_EHR_ESCALA_HOR_RESERVA.AGS_EHR_DT_ULTIMA_ATUALIZACAO%type DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_AGS_EHR_ESCALA_HOR_RESERVA.SEG_USU_ID_USUARIO%type DEFAULT NULL,
     pCAD_PRD_ID IN TB_AGS_EHR_ESCALA_HOR_RESERVA.CAD_PRD_ID%type DEFAULT NULL,
     pAGS_EHR_HR_INICIAL IN TB_AGS_EHR_ESCALA_HOR_RESERVA.AGS_EHR_HR_INICIAL%type DEFAULT NULL,
     pAGS_EHR_HR_FINAL IN TB_AGS_EHR_ESCALA_HOR_RESERVA.AGS_EHR_HR_FINAL%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AGS_EHR_ESCALA_HOR_RESERVA_S
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       AGS_EHR_ID,
       AGS_ESM_ID,
       AGS_EHR_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_PRD_ID,
       AGS_EHR_HR_INICIAL,
       AGS_EHR_HR_FINAL
    FROM TB_AGS_EHR_ESCALA_HOR_RESERVA
    WHERE
        (pAGS_EHR_ID is null OR AGS_EHR_ID = pAGS_EHR_ID) AND 
        (pAGS_ESM_ID is null OR AGS_ESM_ID = pAGS_ESM_ID) AND 
        (pAGS_EHR_DT_ULTIMA_ATUALIZACAO is null OR AGS_EHR_DT_ULTIMA_ATUALIZACAO = pAGS_EHR_DT_ULTIMA_ATUALIZACAO) AND 
        (pSEG_USU_ID_USUARIO is null OR SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO) AND 
        (pCAD_PRD_ID is null OR CAD_PRD_ID = pCAD_PRD_ID) AND 
        (pAGS_EHR_HR_INICIAL is null OR AGS_EHR_HR_INICIAL = pAGS_EHR_HR_INICIAL) AND 
        (pAGS_EHR_HR_FINAL is null OR AGS_EHR_HR_FINAL = pAGS_EHR_HR_FINAL);          
    io_cursor := v_cursor;
  end PRC_AGS_EHR_ESM_HOR_RESERVA_S;
