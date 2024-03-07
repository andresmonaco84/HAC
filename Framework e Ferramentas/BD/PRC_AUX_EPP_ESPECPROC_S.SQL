create or replace procedure PRC_AUX_EPP_ESPECPROC_S
  (
     pAUX_EPP_CD_ESPECPROC IN TB_AUX_EPP_ESPECPROC.AUX_EPP_CD_ESPECPROC%type DEFAULT NULL,
     pAUX_EPP_DS_DESCRICAO IN TB_AUX_EPP_ESPECPROC.AUX_EPP_DS_DESCRICAO%type DEFAULT NULL,
     pAUX_EPP_FL_ATENDSADT IN TB_AUX_EPP_ESPECPROC.AUX_EPP_FL_ATENDSADT%type DEFAULT NULL,
     pTIS_MED_CD_TABELAMEDICA IN TB_AUX_EPP_ESPECPROC.TIS_MED_CD_TABELAMEDICA%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUX_EPP_ESPECPROC_S
  *
  *    Data Criacao: 	  18/12/2007         Por: Fabiola R. Lopes
  *    Data Alteracao:	data da alteragco  Por: Nome do Analista
  *
  *    Funcao: Lista as Especialidades cadastradas
  *
  *    Data Alteração: 22/03/2010    Por: Davi Silvestre M. dos Reis
  *    Alteracao: Inclusao dos campos AUX_EPP_FL_ATENDSADT e TIS_MED_CD_TABELAMEDICA
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       AUX_EPP_CD_ESPECPROC,
       AUX_EPP_DS_DESCRICAO,
       AUX_EPP_FL_ATENDSADT,
       TIS_MED_CD_TABELAMEDICA
    FROM TB_AUX_EPP_ESPECPROC
    WHERE
        (pAUX_EPP_CD_ESPECPROC is null OR AUX_EPP_CD_ESPECPROC = pAUX_EPP_CD_ESPECPROC)
    AND  (pAUX_EPP_DS_DESCRICAO IS NULL OR AUX_EPP_DS_DESCRICAO LIKE UPPER(pAUX_EPP_DS_DESCRICAO))
    AND  (pAUX_EPP_FL_ATENDSADT IS NULL OR AUX_EPP_FL_ATENDSADT = pAUX_EPP_FL_ATENDSADT)
    AND  (pTIS_MED_CD_TABELAMEDICA IS NULL OR TIS_MED_CD_TABELAMEDICA = pTIS_MED_CD_TABELAMEDICA);
    io_cursor := v_cursor;
  end PRC_AUX_EPP_ESPECPROC_S;
/
