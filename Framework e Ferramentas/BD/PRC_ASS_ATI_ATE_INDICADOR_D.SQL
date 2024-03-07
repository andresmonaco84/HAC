

--PRC_ASS_ATI_ATE_INDICADOR_D
create or replace procedure PRC_ASS_ATI_ATE_INDICADOR_D 
(
     pASS_ATI_ID IN TB_ASS_ATI_ATE_INDICADOR.ASS_ATI_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ASS_ATI_ATE_INDICADOR_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ASS_ATI_ATE_INDICADOR
WHERE  
        ASS_ATI_ID = pASS_ATI_ID;	   
end PRC_ASS_ATI_ATE_INDICADOR_D;
