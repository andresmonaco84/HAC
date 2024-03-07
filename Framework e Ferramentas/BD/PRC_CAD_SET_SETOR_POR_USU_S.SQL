create or replace procedure PRC_CAD_SET_SETOR_POR_USU_S
( pSEG_USU_ID_USUARIO IN TB_SEG_USU_USUARIO.SEG_USU_ID_USUARIO%TYPE,
  io_cursor OUT PKG_CURSOR.t_cursor )

is
  /********************************************************************
  *    Procedure: PRC_CAD_SET_SETOR_POR_USU_S
  *
  *    Data Alteração:   20/07/2009  Por: Pedro
  *    Alteração:  Incluído os campos CAD_SET_FL_PREFERENC_ACS_OK e CAD_SET_FL_PERMITEINTERN_OK
  *
  *    Data Alteração:   04/08/2009  Por: Pedro
  *    Alteração:  Incluído o campo CAD_SET_FL_MOVIMENTAPACINT_OK
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
      SELECT DISTINCT
              SETOR.CAD_SET_ID,
              SETOR.CAD_SET_CD_SETOR,
              SETOR.CAD_SET_DS_SETOR,
              SETOR.CAD_SET_NR_TELEFONE,
              SETOR.CAD_SET_FL_SUBSTALMOX_OK,
              SETOR.CAD_SET_FL_ESTQPROPRIO_OK,
              SETOR.CAD_SET_FL_ATIVO_OK,
              SETOR.CAD_SET_FL_GRAVAATEND_OK,
              SETOR.SEG_USU_ID_USUARIO,
              SETOR.CAD_SET_NR_ANDAR,
              SETOR.CAD_SET_DT_ULTIMA_ATUALIZACAO,
              SETOR.CAD_UNI_ID_UNIDADE,
              SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO,
              SETOR.CAD_SET_NR_RAMAL,
              SETOR.CAD_SET_FL_ATENDSERVMUL_OK,
              SETOR.CAD_SET_FL_PREFERENC_ACS_OK,
              SETOR.CAD_SET_FL_PERMITEINTERN_OK,
              SETOR.CAD_SET_FL_MOVIMENTAPACINT_OK
         FROM
              TB_CAD_SET_SETOR SETOR,
              TB_ASS_ULS_UNID_LOC_SET_USU ULS
        WHERE
              ULS.CAD_SET_ID = SETOR.CAD_SET_ID
          AND ULS.SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO
          AND SETOR.CAD_SET_FL_ATIVO_OK = 'S';
    io_cursor := v_cursor;
end PRC_CAD_SET_SETOR_POR_USU_S;
/
