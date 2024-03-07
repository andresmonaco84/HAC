

--PRC_INT_PPR_PRODUTO_D
create or replace procedure PRC_INT_PPR_PRODUTO_D 
(
     pINT_PPR_ID IN TB_INT_PPR_PRODUTO.INT_PPR_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_INT_PPR_PRODUTO_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_INT_PPR_PRODUTO
WHERE  
        INT_PPR_ID = pINT_PPR_ID;	   
end PRC_INT_PPR_PRODUTO_D;
