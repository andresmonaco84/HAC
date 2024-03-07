  --PRC_AUX_NACIONALIDADE_RMT_I
  create or replace procedure PRC_AUX_NACIONALIDADE_RMT_I
  (
     pAUX_NAC_CD_CODIGO IN TB_AUX_NAC_NACIONALIDADE.AUX_NAC_CD_CODIGO%type,
     pAUX_NAC_NM_NOME IN TB_AUX_NAC_NACIONALIDADE.AUX_NAC_NM_NOME%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUX_NACIONALIDADE_RMT_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_AUX_NAC_NACIONALIDADE
    (
       AUX_NAC_CD_CODIGO,
       AUX_NAC_NM_NOME
    )
    VALUES
    (
	     pAUX_NAC_CD_CODIGO,
	     pAUX_NAC_NM_NOME
    );
	
  end PRC_AUX_NACIONALIDADE_RMT_I;

