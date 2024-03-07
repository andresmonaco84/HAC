create or replace procedure PRC_ASS_PCF_PROF_CFM_D 
(
     pASS_PCF_ID_PROF_CFM IN TB_ASS_PCF_PROF_CFM.ASS_PCF_ID_PROF_CFM%type	
)
is
/********************************************************************
*    Procedure: PRC_ASS_PCF_PROF_CFM_D
* 
*    Data Criacao: 	13/04/2012   Por: Andr�
*
*    Funcao: Exclui associa��o de Especialidade CFM com profissional
*
*******************************************************************/    
begin
DELETE TB_ASS_PCF_PROF_CFM
WHERE  
        ASS_PCF_ID_PROF_CFM = pASS_PCF_ID_PROF_CFM;	   
end PRC_ASS_PCF_PROF_CFM_D;