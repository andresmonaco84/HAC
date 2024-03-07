CREATE OR REPLACE PROCEDURE PRC_MTMD_USU_SETOR_S  (
     pCAD_UNI_ID_UNIDADE           IN TB_ASS_ULS_UNID_LOC_SET_USU.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_ULS_UNID_LOC_SET_USU.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pASS_ULS_FL_STATUS            IN TB_ASS_ULS_UNID_LOC_SET_USU.ass_uls_fl_status%TYPE DEFAULT NULL,
     pSEG_USU_ID_USUARIO           IN TB_ASS_ULS_UNID_LOC_SET_USU.seg_usu_id_usuario%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
     ) IS

 /********************************************************************
  *    Procedure: PRC_MTMD_USU_SETOR_S
  *
  *    Data Criacao:  04/05/2010   Por: RICARDO COSTA
  *    Data Alteracao:  Por: Nome do Analista
  *
  *    Funcao: Listar setores que usuario tem acesso
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       ASS.SEG_USU_ID_USUARIO,
       ASS.CAD_UNI_ID_UNIDADE,
       ASS.CAD_SET_ID,
       ASS.CAD_LAT_ID_LOCAL_ATENDIMENTO,
       ASS.ASS_ULS_FL_STATUS,
       SETOR.cad_set_ds_setor
    FROM TB_ASS_ULS_UNID_LOC_SET_USU  ASS,
         TB_CAD_SET_SETOR             SETOR
    WHERE ASS.seg_usu_id_usuario             = pSEG_USU_ID_USUARIO
    AND   ASS.cad_uni_id_unidade             = pCAD_UNI_ID_UNIDADE
    AND   ASS.cad_lat_id_local_atendimento   = pCAD_LAT_ID_LOCAL_ATENDIMENTO
    AND   ( pASS_ULS_FL_STATUS IS NULL OR    ASS.ass_uls_fl_status              = pASS_ULS_FL_STATUS)
    AND   SETOR.cad_set_id                   = ASS.cad_set_id
    AND   SETOR.cad_uni_id_unidade           = ASS.cad_uni_id_unidade
    AND   SETOR.cad_lat_id_local_atendimento = ASS.cad_lat_id_local_atendimento
    AND   SETOR.CAD_SET_FL_ATIVO_OK = 'S'
    ORDER BY SETOR.cad_set_ds_setor;
    io_cursor := v_cursor;
END PRC_MTMD_USU_SETOR_S;