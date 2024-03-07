create or replace procedure PRC_CAD_SET_SETOR_PERMIS_ATE_S
  (
     pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%type DEFAULT NULL,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN tb_cad_lat_local_atendimento.cad_lat_id_local_atendimento%TYPE DEFAULT NULL,
     pCAD_UNI_ID_UNIDADE IN tb_cad_uni_unidade.cad_uni_id_unidade%TYPE DEFAULT NULL,
     pSEG_USU_ID_USUARIO IN TB_SEG_USU_USUARIO.SEG_USU_ID_USUARIO%TYPE DEFAULT NULL,
     pCAD_SET_FL_GRAVAATEND_OK IN TB_CAD_SET_SETOR.CAD_SET_FL_GRAVAATEND_OK%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_SET_SETOR_PERMIS_ATE_S
  *
  *    Data Alteração:   20/07/2009  Por: Pedro
  *    Alteração:  Incluído os campos CAD_SET_FL_PREFERENC_ACS_OK,
                                      CAD_SET_FL_PERMITEINTERN_OK
                                      CAD_SET_FL_MOVIMENTAPACINT_OK
  *
  *    Funcao: Listar todos os setores por Setor, Usuario, Unidade, Local e Permissao de Atendimento
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
     SELECT
             CAD_SET_ID,
             CAD_SET_CD_SETOR,
             CAD_SET_DS_SETOR,
             CAD_SET_NR_TELEFONE,
             CAD_SET_FL_SUBSTALMOX_OK,
             CAD_SET_FL_ESTQPROPRIO_OK,
             CAD_SET_FL_ATIVO_OK,
             CAD_SET_FL_GRAVAATEND_OK,
             SEG_USU_ID_USUARIO,
             CAD_SET_NR_ANDAR,
             CAD_SET_DT_ULTIMA_ATUALIZACAO,
             CAD_UNI_ID_UNIDADE,
             CAD_LAT_ID_LOCAL_ATENDIMENTO,
             CAD_SET_NR_RAMAL,
             CAD_SET_FL_ATENDSERVMUL_OK,
             CAD_SET_FL_PREFERENC_ACS_OK,
             CAD_SET_FL_PERMITEINTERN_OK,
             CAD_SET_FL_MOVIMENTAPACINT_OK
    FROM
             TB_CAD_SET_SETOR
    WHERE

            (pCAD_SET_ID is null OR CAD_SET_ID = pCAD_SET_ID)
            AND (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO)
            AND (pCAD_UNI_ID_UNIDADE IS NULL OR CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
            AND (pSEG_USU_ID_USUARIO IS NULL OR SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO)
            AND (pCAD_SET_FL_GRAVAATEND_OK IS NULL OR CAD_SET_FL_GRAVAATEND_OK = pCAD_SET_FL_GRAVAATEND_OK);

    io_cursor := v_cursor;

END PRC_CAD_SET_SETOR_PERMIS_ATE_S;
/
