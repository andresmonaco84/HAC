create or replace procedure PRC_ASS_USP_UNI_LAT_SUBPLANO_S
  (
     pASS_USP_ID                   IN TB_ASS_USP_UNI_LAT_SUB_PLANO.ASS_USP_ID%type DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE           IN TB_ASS_USP_UNI_LAT_SUB_PLANO.CAD_UNI_ID_UNIDADE%TYPE DEFAULT NULL,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_USP_UNI_LAT_SUB_PLANO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE DEFAULT NULL,
     pCAD_SPL_ID                   IN TB_ASS_USP_UNI_LAT_SUB_PLANO.CAD_SPL_ID%TYPE DEFAULT NULL,
     pASS_USP_FL_STATUS            IN TB_ASS_USP_UNI_LAT_SUB_PLANO.ASS_USP_FL_STATUS%TYPE DEFAULT NULL,     
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_USP_UNI_LAT_SUBPLANO_S
  *
  *    Data Criacao:   17/07/2008        Por: Fabiola Lopes
  *    Data Alteracao:  data da alteragco  Por: Nome do Analista
  *
  *    Funcao: Lista as Associagues de Unidade x Local e Sub-Plano
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
       ASS_USP_DT_ULTIMA_ATUALIZACAO
    FROM TB_ASS_USP_UNI_LAT_SUB_PLANO
    WHERE
          (pASS_USP_ID is null OR ASS_USP_ID = pASS_USP_ID)
      AND (pCAD_UNI_ID_UNIDADE is null or CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
      AND (pCAD_LAT_ID_LOCAL_ATENDIMENTO is null or CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
      AND (pCAD_SPL_ID is null or CAD_SPL_ID = pCAD_SPL_ID)
      AND (pASS_USP_FL_STATUS is null or ASS_USP_FL_STATUS = pASS_USP_FL_STATUS);
    io_cursor := v_cursor;
  end PRC_ASS_USP_UNI_LAT_SUBPLANO_S;
/
