

--PRC_CAD_FEX_FORMULARIO_EXPED_D
create or replace procedure PRC_CAD_FEX_FORMULARIO_EXPED_D 
(
     pCAD_FEX_ID IN TB_CAD_FEX_FORMULARIO_EXPED.CAD_FEX_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_FEX_FORMULARIO_EXPED_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_FEX_FORMULARIO_EXPED
WHERE  
        CAD_FEX_ID = pCAD_FEX_ID;	   
end PRC_CAD_FEX_FORMULARIO_EXPED_D;
