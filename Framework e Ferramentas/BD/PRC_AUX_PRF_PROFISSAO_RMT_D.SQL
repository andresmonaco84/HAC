  --PRC_AUX_PRF_PROFISSAO_RMT_D
  create or replace procedure PRC_AUX_PRF_PROFISSAO_RMT_D 
  (
     pAUX_PRF_CD_CODIGO IN TB_AUX_PRF_PROFISSAO.AUX_PRF_CD_CODIGO%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUX_PRF_PROFISSAO_RMT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AUX_PRF_PROFISSAO
    WHERE  
        AUX_PRF_CD_CODIGO = pAUX_PRF_CD_CODIGO;	   
  end PRC_AUX_PRF_PROFISSAO_RMT_D;
