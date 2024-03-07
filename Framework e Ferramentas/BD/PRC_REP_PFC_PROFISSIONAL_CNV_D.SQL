

--PRC_REP_PFC_PROFISSIONAL_CNV_D
create or replace procedure PRC_REP_PFC_PROFISSIONAL_CNV_D 
(
     pREP_PFC_ID IN TB_REP_PFC_PROFISSIONAL_CNV.REP_PFC_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_REP_PFC_PROFISSIONAL_CNV_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_REP_PFC_PROFISSIONAL_CNV
WHERE  
        REP_PFC_ID = pREP_PFC_ID;	   
end PRC_REP_PFC_PROFISSIONAL_CNV_D;
