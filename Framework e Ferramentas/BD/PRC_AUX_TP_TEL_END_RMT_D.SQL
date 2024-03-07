  --PRC_AUX_TP_TEL_END_RMT_D
  create or replace procedure PRC_AUX_TP_TEL_END_RMT_D 
  (
     pAUX_TTE_CD_TP_TEL_END IN TB_AUX_TTE_TP_TEL_ENDERECO.AUX_TTE_CD_TP_TEL_END%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUX_TP_TEL_END_RMT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AUX_TTE_TP_TEL_ENDERECO
    WHERE  
        AUX_TTE_CD_TP_TEL_END = pAUX_TTE_CD_TP_TEL_END;	   
  end PRC_AUX_TP_TEL_END_RMT_D;
