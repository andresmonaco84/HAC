--PRC_ASS_CPR_CLINICA_PROF_D
create or replace procedure PRC_ASS_CPR_CLINICA_PROF_D 
(
     pASS_CPR_ID IN TB_ASS_CPR_CLINICA_PROF.ASS_CPR_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ASS_CPR_CLINICA_PROF_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ASS_CPR_CLINICA_PROF
WHERE  
        ASS_CPR_ID = pASS_CPR_ID;	   
end PRC_ASS_CPR_CLINICA_PROF_D;