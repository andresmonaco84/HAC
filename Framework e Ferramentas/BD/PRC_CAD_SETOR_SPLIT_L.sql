CREATE OR REPLACE PROCEDURE PRC_CAD_SETOR_SPLIT_L
  (
     pCAD_SET_ID_SPLIT IN VARCHAR2 DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_SETOR_SPLIT_L  --CADASTRO REMOTING
  *
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
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
       CAD_SET_DS_PROCEDENCIA,
       CAD_SET_FL_ATENDSERVMUL_OK,
       CAD_SET_SETOR_ALMOX,
       CAD_SET_UNIDADE_ALMOX,
       CAD_SET_LOCAL_ALMOX,
       CAD_SET_ALMOX_CENTRAL,
       CAD_SET_FL_PERMITEINTERN_OK,
       CAD_SET_FL_PREFERENC_ACS_OK,
       CAD_SET_FL_MOVIMENTAPACINT_OK,
       CAD_SET_FL_PERMITELIBLEITO_OK,
       CAD_SET_FL_LANCATXAUTPORT_OK
    FROM TB_CAD_SET_SETOR
    WHERE CAD_SET_ID IN (SELECT column_value from table(FNC_SPLIT(pCAD_SET_ID_SPLIT)))
    ORDER BY CAD_SET_DS_SETOR;
    io_cursor := v_cursor;
  end PRC_CAD_SETOR_SPLIT_L;
