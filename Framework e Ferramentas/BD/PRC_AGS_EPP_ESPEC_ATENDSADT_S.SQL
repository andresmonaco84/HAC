CREATE OR REPLACE PROCEDURE PRC_AGS_EPP_ESPEC_ATENDSADT_S
(
       pAUX_EPP_FL_ATENDSADT IN TB_AUX_EPP_ESPECPROC.AUX_EPP_FL_ATENDSADT%TYPE DEFAULT NULL,
       io_cursor OUT PKG_CURSOR.t_cursor
)
IS
 /********************************************************************
  *    Procedure: PRC_AGS_EPP_ESPEC_ATENDSADT_S
  * 
  *    Data Criacao:   23/03/2009          Por: Fabíola Lopes
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Retorna as especialidades associadas que permitem ou não atendimento sadt
  *
  *******************************************************************/  
v_cursor PKG_CURSOR.t_cursor;

  BEGIN
   OPEN v_cursor FOR

      SELECT EPP.AUX_EPP_CD_ESPECPROC, EPP.AUX_EPP_DS_DESCRICAO
      FROM TB_ASS_ULP_UNID_LOCAL_PROCED ULP
       INNER JOIN TB_AUX_EPP_ESPECPROC EPP
        ON ULP.AUX_EPP_CD_ESPECPROCED = EPP.AUX_EPP_CD_ESPECPROC
        WHERE (pAUX_EPP_FL_ATENDSADT IS NULL OR EPP.AUX_EPP_FL_ATENDSADT = pAUX_EPP_FL_ATENDSADT)
        AND   EPP.TIS_MED_CD_TABELAMEDICA = '90'
      GROUP BY EPP.AUX_EPP_CD_ESPECPROC, EPP.AUX_EPP_DS_DESCRICAO
      ORDER BY EPP.AUX_EPP_DS_DESCRICAO;

io_cursor := v_cursor;

END PRC_AGS_EPP_ESPEC_ATENDSADT_S;
/
