create or replace procedure PRC_TIS_MGL_MOTIVO_GLOSA_S
  (
     pTIS_MGL_CD_MOTIVOGLOSA IN TB_TIS_MGL_MOTIVO_GLOSA.TIS_MGL_CD_MOTIVOGLOSA%type DEFAULT NULL,
     pTIS_MGL_DS_MOTIVOGLOSA IN TB_TIS_MGL_MOTIVO_GLOSA.TIS_MGL_DS_MOTIVOGLOSA%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_MGL_MOTIVO_GLOSA_S
  *
  *    Data Criacao: 	07/03/2007   Por: Cristiane Gomes da Silva
  *    Data Alteracao:	02/05/2007  Por: Cristiane Gomes da Silva
  *
  *    Funcao: Obtem Motivo(s) de Glosa - TISS
  *
  *    Data Alteracao: 19/11/2007  Por: Guilherme Holdack
  *    Alterac?o: Remoc?o de Upper em campo, no where
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       TIS_MGL_CD_MOTIVOGLOSA,
       TIS_MGL_DS_MOTIVOGLOSA,
       TIS_GGL_CD_GRUPO,
       TIS_MGL_DT_CRIACAO,
      SEG_USU_ID_USUARIO_CRIACAO,
      TIS_MGL_DT_ULT_ATULIZACAO,
      SEG_USU_ID_USU_ULT_ATUALIZ
    FROM TB_TIS_MGL_MOTIVO_GLOSA
    WHERE
        (pTIS_MGL_CD_MOTIVOGLOSA is null OR TIS_MGL_CD_MOTIVOGLOSA = pTIS_MGL_CD_MOTIVOGLOSA)
    AND (pTIS_MGL_DS_MOTIVOGLOSA is null OR TIS_MGL_DS_MOTIVOGLOSA LIKE UPPER('%'||pTIS_MGL_DS_MOTIVOGLOSA||'%'))
    ORDER BY TIS_MGL_CD_MOTIVOGLOSA;
    io_cursor := v_cursor;
  end PRC_TIS_MGL_MOTIVO_GLOSA_S;
 