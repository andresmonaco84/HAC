  --PRC_ASS_UNID_LOCAL_CBO_RMT_SID
  create or replace procedure PRC_ASS_UNID_LOCAL_CBO_RMT_SID 
  (
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_ULC_UNID_LOCAL_CBOS.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_ULC_UNID_LOCAL_CBOS.CAD_UNI_ID_UNIDADE%type,
     pTIS_CBO_CD_CBOS IN TB_ASS_ULC_UNID_LOCAL_CBOS.TIS_CBO_CD_CBOS%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_UNID_LOCAL_CBO_RMT_SID
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT	
       TIS_CBO_CD_CBOS,
       ASS_ULC_QTD_ATEND_HORA,
       SEG_USU_ID_USUARIO,
       ASS_ULC_DT_ULTIMA_ATUALIZACAO,
       ASS_ULC_FL_STATUS,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO--,
       --ASS_ULC_CD_PROGRAMA_ACS
    FROM TB_ASS_ULC_UNID_LOCAL_CBOS
    WHERE
        CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
    AND CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
    AND TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS;          
    io_cursor := v_cursor;
  end PRC_ASS_UNID_LOCAL_CBO_RMT_SID;
