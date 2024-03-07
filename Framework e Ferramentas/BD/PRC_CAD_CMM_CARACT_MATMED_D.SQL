

--PRC_CAD_CMM_CARACT_MATMED_D
create or replace procedure PRC_CAD_CMM_CARACT_MATMED_D 
(
     pCAD_CMM_CD_CARACMATMED IN TB_CAD_CMM_CARACT_MATMED.CAD_CMM_CD_CARACMATMED%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_CMM_CARACT_MATMED_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_CMM_CARACT_MATMED
WHERE  
        CAD_CMM_CD_CARACMATMED = pCAD_CMM_CD_CARACMATMED;	   
end PRC_CAD_CMM_CARACT_MATMED_D;
