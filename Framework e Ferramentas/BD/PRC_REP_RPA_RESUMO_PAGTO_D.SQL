--PRC_REP_RPA_RESUMO_PAGTO_D
create or replace procedure PRC_REP_RPA_RESUMO_PAGTO_D 
(
     pREP_RPA_ID IN TB_REP_RPA_RESUMO_PAGTO.REP_RPA_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_REP_RPA_RESUMO_PAGTO_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_REP_RPA_RESUMO_PAGTO
WHERE  
        REP_RPA_ID = pREP_RPA_ID;	   
end PRC_REP_RPA_RESUMO_PAGTO_D;