

--PRC_COB_MGC_MOV_GUIA_S
create or replace procedure PRC_COB_MGC_MOV_GUIA_S 
(
     pCOB_MGC_ID IN TB_COB_MGC_MOV_GUIA_COBRANCA.COB_MGC_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_COB_MGC_MOV_GUIA_S
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
       COB_MGC_ID,
       FAT_NOF_ID,
       ATD_ATE_ID,
       CAD_PAC_ID_PACIENTE,
       COB_COC_ID,
       COB_CCP_ID,
       ATD_GUI_CD_CODIGO,
       ATD_GUI_DT_VALIDADE,
       CAD_TMC_ID,
       COB_MGC_DT_MOVIMENTO,
       COB_MGC_VL_MOVIMENTO,
       COB_MGC_NR_NOTA_CREDITO,
       CAD_MGC_DT_REGISTRO,
       SEG_USU_ID_USUARIO_REG,
       COB_MGC_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO_ATUALIZ,
       COB_MGC_NR_PROT_PROTESTO,
       COB_MGC_DS_MOTIVO_BAIXA,
       COB_MGC_DT_LIBERACAO_CONTAB,
       COB_MGC_PC_ISS,
       COB_MGC_VL_ISS,
       COB_MGC_PC_IR,
       COB_MGC_VL_IR,
       COB_MGC_PC_CSLL,
       COB_MGC_VL_CSLL,
       COB_MGC_PC_COFINS,
       COB_MGC_VL_COFINS,
       COB_MGC_PC_PIS,
       COB_MGC_VL_PIS,
       ASS_BCT_ID
       COB_MGC_VL_MOVIMENTO_BRUTO,
       COB_MGC_VL_BASE_CALCULO
FROM TB_COB_MGC_MOV_GUIA_COBRANCA
WHERE
        COB_MGC_ID = pCOB_MGC_ID;          
io_cursor := v_cursor;
end PRC_COB_MGC_MOV_GUIA_S;
