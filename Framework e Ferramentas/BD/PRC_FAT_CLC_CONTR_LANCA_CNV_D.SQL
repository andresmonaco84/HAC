

--PRC_FAT_CLC_CONTR_LANCA_CNV_D
create or replace procedure PRC_FAT_CLC_CONTR_LANCA_CNV_D 
(
     pFAT_CLC_ID IN TB_FAT_CLC_CONTR_LANCA_CNV.FAT_CLC_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_FAT_CLC_CONTR_LANCA_CNV_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_FAT_CLC_CONTR_LANCA_CNV
WHERE  
        FAT_CLC_ID = pFAT_CLC_ID;	   
end PRC_FAT_CLC_CONTR_LANCA_CNV_D;
