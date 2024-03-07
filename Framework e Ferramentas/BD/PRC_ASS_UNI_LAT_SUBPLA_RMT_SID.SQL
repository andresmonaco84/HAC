  --PRC_ASS_UNI_LAT_SUBPLA_RMT_SID
  create or replace procedure PRC_ASS_UNI_LAT_SUBPLA_RMT_SID 
  (
     pASS_USP_ID IN TB_ASS_USP_UNI_LAT_SUB_PLANO.ASS_USP_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_UNI_LAT_SUBPLA_RMT_SID
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
       ASS_USP_ID,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_SPL_ID,
       ASS_USP_FL_STATUS,
       SEG_USU_ID_USUARIO,
       ASS_USP_DT_ULTIMA_ATUALIZACAO,
       CAD_PLA_ID_PLANO
    FROM TB_ASS_USP_UNI_LAT_SUB_PLANO
    WHERE
        ASS_USP_ID = pASS_USP_ID;          
    io_cursor := v_cursor;
  end PRC_ASS_UNI_LAT_SUBPLA_RMT_SID;
