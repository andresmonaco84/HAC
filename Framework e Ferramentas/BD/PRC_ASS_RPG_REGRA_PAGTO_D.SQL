--PRC_ASS_RPG_REGRA_PAGTO_D
create or replace procedure PRC_ASS_RPG_REGRA_PAGTO_D 
(
     pASS_RPG_ID IN TB_ASS_RPG_REGRA_PAGTO.ASS_RPG_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ASS_RPG_REGRA_PAGTO_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ASS_RPG_REGRA_PAGTO
WHERE  
        ASS_RPG_ID = pASS_RPG_ID;	   
end PRC_ASS_RPG_REGRA_PAGTO_D;