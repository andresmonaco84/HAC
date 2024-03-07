  create or replace procedure PRC_SEG_PFU_PERFIL_FUNC_I
  (
     pSEG_PER_ID_PERFIL IN TB_SEG_PFU_PERFIL_FUNCIONALID.SEG_PER_ID_PERFIL%type,
     pSEG_MOD_ID_MODULO IN TB_SEG_PFU_PERFIL_FUNCIONALID.SEG_MOD_ID_MODULO%type,
     pSEG_FUN_ID_FUNCIONALIDADE IN TB_SEG_PFU_PERFIL_FUNCIONALID.SEG_FUN_ID_FUNCIONALIDADE%type	
  ) 
  is
  /********************************************************************
  *    Procedure: PRC_SEG_PFU_PERFIL_FUNC_I
  * 
  *    Data Criacao: 	27/02/2007             Por: Carlos Eduardo
  *    Data Alteracao:	                     Por: 
  *
  *    Funcao: Inclui a associação de Funcionalidade ao Módulo e Perfil
  *
  *******************************************************************/  
	  
  begin
	    
    INSERT INTO TB_SEG_PFU_PERFIL_FUNCIONALID
    (
       SEG_PER_ID_PERFIL,
       SEG_MOD_ID_MODULO,
       SEG_FUN_ID_FUNCIONALIDADE
    )
    VALUES
    (
	     pSEG_PER_ID_PERFIL,
	     pSEG_MOD_ID_MODULO,
	     pSEG_FUN_ID_FUNCIONALIDADE
    );
	
  end PRC_SEG_PFU_PERFIL_FUNC_I;
/
