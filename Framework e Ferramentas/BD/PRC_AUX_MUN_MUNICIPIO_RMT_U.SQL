

  --PRC_AUX_MUN_MUNICIPIO_U
  create or replace procedure PRC_AUX_MUN_MUNICIPIO_RMT_U
  (
     pAUX_MUN_CD_IBGE IN TB_AUX_MUN_MUNICIPIO.AUX_MUN_CD_IBGE%type,
     pAUX_MUN_SG_UF IN TB_AUX_MUN_MUNICIPIO.AUX_MUN_SG_UF%type,
     pAUX_MUN_NM_MUNICIPIO IN TB_AUX_MUN_MUNICIPIO.AUX_MUN_NM_MUNICIPIO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUX_MUN_MUNICIPIO_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_AUX_MUN_MUNICIPIO
    SET	   
        AUX_MUN_SG_UF = pAUX_MUN_SG_UF,
        AUX_MUN_NM_MUNICIPIO = pAUX_MUN_NM_MUNICIPIO 
    WHERE
        AUX_MUN_CD_IBGE = pAUX_MUN_CD_IBGE;	
  end PRC_AUX_MUN_MUNICIPIO_RMT_U;