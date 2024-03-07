--PRC_REP_PPC_PAG_PROF_CLI_D
create or replace procedure PRC_REP_PPC_PAG_PROF_CLI_D 
(
     pREP_PPC_ID IN TB_REP_PPC_PAG_PROF_CLI.REP_PPC_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_REP_PPC_PAG_PROF_CLI_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_REP_PPC_PAG_PROF_CLI
WHERE  
        REP_PPC_ID = pREP_PPC_ID;	   
end PRC_REP_PPC_PAG_PROF_CLI_D;
