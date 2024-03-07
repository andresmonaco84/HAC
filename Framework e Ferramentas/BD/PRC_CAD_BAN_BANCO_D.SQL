--PRC_CAD_BAN_BANCO_D
create or replace procedure PRC_CAD_BAN_BANCO_D 
(
     pCAD_BAN_ID IN TB_CAD_BAN_BANCO.CAD_BAN_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_BAN_BANCO_D
* 
*    Data Criacao: 	12/8/2011   Por: Pedro
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_BAN_BANCO
WHERE  
        CAD_BAN_ID = pCAD_BAN_ID;	   
end PRC_CAD_BAN_BANCO_D;
/
