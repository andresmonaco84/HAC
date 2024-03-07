
--PRC_CAD_BRA_BRASINDICE_R_D
create or replace procedure PRC_CAD_BRA_BRASINDICE_R_D 
(
     pCAD_BRA_ID IN TB_CAD_BRA_BRASINDICE.CAD_BRA_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_BRA_BRASINDICE_R_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_BRA_BRASINDICE
WHERE  
        CAD_BRA_ID = pCAD_BRA_ID;	   
end PRC_CAD_BRA_BRASINDICE_R_D;
