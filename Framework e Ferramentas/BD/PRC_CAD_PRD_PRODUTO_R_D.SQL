
--PRC_CAD_PRD_PRODUTO_R_D
create or replace procedure PRC_CAD_PRD_PRODUTO_R_D 
(
     pCAD_PRD_ID IN TB_CAD_PRD_PRODUTO.CAD_PRD_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_PRD_PRODUTO_R_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_PRD_PRODUTO
WHERE  
        CAD_PRD_ID = pCAD_PRD_ID;	   
end PRC_CAD_PRD_PRODUTO_R_D;
