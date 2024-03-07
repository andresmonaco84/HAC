create or replace procedure PRC_ASS_ULS_UNID_LOC_SET_USU_S
  (
     pASS_ULS_ID IN TB_ASS_ULS_UNID_LOC_SET_USU.ASS_ULS_ID%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_ULS_UNID_LOC_SET_USU_S
  *
  *    Data Criacao: 	21/01/2008   Por: Fabiola R. Lopes
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Listar os usuarios associados a unidade x local x setor
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       ASS_ULS_ID,
       SEG_USU_ID_USUARIO,
       CAD_UNI_ID_UNIDADE,
       CAD_SET_ID,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       ASS_ULS_FL_STATUS,
       ASS_DT_ULTIMA_ATUALIZACAO,
       ASS_ULS_ID_USUARIO
    FROM TB_ASS_ULS_UNID_LOC_SET_USU
    WHERE
        (pASS_ULS_ID is null OR ASS_ULS_ID = pASS_ULS_ID);
    io_cursor := v_cursor;
  end PRC_ASS_ULS_UNID_LOC_SET_USU_S;
/
