--PRC_CAD_REP_REGRA_PAGAMENTO_D
create or replace procedure PRC_CAD_REP_REGRA_PAGAMENTO_D 
(
     pCAD_REP_ID IN TB_CAD_REP_REGRA_PAGAMENTO.CAD_REP_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_CAD_REP_REGRA_PAGAMENTO_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_CAD_REP_REGRA_PAGAMENTO
WHERE  
        CAD_REP_ID = pCAD_REP_ID;	   
end PRC_CAD_REP_REGRA_PAGAMENTO_D;
