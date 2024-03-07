create or replace procedure PRC_TIS_MGL_MOTIVO_GLOSA_I
  (
     pTIS_MGL_CD_MOTIVOGLOSA IN TB_TIS_MGL_MOTIVO_GLOSA.TIS_MGL_CD_MOTIVOGLOSA%type,
     pTIS_MGL_DS_MOTIVOGLOSA IN TB_TIS_MGL_MOTIVO_GLOSA.TIS_MGL_DS_MOTIVOGLOSA%type,
     pTIS_GGL_CD_GRUPO  IN TB_TIS_MGL_MOTIVO_GLOSA.TIS_GGL_CD_GRUPO%type,
     pTIS_MGL_DT_CRIACAO IN TB_TIS_MGL_MOTIVO_GLOSA.TIS_MGL_DT_CRIACAO%TYPE DEFAULT NULL,     
     pSEG_USU_ID_USUARIO_CRIACAO IN TB_TIS_MGL_MOTIVO_GLOSA.SEG_USU_ID_USUARIO_CRIACAO%TYPE DEFAULT NULL,
     pTIS_MGL_DT_ULT_ATULIZACAO IN TB_TIS_MGL_MOTIVO_GLOSA.TIS_MGL_DT_ULT_ATULIZACAO%TYPE DEFAULT NULL,
     pSEG_USU_ID_USU_ULT_ATUALIZ IN TB_TIS_MGL_MOTIVO_GLOSA.SEG_USU_ID_USU_ULT_ATUALIZ%TYPE DEFAULT NULL
 
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_MGL_MOTIVO_GLOSA_I
  *
  *    Data Criacao: 	07/03/2007   Por: Cristiane Gomes da Silva
  *    Data Alteracao:	02/05/2007  Por: Cristiane Gomes da Silva
  *    Data Alterac?o:  25/05/2007  Por: Silmara
  *	   Alterac?o: Foi alterado os parametros para gravar em maiusculo
  *    Funcao: Inclui Motivo de Glosa - TISS
  *
  *******************************************************************/
 lIdtRetorno INTEGER;
  begin
    SELECT SEQ_TIS_MGL_01.NextVal INTO lIdtRetorno FROM DUAL;

    INSERT INTO TB_TIS_MGL_MOTIVO_GLOSA
    (
           TIS_MGL_ID,
       TIS_MGL_CD_MOTIVOGLOSA,
       TIS_MGL_DS_MOTIVOGLOSA,
       TIS_GGL_CD_GRUPO,
       TIS_MGL_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       TIS_MGL_DT_ULT_ATULIZACAO,
       SEG_USU_ID_USU_ULT_ATUALIZ

    )
    VALUES
    (
       lIdtRetorno,
	     pTIS_MGL_CD_MOTIVOGLOSA,
	     UPPER(pTIS_MGL_DS_MOTIVOGLOSA),
       pTIS_GGL_CD_GRUPO,
       SYSDATE,
       pSEG_USU_ID_USUARIO_CRIACAO,
       SYSDATE,
       pSEG_USU_ID_USU_ULT_ATUALIZ

    );

  end PRC_TIS_MGL_MOTIVO_GLOSA_I;
 