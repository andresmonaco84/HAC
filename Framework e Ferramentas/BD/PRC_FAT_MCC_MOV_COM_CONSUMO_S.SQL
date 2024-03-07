

--PRC_FAT_MCC_MOV_COM_CONSUMO_S
create or replace procedure PRC_FAT_MCC_MOV_COM_CONSUMO_S 
(
     pFAT_MCC_ID IN TB_FAT_MCC_MOV_COM_CONSUMO.FAT_MCC_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_FAT_MCC_MOV_COM_CONSUMO_S
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
       FAT_MCC_ID,
       ATD_ATE_ID,
       FAT_MCC_DT_MOVIMENTACAO,
       FAT_MCC_HR_MOVIMENTACAO,
       FAT_MCC_VL_TOT_MOV_COMANDA,
       FAT_MCC_QT_TOT_ITEM_MOV_COM,
       FAT_MCC_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       FAT_MCC_FL_STATUS,
       FAT_COC_FL_FATURADO,
       ATD_GUI_CD_CODIGO,
       FAT_TCO_ID,
       CAD_SET_ID
FROM TB_FAT_MCC_MOV_COM_CONSUMO
WHERE
        FAT_MCC_ID = pFAT_MCC_ID;          
io_cursor := v_cursor;
end PRC_FAT_MCC_MOV_COM_CONSUMO_S;
