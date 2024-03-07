

--PRC_FAT_CRC_CRONOG_FECH_CONV_D
create or replace procedure PRC_FAT_CRC_CRONOG_FECH_CONV_D 
(
     pFAT_CRC_ID IN TB_FAT_CRC_CRONOG_FECH_CONV.FAT_CRC_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_FAT_CRC_CRONOG_FECH_CONV_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_FAT_CRC_CRONOG_FECH_CONV
WHERE  
        FAT_CRC_ID = pFAT_CRC_ID;	   
end PRC_FAT_CRC_CRONOG_FECH_CONV_D;
