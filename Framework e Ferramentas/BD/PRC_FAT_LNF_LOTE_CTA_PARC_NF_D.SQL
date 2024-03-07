

--PRC_FAT_LNF_LOTE_CTA_PARC_NF_D
create or replace procedure PRC_FAT_LNF_LOTE_CTA_PARC_NF_D 
(
     pFAT_LNF_ID IN TB_FAT_LNF_LOTE_CTA_PARC_NF.FAT_LNF_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_FAT_LNF_LOTE_CTA_PARC_NF_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_FAT_LNF_LOTE_CTA_PARC_NF
WHERE  
        FAT_LNF_ID = pFAT_LNF_ID;	   
end PRC_FAT_LNF_LOTE_CTA_PARC_NF_D;
