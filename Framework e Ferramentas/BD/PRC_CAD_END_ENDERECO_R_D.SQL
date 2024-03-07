

--PRC_CAD_END_ENDERECO_R_D
create or replace procedure PRC_CAD_END_ENDERECO_R_D 
(
     pCAD_END_ID_ENDERECO IN TB_CAD_END_ENDERECO.CAD_END_ID_ENDERECO%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_END_ENDERECO_R_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_END_ENDERECO
WHERE  
        CAD_END_ID_ENDERECO = pCAD_END_ID_ENDERECO;	   
end PRC_CAD_END_ENDERECO_R_D;
