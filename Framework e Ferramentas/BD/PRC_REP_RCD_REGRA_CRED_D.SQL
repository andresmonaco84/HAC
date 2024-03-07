

--PRC_REP_RCD_REGRA_CRED_D
create or replace procedure PRC_REP_RCD_REGRA_CRED_D 
(
     pREP_RCD_ID IN TB_REP_RCD_REGRA_CRED.REP_RCD_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_REP_RCD_REGRA_CRED_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_REP_RCD_REGRA_CRED
WHERE  
        REP_RCD_ID = pREP_RCD_ID;	   
end PRC_REP_RCD_REGRA_CRED_D;
