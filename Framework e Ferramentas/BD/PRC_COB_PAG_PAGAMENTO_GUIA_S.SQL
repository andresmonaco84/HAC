--PRC_COB_PAG_PAGAMENTO_GUIA_S
create or replace procedure PRC_COB_PAG_PAGAMENTO_GUIA_S 
(
     pCOB_PAG_ID IN TB_COB_PAG_PAGAMENTO_GUIA.COB_PAG_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_COB_PAG_PAGAMENTO_GUIA_S
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
       COB_PAG_ID,
       ATD_ATE_ID,
       FAT_COC_ID,
       FAT_CCP_ID,
       ATD_GUI_CD_CODIGO,
       FAT_NOF_ID,
       COB_PAG_DT_PAGAMENTO,
       COB_PAG_VL_PAGAMENTO,
       COB_PAG_DT_CRIACAO,
       SEG_USU_ID_USUARIO_CRIACAO,
       COB_PAG_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO_ATUALIZ,
       CAD_PAC_ID_PACIENTE,
       ATD_GUI_DT_VALIDADE
FROM TB_COB_PAG_PAGAMENTO_GUIA
WHERE
        COB_PAG_ID = pCOB_PAG_ID;          
io_cursor := v_cursor;
end PRC_COB_PAG_PAGAMENTO_GUIA_S;
/
