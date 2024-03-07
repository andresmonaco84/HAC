

--PRC_CAD_IPA_ITEM_PACOTE_S
create or replace procedure PRC_CAD_IPA_ITEM_PACOTE_S 
(
     pCAD_IPA_ID IN TB_CAD_IPA_ITEM_PACOTE.CAD_IPA_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_CAD_IPA_ITEM_PACOTE_S
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
       CAD_IPA_ID,
       CAD_PRD_ID_PACOTE,
       CAD_IPA_VL_ITEM_PACOTE,
       CAD_IPA_PC_RATEIO,
       CAD_IPA_DT_INICIO_VIGENCIA,
       CAD_IPA_DT_FIM_VIGENCIA,
       SEG_USU_ID_USUARIO,
       CAD_IPA_FL_STATUS,
       CAD_IPA_PC_DESCONTO,
       CAD_IPA_PC_ACRESCIMO,
       CAD_IPA_DS_OBSERVACAO,
       CAD_IPA_DT_ULTIMA_ATUALIZACAO,
       CAD_PRD_ID_ITEM_PACOTE,
       CAD_IPA_VL_ORIG_ITEM_PRODUTO,
       CAD_IPA_VL_ACRESCIMO,
       CAD_IPA_VL_DESCONTO,
       CAD_IPA_VL_FINAL_PACOTE,
       CAD_IPA_QT_ITEM_PACOTE
FROM TB_CAD_IPA_ITEM_PACOTE
WHERE
        CAD_IPA_ID = pCAD_IPA_ID;          
io_cursor := v_cursor;
end PRC_CAD_IPA_ITEM_PACOTE_S;
