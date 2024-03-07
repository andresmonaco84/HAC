

--PRC_CAD_REP_BCP_BASE_CALCULO_D 
create or replace procedure PRC_CAD_REP_BCP_BASE_CALCULO_D 
(
     pCAD_REP_TP_BASE_CALCULO IN TB_CAD_REP_BCP_BASE_CALCULO.CAD_REP_TP_BASE_CALCULO%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_REP_BCP_BASE_CALCULO_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_REP_BCP_BASE_CALCULO
WHERE  
        CAD_REP_TP_BASE_CALCULO = pCAD_REP_TP_BASE_CALCULO;	   
end PRC_CAD_REP_BCP_BASE_CALCULO_D;
