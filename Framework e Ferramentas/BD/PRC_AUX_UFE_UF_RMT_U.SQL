
  --PRC_AUX_UFE_UF_RMT_U
  create or replace procedure PRC_AUX_UFE_UF_RMT_U
  (
     pAUX_UFE_SG_UF IN TB_AUX_UFE_UF.AUX_UFE_SG_UF%type,
     pAUX_UFE_NM_UF IN TB_AUX_UFE_UF.AUX_UFE_NM_UF%type
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUX_UFE_UF_RMT_U
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
  begin
    UPDATE TB_AUX_UFE_UF
    SET	   
        AUX_UFE_NM_UF = pAUX_UFE_NM_UF 
    WHERE
        AUX_UFE_SG_UF = pAUX_UFE_SG_UF;	
  end PRC_AUX_UFE_UF_RMT_U;

