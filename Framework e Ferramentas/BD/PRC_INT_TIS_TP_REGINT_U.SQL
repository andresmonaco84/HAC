  --PRC_INT_TIS_TP_REGINT_U
  create or replace procedure PRC_INT_TIS_TP_REGINT_U
  (
     pTIS_TRI_CD_TP_REGINTERNACAO IN TB_TIS_TRI_TP_REGINTERNACAO.TIS_TRI_CD_TP_REGINTERNACAO%type,
     pTIS_TRI_DS_TP_REGINTERNACAO IN TB_TIS_TRI_TP_REGINTERNACAO.TIS_TRI_DS_TP_REGINTERNACAO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_INT_TIS_TP_REGINT_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_TIS_TRI_TP_REGINTERNACAO
    SET	   
        TIS_TRI_DS_TP_REGINTERNACAO = pTIS_TRI_DS_TP_REGINTERNACAO 
    WHERE
        TIS_TRI_CD_TP_REGINTERNACAO = pTIS_TRI_CD_TP_REGINTERNACAO;	
  end PRC_INT_TIS_TP_REGINT_U;

