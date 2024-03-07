

--PRC_CAD_LOG_ERRO_PROCESSO_D
create or replace procedure PRC_CAD_LOG_ERRO_PROCESSO_D 
(
     pCAD_LOG_ATE_ATD IN TB_CAD_LOG_ERRO_PROCESSO.CAD_LOG_ATE_ATD%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_LOG_ERRO_PROCESSO_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_LOG_ERRO_PROCESSO
WHERE  
        CAD_LOG_ATE_ATD = pCAD_LOG_ATE_ATD;	   
end PRC_CAD_LOG_ERRO_PROCESSO_D;
