--PRC_REP_PGM_PAGTO_MEDICO_D
create or replace procedure PRC_REP_PGM_PAGTO_MEDICO_D 
(
     pREP_PGM_ID IN TB_REP_PGM_PAGTO_MEDICO.REP_PGM_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_REP_PGM_PAGTO_MEDICO_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_REP_PGM_PAGTO_MEDICO
WHERE  
        REP_PGM_ID = pREP_PGM_ID;	   
end PRC_REP_PGM_PAGTO_MEDICO_D;
