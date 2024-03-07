

--PRC_REP_CCC_CLINICA_CRED_CNV_D
create or replace procedure PRC_REP_CCC_CLINICA_CRED_CNV_D 
(
     pREP_CCC_ID IN TB_REP_CCC_CLINICA_CRED_CNV.REP_CCC_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_REP_CCC_CLINICA_CRED_CNV_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_REP_CCC_CLINICA_CRED_CNV
WHERE  
        REP_CCC_ID = pREP_CCC_ID;	   
end PRC_REP_CCC_CLINICA_CRED_CNV_D;
