
--PRC_CAD_UNI_UNIDADE_R_D
create or replace procedure PRC_CAD_UNI_UNIDADE_R_D 
(
     pCAD_UNI_ID_UNIDADE IN TB_CAD_UNI_UNIDADE.CAD_UNI_ID_UNIDADE%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_UNI_UNIDADE_R_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_UNI_UNIDADE
WHERE  
        CAD_UNI_ID_UNIDADE = pCAD_UNI_ID_UNIDADE;	   
end PRC_CAD_UNI_UNIDADE_R_D;
