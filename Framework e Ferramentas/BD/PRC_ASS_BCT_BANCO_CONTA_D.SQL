

--PRC_ASS_BCT_BANCO_CONTA_D
create or replace procedure PRC_ASS_BCT_BANCO_CONTA_D 
(
     pASS_BCT_ID IN TB_ASS_BCT_BANCO_CONTA.ASS_BCT_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ASS_BCT_BANCO_CONTA_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ASS_BCT_BANCO_CONTA
WHERE  
        ASS_BCT_ID = pASS_BCT_ID;	   
end PRC_ASS_BCT_BANCO_CONTA_D;
