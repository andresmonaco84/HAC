  --PRC_TIS_TLG_TP_LOGRADOURO_RMT_D
  create or replace procedure PRC_TIS_TLG_TP_LOGR_RMT_D 
  (
     pTIS_TLG_CD_TPLOGRADOURO IN TB_TIS_TLG_TP_LOGRADOURO.TIS_TLG_CD_TPLOGRADOURO%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_TIS_TLG_TP_LOGRADOURO_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_TIS_TLG_TP_LOGRADOURO
    WHERE  
        TIS_TLG_CD_TPLOGRADOURO = pTIS_TLG_CD_TPLOGRADOURO;	   
  end PRC_TIS_TLG_TP_LOGR_RMT_D;