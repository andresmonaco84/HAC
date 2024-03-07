

--PRC_FAT_PEC_PERC_EXA_COBRA_S
create or replace procedure PRC_FAT_PEC_PERC_EXA_COBRA_S 
(
     pFAT_PEC_ID IN TB_FAT_PEC_PERC_EXA_COBRA.FAT_PEC_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_FAT_PEC_PERC_EXA_COBRA_S
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
       AUX_EPP_CD_ESPECPROC,
       FAT_PEC_DS_DESCRICAO,
       FAT_PEC_PC_COBRADO_EXA,
       CAD_CNV_ID_CONVENIO,
       FAT_PEC_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       FAT_PEC_CD_CODIGO,
       FAT_PEC_ID,
       TIS_MED_CD_TABELAMEDICA
FROM TB_FAT_PEC_PERC_EXA_COBRA
WHERE
        FAT_PEC_ID = pFAT_PEC_ID;          
io_cursor := v_cursor;
end PRC_FAT_PEC_PERC_EXA_COBRA_S;
