

--PRC_CAD_PEC_PERCLME_R_D
create or replace procedure PRC_CAD_PEC_PERCLME_R_D 
(
     pCAD_PEC_ID IN TB_CAD_PEC_PERCLME.CAD_PEC_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_PEC_PERCLME_R_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_PEC_PERCLME
WHERE  
        CAD_PEC_ID = pCAD_PEC_ID;	   
end PRC_CAD_PEC_PERCLME_R_D;
