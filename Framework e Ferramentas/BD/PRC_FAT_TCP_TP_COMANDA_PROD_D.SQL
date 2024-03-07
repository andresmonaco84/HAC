

--PRC_FAT_TCP_TP_COMANDA_PROD_D
create or replace procedure PRC_FAT_TCP_TP_COMANDA_PROD_D 
(
     pFAT_TCP_ID IN TB_FAT_TCP_TP_COMANDA_PROD.FAT_TCP_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_FAT_TCP_TP_COMANDA_PROD_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_FAT_TCP_TP_COMANDA_PROD
WHERE  
        FAT_TCP_ID = pFAT_TCP_ID;	   
end PRC_FAT_TCP_TP_COMANDA_PROD_D;
