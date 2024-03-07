
--PRC_SEG_MPF_MODULO_PERFIL_R_I
create or replace procedure PRC_SEG_MPF_MODULO_PERFIL_R_I
(
     pSEG_PER_ID_PERFIL IN TB_SEG_MPF_MODULO_PERFIL.SEG_PER_ID_PERFIL%type,
     pSEG_MOD_ID_MODULO IN TB_SEG_MPF_MODULO_PERFIL.SEG_MOD_ID_MODULO%type	
) 
is
/********************************************************************
*    Procedure: PRC_SEG_MPF_MODULO_PERFIL_R_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
	  
begin
	    
INSERT INTO TB_SEG_MPF_MODULO_PERFIL
(
       SEG_PER_ID_PERFIL,
       SEG_MOD_ID_MODULO
)
VALUES
(
	     pSEG_PER_ID_PERFIL,
	     pSEG_MOD_ID_MODULO
);
	
end PRC_SEG_MPF_MODULO_PERFIL_R_I;

