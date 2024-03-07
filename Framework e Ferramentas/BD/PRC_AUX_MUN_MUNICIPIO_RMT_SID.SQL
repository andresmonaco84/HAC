create or replace procedure PRC_AUX_MUN_MUNICIPIO_RMT_SID
  (
     pAUX_MUN_CD_IBGE IN TB_AUX_MUN_MUNICIPIO.AUX_MUN_CD_IBGE%type,
    io_cursor OUT PKG_CURSOR.t_cursor
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUX_MUN_MUNICIPIO_SID
  *
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/
  v_cursor PKG_CURSOR.t_cursor;
  begin
    OPEN v_cursor FOR
    SELECT
       AUX_MUN_CD_IBGE,
       AUX_MUN_SG_UF,
       AUX_MUN_NM_MUNICIPIO
    FROM TB_AUX_MUN_MUNICIPIO
    WHERE
        AUX_MUN_CD_IBGE = pAUX_MUN_CD_IBGE;
    io_cursor := v_cursor;
  end PRC_AUX_MUN_MUNICIPIO_RMT_SID;
