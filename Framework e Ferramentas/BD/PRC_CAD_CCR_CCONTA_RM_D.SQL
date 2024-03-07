

--PRC_CAD_CCR_CCONTA_RM_D
create or replace procedure PRC_CAD_CCR_CCONTA_RM_D 
(
     pCAD_CCR_ID IN TB_CAD_CCR_CCONTA_RM.CAD_CCR_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_CCR_CCONTA_RM_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_CCR_CCONTA_RM
WHERE  
        CAD_CCR_ID = pCAD_CCR_ID;	   
end PRC_CAD_CCR_CCONTA_RM_D;
