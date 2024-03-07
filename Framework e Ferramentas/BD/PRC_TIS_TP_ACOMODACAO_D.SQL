  --PRC_TIS_TP_ACOMODACAO_D
  create or replace procedure PRC_TIS_TP_ACOMODACAO_D 
  (
     pTIS_TAC_CD_TIPO_ACOMODACAO IN TB_TIS_TAC_TIPO_ACOMODACAO.TIS_TAC_CD_TIPO_ACOMODACAO%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_TP_ACOMODACAO_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_TIS_TAC_TIPO_ACOMODACAO
    WHERE  
        TIS_TAC_CD_TIPO_ACOMODACAO = pTIS_TAC_CD_TIPO_ACOMODACAO;	   
  end PRC_TIS_TP_ACOMODACAO_D;
