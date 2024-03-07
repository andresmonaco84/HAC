create or replace procedure PRC_ASS_USP_UNI_LAT_SUBPLAT_I
  (
     pNewIdt OUT integer,
     pCAD_UNI_ID_UNIDADE IN TB_ASS_USP_UNI_LAT_SUB_PLANO.CAD_UNI_ID_UNIDADE%TYPE,
     pCAD_LAT_ID_LOCAL_ATENDIMENTO IN TB_ASS_USP_UNI_LAT_SUB_PLANO.CAD_LAT_ID_LOCAL_ATENDIMENTO%TYPE,
     pASS_USP_FL_STATUS IN TB_ASS_USP_UNI_LAT_SUB_PLANO.ASS_USP_FL_STATUS%TYPE,
     pSEG_USU_ID_USUARIO IN TB_ASS_USP_UNI_LAT_SUB_PLANO.SEG_USU_ID_USUARIO%TYPE,
     pCAD_CNV_ID_CONVENIO IN TB_CAD_CNV_CONVENIO.CAD_CNV_ID_CONVENIO%TYPE
  )
  IS

  /********************************************************************
  *    Procedure: PRC_ASS_USP_UNI_LAT_SUBPLAT_I
  *
  *    Data Criacao: 	21/07/2008   Por: Fabiola Lopes
  *    Data Alteracao:	data da alteracao  Por: Nome do Analista
  *
  *    Funcao: Inclui a Associacao na Unidade e Local para todos os SubPlanos do Convjnio
  *******************************************************************/

    lIdtRetorno integer;
    nCount integer;
    v_CAD_SPL_ID NUMBER;

  CURSOR cursor_planos is

    SELECT  SPL.CAD_SPL_ID
      FROM  TB_CAD_SPL_SUB_PLANO SPL
     WHERE  SPL.CAD_SPL_FL_STATUS = 'A'
       AND  SPL.CAD_CNV_ID_CONVENIO = pCAD_CNV_ID_CONVENIO;
   
   BEGIN

--  begin transaction;
   FOR X IN cursor_planos LOOP
    v_CAD_SPL_ID := X.CAD_SPL_ID;

    SELECT  COUNT(*)
      INTO  nCount
      FROM  TB_ASS_USP_UNI_LAT_SUB_PLANO USP
     WHERE  USP.CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
       AND  USP.CAD_LAT_ID_LOCAL_ATENDIMENTO = pCAD_LAT_ID_LOCAL_ATENDIMENTO
       AND  USP.CAD_SPL_ID = v_CAD_SPL_ID;

    IF (nCount = 0) then

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
         v_CAD_SPL_ID,
         pASS_USP_FL_STATUS,
         pSEG_USU_ID_USUARIO,
         SYSDATE
       );

    END IF;

   END LOOP;

--  COMMIT
  EXCEPTION
  WHEN OTHERS THEN

--  ROLLBACK;
  raise_application_error(SQLCODE, SQLERRM);

  pNewIdt := lIdtRetorno;

  end PRC_ASS_USP_UNI_LAT_SUBPLAT_I;
  /