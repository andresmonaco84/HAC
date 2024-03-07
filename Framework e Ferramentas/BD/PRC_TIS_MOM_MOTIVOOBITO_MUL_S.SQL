create or replace procedure PRC_TIS_MOM_MOTIVOOBITO_MUL_S
  (
     pTIS_MOM_CD_MOTIVOOBITO IN TB_TIS_MOM_MOTIVOOBITO_MULHER.TIS_MOM_CD_MOTIVOOBITO%type DEFAULT NULL,
     pTIS_MOM_DS_MOTIVOOBITO IN TB_TIS_MOM_MOTIVOOBITO_MULHER.TIS_MOM_DS_MOTIVOOBITO%type DEFAULT NULL,
     
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_MOM_MOTIVOOBITO_MUL_S
  *
  *    Data Criacao:  12/03/2007   Por: Cristiane Gomes da Silva
  *    Data Alteracao: 02/05/2007   Por: Cristiane Gomes da Silva
  *
  *    Funcao: Obtem Motivo(s) de Obito em Mulher - TISS
  *
  *    Data Alteracao: 19/11/2007  Por: Guilherme Holdack
  *    Alterac?o: Remoc?o de Upper em campo, no where
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       TIS_MOM_CD_MOTIVOOBITO,
       TIS_MOM_DS_MOTIVOOBITO,
    TIS_MOM_FL_STATUS,
    TIS_MOM_DT_CRIACAO,
SEG_USU_ID_USUARIO_CRIACAO,
TIS_MOM_DT_ULT_ATUALIZACAO,
SEG_USU_ID_USU_ULT_ATUALIZ

    FROM TB_TIS_MOM_MOTIVOOBITO_MULHER
    WHERE
        (pTIS_MOM_CD_MOTIVOOBITO is null OR TIS_MOM_CD_MOTIVOOBITO = pTIS_MOM_CD_MOTIVOOBITO)
    AND (pTIS_MOM_DS_MOTIVOOBITO is null OR TIS_MOM_DS_MOTIVOOBITO LIKE UPPER('%'||pTIS_MOM_DS_MOTIVOOBITO||'%'))
    ORDER BY TIS_MOM_CD_MOTIVOOBITO;
    io_cursor := v_cursor;
  end PRC_TIS_MOM_MOTIVOOBITO_MUL_S;
 