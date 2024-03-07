create or replace procedure PRC_AUX_NAC_NACIONALIDADE_S
  (
     pAUX_NAC_CD_CODIGO IN TB_AUX_NAC_NACIONALIDADE.AUX_NAC_CD_CODIGO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUX_NAC_NACIONALIDADE_S
  *
  *    Data Criacao: 	08/01/2008   Por: Fabmola Lopes
  *    Data Alteracao:	data da alteragco  Por: Nome do Analista
  *
  *    Funcao: Listar as Nacionalidades cadastradas
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       AUX_NAC_CD_CODIGO,
       AUX_NAC_NM_NOME
    FROM TB_AUX_NAC_NACIONALIDADE
    WHERE
        (pAUX_NAC_CD_CODIGO is null OR AUX_NAC_CD_CODIGO = pAUX_NAC_CD_CODIGO);
    io_cursor := v_cursor;
  end PRC_AUX_NAC_NACIONALIDADE_S;
/
