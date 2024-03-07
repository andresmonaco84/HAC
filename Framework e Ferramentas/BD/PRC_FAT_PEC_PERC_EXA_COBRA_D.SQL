

--PRC_FAT_PEC_PERC_EXA_COBRA_D
create or replace procedure PRC_FAT_PEC_PERC_EXA_COBRA_D 
(
     pFAT_PEC_ID IN TB_FAT_PEC_PERC_EXA_COBRA.FAT_PEC_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_FAT_PEC_PERC_EXA_COBRA_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_FAT_PEC_PERC_EXA_COBRA
WHERE  
        FAT_PEC_ID = pFAT_PEC_ID;	   
end PRC_FAT_PEC_PERC_EXA_COBRA_D;
