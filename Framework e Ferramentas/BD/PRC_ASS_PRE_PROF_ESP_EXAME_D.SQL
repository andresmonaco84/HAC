

--PRC_ASS_PRE_PROF_ESP_EXAME_D
create or replace procedure PRC_ASS_PRE_PROF_ESP_EXAME_D 
(
     pASS_PRE_ID IN TB_ASS_PRE_PROF_ESP_EXAME.ASS_PRE_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ASS_PRE_PROF_ESP_EXAME_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ASS_PRE_PROF_ESP_EXAME
WHERE  
        ASS_PRE_ID = pASS_PRE_ID;	   
end PRC_ASS_PRE_PROF_ESP_EXAME_D;
