

--PRC_CAD_PRA_PRODUT_AUTOM_D
create or replace procedure PRC_CAD_PRA_PRODUT_AUTOM_D 
(
     pCAD_PRA_ID IN TB_CAD_PRA_PRODUT_AUTOM.CAD_PRA_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_PRA_PRODUT_AUTOM_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_PRA_PRODUT_AUTOM
WHERE  
        CAD_PRA_ID = pCAD_PRA_ID;	   
end PRC_CAD_PRA_PRODUT_AUTOM_D;
