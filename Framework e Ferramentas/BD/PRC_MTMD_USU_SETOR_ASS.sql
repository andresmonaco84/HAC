CREATE OR REPLACE PROCEDURE PRC_MTMD_USU_SETOR_ASS(
     pCAD_UNI_ID_UNIDADE           IN TB_ASS_ULS_UNID_LOC_SET_USU.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_ULS_UNID_LOC_SET_USU.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pSEG_USU_ID_USUARIO           IN TB_ASS_ULS_UNID_LOC_SET_USU.seg_usu_id_usuario%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
     ) IS

 /********************************************************************
  *    Procedure: PRC_MTMD_USU_SETOR_ASS
  *
  *    Data Criacao:  04/05/2010   Por: RICARDO COSTA
  *    Data Alteracao:  Por: Nome do Analista
  *
  *    Funcao: Retorna listagem de todos os setor mostrando qual esta associado ao usuario
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       SETOR.cad_set_id,
       SETOR.cad_set_ds_setor,
       ASS.ass_uls_fl_status,
       ASS.ass_uls_id
    FROM TB_ASS_ULS_UNID_LOC_SET_USU  ASS,
         TB_CAD_SET_SETOR             SETOR
    WHERE SETOR.cad_uni_id_unidade            = pCAD_UNI_ID_UNIDADE
    AND   SETOR.cad_lat_id_local_atendimento  = pCAD_LAT_ID_LOCAL_ATENDIMENTO
    AND   ASS.seg_usu_id_usuario(+)              = pSEG_USU_ID_USUARIO
    AND   ASS.cad_set_id(+)                      = SETOR.cad_set_id
    AND   ASS.cad_uni_id_unidade(+)              = SETOR.cad_uni_id_unidade
    AND   ASS.cad_lat_id_local_atendimento(+)    = SETOR.cad_lat_id_local_atendimento
    AND   SETOR.CAD_SET_FL_ATIVO_OK              = 'S'
    ORDER BY SETOR.cad_set_ds_setor;
    io_cursor := v_cursor;
END PRC_MTMD_USU_SETOR_ASS;