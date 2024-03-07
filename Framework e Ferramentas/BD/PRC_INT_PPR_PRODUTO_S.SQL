

--PRC_INT_PPR_PRODUTO_S
create or replace procedure PRC_INT_PPR_PRODUTO_S 
(
     pINT_PPR_ID IN TB_INT_PPR_PRODUTO.INT_PPR_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_INT_PPR_PRODUTO_S
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT	
       INT_PPR_ID,
       INT_PPR_DS_DESCRICAO,
       INT_PPR_CD_COR,
       INT_PPR_DS_PRINCIPIOATIVO,
       INT_PPR_DS_IRRITANTE,
       INT_PPR_DS_PH,
       INT_PPR_DS_REFBIB
FROM TB_INT_PPR_PRODUTO
WHERE
        INT_PPR_ID = pINT_PPR_ID;          
io_cursor := v_cursor;
end PRC_INT_PPR_PRODUTO_S;
