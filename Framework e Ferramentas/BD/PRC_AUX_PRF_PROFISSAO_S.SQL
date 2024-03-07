create or replace procedure PRC_AUX_PRF_PROFISSAO_S
  (
     pAUX_PRF_CD_CODIGO IN TB_AUX_PRF_PROFISSAO.AUX_PRF_CD_CODIGO%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUX_PRF_PROFISSAO_S
  *
  *    Data Criacao: 	08/01/2008   Por: Fabmola Lopes
  *    Data Alteracao:	data da alteragco  Por: Nome do Analista
  *
  *    Funcao: Listar as Profissoes cadastradas
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       AUX_PRF_CD_CODIGO,
       AUX_PRF_DS_DESCRICAO
    FROM TB_AUX_PRF_PROFISSAO
    WHERE
        (pAUX_PRF_CD_CODIGO is null OR AUX_PRF_CD_CODIGO = pAUX_PRF_CD_CODIGO);
    io_cursor := v_cursor;
  end PRC_AUX_PRF_PROFISSAO_S;
/
