  --PRC_AUX_PRF_PROFISSAO_RMT_U
  create or replace procedure PRC_AUX_PRF_PROFISSAO_RMT_U
  (
     pAUX_PRF_CD_CODIGO IN TB_AUX_PRF_PROFISSAO.AUX_PRF_CD_CODIGO%type,
     pAUX_PRF_DS_DESCRICAO IN TB_AUX_PRF_PROFISSAO.AUX_PRF_DS_DESCRICAO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUX_PRF_PROFISSAO_RMT_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_AUX_PRF_PROFISSAO
    SET	   
        AUX_PRF_DS_DESCRICAO = pAUX_PRF_DS_DESCRICAO 
    WHERE
        AUX_PRF_CD_CODIGO = pAUX_PRF_CD_CODIGO;	
  end PRC_AUX_PRF_PROFISSAO_RMT_U;

