

--PRC_CAD_IND_INDICADOR_D
create or replace procedure PRC_CAD_IND_INDICADOR_D 
(
     pCAD_IND_ID IN TB_CAD_IND_INDICADOR.CAD_IND_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_IND_INDICADOR_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_IND_INDICADOR
WHERE  
        CAD_IND_ID = pCAD_IND_ID;	   
end PRC_CAD_IND_INDICADOR_D;
