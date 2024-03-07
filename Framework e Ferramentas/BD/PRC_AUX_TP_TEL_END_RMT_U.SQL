  --PRC_AUX_TP_TEL_END_RMT_U
  create or replace procedure PRC_AUX_TP_TEL_END_RMT_U
  (
     pAUX_TTE_CD_TP_TEL_END IN TB_AUX_TTE_TP_TEL_ENDERECO.AUX_TTE_CD_TP_TEL_END%type,
     pAUX_TTE_NM_TIPO IN TB_AUX_TTE_TP_TEL_ENDERECO.AUX_TTE_NM_TIPO%type,
     pAUX_TTE_CD_TIPO IN TB_AUX_TTE_TP_TEL_ENDERECO.AUX_TTE_CD_TIPO%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUX_TP_TEL_END_RMT_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_AUX_TTE_TP_TEL_ENDERECO
    SET	   
        AUX_TTE_NM_TIPO = pAUX_TTE_NM_TIPO,
        AUX_TTE_CD_TIPO = pAUX_TTE_CD_TIPO 
    WHERE
        AUX_TTE_CD_TP_TEL_END = pAUX_TTE_CD_TP_TEL_END;	
  end PRC_AUX_TP_TEL_END_RMT_U;

