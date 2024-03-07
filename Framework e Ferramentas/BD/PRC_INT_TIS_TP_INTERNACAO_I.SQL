  --PRC_INT_TIS_TP_INTERNACAO_I
  create or replace procedure PRC_INT_TIS_TP_INTERNACAO_I
  (
     pTIS_TIN_CD_INTERNACAO IN TB_TIS_TIN_TP_INTERNACAO.TIS_TIN_CD_INTERNACAO%type,
     pTIS_TIN_DS_INTERNACAO IN TB_TIS_TIN_TP_INTERNACAO.TIS_TIN_DS_INTERNACAO%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_TIS_TP_INTERNACAO_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_TIS_TIN_TP_INTERNACAO
    (
       TIS_TIN_CD_INTERNACAO,
       TIS_TIN_DS_INTERNACAO
    )
    VALUES
    (
	     pTIS_TIN_CD_INTERNACAO,
	     pTIS_TIN_DS_INTERNACAO
    );
	
  end PRC_INT_TIS_TP_INTERNACAO_I;

