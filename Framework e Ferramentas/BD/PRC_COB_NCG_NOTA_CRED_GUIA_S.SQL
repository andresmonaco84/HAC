--PRC_COB_NCG_NOTA_CREDITO_GUIA_S
create or replace procedure PRC_COB_NCG_NOTA_CRED_GUIA_S 
(
     pCOB_NCG_ID IN TB_COB_NCG_NOTA_CREDITO_GUIA.COB_NCG_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_COB_NCG_NOTA_CREDITO_GUIA_S
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
       COB_NCG_ID,
       COB_PAG_ID,
       COB_NCG_NR_NOTA_CREDITO,
       COB_NCG_DT_NOTA_CREDITO,
       COB_NCG_VL_NOTA_CREDITO,
       COB_NCG_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       COB_NCG_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO_ATUALIZ
FROM TB_COB_NCG_NOTA_CREDITO_GUIA
WHERE
        COB_NCG_ID = pCOB_NCG_ID;          
io_cursor := v_cursor;
end PRC_COB_NCG_NOTA_CRED_GUIA_S;
/
