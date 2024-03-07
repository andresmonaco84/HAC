
create or replace procedure PRC_ASS_PFA_PROF_CFM_AA_D 
(
     pASS_PFA_ID_PROF_CFM_AA IN TB_ASS_PFA_PROF_CFM_AA.ASS_PFA_ID_PROF_CFM_AA%type	
)
is
/********************************************************************
*    Procedure: PRC_ASS_PFA_PROF_CFM_AA_D
* 
*    Data Criacao: 	16/04/2012   Por: Andr�
*
*    Funcao: Exclui associa��o de Esp. CFM com profissional e �rea de atua��o
*
*******************************************************************/    
begin
DELETE TB_ASS_PFA_PROF_CFM_AA
WHERE  
        ASS_PFA_ID_PROF_CFM_AA = pASS_PFA_ID_PROF_CFM_AA;	   
end PRC_ASS_PFA_PROF_CFM_AA_D;
