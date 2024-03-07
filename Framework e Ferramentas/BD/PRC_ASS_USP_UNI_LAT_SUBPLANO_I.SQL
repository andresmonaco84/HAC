create or replace procedure PRC_ASS_USP_UNI_LAT_SUBPLANO_I
  (
     pNewIdt OUT integer,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_USP_UNI_LAT_SUB_PLANO.CAD_UNI_ID_UNIDADE%type,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_USP_UNI_LAT_SUB_PLANO.CAD_LAT_ID_LOCAL_ATENDIMENTO%type,
     pCAD_SPL_ID IN TB_ASS_USP_UNI_LAT_SUB_PLANO.CAD_SPL_ID%type,
     pASS_USP_FL_STATUS IN TB_ASS_USP_UNI_LAT_SUB_PLANO.ASS_USP_FL_STATUS%type,
     pSEG_USU_ID_USUARIO IN TB_ASS_USP_UNI_LAT_SUB_PLANO.SEG_USU_ID_USUARIO%type
  )
  is
  /********************************************************************
  *    Procedure: PRC_ASS_USP_UNI_LAT_SUBPLANO_I
  *
  *    Data Criacao:   17/07/2008        Por: Fabiola Lopes
  *    Data Alteracao:  data da alteragco  Por: Nome do Analista
  *
  *    Funcao: Inclui as Associagues de Unidade x Local e Sub-Plano
  *
  *******************************************************************/
  lIdtRetorno integer;
  
  begin

    SELECT SEQ_ASS_USP_01.NextVal INTO lIdtRetorno FROM DUAL;

    INSERT INTO TB_ASS_USP_UNI_LAT_SUB_PLANO
    (
       ASS_USP_ID,
       CAD_UNI_ID_UNIDADE,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_SPL_ID,
       ASS_USP_FL_STATUS,
       SEG_USU_ID_USUARIO,
       ASS_USP_DT_ULTIMA_ATUALIZACAO
    )
    VALUES
    (
       lIdtRetorno,
       pCAD_UNI_ID_UNIDADE,
       pCAD_LAT_ID_LOCAL_ATENDIMENTO,
       pCAD_SPL_ID,
       pASS_USP_FL_STATUS,
       pSEG_USU_ID_USUARIO,
       SYSDATE
    );
  
  pNewIdt := lIdtRetorno;

  end PRC_ASS_USP_UNI_LAT_SUBPLANO_I;
/
