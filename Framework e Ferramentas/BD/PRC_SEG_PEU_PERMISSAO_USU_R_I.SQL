
--PRC_SEG_PEU_PERMISSAO_USU_R_I
create or replace procedure PRC_SEG_PEU_PERMISSAO_USU_R_I
(
     pSEG_PER_ID_PERFIL IN TB_SEG_PEU_PERMISSAO_USUARIO.SEG_PER_ID_PERFIL%type,
     pSEG_USU_ID_USUARIO IN TB_SEG_PEU_PERMISSAO_USUARIO.SEG_USU_ID_USUARIO%type,
     pCAD_UNI_ID_UNIDADE IN TB_SEG_PEU_PERMISSAO_USUARIO.CAD_UNI_ID_UNIDADE%type,
     pSEG_MOD_ID_MODULO IN TB_SEG_PEU_PERMISSAO_USUARIO.SEG_MOD_ID_MODULO%type	
) 
is
/********************************************************************
*    Procedure: PRC_SEG_PEU_PERMISSAO_USU_R_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
	  
begin
	    
INSERT INTO TB_SEG_PEU_PERMISSAO_USUARIO
(
       SEG_PER_ID_PERFIL,
       SEG_USU_ID_USUARIO,
       CAD_UNI_ID_UNIDADE,
       SEG_MOD_ID_MODULO
)
VALUES
(
	     pSEG_PER_ID_PERFIL,
	     pSEG_USU_ID_USUARIO,
	     pCAD_UNI_ID_UNIDADE,
	     pSEG_MOD_ID_MODULO
);
	
end PRC_SEG_PEU_PERMISSAO_USU_R_I;

