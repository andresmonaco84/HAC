CREATE OR REPLACE PROCEDURE PRC_CAD_LOCAL_UNIDADE_S
  (
     pCAD_UNI_ID_UNIDADE IN TB_ASS_ULO_UNID_LOCAL.CAD_UNI_ID_UNIDADE%type DEFAULT NULL,
     pCAD_LAT_FL_ATIVO_OK IN TB_CAD_LAT_LOCAL_ATENDIMENTO.CAD_LAT_FL_ATIVO_OK%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  Retorna lista de Locais conforme unidade selecionada no combo
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       LOC.CAD_LAT_ID_LOCAL_ATENDIMENTO,
       LOC.CAD_LAT_DS_LOCAL_ATENDIMENTO,
       LOC.CAD_LAT_FL_ATIVO_OK,
       LOC.CAD_LAT_DT_ULTIMA_ATUALIZACAO,
       LOC.SEG_USU_ID_USUARIO,
       LOC.CAD_LAT_CD_LOCAL_ATENDIMENTO,
       UNID.CAD_UNI_ID_UNIDADE
    FROM TB_CAD_LAT_LOCAL_ATENDIMENTO LOC,
         TB_ASS_ULO_UNID_LOCAL        UNID
    WHERE 
        (pCAD_UNI_ID_UNIDADE is null OR UNID.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE) 
    AND (pCAD_LAT_FL_ATIVO_OK is null OR CAD_LAT_FL_ATIVO_OK = pCAD_LAT_FL_ATIVO_OK)
    AND LOC.cad_lat_id_local_atendimento = UNID.cad_lat_id_local_atendimento
    AND UNID.ASS_ULO_FL_STATUS = 'A'
    ORDER BY UNID.CAD_UNI_ID_UNIDADE, CAD_LAT_DS_LOCAL_ATENDIMENTO;
    io_cursor := v_cursor;
  end PRC_CAD_LOCAL_UNIDADE_S; 
