

--PRC_INT_PPR_PRODUTO_U
create or replace procedure PRC_INT_PPR_PRODUTO_U
(
     pINT_PPR_ID IN TB_INT_PPR_PRODUTO.INT_PPR_ID%type,
     pINT_PPR_DS_DESCRICAO IN TB_INT_PPR_PRODUTO.INT_PPR_DS_DESCRICAO%type default NULL,
     pINT_PPR_CD_COR IN TB_INT_PPR_PRODUTO.INT_PPR_CD_COR%type default NULL,
     pINT_PPR_DS_PRINCIPIOATIVO IN TB_INT_PPR_PRODUTO.INT_PPR_DS_PRINCIPIOATIVO%type default NULL,
     pINT_PPR_DS_IRRITANTE IN TB_INT_PPR_PRODUTO.INT_PPR_DS_IRRITANTE%type default NULL,
     pINT_PPR_DS_PH IN TB_INT_PPR_PRODUTO.INT_PPR_DS_PH%type default NULL,
     pINT_PPR_DS_REFBIB IN TB_INT_PPR_PRODUTO.INT_PPR_DS_REFBIB%type default NULL
) 
is
/********************************************************************
*    Procedure: PRC_INT_PPR_PRODUTO_U
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/  
begin
UPDATE TB_INT_PPR_PRODUTO
SET	   
        INT_PPR_DS_DESCRICAO = pINT_PPR_DS_DESCRICAO,
        INT_PPR_CD_COR = pINT_PPR_CD_COR,
        INT_PPR_DS_PRINCIPIOATIVO = pINT_PPR_DS_PRINCIPIOATIVO,
        INT_PPR_DS_IRRITANTE = pINT_PPR_DS_IRRITANTE,
        INT_PPR_DS_PH = pINT_PPR_DS_PH,
        INT_PPR_DS_REFBIB = pINT_PPR_DS_REFBIB 
WHERE
        INT_PPR_ID = pINT_PPR_ID;	
end PRC_INT_PPR_PRODUTO_U;

