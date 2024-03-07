CREATE OR REPLACE PROCEDURE PRC_CAD_UNIDADE_REGIONAIS
  (
     pSO_SANTOS IN NUMBER,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_CAD_UNIDADE_REGIONAIS
  *
  *    Data Criacao: 	19/03/2012   Por: André
  *
  *    Funcao: Query para buscar as unidades de Santos ou Regionais
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR

    SELECT UNI.CAD_UNI_ID_UNIDADE,
           UNI.CAD_UNI_DS_UNIDADE,
           MUN.AUX_MUN_NM_MUNICIPIO
    FROM
    TB_CAD_UNI_UNIDADE UNI,
--    TB_ASS_PEE_PESSOA_ENDERECO PEE,
    TB_CAD_END_ENDERECO END,
    TB_AUX_TTE_TP_TEL_ENDERECO TTE,
    TB_AUX_MUN_MUNICIPIO MUN
    WHERE UNI.CAD_UNI_FL_STATUS = 'A'
    AND UNI.CAD_PES_ID_PESSOA = END.CAD_PES_ID_PESSOA
    AND END.AUX_TTE_CD_TP_TEL_END = TTE.AUX_TTE_CD_TP_TEL_END
    AND TTE.AUX_TTE_NM_TIPO LIKE 'EMPRESA%'
    AND END.AUX_MUN_CD_IBGE = MUN.AUX_MUN_CD_IBGE
    AND (pSO_SANTOS = 0 OR MUN.AUX_MUN_NM_MUNICIPIO LIKE 'SANTOS%')
    AND (pSO_SANTOS = 1 OR MUN.AUX_MUN_NM_MUNICIPIO NOT LIKE 'SANTOS%');

    io_cursor := v_cursor;
  end PRC_CAD_UNIDADE_REGIONAIS;
