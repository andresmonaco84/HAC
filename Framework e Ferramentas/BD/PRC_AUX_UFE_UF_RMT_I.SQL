
  --PRC_AUX_UFE_UF_RMT_I
  create or replace procedure PRC_AUX_UFE_UF_RMT_I
  (
     pAUX_UFE_SG_UF IN TB_AUX_UFE_UF.AUX_UFE_SG_UF%type,
     pAUX_UFE_NM_UF IN TB_AUX_UFE_UF.AUX_UFE_NM_UF%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_AUX_UFE_UF_RMT_I
  * 
  *    Data Criacao: 	data da  criação   Por: Nome do Analista
  *    Data Alteracao:	data da alteração  Por: Nome do Analista
  *
  *    Funcao: Descrição da funcionalidade da Stored Procedure
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_AUX_UFE_UF
    (
       AUX_UFE_SG_UF,
       AUX_UFE_NM_UF
    )
    VALUES
    (
	     pAUX_UFE_SG_UF,
	     pAUX_UFE_NM_UF
    );
	
  end PRC_AUX_UFE_UF_RMT_I;

