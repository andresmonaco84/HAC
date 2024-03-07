
--PRC_SEG_PFU_PERFIL_FUNC_R_I
create or replace procedure PRC_SEG_PFU_PERFIL_FUNC_R_I
(
     pSEG_PER_ID_PERFIL IN TB_SEG_PFU_PERFIL_FUNCIONALID.SEG_PER_ID_PERFIL%type,
     pSEG_MOD_ID_MODULO IN TB_SEG_PFU_PERFIL_FUNCIONALID.SEG_MOD_ID_MODULO%type,
     pSEG_FUN_ID_FUNCIONALIDADE IN TB_SEG_PFU_PERFIL_FUNCIONALID.SEG_FUN_ID_FUNCIONALIDADE%type	
) 
is
/********************************************************************
*    Procedure: PRC_SEG_PFU_PERFIL_FUNCIONALID_R_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
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
	
end PRC_SEG_PFU_PERFIL_FUNC_R_I;

