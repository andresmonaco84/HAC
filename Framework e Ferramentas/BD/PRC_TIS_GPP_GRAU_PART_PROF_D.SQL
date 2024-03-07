--PRC_TIS_GPP_GRAU_PART_PROF_D
create or replace procedure PRC_TIS_GPP_GRAU_PART_PROF_D 
(
     pTIS_GPP_CD_GRAU_PART_PROF IN TB_TIS_GPP_GRAU_PART_PROF.TIS_GPP_CD_GRAU_PART_PROF%type	
)
is
/********************************************************************
*    Procedure: PRC_TIS_GPP_GRAU_PART_PROF_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_TIS_GPP_GRAU_PART_PROF
WHERE  
        TIS_GPP_CD_GRAU_PART_PROF = pTIS_GPP_CD_GRAU_PART_PROF;	   
end PRC_TIS_GPP_GRAU_PART_PROF_D;
