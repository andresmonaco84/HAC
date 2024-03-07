

--PRC_FAT_MCC_MOV_COM_CONSUMO_D
create or replace procedure PRC_FAT_MCC_MOV_COM_CONSUMO_D 
(
     pFAT_MCC_ID IN TB_FAT_MCC_MOV_COM_CONSUMO.FAT_MCC_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_FAT_MCC_MOV_COM_CONSUMO_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_FAT_MCC_MOV_COM_CONSUMO
WHERE  
        FAT_MCC_ID = pFAT_MCC_ID;	   
end PRC_FAT_MCC_MOV_COM_CONSUMO_D;
