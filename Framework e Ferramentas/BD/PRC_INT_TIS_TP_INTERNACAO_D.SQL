  --PRC_INT_TIS_TP_INTERNACAO_D
  create or replace procedure PRC_INT_TIS_TP_INTERNACAO_D 
  (
     pTIS_TIN_CD_INTERNACAO IN TB_TIS_TIN_TP_INTERNACAO.TIS_TIN_CD_INTERNACAO%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_INT_TIS_TP_INTERNACAO_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_TIS_TIN_TP_INTERNACAO
    WHERE  
        TIS_TIN_CD_INTERNACAO = pTIS_TIN_CD_INTERNACAO;	   
  end PRC_INT_TIS_TP_INTERNACAO_D;
