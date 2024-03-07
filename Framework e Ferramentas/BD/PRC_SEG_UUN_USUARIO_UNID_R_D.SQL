--PRC_SEG_UUN_USUARIO_UNID_R_D
create or replace procedure PRC_SEG_UUN_USUARIO_UNID_R_D 
(
     pCAD_UNI_ID_UNIDADE IN TB_SEG_UUN_USUARIO_UNIDADE.CAD_UNI_ID_UNIDADE%type,
     pSEG_USU_ID_USUARIO IN TB_SEG_UUN_USUARIO_UNIDADE.SEG_USU_ID_USUARIO%type	
)
is
/********************************************************************
*    Procedure: PRC_SEG_UUN_USUARIO_UNID_R_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_SEG_UUN_USUARIO_UNIDADE
WHERE  
        CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE
    AND SEG_USU_ID_USUARIO = pSEG_USU_ID_USUARIO;	   
end PRC_SEG_UUN_USUARIO_UNID_R_D;

