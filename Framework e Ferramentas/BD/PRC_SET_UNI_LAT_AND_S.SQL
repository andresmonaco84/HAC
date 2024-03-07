create or replace procedure PRC_SET_UNI_LAT_AND_S(pCAD_LAT_ID_LOCAL_ATENDIMENTO IN tb_cad_lat_local_atendimento.cad_lat_id_local_atendimento%TYPE DEFAULT NULL,
                                                  pCAD_UNI_ID_UNIDADE           IN tb_cad_uni_unidade.cad_uni_id_unidade%TYPE DEFAULT NULL,
                                                  pAGE_SAU_CD_ANDAR             IN TB_AGE_SAU_SALA_UNID_AND.AGE_SAU_CD_ANDAR%TYPE DEFAULT NULL,
                                                  pCAD_SET_FL_GRAVAATEND_OK     IN TB_CAD_SET_SETOR.CAD_SET_FL_GRAVAATEND_OK%TYPE DEFAULT NULL,
--                                                  pCAD_SET_FL_ATIVO_OK          IN TB_CAD_SET_SETOR.CAD_SET_FL_ATIVO_OK%TYPE DEFAULT NULL,
                                                  io_cursor                     OUT PKG_CURSOR.t_cursor) is
  /********************************************************************
  *    Procedure: PRC_SET_UNI_LAT_AND_S
  *
  *    Data Criacao:  08/05/200/   Por: Fabiola
  *    Data Alteracao: data da alteracao  Por: Nome do Analista
  *
  *    Funcao:
  *
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
begin
  OPEN v_cursor FOR
    SELECT SETOR.CAD_SET_ID,
           SETOR.CAD_SET_CD_SETOR,
           SETOR.CAD_SET_DS_SETOR,
           SETOR.CAD_SET_NR_TELEFONE,
           SETOR.CAD_SET_FL_SUBSTALMOX_OK,
           SETOR.CAD_SET_FL_ESTQPROPRIO_OK,
           SETOR.CAD_SET_FL_ATIVO_OK,
           SETOR.CAD_SET_FL_GRAVAATEND_OK,
           SETOR.SEG_USU_ID_USUARIO,
           SAU.AGE_SAU_CD_ANDAR,
           SETOR.CAD_SET_DT_ULTIMA_ATUALIZACAO,
           SETOR.CAD_UNI_ID_UNIDADE,
           SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO,
           SETOR.CAD_SET_NR_RAMAL
    
      FROM TB_CAD_SET_SETOR             SETOR,
           TB_ASS_USS_UNID_LOC_SET_SALA USS,
           TB_AGE_SAU_SALA_UNID_AND     SAU
    
     WHERE (pCAD_LAT_ID_LOCAL_ATENDIMENTO IS NULL OR
           SETOR.CAD_LAT_ID_LOCAL_ATENDIMENTO =
           pCAD_LAT_ID_LOCAL_ATENDIMENTO)
       AND (pCAD_UNI_ID_UNIDADE IS NULL OR
           SETOR.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE)
       AND (pCAD_SET_FL_GRAVAATEND_OK IS NULL OR
           CAD_SET_FL_GRAVAATEND_OK = pCAD_SET_FL_GRAVAATEND_OK)
--       AND (pCAD_SET_FL_ATIVO_OK IS NULL OR
--           CAD_SET_FL_ATIVO_OK = pCAD_SET_FL_ATIVO_OK)
       AND SETOR.CAD_SET_ID = USS.CAD_SET_ID
       AND USS.AGE_SAU_ID = SAU.AGE_SAU_ID
       AND SAU.AGE_SAU_CD_ANDAR = pAGE_SAU_CD_ANDAR
     ORDER BY CAD_SET_DS_SETOR;
  io_cursor := v_cursor;

end PRC_SET_UNI_LAT_AND_S;
/
