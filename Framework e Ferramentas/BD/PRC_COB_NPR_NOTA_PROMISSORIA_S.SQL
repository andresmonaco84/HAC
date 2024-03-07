--PRC_COB_NPR_NOTA_PROMISSORIA_S
create or replace procedure PRC_COB_NPR_NOTA_PROMISSORIA_S 
(
     pCOB_NPR_ID IN TB_COB_NPR_NOTA_PROMISSORIA.COB_NPR_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_COB_NPR_NOTA_PROMISSORIA_S
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
       COB_NPR_ID,
       COB_NPR_NR_NOTA_PROMISSORIA,
       COB_NPR_QT_TOTAL,
       COB_NPR_DT_VENCIMENTO,
       AUX_MUN_CD_IBGE_PRACA,
       COB_NPR_VL_NOTA_PROMISSORIA,
       COB_NPR_DT_EMISSAO,
       AUX_MUN_CD_IBGE_LOCAL_EMISSAO,
       CAD_PES_ID_PESSOA,
       COB_NPR_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       COB_NPR_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO_ATUALIZ
FROM TB_COB_NPR_NOTA_PROMISSORIA
WHERE
        COB_NPR_ID = pCOB_NPR_ID;          
io_cursor := v_cursor;
end PRC_COB_NPR_NOTA_PROMISSORIA_S;
/
