  --PRC_AUX_PRF_PROFISSAO_RMT_I
  create or replace procedure PRC_AUX_PRF_PROFISSAO_RMT_I
  (
     pAUX_PRF_CD_CODIGO IN TB_AUX_PRF_PROFISSAO.AUX_PRF_CD_CODIGO%type,
     pAUX_PRF_DS_DESCRICAO IN TB_AUX_PRF_PROFISSAO.AUX_PRF_DS_DESCRICAO%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUX_PRF_PROFISSAO_RMT_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_AUX_PRF_PROFISSAO
    (
       AUX_PRF_CD_CODIGO,
       AUX_PRF_DS_DESCRICAO
    )
    VALUES
    (
	     pAUX_PRF_CD_CODIGO,
	     pAUX_PRF_DS_DESCRICAO
    );
	
  end PRC_AUX_PRF_PROFISSAO_RMT_I;

