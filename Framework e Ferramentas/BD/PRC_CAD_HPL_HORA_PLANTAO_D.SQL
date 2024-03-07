--PRC_CAD_HPL_HORA_PLANTAO_D
create or replace procedure PRC_CAD_HPL_HORA_PLANTAO_D 
(
     pCAD_HPL_ID IN TB_CAD_HPL_HORA_PLANTAO.CAD_HPL_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_HPL_HORA_PLANTAO_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_HPL_HORA_PLANTAO
WHERE  
        CAD_HPL_ID = pCAD_HPL_ID;	   
end PRC_CAD_HPL_HORA_PLANTAO_D;