CREATE OR REPLACE PROCEDURE PRC_AUX_MUN_MUNICIPIO_DISP_S
  (
     pAUX_MUN_SG_UF IN TB_AUX_MUN_MUNICIPIO.AUX_MUN_SG_UF%TYPE DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  )
  IS
  /********************************************************************
  *    Procedure: PRC_AUX_MUN_MUNICIPIO_DISP_S
  *
  *    Data Criacao: 	01/08/2007   Por: Fabiola R. Lopes
  *
  *    Funcao: Lista os Municipios Disponível
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  BEGIN
    OPEN v_cursor FOR
    SELECT	 A.AUX_MUN_CD_IBGE,
             A.AUX_MUN_SG_UF,
             A.AUX_MUN_NM_MUNICIPIO
    FROM     TB_AUX_MUN_MUNICIPIO A
    WHERE    AUX_MUN_SG_UF = pAUX_MUN_SG_UF
    AND      NOT EXISTS ( SELECT 1
                          FROM   TB_AUX_RMN_RESTRICAO_MUNICIPIO B
                          WHERE  B.AUX_RMN_SG_UF = A.AUX_MUN_SG_UF
                          AND    B.AUX_RMN_CD_IBGE = A.AUX_MUN_CD_IBGE
                          AND    B.AUX_RMN_SG_UF = pAUX_MUN_SG_UF )
    ORDER BY AUX_MUN_NM_MUNICIPIO;
    io_cursor := v_cursor;
  END PRC_AUX_MUN_MUNICIPIO_DISP_S;
/
