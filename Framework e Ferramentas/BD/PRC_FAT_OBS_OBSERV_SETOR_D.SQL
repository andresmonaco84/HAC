

--PRC_FAT_OBS_OBSERV_SETOR_D
create or replace procedure PRC_FAT_OBS_OBSERV_SETOR_D 
(
     pFAT_OBS_ID IN TB_FAT_OBS_OBSERV_SETOR.FAT_OBS_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_FAT_OBS_OBSERV_SETOR_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_FAT_OBS_OBSERV_SETOR
WHERE  
        FAT_OBS_ID = pFAT_OBS_ID;	   
end PRC_FAT_OBS_OBSERV_SETOR_D;
