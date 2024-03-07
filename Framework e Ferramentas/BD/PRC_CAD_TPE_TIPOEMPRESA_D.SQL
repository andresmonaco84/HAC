--PRC_CAD_TPE_TIPOEMPRESA_D
create or replace procedure PRC_CAD_TPE_TIPOEMPRESA_D 
(
     pCAD_TPE_CD_CODIGO IN TB_CAD_TPE_TIPOEMPRESA.CAD_TPE_CD_CODIGO%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_TPE_TIPOEMPRESA_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_TPE_TIPOEMPRESA
WHERE  
        CAD_TPE_CD_CODIGO = pCAD_TPE_CD_CODIGO;	   
end PRC_CAD_TPE_TIPOEMPRESA_D;
