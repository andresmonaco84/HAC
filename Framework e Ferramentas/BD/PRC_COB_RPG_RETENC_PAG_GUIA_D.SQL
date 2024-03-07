--PRC_COB_RPG_RETENCAO_PAGTO_GUIA_D
create or replace procedure PRC_COB_RPG_RETENC_PAG_GUIA_D 
(
     pCOB_RPG_ID IN TB_COB_RPG_RETENCAO_PAGTO_GUIA.COB_RPG_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_COB_RPG_RETENCAO_PAGTO_GUIA_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_COB_RPG_RETENCAO_PAGTO_GUIA
WHERE  
        COB_RPG_ID = pCOB_RPG_ID;	   
end PRC_COB_RPG_RETENC_PAG_GUIA_D;
/
