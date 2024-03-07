  --PRC_INT_TIS_TP_REGINT_D
  create or replace procedure PRC_INT_TIS_TP_REGINT_D 
  (
     pTIS_TRI_CD_TP_REGINTERNACAO IN TB_TIS_TRI_TP_REGINTERNACAO.TIS_TRI_CD_TP_REGINTERNACAO%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_INT_TIS_TP_REGINT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_TIS_TRI_TP_REGINTERNACAO
    WHERE  
        TIS_TRI_CD_TP_REGINTERNACAO = pTIS_TRI_CD_TP_REGINTERNACAO;	   
  end PRC_INT_TIS_TP_REGINT_D;
