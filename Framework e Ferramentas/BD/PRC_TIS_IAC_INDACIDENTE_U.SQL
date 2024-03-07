create or replace procedure PRC_TIS_MGL_MOTIVO_GLOSA_U
  (
     pTIS_MGL_CD_MOTIVOGLOSA IN TB_TIS_MGL_MOTIVO_GLOSA.TIS_MGL_CD_MOTIVOGLOSA%type,
     pTIS_GGL_CD_GRUPO IN TB_TIS_MGL_MOTIVO_GLOSA.TIS_GGL_CD_GRUPO%type,
     pTIS_MGL_DS_MOTIVOGLOSA IN TB_TIS_MGL_MOTIVO_GLOSA.TIS_MGL_DS_MOTIVOGLOSA%type,
     
     pTIS_MGL_DT_CRIACAO IN TB_TIS_MGL_MOTIVO_GLOSA.TIS_MGL_DT_CRIACAO%TYPE DEFAULT NULL,     
     pSEG_USU_ID_USUARIO_CRIACAO IN TB_TIS_MGL_MOTIVO_GLOSA.SEG_USU_ID_USUARIO_CRIACAO%TYPE DEFAULT NULL,
     pTIS_MGL_DT_ULT_ATULIZACAO IN TB_TIS_MGL_MOTIVO_GLOSA.TIS_MGL_DT_ULT_ATULIZACAO%TYPE DEFAULT NULL,
     pSEG_USU_ID_USU_ULT_ATUALIZ IN TB_TIS_MGL_MOTIVO_GLOSA.SEG_USU_ID_USU_ULT_ATUALIZ%TYPE DEFAULT NULL
 
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_MGL_MOTIVO_GLOSA_U
  *
  *    Data Criacao: 	07/03/2007   Por: Cristiane Gomes da Silva
  *    Data Alteracao:	02/05/2007  Por: Cristiane Gomes da Silva
  *    Data Alterac?o:  25/05/2007  Por: Silmara
  *    Alterac?o:Foi alterado os parametros para gravar em maiusculo
  *    Funcao: Altera Motivo de Glosa - TISS
  *
  *******************************************************************/
  begin
    UPDATE TB_TIS_MGL_MOTIVO_GLOSA
    SET
        TIS_GGL_CD_GRUPO = pTIS_GGL_CD_GRUPO,
        TIS_MGL_DS_MOTIVOGLOSA = UPPER(pTIS_MGL_DS_MOTIVOGLOSA),
        TIS_MGL_DT_ULT_ATULIZACAO = SYSDATE,
        SEG_USU_ID_USU_ULT_ATUALIZ = pSEG_USU_ID_USU_ULT_ATUALIZ
    WHERE
        TIS_MGL_CD_MOTIVOGLOSA = pTIS_MGL_CD_MOTIVOGLOSA;
  end PRC_TIS_MGL_MOTIVO_GLOSA_U;
 