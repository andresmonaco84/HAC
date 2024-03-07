

  --PRC_AUX_MUN_MUNICIPIO_D
  create or replace procedure PRC_AUX_MUN_MUNICIPIO_RMT_D
  (
     pAUX_MUN_CD_IBGE IN TB_AUX_MUN_MUNICIPIO.AUX_MUN_CD_IBGE%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUX_MUN_MUNICIPIO_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AUX_MUN_MUNICIPIO
    WHERE  
        AUX_MUN_CD_IBGE = pAUX_MUN_CD_IBGE;	   
  end PRC_AUX_MUN_MUNICIPIO_RMT_D;
