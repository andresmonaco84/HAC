CREATE OR REPLACE PROCEDURE PRC_CAD_SETOR_RMT_SID
  (
     pCAD_SET_ID IN TB_CAD_SET_SETOR.CAD_SET_ID%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_SETOR_RMT_SID  --CADASTRO REMOTING
  *
  *    Data Alteracao: 07/12/2012 Por: Andre
  *         Alteracao: Adicao do campo pCAD_SET_FL_CONTROLE_PRONT
  *    Data Alteracao: 25/07/2018 Por: Andre
  *         Alteracao: Adicao do campo CAD_SET_SETOR_FARMACIA
  *
  *    Funcao: Descric?o da funcionalidade da Stored Procedure
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
       CAD_SET_FL_LANCATXAUTPORT_OK,
       CAD_SET_FL_CONTROLE_PRONT,
       CAD_SET_SETOR_FARMACIA,
       CAD_SET_CE_SETOR_PAI
    FROM TB_CAD_SET_SETOR
    WHERE CAD_SET_ID = pCAD_SET_ID
    ORDER BY CAD_SET_DS_SETOR;
    io_cursor := v_cursor;
  end PRC_CAD_SETOR_RMT_SID;