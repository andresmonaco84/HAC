

--PRC_CAD_NFM_NOTA_FIS_MAT_S
create or replace procedure PRC_CAD_NFM_NOTA_FIS_MAT_S 
(
     pCAD_NFM_ID IN TB_CAD_NFM_NOTA_FIS_MAT.CAD_NFM_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_NFM_NOTA_FIS_MAT_S
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
       CAD_NFM_ID,
       CAD_NFM_NR_NF,
       CAD_NFM_DS_SERIE,
       CAD_NFM_DT_EMISSAO,
       CAD_NFM_NM_FORNECEDOR,
       CAD_NFM_NR_CNPJ,
       CAD_NFM_VL_NF,
       CAD_NFM_VL_CALCULADO,
       CAD_PRD_ID,
       CAD_NFM_DS_OBSERVACAO,
       CAD_NFM_DT_ULT_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       CAD_NFM_PC_IPI,
       ATD_ATE_ID
FROM TB_CAD_NFM_NOTA_FIS_MAT
WHERE
        CAD_NFM_ID = pCAD_NFM_ID;          
io_cursor := v_cursor;
end PRC_CAD_NFM_NOTA_FIS_MAT_S;
