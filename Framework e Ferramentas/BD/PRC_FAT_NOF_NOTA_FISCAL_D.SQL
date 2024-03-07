

--PRC_FAT_NOF_NOTA_FISCAL_D
create or replace procedure PRC_FAT_NOF_NOTA_FISCAL_D 
(
     pFAT_NOF_ID IN TB_FAT_NOF_NOTA_FISCAL.FAT_NOF_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_FAT_NOF_NOTA_FISCAL_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_FAT_NOF_NOTA_FISCAL
WHERE  
        FAT_NOF_ID = pFAT_NOF_ID;	   
end PRC_FAT_NOF_NOTA_FISCAL_D;
