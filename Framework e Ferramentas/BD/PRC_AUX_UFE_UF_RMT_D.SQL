

  --PRC_AUX_UFE_UF_RMT_D
  create or replace procedure PRC_AUX_UFE_UF_RMT_D 
  (
     pAUX_UFE_SG_UF IN TB_AUX_UFE_UF.AUX_UFE_SG_UF%type	
  )
  is
  /********************************************************************
  *    Procedure: PRC_AUX_UFE_UF_RMT_D
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/    
  begin
    DELETE TB_AUX_UFE_UF
    WHERE  
        AUX_UFE_SG_UF = pAUX_UFE_SG_UF;	   
  end PRC_AUX_UFE_UF_RMT_D;
