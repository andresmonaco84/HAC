create or replace procedure PRC_ASS_ULC_UNID_LOCAL_CBOS_U
  (
     pCAD_UNI_ID_UNIDADE IN TB_ASS_ULC_UNID_LOCAL_CBOS.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_ULC_UNID_LOCAL_CBOS.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pTIS_CBO_CD_CBOS IN TB_ASS_ULC_UNID_LOCAL_CBOS.TIS_CBO_CD_CBOS%type,
--     pASS_ULC_QTD_ATEND_HORA IN TB_ASS_ULC_UNID_LOCAL_CBOS.ASS_ULC_QTD_ATEND_HORA%type,
     pASS_ULC_FL_STATUS IN TB_ASS_ULC_UNID_LOCAL_CBOS.ASS_ULC_FL_STATUS%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_ULC_UNID_LOCAL_CBOS.SEG_USU_ID_USUARIO%type--,
   --  pASS_ULC_CD_PROGRAMA_ACS IN TB_ASS_ULC_UNID_LOCAL_CBOS.ass_ulc_cd_programa_acs%type DEFAULT NULL
  )
  is
 /********************************************************************
  *    Procedure: PRC_ASS_ULC_UNID_LOCAL_CBOS_U
  *
  *    Data Alteracao:	26/08/2011  Por: Pedro
  *    Alterac?o: Alterac?o de tabela
  *
  *******************************************************************/

  begin
    UPDATE TB_ASS_ULC_UNID_LOCAL_CBOS
    SET
  --      ASS_ULC_QTD_ATEND_HORA        = pASS_ULC_QTD_ATEND_HORA,
        ASS_ULC_FL_STATUS             = pASS_ULC_FL_STATUS,
        SEG_USU_ID_USUARIO            = pSEG_USU_ID_USUARIO,
        ASS_ULC_DT_ULTIMA_ATUALIZACAO = sysdate--,
       -- ASS_ULC_CD_PROGRAMA_ACS      = pASS_ULC_CD_PROGRAMA_ACS
    WHERE
        CAD_UNI_ID_UNIDADE            = pCAD_UNI_ID_UNIDADE
    AND CAD_LAT_ID_LOCAL_ATENDIMENTO  = pCAD_LAT_ID_LOCAL_ATENDIMENTO
    AND TIS_CBO_CD_CBOS               = pTIS_CBO_CD_CBOS;

  end PRC_ASS_ULC_UNID_LOCAL_CBOS_U;
/
