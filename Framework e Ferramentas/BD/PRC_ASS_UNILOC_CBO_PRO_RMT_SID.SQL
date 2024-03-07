  --PRC_ASS_UNILOC_CBO_PRO_RMT_SID
  create or replace procedure PRC_ASS_UNILOC_CBO_PRO_RMT_SID 
  (
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_UCP_UNID_LOC_CBO_PROF.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_PRO_ID_PROFISSIONAL IN TB_ASS_UCP_UNID_LOC_CBO_PROF.CAD_PRO_ID_PROFISSIONAL%type,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_UCP_UNID_LOC_CBO_PROF.CAD_UNI_ID_UNIDADE%type,
     pTIS_CBO_CD_CBOS IN TB_ASS_UCP_UNID_LOC_CBO_PROF.TIS_CBO_CD_CBOS%type,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_ASS_UNILOC_CBO_PRO_RMT_SID
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
       ASS_UCP_QTD_AGEND_PERM_CBOS,
       ASS_UCP_DS_OBS,
       SEG_USU_ID_USUARIO,
       ASS_UCP_DT_ULTIMA_ATUALIZACAO,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       TIS_CBO_CD_CBOS,
       CAD_PRO_ID_PROFISSIONAL,
       ASS_UCP_FL_STATUS
    FROM TB_ASS_UCP_UNID_LOC_CBO_PROF
    WHERE
        CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
    AND CAD_PRO_ID_PROFISSIONAL = pCAD_PRO_ID_PROFISSIONAL
    AND CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
    AND TIS_CBO_CD_CBOS = pTIS_CBO_CD_CBOS;          
    io_cursor := v_cursor;
  end PRC_ASS_UNILOC_CBO_PRO_RMT_SID;
