--PRC_COB_BPC_BANCO_PAGTO_CONV_S
create or replace procedure PRC_COB_BPC_BANCO_PAGTO_CONV_S 
(
     pCOB_BPC_ID IN TB_COB_BPC_BANCO_PAGTO_CONV.COB_BPC_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_COB_BPC_BANCO_PAGTO_CONV_S
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
       COB_BPC_ID,
       ASS_CNU_ID,
       ASS_BCT_ID,
       COB_BPC_DT_INI_VIGENCIA,
       COB_BPC_DT_FIM_VIGENCIA,
       COB_BPC_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       COB_BPC_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO_ATUALIZ
FROM TB_COB_BPC_BANCO_PAGTO_CONV
WHERE
        COB_BPC_ID = pCOB_BPC_ID;          
io_cursor := v_cursor;
end PRC_COB_BPC_BANCO_PAGTO_CONV_S;
/
