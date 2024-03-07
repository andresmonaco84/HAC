

--PRC_FAT_TCO_TIPO_COMANDA_D
create or replace procedure PRC_FAT_TCO_TIPO_COMANDA_D 
(
     pFAT_TCO_ID IN TB_FAT_TCO_TIPO_COMANDA.FAT_TCO_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_FAT_TCO_TIPO_COMANDA_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_FAT_TCO_TIPO_COMANDA
WHERE  
        FAT_TCO_ID = pFAT_TCO_ID;	   
end PRC_FAT_TCO_TIPO_COMANDA_D;
