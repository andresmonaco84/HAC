CREATE OR REPLACE PROCEDURE PRC_AUX_GPC_GRUPOPROC_S
  (
     pAUX_GPC_CD_GRUPOPROC IN TB_AUX_GPC_GRUPOPROC.AUX_GPC_CD_GRUPOPROC%type DEFAULT NULL,
     pAUX_GPC_DS_DESCRICAO IN TB_AUX_GPC_GRUPOPROC.AUX_GPC_DS_DESCRICAO%TYPE DEFAULT NULL,
     pAUX_EPP_CD_ESPECPROC IN TB_AUX_GPC_GRUPOPROC.AUX_EPP_CD_ESPECPROC%TYPE DEFAULT NULL,
     pTIS_MED_CD_TABELAMEDICA IN TB_AUX_GPC_GRUPOPROC.TIS_MED_CD_TABELAMEDICA%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUX_GPC_GRUPOPROC_S
  *
  *    Data Criacao: 	02/01/2008   	 Por: Fabmola Lopes.
  *    Data Alteracao:	26/03/2010  Por: PEDRO
  *    Alteracao: Inclusao do TIS_MED_CD_TABELAMEDICA
  *    Data Alteracao:	11/02/2014   Por: André
  *         Alteracao:	INCLUSAO DE ORDER BY pela AUX_GPC_DS_DESCRICAO
  *
  *    Funcao: Listar os Grupos cadastrados
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
      SELECT
              AUX_GPC_CD_GRUPOPROC,
              AUX_GPC_DS_DESCRICAO,
              AUX_EPP_CD_ESPECPROC,
              TIS_MED_CD_TABELAMEDICA
      FROM
              TB_AUX_GPC_GRUPOPROC
      WHERE
              (pAUX_GPC_CD_GRUPOPROC IS NULL OR AUX_GPC_CD_GRUPOPROC = pAUX_GPC_CD_GRUPOPROC)
      AND      (pAUX_GPC_DS_DESCRICAO IS NULL OR AUX_GPC_DS_DESCRICAO LIKE UPPER(pAUX_GPC_DS_DESCRICAO))
      AND      (pAUX_EPP_CD_ESPECPROC IS NULL OR AUX_EPP_CD_ESPECPROC = pAUX_EPP_CD_ESPECPROC)
      AND      (pTIS_MED_CD_TABELAMEDICA IS NULL OR TIS_MED_CD_TABELAMEDICA = pTIS_MED_CD_TABELAMEDICA)
      ORDER BY AUX_GPC_DS_DESCRICAO;
    io_cursor := v_cursor;
  end PRC_AUX_GPC_GRUPOPROC_S;
 
