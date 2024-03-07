
--PRC_ASS_CVP_CONV_VLR_PRODUTO_D
create or replace procedure PRC_ASS_CVP_CONV_VLR_PRODUTO_D 
(
     pASS_CVP_ID IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_CVP_ID%type	
)
is
/********************************************************************
*    Procedure: PRC_ASS_CVP_CONV_VLR_PRODUTO_D
* 
*    Data Criacao: 	data da  criação   Por: Nome do Analista
*    Data Alteracao:	data da alteração  Por: Nome do Analista
*
*    Funcao: Descrição da funcionalidade da Stored Procedure
*
*******************************************************************/    
begin
DELETE TB_ASS_CVP_CONV_VLR_PRODUTO
WHERE  
        ASS_CVP_ID = pASS_CVP_ID;	   
end PRC_ASS_CVP_CONV_VLR_PRODUTO_D;
