create or replace procedure PRC_ASS_USP_UNI_LAT_SUBPLANO_U
  (
     pASS_USP_ID IN TB_ASS_USP_UNI_LAT_SUB_PLANO.ASS_USP_ID%type,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_USP_UNI_LAT_SUB_PLANO.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_USP_UNI_LAT_SUB_PLANO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_SPL_ID IN TB_ASS_USP_UNI_LAT_SUB_PLANO.CAD_SPL_ID%type,
     pASS_USP_FL_STATUS IN TB_ASS_USP_UNI_LAT_SUB_PLANO.ASS_USP_FL_STATUS%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_USP_UNI_LAT_SUB_PLANO.SEG_USU_ID_USUARIO%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_USP_UNI_LAT_SUBPLANO_U
  *
  *    Data Criacao:   17/07/2008        Por: Fabiola Lopes
  *    Data Alteracao:  data da alteragco  Por: Nome do Analista
  *
  *    Funcao: Altera as Associagues de Unidade x Local e Sub-Plano
  *
  *******************************************************************/
  begin
    UPDATE TB_ASS_USP_UNI_LAT_SUB_PLANO
    SET
        CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE,
        CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO,
        CAD_SPL_ID = pCAD_SPL_ID,
        ASS_USP_FL_STATUS = pASS_USP_FL_STATUS,
        SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO,
        ASS_USP_DT_ULTIMA_ATUALIZACAO = trunc(SYSDATE)
    WHERE
        ASS_USP_ID = pASS_USP_ID;
  end PRC_ASS_USP_UNI_LAT_SUBPLANO_U;
/
