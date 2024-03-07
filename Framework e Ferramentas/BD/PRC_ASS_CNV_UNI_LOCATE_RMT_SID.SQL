  --PRC_ASS_CNV_UNI_LOCATE_RMT_SID
  create or replace procedure PRC_ASS_CNV_UNI_LOCATE_RMT_SID 
  (
     pASS_CUL_ID IN TB_ASS_CUL_CONV_UNI_LOCATEND.ASS_CUL_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_CNV_UNI_LOCATE_RMT_SID
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
       ASS_CUL_ID,
       ASS_CUL_DT_INI_VIGENCIA,
       ASS_CUL_DS_MOTIVO_FIM_VIGENCIA,
       ASS_CUL_DT_ULTIMA_ATUALIZACAO,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       ASS_CUL_DT_FIM_VIGENCIA,
       SEG_USU_ID_USUARIO,
       ASS_CNU_ID
    FROM TB_ASS_CUL_CONV_UNI_LOCATEND
    WHERE
        ASS_CUL_ID = pASS_CUL_ID;          
    io_cursor := v_cursor;
  end PRC_ASS_CNV_UNI_LOCATE_RMT_SID;
