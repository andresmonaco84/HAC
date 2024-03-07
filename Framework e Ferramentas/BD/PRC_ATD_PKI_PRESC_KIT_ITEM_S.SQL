

--PRC_ATD_PKI_PRESCRICAO_KIT_ITEM_S
create or replace procedure PRC_ATD_PKI_PRESC_KIT_ITEM_S 
(
     pATD_PKI_ID IN TB_ATD_PKI_PRESCRICAO_KIT_ITEM.ATD_PKI_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_ATD_PKI_PRESCRICAO_KIT_ITEM_S
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
       ATD_PKI_ID,
       ATD_PKI_ID_PAI,
       ATD_PKT_ID,
       ATD_PKI_TIPO,
       ATD_PKI_SAL,
       ATD_PKI_FORMA,
       ATD_PKI_APRESENTACAO,
       CAD_MTMD_ID,
       ATD_PKI_QTD,
       ATD_PKI_ID_USU_ULT_ATUALIZ,
       ATD_PKI_DT_ULT_ATUALIZ,
       ATD_PKI_VIA,
       ATD_PKI_DOSE_ADM,
       ATD_PKI_INTERVALO,
       ATD_PKI_APRAZAMENTO,
       ATD_PKI_OBSERVACAO,
       ATD_PKI_FL_IMEDIATO,
       ATD_PKI_FL_SENECESSARIO,
       ATD_PKI_FL_ACM
FROM TB_ATD_PKI_PRESCRICAO_KIT_ITEM
WHERE
        ATD_PKI_ID = pATD_PKI_ID;          
io_cursor := v_cursor;
end PRC_ATD_PKI_PRESC_KIT_ITEM_S;
