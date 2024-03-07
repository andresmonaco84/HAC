create or replace procedure PRC_AUX_EPP_PRD_CIR_L
  (
     pAUX_EPP_CD_ESPECPROC     IN TB_AUX_EPP_ESPECPROC.AUX_EPP_CD_ESPECPROC%type DEFAULT NULL,
     pAUX_EPP_DS_DESCRICAO     IN TB_AUX_EPP_ESPECPROC.AUX_EPP_DS_DESCRICAO%type DEFAULT NULL,
--     pAUX_EPP_FL_ATENDSADT     IN TB_AUX_EPP_ESPECPROC.AUX_EPP_FL_ATENDSADT%type DEFAULT NULL,
--     pTIS_MED_CD_TABELAMEDICA  IN TB_TIS_MED_TABELAMEDICA.TIS_MED_CD_TABELAMEDICA%TYPE DEFAULT NULL,
     pAUX_EPP_FL_AGENDA_CIRURG IN TB_AUX_EPP_ESPECPROC.AUX_EPP_FL_AGENDA_CIRURG%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUX_EPP_PRD_CIR_L
  *
  *    Data Criacao:  13/09/2018   Por: Fabiola
  *    Data Alteracao:  data da altera��o  Por: Nome do Analista
  *
  *    Funcao: Lista Especialidades de determinada tabela e/ou flag Agenda Cirurgica
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT DISTINCT EPP.AUX_EPP_CD_ESPECPROC,
                    EPP.AUX_EPP_DS_DESCRICAO,
                    EPP.AUX_EPP_FL_ATENDSADT,
                    EPP.TIS_MED_CD_TABELAMEDICA,
                    EPP.AUX_EPP_FL_AGENDA_CIRURG
      FROM TB_AUX_EPP_ESPECPROC EPP
      JOIN TB_CAD_PRD_PRODUTO PRD
        ON PRD.AUX_EPP_CD_ESPECPROC = EPP.AUX_EPP_CD_ESPECPROC
       AND PRD.TIS_MED_CD_TABELAMEDICA = EPP.TIS_MED_CD_TABELAMEDICA
     WHERE --(pAUX_EPP_CD_ESPECPROC IS NULL OR EPP.AUX_EPP_CD_ESPECPROC = pAUX_EPP_CD_ESPECPROC) AND
          -- (pAUX_EPP_DS_DESCRICAO IS NULL OR EPP.AUX_EPP_DS_DESCRICAO = pAUX_EPP_DS_DESCRICAO) AND
  --         (pAUX_EPP_FL_ATENDSADT IS NULL OR EPP.AUX_EPP_FL_ATENDSADT = pAUX_EPP_FL_ATENDSADT) AND
           (PRD.TIS_MED_CD_TABELAMEDICA = 16) AND
           (EPP.AUX_EPP_FL_AGENDA_CIRURG = pAUX_EPP_FL_AGENDA_CIRURG);
    io_cursor := v_cursor;
  end PRC_AUX_EPP_PRD_CIR_L;
/
