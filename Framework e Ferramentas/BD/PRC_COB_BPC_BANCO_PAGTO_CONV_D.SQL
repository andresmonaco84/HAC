--PRC_COB_BPC_BANCO_PAGTO_CONV_D
create or replace procedure PRC_COB_BPC_BANCO_PAGTO_CONV_D 
(
     pCOB_BPC_ID IN TB_COB_BPC_BANCO_PAGTO_CONV.COB_BPC_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_COB_BPC_BANCO_PAGTO_CONV_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_COB_BPC_BANCO_PAGTO_CONV
WHERE  
        COB_BPC_ID = pCOB_BPC_ID;	   
end PRC_COB_BPC_BANCO_PAGTO_CONV_D;
/
