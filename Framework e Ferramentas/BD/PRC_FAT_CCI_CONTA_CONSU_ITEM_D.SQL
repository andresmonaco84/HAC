--PRC_FAT_CCI_CONTA_CONSU_ITEM_D
create or replace procedure PRC_FAT_CCI_CONTA_CONSU_ITEM_D 
(
     pFAT_CCI_ID IN TB_FAT_CCI_CONTA_CONSU_ITEM.FAT_CCI_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_FAT_CCI_CONTA_CONSU_ITEM_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin

update tb_ass_pap_pac_aten_proc pap
set pap.fat_cci_id = null
where pap.fat_cci_id = pFAT_CCI_ID;

DELETE TB_FAT_CCI_CONTA_CONSU_ITEM
WHERE  
        FAT_CCI_ID = pFAT_CCI_ID;	   
        
end PRC_FAT_CCI_CONTA_CONSU_ITEM_D;
