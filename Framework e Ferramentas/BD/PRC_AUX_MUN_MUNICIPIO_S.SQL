  create or replace procedure PRC_AUX_MUN_MUNICIPIO_S 
  (
     pAUX_MUN_CD_IBGE IN TB_AUX_MUN_MUNICIPIO.AUX_MUN_CD_IBGE%type DEFAULT NULL,
     pAUX_MUN_SG_UF IN TB_AUX_MUN_MUNICIPIO.AUX_MUN_SG_UF%type DEFAULT NULL,
     io_cursor OUT PKG_CURSOR.t_cursor
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUX_MUN_MUNICIPIO_S 
  * 
  *    Data Criacao: 	31/05/2007   Por: Cristiane Gomes da Silva
  *    Data Alteracao: 20/06/2007   Por: Cristiane Gomes da Silva
  *
  *    Alteração: 1) Inclusão de DEFAULT NULL para o parâmetro 
  *               pAUX_MUN_SG_UF
  *               2) Inclusão do ORDER BY
  *
  *    Funcao: Obtém Município(s)
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
        (pAUX_MUN_CD_IBGE is null OR AUX_MUN_CD_IBGE = pAUX_MUN_CD_IBGE)
    AND (pAUX_MUN_SG_UF is null OR AUX_MUN_SG_UF = pAUX_MUN_SG_UF)
    order by AUX_MUN_NM_MUNICIPIO;          
    io_cursor := v_cursor;
  end PRC_AUX_MUN_MUNICIPIO_S;
/
