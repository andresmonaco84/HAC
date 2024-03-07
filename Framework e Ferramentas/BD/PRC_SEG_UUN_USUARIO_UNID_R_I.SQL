
--PRC_SEG_UUN_USUARIO_UNID_R_I
create or replace procedure PRC_SEG_UUN_USUARIO_UNID_R_I
(
     pSEG_USU_ID_USUARIO IN TB_SEG_UUN_USUARIO_UNIDADE.SEG_USU_ID_USUARIO%type,
     pCAD_UNI_ID_UNIDADE IN TB_SEG_UUN_USUARIO_UNIDADE.CAD_UNI_ID_UNIDADE%type	
) 
is
/********************************************************************
*    Procedure: PRC_SEG_UUN_USUARIO_UNID_R_I
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
	  
begin
	    
INSERT INTO TB_SEG_UUN_USUARIO_UNIDADE
(
       SEG_USU_ID_USUARIO,
       CAD_UNI_ID_UNIDADE
)
VALUES
(
	     pSEG_USU_ID_USUARIO,
	     pCAD_UNI_ID_UNIDADE
);
	
end PRC_SEG_UUN_USUARIO_UNID_R_I;

