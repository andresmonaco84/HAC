create or replace procedure PRC_CAD_LAT_POR_UNI_USU_S
  (
    pCAD_UNI_ID_UNIDADE IN TB_CAD_SET_SETOR.CAD_UNI_ID_UNIDADE%TYPE,
    pSEG_USU_ID_USUARIO IN TB_SEG_USU_USUARIO.SEG_USU_ID_USUARIO%TYPE,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_CAD_SET_POR_UNI_USU_S
  * 
  *    Data Criacao: 	19/12/2007   Por: Guilherme Holdack
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Lista setores por unidade x usuario
  *
  *    Data Alteracao: 25/03/2010  Por: Davi Silvestre M. dos Reis
  *    Alteracao: Inclusao do campo CAD_LAT_FL_PERMITE_ATEND (tarefa 8107)
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	DISTINCT
       lat.cad_lat_id_local_atendimento,
       lat.cad_lat_ds_local_atendimento,
       lat.cad_lat_fl_ativo_ok,
       lat.cad_lat_dt_ultima_atualizacao,
       lat.seg_usu_id_usuario,
       lat.cad_lat_cd_local_atendimento,
       lat.cad_lat_fl_permite_atend
    FROM TB_CAD_SET_SETOR setor,
    tb_cad_lat_local_atendimento lat
    WHERE
         lat.cad_lat_id_local_atendimento = setor.cad_lat_id_local_atendimento
        AND setor.seg_usu_id_usuario = pSEG_USU_ID_USUARIO
        AND setor.cad_uni_id_unidade = pCAD_UNI_ID_UNIDADE;          
    io_cursor := v_cursor;
  end PRC_CAD_LAT_POR_UNI_USU_S;
/
