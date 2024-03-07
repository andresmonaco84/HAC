  --PRC_AUX_NACIONALIDADE_RMT_U
  create or replace procedure PRC_AUX_NACIONALIDADE_RMT_U
  (
     pAUX_NAC_CD_CODIGO IN TB_AUX_NAC_NACIONALIDADE.AUX_NAC_CD_CODIGO%type,
     pAUX_NAC_NM_NOME IN TB_AUX_NAC_NACIONALIDADE.AUX_NAC_NM_NOME%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUX_NACIONALIDADE_RMT_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_AUX_NAC_NACIONALIDADE
    SET	   
        AUX_NAC_NM_NOME = pAUX_NAC_NM_NOME 
    WHERE
        AUX_NAC_CD_CODIGO = pAUX_NAC_CD_CODIGO;	
  end PRC_AUX_NACIONALIDADE_RMT_U;

