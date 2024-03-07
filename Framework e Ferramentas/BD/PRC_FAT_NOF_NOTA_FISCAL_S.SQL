create or replace procedure PRC_FAT_NOF_NOTA_FISCAL_S
(
     pFAT_NOF_ID IN TB_FAT_NOF_NOTA_FISCAL.FAT_NOF_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
) 
is
/********************************************************************
*    Procedure: PRC_FAT_NOF_NOTA_FISCAL_S
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
       FAT_NOF_ID,
       FAT_NOF_NR_NOTAFISCAL,
       FAT_NOF_TP_SERIEFISCAL,
       CAD_UNI_ID_UNIDADE,
       FAT_NOF_FL_STATUS,
       FAT_NFO_DT_EMISSAO,
       FAT_NFO_DT_VENCIMENTO,
       FAT_NOF_MES_FAT,
       FAT_NOF_ANO_FAT,
       CAD_CNV_ID_CONVENIO,
       CAD_PLA_ID_PLANO,
       FAT_NFO_VL_FATURADO,
       FAT_NFO_VL_RETENCAO,
       FAT_NFO_VL_LIQUIDO,
       FAT_NOF_VL_IR,
       FAT_NOF_PC_IR,
       FAT_NOF_VL_ISS,
       FAT_NOF_PC_ISS,
       FAT_NOF_VL_COFINS,
       FAT_NOF_PC_COFINS,
       FAT_NOF_VL_CSLL,
       FAT_NOF_PC_CSLL,
       FAT_NOF_VL_PIS,
       FAT_NOF_PC_PIS,
       SEG_USU_ID_USUARIO,
       FAT_NOF_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO_CANCELA,
       FAT_NOF_DT_CANCELAMENTO,
       CAD_MCN_ID,
       FAT_NOF_VL_DESCONTO,
       FAT_NOF_DS_DESCONTO,
       FAT_NOF_FL_JURIDICA,
       FAT_NOF_NR_DOCUMENTO,
       FAT_NFO_FL_LIBERADO_COB,
       FAT_NOF_DT_LIBERA_COBRANCA,
       FAT_NOF_FL_LIBERA_PROTOCOLO,
       FAT_NOF_DT_LIBERA_PROTOCOLO,
       FAT_NOF_FL_ENVIO_ELET_REALIZ,
       FAT_NOF_DT_ENVIO_ELETR_REALIZ,
       CAD_UNI_DS_MUNICIPIO,
       CAD_UNI_CD_INSCR_MUNIC,
       CAD_TPE_CD_CODIGO,
       FAT_NOF_TP_GRUPO_PAC,
       SEG_USU_ID_USUARIO_LIB_PROTOC,
       CAD_FEX_NUMERO_FORMULARIO,
       FAT_NOF_OBS_PROTOCOLO,
       CAD_FEX_ID,
       FAT_NOF_FL_HISTORICO,
       FAT_NOF_ST_SITUACAO_SALDO,
       FAT_NOF_DT_ENVIO_HISTORICO,
       SEG_USU_ID_USUARIO_ENVIO_HIST,
       FAT_NOF_VL_NOTAFISCAL
FROM TB_FAT_NOF_NOTA_FISCAL
WHERE
        FAT_NOF_ID = pFAT_NOF_ID;          
io_cursor := v_cursor;
end PRC_FAT_NOF_NOTA_FISCAL_S;
 
/
