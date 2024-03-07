create or replace procedure PRC_ASS_CVP_CONV_VLR_PRODUTO_S
(
     pASS_CVP_ID IN TB_ASS_CVP_CONV_VLR_PRODUTO.ASS_CVP_ID%type,
     io_cursor OUT PKG_CURSOR.t_cursor
)
is
/********************************************************************
*    Procedure: PRC_ASS_CVP_CONV_VLR_PRODUTO_S
*
*    Data Criacao:   11/2009     Por: Alexandre Muniz
*    Data Alteracao: 20/09/2010  Por: André S. Monaco
*         Alteracao: Adição de campos (TIS_MED_CD_TABELAMEDICA,
*                                      AUX_EPP_CD_ESPECPROC,
*                                      AUX_GPC_CD_GRUPOPROC,
*                                      ASS_CVP_FL_STATUS)
*    Data Alteracao: 26/10/2010  Por: André S. Monaco
*         Alteracao: Adição do campo CAD_PRD_ID_TAXA_ADM
*    Data Alteracao: 06/12/2010  Por: André S. Monaco
*         Alteracao: Adição dos campos ASS_CVP_TP_PORTE_SALA
*
*    Funcao: Pesquisa valor de procedimento do convênio
*
*******************************************************************/
v_cursor PKG_CURSOR.t_cursor;
begin
OPEN v_cursor FOR
SELECT
       ASS_CVP_ID,
       CAD_CNV_ID_CONVENIO,
       CAD_LAT_ID_LOCAL_ATENDIMENTO,
       CAD_TAP_TP_ATRIBUTO,
       CAD_PRD_ID,
       CAD_TIH_TP_INDICE_HOSP,
       ASS_CVP_QT_INDICE_HOSP,
       ASS_CVP_VL_INDICE_HOSP,
       ASS_CVP_TP_PORTE,
       ASS_CVP_VL_PRODUTO,
       ASS_CVP_QT_MAXIMA_PERM,
       ASS_CVP_QT_MINIMA_PERM,
       ASS_CVP_PC_ACRESCIMO,
       ASS_CVP_PC_DESCONTO,
       ASS_CVP_VL_ACRESCIMO,
       ASS_CVP_VL_DESCONTO,
       ASS_CVP_PC_TAXAADM,
       ASS_CVP_PC_DOPPLER,
       ASS_CVP_DT_INICIO_VIGENCIA,
       ASS_CVP_DT_FIM_VIGENCIA,
       TIS_CDE_CD_CODIGO_DESPESA,
       ASS_CPE_ID,
       ASS_DT_ULTIMA_ATUALIZACAO,
       SEG_USU_ID_USUARIO,
       ASS_CVP_FL_PC_ACRESCIMOHR,
       ASS_CVP_FL_ISEN_COBRA,
       ASS_CVP_FL_COBERT_ANEST,
       ASS_CVP_TP_UNID_CONSUMO,
       ASS_CVP_PC_ACOMOD_HM,
       CAD_PLA_ID_PLANO,
       CAD_SPL_ID,
       CAD_UNI_ID_UNIDADE,
       TIS_MED_CD_TABELAMEDICA,
       AUX_EPP_CD_ESPECPROC,
       AUX_GPC_CD_GRUPOPROC,
       ASS_CVP_FL_STATUS,
       CAD_PRD_ID_TAXA_ADM,
       ASS_CVP_TP_PORTE_SALA
FROM TB_ASS_CVP_CONV_VLR_PRODUTO
WHERE
        ASS_CVP_ID = pASS_CVP_ID;
io_cursor := v_cursor;
end PRC_ASS_CVP_CONV_VLR_PRODUTO_S;
