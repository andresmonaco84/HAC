
--PRC_CAD_SIM_SIMPRO_R_D
create or replace procedure PRC_CAD_SIM_SIMPRO_R_D 
(
     pCAD_SIM_ID IN TB_CAD_SIM_SIMPRO.CAD_SIM_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_SIM_SIMPRO_R_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_SIM_SIMPRO
WHERE  
        CAD_SIM_ID = pCAD_SIM_ID;	   
end PRC_CAD_SIM_SIMPRO_R_D;
